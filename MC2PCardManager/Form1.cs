using Ionic.Zip;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC2PCardManager
{
    public partial class FormMain : Form
    {
        public static readonly string[] TYPES_WITH_ROMS = { "Computers", "Consoles"};

        private bool _loading = true, _loadingRomsTree = false;

        private eMCModels _myModel = eMCModels.Undefined;
        private string
            _localPath = "",
            _currentHead = "",
            _modelFolder = ""
        ;

        private Dictionary<string, string> _romsPath = new Dictionary<string, string>();

        private Multicore2Repo _mc2repo = new Multicore2Repo();

        private List<FileInfo> _sdCardFiles = new List<FileInfo>();
        private SDDriveInfo _sdDrive;

        private bool _waitingDowload = false;

        private MulticoreCoreZipFile _selectedCore = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void loadSDFiles()
        {
            this._sdCardFiles.Clear();            
            DirectoryInfo dirInfo = new DirectoryInfo(this._sdDrive.DriveInfo.Name);
            this._sdCardFiles.AddRange(dirInfo.GetFiles());
            //this.loadLocalPath();
            if (tvLocalPath.Nodes.Count > 0) updateExistingCores();
        }
        private void updateExistingCores()
        {
            this.UncheckAllNodes(tvLocalPath.Nodes);
            List<TreeNode> nodesCores = new List<TreeNode>();
            bool haveUpdates = false;
            foreach(TreeNode tnT in tvLocalPath.Nodes[0].Nodes)
            {
                foreach (TreeNode tnC in tnT.Nodes) nodesCores.Add(tnC);
            }
            if (nodesCores.Count > 0)
            {
                foreach (TreeNode tnCore in nodesCores)
                {
                    MulticoreCoreZipFile mcZip = (MulticoreCoreZipFile)tnCore.Tag;
                    using (ZipFile zip = ZipFile.Read(mcZip.FileInfo.FullName))
                    {
                        foreach (ZipEntry e in zip)
                        {
                            FileInfo sdInfo = (from FileInfo fiSD in this._sdCardFiles where fiSD.Name == e.FileName select fiSD).FirstOrDefault();
                            tnCore.Checked = (sdInfo != null);

                            if (sdInfo == null) continue;

                            #region check if was updated
                            mcZip.WasUpdated = (sdInfo.Length != mcZip.FileInfo.Length) || (sdInfo.LastWriteTime != mcZip.FileInfo.LastWriteTime);
                            if (mcZip.WasUpdated) tnCore.Tag = mcZip;
                            haveUpdates |= mcZip.WasUpdated;
                            #endregion check if was updated
                            //zipContents += e.FileName + "\r\n";
                            //if (!haveAll) break;
                        }
                    }
                }
                if (haveUpdates) tvLocalPath.Refresh();
            }
        }

        private void updateExistingRoms()
        {
            this.UncheckAllNodes(tvRoms.Nodes);
            string sdRomPath = _sdDrive.DriveInfo.RootDirectory + "ROMS" + Path.DirectorySeparatorChar + this._selectedCore.Name + Path.DirectorySeparatorChar;
            DirectoryInfo di = new DirectoryInfo(sdRomPath);
            if (di.Exists)
            {
                List<FileInfo> sdFiles = di.GetFiles().ToList();
                foreach (TreeNode tnRom in tvRoms.Nodes)
                {
                    FileInfo fi = (FileInfo)tnRom.Tag;
                    string dPath = sdRomPath + fi.Name;
                    tnRom.Checked = (from FileInfo sfi in sdFiles where sfi.Name.Equals(fi.Name) select sfi).FirstOrDefault() != null;
                }
            }
        }

        private void loadConfig()
        {
            this._localPath = Properties.Settings.Default.LocalPath;
            this._currentHead = Properties.Settings.Default.CurrentHead;
            string[] models = Properties.Settings.Default.MCModels.Split(';');
            foreach (string model in models) cbMCModel.Items.Add(model);
            this._myModel = (eMCModels)Properties.Settings.Default.MyMCModel;
            cbMCModel.SelectedIndex = Properties.Settings.Default.MyMCModel;
            _romsPath.Clear();
            string _rp = Properties.Settings.Default.RomsPath;
            if (!string.IsNullOrEmpty(_rp))
            {
                _romsPath = JsonConvert.DeserializeObject<Dictionary<string, string>>(_rp);                
            }
        }
        private void updateCoresRomPaths()
        {
            foreach (KeyValuePair<string, string> kvp in _romsPath)
            {
                MulticoreCoreZipFile core = (from MulticoreCoreZipFile cz in _mc2repo.Cores where cz.Name.Equals(kvp.Key) select cz).FirstOrDefault();
                if (core != null) core.RomsFolder = kvp.Value;
            }
        }

        private void saveConfig()
        {
            Properties.Settings.Default.LocalPath = this._localPath;
            Properties.Settings.Default.CurrentHead = this._currentHead;
            Properties.Settings.Default.MyMCModel = (int)this._myModel;
            if (_romsPath.Count > 0)
            {
                Properties.Settings.Default.RomsPath = JsonConvert.SerializeObject(_romsPath);
            }
            Properties.Settings.Default.Save();
        }

        private bool chooseLocalPath()
        {
            bool ret = true;
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                Description = "Selecione a pasta onde estão (ou ficarão) os arquivos do repositório do MC2+"
            };
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                this._localPath = fbd.SelectedPath;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        private void loadRemovableDrives()
        {
            cbDrives.Items.Clear();
            Cursor.Current = Cursors.WaitCursor;
            List<DriveInfo> drives = DriveInfo.GetDrives()
                .Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable).ToList();
            
            foreach(DriveInfo di in drives)
            {
                cbDrives.Items.Add(new SDDriveInfo(di));
            }
            if (cbDrives.Items.Count > 0) cbDrives.SelectedIndex = 0;
            if (drives.Count == 1) loadSDFiles();
            Cursor.Current = Cursors.Default;
        }

        private void loadDirectory(TreeView treeView, string path)
        {
            _mc2repo.TypeDirs.Clear(); _mc2repo.Model = _myModel;
            TreeNode rootNode = new TreeNode(cbMCModel.Text);
            foreach (DirectoryInfo typeDir in new DirectoryInfo(path).GetDirectories())
            {
                Multicore2TypeDirectory mc2TDir = new Multicore2TypeDirectory() { 
                    Name = typeDir.Name
                };
                TreeNode typeNode = new TreeNode(typeDir.Name);
                foreach (DirectoryInfo hardDir in typeDir.GetDirectories())
                {
                    MulticoreDirectory MCDir = new MulticoreDirectory()
                    {
                        DirInfo = hardDir
                    };
                    foreach (FileInfo file in hardDir.GetFiles())
                    {
                        
                        if (file.Name.ToUpper().Equals("README.MD"))
                        {
                            MCDir.Readme = File.ReadAllText(file.FullName);
                        }
                        
                        if (file.Extension.ToUpper().Equals(".ZIP"))
                        {
                            TreeNode itemNode = new TreeNode(file.Name.ToUpper().Replace(".ZIP",""));
                            bool haveAll = true;
                            string zipContents = "";
                            using (ZipFile zip = ZipFile.Read(file.FullName))
                            {
                                foreach (ZipEntry e in zip)
                                {
                                    haveAll &= ((from FileInfo fi in this._sdCardFiles where fi.Name == e.FileName select fi.Name).FirstOrDefault() != null);
                                    zipContents += e.FileName + "\r\n";
                                    //if (!haveAll) break;
                                }
                                itemNode.Tag = file;
                                itemNode.Checked = haveAll;
                            }
                            typeNode.Nodes.Add(itemNode);
                        }
                        MCDir.Cores.Add(new MulticoreCoreZipFile() { FileInfo = file });
                    }
                    mc2TDir.Directories.Add(MCDir);
                } //hardwareDir
                rootNode.Nodes.Add(typeNode);
                _mc2repo.TypeDirs.Add(mc2TDir);
            } // typeDir
            treeView.Nodes.Add(rootNode);
        }

        private void loadRepository(string path)
        {
            _mc2repo.TypeDirs.Clear(); _mc2repo.Model = _myModel;
            
            foreach (DirectoryInfo typeDir in new DirectoryInfo(path).GetDirectories())
            {
                Multicore2TypeDirectory mc2TDir = new Multicore2TypeDirectory()
                {
                    Name = typeDir.Name, 
                    HaveRoms = TYPES_WITH_ROMS.Contains(typeDir.Name)
                };

                foreach (DirectoryInfo hardDir in typeDir.GetDirectories())
                {
                    MulticoreDirectory MCDir = new MulticoreDirectory()
                    {
                        DirInfo = hardDir, 
                        TypeDir = mc2TDir
                    };
                    foreach (FileInfo file in hardDir.GetFiles())
                    {

                        if ((file.Name.ToUpper().Equals("README.MD")) || (file.Name.ToUpper().Equals("README.TXT")))
                        {
                            MCDir.Readme = File.ReadAllText(file.FullName);
                        }
                        else
                        {
                            if (file.Extension.ToUpper().Equals(".ZIP"))
                            {
                                //bool haveAll = true;
                                string zipContents = "";
                                using (ZipFile zip = ZipFile.Read(file.FullName))
                                {
                                    foreach (ZipEntry e in zip)
                                    {
                                        //haveAll &= ((from FileInfo fi in this._sdCardFiles where fi.Name == e.FileName select fi.Name).FirstOrDefault() != null);
                                        zipContents += e.FileName + "\r\n";
                                        //if (!haveAll) break;
                                    }
                                }
                                MulticoreCoreZipFile core = new MulticoreCoreZipFile()
                                {
                                    FileInfo = file,
                                    ZipContents = zipContents,//.Split(new char[] { '\r', '\n' }),
                                    HardDir = MCDir
                                };
                                if (_romsPath.ContainsKey(file.Name)) core.RomsFolder = _romsPath[file.Name];
                                MCDir.Cores.Add(core);
                            }
                        }
                    }
                    mc2TDir.Directories.Add(MCDir);
                } //hardwareDir
                _mc2repo.TypeDirs.Add(mc2TDir);
            } // typeDir

            #region detect cores with repeating names
            //var dups = _mc2repo.Cores.GroupBy(n => n.FileInfo.Name).Where(c => c.Count() > 1).Select(x => x).ToList();
            List<string> dups = _mc2repo.Cores.GroupBy(n => n.FileInfo.Name).SelectMany(g => g.Skip(1)).Distinct().Select(s=>s.FileInfo.Name).ToList();
            if (dups.Count > 0)
            {
                foreach (string corename in dups)
                {
                    foreach(MulticoreCoreZipFile core in _mc2repo.Cores.Where(c => c.FileInfo.Name.Equals(corename)).Select(s => s).ToList())
                    {
                        core.SameName = true;
                    }
                }
            }
            #endregion detect cores with repeating names

            this.updateCoresRomPaths();
        }

        private void loadTreeView()
        {
            this._selectedCore = null;
            tvLocalPath.Nodes.Clear();
            TreeNode root = new TreeNode(_mc2repo.ToString());
            foreach(Multicore2TypeDirectory typeDir in _mc2repo.TypeDirs)
            {
                TreeNode typeNode = new TreeNode(typeDir.ToString());
                foreach(MulticoreDirectory mcDir in typeDir.Directories)
                {
                    foreach(MulticoreCoreZipFile core in mcDir.Cores)
                    {
                        TreeNode coreNode = new TreeNode(core.ToString().ToUpper().Replace(".ZIP","")) { Tag = core };
                        typeNode.Nodes.Add(coreNode);
                    }
                }
                root.Nodes.Add(typeNode);
            }
            tvLocalPath.Nodes.Add(root);
            tvLocalPath.Sort();
            tvLocalPath.Nodes[0].Expand();
        }

        public void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        private void loadLocalPath()
        {
            if (_loading) return; //previne repetição ao abrir o programa

            Cursor.Current = Cursors.WaitCursor;
            tvLocalPath.Nodes.Clear();
            if (this._myModel != eMCModels.Undefined)
            {
                string mPath = this._localPath + Path.DirectorySeparatorChar + this._modelFolder;
                if (Directory.Exists(mPath))
                {
                    this.loadRepository(mPath);
                    this.loadTreeView();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.loadConfig();
            if (string.IsNullOrEmpty(this._localPath))
            {
                if (!this.chooseLocalPath())
                {
                    MessageBox.Show("O programa não pode funcionar sem que o local do repositório seja informado e será fechado.");
                    Application.Exit();
                }
                this.saveConfig();
            }
            if (!Directory.Exists(this._localPath))
            {
                if (MessageBox.Show("O caminho local do repositório não existe, gostaria de criá-lo?", "Confirmação para criação de pastas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                }
                else
                {
                    MessageBox.Show("O programa não pode funcionar sem que o caminho local do repositório exista e será fechado.");
                    Application.Exit();
                }
            }
            txtLocalPath.Text = this._localPath;
            
            _loading = false;
            this.loadLocalPath();
            this.loadRemovableDrives();
        }

        private string downloadLatest()
        {
            string ret = this._localPath + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyyMMdd-HHmm") + "_Multicore_Bitstreams-master.zip";
            pBar.Value = 0;  pBar.Maximum = 100; pBar.Visible = true;
            lbProgressMsg.Text = "Fazendo download do repositorio"; lbProgressMsg.Visible = true;
            try
            {
                using (var webCli = new WebClient())
                {
                    //webCli.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.146 Safari/537.36";
                    webCli.DownloadProgressChanged += delegate (object o, System.Net.DownloadProgressChangedEventArgs ee)
                    {
                        lbProgressMsg.Text = "Baixando arquivo..." + ee.BytesReceived / 1024 + " Kb";
                    };
                    webCli.DownloadFileCompleted += delegate (object o, System.ComponentModel.AsyncCompletedEventArgs ee)
                    {
                        pBar.Visible = false; lbProgressMsg.Visible = false;
                        this._waitingDowload = false;

                        if ((ee.Error != null) || (ee.Cancelled))
                        {
                            return;
                        }
                    };
                    webCli.DownloadFileAsync(new System.Uri("https://gitlab.com/victor.trucco/Multicore_Bitstreams/-/archive/master/Multicore_Bitstreams-master.zip"), ret);                    
                }
            }
            catch (Exception ex)
            {
                ret = string.Empty;
            }
            return ret;
        }

        private void extractDownloadedZip(string zipPath)
        {
            pBar.Value = 0; 
            lbProgressMsg.Text = "Extraindo conteúdo do ZIP..."; lbProgressMsg.Visible = true;
            pnTop.Refresh();
            using (ZipFile zip = ZipFile.Read(zipPath))
            {
                pBar.Maximum = zip.Count; pBar.Visible = true;
                zip.ExtractProgress += delegate (object o, ExtractProgressEventArgs ee)
                {
                    if (ee.EventType == ZipProgressEventType.Saving_AfterWriteEntry) pBar.Value++;
                };
                //zip.ExtractAll(this._localPath, ExtractExistingFileAction.OverwriteSilently);
                foreach (ZipEntry ze in zip)
                {
                    if (ze.FileName.Equals("Multicore_Bitstreams-master/")) continue; //ignora a criação do diretório-raiz
                    string newPath = Path.Combine(this._localPath, ze.FileName.Replace("Multicore_Bitstreams-master/", ""));

                    if (ze.IsDirectory)
                    {
                        if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);
                    }
                    else
                    {
                        using (FileStream stream = new FileStream(newPath, FileMode.Create))
                            ze.Extract(stream);
                    }
                }
            }
            pBar.Visible = false; lbProgressMsg.Visible = false;
        }

        private void btAtualizaDrives_Click(object sender, EventArgs e)
        {
            this.loadRemovableDrives();
        }

        private void cbDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDrives.SelectedIndex == -1)
            {
                this._sdDrive = null;
            }
            else
            {
                this._sdDrive = (SDDriveInfo)cbDrives.Items[cbDrives.SelectedIndex];
                this.loadSDFiles();
            }
        }
        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            this.saveConfig();
        }

        private void tvLocalPath_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 2) // nodes dos itens
            {
                FileInfo fi = ((MulticoreCoreZipFile)e.Node.Tag).FileInfo;
                using (ZipFile zip = ZipFile.Read(fi.FullName))
                {
                    if (e.Node.Checked) //adiciona
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            try
                            {
                                zip.ExtractAll(_sdDrive.DriveInfo.RootDirectory.Name);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    else //remove
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            try
                            {
                                foreach (ZipEntry ze in zip)
                                {
                                    string path = _sdDrive.DriveInfo.RootDirectory.Name + ze.FileName;
                                    File.Delete(path);
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    }
                }
            }
        }

        private void tvLocalPath_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtReadme.Text = "";
            if(e.Node != null)
            {
                if(e.Node.Tag != null)
                {
                    if (e.Node.Tag.GetType().Equals(typeof(MulticoreCoreZipFile)))
                    {
                        this.showCoreInfo((MulticoreCoreZipFile)e.Node.Tag);
                    }
                }
            }
        }

        private void showCoreInfo(MulticoreCoreZipFile core)
        {
            this._selectedCore = core;
            this.clearInfo();
            gbReadme.Visible = (!string.IsNullOrEmpty(core.HardDir.Readme));
            txtReadme.Text = string.IsNullOrEmpty(core.HardDir.Readme) ? "" : core.HardDir.Readme;
            txtZipContents.Text = core.ZipContents;
            gbRomsDir.Visible = core.HardDir.TypeDir.HaveRoms;
            txtRomsDir.Text = core.RomsFolder;
            btBrowseRomDir.Tag = core;
            if (core.HardDir.TypeDir.HaveRoms) this.loadRomsTree(core); else tvRoms.Nodes.Clear();
        }

        private void loadRomsTree(MulticoreCoreZipFile core)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _loadingRomsTree = true;
                tvRoms.Nodes.Clear();
                gbRoms.Text = "Roms para core selecionado";

                if (string.IsNullOrEmpty(core.RomsFolder))
                {
                    tvRoms.CheckBoxes = false;
                    tvRoms.Nodes.Add(new TreeNode("Diretório de ROMs não informado"));
                }
                else
                {
                    gbRoms.Text += " (" + _sdDrive.DriveInfo.RootDirectory + "ROMS" + Path.DirectorySeparatorChar + core.Name + ")";
                    tvRoms.CheckBoxes = true;
                    DirectoryInfo di = new DirectoryInfo(core.RomsFolder);
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        TreeNode tn = new TreeNode(fi.Name) { Tag = fi };
                        tvRoms.Nodes.Add(tn);
                    }
                    this.updateExistingRoms();
                }
            }
            finally
            {
                _loadingRomsTree = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btBrowseRomDir_Click(object sender, EventArgs e)
        {
            MulticoreCoreZipFile core = ((MulticoreCoreZipFile)btBrowseRomDir.Tag);
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true,
                Description = "Selecione o diretorio com as ROMS de " + core.HardDir.ToString()
            };
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                if(fbd.SelectedPath != core.RomsFolder)
                {
                    core.RomsFolder = fbd.SelectedPath;
                    txtRomsDir.Text = core.RomsFolder;
                    if (_romsPath.ContainsKey(core.Name)) 
                        _romsPath[core.Name] = core.RomsFolder; 
                    else 
                        _romsPath.Add(core.Name, core.RomsFolder);
                    this.saveConfig();
                }
            }
        }

        private void btRomPaths_Click(object sender, EventArgs e)
        {
            using (FormRoms frmRoms = new FormRoms(this._romsPath, this._mc2repo))
            {
                if (frmRoms.ShowDialog(this) == DialogResult.OK)
                {
                    _romsPath = frmRoms.RomPaths;
                    this.saveConfig();
                    this.loadRomsTree(this._selectedCore);
                }
            }
        }

        private void tvLocalPath_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            MulticoreCoreZipFile core = (MulticoreCoreZipFile)e.Node.Tag;
            e.DrawDefault = !core.WasUpdated;
            if (!e.DrawDefault)
            {
                
            }
        }

        private void btGitLab_Click(object sender, EventArgs e)
        {
            btGitLab.Visible = false;
            try
            {
                pBar.Value = 0;
                pBar.Visible = true;
                this._waitingDowload = true;
                string downloadedFile = this.downloadLatest();
                while (this._waitingDowload)
                {
                    Application.DoEvents();
                }
                if (!string.IsNullOrEmpty(downloadedFile))
                {
                    extractDownloadedZip(downloadedFile);
                    loadLocalPath();
                }
                else
                {
                    //erro no download
                }
            }
            finally
            {
                btGitLab.Visible = false;
            }
        }

        private void tvRoms_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (_loadingRomsTree) return;

            FileInfo fi = (FileInfo)e.Node.Tag;
            string
                oPath = fi.FullName,
                dPath = _sdDrive.DriveInfo.RootDirectory + "ROMS" + Path.DirectorySeparatorChar + this._selectedCore.Name + Path.DirectorySeparatorChar + fi.Name;
            if (e.Node.Checked) //adiciona
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(dPath)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(dPath));
                        }
                        File.Copy(oPath, dPath);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            else //remove
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        if (File.Exists(dPath)) File.Delete(dPath);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void clearInfo()
        {
            gbReadme.Visible = true;
            txtReadme.Clear();
            gbZipContents.Visible = true;
            txtZipContents.Clear();
            txtRomsDir.Clear();
            tvRoms.Nodes.Clear();
        }

        private void cbMCModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._modelFolder = "";
            switch (cbMCModel.SelectedIndex)
            {
                case 1:
                    {
                        this._modelFolder = "Multicore";
                        break;
                    }
                case 2:
                    {
                        this._modelFolder = "Multicore 2";
                        break;
                    }
                case 3:
                    {
                        this._modelFolder = "Multicore 2 Plus";
                        break;
                    }
            }
            this._myModel = (eMCModels)cbMCModel.SelectedIndex;
            this.loadLocalPath();
        }
    }
    public class SDDriveInfo
    {
        private DriveInfo _info;
        public DriveInfo DriveInfo { get { return this._info; } }
        public SDDriveInfo (DriveInfo info)
        {
            this._info = info;
        }
        public override string ToString()
        {
            return string.Format(
                "{0} [{1} - {2}] - {3} Mb livres",
                this._info.Name.Replace("\\", ""), 
                this._info.VolumeLabel,                
                this._info.DriveFormat,
                this._info.TotalFreeSpace / 1024 / 1024
            );
        }
    }
}

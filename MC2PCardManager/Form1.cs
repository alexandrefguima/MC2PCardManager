using Ionic.Zip;
using Microsoft.Win32.SafeHandles;
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

        public enum eMCModels
        {
            Undefined = 0,
            Multicore1 = 1,
            Multicore2 = 2,
            Multicore2p= 3
        }

        private eMCModels _myModel = eMCModels.Undefined;
        private string
            _localPath = "",
            _currentHead = "",
            _modelFolder = ""
        ;
        private List<FileInfo> _sdCardFiles = new List<FileInfo>();
        private SDDriveInfo _sdDrive;

        private bool _waitingDowload = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void loadSDFiles()
        {
            this._sdCardFiles.Clear();

            DirectoryInfo dirInfo = new DirectoryInfo(this._sdDrive.DriveInfo.Name);
            this._sdCardFiles.AddRange(dirInfo.GetFiles());
            this.loadLocalPath();
        }

        private void loadConfig()
        {
            this._localPath = Properties.Settings.Default.LocalPath;
            this._currentHead = Properties.Settings.Default.CurrentHead;
            string[] models = Properties.Settings.Default.MCModels.Split(';');
            foreach (string model in models) cbMCModel.Items.Add(model);
            this._myModel = (eMCModels)Properties.Settings.Default.MyMCModel;
            cbMCModel.SelectedIndex = Properties.Settings.Default.MyMCModel;
        }

        private void saveConfig()
        {
            Properties.Settings.Default.LocalPath = this._localPath;
            Properties.Settings.Default.CurrentHead = this._currentHead;
            Properties.Settings.Default.MyMCModel = (int)this._myModel;
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
                    }
                } //hardwareDir
                rootNode.Nodes.Add(typeNode);
            } // typeDir
            treeView.Nodes.Add(rootNode);
        }

        private void loadLocalPath()
        {            
            Cursor.Current = Cursors.WaitCursor;
            tvLocalPath.Nodes.Clear();
            if (this._myModel != eMCModels.Undefined)
            {
                string mPath = this._localPath + Path.DirectorySeparatorChar + this._modelFolder;
                if(Directory.Exists(mPath)) this.loadDirectory(tvLocalPath, mPath);
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
            this.loadRemovableDrives();
            this.loadLocalPath();
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

        private void button1_Click(object sender, EventArgs e)
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

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            this.saveConfig();
        }

        private void tvLocalPath_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 2) // nodes dos itens
            {
                FileInfo fi = (FileInfo)e.Node.Tag;
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
            txtFileDetails.Text = "";
            if(e.Node != null)
            {
                if(e.Node.Tag != null)
                {
                    if (e.Node.Tag.GetType().Equals(typeof(string)))
                    {
                        txtFileDetails.Text = e.Node.Tag.ToString();
                    }
                }
            }
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
            return string.Format("{0} [{1}Gb] ({2}) - {3} Mb livres", this._info.VolumeLabel, this._info.TotalFreeSpace / 1024 / 1024 / 1024, this._info.Name.Replace("\\", ""), this._info.TotalFreeSpace / 1024 / 1024);
        }
    }
}

using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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


        private GitLab _git = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void loadSDFiles()
        {
            this._sdCardFiles.Clear();

            DirectoryInfo dirInfo = new DirectoryInfo(this._sdDrive.DriveInfo.Name);
            this._sdCardFiles.AddRange(dirInfo.GetFiles());
            /*
            foreach (FileInfo file in dirInfo.GetFiles())
            {

            }
            */
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
            Cursor.Current = Cursors.Default;
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                TreeNode tn = new TreeNode(file.Name);
                if (file.Extension.ToUpper().Equals(".ZIP"))
                {
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
                        tn.Tag = zipContents;
                        tn.Checked = haveAll;
                    }
                }
                if (file.Name.ToUpper().Equals("README.MD"))
                {
                    tn.Tag = File.ReadAllText(file.FullName);
                }
                directoryNode.Nodes.Add(tn);
            }

            return directoryNode;
        }

        private void loadLocalPath()
        {            
            Cursor.Current = Cursors.WaitCursor;
            tvLocalPath.Nodes.Clear();
            if (this._myModel != eMCModels.Undefined)
            {
                string mPath = this._localPath + Path.DirectorySeparatorChar + this._modelFolder;
                if(Directory.Exists(mPath)) this.ListDirectory(tvLocalPath, mPath);
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
            this.loadLocalPath();
            this.loadRemovableDrives();
            //GitLab();
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

        private async void GitLab()
        {
            this._git = new GitLab("", "", _localPath);
            await _git.Login();
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

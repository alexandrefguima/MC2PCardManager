using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC2PCardManager
{
    public partial class FormRoms : Form
    {
        private Dictionary<string, string> _romPaths;
        public Dictionary<string, string> RomPaths { get { return _romPaths; } }

        private Multicore2Repo _repository = null;
        public FormRoms(Dictionary<string, string> romPaths, Multicore2Repo repository)
        {
            this._romPaths = romPaths;
            this._repository = repository;
            InitializeComponent();
        }

        private void FormRoms_Load(object sender, EventArgs e)
        {
            foreach (MulticoreCoreZipFile core in _repository.CoresWithRoms)
            {
                ListViewItem lvi = new ListViewItem(
                    new string[] {
                        core.HardDir.TypeDir.Name,
                        core.Name,
                        _romPaths.ContainsKey(core.Name)?_romPaths[core.Name]: core.RomsFolder,
                        "..."
                    }
                )
                {
                    Tag = core
                };
                //lvi.SubItems[2].BackColor = Color.Gray;
                lvRoms.Items.Add(lvi);
            }
        }

        private void lvRoms_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            e.DrawText();
        }

        private void lvRoms_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvRoms_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = lvRoms.PointToClient(Control.MousePosition);
                ListViewHitTestInfo hitTest = lvRoms.HitTest(mousePos);
                if (hitTest.Item != null)
                {
                    int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
                    if (columnIndex == 3) //directory navigator
                    {
                        MulticoreCoreZipFile core = ((MulticoreCoreZipFile)hitTest.Item.Tag);
                        FolderBrowserDialog fbd = new FolderBrowserDialog()
                        {
                            ShowNewFolderButton = true,
                            Description = "Selecione o diretorio com as ROMS de " + core.HardDir.DirInfo.Name, 
                            SelectedPath = core.RomsFolder
                        };
                        if (fbd.ShowDialog() == DialogResult.OK)
                        {
                            if (fbd.SelectedPath != core.RomsFolder)
                            {
                                //core.RomsFolder = fbd.SelectedPath;
                                if (_romPaths.ContainsKey(core.HardDir.DirInfo.Name.ToUpper()))
                                    _romPaths[core.HardDir.DirInfo.Name.ToUpper()] = fbd.SelectedPath;
                                else
                                    _romPaths.Add(core.HardDir.DirInfo.Name.ToUpper(), fbd.SelectedPath);
                                hitTest.Item.SubItems[2].Text = fbd.SelectedPath;
                                lvRoms.Refresh();
                            }
                        }
                    }
                }
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

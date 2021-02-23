
namespace MC2PCardManager
{
    partial class FormMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnTop = new System.Windows.Forms.Panel();
            this.btGitLab = new System.Windows.Forms.Button();
            this.btRomPaths = new System.Windows.Forms.Button();
            this.lbProgressMsg = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.btSaveConfig = new System.Windows.Forms.Button();
            this.cbMCModel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.btChooseLocalPath = new System.Windows.Forms.Button();
            this.btAtualizaDrives = new System.Windows.Forms.Button();
            this.cbDrives = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbCores = new System.Windows.Forms.GroupBox();
            this.tvLocalPath = new System.Windows.Forms.TreeView();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.gbReadme = new System.Windows.Forms.GroupBox();
            this.txtReadme = new System.Windows.Forms.TextBox();
            this.gbZipContents = new System.Windows.Forms.GroupBox();
            this.txtZipContents = new System.Windows.Forms.TextBox();
            this.gbRomsDir = new System.Windows.Forms.GroupBox();
            this.btBrowseRomDir = new System.Windows.Forms.Button();
            this.txtRomsDir = new System.Windows.Forms.TextBox();
            this.gbRoms = new System.Windows.Forms.GroupBox();
            this.tvRoms = new System.Windows.Forms.TreeView();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbCores.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbReadme.SuspendLayout();
            this.gbZipContents.SuspendLayout();
            this.gbRomsDir.SuspendLayout();
            this.gbRoms.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.btGitLab);
            this.pnTop.Controls.Add(this.btRomPaths);
            this.pnTop.Controls.Add(this.lbProgressMsg);
            this.pnTop.Controls.Add(this.pBar);
            this.pnTop.Controls.Add(this.btSaveConfig);
            this.pnTop.Controls.Add(this.cbMCModel);
            this.pnTop.Controls.Add(this.label3);
            this.pnTop.Controls.Add(this.txtLocalPath);
            this.pnTop.Controls.Add(this.btChooseLocalPath);
            this.pnTop.Controls.Add(this.btAtualizaDrives);
            this.pnTop.Controls.Add(this.cbDrives);
            this.pnTop.Controls.Add(this.label2);
            this.pnTop.Controls.Add(this.label1);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(953, 107);
            this.pnTop.TabIndex = 0;
            // 
            // btGitLab
            // 
            this.btGitLab.Location = new System.Drawing.Point(402, 80);
            this.btGitLab.Name = "btGitLab";
            this.btGitLab.Size = new System.Drawing.Size(200, 23);
            this.btGitLab.TabIndex = 9;
            this.btGitLab.Text = "Verificar atualização no GitLab";
            this.btGitLab.UseVisualStyleBackColor = true;
            this.btGitLab.Click += new System.EventHandler(this.btGitLab_Click);
            // 
            // btRomPaths
            // 
            this.btRomPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRomPaths.Location = new System.Drawing.Point(835, 38);
            this.btRomPaths.Name = "btRomPaths";
            this.btRomPaths.Size = new System.Drawing.Size(106, 23);
            this.btRomPaths.TabIndex = 2;
            this.btRomPaths.Text = "Diretórios de Roms";
            this.btRomPaths.UseVisualStyleBackColor = true;
            this.btRomPaths.Click += new System.EventHandler(this.btRomPaths_Click);
            // 
            // lbProgressMsg
            // 
            this.lbProgressMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProgressMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbProgressMsg.Location = new System.Drawing.Point(228, 80);
            this.lbProgressMsg.Name = "lbProgressMsg";
            this.lbProgressMsg.Size = new System.Drawing.Size(504, 17);
            this.lbProgressMsg.TabIndex = 11;
            this.lbProgressMsg.Text = "lbProgressMsg";
            this.lbProgressMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbProgressMsg.Visible = false;
            // 
            // pBar
            // 
            this.pBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBar.Location = new System.Drawing.Point(0, 93);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(953, 14);
            this.pBar.TabIndex = 10;
            this.pBar.Visible = false;
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveConfig.Location = new System.Drawing.Point(848, 6);
            this.btSaveConfig.Name = "btSaveConfig";
            this.btSaveConfig.Size = new System.Drawing.Size(93, 23);
            this.btSaveConfig.TabIndex = 8;
            this.btSaveConfig.Text = "Salvar config.";
            this.btSaveConfig.UseVisualStyleBackColor = true;
            this.btSaveConfig.Click += new System.EventHandler(this.btSaveConfig_Click);
            // 
            // cbMCModel
            // 
            this.cbMCModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMCModel.FormattingEnabled = true;
            this.cbMCModel.Location = new System.Drawing.Point(688, 6);
            this.cbMCModel.Name = "cbMCModel";
            this.cbMCModel.Size = new System.Drawing.Size(121, 21);
            this.cbMCModel.TabIndex = 7;
            this.cbMCModel.SelectedIndexChanged += new System.EventHandler(this.cbMCModel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Modelo multicore:";
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalPath.Location = new System.Drawing.Point(114, 6);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(407, 20);
            this.txtLocalPath.TabIndex = 2;
            // 
            // btChooseLocalPath
            // 
            this.btChooseLocalPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btChooseLocalPath.Location = new System.Drawing.Point(519, 5);
            this.btChooseLocalPath.Name = "btChooseLocalPath";
            this.btChooseLocalPath.Size = new System.Drawing.Size(25, 22);
            this.btChooseLocalPath.TabIndex = 5;
            this.btChooseLocalPath.Text = "...";
            this.btChooseLocalPath.UseVisualStyleBackColor = true;
            // 
            // btAtualizaDrives
            // 
            this.btAtualizaDrives.Location = new System.Drawing.Point(402, 35);
            this.btAtualizaDrives.Name = "btAtualizaDrives";
            this.btAtualizaDrives.Size = new System.Drawing.Size(56, 21);
            this.btAtualizaDrives.TabIndex = 4;
            this.btAtualizaDrives.Text = "Atualizar";
            this.btAtualizaDrives.UseVisualStyleBackColor = true;
            this.btAtualizaDrives.Click += new System.EventHandler(this.btAtualizaDrives_Click);
            // 
            // cbDrives
            // 
            this.cbDrives.FormattingEnabled = true;
            this.cbDrives.Location = new System.Drawing.Point(114, 35);
            this.cbDrives.Name = "cbDrives";
            this.cbDrives.Size = new System.Drawing.Size(282, 21);
            this.cbDrives.TabIndex = 3;
            this.cbDrives.SelectedIndexChanged += new System.EventHandler(this.cbDrives_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Drive do cartão SD:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caminho repositório:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 107);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbCores);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbInfo);
            this.splitContainer1.Panel2.Controls.Add(this.gbRoms);
            this.splitContainer1.Size = new System.Drawing.Size(953, 343);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbCores
            // 
            this.gbCores.Controls.Add(this.tvLocalPath);
            this.gbCores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCores.Location = new System.Drawing.Point(0, 0);
            this.gbCores.Name = "gbCores";
            this.gbCores.Size = new System.Drawing.Size(316, 343);
            this.gbCores.TabIndex = 1;
            this.gbCores.TabStop = false;
            this.gbCores.Text = "Cores (marque para copiar pro cartão)";
            // 
            // tvLocalPath
            // 
            this.tvLocalPath.CheckBoxes = true;
            this.tvLocalPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLocalPath.Location = new System.Drawing.Point(3, 16);
            this.tvLocalPath.Name = "tvLocalPath";
            this.tvLocalPath.Size = new System.Drawing.Size(310, 324);
            this.tvLocalPath.TabIndex = 0;
            this.tvLocalPath.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvLocalPath_AfterCheck);
            this.tvLocalPath.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tvLocalPath_DrawNode);
            this.tvLocalPath.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLocalPath_AfterSelect);
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.gbReadme);
            this.gbInfo.Controls.Add(this.gbZipContents);
            this.gbInfo.Controls.Add(this.gbRomsDir);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInfo.Location = new System.Drawing.Point(0, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(374, 343);
            this.gbInfo.TabIndex = 1;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Informações do core selecionado";
            // 
            // gbReadme
            // 
            this.gbReadme.Controls.Add(this.txtReadme);
            this.gbReadme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbReadme.Location = new System.Drawing.Point(3, 16);
            this.gbReadme.Name = "gbReadme";
            this.gbReadme.Size = new System.Drawing.Size(368, 164);
            this.gbReadme.TabIndex = 0;
            this.gbReadme.TabStop = false;
            this.gbReadme.Text = "README";
            // 
            // txtReadme
            // 
            this.txtReadme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReadme.Location = new System.Drawing.Point(3, 16);
            this.txtReadme.Multiline = true;
            this.txtReadme.Name = "txtReadme";
            this.txtReadme.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReadme.Size = new System.Drawing.Size(362, 145);
            this.txtReadme.TabIndex = 0;
            // 
            // gbZipContents
            // 
            this.gbZipContents.Controls.Add(this.txtZipContents);
            this.gbZipContents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbZipContents.Location = new System.Drawing.Point(3, 180);
            this.gbZipContents.Name = "gbZipContents";
            this.gbZipContents.Size = new System.Drawing.Size(368, 119);
            this.gbZipContents.TabIndex = 1;
            this.gbZipContents.TabStop = false;
            this.gbZipContents.Text = "Conteúdo do zip";
            // 
            // txtZipContents
            // 
            this.txtZipContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtZipContents.Location = new System.Drawing.Point(3, 16);
            this.txtZipContents.Multiline = true;
            this.txtZipContents.Name = "txtZipContents";
            this.txtZipContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtZipContents.Size = new System.Drawing.Size(362, 100);
            this.txtZipContents.TabIndex = 0;
            // 
            // gbRomsDir
            // 
            this.gbRomsDir.Controls.Add(this.btBrowseRomDir);
            this.gbRomsDir.Controls.Add(this.txtRomsDir);
            this.gbRomsDir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbRomsDir.Location = new System.Drawing.Point(3, 299);
            this.gbRomsDir.Name = "gbRomsDir";
            this.gbRomsDir.Size = new System.Drawing.Size(368, 41);
            this.gbRomsDir.TabIndex = 2;
            this.gbRomsDir.TabStop = false;
            this.gbRomsDir.Text = "Diretório LOCAL de ROMs";
            // 
            // btBrowseRomDir
            // 
            this.btBrowseRomDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseRomDir.Location = new System.Drawing.Point(340, 14);
            this.btBrowseRomDir.Name = "btBrowseRomDir";
            this.btBrowseRomDir.Size = new System.Drawing.Size(25, 22);
            this.btBrowseRomDir.TabIndex = 1;
            this.btBrowseRomDir.Text = "...";
            this.btBrowseRomDir.UseVisualStyleBackColor = true;
            this.btBrowseRomDir.Click += new System.EventHandler(this.btBrowseRomDir_Click);
            // 
            // txtRomsDir
            // 
            this.txtRomsDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRomsDir.Location = new System.Drawing.Point(6, 15);
            this.txtRomsDir.Name = "txtRomsDir";
            this.txtRomsDir.Size = new System.Drawing.Size(334, 20);
            this.txtRomsDir.TabIndex = 0;
            // 
            // gbRoms
            // 
            this.gbRoms.Controls.Add(this.tvRoms);
            this.gbRoms.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbRoms.Location = new System.Drawing.Point(374, 0);
            this.gbRoms.Name = "gbRoms";
            this.gbRoms.Size = new System.Drawing.Size(259, 343);
            this.gbRoms.TabIndex = 12;
            this.gbRoms.TabStop = false;
            this.gbRoms.Text = "Roms para core selecionado";
            // 
            // tvRoms
            // 
            this.tvRoms.CheckBoxes = true;
            this.tvRoms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRoms.HideSelection = false;
            this.tvRoms.Location = new System.Drawing.Point(3, 16);
            this.tvRoms.Name = "tvRoms";
            this.tvRoms.Size = new System.Drawing.Size(253, 324);
            this.tvRoms.TabIndex = 0;
            this.tvRoms.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvRoms_AfterCheck);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnTop);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multicore 2+ Card Manager";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbCores.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbReadme.ResumeLayout(false);
            this.gbReadme.PerformLayout();
            this.gbZipContents.ResumeLayout(false);
            this.gbZipContents.PerformLayout();
            this.gbRomsDir.ResumeLayout(false);
            this.gbRomsDir.PerformLayout();
            this.gbRoms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvLocalPath;
        private System.Windows.Forms.TextBox txtLocalPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDrives;
        private System.Windows.Forms.Button btChooseLocalPath;
        private System.Windows.Forms.Button btAtualizaDrives;
        private System.Windows.Forms.ComboBox cbMCModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSaveConfig;
        private System.Windows.Forms.TextBox txtReadme;
        private System.Windows.Forms.Button btGitLab;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label lbProgressMsg;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.GroupBox gbReadme;
        private System.Windows.Forms.GroupBox gbZipContents;
        private System.Windows.Forms.GroupBox gbRomsDir;
        private System.Windows.Forms.TextBox txtZipContents;
        private System.Windows.Forms.TextBox txtRomsDir;
        private System.Windows.Forms.Button btBrowseRomDir;
        private System.Windows.Forms.Button btRomPaths;
        private System.Windows.Forms.GroupBox gbCores;
        private System.Windows.Forms.GroupBox gbRoms;
        private System.Windows.Forms.TreeView tvRoms;
    }
}


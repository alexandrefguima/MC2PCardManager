﻿
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
            this.lbProgressMsg = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
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
            this.tvLocalPath = new System.Windows.Forms.TreeView();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.gbReadme = new System.Windows.Forms.GroupBox();
            this.txtReadme = new System.Windows.Forms.TextBox();
            this.gbZipContents = new System.Windows.Forms.GroupBox();
            this.txtZipContents = new System.Windows.Forms.TextBox();
            this.gbRomsDir = new System.Windows.Forms.GroupBox();
            this.btBrowseRomDir = new System.Windows.Forms.Button();
            this.txtRomsDir = new System.Windows.Forms.TextBox();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbReadme.SuspendLayout();
            this.gbZipContents.SuspendLayout();
            this.gbRomsDir.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lbProgressMsg);
            this.pnTop.Controls.Add(this.pBar);
            this.pnTop.Controls.Add(this.button1);
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
            // lbProgressMsg
            // 
            this.lbProgressMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProgressMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbProgressMsg.Location = new System.Drawing.Point(228, 75);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(469, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Verif. atualiz.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.Location = new System.Drawing.Point(697, 35);
            this.btSaveConfig.Name = "btSaveConfig";
            this.btSaveConfig.Size = new System.Drawing.Size(93, 23);
            this.btSaveConfig.TabIndex = 8;
            this.btSaveConfig.Text = "Salvar config.";
            this.btSaveConfig.UseVisualStyleBackColor = true;
            this.btSaveConfig.Click += new System.EventHandler(this.btSaveConfig_Click);
            // 
            // cbMCModel
            // 
            this.cbMCModel.FormattingEnabled = true;
            this.cbMCModel.Location = new System.Drawing.Point(669, 6);
            this.cbMCModel.Name = "cbMCModel";
            this.cbMCModel.Size = new System.Drawing.Size(121, 21);
            this.cbMCModel.TabIndex = 7;
            this.cbMCModel.SelectedIndexChanged += new System.EventHandler(this.cbMCModel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Modelo multicore:";
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.Location = new System.Drawing.Point(114, 6);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(407, 20);
            this.txtLocalPath.TabIndex = 2;
            // 
            // btChooseLocalPath
            // 
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
            this.splitContainer1.Panel1.Controls.Add(this.tvLocalPath);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbInfo);
            this.splitContainer1.Size = new System.Drawing.Size(953, 343);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvLocalPath
            // 
            this.tvLocalPath.CheckBoxes = true;
            this.tvLocalPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLocalPath.Location = new System.Drawing.Point(0, 0);
            this.tvLocalPath.Name = "tvLocalPath";
            this.tvLocalPath.Size = new System.Drawing.Size(316, 343);
            this.tvLocalPath.TabIndex = 0;
            this.tvLocalPath.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvLocalPath_AfterCheck);
            this.tvLocalPath.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLocalPath_AfterSelect);
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.gbReadme);
            this.gbInfo.Controls.Add(this.gbZipContents);
            this.gbInfo.Controls.Add(this.gbRomsDir);
            this.gbInfo.Location = new System.Drawing.Point(3, 6);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(396, 325);
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
            this.gbReadme.Size = new System.Drawing.Size(390, 146);
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
            this.txtReadme.Size = new System.Drawing.Size(384, 127);
            this.txtReadme.TabIndex = 0;
            // 
            // gbZipContents
            // 
            this.gbZipContents.Controls.Add(this.txtZipContents);
            this.gbZipContents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbZipContents.Location = new System.Drawing.Point(3, 162);
            this.gbZipContents.Name = "gbZipContents";
            this.gbZipContents.Size = new System.Drawing.Size(390, 119);
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
            this.txtZipContents.Size = new System.Drawing.Size(384, 100);
            this.txtZipContents.TabIndex = 0;
            // 
            // gbRomsDir
            // 
            this.gbRomsDir.Controls.Add(this.btBrowseRomDir);
            this.gbRomsDir.Controls.Add(this.txtRomsDir);
            this.gbRomsDir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbRomsDir.Location = new System.Drawing.Point(3, 281);
            this.gbRomsDir.Name = "gbRomsDir";
            this.gbRomsDir.Size = new System.Drawing.Size(390, 41);
            this.gbRomsDir.TabIndex = 2;
            this.gbRomsDir.TabStop = false;
            this.gbRomsDir.Text = "Diretório de ROMs";
            // 
            // btBrowseRomDir
            // 
            this.btBrowseRomDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseRomDir.Location = new System.Drawing.Point(362, 14);
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
            this.txtRomsDir.Size = new System.Drawing.Size(356, 20);
            this.txtRomsDir.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnTop);
            this.Name = "FormMain";
            this.Text = "Multicore 2+ Card Manager";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbReadme.ResumeLayout(false);
            this.gbReadme.PerformLayout();
            this.gbZipContents.ResumeLayout(false);
            this.gbZipContents.PerformLayout();
            this.gbRomsDir.ResumeLayout(false);
            this.gbRomsDir.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label lbProgressMsg;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.GroupBox gbReadme;
        private System.Windows.Forms.GroupBox gbZipContents;
        private System.Windows.Forms.GroupBox gbRomsDir;
        private System.Windows.Forms.TextBox txtZipContents;
        private System.Windows.Forms.TextBox txtRomsDir;
        private System.Windows.Forms.Button btBrowseRomDir;
    }
}


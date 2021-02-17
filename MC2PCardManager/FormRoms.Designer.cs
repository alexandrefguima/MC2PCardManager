
namespace MC2PCardManager
{
    partial class FormRoms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnBottom = new System.Windows.Forms.Panel();
            this.lvRoms = new System.Windows.Forms.ListView();
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colClear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btCancelar = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.btOK);
            this.pnBottom.Controls.Add(this.btCancelar);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 392);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(800, 58);
            this.pnBottom.TabIndex = 0;
            // 
            // lvRoms
            // 
            this.lvRoms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colType,
            this.colCore,
            this.colPath,
            this.colClear});
            this.lvRoms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRoms.GridLines = true;
            this.lvRoms.HideSelection = false;
            this.lvRoms.Location = new System.Drawing.Point(0, 0);
            this.lvRoms.MultiSelect = false;
            this.lvRoms.Name = "lvRoms";
            this.lvRoms.OwnerDraw = true;
            this.lvRoms.ShowGroups = false;
            this.lvRoms.Size = new System.Drawing.Size(800, 392);
            this.lvRoms.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvRoms.TabIndex = 1;
            this.lvRoms.UseCompatibleStateImageBehavior = false;
            this.lvRoms.View = System.Windows.Forms.View.Details;
            this.lvRoms.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvRoms_DrawColumnHeader);
            this.lvRoms.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvRoms_DrawItem);
            this.lvRoms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvRoms_MouseUp);
            // 
            // colType
            // 
            this.colType.Text = "Tipo";
            this.colType.Width = 70;
            // 
            // colCore
            // 
            this.colCore.Text = "Core";
            this.colCore.Width = 120;
            // 
            // colPath
            // 
            this.colPath.Text = "Diretório de ROMs";
            this.colPath.Width = 500;
            // 
            // colClear
            // 
            this.colClear.Text = "";
            this.colClear.Width = 20;
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(491, 6);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(122, 40);
            this.btCancelar.TabIndex = 0;
            this.btCancelar.Text = "CANCELAR";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(193, 6);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(122, 40);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // FormRoms
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvRoms);
            this.Controls.Add(this.pnBottom);
            this.DoubleBuffered = true;
            this.Name = "FormRoms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Diretorios de ROMs";
            this.Load += new System.EventHandler(this.FormRoms_Load);
            this.pnBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.ListView lvRoms;
        private System.Windows.Forms.ColumnHeader colCore;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colClear;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btOK;
    }
}
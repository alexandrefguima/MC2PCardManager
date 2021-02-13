
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
            this.SuspendLayout();
            // 
            // pnBottom
            // 
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 287);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(800, 163);
            this.pnBottom.TabIndex = 0;
            // 
            // lvRoms
            // 
            this.lvRoms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRoms.FullRowSelect = true;
            this.lvRoms.HideSelection = false;
            this.lvRoms.Location = new System.Drawing.Point(0, 0);
            this.lvRoms.MultiSelect = false;
            this.lvRoms.Name = "lvRoms";
            this.lvRoms.Size = new System.Drawing.Size(800, 287);
            this.lvRoms.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvRoms.TabIndex = 1;
            this.lvRoms.UseCompatibleStateImageBehavior = false;
            this.lvRoms.View = System.Windows.Forms.View.List;
            // 
            // FormRoms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvRoms);
            this.Controls.Add(this.pnBottom);
            this.Name = "FormRoms";
            this.Text = "Diretorios de ROMs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.ListView lvRoms;
    }
}
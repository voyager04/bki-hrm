namespace BKI_HRM
{
    partial class f400_Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quáTrìnhLàmViệcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trạngTháiLaoĐộngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quáTrìnhLàmViệcToolStripMenuItem,
            this.trạngTháiLaoĐộngToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // quáTrìnhLàmViệcToolStripMenuItem
            // 
            this.quáTrìnhLàmViệcToolStripMenuItem.Name = "quáTrìnhLàmViệcToolStripMenuItem";
            this.quáTrìnhLàmViệcToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.quáTrìnhLàmViệcToolStripMenuItem.Text = "Quá trình làm việc";
            this.quáTrìnhLàmViệcToolStripMenuItem.Click += new System.EventHandler(this.quáTrìnhLàmViệcToolStripMenuItem_Click);
            // 
            // trạngTháiLaoĐộngToolStripMenuItem
            // 
            this.trạngTháiLaoĐộngToolStripMenuItem.Name = "trạngTháiLaoĐộngToolStripMenuItem";
            this.trạngTháiLaoĐộngToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.trạngTháiLaoĐộngToolStripMenuItem.Text = "Trạng thái lao động";
            // 
            // f400_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "f400_Main";
            this.Text = "f400_Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quáTrìnhLàmViệcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trạngTháiLaoĐộngToolStripMenuItem;
    }
}
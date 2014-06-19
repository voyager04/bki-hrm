namespace BKI_HRM
{
    partial class f400_dialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f400_dialog));
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_cmd_restore = new SIS.Controls.Button.SiSButton();
            this.m_cmd_backup = new SIS.Controls.Button.SiSButton();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // m_cmd_exit
            // 
            this.m_cmd_exit.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_exit.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_exit.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_exit.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cmd_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.m_cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_exit.ImageIndex = 12;
            this.m_cmd_exit.Location = new System.Drawing.Point(0, 102);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(437, 51);
            this.m_cmd_exit.TabIndex = 45;
            this.m_cmd_exit.Text = "Thoát";
            this.m_cmd_exit.Click += new System.EventHandler(this.m_cmd_exit_Click);
            // 
            // m_cmd_restore
            // 
            this.m_cmd_restore.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_restore.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_restore.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_restore.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cmd_restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.m_cmd_restore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_restore.ImageIndex = 13;
            this.m_cmd_restore.ImageList = this.ImageList;
            this.m_cmd_restore.Location = new System.Drawing.Point(0, 51);
            this.m_cmd_restore.Name = "m_cmd_restore";
            this.m_cmd_restore.Size = new System.Drawing.Size(437, 51);
            this.m_cmd_restore.TabIndex = 41;
            this.m_cmd_restore.Text = "Phục hồi dữ liệu";
            this.m_cmd_restore.Click += new System.EventHandler(this.m_cmd_restore_Click);
            // 
            // m_cmd_backup
            // 
            this.m_cmd_backup.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_backup.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_backup.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_backup.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cmd_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.m_cmd_backup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_backup.ImageIndex = 13;
            this.m_cmd_backup.ImageList = this.ImageList;
            this.m_cmd_backup.Location = new System.Drawing.Point(0, 0);
            this.m_cmd_backup.Name = "m_cmd_backup";
            this.m_cmd_backup.Size = new System.Drawing.Size(437, 51);
            this.m_cmd_backup.TabIndex = 40;
            this.m_cmd_backup.Text = "Sao lưu dữ liệu";
            this.m_cmd_backup.Click += new System.EventHandler(this.m_cmd_back_up_Click);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            this.ImageList.Images.SetKeyName(8, "");
            this.ImageList.Images.SetKeyName(9, "");
            this.ImageList.Images.SetKeyName(10, "");
            this.ImageList.Images.SetKeyName(11, "");
            this.ImageList.Images.SetKeyName(12, "");
            this.ImageList.Images.SetKeyName(13, "");
            this.ImageList.Images.SetKeyName(14, "");
            this.ImageList.Images.SetKeyName(15, "");
            this.ImageList.Images.SetKeyName(16, "");
            this.ImageList.Images.SetKeyName(17, "");
            this.ImageList.Images.SetKeyName(18, "");
            this.ImageList.Images.SetKeyName(19, "");
            this.ImageList.Images.SetKeyName(20, "");
            this.ImageList.Images.SetKeyName(21, "");
            // 
            // f400_dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 152);
            this.Controls.Add(this.m_cmd_exit);
            this.Controls.Add(this.m_cmd_restore);
            this.Controls.Add(this.m_cmd_backup);
            this.Name = "f400_dialog";
            this.Text = "f400_dialog";
            this.ResumeLayout(false);

        }

        #endregion

        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        internal SIS.Controls.Button.SiSButton m_cmd_restore;
        internal SIS.Controls.Button.SiSButton m_cmd_backup;
        internal System.Windows.Forms.ImageList ImageList;
    }
}
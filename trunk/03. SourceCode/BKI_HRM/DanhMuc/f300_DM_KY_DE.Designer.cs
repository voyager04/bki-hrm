namespace BKI_HRM.DanhMuc
{
    partial class f300_DM_KY_DE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f300_DM_KY_DE));
            this.m_txt_ma_ky = new System.Windows.Forms.TextBox();
            this.m_dat_ngay_bat_dau = new System.Windows.Forms.DateTimePicker();
            this.m_dat_ngay_ket_thuc = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_save = new SIS.Controls.Button.SiSButton();
            this.m_cmd_reset = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_pnl_out_place_dm.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txt_ma_ky
            // 
            this.m_txt_ma_ky.Location = new System.Drawing.Point(65, 27);
            this.m_txt_ma_ky.Name = "m_txt_ma_ky";
            this.m_txt_ma_ky.Size = new System.Drawing.Size(275, 20);
            this.m_txt_ma_ky.TabIndex = 0;
            // 
            // m_dat_ngay_bat_dau
            // 
            this.m_dat_ngay_bat_dau.CustomFormat = "dd/MM/yyyy";
            this.m_dat_ngay_bat_dau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dat_ngay_bat_dau.Location = new System.Drawing.Point(65, 91);
            this.m_dat_ngay_bat_dau.Name = "m_dat_ngay_bat_dau";
            this.m_dat_ngay_bat_dau.Size = new System.Drawing.Size(113, 20);
            this.m_dat_ngay_bat_dau.TabIndex = 1;
            // 
            // m_dat_ngay_ket_thuc
            // 
            this.m_dat_ngay_ket_thuc.CustomFormat = "dd/MM/yyyy";
            this.m_dat_ngay_ket_thuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dat_ngay_ket_thuc.Location = new System.Drawing.Point(227, 91);
            this.m_dat_ngay_ket_thuc.Name = "m_dat_ngay_ket_thuc";
            this.m_dat_ngay_ket_thuc.Size = new System.Drawing.Size(113, 20);
            this.m_dat_ngay_ket_thuc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã kỳ (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngày bắt đầu kỳ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày kết thúc kỳ";
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
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_save);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_reset);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 169);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(407, 36);
            this.m_pnl_out_place_dm.TabIndex = 3;
            // 
            // m_cmd_save
            // 
            this.m_cmd_save.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_save.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_save.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_save.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_save.ImageIndex = 10;
            this.m_cmd_save.ImageList = this.ImageList;
            this.m_cmd_save.Location = new System.Drawing.Point(139, 4);
            this.m_cmd_save.Name = "m_cmd_save";
            this.m_cmd_save.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_save.TabIndex = 0;
            this.m_cmd_save.Text = "&Lưu";
            // 
            // m_cmd_reset
            // 
            this.m_cmd_reset.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_reset.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_reset.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_reset.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_reset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_reset.ImageIndex = 9;
            this.m_cmd_reset.ImageList = this.ImageList;
            this.m_cmd_reset.Location = new System.Drawing.Point(227, 4);
            this.m_cmd_reset.Name = "m_cmd_reset";
            this.m_cmd_reset.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_reset.TabIndex = 1;
            this.m_cmd_reset.Text = "L&àm lại";
            // 
            // m_cmd_exit
            // 
            this.m_cmd_exit.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_exit.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_exit.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmd_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_exit.ImageIndex = 12;
            this.m_cmd_exit.ImageList = this.ImageList;
            this.m_cmd_exit.Location = new System.Drawing.Point(315, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 2;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // f300_DM_KY_DE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 205);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_dat_ngay_ket_thuc);
            this.Controls.Add(this.m_dat_ngay_bat_dau);
            this.Controls.Add(this.m_txt_ma_ky);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "f300_DM_KY_DE";
            this.Text = "F300 - Chi tiết kỳ";
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_txt_ma_ky;
        private System.Windows.Forms.DateTimePicker m_dat_ngay_bat_dau;
        private System.Windows.Forms.DateTimePicker m_dat_ngay_ket_thuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ImageList ImageList;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        internal SIS.Controls.Button.SiSButton m_cmd_save;
        internal SIS.Controls.Button.SiSButton m_cmd_reset;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
    }
}
namespace BKI_HRM
{
    partial class F206_chi_tiet_cong_tac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F206_chi_tiet_cong_tac));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_save = new SIS.Controls.Button.SiSButton();
            this.m_cmd_refresh = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_lbl_ma_nhan_vien = new System.Windows.Forms.Label();
            this.m_txt_ma_nhan_vien = new System.Windows.Forms.TextBox();
            this.m_txt_ho_dem = new System.Windows.Forms.TextBox();
            this.m_lbl_ho_dem = new System.Windows.Forms.Label();
            this.m_lbl_ngay_di = new System.Windows.Forms.Label();
            this.m_dat_ngay_di = new System.Windows.Forms.DateTimePicker();
            this.m_dat_ngay_ve = new System.Windows.Forms.DateTimePicker();
            this.m_lbl_ngay_ve = new System.Windows.Forms.Label();
            this.m_txt_dia_diem = new System.Windows.Forms.TextBox();
            this.m_lbl_dia_diem = new System.Windows.Forms.Label();
            this.m_txt_mo_ta_cong_viec = new System.Windows.Forms.TextBox();
            this.m_lbl_mo_ta = new System.Windows.Forms.Label();
            this.m_txt_ten = new System.Windows.Forms.TextBox();
            this.m_lbl_ten = new System.Windows.Forms.Label();
            this.m_pnl_out_place_dm.SuspendLayout();
            this.SuspendLayout();
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
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_refresh);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 231);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(590, 36);
            this.m_pnl_out_place_dm.TabIndex = 109;
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
            this.m_cmd_save.Location = new System.Drawing.Point(322, 4);
            this.m_cmd_save.Name = "m_cmd_save";
            this.m_cmd_save.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_save.TabIndex = 13;
            this.m_cmd_save.Text = "&Lưu";
            // 
            // m_cmd_refresh
            // 
            this.m_cmd_refresh.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_refresh.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_refresh.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_refresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_refresh.ImageIndex = 9;
            this.m_cmd_refresh.ImageList = this.ImageList;
            this.m_cmd_refresh.Location = new System.Drawing.Point(410, 4);
            this.m_cmd_refresh.Name = "m_cmd_refresh";
            this.m_cmd_refresh.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_refresh.TabIndex = 14;
            this.m_cmd_refresh.Text = "L&àm lại";
            // 
            // m_cmd_exit
            // 
            this.m_cmd_exit.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_exit.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_exit.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_exit.ImageIndex = 12;
            this.m_cmd_exit.ImageList = this.ImageList;
            this.m_cmd_exit.Location = new System.Drawing.Point(498, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // m_lbl_ma_nhan_vien
            // 
            this.m_lbl_ma_nhan_vien.AutoSize = true;
            this.m_lbl_ma_nhan_vien.Location = new System.Drawing.Point(25, 37);
            this.m_lbl_ma_nhan_vien.Name = "m_lbl_ma_nhan_vien";
            this.m_lbl_ma_nhan_vien.Size = new System.Drawing.Size(72, 13);
            this.m_lbl_ma_nhan_vien.TabIndex = 110;
            this.m_lbl_ma_nhan_vien.Text = "Mã nhân viên";
            // 
            // m_txt_ma_nhan_vien
            // 
            this.m_txt_ma_nhan_vien.Location = new System.Drawing.Point(117, 33);
            this.m_txt_ma_nhan_vien.Name = "m_txt_ma_nhan_vien";
            this.m_txt_ma_nhan_vien.Size = new System.Drawing.Size(100, 20);
            this.m_txt_ma_nhan_vien.TabIndex = 111;
            // 
            // m_txt_ho_dem
            // 
            this.m_txt_ho_dem.Location = new System.Drawing.Point(299, 33);
            this.m_txt_ho_dem.Name = "m_txt_ho_dem";
            this.m_txt_ho_dem.Size = new System.Drawing.Size(134, 20);
            this.m_txt_ho_dem.TabIndex = 113;
            // 
            // m_lbl_ho_dem
            // 
            this.m_lbl_ho_dem.AutoSize = true;
            this.m_lbl_ho_dem.Location = new System.Drawing.Point(241, 37);
            this.m_lbl_ho_dem.Name = "m_lbl_ho_dem";
            this.m_lbl_ho_dem.Size = new System.Drawing.Size(45, 13);
            this.m_lbl_ho_dem.TabIndex = 112;
            this.m_lbl_ho_dem.Text = "Họ đệm";
            // 
            // m_lbl_ngay_di
            // 
            this.m_lbl_ngay_di.AutoSize = true;
            this.m_lbl_ngay_di.Location = new System.Drawing.Point(25, 82);
            this.m_lbl_ngay_di.Name = "m_lbl_ngay_di";
            this.m_lbl_ngay_di.Size = new System.Drawing.Size(44, 13);
            this.m_lbl_ngay_di.TabIndex = 114;
            this.m_lbl_ngay_di.Text = "Ngày đi";
            // 
            // m_dat_ngay_di
            // 
            this.m_dat_ngay_di.CustomFormat = "dd/MM/yyyy";
            this.m_dat_ngay_di.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dat_ngay_di.Location = new System.Drawing.Point(117, 78);
            this.m_dat_ngay_di.Name = "m_dat_ngay_di";
            this.m_dat_ngay_di.Size = new System.Drawing.Size(100, 20);
            this.m_dat_ngay_di.TabIndex = 115;
            // 
            // m_dat_ngay_ve
            // 
            this.m_dat_ngay_ve.CustomFormat = "dd/MM/yyyy";
            this.m_dat_ngay_ve.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dat_ngay_ve.Location = new System.Drawing.Point(299, 78);
            this.m_dat_ngay_ve.Name = "m_dat_ngay_ve";
            this.m_dat_ngay_ve.Size = new System.Drawing.Size(100, 20);
            this.m_dat_ngay_ve.TabIndex = 117;
            // 
            // m_lbl_ngay_ve
            // 
            this.m_lbl_ngay_ve.AutoSize = true;
            this.m_lbl_ngay_ve.Location = new System.Drawing.Point(241, 82);
            this.m_lbl_ngay_ve.Name = "m_lbl_ngay_ve";
            this.m_lbl_ngay_ve.Size = new System.Drawing.Size(47, 13);
            this.m_lbl_ngay_ve.TabIndex = 116;
            this.m_lbl_ngay_ve.Text = "Ngày về";
            // 
            // m_txt_dia_diem
            // 
            this.m_txt_dia_diem.Location = new System.Drawing.Point(117, 120);
            this.m_txt_dia_diem.Name = "m_txt_dia_diem";
            this.m_txt_dia_diem.Size = new System.Drawing.Size(100, 20);
            this.m_txt_dia_diem.TabIndex = 119;
            // 
            // m_lbl_dia_diem
            // 
            this.m_lbl_dia_diem.AutoSize = true;
            this.m_lbl_dia_diem.Location = new System.Drawing.Point(25, 124);
            this.m_lbl_dia_diem.Name = "m_lbl_dia_diem";
            this.m_lbl_dia_diem.Size = new System.Drawing.Size(49, 13);
            this.m_lbl_dia_diem.TabIndex = 118;
            this.m_lbl_dia_diem.Text = "Địa điểm";
            // 
            // m_txt_mo_ta_cong_viec
            // 
            this.m_txt_mo_ta_cong_viec.Location = new System.Drawing.Point(117, 155);
            this.m_txt_mo_ta_cong_viec.Multiline = true;
            this.m_txt_mo_ta_cong_viec.Name = "m_txt_mo_ta_cong_viec";
            this.m_txt_mo_ta_cong_viec.Size = new System.Drawing.Size(449, 58);
            this.m_txt_mo_ta_cong_viec.TabIndex = 121;
            // 
            // m_lbl_mo_ta
            // 
            this.m_lbl_mo_ta.AutoSize = true;
            this.m_lbl_mo_ta.Location = new System.Drawing.Point(25, 159);
            this.m_lbl_mo_ta.Name = "m_lbl_mo_ta";
            this.m_lbl_mo_ta.Size = new System.Drawing.Size(84, 13);
            this.m_lbl_mo_ta.TabIndex = 120;
            this.m_lbl_mo_ta.Text = "Mô tả công việc";
            // 
            // m_txt_ten
            // 
            this.m_txt_ten.Location = new System.Drawing.Point(478, 34);
            this.m_txt_ten.Name = "m_txt_ten";
            this.m_txt_ten.Size = new System.Drawing.Size(80, 20);
            this.m_txt_ten.TabIndex = 123;
            // 
            // m_lbl_ten
            // 
            this.m_lbl_ten.AutoSize = true;
            this.m_lbl_ten.Location = new System.Drawing.Point(440, 38);
            this.m_lbl_ten.Name = "m_lbl_ten";
            this.m_lbl_ten.Size = new System.Drawing.Size(26, 13);
            this.m_lbl_ten.TabIndex = 122;
            this.m_lbl_ten.Text = "Tên";
            // 
            // F206_chi_tiet_cong_tac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 267);
            this.Controls.Add(this.m_txt_ten);
            this.Controls.Add(this.m_lbl_ten);
            this.Controls.Add(this.m_txt_mo_ta_cong_viec);
            this.Controls.Add(this.m_lbl_mo_ta);
            this.Controls.Add(this.m_txt_dia_diem);
            this.Controls.Add(this.m_lbl_dia_diem);
            this.Controls.Add(this.m_dat_ngay_ve);
            this.Controls.Add(this.m_lbl_ngay_ve);
            this.Controls.Add(this.m_dat_ngay_di);
            this.Controls.Add(this.m_lbl_ngay_di);
            this.Controls.Add(this.m_txt_ho_dem);
            this.Controls.Add(this.m_lbl_ho_dem);
            this.Controls.Add(this.m_txt_ma_nhan_vien);
            this.Controls.Add(this.m_lbl_ma_nhan_vien);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Name = "F206_chi_tiet_cong_tac";
            this.Text = "F206 - Chi tiết công tác";
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ImageList ImageList;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        internal SIS.Controls.Button.SiSButton m_cmd_save;
        internal SIS.Controls.Button.SiSButton m_cmd_refresh;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        private System.Windows.Forms.Label m_lbl_ma_nhan_vien;
        private System.Windows.Forms.TextBox m_txt_ma_nhan_vien;
        private System.Windows.Forms.TextBox m_txt_ho_dem;
        private System.Windows.Forms.Label m_lbl_ho_dem;
        private System.Windows.Forms.Label m_lbl_ngay_di;
        private System.Windows.Forms.DateTimePicker m_dat_ngay_di;
        private System.Windows.Forms.DateTimePicker m_dat_ngay_ve;
        private System.Windows.Forms.Label m_lbl_ngay_ve;
        private System.Windows.Forms.TextBox m_txt_dia_diem;
        private System.Windows.Forms.Label m_lbl_dia_diem;
        private System.Windows.Forms.TextBox m_txt_mo_ta_cong_viec;
        private System.Windows.Forms.Label m_lbl_mo_ta;
        private System.Windows.Forms.TextBox m_txt_ten;
        private System.Windows.Forms.Label m_lbl_ten;
    }
}
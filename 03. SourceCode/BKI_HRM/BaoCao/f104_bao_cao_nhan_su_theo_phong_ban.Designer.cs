namespace BKI_HRM {
    partial class f104_bao_cao_nhan_su_theo_phong_ban {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f104_bao_cao_nhan_su_theo_phong_ban));
            this.m_fg_don_vi = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lbl_so_ban_ghi_don_vi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dat_tu_ngay = new System.Windows.Forms.DateTimePicker();
            this.m_cmd_search_don_vi = new SIS.Controls.Button.SiSButton();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.m_lbl_tim_kiem = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cbo_trang_thai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lbl_so_ban_ghi_nhan_su = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cbo_gioi_tinh = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cmd_search_nhan_su = new SIS.Controls.Button.SiSButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_fg_nhan_su = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_xuat_excel = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg_don_vi)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg_nhan_su)).BeginInit();
            this.m_pnl_out_place_dm.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_fg_don_vi
            // 
            this.m_fg_don_vi.ColumnInfo = resources.GetString("m_fg_don_vi.ColumnInfo");
            this.m_fg_don_vi.Location = new System.Drawing.Point(1, 70);
            this.m_fg_don_vi.Name = "m_fg_don_vi";
            this.m_fg_don_vi.Size = new System.Drawing.Size(1169, 183);
            this.m_fg_don_vi.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg_don_vi.Styles"));
            this.m_fg_don_vi.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lbl_so_ban_ghi_don_vi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_dat_tu_ngay);
            this.panel1.Controls.Add(this.m_cmd_search_don_vi);
            this.panel1.Controls.Add(this.m_txt_tim_kiem);
            this.panel1.Controls.Add(this.m_lbl_tim_kiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 72);
            this.panel1.TabIndex = 22;
            // 
            // m_lbl_so_ban_ghi_don_vi
            // 
            this.m_lbl_so_ban_ghi_don_vi.AutoSize = true;
            this.m_lbl_so_ban_ghi_don_vi.Location = new System.Drawing.Point(137, 53);
            this.m_lbl_so_ban_ghi_don_vi.Name = "m_lbl_so_ban_ghi_don_vi";
            this.m_lbl_so_ban_ghi_don_vi.Size = new System.Drawing.Size(127, 14);
            this.m_lbl_so_ban_ghi_don_vi.TabIndex = 28;
            this.m_lbl_so_ban_ghi_don_vi.Text = "lbl_so_luong_phong_ban";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "Số lượng phòng ban:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "Từ ngày";
            // 
            // m_dat_tu_ngay
            // 
            this.m_dat_tu_ngay.Checked = false;
            this.m_dat_tu_ngay.CustomFormat = "dd/MM/yyyy";
            this.m_dat_tu_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dat_tu_ngay.Location = new System.Drawing.Point(374, 34);
            this.m_dat_tu_ngay.Name = "m_dat_tu_ngay";
            this.m_dat_tu_ngay.ShowCheckBox = true;
            this.m_dat_tu_ngay.Size = new System.Drawing.Size(200, 20);
            this.m_dat_tu_ngay.TabIndex = 3;
            // 
            // m_cmd_search_don_vi
            // 
            this.m_cmd_search_don_vi.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search_don_vi.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search_don_vi.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search_don_vi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search_don_vi.ImageIndex = 5;
            this.m_cmd_search_don_vi.ImageList = this.ImageList;
            this.m_cmd_search_don_vi.Location = new System.Drawing.Point(795, 3);
            this.m_cmd_search_don_vi.Name = "m_cmd_search_don_vi";
            this.m_cmd_search_don_vi.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_search_don_vi.TabIndex = 2;
            this.m_cmd_search_don_vi.Text = "Tìm kiếm";
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
            // m_txt_tim_kiem
            // 
            this.m_txt_tim_kiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_txt_tim_kiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_tim_kiem.Location = new System.Drawing.Point(298, 8);
            this.m_txt_tim_kiem.Name = "m_txt_tim_kiem";
            this.m_txt_tim_kiem.Size = new System.Drawing.Size(445, 20);
            this.m_txt_tim_kiem.TabIndex = 1;
            // 
            // m_lbl_tim_kiem
            // 
            this.m_lbl_tim_kiem.AutoSize = true;
            this.m_lbl_tim_kiem.Location = new System.Drawing.Point(239, 11);
            this.m_lbl_tim_kiem.Name = "m_lbl_tim_kiem";
            this.m_lbl_tim_kiem.Size = new System.Drawing.Size(48, 14);
            this.m_lbl_tim_kiem.TabIndex = 24;
            this.m_lbl_tim_kiem.Text = "Tìm kiếm";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cbo_trang_thai);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.m_lbl_so_ban_ghi_nhan_su);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.m_cbo_gioi_tinh);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.m_cmd_search_nhan_su);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(5, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1169, 71);
            this.panel2.TabIndex = 25;
            // 
            // m_cbo_trang_thai
            // 
            this.m_cbo_trang_thai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbo_trang_thai.FormattingEnabled = true;
            this.m_cbo_trang_thai.Location = new System.Drawing.Point(135, 9);
            this.m_cbo_trang_thai.Name = "m_cbo_trang_thai";
            this.m_cbo_trang_thai.Size = new System.Drawing.Size(121, 22);
            this.m_cbo_trang_thai.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "Trạng thái lao động";
            // 
            // m_lbl_so_ban_ghi_nhan_su
            // 
            this.m_lbl_so_ban_ghi_nhan_su.AutoSize = true;
            this.m_lbl_so_ban_ghi_nhan_su.Location = new System.Drawing.Point(105, 49);
            this.m_lbl_so_ban_ghi_nhan_su.Name = "m_lbl_so_ban_ghi_nhan_su";
            this.m_lbl_so_ban_ghi_nhan_su.Size = new System.Drawing.Size(73, 14);
            this.m_lbl_so_ban_ghi_nhan_su.TabIndex = 28;
            this.m_lbl_so_ban_ghi_nhan_su.Text = "lbl_nhan_vien";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 14);
            this.label4.TabIndex = 27;
            this.label4.Text = "Số nhân viên:";
            // 
            // m_cbo_gioi_tinh
            // 
            this.m_cbo_gioi_tinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbo_gioi_tinh.FormattingEnabled = true;
            this.m_cbo_gioi_tinh.Items.AddRange(new object[] {
            "Tất cả",
            "Nam",
            "Nữ"});
            this.m_cbo_gioi_tinh.Location = new System.Drawing.Point(333, 9);
            this.m_cbo_gioi_tinh.Name = "m_cbo_gioi_tinh";
            this.m_cbo_gioi_tinh.Size = new System.Drawing.Size(69, 22);
            this.m_cbo_gioi_tinh.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 14);
            this.label5.TabIndex = 25;
            this.label5.Text = "Giới tính";
            // 
            // m_cmd_search_nhan_su
            // 
            this.m_cmd_search_nhan_su.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search_nhan_su.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search_nhan_su.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search_nhan_su.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search_nhan_su.ImageIndex = 5;
            this.m_cmd_search_nhan_su.ImageList = this.ImageList;
            this.m_cmd_search_nhan_su.Location = new System.Drawing.Point(1058, 9);
            this.m_cmd_search_nhan_su.Name = "m_cmd_search_nhan_su";
            this.m_cmd_search_nhan_su.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_search_nhan_su.TabIndex = 2;
            this.m_cmd_search_nhan_su.Text = "Tìm kiếm";
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.Location = new System.Drawing.Point(539, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(513, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(437, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 14);
            this.label6.TabIndex = 24;
            this.label6.Text = "Từ khoá tìm kiếm";
            // 
            // m_fg_nhan_su
            // 
            this.m_fg_nhan_su.ColumnInfo = resources.GetString("m_fg_nhan_su.ColumnInfo");
            this.m_fg_nhan_su.Location = new System.Drawing.Point(3, 330);
            this.m_fg_nhan_su.Name = "m_fg_nhan_su";
            this.m_fg_nhan_su.Size = new System.Drawing.Size(1170, 308);
            this.m_fg_nhan_su.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg_nhan_su.Styles"));
            this.m_fg_nhan_su.TabIndex = 26;
            // 
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_xuat_excel);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 640);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(1174, 36);
            this.m_pnl_out_place_dm.TabIndex = 32;
            // 
            // m_cmd_xuat_excel
            // 
            this.m_cmd_xuat_excel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_xuat_excel.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_xuat_excel.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_xuat_excel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmd_xuat_excel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.m_cmd_xuat_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_xuat_excel.ImageIndex = 19;
            this.m_cmd_xuat_excel.ImageList = this.ImageList;
            this.m_cmd_xuat_excel.Location = new System.Drawing.Point(4, 4);
            this.m_cmd_xuat_excel.Name = "m_cmd_xuat_excel";
            this.m_cmd_xuat_excel.Size = new System.Drawing.Size(118, 28);
            this.m_cmd_xuat_excel.TabIndex = 12;
            this.m_cmd_xuat_excel.Text = "Xuất Excel";
            // 
            // m_cmd_exit
            // 
            this.m_cmd_exit.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_exit.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_exit.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_exit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.m_cmd_exit.ForeColor = System.Drawing.Color.Maroon;
            this.m_cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_exit.ImageIndex = 12;
            this.m_cmd_exit.ImageList = this.ImageList;
            this.m_cmd_exit.Location = new System.Drawing.Point(1052, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(118, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // f104_bao_cao_nhan_su_theo_phong_ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 676);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Controls.Add(this.m_fg_nhan_su);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_fg_don_vi);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f104_bao_cao_nhan_su_theo_phong_ban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f104 - Báo cáo nhân sự theo phòng ban";
            this.Load += new System.EventHandler(this.f104_bao_cao_nhan_su_theo_phong_ban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_fg_don_vi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg_nhan_su)).EndInit();
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid m_fg_don_vi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_lbl_so_ban_ghi_don_vi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker m_dat_tu_ngay;
        internal SIS.Controls.Button.SiSButton m_cmd_search_don_vi;
        private System.Windows.Forms.TextBox m_txt_tim_kiem;
        private System.Windows.Forms.Label m_lbl_tim_kiem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox m_cbo_trang_thai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label m_lbl_so_ban_ghi_nhan_su;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox m_cbo_gioi_tinh;
        private System.Windows.Forms.Label label5;
        internal SIS.Controls.Button.SiSButton m_cmd_search_nhan_su;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1FlexGrid.C1FlexGrid m_fg_nhan_su;
        internal System.Windows.Forms.ImageList ImageList;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        internal SIS.Controls.Button.SiSButton m_cmd_xuat_excel;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
    }
}
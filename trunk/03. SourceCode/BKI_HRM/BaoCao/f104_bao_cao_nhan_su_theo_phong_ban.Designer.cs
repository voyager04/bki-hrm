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
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lbl_thong_bao = new System.Windows.Forms.Label();
            this.m_lbl_thoidiem = new System.Windows.Forms.Label();
            this.m_dtp_thoidiem = new System.Windows.Forms.DateTimePicker();
            this.m_lbl_so_luong_ban_ghi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmd_search = new SIS.Controls.Button.SiSButton();
            this.m_txt_search = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_xuat_excel = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdb_nhom = new System.Windows.Forms.RadioButton();
            this.m_rdb_ko_nhom = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.m_pnl_out_place_dm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.m_lbl_thong_bao);
            this.panel2.Controls.Add(this.m_lbl_thoidiem);
            this.panel2.Controls.Add(this.m_dtp_thoidiem);
            this.panel2.Controls.Add(this.m_lbl_so_luong_ban_ghi);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.m_cmd_search);
            this.panel2.Controls.Add(this.m_txt_search);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1189, 81);
            this.panel2.TabIndex = 25;
            // 
            // m_lbl_thong_bao
            // 
            this.m_lbl_thong_bao.AutoSize = true;
            this.m_lbl_thong_bao.Location = new System.Drawing.Point(13, 5);
            this.m_lbl_thong_bao.Name = "m_lbl_thong_bao";
            this.m_lbl_thong_bao.Size = new System.Drawing.Size(0, 13);
            this.m_lbl_thong_bao.TabIndex = 37;
            // 
            // m_lbl_thoidiem
            // 
            this.m_lbl_thoidiem.AutoSize = true;
            this.m_lbl_thoidiem.Location = new System.Drawing.Point(782, 28);
            this.m_lbl_thoidiem.Name = "m_lbl_thoidiem";
            this.m_lbl_thoidiem.Size = new System.Drawing.Size(57, 13);
            this.m_lbl_thoidiem.TabIndex = 36;
            this.m_lbl_thoidiem.Text = "Thời điểm:";
            // 
            // m_dtp_thoidiem
            // 
            this.m_dtp_thoidiem.CustomFormat = "dd/MM/yyyy";
            this.m_dtp_thoidiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtp_thoidiem.Location = new System.Drawing.Point(844, 23);
            this.m_dtp_thoidiem.Name = "m_dtp_thoidiem";
            this.m_dtp_thoidiem.Size = new System.Drawing.Size(99, 20);
            this.m_dtp_thoidiem.TabIndex = 2;
            this.m_dtp_thoidiem.ValueChanged += new System.EventHandler(this.m_dtp_thoidiem_ValueChanged);
            // 
            // m_lbl_so_luong_ban_ghi
            // 
            this.m_lbl_so_luong_ban_ghi.AutoSize = true;
            this.m_lbl_so_luong_ban_ghi.Location = new System.Drawing.Point(195, 55);
            this.m_lbl_so_luong_ban_ghi.Name = "m_lbl_so_luong_ban_ghi";
            this.m_lbl_so_luong_ban_ghi.Size = new System.Drawing.Size(25, 13);
            this.m_lbl_so_luong_ban_ghi.TabIndex = 28;
            this.m_lbl_so_luong_ban_ghi.Text = "000";
            this.m_lbl_so_luong_ban_ghi.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Số nhân viên viên trong danh sách:";
            this.label4.Visible = false;
            // 
            // m_cmd_search
            // 
            this.m_cmd_search.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search.ImageIndex = 5;
            this.m_cmd_search.ImageList = this.ImageList;
            this.m_cmd_search.Location = new System.Drawing.Point(961, 19);
            this.m_cmd_search.Name = "m_cmd_search";
            this.m_cmd_search.Size = new System.Drawing.Size(88, 26);
            this.m_cmd_search.TabIndex = 3;
            this.m_cmd_search.Text = "Tìm kiếm";
            // 
            // m_txt_search
            // 
            this.m_txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_txt_search.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_search.Location = new System.Drawing.Point(305, 21);
            this.m_txt_search.Name = "m_txt_search";
            this.m_txt_search.Size = new System.Drawing.Size(462, 20);
            this.m_txt_search.TabIndex = 1;
            this.m_tooltip.SetToolTip(this.m_txt_search, "Nhập Tên hoặc Mã sô phòng ban, trung tâm, khối để tìm kiếm");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Từ khoá tìm kiếm";
            // 
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_xuat_excel);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 498);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(1189, 33);
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
            this.m_cmd_xuat_excel.Size = new System.Drawing.Size(118, 25);
            this.m_cmd_xuat_excel.TabIndex = 4;
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
            this.m_cmd_exit.Location = new System.Drawing.Point(1067, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(118, 25);
            this.m_cmd_exit.TabIndex = 5;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_fg.Location = new System.Drawing.Point(0, 87);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(1189, 411);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdb_nhom);
            this.groupBox1.Controls.Add(this.m_rdb_ko_nhom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 65);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiển thị:";
            // 
            // m_rdb_nhom
            // 
            this.m_rdb_nhom.AutoSize = true;
            this.m_rdb_nhom.Location = new System.Drawing.Point(21, 44);
            this.m_rdb_nhom.Name = "m_rdb_nhom";
            this.m_rdb_nhom.Size = new System.Drawing.Size(169, 17);
            this.m_rdb_nhom.TabIndex = 1;
            this.m_rdb_nhom.Text = "Nhóm theo địa bàn, mã đơn vị";
            this.m_rdb_nhom.UseVisualStyleBackColor = true;
            this.m_rdb_nhom.CheckedChanged += new System.EventHandler(this.m_rdb_nhom_CheckedChanged);
            // 
            // m_rdb_ko_nhom
            // 
            this.m_rdb_ko_nhom.AutoSize = true;
            this.m_rdb_ko_nhom.Checked = true;
            this.m_rdb_ko_nhom.Location = new System.Drawing.Point(21, 20);
            this.m_rdb_ko_nhom.Name = "m_rdb_ko_nhom";
            this.m_rdb_ko_nhom.Size = new System.Drawing.Size(85, 17);
            this.m_rdb_ko_nhom.TabIndex = 0;
            this.m_rdb_ko_nhom.TabStop = true;
            this.m_rdb_ko_nhom.Text = "Không nhóm";
            this.m_rdb_ko_nhom.UseVisualStyleBackColor = true;
            // 
            // f104_bao_cao_nhan_su_theo_phong_ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 531);
            this.Controls.Add(this.m_fg);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f104_bao_cao_nhan_su_theo_phong_ban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F104 - Báo cáo nhân sự theo phòng ban";
            this.Load += new System.EventHandler(this.f104_bao_cao_nhan_su_theo_phong_ban_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.m_pnl_out_place_dm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        internal SIS.Controls.Button.SiSButton m_cmd_search;
        private System.Windows.Forms.TextBox m_txt_search;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ImageList ImageList;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        internal SIS.Controls.Button.SiSButton m_cmd_xuat_excel;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        private System.Windows.Forms.ToolTip m_tooltip;
        private System.Windows.Forms.Label m_lbl_thoidiem;
        private System.Windows.Forms.DateTimePicker m_dtp_thoidiem;
        private System.Windows.Forms.Label m_lbl_thong_bao;
        private System.Windows.Forms.Label m_lbl_so_luong_ban_ghi;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1FlexGrid.C1FlexGrid m_fg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton m_rdb_nhom;
        private System.Windows.Forms.RadioButton m_rdb_ko_nhom;
    }
}
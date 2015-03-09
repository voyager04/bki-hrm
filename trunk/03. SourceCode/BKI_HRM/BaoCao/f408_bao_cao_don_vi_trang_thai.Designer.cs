namespace BKI_HRM
{
    partial class f408_bao_cao_don_vi_trang_thai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f408_bao_cao_don_vi_trang_thai));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_dat_thoidiem = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_cmd_xuat_excel = new SIS.Controls.Button.SiSButton();
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_refresh = new SIS.Controls.Button.SiSButton();
            this.m_lbl_phim_tat = new System.Windows.Forms.Label();
            this.m_fg_donvi = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdb_nhom = new System.Windows.Forms.RadioButton();
            this.m_rdb_ko_nhom = new System.Windows.Forms.RadioButton();
            this.m_cmd_search = new SIS.Controls.Button.SiSButton();
            this.m_ckb_kiem_nhiem = new System.Windows.Forms.CheckBox();
            this.m_txt_search = new System.Windows.Forms.TextBox();
            this.m_lbl_so_luong_ban_ghi = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.m_pnl_out_place_dm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg_donvi)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // m_dat_thoidiem
            // 
            this.m_dat_thoidiem.CustomFormat = "dd/MM/yyyy";
            this.m_dat_thoidiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dat_thoidiem.Location = new System.Drawing.Point(368, 28);
            this.m_dat_thoidiem.Name = "m_dat_thoidiem";
            this.m_dat_thoidiem.Size = new System.Drawing.Size(313, 20);
            this.m_dat_thoidiem.TabIndex = 39;
            this.m_dat_thoidiem.ValueChanged += new System.EventHandler(this.m_dat_thoidiem_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Thời điểm:";
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
            this.m_cmd_exit.Location = new System.Drawing.Point(1225, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 7;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            this.m_cmd_exit.Visible = false;
            this.m_cmd_exit.Click += new System.EventHandler(this.m_cmd_exit_Click);
            // 
            // m_cmd_xuat_excel
            // 
            this.m_cmd_xuat_excel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_xuat_excel.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_xuat_excel.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_xuat_excel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmd_xuat_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.m_cmd_xuat_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_xuat_excel.ImageIndex = 19;
            this.m_cmd_xuat_excel.ImageList = this.ImageList;
            this.m_cmd_xuat_excel.Location = new System.Drawing.Point(4, 4);
            this.m_cmd_xuat_excel.Name = "m_cmd_xuat_excel";
            this.m_cmd_xuat_excel.Size = new System.Drawing.Size(93, 28);
            this.m_cmd_xuat_excel.TabIndex = 6;
            this.m_cmd_xuat_excel.Text = "Xuất Excel";
            this.m_cmd_xuat_excel.Click += new System.EventHandler(this.m_cmd_xuat_excel_Click);
            // 
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_refresh);
            this.m_pnl_out_place_dm.Controls.Add(this.m_lbl_phim_tat);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_xuat_excel);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 609);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(1317, 36);
            this.m_pnl_out_place_dm.TabIndex = 41;
            // 
            // m_cmd_refresh
            // 
            this.m_cmd_refresh.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_refresh.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_refresh.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_refresh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmd_refresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_refresh.ImageIndex = 12;
            this.m_cmd_refresh.ImageList = this.ImageList;
            this.m_cmd_refresh.Location = new System.Drawing.Point(1111, 4);
            this.m_cmd_refresh.Name = "m_cmd_refresh";
            this.m_cmd_refresh.Size = new System.Drawing.Size(114, 28);
            this.m_cmd_refresh.TabIndex = 1002;
            this.m_cmd_refresh.Text = "Làm mới dữ liệu";
            this.m_cmd_refresh.Click += new System.EventHandler(this.m_cmd_refresh_Click);
            // 
            // m_lbl_phim_tat
            // 
            this.m_lbl_phim_tat.AutoSize = true;
            this.m_lbl_phim_tat.Location = new System.Drawing.Point(154, 12);
            this.m_lbl_phim_tat.Name = "m_lbl_phim_tat";
            this.m_lbl_phim_tat.Size = new System.Drawing.Size(206, 13);
            this.m_lbl_phim_tat.TabIndex = 1001;
            this.m_lbl_phim_tat.Text = "Phím tắt: F6_Mở rộng-Thu gọn danh sách";
            // 
            // m_fg_donvi
            // 
            this.m_fg_donvi.ColumnInfo = "1,1,0,0,0,85,Columns:0{Width:13;}\t";
            this.m_fg_donvi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_fg_donvi.Location = new System.Drawing.Point(0, 0);
            this.m_fg_donvi.Name = "m_fg_donvi";
            this.m_fg_donvi.Size = new System.Drawing.Size(407, 609);
            this.m_fg_donvi.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg_donvi.Styles"));
            this.m_fg_donvi.TabIndex = 42;
            this.m_fg_donvi.Click += new System.EventHandler(this.m_fg_donvi_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_fg_donvi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_fg);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1317, 609);
            this.splitContainer1.SplitterDistance = 407;
            this.splitContainer1.TabIndex = 43;
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_fg.Location = new System.Drawing.Point(0, 89);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(906, 520);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 48;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.m_cmd_search);
            this.panel2.Controls.Add(this.m_ckb_kiem_nhiem);
            this.panel2.Controls.Add(this.m_dat_thoidiem);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_txt_search);
            this.panel2.Controls.Add(this.m_lbl_so_luong_ban_ghi);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 89);
            this.panel2.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdb_nhom);
            this.groupBox1.Controls.Add(this.m_rdb_ko_nhom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 65);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiển thị:";
            this.groupBox1.Visible = false;
            // 
            // m_rdb_nhom
            // 
            this.m_rdb_nhom.AutoSize = true;
            this.m_rdb_nhom.Location = new System.Drawing.Point(21, 44);
            this.m_rdb_nhom.Name = "m_rdb_nhom";
            this.m_rdb_nhom.Size = new System.Drawing.Size(194, 17);
            this.m_rdb_nhom.TabIndex = 1;
            this.m_rdb_nhom.Text = "Nhóm theo mã đơn vị, trạng thái LĐ";
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
            // m_cmd_search
            // 
            this.m_cmd_search.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search.ImageIndex = 5;
            this.m_cmd_search.ImageList = this.ImageList;
            this.m_cmd_search.Location = new System.Drawing.Point(701, 24);
            this.m_cmd_search.Name = "m_cmd_search";
            this.m_cmd_search.Size = new System.Drawing.Size(88, 26);
            this.m_cmd_search.TabIndex = 38;
            this.m_cmd_search.Text = "Tìm kiếm";
            // 
            // m_ckb_kiem_nhiem
            // 
            this.m_ckb_kiem_nhiem.AutoSize = true;
            this.m_ckb_kiem_nhiem.Location = new System.Drawing.Point(671, 54);
            this.m_ckb_kiem_nhiem.Name = "m_ckb_kiem_nhiem";
            this.m_ckb_kiem_nhiem.Size = new System.Drawing.Size(118, 17);
            this.m_ckb_kiem_nhiem.TabIndex = 45;
            this.m_ckb_kiem_nhiem.Text = "Hiển thị kiêm nhiệm";
            this.m_ckb_kiem_nhiem.UseVisualStyleBackColor = true;
            this.m_ckb_kiem_nhiem.CheckedChanged += new System.EventHandler(this.m_ckb_kiem_nhiem_CheckedChanged);
            // 
            // m_txt_search
            // 
            this.m_txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_txt_search.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_search.Location = new System.Drawing.Point(368, 28);
            this.m_txt_search.Name = "m_txt_search";
            this.m_txt_search.Size = new System.Drawing.Size(327, 20);
            this.m_txt_search.TabIndex = 35;
            this.m_txt_search.Visible = false;
            // 
            // m_lbl_so_luong_ban_ghi
            // 
            this.m_lbl_so_luong_ban_ghi.AutoSize = true;
            this.m_lbl_so_luong_ban_ghi.Location = new System.Drawing.Point(456, 55);
            this.m_lbl_so_luong_ban_ghi.Name = "m_lbl_so_luong_ban_ghi";
            this.m_lbl_so_luong_ban_ghi.Size = new System.Drawing.Size(25, 13);
            this.m_lbl_so_luong_ban_ghi.TabIndex = 44;
            this.m_lbl_so_luong_ban_ghi.Text = "000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Từ khoá tìm kiếm";
            this.label6.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Số nhân viên viên trong danh sách:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1317, 609);
            this.panel1.TabIndex = 44;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // f408_bao_cao_don_vi_trang_thai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmd_exit;
            this.ClientSize = new System.Drawing.Size(1317, 645);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1600, 1000);
            this.MinimumSize = new System.Drawing.Size(877, 451);
            this.Name = "f408_bao_cao_don_vi_trang_thai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f408_bao_cao_don_vi_trang_thai";
            this.Load += new System.EventHandler(this.f408_bao_cao_don_vi_trang_thai_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.m_pnl_out_place_dm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg_donvi)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.DateTimePicker m_dat_thoidiem;
        private System.Windows.Forms.Label label1;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        internal SIS.Controls.Button.SiSButton m_cmd_xuat_excel;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        private C1.Win.C1FlexGrid.C1FlexGrid m_fg_donvi;
        private System.Windows.Forms.Label m_lbl_phim_tat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
        internal SIS.Controls.Button.SiSButton m_cmd_search;
        private System.Windows.Forms.CheckBox m_ckb_kiem_nhiem;
        private System.Windows.Forms.Label m_lbl_so_luong_ban_ghi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton m_rdb_nhom;
        private System.Windows.Forms.RadioButton m_rdb_ko_nhom;
        private System.Windows.Forms.TextBox m_txt_search;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        internal SIS.Controls.Button.SiSButton m_cmd_refresh;
        private C1.Win.C1FlexGrid.C1FlexGrid m_fg;

    }
}
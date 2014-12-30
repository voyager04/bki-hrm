///************************************************
/// Generated by: AnhLT
/// Date: 13/05/2014 06:15:33
/// Goal: Create Form for V_DM_DU_LIEU_NHAN_VIEN
///************************************************


using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPExcelReport;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;

namespace BKI_HRM
{
	public class f409_bao_cao_nghi_viec : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ImageList ImageList;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        internal SIS.Controls.Button.SiSButton m_cmd_xuat_excel;
        private Label m_lbl_thoidiem;
        private DateTimePicker m_dtp_tu_ngay;
        internal SIS.Controls.Button.SiSButton m_cmd_search;
        private TextBox m_txt_tim_kiem;
        private Label label1;
        private DateTimePicker m_dtp_den_ngay;
        private GroupBox groupBox1;
        private RadioButton m_rdb_nhom;
        private RadioButton m_rdb_ko_nhom;
        private Label m_lbl_soluongns;
        private Label label2;
        private Label m_lbl_phim_tat;
        private Panel panel2;
        private ComboBox m_cbo_trang_thai_ld;
        private C1FlexGrid m_fg;
		private System.ComponentModel.IContainer components;

		public f409_bao_cao_nghi_viec()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			format_controls();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f409_bao_cao_nghi_viec));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_lbl_phim_tat = new System.Windows.Forms.Label();
            this.m_cmd_xuat_excel = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_lbl_thoidiem = new System.Windows.Forms.Label();
            this.m_dtp_tu_ngay = new System.Windows.Forms.DateTimePicker();
            this.m_txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtp_den_ngay = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdb_nhom = new System.Windows.Forms.RadioButton();
            this.m_rdb_ko_nhom = new System.Windows.Forms.RadioButton();
            this.m_cmd_search = new SIS.Controls.Button.SiSButton();
            this.m_lbl_soluongns = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cbo_trang_thai_ld = new System.Windows.Forms.ComboBox();
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_pnl_out_place_dm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).BeginInit();
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
            this.m_pnl_out_place_dm.Controls.Add(this.m_lbl_phim_tat);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_xuat_excel);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 586);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(1268, 36);
            this.m_pnl_out_place_dm.TabIndex = 19;
            // 
            // m_lbl_phim_tat
            // 
            this.m_lbl_phim_tat.AutoSize = true;
            this.m_lbl_phim_tat.Location = new System.Drawing.Point(193, 12);
            this.m_lbl_phim_tat.Name = "m_lbl_phim_tat";
            this.m_lbl_phim_tat.Size = new System.Drawing.Size(206, 13);
            this.m_lbl_phim_tat.TabIndex = 1001;
            this.m_lbl_phim_tat.Text = "Phím tắt: F6_Mở rộng-Thu gọn danh sách";
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
            this.m_cmd_xuat_excel.Click += new System.EventHandler(this.m_cmd_xuat_excel_Click);
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
            this.m_cmd_exit.Location = new System.Drawing.Point(1176, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // m_lbl_thoidiem
            // 
            this.m_lbl_thoidiem.AutoSize = true;
            this.m_lbl_thoidiem.Location = new System.Drawing.Point(756, 11);
            this.m_lbl_thoidiem.Name = "m_lbl_thoidiem";
            this.m_lbl_thoidiem.Size = new System.Drawing.Size(49, 13);
            this.m_lbl_thoidiem.TabIndex = 38;
            this.m_lbl_thoidiem.Text = "Từ ngày:";
            // 
            // m_dtp_tu_ngay
            // 
            this.m_dtp_tu_ngay.CustomFormat = "dd/MM/yyyy";
            this.m_dtp_tu_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtp_tu_ngay.Location = new System.Drawing.Point(819, 5);
            this.m_dtp_tu_ngay.Name = "m_dtp_tu_ngay";
            this.m_dtp_tu_ngay.Size = new System.Drawing.Size(176, 20);
            this.m_dtp_tu_ngay.TabIndex = 37;
            this.m_dtp_tu_ngay.ValueChanged += new System.EventHandler(this.m_dtp_tu_ngay_ValueChanged);
            // 
            // m_txt_tim_kiem
            // 
            this.m_txt_tim_kiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_txt_tim_kiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_tim_kiem.Location = new System.Drawing.Point(240, 8);
            this.m_txt_tim_kiem.Name = "m_txt_tim_kiem";
            this.m_txt_tim_kiem.Size = new System.Drawing.Size(405, 20);
            this.m_txt_tim_kiem.TabIndex = 35;
            this.m_txt_tim_kiem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_txt_tim_kiem_MouseClick);
            this.m_txt_tim_kiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txt_tim_kiem_KeyDown);
            this.m_txt_tim_kiem.Leave += new System.EventHandler(this.m_txt_tim_kiem_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(756, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Đến ngày:";
            // 
            // m_dtp_den_ngay
            // 
            this.m_dtp_den_ngay.CustomFormat = "dd/MM/yyyy";
            this.m_dtp_den_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtp_den_ngay.Location = new System.Drawing.Point(819, 31);
            this.m_dtp_den_ngay.Name = "m_dtp_den_ngay";
            this.m_dtp_den_ngay.Size = new System.Drawing.Size(176, 20);
            this.m_dtp_den_ngay.TabIndex = 39;
            this.m_dtp_den_ngay.ValueChanged += new System.EventHandler(this.m_dtp_den_ngay_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdb_nhom);
            this.groupBox1.Controls.Add(this.m_rdb_ko_nhom);
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 65);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiển thị:";
            // 
            // m_rdb_nhom
            // 
            this.m_rdb_nhom.AutoSize = true;
            this.m_rdb_nhom.Location = new System.Drawing.Point(21, 44);
            this.m_rdb_nhom.Name = "m_rdb_nhom";
            this.m_rdb_nhom.Size = new System.Drawing.Size(178, 17);
            this.m_rdb_nhom.TabIndex = 1;
            this.m_rdb_nhom.Text = "Nhóm theo địa bàn, mã chức vụ";
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
            this.m_cmd_search.Location = new System.Drawing.Point(651, 3);
            this.m_cmd_search.Name = "m_cmd_search";
            this.m_cmd_search.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_search.TabIndex = 36;
            this.m_cmd_search.Text = "Tìm kiếm";
            this.m_cmd_search.Click += new System.EventHandler(this.m_cmd_search_Click);
            // 
            // m_lbl_soluongns
            // 
            this.m_lbl_soluongns.AutoSize = true;
            this.m_lbl_soluongns.Location = new System.Drawing.Point(705, 55);
            this.m_lbl_soluongns.Name = "m_lbl_soluongns";
            this.m_lbl_soluongns.Size = new System.Drawing.Size(35, 13);
            this.m_lbl_soluongns.TabIndex = 45;
            this.m_lbl_soluongns.Text = "label2";
            this.m_lbl_soluongns.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Số lượng nhân sự:";
            this.label2.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cbo_trang_thai_ld);
            this.panel2.Controls.Add(this.m_cmd_search);
            this.panel2.Controls.Add(this.m_lbl_soluongns);
            this.panel2.Controls.Add(this.m_txt_tim_kiem);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.m_dtp_tu_ngay);
            this.panel2.Controls.Add(this.m_lbl_thoidiem);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.m_dtp_den_ngay);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1268, 75);
            this.panel2.TabIndex = 47;
            // 
            // m_cbo_trang_thai_ld
            // 
            this.m_cbo_trang_thai_ld.FormattingEnabled = true;
            this.m_cbo_trang_thai_ld.Location = new System.Drawing.Point(240, 47);
            this.m_cbo_trang_thai_ld.Name = "m_cbo_trang_thai_ld";
            this.m_cbo_trang_thai_ld.Size = new System.Drawing.Size(121, 21);
            this.m_cbo_trang_thai_ld.TabIndex = 46;
            this.m_cbo_trang_thai_ld.SelectedValueChanged += new System.EventHandler(this.m_cbo_trang_thai_ld_SelectedValueChanged);
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_fg.Location = new System.Drawing.Point(0, 75);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(1268, 511);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 48;
            // 
            // f409_bao_cao_nghi_viec
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.m_cmd_exit;
            this.ClientSize = new System.Drawing.Size(1268, 622);
            this.Controls.Add(this.m_fg);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f409_bao_cao_nghi_viec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F409 - Nhân sự theo TTLĐ";
            this.Load += new System.EventHandler(this.f409_bao_cao_nghi_viec_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.m_pnl_out_place_dm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		public void display(){			
			this.ShowDialog();
		}
        public delegate void close_tab(bool ip_y_n);
        public close_tab close_tab_B;

		#endregion

		#region Data Structure
        private enum e_col_Number
        {
            EMAIL_CQ = 25
,
            TEN_DON_VI = 22
                ,
            MA_NV = 1
                ,
            NGAY_KET_THUC = 12
                ,
            NGAY_BAT_DAU = 11
                ,
            TRANG_THAI_CV = 21
                ,
            LOAI_CV = 8
                ,
            MA_QUYET_DINH = 13
                ,
            DIA_BAN = 23
                ,
            TEN = 3
                ,
            LOAI_QD = 16
                ,
            NGAY_CO_HIEU_LUC = 14
                ,
            MA_DON_VI = 7
                ,
            MA_TTLD = 9
                ,
            HO_DEM = 2
                ,
            TY_LE_THAM_GIA = 10
                ,
            NGAY_HET_HIEU_LUC_LD = 20
                ,
            NGAY_CO_HIEU_LUC_LD = 19
                ,
            NGAY_HET_HIEU_LUC = 15
                ,
            DI_DONG = 26
                ,
            TRANG_THAI_LD_HIEN_TAI = 18
                ,
            CHO_O = 27
                ,
            MA_HEADCOUNT = 28
                ,
            MA_CV = 21
                ,
            BAC = 6
                ,
            MA_QUYET_DINH_MIEN_NHIEM = 17
                ,
            NGACH = 5
                ,
            GIOI_TINH = 24
                , MA_PHAP_NHAN = 4

        }		
		#endregion

		#region Members
		ITransferDataRow m_obj_trans;		
		DS_V_DM_DU_LIEU_NHAN_VIEN m_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
		US_V_DM_DU_LIEU_NHAN_VIEN m_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
		#endregion

		#region Private Methods
		private void format_controls(){
			CControlFormat.setFormStyle(this, new CAppContext_201());
			CControlFormat.setC1FlexFormat(m_fg);
			CGridUtils.AddSave_Excel_Handlers(m_fg);
            			CGridUtils.AddSearch_Handlers(m_fg);
                        m_fg.Tree.Column = (int)e_col_Number.DIA_BAN;
                        m_fg.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf;
			set_define_events();
			this.KeyPreview = true;		
		}
		private void set_initial_form_load(){						
			m_obj_trans = get_trans_object(m_fg);
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_LAO_DONG, WinFormControls.eTAT_CA.NO, m_cbo_trang_thai_ld);
            m_txt_tim_kiem.Text = "";
            load_data_2_grid();
            m_txt_tim_kiem.Text = "Nhập mã đơn vị, mã nhân viên, họ tên";		
		}	
		private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg){
			Hashtable v_htb = new Hashtable();
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.EMAIL_CQ, e_col_Number.EMAIL_CQ);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TEN_DON_VI, e_col_Number.TEN_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_KET_THUC, e_col_Number.NGAY_KET_THUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_BAT_DAU, e_col_Number.NGAY_BAT_DAU);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TRANG_THAI_CV, e_col_Number.TRANG_THAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.LOAI_CV, e_col_Number.LOAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_QUYET_DINH, e_col_Number.MA_QUYET_DINH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.DIA_BAN, e_col_Number.DIA_BAN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TEN, e_col_Number.TEN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.LOAI_QD, e_col_Number.LOAI_QD);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_CO_HIEU_LUC, e_col_Number.NGAY_CO_HIEU_LUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_DON_VI, e_col_Number.MA_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_TTLD, e_col_Number.MA_TTLD);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.HO_DEM, e_col_Number.HO_DEM);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TY_LE_THAM_GIA, e_col_Number.TY_LE_THAM_GIA);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_HET_HIEU_LUC_LD, e_col_Number.NGAY_HET_HIEU_LUC_LD);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_CO_HIEU_LUC_LD, e_col_Number.NGAY_CO_HIEU_LUC_LD);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_HET_HIEU_LUC, e_col_Number.NGAY_HET_HIEU_LUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.DI_DONG, e_col_Number.DI_DONG);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TRANG_THAI_LD_HIEN_TAI, e_col_Number.TRANG_THAI_LD_HIEN_TAI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.CHO_O, e_col_Number.CHO_O);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_HEADCOUNT, e_col_Number.MA_HEADCOUNT);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_CV, e_col_Number.MA_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.BAC, e_col_Number.BAC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_QUYET_DINH_MIEN_NHIEM, e_col_Number.MA_QUYET_DINH_MIEN_NHIEM);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGACH, e_col_Number.NGACH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.GIOI_TINH, e_col_Number.GIOI_TINH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_PHAP_NHAN, e_col_Number.MA_PHAP_NHAN);

						
			ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg,v_htb,m_ds.V_DM_DU_LIEU_NHAN_VIEN.NewRow());
			return v_obj_trans;			
		}
		private void load_data_2_grid(){						
			m_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            m_us.FillDatasetNVNghiviec(m_ds,m_txt_tim_kiem.Text.Trim(),m_dtp_tu_ngay.Value,m_dtp_den_ngay.Value,decimal.Parse(m_cbo_trang_thai_ld.SelectedValue.ToString()), CAppContext_201.getCurrentIDPhapnhan());
			m_fg.Redraw = false;
			CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            if (m_rdb_nhom.Checked == true)
            {
                m_fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count
                  , 0
                  , (int)e_col_Number.DIA_BAN
                  , (int)e_col_Number.MA_NV
                  , "{0}"
                  );
                m_fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count
                  , 1
                  , (int)e_col_Number.MA_DON_VI
                  , (int)e_col_Number.MA_NV
                  , "{0}"
                  );
            }
			m_fg.Redraw = true;
            m_lbl_soluongns.Text = m_ds.V_DM_DU_LIEU_NHAN_VIEN.Count.ToString();
		}
		private void grid2us_object(US_V_DM_DU_LIEU_NHAN_VIEN i_us
			, int i_grid_row) {
			DataRow v_dr;
			v_dr = (DataRow) m_fg.Rows[i_grid_row].UserData;
			m_obj_trans.GridRow2DataRow(i_grid_row,v_dr);
			i_us.DataRow2Me(v_dr);
		}

	
		private void us_object2grid(US_V_DM_DU_LIEU_NHAN_VIEN i_us
			, int i_grid_row) {
			DataRow v_dr = (DataRow) m_fg.Rows[i_grid_row].UserData;
			i_us.Me2DataRow(v_dr);
			m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
		}
        private void load_custom_source_2_m_txt_tim_kiem()
        {
            m_us.FillDataset(m_ds, "WHERE ID_PHAP_NHAN ="+CAppContext_201.getCurrentIDPhapnhan().ToString());
            int count = m_ds.Tables["V_DM_DU_LIEU_NHAN_VIEN"].Rows.Count;
            AutoCompleteStringCollection v_acsc_search = new AutoCompleteStringCollection();
            foreach (DataRow dr in m_ds.V_DM_DU_LIEU_NHAN_VIEN)
            {
                v_acsc_search.Add(dr[V_DM_DU_LIEU_NHAN_VIEN.MA_DON_VI].ToString());
                v_acsc_search.Add(dr[V_DM_DU_LIEU_NHAN_VIEN.HO_DEM].ToString() + " " + dr[V_DM_DU_LIEU_NHAN_VIEN.TEN].ToString());
                v_acsc_search.Add(dr[V_DM_DU_LIEU_NHAN_VIEN.MA_NV].ToString());
            }
            m_txt_tim_kiem.AutoCompleteCustomSource = v_acsc_search;
        }

        private void export_2_excel()
        {
            CExcelReport v_obj_excel_rpt = new CExcelReport("f409_bao_cao_nghi_viec.xlsx", 3, 2);
            v_obj_excel_rpt.AddFindAndReplaceItem("<tu_ngay>", m_dtp_tu_ngay.Value);
            v_obj_excel_rpt.AddFindAndReplaceItem("<den_ngay>", m_dtp_den_ngay.Value);
            v_obj_excel_rpt.FindAndReplace(false);
            v_obj_excel_rpt.Export2ExcelWithoutFixedRows(m_fg, 1, m_fg.Cols.Count - 1, true);
        }

		private void set_define_events(){
			m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
			
		}
		#endregion

//
		//
		//		EVENT HANLDERS
		//
		//
		private void f409_bao_cao_nghi_viec_Load(object sender, System.EventArgs e) {
			try{
				set_initial_form_load();
                load_custom_source_2_m_txt_tim_kiem();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		
		}

		private void m_cmd_exit_Click(object sender, EventArgs e) {
			try{
                close_tab_B(true);
    
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

        private void m_cmd_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_txt_tim_kiem.Text.Trim() == "Nhập mã đơn vị, mã nhân viên, họ tên")
                {
                    m_txt_tim_kiem.Text = "";
                    load_data_2_grid();
                    m_txt_tim_kiem.Text = "Nhập mã đơn vị, mã nhân viên, họ tên";
                }
                else
                    load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_tim_kiem_Leave(object sender, EventArgs e)
        {
            try
            {
                if (m_txt_tim_kiem.Text.Trim() == "")
                    m_txt_tim_kiem.Text = "Nhập mã đơn vị, mã nhân viên, họ tên";
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_tim_kiem_MouseClick(object sender, MouseEventArgs e)
        {
            m_txt_tim_kiem.Text = "";
        }

        private void m_txt_tim_kiem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    load_data_2_grid();

                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_dtp_tu_ngay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
            if (m_txt_tim_kiem.Text.Trim() == "Nhập mã đơn vị, mã nhân viên, họ tên")
            {
                m_txt_tim_kiem.Text = "";
                load_data_2_grid();
                m_txt_tim_kiem.Text = "Nhập mã đơn vị, mã nhân viên, họ tên";
            }
            else
                load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_dtp_den_ngay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_txt_tim_kiem.Text.Trim() == "Nhập mã đơn vị, mã nhân viên, họ tên")
                {
                    m_txt_tim_kiem.Text = "";
                    load_data_2_grid();
                    m_txt_tim_kiem.Text = "Nhập mã đơn vị, mã nhân viên, họ tên";
                }
                else
                    load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_rdb_nhom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_txt_tim_kiem.Text.Trim() == "Nhập mã đơn vị, mã nhân viên, họ tên")
                {
                    m_txt_tim_kiem.Text = "";
                    load_data_2_grid();
                    m_txt_tim_kiem.Text = "Nhập mã đơn vị, mã nhân viên, họ tên";
                }
                else
                    load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_xuat_excel_Click(object sender, EventArgs e)
        {
            try
            {
                export_2_excel();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_trang_thai_ld_SelectedValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                if (m_txt_tim_kiem.Text.Trim() == "Nhập mã đơn vị, mã nhân viên, họ tên")
                {
                    m_txt_tim_kiem.Text = "";
                    load_data_2_grid();
                    m_txt_tim_kiem.Text = "Nhập mã đơn vị, mã nhân viên, họ tên";
                }
                else
                    load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }*/
        }
	}
}


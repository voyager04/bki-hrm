///************************************************
/// Generated by: AnhHT
/// Date: 27/02/2014 05:17:25
/// Goal: Create Form for V_GD_QUA_TRINH_LAM_VIEC
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
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;

namespace BKI_HRM
{



	public class f202_V_GD_QUA_TRINH_LAM_VIEC : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ImageList ImageList;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        private Label label1;
        private TextBox m_txt_tim_kiem;
        internal SIS.Controls.Button.SiSButton m_cmd_tim_nhan_vien;
        private C1FlexGrid m_grv_qua_trinh_lam_viec;
        internal SIS.Controls.Button.SiSButton m_cmd_delete;
        internal SIS.Controls.Button.SiSButton m_cmd_kiem_nhiem;
        internal SIS.Controls.Button.SiSButton m_cmd_mien_nhiem;
        internal SIS.Controls.Button.SiSButton m_cmd_update;
        private Label m_lbl_mess;
        private Label m_lbl_so_nhan_vien;
        private Label m_lbl_phim_tat;
		private System.ComponentModel.IContainer components;

		public f202_V_GD_QUA_TRINH_LAM_VIEC()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f202_V_GD_QUA_TRINH_LAM_VIEC));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_lbl_phim_tat = new System.Windows.Forms.Label();
            this.m_cmd_update = new SIS.Controls.Button.SiSButton();
            this.m_cmd_kiem_nhiem = new SIS.Controls.Button.SiSButton();
            this.m_cmd_mien_nhiem = new SIS.Controls.Button.SiSButton();
            this.m_cmd_delete = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.m_cmd_tim_nhan_vien = new SIS.Controls.Button.SiSButton();
            this.m_grv_qua_trinh_lam_viec = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_lbl_mess = new System.Windows.Forms.Label();
            this.m_lbl_so_nhan_vien = new System.Windows.Forms.Label();
            this.m_pnl_out_place_dm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grv_qua_trinh_lam_viec)).BeginInit();
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
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_update);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_kiem_nhiem);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_mien_nhiem);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_delete);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 434);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(1096, 36);
            this.m_pnl_out_place_dm.TabIndex = 19;
            // 
            // m_lbl_phim_tat
            // 
            this.m_lbl_phim_tat.AutoSize = true;
            this.m_lbl_phim_tat.Location = new System.Drawing.Point(142, 12);
            this.m_lbl_phim_tat.Name = "m_lbl_phim_tat";
            this.m_lbl_phim_tat.Size = new System.Drawing.Size(206, 13);
            this.m_lbl_phim_tat.TabIndex = 1000;
            this.m_lbl_phim_tat.Text = "Phím tắt: F6_Mở rộng-Thu gọn danh sách";
            // 
            // m_cmd_update
            // 
            this.m_cmd_update.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_update.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_update.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_update.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_update.ImageIndex = 9;
            this.m_cmd_update.ImageList = this.ImageList;
            this.m_cmd_update.Location = new System.Drawing.Point(596, 4);
            this.m_cmd_update.Name = "m_cmd_update";
            this.m_cmd_update.Size = new System.Drawing.Size(104, 28);
            this.m_cmd_update.TabIndex = 18;
            this.m_cmd_update.Text = "&Sửa";
            this.m_cmd_update.Visible = false;
            this.m_cmd_update.Click += new System.EventHandler(this.m_cmd_update_Click);
            // 
            // m_cmd_kiem_nhiem
            // 
            this.m_cmd_kiem_nhiem.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_kiem_nhiem.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_kiem_nhiem.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_kiem_nhiem.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_kiem_nhiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_kiem_nhiem.ImageIndex = 6;
            this.m_cmd_kiem_nhiem.ImageList = this.ImageList;
            this.m_cmd_kiem_nhiem.Location = new System.Drawing.Point(700, 4);
            this.m_cmd_kiem_nhiem.Name = "m_cmd_kiem_nhiem";
            this.m_cmd_kiem_nhiem.Size = new System.Drawing.Size(105, 28);
            this.m_cmd_kiem_nhiem.TabIndex = 17;
            this.m_cmd_kiem_nhiem.Text = "&Bổ nhiệm";
            // 
            // m_cmd_mien_nhiem
            // 
            this.m_cmd_mien_nhiem.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_mien_nhiem.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_mien_nhiem.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_mien_nhiem.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_mien_nhiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_mien_nhiem.ImageIndex = 11;
            this.m_cmd_mien_nhiem.ImageList = this.ImageList;
            this.m_cmd_mien_nhiem.Location = new System.Drawing.Point(805, 4);
            this.m_cmd_mien_nhiem.Name = "m_cmd_mien_nhiem";
            this.m_cmd_mien_nhiem.Size = new System.Drawing.Size(111, 28);
            this.m_cmd_mien_nhiem.TabIndex = 16;
            this.m_cmd_mien_nhiem.Text = "&Miễn nhiệm";
            // 
            // m_cmd_delete
            // 
            this.m_cmd_delete.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_delete.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_delete.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_delete.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_delete.ImageIndex = 4;
            this.m_cmd_delete.ImageList = this.ImageList;
            this.m_cmd_delete.Location = new System.Drawing.Point(916, 4);
            this.m_cmd_delete.Name = "m_cmd_delete";
            this.m_cmd_delete.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_delete.TabIndex = 15;
            this.m_cmd_delete.Text = "&Xóa";
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
            this.m_cmd_exit.Location = new System.Drawing.Point(1004, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Thông tin nhân viên";
            // 
            // m_txt_tim_kiem
            // 
            this.m_txt_tim_kiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.m_txt_tim_kiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_tim_kiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txt_tim_kiem.Location = new System.Drawing.Point(315, 17);
            this.m_txt_tim_kiem.Name = "m_txt_tim_kiem";
            this.m_txt_tim_kiem.Size = new System.Drawing.Size(422, 20);
            this.m_txt_tim_kiem.TabIndex = 22;
            this.m_txt_tim_kiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txt_tim_kiem_KeyDown);
            // 
            // m_cmd_tim_nhan_vien
            // 
            this.m_cmd_tim_nhan_vien.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_tim_nhan_vien.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_tim_nhan_vien.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_tim_nhan_vien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_tim_nhan_vien.ImageIndex = 5;
            this.m_cmd_tim_nhan_vien.ImageList = this.ImageList;
            this.m_cmd_tim_nhan_vien.Location = new System.Drawing.Point(752, 12);
            this.m_cmd_tim_nhan_vien.Name = "m_cmd_tim_nhan_vien";
            this.m_cmd_tim_nhan_vien.Size = new System.Drawing.Size(111, 28);
            this.m_cmd_tim_nhan_vien.TabIndex = 23;
            this.m_cmd_tim_nhan_vien.Text = "Tìm nhân viên";
            this.m_cmd_tim_nhan_vien.Click += new System.EventHandler(this.m_cmd_tim_nhan_vien_Click);
            // 
            // m_grv_qua_trinh_lam_viec
            // 
            this.m_grv_qua_trinh_lam_viec.AllowEditing = false;
            this.m_grv_qua_trinh_lam_viec.ColumnInfo = resources.GetString("m_grv_qua_trinh_lam_viec.ColumnInfo");
            this.m_grv_qua_trinh_lam_viec.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_grv_qua_trinh_lam_viec.Location = new System.Drawing.Point(0, 61);
            this.m_grv_qua_trinh_lam_viec.Name = "m_grv_qua_trinh_lam_viec";
            this.m_grv_qua_trinh_lam_viec.Size = new System.Drawing.Size(1096, 373);
            this.m_grv_qua_trinh_lam_viec.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_grv_qua_trinh_lam_viec.Styles"));
            this.m_grv_qua_trinh_lam_viec.TabIndex = 24;
            // 
            // m_lbl_mess
            // 
            this.m_lbl_mess.AutoSize = true;
            this.m_lbl_mess.Location = new System.Drawing.Point(12, 45);
            this.m_lbl_mess.Name = "m_lbl_mess";
            this.m_lbl_mess.Size = new System.Drawing.Size(156, 13);
            this.m_lbl_mess.TabIndex = 25;
            this.m_lbl_mess.Text = "Số nhân viên ( hiện tại/tổng số)";
            this.m_lbl_mess.Visible = false;
            // 
            // m_lbl_so_nhan_vien
            // 
            this.m_lbl_so_nhan_vien.AutoSize = true;
            this.m_lbl_so_nhan_vien.Location = new System.Drawing.Point(180, 45);
            this.m_lbl_so_nhan_vien.Name = "m_lbl_so_nhan_vien";
            this.m_lbl_so_nhan_vien.Size = new System.Drawing.Size(13, 13);
            this.m_lbl_so_nhan_vien.TabIndex = 26;
            this.m_lbl_so_nhan_vien.Text = "_";
            this.m_lbl_so_nhan_vien.Visible = false;
            // 
            // f202_V_GD_QUA_TRINH_LAM_VIEC
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.m_cmd_exit;
            this.ClientSize = new System.Drawing.Size(1096, 470);
            this.Controls.Add(this.m_lbl_so_nhan_vien);
            this.Controls.Add(this.m_lbl_mess);
            this.Controls.Add(this.m_grv_qua_trinh_lam_viec);
            this.Controls.Add(this.m_cmd_tim_nhan_vien);
            this.Controls.Add(this.m_txt_tim_kiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f202_V_GD_QUA_TRINH_LAM_VIEC";
            this.Text = "F202-Thay đổi chức vụ, đơn vị công tác";
            this.Load += new System.EventHandler(this.f202_V_GD_QUA_TRINH_LAM_VIEC_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.m_pnl_out_place_dm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grv_qua_trinh_lam_viec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Public Interface
		public void display(){			
			this.ShowDialog();
		}

		#endregion

		#region Data Structure
		private enum e_col_Number{
            NGAY_CO_HIEU_LUC = 19,
            CAP_DON_VI = 14,
            NGAY_BAT_DAU = 4,
            TEN_CV = 7,
            TEN_DON_VI = 13,
            MA_NV = 1,
            MA_DON_VI = 12 ,
            NGAY_KET_THUC = 5,
            MA_CV = 6,
            HO_DEM = 2,
            LOAI_DON_VI = 15,
            TEN = 3 ,
            LOAI_CV = 10,
            TY_LE_THAM_GIA = 11,
            TRANG_THAI_CV = 9,
            MA_QUYET_DINH = 17 ,
            LOAI_QUYET_DINH = 18,
            NGAY_HET_HIEU_LUC = 20,
            DIA_BAN = 16 ,
            NGACH = 8,
            MA_QUYET_DINH_MIEN_NHIEM = 21
		}			
		#endregion

		#region Members
		ITransferDataRow m_obj_trans;		
		DS_V_GD_QUA_TRINH_LAM_VIEC m_ds_qua_trinh_lam_viec = new DS_V_GD_QUA_TRINH_LAM_VIEC();
		US_V_GD_QUA_TRINH_LAM_VIEC m_us_qua_trinh_lam_viec = new US_V_GD_QUA_TRINH_LAM_VIEC();
        US_V_DM_QUYET_DINH m_us_dm_quyet_dinh = new US_V_DM_QUYET_DINH();
        US_DM_NHAN_SU m_us_dm_nhan_su = new US_DM_NHAN_SU();
        decimal tong_so;
        decimal hien_tai;
        string m_str_message_tim_kiem = "Nhập mã nhân viên hoặc họ tên để tìm kiếm";
		#endregion

		#region Private Methods
		private void format_controls(){
			CControlFormat.setFormStyle(this, new CAppContext_201());
			CControlFormat.setC1FlexFormat(m_grv_qua_trinh_lam_viec);
			CGridUtils.AddSave_Excel_Handlers(m_grv_qua_trinh_lam_viec);
            CGridUtils.AddSearch_Handlers(m_grv_qua_trinh_lam_viec);
            m_grv_qua_trinh_lam_viec.Tree.Column = (int)e_col_Number.HO_DEM;
            m_grv_qua_trinh_lam_viec.Cols[(int)e_col_Number.MA_NV].Visible = false;
            m_grv_qua_trinh_lam_viec.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf;
			set_define_events();
            this.KeyPreview = true;
        }
        
        private void set_initial_form_load()
        {
            m_txt_tim_kiem.Text = m_str_message_tim_kiem;
            m_txt_tim_kiem.ForeColor = Color.Gray;
			m_obj_trans = get_trans_object(m_grv_qua_trinh_lam_viec);
			load_data_2_grid();		
		}	
		private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg){
			Hashtable v_htb = new Hashtable();
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.LOAI_CV, e_col_Number.LOAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.LOAI_QD, e_col_Number.LOAI_QUYET_DINH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_CO_HIEU_LUC, e_col_Number.NGAY_CO_HIEU_LUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.CAP_DON_VI, e_col_Number.CAP_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_BAT_DAU, e_col_Number.NGAY_BAT_DAU);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TEN_CV, e_col_Number.TEN_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TEN_DON_VI, e_col_Number.TEN_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_DON_VI, e_col_Number.MA_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_KET_THUC, e_col_Number.NGAY_KET_THUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_CV, e_col_Number.MA_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.HO_DEM, e_col_Number.HO_DEM);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.LOAI_DON_VI, e_col_Number.LOAI_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TEN, e_col_Number.TEN);
           // v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.LOAI_CV, e_col_Number.LOAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TY_LE_THAM_GIA, e_col_Number.TY_LE_THAM_GIA);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TRANG_THAI_CV, e_col_Number.TRANG_THAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_QUYET_DINH, e_col_Number.MA_QUYET_DINH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_HET_HIEU_LUC, e_col_Number.NGAY_HET_HIEU_LUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.DIA_BAN, e_col_Number.DIA_BAN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGACH, e_col_Number.NGACH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_QUYET_DINH_MIEN_NHIEM, e_col_Number.MA_QUYET_DINH_MIEN_NHIEM);						
			
									
			ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg,v_htb,m_ds_qua_trinh_lam_viec.V_GD_QUA_TRINH_LAM_VIEC.NewRow());
			return v_obj_trans;			
		}
		private void load_data_2_grid(){						
			m_ds_qua_trinh_lam_viec = new DS_V_GD_QUA_TRINH_LAM_VIEC();			
			m_us_qua_trinh_lam_viec.FillDataset_search(m_ds_qua_trinh_lam_viec,"", CAppContext_201.getCurrentIDPhapnhan());
			m_grv_qua_trinh_lam_viec.Redraw = false;
           
			CGridUtils.Dataset2C1Grid(m_ds_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec, m_obj_trans);
            m_grv_qua_trinh_lam_viec.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None // chỗ này dùng hàm count tức là để đếm, có thể dùng các hàm khác thay thế
             , 0
             , (int)e_col_Number.MA_NV // chỗ này là tên trường mà mình nhóm
             , (int)e_col_Number.TEN_CV // chỗ này là tên trường mà mình Count
             , "{0}"
             );
            m_grv_qua_trinh_lam_viec.Redraw = true;
           
            m_us_qua_trinh_lam_viec.Count_Nhan_vien(ref tong_so,ref  hien_tai);
            m_lbl_so_nhan_vien.Text = hien_tai.ToString() + "/" + tong_so.ToString();
        }
        private void load_data_2_grid_search()
        {
            m_ds_qua_trinh_lam_viec = new DS_V_GD_QUA_TRINH_LAM_VIEC();
            m_us_qua_trinh_lam_viec.FillDataset_search(m_ds_qua_trinh_lam_viec, m_txt_tim_kiem.Text.Trim(), CAppContext_201.getCurrentIDPhapnhan());
            m_grv_qua_trinh_lam_viec.Redraw = false;
            
            CGridUtils.Dataset2C1Grid(m_ds_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec, m_obj_trans);
            m_grv_qua_trinh_lam_viec.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None // chỗ này dùng hàm count tức là để đếm, có thể dùng các hàm khác thay thế
              , 0
              , (int)e_col_Number.MA_NV // chỗ này là tên trường mà mình nhóm
              , (int)e_col_Number.TEN_CV // chỗ này là tên trường mà mình Count
              , "{0}"
              );
            m_grv_qua_trinh_lam_viec.Redraw = true;
           
            m_us_qua_trinh_lam_viec.Count_Nhan_vien(ref tong_so,ref hien_tai);
            m_lbl_so_nhan_vien.Text = tong_so.ToString() + "/" + hien_tai.ToString();
        }
        private void load_custom_source_2_m_txt_tim_kiem()
        {
          //  int count = m_ds_qua_trinh_lam_viec.Tables["V_GD_QUA_TRINH_LAM_VIEC"].Rows.Count;
            AutoCompleteStringCollection v_acsc_search = new AutoCompleteStringCollection();
            foreach (DataRow dr in m_ds_qua_trinh_lam_viec.V_GD_QUA_TRINH_LAM_VIEC)
            {
                v_acsc_search.Add(dr[V_GD_QUA_TRINH_LAM_VIEC.MA_NV].ToString());
                v_acsc_search.Add(dr[V_GD_QUA_TRINH_LAM_VIEC.HO_DEM].ToString() + " " + dr[V_GD_QUA_TRINH_LAM_VIEC.TEN].ToString());
                v_acsc_search.Add(dr[V_GD_QUA_TRINH_LAM_VIEC.TEN].ToString());
            }
            m_txt_tim_kiem.AutoCompleteCustomSource = v_acsc_search;
        }
        private void load_data_2_grid(US_DM_NHAN_SU ip_us_dm_nhan_su)
        {
            m_ds_qua_trinh_lam_viec = new DS_V_GD_QUA_TRINH_LAM_VIEC();
            m_us_qua_trinh_lam_viec.FillDatasetByManhanvien(m_ds_qua_trinh_lam_viec, ip_us_dm_nhan_su.strMA_NV,CIPConvert.ToDatetime("01/01/1800"),DateTime.Now);
            m_grv_qua_trinh_lam_viec.Redraw = false;
            m_obj_trans = get_trans_object(m_grv_qua_trinh_lam_viec);
            
            CGridUtils.Dataset2C1Grid(m_ds_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec, m_obj_trans);
            m_grv_qua_trinh_lam_viec.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None // chỗ này dùng hàm count tức là để đếm, có thể dùng các hàm khác thay thế
              , 0
              , (int)e_col_Number.MA_NV // chỗ này là tên trường mà mình nhóm
              , (int)e_col_Number.TEN_CV // chỗ này là tên trường mà mình Count
              , "{0}"
              );
            m_grv_qua_trinh_lam_viec.Redraw = true;
        }
        private void load_data(US_DM_NHAN_SU ip_us_dm_nhan_su)
        {
            US_V_GD_QUA_TRINH_LAM_VIEC v_us = new US_V_GD_QUA_TRINH_LAM_VIEC();
            v_us.DataRow2Me((DataRow)m_grv_qua_trinh_lam_viec.Rows[1].UserData);
           
            m_txt_tim_kiem.Text = ip_us_dm_nhan_su.strMA_NV + ", " + ip_us_dm_nhan_su.strHO_DEM + " " + ip_us_dm_nhan_su.strTEN;
            
            load_data_2_grid(ip_us_dm_nhan_su);
          
        }
		private void grid2us_object(US_V_GD_QUA_TRINH_LAM_VIEC i_us
			, int i_grid_row) {
			DataRow v_dr;
			v_dr = (DataRow) m_grv_qua_trinh_lam_viec.Rows[i_grid_row].UserData;
			m_obj_trans.GridRow2DataRow(i_grid_row,v_dr);
			i_us.DataRow2Me(v_dr);
		}

        private void tim_kiem_nhan_vien()
        {
            if (m_txt_tim_kiem.Text == m_str_message_tim_kiem)
            {
                m_txt_tim_kiem.Text = "";
                load_data_2_grid_search();
                m_txt_tim_kiem.Text = m_str_message_tim_kiem;
            }
            else
            {
                load_data_2_grid_search();
            }
            
        }
        
		private void us_object2grid(US_V_GD_QUA_TRINH_LAM_VIEC i_us
			, int i_grid_row) {
			DataRow v_dr = (DataRow) m_grv_qua_trinh_lam_viec.Rows[i_grid_row].UserData;
			i_us.Me2DataRow(v_dr);
			m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
		}

        private void update_data()
        {
            m_cmd_kiem_nhiem.Visible = true;
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_qua_trinh_lam_viec)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row)) return;
            if (m_grv_qua_trinh_lam_viec.Rows[m_grv_qua_trinh_lam_viec.Row].UserData != null)
            {
                grid2us_object(m_us_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row);
                f202_v_gd_qua_trinh_lam_viec_de v_fDE = new f202_v_gd_qua_trinh_lam_viec_de();
                v_fDE.display_for_update_qd(m_us_qua_trinh_lam_viec);
                if (m_txt_tim_kiem.Text == m_str_message_tim_kiem)
                {
                    m_txt_tim_kiem.Text = "";
                    load_data_2_grid_search();
                    m_txt_tim_kiem.Text = m_str_message_tim_kiem;
                }
                else
                load_data_2_grid_search();
            }
            else
            {
                MessageBox.Show("Chọn dòng khác để sửa.");
            }
        }
		private void insert_v_gd_qua_trinh_lam_viec(string ip_str_loai_thay_doi){
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_qua_trinh_lam_viec)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row)) return;
            

            if (m_grv_qua_trinh_lam_viec.Rows[m_grv_qua_trinh_lam_viec.Row].UserData != null)
            {
                grid2us_object(m_us_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row);
            }
            else
            {
                grid2us_object(m_us_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row + 1);
            }
            if (m_txt_tim_kiem.Text == m_str_message_tim_kiem)
            {
                m_txt_tim_kiem.Text = "";
                load_data_2_grid_search();
                m_txt_tim_kiem.Text = m_str_message_tim_kiem;
            }
            else
            {
                load_data_2_grid_search();
            }
            
            m_us_qua_trinh_lam_viec.FillDataset_search(m_ds_qua_trinh_lam_viec, "",CAppContext_201.getCurrentIDPhapnhan());
            int v_i_count = m_ds_qua_trinh_lam_viec.V_GD_QUA_TRINH_LAM_VIEC.Count;
            f202_v_gd_qua_trinh_lam_viec_de v_fDE = new f202_v_gd_qua_trinh_lam_viec_de();
            v_fDE.display_for_insert(m_us_qua_trinh_lam_viec, ip_str_loai_thay_doi);

            if (m_txt_tim_kiem.Text == m_str_message_tim_kiem)
            {
                m_txt_tim_kiem.Text = "";
                load_data_2_grid_search();
                m_txt_tim_kiem.Text = m_str_message_tim_kiem;
            }
            else
            {
                load_data_2_grid_search();
            }
            
   //         m_us_qua_trinh_lam_viec.FillDataset_search(m_ds_qua_trinh_lam_viec, "",CAppContext_201.getCurrentIDPhapnhan());
//             if (m_ds_qua_trinh_lam_viec.V_GD_QUA_TRINH_LAM_VIEC.Count > v_i_count)
//             {
//                 bool v_dlr = BaseMessages.MsgBox_Confirm("Có miễn nhiệm chức vũ cũ không?");
//                 if (v_dlr)
//                 {
//                     US_V_GD_QUA_TRINH_LAM_VIEC v_us_qua_trinh_lam_viec = new US_V_GD_QUA_TRINH_LAM_VIEC();
//                     v_fDE.get_us(ref v_us_qua_trinh_lam_viec);
//                     m_txt_tim_kiem.Text = v_us_qua_trinh_lam_viec.strMA_NV;
//                     load_data_2_grid_search();
//                     m_cmd_kiem_nhiem.Visible = false;
//                 }
//             }
		}

		private void update_v_gd_qua_trinh_lam_viec()
        {
            m_cmd_kiem_nhiem.Visible = true;
			if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_qua_trinh_lam_viec)) return;
			if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row)) return;			
            if (m_grv_qua_trinh_lam_viec.Rows[m_grv_qua_trinh_lam_viec.Row].UserData != null)
            {
                grid2us_object(m_us_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row);
                f202_v_gd_qua_trinh_lam_viec_de v_fDE = new f202_v_gd_qua_trinh_lam_viec_de();
                v_fDE.display_for_update(m_us_qua_trinh_lam_viec);
                if (m_txt_tim_kiem.Text == m_str_message_tim_kiem)
                {
                    m_txt_tim_kiem.Text = "";
                    load_data_2_grid_search();
                    m_txt_tim_kiem.Text = m_str_message_tim_kiem;
                }
                else
                load_data_2_grid_search();
            }
            else
            {
                MessageBox.Show("Chọn dòng khác để sửa.");
            }
		}

       
		private void delete_v_gd_qua_trinh_lam_viec(){
			if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_qua_trinh_lam_viec)) return;
			if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row)) return;
			if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted)  return;
			US_V_GD_QUA_TRINH_LAM_VIEC v_us = new US_V_GD_QUA_TRINH_LAM_VIEC();
			grid2us_object(v_us, m_grv_qua_trinh_lam_viec.Row);
			try {			
                //v_us.BeginTransaction();    											
                //v_us.Delete();                      								
                //v_us.CommitTransaction();
                //m_grv_qua_trinh_lam_viec.Rows.Remove(m_grv_qua_trinh_lam_viec.Row);				
                v_us.BeginTransaction();
                v_us.delete_by_id_gd_chi_tiet_chuc_vu(v_us.dcID);
                v_us.CommitTransaction();
                m_grv_qua_trinh_lam_viec.Rows.Remove(m_grv_qua_trinh_lam_viec.Row);
                BaseMessages.MsgBox_Infor("Đã xóa thành công!");
			}
			catch (Exception v_e) {
				v_us.Rollback();
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e,
					new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}

        
		private void view_v_gd_qua_trinh_lam_viec(){			
			if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_qua_trinh_lam_viec)) return;
			if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row)) return;
			grid2us_object(m_us_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row);
		//	f202_V_GD_QUA_TRINH_LAM_VIEC_DE v_fDE = new f202_V_GD_QUA_TRINH_LAM_VIEC_DE();			
		//	v_fDE.display(m_us);
		}
		private void set_define_events(){
			m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
			m_cmd_kiem_nhiem.Click += new EventHandler(m_cmd_kiem_nhiem_Click);
			
			m_cmd_mien_nhiem.Click += new EventHandler(m_cmd_mien_nhiem_Click);
           m_cmd_delete.Click += new EventHandler(m_cmd_delete_Click);
            m_txt_tim_kiem.MouseClick += m_txt_tim_kiem_MouseClick;
            m_txt_tim_kiem.Leave += m_txt_tim_kiem_Leave;
            m_grv_qua_trinh_lam_viec.Click += m_grv_qua_trinh_lam_viec_Click;
		}

       private  void m_grv_qua_trinh_lam_viec_Click(object sender, EventArgs e)
        {
            if (m_grv_qua_trinh_lam_viec.Col == (int)e_col_Number.MA_QUYET_DINH)
            {
                if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_qua_trinh_lam_viec)) return;
                if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row)) return;
                grid2us_object(m_us_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row);
                if (m_us_qua_trinh_lam_viec.dcID_QUYET_DINH > 0)
                {
                    US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(m_us_qua_trinh_lam_viec.dcID_QUYET_DINH);
                    if (v_us.strLINK != "")
                    {
                        //FileExplorer.DownloadFile(v_us.strLINK);
                        f202_v_gd_qua_trinh_lam_viec_view v_frm = new f202_v_gd_qua_trinh_lam_viec_view();
                        v_frm.display_for_view_quyet_dinh(v_us);
                    }
                    else
                    {
                        BaseMessages.MsgBox_Error("Chưa có file đính kèm.");
                    }
                }
               
                else
                {
                    BaseMessages.MsgBox_Error("Chưa có file đính kèm.");
                }
            }
            if (m_grv_qua_trinh_lam_viec.Col == (int)e_col_Number.MA_QUYET_DINH_MIEN_NHIEM)
            {
                if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_qua_trinh_lam_viec)) return;
                if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row)) return;
                grid2us_object(m_us_qua_trinh_lam_viec, m_grv_qua_trinh_lam_viec.Row);
                if (m_us_qua_trinh_lam_viec.dcID_QUYET_DINH > 0)
                {
                    US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(m_us_qua_trinh_lam_viec.dcID_QUYET_DINH);
                    if (v_us.strLINK != "")
                    {
                        //FileExplorer.DownloadFile(v_us.strLINK);
                        f202_v_gd_qua_trinh_lam_viec_view v_frm = new f202_v_gd_qua_trinh_lam_viec_view();
                        v_frm.display_for_view_quyet_dinh(v_us);
                    }
                    else
                    {
                        BaseMessages.MsgBox_Error("Chưa có file đính kèm.");
                    }
                }
                else
                {
                    BaseMessages.MsgBox_Error("Chưa có file đính kèm.");
                }
            }
        }
		#endregion

//
		//
		//		EVENT HANLDERS
		//
		//
		private void f202_V_GD_QUA_TRINH_LAM_VIEC_Load(object sender, System.EventArgs e) {
			try{
				set_initial_form_load();
                m_cmd_update.Visible = true;
                m_cmd_update.Enabled = true;
                load_custom_source_2_m_txt_tim_kiem();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		
		}

		private void m_cmd_exit_Click(object sender, EventArgs e) {
			try{
				this.Close();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

		private void m_cmd_kiem_nhiem_Click(object sender, EventArgs e) {
			try{
				insert_v_gd_qua_trinh_lam_viec("kiem_nhiem");
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

		private void m_cmd_delete_Click(object sender, EventArgs e) {
			try{
				delete_v_gd_qua_trinh_lam_viec();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

        private void m_cmd_tim_nhan_vien_Click(object sender, EventArgs e)
        {
            try
            {
                tim_kiem_nhan_vien();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
            
        }

        private void m_txt_tim_kiem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    load_data_2_grid_search();
                    
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_txt_tim_kiem_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (m_txt_tim_kiem.Text == m_str_message_tim_kiem)
                    m_txt_tim_kiem.Text = "";
                m_txt_tim_kiem.ForeColor = Color.Black;
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
                if (m_txt_tim_kiem.Text == "")
                {
                    m_txt_tim_kiem.Text = m_str_message_tim_kiem;
                    m_txt_tim_kiem.ForeColor = Color.Gray;
                }

            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_mien_nhiem_Click(object sender, EventArgs e)
        {
            try
            {
                update_v_gd_qua_trinh_lam_viec();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_update_Click(object sender, EventArgs e)
        {
            try
            {
                update_data();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        
	}
}


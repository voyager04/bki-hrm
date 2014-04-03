///************************************************
/// Generated by: ThaiPH
/// Date: 22/02/2014 04:57:46
/// Goal: Create Form for V_DM_DU_AN_QUYET_DINH_TU_DIEN
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
using BKI_HRM.NghiepVu;

namespace BKI_HRM
{



	public class F500_DM_DU_AN : System.Windows.Forms.Form
    {
		internal System.Windows.Forms.Panel m_pnl_out_place_dm;
		private C1.Win.C1FlexGrid.C1FlexGrid m_grv_du_an;
		internal SIS.Controls.Button.SiSButton m_cmd_delete;
		internal SIS.Controls.Button.SiSButton m_cmd_update;
		internal SIS.Controls.Button.SiSButton m_cmd_insert;
		internal SIS.Controls.Button.SiSButton m_cmd_exit;
		internal SIS.Controls.Button.SiSButton m_cmd_view;
        private TextBox m_txt_tim_kiem;
        internal SIS.Controls.Button.SiSButton m_cmd_search;
        private Label m_lbl_tim_kiem;
        private DateTimePicker m_dat_tu_ngay;
        private DateTimePicker m_dat_den_ngay;
        private Label m_lbl_tu_ngay;
        private Label label1;
        internal ImageList ImageList;
		private System.ComponentModel.IContainer components;

		public F500_DM_DU_AN()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F500_DM_DU_AN));
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_insert = new SIS.Controls.Button.SiSButton();
            this.m_cmd_update = new SIS.Controls.Button.SiSButton();
            this.m_cmd_view = new SIS.Controls.Button.SiSButton();
            this.m_cmd_delete = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_grv_du_an = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.m_cmd_search = new SIS.Controls.Button.SiSButton();
            this.m_lbl_tim_kiem = new System.Windows.Forms.Label();
            this.m_dat_tu_ngay = new System.Windows.Forms.DateTimePicker();
            this.m_dat_den_ngay = new System.Windows.Forms.DateTimePicker();
            this.m_lbl_tu_ngay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grv_du_an)).BeginInit();
            this.SuspendLayout();
            // 
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_insert);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_update);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_view);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_delete);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 357);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(1008, 36);
            this.m_pnl_out_place_dm.TabIndex = 19;
            // 
            // m_cmd_insert
            // 
            this.m_cmd_insert.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_insert.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_insert.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_insert.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_insert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_insert.ImageIndex = 2;
            this.m_cmd_insert.ImageList = this.ImageList;
            this.m_cmd_insert.Location = new System.Drawing.Point(652, 4);
            this.m_cmd_insert.Name = "m_cmd_insert";
            this.m_cmd_insert.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_insert.TabIndex = 12;
            this.m_cmd_insert.Text = "&Thêm";
            // 
            // m_cmd_update
            // 
            this.m_cmd_update.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_update.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_update.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_update.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_update.ImageIndex = 3;
            this.m_cmd_update.ImageList = this.ImageList;
            this.m_cmd_update.Location = new System.Drawing.Point(740, 4);
            this.m_cmd_update.Name = "m_cmd_update";
            this.m_cmd_update.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_update.TabIndex = 13;
            this.m_cmd_update.Text = "&Sửa";
            // 
            // m_cmd_view
            // 
            this.m_cmd_view.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_view.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_view.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_view.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_view.ImageIndex = 18;
            this.m_cmd_view.ImageList = this.ImageList;
            this.m_cmd_view.Location = new System.Drawing.Point(4, 4);
            this.m_cmd_view.Name = "m_cmd_view";
            this.m_cmd_view.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_view.TabIndex = 21;
            this.m_cmd_view.Text = "Xem";
            this.m_cmd_view.Click += new System.EventHandler(this.m_cmd_view_Click);
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
            this.m_cmd_delete.Location = new System.Drawing.Point(828, 4);
            this.m_cmd_delete.Name = "m_cmd_delete";
            this.m_cmd_delete.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_delete.TabIndex = 14;
            this.m_cmd_delete.Text = "&Xoá";
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
            this.m_cmd_exit.Location = new System.Drawing.Point(916, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // m_grv_du_an
            // 
            this.m_grv_du_an.ColumnInfo = resources.GetString("m_grv_du_an.ColumnInfo");
            this.m_grv_du_an.Location = new System.Drawing.Point(0, 57);
            this.m_grv_du_an.Name = "m_grv_du_an";
            this.m_grv_du_an.Size = new System.Drawing.Size(1008, 291);
            this.m_grv_du_an.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_grv_du_an.Styles"));
            this.m_grv_du_an.TabIndex = 20;
            this.m_grv_du_an.Click += new System.EventHandler(this.m_grv_du_an_Click);
            // 
            // m_txt_tim_kiem
            // 
            this.m_txt_tim_kiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_txt_tim_kiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_tim_kiem.Location = new System.Drawing.Point(111, 29);
            this.m_txt_tim_kiem.Name = "m_txt_tim_kiem";
            this.m_txt_tim_kiem.Size = new System.Drawing.Size(324, 20);
            this.m_txt_tim_kiem.TabIndex = 22;
            // 
            // m_cmd_search
            // 
            this.m_cmd_search.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search.ImageList = this.ImageList;
            this.m_cmd_search.Location = new System.Drawing.Point(906, 23);
            this.m_cmd_search.Name = "m_cmd_search";
            this.m_cmd_search.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_search.TabIndex = 23;
            this.m_cmd_search.Text = "Tìm kiếm";
            this.m_cmd_search.Click += new System.EventHandler(this.m_cmd_search_Click);
            // 
            // m_lbl_tim_kiem
            // 
            this.m_lbl_tim_kiem.AutoSize = true;
            this.m_lbl_tim_kiem.Location = new System.Drawing.Point(43, 36);
            this.m_lbl_tim_kiem.Name = "m_lbl_tim_kiem";
            this.m_lbl_tim_kiem.Size = new System.Drawing.Size(49, 13);
            this.m_lbl_tim_kiem.TabIndex = 24;
            this.m_lbl_tim_kiem.Text = "Tìm kiếm";
            // 
            // m_dat_tu_ngay
            // 
            this.m_dat_tu_ngay.CustomFormat = "dd/MM/yyyy";
            this.m_dat_tu_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dat_tu_ngay.Location = new System.Drawing.Point(538, 29);
            this.m_dat_tu_ngay.Name = "m_dat_tu_ngay";
            this.m_dat_tu_ngay.ShowCheckBox = true;
            this.m_dat_tu_ngay.Size = new System.Drawing.Size(121, 20);
            this.m_dat_tu_ngay.TabIndex = 33;
            this.m_dat_tu_ngay.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            // 
            // m_dat_den_ngay
            // 
            this.m_dat_den_ngay.CustomFormat = "dd/MM/yyyy";
            this.m_dat_den_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dat_den_ngay.Location = new System.Drawing.Point(751, 29);
            this.m_dat_den_ngay.Name = "m_dat_den_ngay";
            this.m_dat_den_ngay.ShowCheckBox = true;
            this.m_dat_den_ngay.Size = new System.Drawing.Size(121, 20);
            this.m_dat_den_ngay.TabIndex = 34;
            this.m_dat_den_ngay.Value = new System.DateTime(2015, 12, 31, 0, 0, 0, 0);
            // 
            // m_lbl_tu_ngay
            // 
            this.m_lbl_tu_ngay.AutoSize = true;
            this.m_lbl_tu_ngay.Location = new System.Drawing.Point(489, 35);
            this.m_lbl_tu_ngay.Name = "m_lbl_tu_ngay";
            this.m_lbl_tu_ngay.Size = new System.Drawing.Size(46, 13);
            this.m_lbl_tu_ngay.TabIndex = 35;
            this.m_lbl_tu_ngay.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(692, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Đến ngày";
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
            // F500_DM_DU_AN
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1008, 393);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_lbl_tu_ngay);
            this.Controls.Add(this.m_dat_den_ngay);
            this.Controls.Add(this.m_dat_tu_ngay);
            this.Controls.Add(this.m_txt_tim_kiem);
            this.Controls.Add(this.m_cmd_search);
            this.Controls.Add(this.m_lbl_tim_kiem);
            this.Controls.Add(this.m_grv_du_an);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Name = "F500_DM_DU_AN";
            this.Text = "F500 Danh mục dự án";
            this.Load += new System.EventHandler(this.F500_V_DM_DU_AN_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_grv_du_an)).EndInit();
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
			MA_DU_AN = 2
,ID = 1
,NGAY_BAT_DAU = 6
,TRANG_THAI = 4
,NGAY_KET_THUC = 7
,TEN_DU_AN = 3
,MA_QUYET_DINH = 10
,NOI_DUNG = 8
,LOAI_DU_AN = 5
,CO_CHE = 9

		}			
		#endregion

		#region Members
        bool trang_thai = true;
		ITransferDataRow m_obj_trans;
        int m_dc_index_row = 1;
        int m_dc_index_row_chi_tiet_da = 1;
		DS_V_DM_DU_AN_QUYET_DINH_TU_DIEN m_ds = new DS_V_DM_DU_AN_QUYET_DINH_TU_DIEN();
		US_V_DM_DU_AN_QUYET_DINH_TU_DIEN m_us = new US_V_DM_DU_AN_QUYET_DINH_TU_DIEN();
        private enum e_col_Number_of_nhan_su_du_an
        {
            MA_NV = 3,
            HO_DEM = 4,
            TEN = 5,
            MA_CV = 6,
            MA_DON_VI = 7,
            VI_TRI = 8,
            THOI_DIEM_TG = 9,
            THOI_DIEM_KT = 10,
            THOI_GIAN_TG = 11,
            DANH_HIEU = 12
        }

		#endregion

		#region Private Methods
        //private void insert_gd_chi_tiet_du_an()
        //{
        //    F500_gd_chi_tiet_du_an_de v_fDE = new F500_gd_chi_tiet_du_an_de();
        //    v_fDE.display_for_insert();
        //    load_data_2_grid();
        //}
        //private void delete_gd_chi_tiet_du_an()
        //{
        //    if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted) return;
        //    DataRow v_dr;
        //    v_dr = (DataRow)m_grv_nhan_su.Rows[m_dc_index_row_chi_tiet_da].UserData;
        //    US_GD_CHI_TIET_DU_AN v_us = new US_GD_CHI_TIET_DU_AN();
        //    DS_GD_CHI_TIET_DU_AN v_ds = new DS_GD_CHI_TIET_DU_AN();

        //    v_us.DeleteChiTietDuAnById(v_ds, CIPConvert.ToDecimal(v_dr["ID"].ToString()));
        //    m_grv_nhan_su.Rows.Remove(m_grv_nhan_su.Row);
        //}
        private ITransferDataRow get_trans_object_nhan_su_du_an(C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_NV, e_col_Number_of_nhan_su_du_an.MA_NV);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.HO_DEM, e_col_Number_of_nhan_su_du_an.HO_DEM);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.TEN, e_col_Number_of_nhan_su_du_an.TEN);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_CV, e_col_Number_of_nhan_su_du_an.MA_CV);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_DON_VI, e_col_Number_of_nhan_su_du_an.MA_DON_VI);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.VI_TRI, e_col_Number_of_nhan_su_du_an.VI_TRI);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_DIEM_TG, e_col_Number_of_nhan_su_du_an.THOI_DIEM_TG);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_DIEM_KT, e_col_Number_of_nhan_su_du_an.THOI_DIEM_KT);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_GIAN_TG, e_col_Number_of_nhan_su_du_an.THOI_GIAN_TG);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.DANH_HIEU, e_col_Number_of_nhan_su_du_an.DANH_HIEU);
            DS_V_DM_NHAN_SU_DU_AN v_ds = new DS_V_DM_NHAN_SU_DU_AN();
            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, v_ds.V_DM_NHAN_SU_DU_AN.NewRow());
            return v_obj_trans;
        }
        //private void load_data_2_grid_dm_nhan_su(int i_dc_row_index)
        //{
        //    DS_V_DM_NHAN_SU_DU_AN v_ds_nhan_su = new DS_V_DM_NHAN_SU_DU_AN();
        //    US_V_DM_NHAN_SU_DU_AN v_us_nhan_su = new US_V_DM_NHAN_SU_DU_AN();

        //    grid2us_object(m_us, i_dc_row_index);

        //    m_lbl_ten_du_an.Text = m_us.strMA_DU_AN;

        //    v_us_nhan_su.FillDatasetByIdDuAn(v_ds_nhan_su, m_us.dcID);
        //    m_grv_nhan_su.Redraw = false;

        //    ITransferDataRow v_obj_trans = get_trans_object_nhan_su_du_an(m_grv_nhan_su);
        //    CGridUtils.Dataset2C1Grid(v_ds_nhan_su, m_grv_nhan_su, v_obj_trans);
        //    m_grv_nhan_su.Redraw = true;
        //}
        private void load_custom_source_2_m_txt_tim_kiem()
        {
            //m_us.FillDataset(m_ds);
            int count = m_ds.Tables["V_DM_DU_AN_QUYET_DINH_TU_DIEN"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataRow dr = m_ds.Tables["V_DM_DU_AN_QUYET_DINH_TU_DIEN"].Rows[i];
                m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr[1].ToString());
                m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr[2].ToString());
            }
        }
        private void F500_V_DM_DU_AN_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (!trang_thai)
                {
                    return;
                }
                set_initial_form_load();
                //load_data_2_grid_dm_nhan_su(1);
                load_custom_source_2_m_txt_tim_kiem();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }
		private void format_controls(){
			CControlFormat.setFormStyle(this, new CAppContext_201());
			CControlFormat.setC1FlexFormat(m_grv_du_an);
            //CControlFormat.setC1FlexFormat(m_grv_nhan_su);
			CGridUtils.AddSave_Excel_Handlers(m_grv_du_an);
            			CGridUtils.AddSearch_Handlers(m_grv_du_an);
            m_dat_den_ngay.Checked = false;
            m_dat_tu_ngay.Checked = false;
			set_define_events();
			this.KeyPreview = true;		
		}
		private void set_initial_form_load(){						
			m_obj_trans = get_trans_object(m_grv_du_an);
			load_data_2_grid();		
		}	
		private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg){
			Hashtable v_htb = new Hashtable();
			v_htb.Add(V_DM_DU_AN_QUYET_DINH_TU_DIEN.MA_DU_AN, e_col_Number.MA_DU_AN);
			v_htb.Add(V_DM_DU_AN_QUYET_DINH_TU_DIEN.ID, e_col_Number.ID);
			v_htb.Add(V_DM_DU_AN_QUYET_DINH_TU_DIEN.NGAY_BAT_DAU, e_col_Number.NGAY_BAT_DAU);
			v_htb.Add(V_DM_DU_AN_QUYET_DINH_TU_DIEN.TRANG_THAI, e_col_Number.TRANG_THAI);
			v_htb.Add(V_DM_DU_AN_QUYET_DINH_TU_DIEN.NGAY_KET_THUC, e_col_Number.NGAY_KET_THUC);
			v_htb.Add(V_DM_DU_AN_QUYET_DINH_TU_DIEN.TEN_DU_AN, e_col_Number.TEN_DU_AN);
			v_htb.Add(V_DM_DU_AN_QUYET_DINH_TU_DIEN.MA_QUYET_DINH, e_col_Number.MA_QUYET_DINH);
			v_htb.Add(V_DM_DU_AN_QUYET_DINH_TU_DIEN.NOI_DUNG, e_col_Number.NOI_DUNG);
			v_htb.Add(V_DM_DU_AN_QUYET_DINH_TU_DIEN.LOAI_DU_AN, e_col_Number.LOAI_DU_AN);
			v_htb.Add(V_DM_DU_AN_QUYET_DINH_TU_DIEN.CO_CHE, e_col_Number.CO_CHE);
									
			ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg,v_htb,m_ds.V_DM_DU_AN_QUYET_DINH_TU_DIEN.NewRow());
			return v_obj_trans;			
		}
		private void load_data_2_grid(){						
			m_ds = new DS_V_DM_DU_AN_QUYET_DINH_TU_DIEN();			
			m_us.FillDataset(m_ds);
			m_grv_du_an.Redraw = false;
			CGridUtils.Dataset2C1Grid(m_ds, m_grv_du_an, m_obj_trans);
			m_grv_du_an.Redraw = true;
		}
		private void grid2us_object(US_V_DM_DU_AN_QUYET_DINH_TU_DIEN i_us
			, int i_grid_row) {
			DataRow v_dr;
			v_dr = (DataRow) m_grv_du_an.Rows[i_grid_row].UserData;
			m_obj_trans.GridRow2DataRow(i_grid_row,v_dr);
			i_us.DataRow2Me(v_dr);
		}

	
		private void us_object2grid(US_V_DM_DU_AN_QUYET_DINH_TU_DIEN i_us
			, int i_grid_row) {
			DataRow v_dr = (DataRow) m_grv_du_an.Rows[i_grid_row].UserData;
			i_us.Me2DataRow(v_dr);
			m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
		}


		private void insert_v_dm_du_an_quyet_dinh_tu_dien(){			
		//	F500_V_DM_DU_AN_DE v_fDE = new  F500_V_DM_DU_AN_DE();								
		//	v_fDE.display();
            f500_dm_du_an_detail v_fDE = new f500_dm_du_an_detail();
            v_fDE.display_for_insert();
			load_data_2_grid();
		}

		private void update_v_dm_du_an_quyet_dinh_tu_dien(){			
			if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_du_an)) return;
			if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_du_an, m_grv_du_an.Row)) return;			
			grid2us_object(m_us, m_grv_du_an.Row);
            US_DM_DU_AN v_us_dm_da = new US_DM_DU_AN();
            DS_DM_DU_AN v_ds_dm_da = new DS_DM_DU_AN();

            v_us_dm_da.FillDatasetByID(v_ds_dm_da,m_us.dcID);
		//	F500_V_DM_DU_AN_DE v_fDE = new F500_V_DM_DU_AN_DE();
		//	v_fDE.display(m_us);
            f500_dm_du_an_detail v_fDE = new f500_dm_du_an_detail();
            v_fDE.display_for_update(v_ds_dm_da);
			load_data_2_grid();
		}

        //private void update_gd_chi_tiet_du_an()
        //{
        //    F500_gd_chi_tiet_du_an_de v_fDE = new F500_gd_chi_tiet_du_an_de();
        //    DataRow v_dr = (DataRow)m_grv_nhan_su.Rows[m_dc_index_row_chi_tiet_da].UserData;
        //    decimal v_dc_id_chi_tiet_du_an =(decimal)v_dr["ID"];
        //    v_fDE.display_for_update(v_dc_id_chi_tiet_du_an);
        //    load_data_2_grid_dm_nhan_su(m_dc_index_row);
        //}
				
		private void delete_v_dm_du_an_quyet_dinh_tu_dien(){
			if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_du_an)) return;
			if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_du_an, m_grv_du_an.Row)) return;
			if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted)  return;
			US_V_DM_DU_AN_QUYET_DINH_TU_DIEN v_us = new US_V_DM_DU_AN_QUYET_DINH_TU_DIEN();
            US_DM_DU_AN v_us_dm_du_an = new US_DM_DU_AN();
            DS_DM_DU_AN v_ds_dm_du_an = new DS_DM_DU_AN();
            //v_us_dm_du_an.BeginTransaction();
            grid2us_object(m_us, m_dc_index_row);
            v_us_dm_du_an.DeleteDuAnById(v_ds_dm_du_an,m_us.dcID);
            //v_us_dm_du_an.CommitTransaction();
            grid2us_object(v_us, m_grv_du_an.Row);
            m_grv_du_an.Rows.Remove(m_grv_du_an.Row);
            //try
            //{
            //    m_grv_du_an.Rows.Remove(m_grv_du_an.Row);
            //}
            //catch (Exception v_e)
            //{
            //    v_us.Rollback();
            //    CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e,
            //        new CDBClientDBExceptionInterpret());
            //    v_objErrHandler.showErrorMessage();
            //}
		}

		private void view_v_dm_du_an_quyet_dinh_tu_dien(){			
			if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_du_an)) return;
			if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_du_an, m_grv_du_an.Row)) return;
			grid2us_object(m_us, m_grv_du_an.Row);
		//	F500_V_DM_DU_AN_DE v_fDE = new F500_V_DM_DU_AN_DE();			
		//	v_fDE.display(m_us);
		}
		private void set_define_events(){
			m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
			m_cmd_insert.Click += new EventHandler(m_cmd_insert_Click);
			m_cmd_update.Click += new EventHandler(m_cmd_update_Click);
			m_cmd_delete.Click += new EventHandler(m_cmd_delete_Click);
			m_cmd_view.Click += new EventHandler(m_cmd_view_Click);
		}
		#endregion
        
        #region eventHandle
        
        private void m_cmd_exit_Click(object sender, EventArgs e) {
			try{
				this.Close();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

		private void m_cmd_insert_Click(object sender, EventArgs e) {
			try{
				insert_v_dm_du_an_quyet_dinh_tu_dien();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

		private void m_cmd_update_Click(object sender, EventArgs e) {
			try{
				update_v_dm_du_an_quyet_dinh_tu_dien();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

		private void m_cmd_delete_Click(object sender, EventArgs e) {
			try{
				delete_v_dm_du_an_quyet_dinh_tu_dien();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

		private void m_cmd_view_Click(object sender, EventArgs e) {
			try{
				view_v_dm_du_an_quyet_dinh_tu_dien();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

        private void m_grv_du_an_Click(object sender, EventArgs e)
        {
            try
            {
                m_dc_index_row = m_grv_du_an.Row;
                //load_data_2_grid_dm_nhan_su(m_dc_index_row);
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_search_Click(object sender, EventArgs e)
        {
            m_obj_trans = get_trans_object(m_grv_du_an);
            m_ds.Clear();
            if (!m_dat_tu_ngay.Checked)
            {
                m_dat_tu_ngay.Value = new DateTime(2010, 1, 1);
            }
            if (!m_dat_den_ngay.Checked)
            {
                m_dat_den_ngay.Value = new DateTime(2015,12,31);
            }
            m_us.FillDatasetSearch(m_ds, m_txt_tim_kiem.Text,m_dat_tu_ngay.Value, m_dat_den_ngay.Value);
            m_grv_du_an.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_grv_du_an, m_obj_trans);
            m_grv_du_an.Redraw = true;
        }
        
        //private void m_cmd_them_moi_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        insert_gd_chi_tiet_du_an();
        //        load_data_2_grid_dm_nhan_su(m_dc_index_row);
        //    }
        //    catch (Exception v_e)
        //    {
        //        CSystemLog_301.ExceptionHandle(v_e);
        //    }
        //}

        //private void m_cmd_sua_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        update_gd_chi_tiet_du_an();
        //        //load_data_2_grid_dm_nhan_su(m_dc_index_row);
        //    }
        //    catch (Exception v_e)
        //    {
        //        CSystemLog_301.ExceptionHandle(v_e);
        //    }
        //}
        
        //private void m_cmd_xoa_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        delete_gd_chi_tiet_du_an();
        //    }
        //    catch (Exception v_e)
        //    {
        //        CSystemLog_301.ExceptionHandle(v_e);
        //    }
        //}

        //private void m_grv_nhan_su_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        m_dc_index_row_chi_tiet_da = m_grv_nhan_su.Row;
        //    }
        //    catch (Exception v_e)
        //    {
        //        CSystemLog_301.ExceptionHandle(v_e);
        //    }
        //}
        #endregion

        public void DisplaySapKetThuc()
        {
            try
            {
                m_obj_trans = get_trans_object(m_grv_du_an);
                US.US_V_DM_DU_AN_QUYET_DINH_TU_DIEN v_us = new US_V_DM_DU_AN_QUYET_DINH_TU_DIEN();
                DS.DS_V_DM_DU_AN_QUYET_DINH_TU_DIEN v_ds = new DS_V_DM_DU_AN_QUYET_DINH_TU_DIEN();
                v_us.FillDatasetSapKetThuc(v_ds, DateTime.Now.Date);
                m_grv_du_an.Redraw = false;
                CGridUtils.Dataset2C1Grid(v_ds, m_grv_du_an, m_obj_trans);
                m_grv_du_an.Redraw = true;
                //m_ds = new DS_V_DM_DU_AN_QUYET_DINH_TU_DIEN();
                //m_us.FillDataset(m_ds);
                //m_grv_du_an.Redraw = false;
                //CGridUtils.Dataset2C1Grid(m_ds, m_grv_du_an, m_obj_trans);
                //m_grv_du_an.Redraw = true;
                trang_thai = false;
                this.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
            
        }
    }
}


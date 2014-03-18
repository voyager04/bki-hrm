///************************************************
/// Generated by: THAIPH
/// Date: 03/03/2014 04:20:41
/// Goal: Create Form for V_DM_NHAN_SU_DU_AN
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



	public class f501_v_dm_nhan_su_du_an : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ImageList ImageList;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
		internal SIS.Controls.Button.SiSButton m_cmd_delete;
		internal SIS.Controls.Button.SiSButton m_cmd_update;
		internal SIS.Controls.Button.SiSButton m_cmd_insert;
		internal SIS.Controls.Button.SiSButton m_cmd_exit;
        internal SIS.Controls.Button.SiSButton m_cmd_view;
        private TextBox m_txt_tim_kiem;
        internal SIS.Controls.Button.SiSButton m_cmd_search;
        private Label m_lbl_tim_kiem;
        private ToolTip toolTip1;
        private C1FlexGrid m_grv_nhan_su;
		private System.ComponentModel.IContainer components;

		public f501_v_dm_nhan_su_du_an()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f501_v_dm_nhan_su_du_an));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_insert = new SIS.Controls.Button.SiSButton();
            this.m_cmd_update = new SIS.Controls.Button.SiSButton();
            this.m_cmd_view = new SIS.Controls.Button.SiSButton();
            this.m_cmd_delete = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.m_cmd_search = new SIS.Controls.Button.SiSButton();
            this.m_lbl_tim_kiem = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.m_grv_nhan_su = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_pnl_out_place_dm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grv_nhan_su)).BeginInit();
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
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_insert);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_update);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_view);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_delete);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 364);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(883, 36);
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
            this.m_cmd_insert.Location = new System.Drawing.Point(527, 4);
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
            this.m_cmd_update.Location = new System.Drawing.Point(615, 4);
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
            this.m_cmd_delete.Location = new System.Drawing.Point(703, 4);
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
            this.m_cmd_exit.Location = new System.Drawing.Point(791, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // m_txt_tim_kiem
            // 
            this.m_txt_tim_kiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_txt_tim_kiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_tim_kiem.Location = new System.Drawing.Point(153, 28);
            this.m_txt_tim_kiem.Name = "m_txt_tim_kiem";
            this.m_txt_tim_kiem.Size = new System.Drawing.Size(462, 20);
            this.m_txt_tim_kiem.TabIndex = 37;
            this.toolTip1.SetToolTip(this.m_txt_tim_kiem, "Nhập mã dự án, tên dự án, mã nhân viên, họ tên nhân viên");
            // 
            // m_cmd_search
            // 
            this.m_cmd_search.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search.ImageIndex = 5;
            this.m_cmd_search.ImageList = this.ImageList;
            this.m_cmd_search.Location = new System.Drawing.Point(685, 23);
            this.m_cmd_search.Name = "m_cmd_search";
            this.m_cmd_search.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_search.TabIndex = 38;
            this.m_cmd_search.Text = "Tìm kiếm";
            this.m_cmd_search.Click += new System.EventHandler(this.m_cmd_search_Click);
            // 
            // m_lbl_tim_kiem
            // 
            this.m_lbl_tim_kiem.AutoSize = true;
            this.m_lbl_tim_kiem.Location = new System.Drawing.Point(85, 35);
            this.m_lbl_tim_kiem.Name = "m_lbl_tim_kiem";
            this.m_lbl_tim_kiem.Size = new System.Drawing.Size(49, 13);
            this.m_lbl_tim_kiem.TabIndex = 39;
            this.m_lbl_tim_kiem.Text = "Tìm kiếm";
            // 
            // m_grv_nhan_su
            // 
            this.m_grv_nhan_su.ColumnInfo = resources.GetString("m_grv_nhan_su.ColumnInfo");
            this.m_grv_nhan_su.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_grv_nhan_su.Location = new System.Drawing.Point(0, 57);
            this.m_grv_nhan_su.Name = "m_grv_nhan_su";
            this.m_grv_nhan_su.Size = new System.Drawing.Size(883, 307);
            this.m_grv_nhan_su.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_grv_nhan_su.Styles"));
            this.m_grv_nhan_su.TabIndex = 52;
            // 
            // f501_v_dm_nhan_su_du_an
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(883, 400);
            this.Controls.Add(this.m_grv_nhan_su);
            this.Controls.Add(this.m_txt_tim_kiem);
            this.Controls.Add(this.m_cmd_search);
            this.Controls.Add(this.m_lbl_tim_kiem);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Name = "f501_v_dm_nhan_su_du_an";
            this.Text = "F501 Nhân sự dự án";
            this.Load += new System.EventHandler(this.f501_v_dm_nhan_su_du_an_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_grv_nhan_su)).EndInit();
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
            MA_DU_AN = 1
                            ,
            TEN_DU_AN = 2
                ,
            MA_NV = 4
                ,
            HO_DEM = 5
                ,
            TEN = 6
                ,
            MA_CV = 7
                ,
            TEN_CV = 8
                ,
            MA_DON_VI = 9
                ,
            TEN_DON_VI = 10
                ,
            VI_TRI = 11
                ,
            THOI_DIEM_TG = 12
                ,
            THOI_DIEM_KT = 13
                ,
            THOI_GIAN_TG = 14
                ,
            DANH_HIEU = 15
                ,
            MO_TA = 18
                ,
            TRANG_THAI_CV = 19
		}			
		#endregion

		#region Members
        int m_dc_index_row_chi_tiet_da = 1;
		ITransferDataRow m_obj_trans;		
		DS_V_DM_NHAN_SU_DU_AN m_ds = new DS_V_DM_NHAN_SU_DU_AN();
		US_V_DM_NHAN_SU_DU_AN m_us = new US_V_DM_NHAN_SU_DU_AN();
		#endregion

		#region Private Methods
		private void format_controls(){
			CControlFormat.setFormStyle(this, new CAppContext_201());
			CControlFormat.setC1FlexFormat(m_grv_nhan_su);
			CGridUtils.AddSave_Excel_Handlers(m_grv_nhan_su);
            CGridUtils.AddSearch_Handlers(m_grv_nhan_su);
            m_grv_nhan_su.Tree.Column = (int)e_col_Number.TEN_DU_AN;
            m_grv_nhan_su.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf;
			set_define_events();
			this.KeyPreview = true;		
		}
		private void set_initial_form_load(){						
			m_obj_trans = get_trans_object(m_grv_nhan_su);
			load_data_2_grid();		
		}	
		private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg){
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_DM_NHAN_SU_DU_AN.VI_TRI, e_col_Number.VI_TRI);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.TEN_DON_VI, e_col_Number.TEN_DON_VI);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_NV, e_col_Number.MA_NV);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_DU_AN, e_col_Number.MA_DU_AN);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.DANH_HIEU, e_col_Number.DANH_HIEU);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.MO_TA, e_col_Number.MO_TA);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_DIEM_KT, e_col_Number.THOI_DIEM_KT);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.TEN, e_col_Number.TEN);



            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_DON_VI, e_col_Number.MA_DON_VI);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_DIEM_TG, e_col_Number.THOI_DIEM_TG);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.HO_DEM, e_col_Number.HO_DEM);



            v_htb.Add(V_DM_NHAN_SU_DU_AN.TEN_CV, e_col_Number.TEN_CV);



            v_htb.Add(V_DM_NHAN_SU_DU_AN.TEN_DU_AN, e_col_Number.TEN_DU_AN);



            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_CV, e_col_Number.MA_CV);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_GIAN_TG, e_col_Number.THOI_GIAN_TG);

            v_htb.Add(V_DM_NHAN_SU_DU_AN.TRANG_THAI_CV, e_col_Number.TRANG_THAI_CV);


            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds.V_DM_NHAN_SU_DU_AN.NewRow());
            return v_obj_trans;	
		}
		private void load_data_2_grid(){						
			m_ds = new DS_V_DM_NHAN_SU_DU_AN();			
			m_us.FillDataset(m_ds);
			m_grv_nhan_su.Redraw = false;
			CGridUtils.Dataset2C1Grid(m_ds, m_grv_nhan_su, m_obj_trans);
            m_grv_nhan_su.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count // chỗ này dùng hàm count tức là để đếm, có thể dùng các hàm khác thay thế
              , 0
              , (int)e_col_Number.MA_DU_AN // chỗ này là tên trường mà mình nhóm
              , (int)e_col_Number.MA_NV // chỗ này là tên trường mà mình Count
              , "{0}"
              );
			m_grv_nhan_su.Redraw = true;
		}
		private void grid2us_object(US_V_DM_NHAN_SU_DU_AN i_us
			, int i_grid_row) {
			DataRow v_dr;
			v_dr = (DataRow) m_grv_nhan_su.Rows[i_grid_row].UserData;
			m_obj_trans.GridRow2DataRow(i_grid_row,v_dr);
			i_us.DataRow2Me(v_dr);
		}

	
		private void us_object2grid(US_V_DM_NHAN_SU_DU_AN i_us
			, int i_grid_row) {
			DataRow v_dr = (DataRow) m_grv_nhan_su.Rows[i_grid_row].UserData;
			i_us.Me2DataRow(v_dr);
			m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
		}


		private void insert_v_dm_nhan_su_du_an(){
            F500_gd_chi_tiet_du_an_de v_fDE = new F500_gd_chi_tiet_du_an_de();
            v_fDE.display_for_insert("");
            load_data_2_grid();
		}

		private void update_v_dm_nhan_su_du_an(){
            F500_gd_chi_tiet_du_an_de v_fDE = new F500_gd_chi_tiet_du_an_de();
            DataRow v_dr = (DataRow)m_grv_nhan_su.Rows[m_dc_index_row_chi_tiet_da].UserData;
            decimal v_dc_id_chi_tiet_du_an = (decimal)v_dr["ID"];
            v_fDE.display_for_update(v_dc_id_chi_tiet_du_an);
            load_data_2_grid();
		}
				
		private void delete_v_dm_nhan_su_du_an(){
            if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted) return;
            DataRow v_dr;
            v_dr = (DataRow)m_grv_nhan_su.Rows[m_dc_index_row_chi_tiet_da].UserData;
            US_GD_CHI_TIET_DU_AN v_us = new US_GD_CHI_TIET_DU_AN();
            DS_GD_CHI_TIET_DU_AN v_ds = new DS_GD_CHI_TIET_DU_AN();

            v_us.DeleteChiTietDuAnById(v_ds, CIPConvert.ToDecimal(v_dr["ID"].ToString()));
            m_grv_nhan_su.Rows.Remove(m_grv_nhan_su.Row);
		}

		private void view_v_dm_nhan_su_du_an(){			
			if (!CGridUtils.IsThere_Any_NonFixed_Row(m_grv_nhan_su)) return;
			if (!CGridUtils.isValid_NonFixed_RowIndex(m_grv_nhan_su, m_grv_nhan_su.Row)) return;
			grid2us_object(m_us, m_grv_nhan_su.Row);
		//	f501_v_dm_nhan_su_du_an_DE v_fDE = new f501_v_dm_nhan_su_du_an_DE();			
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

//
		//
		//		EVENT HANLDERS
		//
		//
		private void f501_v_dm_nhan_su_du_an_Load(object sender, System.EventArgs e) {
			try{
				set_initial_form_load();
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

		private void m_cmd_insert_Click(object sender, EventArgs e) {
			try{
				insert_v_dm_nhan_su_du_an();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

		private void m_cmd_update_Click(object sender, EventArgs e) {
			try{
				update_v_dm_nhan_su_du_an();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

		private void m_cmd_delete_Click(object sender, EventArgs e) {
			try{
				delete_v_dm_nhan_su_du_an();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

		private void m_cmd_view_Click(object sender, EventArgs e) {
			try{
				view_v_dm_nhan_su_du_an();
			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}

        private void m_grv_nhan_su_Click(object sender, EventArgs e)
        {
            m_dc_index_row_chi_tiet_da = m_grv_nhan_su.Row;
        }

        private void m_cmd_search_Click(object sender, EventArgs e)
        {
            try
            {
                string v_str_tu_khoa = m_txt_tim_kiem.Text;
                US_V_DM_NHAN_SU_DU_AN v_us = new US_V_DM_NHAN_SU_DU_AN();
                DS_V_DM_NHAN_SU_DU_AN v_ds = new DS_V_DM_NHAN_SU_DU_AN();
                v_us.FillDatasetSearch(v_ds,v_str_tu_khoa);
                m_grv_nhan_su.Redraw = false;
                CGridUtils.Dataset2C1Grid(v_ds, m_grv_nhan_su, m_obj_trans);
                m_grv_nhan_su.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count // chỗ này dùng hàm count tức là để đếm, có thể dùng các hàm khác thay thế
                  , 0
                  , (int)e_col_Number.MA_DU_AN // chỗ này là tên trường mà mình nhóm
                  , (int)e_col_Number.MA_NV // chỗ này là tên trường mà mình Count
                  , "{0}"
                  );
                m_grv_nhan_su.Redraw = true;
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
	}
}


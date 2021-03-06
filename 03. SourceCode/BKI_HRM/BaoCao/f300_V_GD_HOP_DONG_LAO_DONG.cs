///************************************************
/// Generated by: NghiaDT
/// Date: 10/01/2014 04:55:35
/// Goal: Create Form for V_GD_HOP_DONG_LAO_DONG
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
using IP.Core.IPExcelReport;

namespace BKI_HRM
{



	public class f300_V_GD_HOP_DONG_LAO_DONG : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ImageList ImageList;
		internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        private C1.Win.C1FlexGrid.C1FlexGrid m_fg;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        private TextBox m_txt_nhan_vien;
        private Label m_lbl_ma_nhan_vien;
        private Label m_lbl_ngay_hieu_luc;
        private Label m_lbl_ngay_het_han;
        private Label m_lbl_loai_hop_dong;
        private ComboBox m_cbo_loai_hop_dong;
        private DateTimePicker m_dat_ngay_bat_dau;
        private DateTimePicker m_dat_ngay_ket_thuc;
        internal SIS.Controls.Button.SiSButton m_cmd_search;
        internal SIS.Controls.Button.SiSButton m_cmd_xuat_excel;
		private System.ComponentModel.IContainer components;

		public f300_V_GD_HOP_DONG_LAO_DONG()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f300_V_GD_HOP_DONG_LAO_DONG));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_xuat_excel = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_txt_nhan_vien = new System.Windows.Forms.TextBox();
            this.m_lbl_ma_nhan_vien = new System.Windows.Forms.Label();
            this.m_lbl_ngay_hieu_luc = new System.Windows.Forms.Label();
            this.m_lbl_ngay_het_han = new System.Windows.Forms.Label();
            this.m_lbl_loai_hop_dong = new System.Windows.Forms.Label();
            this.m_cbo_loai_hop_dong = new System.Windows.Forms.ComboBox();
            this.m_dat_ngay_bat_dau = new System.Windows.Forms.DateTimePicker();
            this.m_dat_ngay_ket_thuc = new System.Windows.Forms.DateTimePicker();
            this.m_cmd_search = new SIS.Controls.Button.SiSButton();
            this.m_pnl_out_place_dm.SuspendLayout();
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
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_xuat_excel);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 373);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(760, 36);
            this.m_pnl_out_place_dm.TabIndex = 19;
            // 
            // m_cmd_xuat_excel
            // 
            this.m_cmd_xuat_excel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_xuat_excel.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_xuat_excel.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_xuat_excel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmd_xuat_excel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmd_xuat_excel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmd_xuat_excel.ForeColor = System.Drawing.Color.Maroon;
            this.m_cmd_xuat_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_xuat_excel.ImageIndex = 19;
            this.m_cmd_xuat_excel.ImageList = this.ImageList;
            this.m_cmd_xuat_excel.Location = new System.Drawing.Point(4, 4);
            this.m_cmd_xuat_excel.Name = "m_cmd_xuat_excel";
            this.m_cmd_xuat_excel.Size = new System.Drawing.Size(113, 28);
            this.m_cmd_xuat_excel.TabIndex = 38;
            this.m_cmd_xuat_excel.Text = "Xuất Excel";
            this.m_cmd_xuat_excel.Click += new System.EventHandler(this.m_cmd_xuat_excel_Click_1);
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
            this.m_cmd_exit.Location = new System.Drawing.Point(668, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            this.m_cmd_exit.Click += new System.EventHandler(this.m_cmd_exit_Click);
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_fg.Location = new System.Drawing.Point(0, 134);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(760, 239);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 20;
            // 
            // m_txt_nhan_vien
            // 
            this.m_txt_nhan_vien.Location = new System.Drawing.Point(181, 23);
            this.m_txt_nhan_vien.Name = "m_txt_nhan_vien";
            this.m_txt_nhan_vien.Size = new System.Drawing.Size(377, 20);
            this.m_txt_nhan_vien.TabIndex = 21;
            this.m_txt_nhan_vien.TextChanged += new System.EventHandler(this.m_txt_ma_nhan_vien_TextChanged);
            // 
            // m_lbl_ma_nhan_vien
            // 
            this.m_lbl_ma_nhan_vien.AutoSize = true;
            this.m_lbl_ma_nhan_vien.Location = new System.Drawing.Point(12, 26);
            this.m_lbl_ma_nhan_vien.Name = "m_lbl_ma_nhan_vien";
            this.m_lbl_ma_nhan_vien.Size = new System.Drawing.Size(163, 13);
            this.m_lbl_ma_nhan_vien.TabIndex = 22;
            this.m_lbl_ma_nhan_vien.Text = "Tìm kiếm theo tên/mã nhân viên:";
            this.m_lbl_ma_nhan_vien.Click += new System.EventHandler(this.m_lbl_ma_nhan_vien_Click);
            // 
            // m_lbl_ngay_hieu_luc
            // 
            this.m_lbl_ngay_hieu_luc.AutoSize = true;
            this.m_lbl_ngay_hieu_luc.Location = new System.Drawing.Point(36, 82);
            this.m_lbl_ngay_hieu_luc.Name = "m_lbl_ngay_hieu_luc";
            this.m_lbl_ngay_hieu_luc.Size = new System.Drawing.Size(139, 13);
            this.m_lbl_ngay_hieu_luc.TabIndex = 25;
            this.m_lbl_ngay_hieu_luc.Text = "Ngày hợp đồng có hiệu lực:";
            // 
            // m_lbl_ngay_het_han
            // 
            this.m_lbl_ngay_het_han.AutoSize = true;
            this.m_lbl_ngay_het_han.Location = new System.Drawing.Point(314, 84);
            this.m_lbl_ngay_het_han.Name = "m_lbl_ngay_het_han";
            this.m_lbl_ngay_het_han.Size = new System.Drawing.Size(123, 13);
            this.m_lbl_ngay_het_han.TabIndex = 25;
            this.m_lbl_ngay_het_han.Text = "Ngày hợp đồng hết hạn:";
            // 
            // m_lbl_loai_hop_dong
            // 
            this.m_lbl_loai_hop_dong.AutoSize = true;
            this.m_lbl_loai_hop_dong.Location = new System.Drawing.Point(80, 52);
            this.m_lbl_loai_hop_dong.Name = "m_lbl_loai_hop_dong";
            this.m_lbl_loai_hop_dong.Size = new System.Drawing.Size(79, 13);
            this.m_lbl_loai_hop_dong.TabIndex = 23;
            this.m_lbl_loai_hop_dong.Text = "Loại hợp đồng:";
            this.m_lbl_loai_hop_dong.UseMnemonic = false;
            // 
            // m_cbo_loai_hop_dong
            // 
            this.m_cbo_loai_hop_dong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbo_loai_hop_dong.FormattingEnabled = true;
            this.m_cbo_loai_hop_dong.Location = new System.Drawing.Point(181, 49);
            this.m_cbo_loai_hop_dong.Name = "m_cbo_loai_hop_dong";
            this.m_cbo_loai_hop_dong.Size = new System.Drawing.Size(271, 21);
            this.m_cbo_loai_hop_dong.TabIndex = 34;
            // 
            // m_dat_ngay_bat_dau
            // 
            this.m_dat_ngay_bat_dau.CalendarForeColor = System.Drawing.Color.Maroon;
            this.m_dat_ngay_bat_dau.CalendarTitleForeColor = System.Drawing.Color.Maroon;
            this.m_dat_ngay_bat_dau.CustomFormat = "dd/MM/yyyy";
            this.m_dat_ngay_bat_dau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dat_ngay_bat_dau.Location = new System.Drawing.Point(181, 80);
            this.m_dat_ngay_bat_dau.Name = "m_dat_ngay_bat_dau";
            this.m_dat_ngay_bat_dau.ShowCheckBox = true;
            this.m_dat_ngay_bat_dau.Size = new System.Drawing.Size(113, 20);
            this.m_dat_ngay_bat_dau.TabIndex = 35;
            this.m_dat_ngay_bat_dau.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // m_dat_ngay_ket_thuc
            // 
            this.m_dat_ngay_ket_thuc.CalendarForeColor = System.Drawing.Color.Maroon;
            this.m_dat_ngay_ket_thuc.CalendarTitleForeColor = System.Drawing.Color.Maroon;
            this.m_dat_ngay_ket_thuc.CustomFormat = "dd/MM/yyyy";
            this.m_dat_ngay_ket_thuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dat_ngay_ket_thuc.Location = new System.Drawing.Point(445, 80);
            this.m_dat_ngay_ket_thuc.Name = "m_dat_ngay_ket_thuc";
            this.m_dat_ngay_ket_thuc.ShowCheckBox = true;
            this.m_dat_ngay_ket_thuc.Size = new System.Drawing.Size(113, 20);
            this.m_dat_ngay_ket_thuc.TabIndex = 36;
            // 
            // m_cmd_search
            // 
            this.m_cmd_search.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmd_search.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmd_search.ForeColor = System.Drawing.Color.Maroon;
            this.m_cmd_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search.ImageIndex = 5;
            this.m_cmd_search.ImageList = this.ImageList;
            this.m_cmd_search.Location = new System.Drawing.Point(599, 57);
            this.m_cmd_search.Name = "m_cmd_search";
            this.m_cmd_search.Size = new System.Drawing.Size(99, 28);
            this.m_cmd_search.TabIndex = 38;
            this.m_cmd_search.Text = "Tìm kiếm";
            this.m_cmd_search.Click += new System.EventHandler(this.m_cmd_search_Click);
            // 
            // f300_V_GD_HOP_DONG_LAO_DONG
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.m_cmd_exit;
            this.ClientSize = new System.Drawing.Size(760, 409);
            this.Controls.Add(this.m_cmd_search);
            this.Controls.Add(this.m_dat_ngay_ket_thuc);
            this.Controls.Add(this.m_dat_ngay_bat_dau);
            this.Controls.Add(this.m_cbo_loai_hop_dong);
            this.Controls.Add(this.m_lbl_ngay_het_han);
            this.Controls.Add(this.m_lbl_ngay_hieu_luc);
            this.Controls.Add(this.m_lbl_loai_hop_dong);
            this.Controls.Add(this.m_lbl_ma_nhan_vien);
            this.Controls.Add(this.m_txt_nhan_vien);
            this.Controls.Add(this.m_fg);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Name = "f300_V_GD_HOP_DONG_LAO_DONG";
            this.Text = "f300_V_GD_HOP_DONG_LAO_DONG";
            this.Load += new System.EventHandler(this.f300_V_GD_HOP_DONG_LAO_DONG_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
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
			NGAY_HET_HAN = 7
,MA_NV = 1
,LOAI_HOP_DONG = 5
,HO_DEM = 2
,TEN = 3
,MA_HOP_DONG = 4
,TRANG_THAI_HOP_DONG = 8
,NGAY_CO_HIEU_LUC = 6

		}			
		#endregion

		#region Members
		ITransferDataRow m_obj_trans;		
		DS_V_GD_HOP_DONG_LAO_DONG m_ds = new DS_V_GD_HOP_DONG_LAO_DONG();
		US_V_GD_HOP_DONG_LAO_DONG m_us = new US_V_GD_HOP_DONG_LAO_DONG();
		#endregion

		#region Private Methods
		private void format_controls(){
            CControlFormat.setFormStyle(this, new CAppContext_201());            
			CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
			set_define_events();
			this.KeyPreview = true;		
		}
		private void set_initial_form_load(){						
			m_obj_trans = get_trans_object(m_fg);
			load_data_2_grid();
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_HOP_DONG,
                WinFormControls.eTAT_CA.YES,
                m_cbo_loai_hop_dong);
		}	
		private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg){
			Hashtable v_htb = new Hashtable();
			v_htb.Add(V_GD_HOP_DONG_LAO_DONG.NGAY_HET_HAN, e_col_Number.NGAY_HET_HAN);
			v_htb.Add(V_GD_HOP_DONG_LAO_DONG.MA_NV, e_col_Number.MA_NV);
			v_htb.Add(V_GD_HOP_DONG_LAO_DONG.TRANG_THAI_HOP_DONG, e_col_Number.TRANG_THAI_HOP_DONG);
			v_htb.Add(V_GD_HOP_DONG_LAO_DONG.HO_DEM, e_col_Number.HO_DEM);
			v_htb.Add(V_GD_HOP_DONG_LAO_DONG.TEN, e_col_Number.TEN);
			v_htb.Add(V_GD_HOP_DONG_LAO_DONG.MA_HOP_DONG, e_col_Number.MA_HOP_DONG);
			v_htb.Add(V_GD_HOP_DONG_LAO_DONG.LOAI_HOP_DONG, e_col_Number.LOAI_HOP_DONG);
			v_htb.Add(V_GD_HOP_DONG_LAO_DONG.NGAY_CO_HIEU_LUC, e_col_Number.NGAY_CO_HIEU_LUC);
									
			ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg,v_htb,m_ds.V_GD_HOP_DONG_LAO_DONG.NewRow());
			return v_obj_trans;			
		}
        
		private void load_data_2_grid(){						
			m_ds = new DS_V_GD_HOP_DONG_LAO_DONG();			
			m_us.FillDataset(m_ds);
			m_fg.Redraw = false;
			CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
			m_fg.Redraw = true;
		}
        private void load_data_2_grid_search(){
            m_ds = new DS_V_GD_HOP_DONG_LAO_DONG();
            m_us.FillDataset_search(m_ds,
                m_txt_nhan_vien.Text,
                CIPConvert.ToDecimal(m_cbo_loai_hop_dong.SelectedValue),
                m_dat_ngay_bat_dau.Value,
                m_dat_ngay_ket_thuc.Value);
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            m_fg.Redraw = true;
        }
		private void grid2us_object(US_V_GD_HOP_DONG_LAO_DONG i_us
			, int i_grid_row) {
			DataRow v_dr;
			v_dr = (DataRow) m_fg.Rows[i_grid_row].UserData;
			m_obj_trans.GridRow2DataRow(i_grid_row,v_dr);
			i_us.DataRow2Me(v_dr);
		}

	
		private void us_object2grid(US_V_GD_HOP_DONG_LAO_DONG i_us
			, int i_grid_row) {
			DataRow v_dr = (DataRow) m_fg.Rows[i_grid_row].UserData;
			i_us.Me2DataRow(v_dr);
			m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
		}


		private void insert_v_gd_hop_dong_lao_dong(){			
		//	f300_V_GD_HOP_DONG_LAO_DONG_DE v_fDE = new  f300_V_GD_HOP_DONG_LAO_DONG_DE();								
		//	v_fDE.display();
			load_data_2_grid();
		}

		private void update_v_gd_hop_dong_lao_dong(){			
			if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
			if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;			
			grid2us_object(m_us, m_fg.Row);
		//	f300_V_GD_HOP_DONG_LAO_DONG_DE v_fDE = new f300_V_GD_HOP_DONG_LAO_DONG_DE();
		//	v_fDE.display(m_us);
			load_data_2_grid();
		}
				
		private void delete_v_gd_hop_dong_lao_dong(){
			if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
			if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
			if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted)  return;
			US_V_GD_HOP_DONG_LAO_DONG v_us = new US_V_GD_HOP_DONG_LAO_DONG();
			grid2us_object(v_us, m_fg.Row);
			try {			
				v_us.BeginTransaction();    											
				v_us.Delete();                      								
				v_us.CommitTransaction();
				m_fg.Rows.Remove(m_fg.Row);				
			}
			catch (Exception v_e) {
				v_us.Rollback();
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e,
					new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}

		private void view_v_gd_hop_dong_lao_dong(){			
			if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
			if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
			grid2us_object(m_us, m_fg.Row);
		//	f300_V_GD_HOP_DONG_LAO_DONG_DE v_fDE = new f300_V_GD_HOP_DONG_LAO_DONG_DE();			
		//	v_fDE.display(m_us);
		}
        private void xuat_excel()
        {
            CExcelReport v_obj_excel = new CExcelReport(
                "f300_v_gd_hop_dong_lao_dong.xls"
                , 3
                , 3);

            v_obj_excel.Export2Excel(m_fg
                , 1
                , (int)m_fg.Cols.Count - 1
                , true);
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
		private void f300_V_GD_HOP_DONG_LAO_DONG_Load(object sender, System.EventArgs e) {
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

       

        private void m_txt_ma_nhan_vien_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_lbl_ma_nhan_vien_Click(object sender, EventArgs e)
        {

        }

        private void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            
        }

        private void m_cmd_xuat_excel_Click(object sender, EventArgs e)
        {

        }

        private void m_cmd_search_Click(object sender, EventArgs e)
        {
            try
            {
                load_data_2_grid_search();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_xuat_excel_Click_1(object sender, EventArgs e)
        {
            xuat_excel();
        }


	}
}


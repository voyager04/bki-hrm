using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Checkbox_Combobox;
using IP.Core.IPCommon;
using IP.Core.IPExcelReport;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;
using SIS.Controls.Button;
using System.Data;

using C1.Win.C1FlexGrid;

namespace BKI_HRM {
    public partial class f104_tra_cuu_nhan_su_theo_ma : Form {

        public f104_tra_cuu_nhan_su_theo_ma() {
            InitializeComponent();
            format_controls();
        }

        #region Public Interface
        public void display() {
            ShowDialog();
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
        DS_V_GD_QUA_TRINH_LAM_VIEC_2 m_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC_2();
        US_V_GD_QUA_TRINH_LAM_VIEC_2 m_us = new US_V_GD_QUA_TRINH_LAM_VIEC_2();
        DS_V_DM_DON_VI m_ds_don_vi = new DS_V_DM_DON_VI();
        US_V_DM_DON_VI m_us_don_vi = new US_V_DM_DON_VI();
        //private const String m_str_goi_y_tim_kiem = "Nhập Mã đơn vị, Họ tên, Mã nhân viên...";
        #endregion

        #region Private Methods

        private void format_controls() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            m_fg.Tree.Column = (int)e_col_Number.MA_DON_VI;
            m_fg.Tree.Style = TreeStyleFlags.SimpleLeaf;
            m_txt_phap_nhan.Text = CAppContext_201.getCurrentIDPhapnhan().ToString();
            set_define_events();
            KeyPreview = true;
        }
        private void set_initial_form_load() {
            m_obj_trans = get_trans_object(m_fg);
            m_cmd_search.Visible = true;
            m_cmd_search.Enabled = true;
            load_data_2_grid();
            //set_search_format_before();
            load_custom_source_2_m_txt_search();
            load_custom_source_2_m_txt_don_vi();
        }

        private void load_custom_source_2_m_txt_search() {
            m_txt_search.AutoCompleteMode = AutoCompleteMode.Suggest;
            m_txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var v_coll = new AutoCompleteStringCollection();
            var v_rows = m_ds.Tables[0].Rows;
            
            for (var i = 0; i < v_rows.Count - 1; i++) {
                v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.HO_DEM] + " " + v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN]);
                v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN] + "");
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.MA_DON_VI] + "");
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.MA_NV] + "");
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.MA_DON_VI] + " - " + v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN_DON_VI]);
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN_DON_VI]+" - "+v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.MA_DON_VI]);
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN_CV] + "");
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.LOAI_DON_VI] + "");
            }

            m_txt_search.AutoCompleteCustomSource = v_coll;
        }
        private void load_custom_source_2_m_txt_don_vi()
        {
            m_txt_don_vi.AutoCompleteMode = AutoCompleteMode.Suggest;
            m_txt_don_vi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var v_coll = new AutoCompleteStringCollection();
            m_us_don_vi.FillDataset(m_ds_don_vi, "WHERE ID_PHAP_NHAN =" + CAppContext_201.getCurrentIDPhapnhan().ToString());
            var v_rows = m_ds_don_vi.Tables[0].Rows;
            for (var i = 0; i < v_rows.Count - 1; i++)
            {
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.HO_DEM] + " " + v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN]);
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN] + "");
                v_coll.Add(v_rows[i][V_DM_DON_VI.MA_DON_VI] + "");
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.MA_NV] + "");
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.MA_DON_VI] + " - " + v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN_DON_VI]);
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN_DON_VI]+" - "+v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.MA_DON_VI]);
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN_CV] + "");
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.LOAI_DON_VI] + "");
            }

            m_txt_don_vi.AutoCompleteCustomSource = v_coll;
        }
        private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.EMAIL_CQ, e_col_Number.EMAIL_CQ);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TEN_DON_VI, e_col_Number.TEN_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_KET_THUC, e_col_Number.NGAY_KET_THUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_BAT_DAU, e_col_Number.NGAY_BAT_DAU);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TRANG_THAI_CV, e_col_Number.TRANG_THAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_KIEM_NHIEM, e_col_Number.LOAI_CV);
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

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds.V_GD_QUA_TRINH_LAM_VIEC_2.NewRow());
            return v_obj_trans;
        }
        public void display_for_dm_don_vi(String v_str_ma_dv)
        {
            m_txt_search.Text = v_str_ma_dv;
            this.Show();
        }
        private void load_data_2_grid() {
            decimal v_kiem_nhiem;
            if (m_txt_kiem_nhiem.Text.Trim() == "01")
                v_kiem_nhiem = 650;
            else if (m_txt_kiem_nhiem.Text.Trim() == "02")
                v_kiem_nhiem = 651;
            else v_kiem_nhiem = -1;
            m_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC_2();
            var v_str_search = m_txt_search.Text.Trim();
            /*if (v_str_search.Equals(m_str_goi_y_tim_kiem)) {
                v_str_search = "";
            }*/
            var v_dat_thoi_diem = DateTime.Now;
            if (m_dtp_thoidiem.Checked){
                v_dat_thoi_diem = m_dtp_thoidiem.Value.Date;
            }
            string m_str_ngach_bac = m_txt_ngach.Text.Trim() + m_txt_bac.Text.Trim();
            decimal m_dc_ty_le;
            if(m_txt_ty_le.Text.Trim() == "")
                m_dc_ty_le = -1;
            else
                m_dc_ty_le = System.Convert.ToDecimal(m_txt_ty_le.Text.Trim().ToString());
            m_us.FillDatase_NhanSu_TheoMa(m_ds, v_str_search, v_dat_thoi_diem,CAppContext_201.getCurrentIDPhapnhan(),v_kiem_nhiem,m_str_ngach_bac,m_txt_don_vi.Text.Trim(),m_txt_trang_thai_ld.Text.Trim(),m_dc_ty_le);
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            /**
             * Group (subtotal) trên grid.
             */
            //m_fg.Subtotal(AggregateEnum.Count, -1, 0, (int)e_col_Number.MA_NV, "Tổng");
            if (m_rdb_nhom.Checked == true)
            {
                m_fg.Subtotal(AggregateEnum.Count
                  , 0
                  , (int)e_col_Number.MA_DON_VI    // Group theo cột này
                  , (int)e_col_Number.MA_NV         // Subtotal theo cột này
                  , "{0}"
                  );
                m_fg.Subtotal(AggregateEnum.Count
                  , 1
                  , (int)e_col_Number.TRANG_THAI_LD_HIEN_TAI    // Group theo cột này
                  , (int)e_col_Number.MA_NV         // Subtotal theo cột này
                  , "{0}"
                  );
            }
            m_fg.Redraw = true;
            /**
             * Đếm số dòng dữ liệu trên Grid
             */
          //  m_lbl_so_luong_ban_ghi.Text = m_ds.V_GD_QUA_TRINH_LAM_VIEC_2.Count.ToString();

            decimal count = 0;
            m_us.count_NhanSu_TheoMa(m_ds, ref count, v_str_search, v_dat_thoi_diem, CAppContext_201.getCurrentIDPhapnhan(), v_kiem_nhiem, m_str_ngach_bac, m_txt_don_vi.Text.Trim(), m_txt_trang_thai_ld.Text.Trim(), m_dc_ty_le);
            m_lbl_so_luong_ban_ghi.Text = CIPConvert.ToStr(count);
           // m_lbl_thong_bao.Text = m_fg.ColumnInfo;
        }
        /*private void set_search_format_before() {
            if (m_txt_search.Text == "") {
                m_txt_search.Text = m_str_goi_y_tim_kiem;
                m_txt_search.ForeColor = Color.Gray;
            }
        }*/
        /*private void set_search_format_after() {
            if (m_txt_search.Text == m_str_goi_y_tim_kiem) {
                m_txt_search.Text = "";
            }
            m_txt_search.ForeColor = Color.Black;
        }*/

        private void xuat_excel(){
            var v_start_row = 8;
            var v_start_col = 1;
            var v_obj_excel_rpt = new CExcelReport("f104_bao_cao_nhan_su_theo_phong_ban.xlsx", v_start_row, v_start_col);
            v_obj_excel_rpt.AddFindAndReplaceItem("<ngay_thang>", string.Format("{0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
            v_obj_excel_rpt.FindAndReplace(false);
            v_obj_excel_rpt.Export2ExcelWithoutFixedRows(m_fg, 1, m_fg.Cols.Count - 1, true);
        }
        
        #endregion

        //
        //
        //		EVENT HANLDERS
        //
        //

        private void set_define_events() {
            m_cmd_exit.Click += m_cmd_exit_Click;
            m_cmd_search.Click += m_cmd_search_Click;
            m_txt_search.KeyDown += m_txt_search_KeyDown;
            m_txt_search.MouseClick += m_txt_search_MouseClick;
            m_txt_search.Leave += m_txt_search_Leave;
            m_cmd_xuat_excel.Click += m_cmd_xuat_excel_Click;
        }

        private void f104_bao_cao_nhan_su_theo_phong_ban_Load(object sender, EventArgs e) {
            try {
                set_initial_form_load();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        private void m_cmd_exit_Click(object sender, EventArgs e) {
            try {
                close_tab_B(true);

            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_search_Click(object sender, EventArgs e)
        {
            try
            {
                load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        
        private void m_txt_search_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyData == Keys.Enter) {
                    load_data_2_grid();
                } else {
                    //set_search_format_after();
                }
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_search_MouseClick(object sender, MouseEventArgs e) {
            try {
                //set_search_format_after();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_search_Leave(object sender, EventArgs e) {
            try {
                //set_search_format_before();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_xuat_excel_Click(object sender, EventArgs e) {
            try{
                xuat_excel();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_dtp_thoidiem_ValueChanged(object sender, EventArgs e)
        {
            try
            {
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
                load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_ckb_kiem_nhiem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

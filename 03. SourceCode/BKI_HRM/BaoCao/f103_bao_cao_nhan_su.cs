using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
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

namespace BKI_HRM.BaoCao {
    public partial class f103_bao_cao_nhan_su : Form {
        public f103_bao_cao_nhan_su() {
            InitializeComponent();
        }

        #region Public Interface
        public void display() {
            this.ShowDialog();
        }
        #endregion

        #region Data Structure
        private enum e_col_Number {
            ID_VI_TRI = 21
,
            NGAY_HET_HAN = 29
                ,
            TEN_DON_VI = 15
                ,
            ID_DON_VI_CAP_TREN = 16
                ,
            MA_DU_AN = 24
                ,
            MA_HOP_DONG = 26
                ,
            NGAY_SINH = 5
                ,
            TRANG_THAI_LAO_DONG = 19
                ,
            TEN_CV = 9
                ,
            LOAI_HOP_DONG = 28
                ,
            TEN = 3
                ,
            ID_LOAI_DON_VI = 17
                ,
            THOI_DIEM_TG = 23
                ,
            TRANG_THAI_HIEN_TAI = 20
                ,
            MA_DON_VI = 14
                ,
            VI_TRI_DU_AN = 22
                ,
            ID_CHUC_VU = 7
                ,
            HO_DEM = 2
                ,
            TY_LE_THAM_GIA = 12
                ,
            TRANG_THAI_HOP_DONG = 30
                ,
            ID_TRANG_THAI_CV = 10
                ,
            MA_NV = 1
                ,
            TEN_DU_AN = 25
                ,
            ID_DON_VI = 13
                ,
            ID_LOAI_HOP_DONG = 27
                ,
            ID_TRANG_LAO_DONG = 18
                ,
            MA_CV = 8
                ,
            TRINH_DO = 6
                ,
            TRANG_THAI_CV = 11
                , GIOI_TINH = 4

        }
        #endregion

        #region Members
        ITransferDataRow m_obj_trans;
        DS_V_DM_DU_LIEU_NHAN_VIEN m_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
        US_V_DM_DU_LIEU_NHAN_VIEN m_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
        #endregion

        #region Private Methods
        private void format_controls() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            set_define_events();
            this.KeyPreview = true;
        }
        private void set_initial_form_load() {
            format_controls();
            m_obj_trans = get_trans_object(m_fg);
            load_data_2_grid();
            m_cbo_gioi_tinh.SelectedIndex = 0;
        }
        private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg) {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.ID_VI_TRI, e_col_Number.ID_VI_TRI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.NGAY_HET_HAN, e_col_Number.NGAY_HET_HAN);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TEN_DON_VI, e_col_Number.TEN_DON_VI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.ID_DON_VI_CAP_TREN, e_col_Number.ID_DON_VI_CAP_TREN);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.MA_DU_AN, e_col_Number.MA_DU_AN);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.MA_HOP_DONG, e_col_Number.MA_HOP_DONG);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.NGAY_SINH, e_col_Number.NGAY_SINH);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TRANG_THAI_LAO_DONG, e_col_Number.TRANG_THAI_LAO_DONG);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TEN_CV, e_col_Number.TEN_CV);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.LOAI_HOP_DONG, e_col_Number.LOAI_HOP_DONG);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TEN, e_col_Number.TEN);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.ID_LOAI_DON_VI, e_col_Number.ID_LOAI_DON_VI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.THOI_DIEM_TG, e_col_Number.THOI_DIEM_TG);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TRANG_THAI_HIEN_TAI, e_col_Number.TRANG_THAI_HIEN_TAI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.MA_DON_VI, e_col_Number.MA_DON_VI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.VI_TRI_DU_AN, e_col_Number.VI_TRI_DU_AN);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.ID_CHUC_VU, e_col_Number.ID_CHUC_VU);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.HO_DEM, e_col_Number.HO_DEM);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TY_LE_THAM_GIA, e_col_Number.TY_LE_THAM_GIA);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TRANG_THAI_HOP_DONG, e_col_Number.TRANG_THAI_HOP_DONG);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.ID_TRANG_THAI_CV, e_col_Number.ID_TRANG_THAI_CV);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TEN_DU_AN, e_col_Number.TEN_DU_AN);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.ID_DON_VI, e_col_Number.ID_DON_VI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.ID_LOAI_HOP_DONG, e_col_Number.ID_LOAI_HOP_DONG);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.ID_TRANG_LAO_DONG, e_col_Number.ID_TRANG_LAO_DONG);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.MA_CV, e_col_Number.MA_CV);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TRINH_DO, e_col_Number.TRINH_DO);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TRANG_THAI_CV, e_col_Number.TRANG_THAI_CV);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.GIOI_TINH, e_col_Number.GIOI_TINH);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds.V_DM_DU_LIEU_NHAN_VIEN.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid() {
            m_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            m_us.FillDataset(m_ds);
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            m_fg.Redraw = true;
            set_search_textbox_style();
            m_lbl_so_nhan_vien.Text = lay_so_ban_ghi().ToString();
        }

        private int lay_so_ban_ghi(){
            return m_ds.V_DM_DU_LIEU_NHAN_VIEN.Count;
        }
        private void set_search_textbox_style() {
            if (m_txt_tim_kiem.Text.Trim().Equals(String.Empty)) {
                m_txt_tim_kiem.Select(); //Đưa chuột vào ô tìm kiếm
            } else {
                m_txt_tim_kiem.SelectAll(); //Chọn tất cả dữ liệu trong ô tìm kiếm
            }
        }
        private void grid2us_object(US_V_DM_DU_LIEU_NHAN_VIEN i_us, int i_grid_row) {
            DataRow v_dr;
            v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            m_obj_trans.GridRow2DataRow(i_grid_row, v_dr);
            i_us.DataRow2Me(v_dr);
        }
        private void us_object2grid(US_V_DM_DU_LIEU_NHAN_VIEN i_us, int i_grid_row) {
        }
        private void load_custom_source_2_m_txt_tim_kiem() {
            int count = m_ds.Tables["V_DM_DU_LIEU_NHAN_VIEN"].Rows.Count;
            for (int i = 0; i < 20; i++) {
                DataRow dr = m_ds.Tables["V_DM_DU_LIEU_NHAN_VIEN"].Rows[i];
                m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr[1].ToString());
                m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr[2].ToString());
            }
        }
        private void tim_kiem() {
            if (m_cbo_gioi_tinh.SelectedIndex!=0){
                tim_kiem_theo_gioi_tinh();
            }
            else{
                tim_kiem_dung_tu_khoa();
            }
        }

        private void tim_kiem_dung_tu_khoa(){
            m_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            var v_str_search = m_txt_tim_kiem.Text.Trim();
            var v_str_month = Regex.Match(v_str_search, @"\d+").Value;
            if (!v_str_month.Equals("")) {
                v_str_search = v_str_month;
            }
            m_us.FillDatasetByKeyWord(v_str_search, m_ds);
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            m_fg.Redraw = true;
            set_search_textbox_style();
            m_lbl_so_nhan_vien.Text = lay_so_ban_ghi().ToString();
        }

        private void tim_kiem_theo_gioi_tinh() {
            m_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            var v_str_search = m_txt_tim_kiem.Text.Trim();
            var v_str_month = Regex.Match(v_str_search, @"\d+").Value;
            if (!v_str_month.Equals("")) {
                v_str_search = v_str_month;
            }
            m_us.FillDatasetConvention(v_str_search, get_gender(), m_ds);
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            m_fg.Redraw = true;
            set_search_textbox_style();
            m_lbl_so_nhan_vien.Text = lay_so_ban_ghi().ToString();
        }

        private string get_gender() {
            if (m_cbo_gioi_tinh.SelectedIndex == 1) {
                return "Nam";
            } else if (m_cbo_gioi_tinh.SelectedIndex == 2) {
                return "Nữ";
            }
            return "";
        }

        #endregion

        //
        //
        //		EVENT HANLDERS
        //
        //

        private void set_define_events() {
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_cmd_search.Click += new EventHandler(m_cmd_search_Click);
            m_txt_tim_kiem.KeyDown += new KeyEventHandler(m_txt_tim_kiem_KeyDown);
        }

        private void f103_bao_cao_nhan_su_Load(object sender, System.EventArgs e) {
            try {
                set_initial_form_load();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        private void m_cmd_exit_Click(object sender, EventArgs e) {
            try {
                this.Close();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_search_Click(object sender, EventArgs e) {
            try {
                tim_kiem();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_tim_kiem_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyData == Keys.Enter)
                    tim_kiem();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

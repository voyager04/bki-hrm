using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BKI_HRM.DanhMuc;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;

namespace BKI_HRM {
    public partial class f104_bao_cao_nhan_su_theo_phong_ban : Form {

        public f104_bao_cao_nhan_su_theo_phong_ban() {
            InitializeComponent();
            format_controls();
        }

        #region Public Interface
        public void display() {
            this.ShowDialog();
        }
        #endregion

        #region Data Structure
        private enum e_col_Number_Don_Vi {
            TEN_TIENG_ANH = 6
                ,
            MA_TRUNG_TAM = 2
                ,
            TRANG_THAI = 9
                ,
            MA_PHONG = 3
                ,
            TEN_PHONG = 4
                ,
            LOAI_DON_VI = 5
                ,
            TU_NGAY = 7
                ,
            MA_KHOI = 1

            , DIA_BAN = 8

        }

        private enum e_col_Number_Nhan_Su {
            LOAI_DON_VI = 13
                ,
            TEN_DON_VI = 12
                ,
            MA_NV = 1
                ,
            CAP_DON_VI = 14
                ,
            TRANG_THAI_LAO_DONG = 16
                ,
            DIA_BAN = 15
                ,
            TEN = 3
                ,
            NGAY_CO_HIEU_LUC = 17
                ,
            TRANG_THAI_HIEN_TAI = 19
                ,
            MA_DON_VI = 11
                ,
            HO_DEM = 2
                ,
            TY_LE_THAM_GIA = 10
                ,
            TEN_CV = 8
                ,
            NGAY_HET_HIEU_LUC = 18
                ,
            NGAY_SINH = 5
                ,
            TRINH_DO = 6
                ,
            TRANG_THAI_CV = 9
                ,
            GIOI_TINH = 4
                ,
            MA_CV = 7

        }
        #endregion

        #region Members
        ITransferDataRow m_obj_trans_don_vi;
        ITransferDataRow m_obj_trans_nhan_su;
        DS_V_DM_DON_VI m_ds_don_vi = new DS_V_DM_DON_VI();
        US_V_DM_DON_VI m_us_don_vi = new US_V_DM_DON_VI();
        DS_V_DM_DU_LIEU_NHAN_VIEN m_ds_nhan_su = new DS_V_DM_DU_LIEU_NHAN_VIEN();
        US_V_DM_DU_LIEU_NHAN_VIEN m_us_nhan_su = new US_V_DM_DU_LIEU_NHAN_VIEN();
        int m_dc_index_row;
        #endregion

        #region Private Methods

        private void format_controls() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg_don_vi);
            CGridUtils.AddSave_Excel_Handlers(m_fg_don_vi);
            CGridUtils.AddSearch_Handlers(m_fg_don_vi);
            m_fg_don_vi.Tree.Column = (int)e_col_Number_Don_Vi.MA_PHONG;
            m_fg_don_vi.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf;
            set_define_events();
            this.KeyPreview = true;
        }
        private void set_initial_form_load() {
            m_obj_trans_don_vi = get_trans_object_don_vi(m_fg_don_vi);
            m_obj_trans_nhan_su = get_trans_object_nhan_su(m_fg_nhan_su);
            load_data_2_grid_don_vi();
        }
        private ITransferDataRow get_trans_object_don_vi(C1.Win.C1FlexGrid.C1FlexGrid i_fg_don_vi) {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_DM_DON_VI.TEN_TIENG_ANH, e_col_Number_Don_Vi.TEN_TIENG_ANH);
            v_htb.Add(V_DM_DON_VI.MA_TRUNG_TAM, e_col_Number_Don_Vi.MA_TRUNG_TAM);
            v_htb.Add(V_DM_DON_VI.TRANG_THAI, e_col_Number_Don_Vi.TRANG_THAI);
            v_htb.Add(V_DM_DON_VI.MA_PHONG, e_col_Number_Don_Vi.MA_PHONG);
            v_htb.Add(V_DM_DON_VI.TEN_PHONG, e_col_Number_Don_Vi.TEN_PHONG);
            v_htb.Add(V_DM_DON_VI.LOAI_DON_VI, e_col_Number_Don_Vi.LOAI_DON_VI);
            v_htb.Add(V_DM_DON_VI.TU_NGAY, e_col_Number_Don_Vi.TU_NGAY);
            v_htb.Add(V_DM_DON_VI.MA_KHOI, e_col_Number_Don_Vi.MA_KHOI);
            v_htb.Add(V_DM_DON_VI.DIA_BAN, e_col_Number_Don_Vi.DIA_BAN);
            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg_don_vi, v_htb, m_ds_don_vi.V_DM_DON_VI.NewRow());
            return v_obj_trans;
        }
        private ITransferDataRow get_trans_object_nhan_su(C1.Win.C1FlexGrid.C1FlexGrid i_fg_nhan_su) {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.LOAI_DON_VI, e_col_Number_Nhan_Su.LOAI_DON_VI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TEN_DON_VI, e_col_Number_Nhan_Su.TEN_DON_VI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.MA_NV, e_col_Number_Nhan_Su.MA_NV);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.CAP_DON_VI, e_col_Number_Nhan_Su.CAP_DON_VI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TRANG_THAI_LAO_DONG, e_col_Number_Nhan_Su.TRANG_THAI_LAO_DONG);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.DIA_BAN, e_col_Number_Nhan_Su.DIA_BAN);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TEN, e_col_Number_Nhan_Su.TEN);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.NGAY_CO_HIEU_LUC, e_col_Number_Nhan_Su.NGAY_CO_HIEU_LUC);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TRANG_THAI_HIEN_TAI, e_col_Number_Nhan_Su.TRANG_THAI_HIEN_TAI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.MA_DON_VI, e_col_Number_Nhan_Su.MA_DON_VI);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.HO_DEM, e_col_Number_Nhan_Su.HO_DEM);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TY_LE_THAM_GIA, e_col_Number_Nhan_Su.TY_LE_THAM_GIA);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TEN_CV, e_col_Number_Nhan_Su.TEN_CV);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.NGAY_HET_HIEU_LUC, e_col_Number_Nhan_Su.NGAY_HET_HIEU_LUC);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.NGAY_SINH, e_col_Number_Nhan_Su.NGAY_SINH);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TRINH_DO, e_col_Number_Nhan_Su.TRINH_DO);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.TRANG_THAI_CV, e_col_Number_Nhan_Su.TRANG_THAI_CV);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.GIOI_TINH, e_col_Number_Nhan_Su.GIOI_TINH);
            v_htb.Add(V_DM_DU_LIEU_NHAN_VIEN.MA_CV, e_col_Number_Nhan_Su.MA_CV);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg_nhan_su, v_htb, m_ds_nhan_su.V_DM_DU_LIEU_NHAN_VIEN.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid_don_vi() {
            m_ds_don_vi = new DS_V_DM_DON_VI();
            if (m_dat_tu_ngay.Checked) {
                m_us_don_vi.FillDatasetByKeyWord_DateTime(m_txt_tim_kiem.Text.Trim(), m_dat_tu_ngay.Value.Date, m_ds_don_vi);
            } else {
                m_us_don_vi.FillDatasetByKeyWord(m_txt_tim_kiem.Text.Trim(), m_ds_don_vi);
            }

            m_fg_don_vi.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds_don_vi, m_fg_don_vi, m_obj_trans_don_vi);
            m_fg_don_vi.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count
              , 0
              , (int)e_col_Number_Don_Vi.MA_KHOI
              , (int)e_col_Number_Don_Vi.TEN_PHONG
              , "{0}"
              );
            m_fg_don_vi.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count
                , 1
                , (int)e_col_Number_Don_Vi.MA_TRUNG_TAM
                , (int)e_col_Number_Don_Vi.TEN_PHONG
                , "{0}"
                );

            m_fg_don_vi.Redraw = true;
            set_search_textbox_style();
            m_lbl_so_ban_ghi_don_vi.Text = m_ds_don_vi.V_DM_DON_VI.Count.ToString();
        }
        private void load_data_2_grid_dm_nhan_su(int ip_int_row_index_choose) {
            m_ds_nhan_su = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            /*Xử lý tìm kiếm*/
            var v_str_search = m_txt_tim_kiem.Text.Trim();
            var v_str_month = Regex.Match(v_str_search, @"\d+").Value;
            if (!v_str_month.Equals("")) {
                v_str_search = v_str_month;
            }
            var v_id_don_vi = get_id_don_vi(ip_int_row_index_choose);
            var v_str_gender = get_gender();
            var v_str_trang_thai_lao_dong = get_trang_thai_lao_dong();
            m_us_nhan_su.FillDataset_By_ID_Don_Vi(m_ds_nhan_su, v_id_don_vi, v_str_search, v_str_gender, v_str_trang_thai_lao_dong);
            m_fg_nhan_su.Redraw = false;
            ITransferDataRow v_obj_trans_nhan_su = get_trans_object_nhan_su(m_fg_nhan_su);
            CGridUtils.Dataset2C1Grid(m_ds_nhan_su, m_fg_nhan_su, v_obj_trans_nhan_su);
            m_fg_nhan_su.Redraw = true;
            set_search_textbox_style();
            m_lbl_so_ban_ghi_nhan_su.Text = lay_so_ban_ghi();
        }
        private void grid2us_object(US_V_DM_DON_VI i_us, int i_grid_row){
            var v_user_data = m_fg_don_vi.Rows[i_grid_row].UserData;
            DataRow v_dr = null;
            if (v_user_data!=null) {
                v_dr = (DataRow)v_user_data;
                m_obj_trans_don_vi.GridRow2DataRow(i_grid_row, v_dr);
                i_us.DataRow2Me(v_dr); 
            }
        }
        private decimal get_id_don_vi(int ip_dc_row_index_choose) {
            //Truyền dữ liệu của dòng chọn vào us
            grid2us_object(m_us_don_vi, ip_dc_row_index_choose);
            return m_us_don_vi.dcID;
        }
        private string lay_so_ban_ghi() {
            return m_ds_nhan_su.V_DM_DU_LIEU_NHAN_VIEN.Count.ToString();
        }
        private string get_gender() {
            if (m_cbo_gioi_tinh.SelectedIndex == 1) {
                return "Nam";
            } else if (m_cbo_gioi_tinh.SelectedIndex == 2) {
                return "Nữ";
            }
            return "";
        }
        private string get_trang_thai_lao_dong() {
            if (m_cbo_trang_thai.SelectedIndex != 0) {
                return m_cbo_trang_thai.Text;
            }
            return "";
        }
        private void set_search_textbox_style() {
            if (m_txt_tim_kiem.Text.Trim().Equals(String.Empty)) {
                m_txt_tim_kiem.Select(); //Đưa chuột vào ô tìm kiếm
            } else {
                m_txt_tim_kiem.SelectAll(); //Chọn tất cả dữ liệu trong ô tìm kiếm
            }
        }

        #endregion

        //
        //
        //		EVENT HANLDERS
        //
        //

        private void set_define_events() {
            m_fg_don_vi.Click += new System.EventHandler(m_fg_don_vi_Click);
        }

        private void f104_bao_cao_nhan_su_theo_phong_ban_Load(object sender, EventArgs e) {
            try {
                set_initial_form_load();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_fg_don_vi_Click(object sender, EventArgs e) {
            try {
                m_dc_index_row = m_fg_don_vi.Row;
                load_data_2_grid_dm_nhan_su(m_dc_index_row);
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

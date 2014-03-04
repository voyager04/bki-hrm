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
        ITransferDataRow m_obj_trans_nhan_su;
        DS_V_DM_DU_LIEU_NHAN_VIEN m_ds_nhan_su = new DS_V_DM_DU_LIEU_NHAN_VIEN();
        US_V_DM_DU_LIEU_NHAN_VIEN m_us_nhan_su = new US_V_DM_DU_LIEU_NHAN_VIEN();
        int m_dc_index_row;
        #endregion

        #region Private Methods

        private void format_controls() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            set_define_events();
            this.KeyPreview = true;
        }
        private void set_initial_form_load() {
            m_obj_trans_nhan_su = get_trans_object_nhan_su(m_fg_nhan_su);
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
   
        private void load_data_2_grid_dm_nhan_su(int ip_int_row_index_choose) {
            m_ds_nhan_su = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            /*Xử lý tìm kiếm*/
            var v_str_search = m_txt_tim_kiem.Text.Trim();
            var v_str_month = Regex.Match(v_str_search, @"\d+").Value;
            if (!v_str_month.Equals("")) {
                v_str_search = v_str_month;
            }
            decimal v_id_don_vi = 0;
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
        }

        private void f104_bao_cao_nhan_su_theo_phong_ban_Load(object sender, EventArgs e) {
            try {
                set_initial_form_load();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

    }
}

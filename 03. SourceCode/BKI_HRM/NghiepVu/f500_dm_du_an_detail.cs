using BKI_HRM.DS;
//using BKI_HRM.US;
//using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using C1.Win.C1FlexGrid;
using IP.Core.IPCommon;
using IP.Core.IPSystemAdmin;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using DS_CM_DM_TU_DIEN = IP.Core.IPData.DS_CM_DM_TU_DIEN;
using US_CM_DM_TU_DIEN = IP.Core.IPUserService.US_CM_DM_TU_DIEN;

namespace BKI_HRM.NghiepVu
{
    public partial class f500_dm_du_an_detail : Form
    {

        public f500_dm_du_an_detail()
        {
            InitializeComponent();
            format_control();
        }

        #region Public Interface
        public void display()
        {
            this.ShowDialog();
        }

        public void set_us_du_an(US_V_DM_DU_AN_QUYET_DINH_TU_DIEN ip_us)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_us = ip_us;
            us_2_form_du_an(ip_us);
            m_str_ma_du_an_old = ip_us.strMA_DU_AN;
        }

        public string lay_ma_du_an_vua_insert()
        {
            return m_str_ma_du_an;
        }
        #endregion

        #region Data Structure
        private enum e_col_Number_nhan_vien
        {
            THOI_GIAN_TG = 8
,
            TRANG_THAI_LAO_DONG = 5
                ,
            MA_NV = 1
                ,
            THOI_DIEM_KT = 7
                ,
            MO_TA = 11
                ,
            VI_TRI = 4
                ,
            TEN = 3
                ,
            THOI_DIEM_TG = 6
                ,
            HO_DEM = 2
                ,
            MA_QUYET_DINH = 10
                , DANH_HIEU = 9
        }

        private enum e_col_Number_quyet_dinh
        {
            MA_QUYET_DINH = 1,
            LOAI_QUYET_DINH = 2,
            NGAY_KY = 3,
            NGAY_CO_HIEU_LUC = 4,
            NGAY_HET_HAN = 5,
            LINK = 6,
            NOI_DUNG = 7,
        }

        private enum e_number
        {
            ID_NHAN_SU = 3,
            ID_QUYET_DINH = 0,
        }

        private int ID_LOAI_TU_DIEN_QUYET_DINH = 3;
        private int ID_QUYET_DINH_THANH_LAP_DU_AN = 679;
        private int ID_QUYET_DINH_BO_SUNG_DU_AN = 745;
        #endregion

        #region Member
        private string m_str_ma_du_an_old;

        ITransferDataRow m_obj_trans_nhan_vien;
        ITransferDataRow m_obj_trans_quyet_dinh;
        DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;
        private string m_str_ma_du_an = "";

        US_V_DM_DU_AN_QUYET_DINH_TU_DIEN m_us = new US_V_DM_DU_AN_QUYET_DINH_TU_DIEN();

        private DataEntryFileMode m_e_file_mode;
        private string m_str_domain = ConfigurationSettings.AppSettings["DOMAIN"];
        private string m_str_directory_to = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private string m_str_user_name = ConfigurationSettings.AppSettings["USERNAME_SHARE"];
        private string m_str_password = ConfigurationSettings.AppSettings["PASSWORD_SHARE"];
        private string m_str_link_old;
        #endregion

        #region Private Method
        private void format_control()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());

            CControlFormat.setC1FlexFormat(m_fg_quyet_dinh);
            CGridUtils.AddSearch_Handlers(m_fg_quyet_dinh);
            CGridUtils.ClearDataInGrid(m_fg_quyet_dinh);
            m_fg_quyet_dinh.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
            m_fg_quyet_dinh.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            m_fg_quyet_dinh.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            m_fg_quyet_dinh.AllowEditing = true;

            CControlFormat.setC1FlexFormat(m_fg_nhan_vien);
            CGridUtils.AddSearch_Handlers(m_fg_nhan_vien);
            CGridUtils.ClearDataInGrid(m_fg_nhan_vien);
            m_fg_nhan_vien.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
            m_fg_nhan_vien.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            m_fg_nhan_vien.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            m_fg_nhan_vien.AllowEditing = true;


            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_DU_AN, WinFormControls.eTAT_CA.NO, m_cbo_loai_du_an);
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DU_AN, WinFormControls.eTAT_CA.NO, m_cbo_trang_thai);
            load_data_to_cbo_co_che(WinFormControls.eLOAI_TU_DIEN.CO_CHE, WinFormControls.eTAT_CA.YES, m_cbo_co_che);

            load_cbo_to_column_of_grid(e_loai_tu_dien.VI_TRI_DU_AN, m_fg_nhan_vien, (int)e_col_Number_nhan_vien.VI_TRI);
            load_cbo_to_column_of_grid(e_loai_tu_dien.DANH_HIEU, m_fg_nhan_vien, (int)e_col_Number_nhan_vien.DANH_HIEU);
            load_cbo_to_column_of_grid(e_loai_tu_dien.LOAI_QUYET_DINH, m_fg_quyet_dinh, (int)e_col_Number_quyet_dinh.LOAI_QUYET_DINH);
            auto_suggest_text();

            m_lbl_chuc_vu.Text = "";
            m_lbl_don_vi.Text = "";
            m_lbl_email_ca_nhan.Text = "";

            this.KeyPreview = true;
            set_define_events();
        }

        private void set_initial_form_load()
        {
            m_obj_trans_nhan_vien = get_trans_object_nhan_vien(m_fg_nhan_vien);
            m_obj_trans_quyet_dinh = get_trans_object_quyet_dinh(m_fg_quyet_dinh);
            us_quyet_dinh_to_grid(m_us);
            us_nhan_vien_to_grid(m_us);

            m_fg_quyet_dinh.Redraw = false;
            for (int i = m_fg_quyet_dinh.Rows.Fixed; i < m_fg_quyet_dinh.Rows.Count; i++)
            {
                // Set up color column. 
                Column column = m_fg_quyet_dinh.Cols[(int)e_col_Number_quyet_dinh.LINK];
                column.DataType = typeof(String);

                // Show cell button. 
                column.ComboList = "...";
            }
            m_fg_quyet_dinh.Redraw = true;

            m_txt_ma_du_an.Focus();
            m_fg_nhan_vien.Cols[(int) e_col_Number_nhan_vien.HO_DEM].AllowEditing = false;
            m_fg_nhan_vien.Cols[(int)e_col_Number_nhan_vien.TEN].AllowEditing = false;
            m_fg_nhan_vien.Cols[(int)e_col_Number_nhan_vien.TRANG_THAI_LAO_DONG].AllowEditing = false;
        }

        private void load_data_to_cbo_co_che(
              WinFormControls.eLOAI_TU_DIEN ip_e
            , WinFormControls.eTAT_CA ip_e_tat_ca
            , ComboBox ip_obj_cbo_trang_thai)
        {

            IP.Core.IPUserService.US_CM_DM_TU_DIEN v_us_dm_tu_dien = new IP.Core.IPUserService.US_CM_DM_TU_DIEN();
            IP.Core.IPData.DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new IP.Core.IPData.DS_CM_DM_TU_DIEN();
            string v_str_loai_tu_dien = "";
            switch (ip_e)
            {
                case WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_CHUC_VU:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_CHUC_VU;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.LOAI_HOP_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_HOP_DONG;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.LOAI_DON_VI:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_DON_VI;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.CAP_DON_VI:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.CAP_DON_VI;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_QUYET_DINH;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_LAO_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_LAO_DONG;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.NGACH:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.NGACH;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.LOAI_CHUC_VU:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_CHUC_VU;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_HOP_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_HOP_DONG;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DU_AN:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_DU_AN;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.MA_HOP_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.MA_HOP_DONG;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.DANH_HIEU:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.DANH_HIEU;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.CO_CHE:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.CO_CHE;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.LOAI_DU_AN:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_DU_AN;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.MA_QUYET_DINH:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.MA_QUYET_DINH;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.DIA_BAN:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.DIA_BAN;
                    break;
            }
            v_us_dm_tu_dien.fill_tu_dien_cung_loai_ds(
                v_str_loai_tu_dien
                , CM_DM_TU_DIEN.GHI_CHU
                , v_ds_dm_tu_dien);


            ip_obj_cbo_trang_thai.DisplayMember = CM_DM_TU_DIEN.TEN;
            ip_obj_cbo_trang_thai.ValueMember = CM_DM_TU_DIEN.ID;
            ip_obj_cbo_trang_thai.DataSource = v_ds_dm_tu_dien.CM_DM_TU_DIEN;
            if (ip_e_tat_ca == WinFormControls.eTAT_CA.YES)
            {
                DataRow v_dr = v_ds_dm_tu_dien.CM_DM_TU_DIEN.NewRow();
                v_dr[CM_DM_TU_DIEN.ID] = -1;
                v_dr[CM_DM_TU_DIEN.TEN] = "------ Không có ------";
                v_dr[CM_DM_TU_DIEN.MA_TU_DIEN] = "";
                v_dr[CM_DM_TU_DIEN.TEN_NGAN] = "";
                v_dr[CM_DM_TU_DIEN.ID_LOAI_TU_DIEN] = 1;
                v_dr[CM_DM_TU_DIEN.GHI_CHU] = "";
                v_ds_dm_tu_dien.CM_DM_TU_DIEN.Rows.InsertAt(v_dr, 0);
                ip_obj_cbo_trang_thai.SelectedIndex = 0;
            }
        }

        private void auto_suggest_text()
        {
            m_txt_search_nhan_vien.AutoCompleteMode = AutoCompleteMode.Suggest;
            m_txt_search_nhan_vien.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            v_us_dm_nhan_su.FillDataset_search(v_ds_dm_nhan_su, m_txt_search_nhan_vien.Text);
            var v_rows = v_ds_dm_nhan_su.Tables[0].Rows;
            for (int i = 0; i < v_rows.Count - 1; i++)
            {
                coll.Add(v_rows[i][DM_NHAN_SU.HO_DEM] + " " + v_rows[i][DM_NHAN_SU.TEN] + " - " + v_rows[i][DM_NHAN_SU.MA_NV]);
                coll.Add(v_rows[i][DM_NHAN_SU.TEN] + " " + v_rows[i][DM_NHAN_SU.HO_DEM] + " " + v_rows[i][DM_NHAN_SU.TEN] + " - " + v_rows[i][DM_NHAN_SU.MA_NV]);
                coll.Add(v_rows[i][DM_NHAN_SU.MA_NV] + " " + v_rows[i][DM_NHAN_SU.HO_DEM] + " " + v_rows[i][DM_NHAN_SU.TEN] + " - " + v_rows[i][DM_NHAN_SU.MA_NV]);
            }
            m_txt_search_nhan_vien.AutoCompleteCustomSource = coll;
        }

        private void select_nhan_vien()
        {
            string[] v_strs = m_txt_search_nhan_vien.Text.Split('-');
            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
            v_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds_dm_nhan_su, v_strs[v_strs.Length - 1].Trim());
            if (v_ds_dm_nhan_su.Tables[0].Rows.Count == 0)
                return;
            m_lbl_ma_nhan_vien.Text = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.MA_NV].ToString();
            m_lbl_ho_va_ten.Text = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.HO_DEM] + " " +
                                   v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.TEN];
            //m_lbl_ngay_sinh.Text = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.NGAY_SINH].ToString().Split(' ')[0];
            //m_lbl_dia_chi.Text = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.CHO_O].ToString();

            // DucVT
            m_lbl_email_ca_nhan.Text = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.EMAIL_CQ].ToString();

            // Lấy chức vụ bằng Id nhân sự
            DS_V_GD_QUA_TRINH_LAM_VIEC v_ds_gd_qtlv = new DS_V_GD_QUA_TRINH_LAM_VIEC();
            US_V_GD_QUA_TRINH_LAM_VIEC v_us_gd_qtlv = new US_V_GD_QUA_TRINH_LAM_VIEC();

            v_us_gd_qtlv.FillDataSet_Now_By_Ma_NV_Id_PN(v_ds_gd_qtlv, v_ds_dm_nhan_su.DM_NHAN_SU.Rows[0][DM_NHAN_SU.MA_NV].ToString(), CAppContext_201.getCurrentIDPhapnhan());

            if (v_ds_gd_qtlv.V_GD_QUA_TRINH_LAM_VIEC.Rows.Count > 0)
            {
                m_lbl_chuc_vu.Text = v_ds_gd_qtlv.V_GD_QUA_TRINH_LAM_VIEC.Rows[0][V_GD_QUA_TRINH_LAM_VIEC.MA_CV].ToString();
                m_lbl_don_vi.Text = v_ds_gd_qtlv.V_GD_QUA_TRINH_LAM_VIEC.Rows[0][V_GD_QUA_TRINH_LAM_VIEC.MA_DON_VI].ToString();
            }
            // ~DucVT
            

            // Đưa thông tin nhân viên vào Grid
            m_fg_nhan_vien.Rows[m_fg_nhan_vien.Row][(int)e_col_Number_nhan_vien.HO_DEM] = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.HO_DEM];
            m_fg_nhan_vien.Rows[m_fg_nhan_vien.Row][(int)e_col_Number_nhan_vien.TEN] = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.TEN];
            m_fg_nhan_vien.Rows[m_fg_nhan_vien.Row][(int)e_col_Number_nhan_vien.MA_NV] = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.MA_NV];
            var rowArray = new object[4];
            rowArray[0] = v_ds_dm_nhan_su.DM_NHAN_SU.Rows[0][DM_NHAN_SU.ID];
            rowArray[1] = v_ds_dm_nhan_su.DM_NHAN_SU.Rows[0][DM_NHAN_SU.ID];
            rowArray[2] = v_ds_dm_nhan_su.DM_NHAN_SU.Rows[0][DM_NHAN_SU.ID];
            rowArray[3] = v_ds_dm_nhan_su.DM_NHAN_SU.Rows[0][DM_NHAN_SU.ID];
            var v_row = v_ds_dm_nhan_su.DM_NHAN_SU.NewRow();
            v_row.ItemArray = rowArray;
            m_fg_nhan_vien.Rows[m_fg_nhan_vien.Row].UserData = v_row;

            // Lấy trạng thái lao động đưa vào Grid
            US_V_GD_TRANG_THAI_LAO_DONG v_us_trang_thai_ld = new US_V_GD_TRANG_THAI_LAO_DONG();
            DS_V_GD_TRANG_THAI_LAO_DONG v_ds_trang_thai_ld = new DS_V_GD_TRANG_THAI_LAO_DONG();
            v_us_trang_thai_ld.FillDatasetByManhanvien_trang_thai_hien_tai(v_ds_trang_thai_ld, m_lbl_ma_nhan_vien.Text, CAppContext_201.getCurrentIDPhapnhan());
            if (v_ds_trang_thai_ld.V_GD_TRANG_THAI_LAO_DONG.Rows.Count > 0)
                m_fg_nhan_vien.Rows[m_fg_nhan_vien.Row][(int)e_col_Number_nhan_vien.TRANG_THAI_LAO_DONG] = v_ds_trang_thai_ld.V_GD_TRANG_THAI_LAO_DONG.Rows[0][V_GD_TRANG_THAI_LAO_DONG.TRANG_THAI_LAO_DONG].ToString();
            else
                m_fg_nhan_vien.Rows[m_fg_nhan_vien.Row][(int)e_col_Number_nhan_vien.TRANG_THAI_LAO_DONG] = string.Empty;

            m_fg_nhan_vien.Select(m_fg_nhan_vien.Row, (int)e_col_Number_nhan_vien.VI_TRI);
            m_tab_du_an.SelectTab("tabNhanVien");
        }

        private ITransferDataRow get_trans_object_nhan_vien(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_NV, e_col_Number_nhan_vien.MA_NV);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.ID_NHAN_SU, e_col_Number_nhan_vien.HO_DEM);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.HO_DEM, e_col_Number_nhan_vien.HO_DEM);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.TEN, e_col_Number_nhan_vien.TEN);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.ID_VI_TRI, e_col_Number_nhan_vien.VI_TRI);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.TRANG_THAI_LAO_DONG, e_col_Number_nhan_vien.TRANG_THAI_LAO_DONG);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_DIEM_TG, e_col_Number_nhan_vien.THOI_DIEM_TG);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_DIEM_KT, e_col_Number_nhan_vien.THOI_DIEM_KT);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_GIAN_TG, e_col_Number_nhan_vien.THOI_GIAN_TG);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.ID_DANH_HIEU, e_col_Number_nhan_vien.DANH_HIEU);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_QUYET_DINH, e_col_Number_nhan_vien.MA_QUYET_DINH);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.MO_TA, e_col_Number_nhan_vien.MO_TA);

            
            DS_V_DM_NHAN_SU_DU_AN v_ds = new DS_V_DM_NHAN_SU_DU_AN();
            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, v_ds.V_DM_NHAN_SU_DU_AN.NewRow());
            return v_obj_trans;
        }

        private ITransferDataRow get_trans_object_quyet_dinh(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();

            v_htb.Add(V_DM_QUYET_DINH.MA_QUYET_DINH, e_col_Number_quyet_dinh.MA_QUYET_DINH);
            v_htb.Add(V_DM_QUYET_DINH.ID_LOAI_QD, e_col_Number_quyet_dinh.LOAI_QUYET_DINH);
            v_htb.Add(V_DM_QUYET_DINH.NGAY_KY, e_col_Number_quyet_dinh.NGAY_KY);
            v_htb.Add(V_DM_QUYET_DINH.NGAY_CO_HIEU_LUC, e_col_Number_quyet_dinh.NGAY_CO_HIEU_LUC);
            v_htb.Add(V_DM_QUYET_DINH.NGAY_HET_HIEU_LUC, e_col_Number_quyet_dinh.NGAY_HET_HAN);
            v_htb.Add(V_DM_QUYET_DINH.LINK, e_col_Number_quyet_dinh.LINK);
            v_htb.Add(V_DM_QUYET_DINH.NOI_DUNG, e_col_Number_quyet_dinh.NOI_DUNG);

            DS_V_DM_QUYET_DINH v_ds = new DS_V_DM_QUYET_DINH();
            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, v_ds.V_DM_QUYET_DINH.NewRow());
            return v_obj_trans;
        }

        private void load_cbo_to_column_of_grid(e_loai_tu_dien ip_e_loai_tu_dien, C1.Win.C1FlexGrid.C1FlexGrid m_fg, int ip_i_col_index)
        {
            US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
            var v_htb = new Hashtable();
            try
            {
                v_us.BeginTransaction();
                if ((int)ip_e_loai_tu_dien == ID_LOAI_TU_DIEN_QUYET_DINH)
                    v_us.FillDataset(v_ds, string.Format("WHERE {0} = {1} OR {0} = {2}", CM_DM_TU_DIEN.ID, ID_QUYET_DINH_BO_SUNG_DU_AN, ID_QUYET_DINH_THANH_LAP_DU_AN));
                else
                    v_us.FillDatasetByIdLoaiTuDien(v_ds, (int)ip_e_loai_tu_dien);
                v_us.CommitTransaction();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }

            foreach (DataRow v_dr in v_ds.CM_DM_TU_DIEN.Rows)
            {
                v_htb.Add(v_dr[CM_DM_TU_DIEN.ID], v_dr[CM_DM_TU_DIEN.TEN]);
            }

            #region DucVT
            if (ip_e_loai_tu_dien != e_loai_tu_dien.LOAI_QUYET_DINH)
            {
                Decimal v_null_value = -1;
                v_htb.Add(v_null_value, "(Bỏ Trống)");
            }

            #endregion

            m_fg.Cols[ip_i_col_index].DataMap = v_htb;
        }



        private void chon_file(RowColEventArgs e)
        {
            FileExplorer.SelectFile(m_ofd_chon_file, m_str_link_old);
            m_fg_quyet_dinh[e.Row, e.Col] = FileExplorer.fileName;
        }

        private void view_file()
        {
            if (m_fg_quyet_dinh.Col == (int)e_col_Number_quyet_dinh.LINK && m_fg_quyet_dinh[m_fg_quyet_dinh.Row, (int)e_col_Number_quyet_dinh.LINK] != null)
            {
                f701_v_gd_hop_dong_lao_dong_View frm = new f701_v_gd_hop_dong_lao_dong_View();
                if (FileExplorer.IsExistedFile(m_str_directory_to + FileExplorer.fileName))
                    frm.display(m_str_directory_to + m_fg_quyet_dinh[m_fg_quyet_dinh.Row, m_fg_quyet_dinh.Col]);
                else
                    frm.display(FileExplorer.path + m_fg_quyet_dinh[m_fg_quyet_dinh.Row, m_fg_quyet_dinh.Col]);
            }
        }




        private void refresh()
        {
            if (m_e_form_mode == DataEntryFormMode.InsertDataState)
            {
                m_txt_ma_du_an.Text = "";
                m_txt_ma_du_an_thr.Text = "";
                m_txt_noi_dung_du_an.Text = "";
                m_txt_ten_du_an.Text = "";
            }
            if (m_e_form_mode == DataEntryFormMode.UpdateDataState)
            {
                us_2_form_du_an(m_us);
            }
        }



        private void form_to_us_du_an(US_DM_DU_AN op_us)
        {
            op_us.dcID = m_us.dcID;
            op_us.strMA_DU_AN = m_txt_ma_du_an.Text;
            op_us.strMA_DU_AN_THR = m_txt_ma_du_an_thr.Text;
            op_us.strTEN_DU_AN = m_txt_ten_du_an.Text;
            op_us.dcID_TRANG_THAI = (decimal)m_cbo_trang_thai.SelectedValue;
            op_us.dcID_LOAI_DU_AN = (decimal)m_cbo_loai_du_an.SelectedValue;
            op_us.datNGAY_BAT_DAU = m_dat_ngay_bd.Value;
            if (m_dat_ngay_kt.Checked)
                op_us.datNGAY_KET_THUC = m_dat_ngay_kt.Value;
            else
                op_us.SetNGAY_KET_THUCNull();

            op_us.strNOI_DUNG = m_txt_noi_dung_du_an.Text;
            if (m_cbo_co_che.SelectedValue.ToString() == "-1")
                op_us.SetID_CO_CHENull();
            else
                op_us.dcID_CO_CHE = (decimal)m_cbo_co_che.SelectedValue;
        }

        private void us_2_form_du_an(US_V_DM_DU_AN_QUYET_DINH_TU_DIEN ip_us)
        {
            m_txt_ma_du_an.Text = ip_us.strMA_DU_AN;
            m_txt_ma_du_an_thr.Text = ip_us.strMA_DU_AN_THR;
            m_cbo_loai_du_an.SelectedValue = ip_us.dcID_LOAI_DU_AN;
            m_txt_ten_du_an.Text = ip_us.strTEN_DU_AN;
            m_dat_ngay_bd.Value = ip_us.datNGAY_BAT_DAU;
            if (ip_us.datNGAY_KET_THUC > DateTime.Parse("01/01/1900"))
            {
                m_dat_ngay_kt.Checked = true;
                m_dat_ngay_kt.Value = ip_us.datNGAY_KET_THUC;
            }
            else
            {
                m_dat_ngay_kt.Checked = false;
            }

            if (ip_us.dcID_CO_CHE == null || ip_us.dcID_CO_CHE == 0)
                m_cbo_co_che.SelectedIndex = 0;
            else
                m_cbo_co_che.SelectedValue = ip_us.dcID_CO_CHE;

            m_cbo_trang_thai.SelectedValue = ip_us.dcID_TRANG_THAI;
            m_txt_noi_dung_du_an.Text = ip_us.strNOI_DUNG;
        }

        private void us_quyet_dinh_to_grid(US_V_DM_DU_AN_QUYET_DINH_TU_DIEN ip_us)
        {
            US_V_DM_QUYET_DINH v_us = new US_V_DM_QUYET_DINH();
            DS_V_DM_QUYET_DINH v_ds = new DS_V_DM_QUYET_DINH();
            v_us.GetAllQuyetDinhOfDuAn(v_ds, ip_us.dcID);
            m_fg_quyet_dinh.Redraw = false;
            CGridUtils.Dataset2C1Grid(v_ds, m_fg_quyet_dinh, m_obj_trans_quyet_dinh);
            m_fg_quyet_dinh.Redraw = true;
        }

        private void us_nhan_vien_to_grid(US_V_DM_DU_AN_QUYET_DINH_TU_DIEN ip_us)
        {
            US_V_DM_NHAN_SU_DU_AN v_us = new US_V_DM_NHAN_SU_DU_AN();
            DS_V_DM_NHAN_SU_DU_AN v_ds = new DS_V_DM_NHAN_SU_DU_AN();
            v_us.FillDatasetByIdDuAn(v_ds, m_us.dcID, CAppContext_201.getCurrentIDPhapnhan());
            m_fg_nhan_vien.Redraw = false;
            CGridUtils.Dataset2C1Grid(v_ds, m_fg_nhan_vien, m_obj_trans_nhan_vien);
            m_fg_nhan_vien.Redraw = true;
        }

        private void grid_row_to_us_quyet_dinh(int i_grid_row, US_V_DM_DU_AN_QUYET_DINH_TU_DIEN op_us)
        {
            op_us.strMA_QUYET_DINH = m_fg_quyet_dinh[i_grid_row, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH].ToString();
            decimal v_id_loai_quyet_dinh = (decimal)m_fg_quyet_dinh[i_grid_row, (int)e_col_Number_quyet_dinh.LOAI_QUYET_DINH];
            if (v_id_loai_quyet_dinh == -1)
                op_us.SetID_LOAI_QDNull();
            else
                op_us.dcID_LOAI_QD = v_id_loai_quyet_dinh;

            op_us.datNGAY_KY = (DateTime)m_fg_quyet_dinh[i_grid_row, (int)e_col_Number_quyet_dinh.NGAY_KY];
            op_us.datNGAY_CO_HIEU_LUC = (DateTime)m_fg_quyet_dinh[i_grid_row, (int)e_col_Number_quyet_dinh.NGAY_CO_HIEU_LUC];

            if (m_fg_quyet_dinh[i_grid_row, (int)e_col_Number_quyet_dinh.NGAY_HET_HAN] != null)
                op_us.datNGAY_HET_HIEU_LUC = (DateTime)m_fg_quyet_dinh[i_grid_row, (int)e_col_Number_quyet_dinh.NGAY_HET_HAN];
            else
                op_us.SetNGAY_HET_HIEU_LUCNull();

            op_us.strLINK = m_fg_quyet_dinh[i_grid_row, (int)e_col_Number_quyet_dinh.LINK] != null ? m_fg_quyet_dinh[i_grid_row, (int)e_col_Number_quyet_dinh.LINK].ToString() : null;
            op_us.strNOI_DUNG_QD = m_fg_quyet_dinh[i_grid_row, (int)e_col_Number_quyet_dinh.NOI_DUNG] != null ? m_fg_quyet_dinh[i_grid_row, (int)e_col_Number_quyet_dinh.NOI_DUNG].ToString() : null;
        }

        private void grid_row_to_us_quyet_dinh_phap_nhan(US_GD_QUYET_DINH_PHAP_NHAN op_us, US_V_DM_DU_AN_QUYET_DINH_TU_DIEN ip_us)
        {
            op_us.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
            op_us.dcID_QUYET_DINH = ip_us.dcID;
        }

        private void grid_row_to_us_nhan_vien(int i_grid_row, US_GD_CHI_TIET_DU_AN op_us, US_DM_DU_AN ip_us_du_an)
        {
            op_us.dcID_DU_AN = ip_us_du_an.dcID;
            var v_data_row = (DataRow)m_fg_nhan_vien.Rows[i_grid_row].UserData;
            op_us.dcID_NHAN_SU = decimal.Parse(v_data_row.ItemArray[(int)e_number.ID_NHAN_SU].ToString());
            decimal v_id_vi_tri = (decimal)m_fg_nhan_vien[i_grid_row, (int)e_col_Number_nhan_vien.VI_TRI];
            if (v_id_vi_tri == -1)
                op_us.SetID_VI_TRINull();
            else
                op_us.dcID_VI_TRI = v_id_vi_tri;


            //var v_obj_trang_thai = m_fg_nhan_vien[i_grid_row, (int) e_col_Number_nhan_vien.TRANG_THAI_LAO_DONG];
            //if (v_obj_trang_thai != null)
            //    op_us.strTRANG_THAI_HIEN_TAI = v_obj_trang_thai.ToString();
            //else
            //    op_us.SetTRANG_THAI_HIEN_TAINull();
            op_us.strTRANG_THAI_HIEN_TAI = "Y";

            op_us.datTHOI_DIEM_TG = (DateTime)m_fg_nhan_vien[i_grid_row, (int)e_col_Number_nhan_vien.THOI_DIEM_TG];

            var v_obj_thoi_diem_ket_thuc = m_fg_nhan_vien[i_grid_row, (int)e_col_Number_nhan_vien.THOI_DIEM_KT];
            if (v_obj_thoi_diem_ket_thuc != null)
                op_us.datTHOI_DIEM_KT = (DateTime)v_obj_thoi_diem_ket_thuc;
            else
                op_us.SetTHOI_DIEM_KTNull();

            var v_obj_thoi_gian_tham_gia = m_fg_nhan_vien[i_grid_row, (int)e_col_Number_nhan_vien.THOI_GIAN_TG];
            if (v_obj_thoi_gian_tham_gia != null)
                op_us.dcTHOI_GIAN_TG = (decimal)v_obj_thoi_gian_tham_gia;
            else
                op_us.SetTHOI_GIAN_TGNull();

            #region DucVT
            var v_obj_danh_hieu = m_fg_nhan_vien[i_grid_row, (int)e_col_Number_nhan_vien.DANH_HIEU];
            if (v_obj_danh_hieu != null)
            {
                decimal v_id_danh_hieu = (decimal)v_obj_danh_hieu;

                if (v_id_danh_hieu == -1)
                    op_us.SetID_DANH_HIEUNull();
                else
                    op_us.dcID_DANH_HIEU = v_id_danh_hieu;
            }
            else
                op_us.SetID_DANH_HIEUNull();
            #endregion

            for (int i = m_fg_quyet_dinh.Rows.Fixed; i < m_fg_quyet_dinh.Rows.Count - 1; i++)
            {
                if ((string)m_fg_quyet_dinh[i, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH] == (string)m_fg_nhan_vien[i_grid_row, (int)e_col_Number_nhan_vien.MA_QUYET_DINH])
                {
                    op_us.dcID_QUYET_DINH = (decimal)m_fg_quyet_dinh.Rows[i].UserData;
                }
            }
        }

        private void grid_row_to_quyet_dinh_du_an(US_GD_QUYET_DINH_DU_AN op_us, US_DM_DU_AN ip_us)
        {
            op_us.dcID_QUYET_DINH = m_us.dcID;
            op_us.dcID_DU_AN = ip_us.dcID;
        }



        private bool is_exist_du_an(string ip_str_ma_du_an)
        {

            DS_DM_DU_AN v_ds = new DS_DM_DU_AN();
            US_DM_DU_AN v_us = new US_DM_DU_AN();
            v_us.FillDataset_search_by_ma_da(v_ds, ip_str_ma_du_an);
            if (v_ds.DM_DU_AN.Count > 0)
                return true;
            return false;
        }

        private bool is_exist_quyet_dinh(string ip_str_ma_quyet_dinh)
        {
            US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
            DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
            v_us.FillDataset_By_Ma_qd(v_ds, ip_str_ma_quyet_dinh);
            if (v_ds.DM_QUYET_DINH.Rows.Count > 0)
                return true;
            return false;
        }

        private bool check_data_is_ok()
        {
            #region Validate form Du An
            if (!m_dat_ngay_bd.Checked)
            {
                BaseMessages.MsgBox_Infor("Phải có ngày bắt đầu dự án");
                m_dat_ngay_bd.Focus();
                return false;
            }

            if (m_dat_ngay_kt.Checked)
            {
                if (m_dat_ngay_bd.Value.Date > m_dat_ngay_kt.Value.Date)
                {
                    BaseMessages.MsgBox_Infor("Ngày bắt đầu dự án phải trước ngày kết thúc dự án");
                    m_dat_ngay_kt.Focus();
                    return false;
                }
            }

            if (!CValidateTextBox.IsValid(m_txt_ma_du_an, DataType.StringType, allowNull.NO, false))
            {
                BaseMessages.MsgBox_Error("Phải nhập mã dự án.");
                return false;
            }

            if (!CValidateTextBox.IsValid(m_txt_ten_du_an, DataType.StringType, allowNull.NO, false))
            {
                BaseMessages.MsgBox_Error("Phải nhập tên dự án");
                return false;
            }
            #endregion

            #region Check exist Du An
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    if (is_exist_du_an(m_txt_ma_du_an.Text))
                    {
                        BaseMessages.MsgBox_Error("Mã dự án đã tồn tại.");
                        m_txt_ma_du_an.Focus();
                        return false;
                    }
                    break;
                case DataEntryFormMode.UpdateDataState:
                    if (!m_txt_ma_du_an.Text.Equals(m_str_ma_du_an_old))
                    {
                        if (is_exist_du_an(m_txt_ma_du_an.Text))
                        {
                            BaseMessages.MsgBox_Error("Mã dự án đã tồn tại.");
                            m_txt_ma_du_an.Focus();
                            return false;
                        }
                    }
                    break;
            }
            #endregion

            for (int v_i_cur_row = m_fg_quyet_dinh.Rows.Fixed; v_i_cur_row < m_fg_quyet_dinh.Rows.Count - 1; v_i_cur_row++)
            {
                #region Validate Quyet Dinh
                if (m_fg_quyet_dinh[v_i_cur_row, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH] == null)
                {
                    BaseMessages.MsgBox_Infor("Bạn chưa điền mã quyết định");
                    m_fg_quyet_dinh.Select(v_i_cur_row, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH);
                    m_tab_du_an.SelectTab("tabQuyetDinh");
                    return false;
                }
                if (m_fg_quyet_dinh[v_i_cur_row, (int)e_col_Number_quyet_dinh.LOAI_QUYET_DINH] == null)
                {
                    BaseMessages.MsgBox_Infor("Bạn chưa chọn loại quyết định");
                    m_fg_quyet_dinh.Select(v_i_cur_row, (int)e_col_Number_quyet_dinh.LOAI_QUYET_DINH);
                    m_tab_du_an.SelectTab("tabQuyetDinh");
                    return false;
                }
                if (m_fg_quyet_dinh[v_i_cur_row, (int)e_col_Number_quyet_dinh.NGAY_KY] == null)
                {
                    BaseMessages.MsgBox_Infor("Bạn chưa chọn ngày ký");
                    m_fg_quyet_dinh.Select(v_i_cur_row, (int)e_col_Number_quyet_dinh.NGAY_KY);
                    m_tab_du_an.SelectTab("tabQuyetDinh");
                    return false;
                }
                if (m_fg_quyet_dinh[v_i_cur_row, (int)e_col_Number_quyet_dinh.NGAY_CO_HIEU_LUC] == null)
                {
                    BaseMessages.MsgBox_Infor("Bạn chưa chọn ngày có hiệu lực");
                    m_fg_quyet_dinh.Select(v_i_cur_row, (int)e_col_Number_quyet_dinh.NGAY_CO_HIEU_LUC);
                    m_tab_du_an.SelectTab("tabQuyetDinh");
                    return false;
                }

                if (DateTime.Parse(m_fg_quyet_dinh[v_i_cur_row, (int)e_col_Number_quyet_dinh.NGAY_CO_HIEU_LUC].ToString()) < DateTime.Parse(m_fg_quyet_dinh[v_i_cur_row, (int)e_col_Number_quyet_dinh.NGAY_KY].ToString()))
                {
                    BaseMessages.MsgBox_Infor("Ngày có hiệu lực phải nhỏ hơn ngày ký");
                    m_fg_quyet_dinh.Select(v_i_cur_row, (int)e_col_Number_quyet_dinh.NGAY_CO_HIEU_LUC);
                    m_tab_du_an.SelectTab("tabQuyetDinh");
                    return false;
                }
                #endregion

                #region Check exist Quyet Dinh
                US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
                DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
                var v_str_ma_quyet_dinh = m_fg_quyet_dinh[v_i_cur_row, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH].ToString();
                var v_col_link = m_fg_quyet_dinh[v_i_cur_row, (int)e_col_Number_quyet_dinh.LINK];
                string v_str_file_name = "";
                if (v_col_link != null)
                {
                    v_str_file_name = v_col_link.ToString();
                }

                // Lấy ID QĐ theo Mã QĐ trên gird
                v_us.FillDataset(v_ds, string.Format("WHERE {0} = '{1}'",
                                                    V_DM_QUYET_DINH.MA_QUYET_DINH,
                                                    v_str_ma_quyet_dinh));
                if (v_ds.DM_QUYET_DINH.Rows.Count > 0)  // Nếu QĐ có tồn tại
                {
                    // Kiểm tra Quyết Định có đang dc dùng cho dự án hiện tại hay ko
                    var v_dc_id_quyet_dinh = v_ds.DM_QUYET_DINH.Rows[0][V_DM_QUYET_DINH.ID];
                    US_GD_QUYET_DINH_DU_AN v_us_qd_da = new US_GD_QUYET_DINH_DU_AN();
                    DS_GD_QUYET_DINH_DU_AN v_ds_qd_da = new DS_GD_QUYET_DINH_DU_AN();
                    v_us_qd_da.FillDataset(v_ds_qd_da, string.Format("WHERE {0} = {1} AND {2} = {3}",
                                                                    GD_QUYET_DINH_DU_AN.ID_QUYET_DINH,
                                                                    v_dc_id_quyet_dinh,
                                                                    GD_QUYET_DINH_DU_AN.ID_DU_AN,
                                                                    m_us.dcID));
                    // Nếu ko dc dùng cho dự án hiện tại.....
                    if (v_ds_qd_da.GD_QUYET_DINH_DU_AN.Rows.Count == 0)
                    {
                        // Dùng mã QĐ trên grid kiểm tra trùng mã QĐ nào ko
                        if (is_exist_quyet_dinh(v_str_ma_quyet_dinh))
                        {
                            BaseMessages.MsgBox_Error("Mã quyết định đã tồn tại.");
                            m_fg_quyet_dinh.Select(v_i_cur_row, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH);
                            m_tab_du_an.SelectTab("tabQuyetDinh");
                            return false;
                        }

                        #region Check File đính kèm
                        if (FileExplorer.IsExistedFile(m_str_directory_to + v_str_file_name))
                        {
                            BaseMessages.MsgBox_Infor("Tên file đã tồn tại.");
                            m_fg_quyet_dinh.Select(v_i_cur_row, (int)e_col_Number_quyet_dinh.LINK);
                            m_tab_du_an.SelectTab("tabQuyetDinh");
                            return false;
                        }
                        #endregion
                    }
                    // Nếu đang dc dùng cho dự án hiện tại
                    else
                    {
                        for (int i = m_fg_quyet_dinh.Rows.Fixed; i < m_fg_quyet_dinh.Rows.Count - 1; i++)
                        {
                            if (i != v_i_cur_row)
                            {
                                var v_str_ma_qd_grid = m_fg_quyet_dinh[i, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH].ToString();
                                if (v_str_ma_quyet_dinh == v_str_ma_qd_grid)
                                {
                                    BaseMessages.MsgBox_Error("Mã quyết định đã tồn tại.");
                                    m_fg_quyet_dinh.Select(v_i_cur_row, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH);
                                    m_tab_du_an.SelectTab("tabQuyetDinh");
                                    return false;
                                }
                            }
                        }
                    }
                }
                else // Nếu QĐ hiện tại chưa tồn tại
                {
                    for (int i = m_fg_quyet_dinh.Rows.Fixed; i < m_fg_quyet_dinh.Rows.Count - 1; i++)
                    {
                        if (i != v_i_cur_row)
                        {
                            if (v_str_ma_quyet_dinh == (string) m_fg_quyet_dinh[i, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH])
                            {
                                BaseMessages.MsgBox_Error("Mã quyết định đã tồn tại.");
                                m_fg_quyet_dinh.Select(v_i_cur_row, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH);
                                m_tab_du_an.SelectTab("tabQuyetDinh");
                                return false;
                            }
                        }
                    }

                    #region Check File đính kèm

                    if (FileExplorer.IsExistedFile(m_str_directory_to + v_str_file_name))
                    {
                        BaseMessages.MsgBox_Infor("Tên file đã tồn tại.");
                        m_fg_quyet_dinh.Select(v_i_cur_row, (int)e_col_Number_quyet_dinh.LINK);
                        m_tab_du_an.SelectTab("tabQuyetDinh");
                        return false;
                    }
                    #endregion
                }
                #endregion
            }

            #region Validate Nhan Vien
            for (int v_i_cur_row = m_fg_nhan_vien.Rows.Fixed; v_i_cur_row < m_fg_nhan_vien.Rows.Count - 1; v_i_cur_row++)
            {
                if (m_fg_nhan_vien[v_i_cur_row, (int)e_col_Number_nhan_vien.HO_DEM] == null)
                {
                    BaseMessages.MsgBox_Infor("Bạn chưa chọn nhân viên");
                    m_fg_nhan_vien.Select(v_i_cur_row, (int)e_col_Number_nhan_vien.HO_DEM);
                    m_tab_du_an.SelectTab("tabNhanVien");
                    return false;
                }
                if (m_fg_nhan_vien[v_i_cur_row, (int)e_col_Number_nhan_vien.VI_TRI] == null)
                {
                    BaseMessages.MsgBox_Infor("Bạn chưa chọn vị trí nhân viên trong dự án");
                    m_fg_nhan_vien.Select(v_i_cur_row, (int)e_col_Number_nhan_vien.VI_TRI);
                    m_tab_du_an.SelectTab("tabNhanVien");
                    return false;
                }
                if (m_fg_nhan_vien[v_i_cur_row, (int)e_col_Number_nhan_vien.THOI_DIEM_TG] == null)
                {
                    BaseMessages.MsgBox_Infor("Bạn chưa chọn thời điểm tham gia");
                    m_fg_nhan_vien.Select(v_i_cur_row, (int)e_col_Number_nhan_vien.THOI_DIEM_TG);
                    m_tab_du_an.SelectTab("tabNhanVien");
                    return false;
                }

                if (m_fg_nhan_vien[v_i_cur_row, (int)e_col_Number_nhan_vien.THOI_DIEM_KT] != null)
                {
                    if ((DateTime)m_fg_nhan_vien[v_i_cur_row, (int)e_col_Number_nhan_vien.THOI_DIEM_TG] > (DateTime)m_fg_nhan_vien[v_i_cur_row, (int)e_col_Number_nhan_vien.THOI_DIEM_KT])
                    {
                        BaseMessages.MsgBox_Infor("Thời điểm kết thúc phải lớn hơn thời điểm tham gia");
                        m_fg_nhan_vien.Select(v_i_cur_row, (int)e_col_Number_nhan_vien.THOI_DIEM_KT);
                        m_tab_du_an.SelectTab("tabNhanVien");
                        return false;
                    }
                }

                if (m_fg_nhan_vien[v_i_cur_row, (int)e_col_Number_nhan_vien.THOI_GIAN_TG] != null)
                {
                    if ((decimal)m_fg_nhan_vien[v_i_cur_row, (int)e_col_Number_nhan_vien.THOI_GIAN_TG] > 100)
                    {
                        BaseMessages.MsgBox_Infor("Thời gian tham gia không thể lớn hơn 100%");
                        m_fg_nhan_vien.Select(v_i_cur_row, (int)e_col_Number_nhan_vien.THOI_GIAN_TG);
                        m_tab_du_an.SelectTab("tabNhanVien");
                        return false;
                    }
                }

                // Check mã quyết định đã có bên Tab Quyết Định chưa
                bool v_b_check_is_exist_ma_quyet_dinh = false;
                if (m_fg_nhan_vien[v_i_cur_row, (int)e_col_Number_nhan_vien.MA_QUYET_DINH] == null)
                {
                    BaseMessages.MsgBox_Infor("Bạn chưa điền mã quyết định");
                    m_fg_nhan_vien.Select(v_i_cur_row, (int)e_col_Number_nhan_vien.MA_QUYET_DINH);
                    m_tab_du_an.SelectTab("tabNhanVien");
                    return false;
                }
                else
                {
                    for (int i = m_fg_quyet_dinh.Rows.Fixed; i < m_fg_quyet_dinh.Rows.Count - 1; i++)
                    {
                        if ((string)m_fg_quyet_dinh[i, (int)e_col_Number_quyet_dinh.MA_QUYET_DINH] == (string)m_fg_nhan_vien[v_i_cur_row, (int)e_col_Number_nhan_vien.MA_QUYET_DINH])
                        {
                            v_b_check_is_exist_ma_quyet_dinh = true;
                            break;
                        }
                    }

                    if (v_b_check_is_exist_ma_quyet_dinh == false)
                    {
                        BaseMessages.MsgBox_Infor("Mã quyết định chưa đúng.");
                        m_fg_nhan_vien.Select(v_i_cur_row, (int)e_col_Number_nhan_vien.MA_QUYET_DINH);
                        m_tab_du_an.SelectTab("tabNhanVien");
                        return false;
                    }
                }
            }
            #endregion

            return true;
        }

        private void save_data()
        {
            if (check_data_is_ok() == false)
                return;

            try
            {
                m_us.BeginTransaction();
                #region Xử lý file đính kèm
                for (int v_i_cur_row = m_fg_quyet_dinh.Rows.Fixed; v_i_cur_row < m_fg_quyet_dinh.Rows.Count - 1; v_i_cur_row++)
                {
                    var v_col_link = m_fg_quyet_dinh[v_i_cur_row, (int)e_col_Number_quyet_dinh.LINK];
                    if (v_col_link != null)
                    {
                        FileExplorer.fileName = v_col_link.ToString();
                        if (FileExplorer.IsExistedFile(m_str_directory_to + FileExplorer.fileName) == false)
                        {
                            if (m_str_user_name != "")
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to, m_str_user_name, m_str_password);
                            else
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to);
                        }
                    }

                }
                #endregion

                #region Xử lý dự án
                US_DM_DU_AN v_us_du_an = new US_DM_DU_AN();
                v_us_du_an.UseTransOfUSObject(m_us);
                form_to_us_du_an(v_us_du_an);
                switch (m_e_form_mode)
                {
                    case DataEntryFormMode.InsertDataState:
                        v_us_du_an.Insert();
                        break;
                    case DataEntryFormMode.UpdateDataState:
                        v_us_du_an.Update();
                        break;
                }
                #endregion

                #region Xử lý quyết định

                // Xóa Quyết định - Dự án - Chi tiết dự án
                US_GD_QUYET_DINH_DU_AN v_us_qd_du_an = new US_GD_QUYET_DINH_DU_AN();
                DS_GD_QUYET_DINH_DU_AN v_ds_qd_du_an = new DS_GD_QUYET_DINH_DU_AN();
                v_us_qd_du_an.FillDataset(v_ds_qd_du_an, string.Format("WHERE {0} = {1}",
                                                                        GD_QUYET_DINH_DU_AN.ID_DU_AN,
                                                                        v_us_du_an.dcID));
                if (v_ds_qd_du_an.GD_QUYET_DINH_DU_AN.Rows.Count > 0)
                {
                    for (int i = 0; i < v_ds_qd_du_an.GD_QUYET_DINH_DU_AN.Rows.Count; i++)
                    {
                        var v_dc_id_quyet_dinh = (decimal)v_ds_qd_du_an.GD_QUYET_DINH_DU_AN.Rows[i][GD_QUYET_DINH_DU_AN.ID_QUYET_DINH];
                        US_GD_QUYET_DINH_PHAP_NHAN v_us_qd_pn = new US_GD_QUYET_DINH_PHAP_NHAN();
                        v_us_qd_pn.UseTransOfUSObject(m_us);
                        v_us_qd_pn.DeleteByID(v_dc_id_quyet_dinh);

                        v_us_qd_du_an.UseTransOfUSObject(m_us);
                        v_us_qd_du_an.DeleteByID(v_dc_id_quyet_dinh);

                        US_GD_CHI_TIET_DU_AN v_us_ct_da = new US_GD_CHI_TIET_DU_AN();
                        v_us_ct_da.UseTransOfUSObject(m_us);
                        v_us_ct_da.DeleteByID(v_dc_id_quyet_dinh);

                        US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH();
                        v_us_qd.UseTransOfUSObject(m_us);
                        v_us_qd.DeleteByID(v_dc_id_quyet_dinh);
                    }
                }

                // Thêm mới
                for (int v_i_current_row = m_fg_quyet_dinh.Rows.Fixed; v_i_current_row < m_fg_quyet_dinh.Rows.Count - 1; v_i_current_row++)
                {
                    grid_row_to_us_quyet_dinh(v_i_current_row, m_us);
                    m_us.Insert();

                    m_fg_quyet_dinh.Rows[v_i_current_row].UserData = m_us.dcID;

                    US_GD_QUYET_DINH_PHAP_NHAN v_us_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
                    v_us_quyet_dinh_phap_nhan.UseTransOfUSObject(m_us);
                    grid_row_to_us_quyet_dinh_phap_nhan(v_us_quyet_dinh_phap_nhan, m_us);
                    v_us_quyet_dinh_phap_nhan.Insert();

                    US_GD_QUYET_DINH_DU_AN v_us_quyet_dinh_du_an = new US_GD_QUYET_DINH_DU_AN();
                    v_us_quyet_dinh_du_an.UseTransOfUSObject(m_us);
                    grid_row_to_quyet_dinh_du_an(v_us_quyet_dinh_du_an, v_us_du_an);
                    v_us_quyet_dinh_du_an.Insert();
                }
                #endregion

                #region Xử lý nhân viên
                US_GD_CHI_TIET_DU_AN v_us_chi_tiet_du_an = new US_GD_CHI_TIET_DU_AN();
                for (int v_i_current_row = m_fg_nhan_vien.Rows.Fixed; v_i_current_row < m_fg_nhan_vien.Rows.Count - 1; v_i_current_row++)
                {
                    v_us_chi_tiet_du_an.UseTransOfUSObject(m_us);
                    grid_row_to_us_nhan_vien(v_i_current_row, v_us_chi_tiet_du_an, v_us_du_an);
                    v_us_chi_tiet_du_an.Insert();
                }
                #endregion

                m_us.CommitTransaction();
                m_str_ma_du_an = m_txt_ma_du_an.Text;
                BaseMessages.MsgBox_Infor("Lưu dữ liệu thành công");
                this.Close();
            }
            catch (Exception)
            {
                if (m_us.is_having_transaction())
                    m_us.Rollback();
                throw;
            }
        }
        #endregion

        #region Event Handle
        private void set_define_events()
        {
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            this.Load += f500_dm_du_an_detail_Load;
            m_txt_search_nhan_vien.KeyDown += m_txt_search_nhan_vien_KeyDown;
            m_txt_search_nhan_vien.Leave += m_txt_search_nhan_vien_Leave;
            m_cmd_delete_nhan_vien.Click += m_cmd_delete_nhan_vien_Click;
            m_fg_nhan_vien.AfterAddRow += m_fg_nhan_vien_AfterAddRow;

            m_cmd_delete_quyet_dinh.Click += m_cmd_delete_quyet_dinh_Click;
            m_fg_quyet_dinh.AfterAddRow += m_fg_quyet_dinh_AfterAddRow;
            m_fg_quyet_dinh.CellButtonClick += m_fg_quyet_dinh_CellButtonClick;
            m_fg_quyet_dinh.DoubleClick += m_fg_quyet_dinh_DoubleClick;
        }

        private void m_fg_quyet_dinh_DoubleClick(object sender, EventArgs eventArgs)
        {
            try
            {
                view_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_fg_quyet_dinh_CellButtonClick(object sender, RowColEventArgs e)
        {
            try
            {
                chon_file(e);
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_fg_quyet_dinh_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            CGridUtils.MakeSoTT(0, m_fg_quyet_dinh);
        }

        void m_cmd_delete_quyet_dinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_fg_quyet_dinh.Rows.Count == 3)
                {
                    return;
                }
                m_fg_quyet_dinh.Rows.Remove(m_fg_quyet_dinh.Row);
                CGridUtils.MakeSoTT(0, m_fg_quyet_dinh);
            }
            catch (System.Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_delete_nhan_vien_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_fg_nhan_vien.Rows.Count == 3)
                {
                    return;
                }
                m_fg_nhan_vien.Rows.Remove(m_fg_nhan_vien.Row);
                CGridUtils.MakeSoTT(0, m_fg_nhan_vien);
            }
            catch (System.Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_fg_nhan_vien_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            CGridUtils.MakeSoTT(0, m_fg_nhan_vien);
        }

        void m_txt_search_nhan_vien_Leave(object sender, EventArgs e)
        {
            try
            {
                select_nhan_vien();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_txt_search_nhan_vien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    select_nhan_vien();
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void f500_dm_du_an_detail_Load(object sender, EventArgs e)
        {
            try
            {
                set_initial_form_load();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_save_Click(object sender, EventArgs e)
        {
            try
            {
                save_data();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                refresh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void m_fg_nhan_vien_CellButtonClick(object sender, RowColEventArgs e)
        {
            
            

        }

        private void m_fg_nhan_vien_Click(object sender, EventArgs e)
        {
            string v_strs;
            
            if (m_fg_nhan_vien.Rows[m_fg_nhan_vien.CursorCell.TopRow][(int)e_col_Number_nhan_vien.MA_NV] == null)
                v_strs = "";
            else
                v_strs = m_fg_nhan_vien.Rows[m_fg_nhan_vien.CursorCell.TopRow][(int)e_col_Number_nhan_vien.MA_NV].ToString();
            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
            v_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds_dm_nhan_su, v_strs.Trim());
            if (v_ds_dm_nhan_su.Tables[0].Rows.Count == 0)
                return;
            m_lbl_ma_nhan_vien.Text = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.MA_NV].ToString();
            m_lbl_ho_va_ten.Text = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.HO_DEM] + " " +
                                   v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.TEN];
            //m_lbl_ngay_sinh.Text = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.NGAY_SINH].ToString().Split(' ')[0];
            //m_lbl_dia_chi.Text = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.CHO_O].ToString();

            // DucVT
            m_lbl_email_ca_nhan.Text = v_ds_dm_nhan_su.Tables[0].Rows[0][DM_NHAN_SU.EMAIL_CQ].ToString();

            // Lấy chức vụ bằng Id nhân sự
            DS_V_GD_QUA_TRINH_LAM_VIEC v_ds_gd_qtlv = new DS_V_GD_QUA_TRINH_LAM_VIEC();
            US_V_GD_QUA_TRINH_LAM_VIEC v_us_gd_qtlv = new US_V_GD_QUA_TRINH_LAM_VIEC();

            v_us_gd_qtlv.FillDataSet_Now_By_Ma_NV_Id_PN(v_ds_gd_qtlv, v_ds_dm_nhan_su.DM_NHAN_SU.Rows[0][DM_NHAN_SU.MA_NV].ToString(), CAppContext_201.getCurrentIDPhapnhan());

            if (v_ds_gd_qtlv.V_GD_QUA_TRINH_LAM_VIEC.Rows.Count > 0)
            {
                m_lbl_chuc_vu.Text = v_ds_gd_qtlv.V_GD_QUA_TRINH_LAM_VIEC.Rows[0][V_GD_QUA_TRINH_LAM_VIEC.MA_CV].ToString();
                m_lbl_don_vi.Text = v_ds_gd_qtlv.V_GD_QUA_TRINH_LAM_VIEC.Rows[0][V_GD_QUA_TRINH_LAM_VIEC.MA_DON_VI].ToString();
            }
            // ~DucVT
        }
    }
}

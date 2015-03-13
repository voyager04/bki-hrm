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
using IP.Core.IPExcelReport;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;

namespace BKI_HRM
{
    public partial class f408_bao_cao_don_vi_trang_thai : Form
    {
        public f408_bao_cao_don_vi_trang_thai()
        {
            InitializeComponent();
            format_controls();
        }
        public void refresh()
        {
            load_data_2_grid_donvi();
            //load_data_2_grid();
        }
        public delegate void close_tab(bool ip_y_n);
        public close_tab close_tab_B;

        #region Members
        AlertForm alert;
        ITransferDataRow m_obj_trans;
        private bool load_invisible = true;
        //DS_V_DM_DON_VI m_ds_v_dm_don_vi = new DS_V_DM_DON_VI();
        //US_V_DM_DON_VI m_us_v_dm_don_vi = new US_V_DM_DON_VI();

        DS_V_GD_QUA_TRINH_LAM_VIEC_2 m_ds_v_qtlv2 = new DS_V_GD_QUA_TRINH_LAM_VIEC_2();
        US_V_GD_QUA_TRINH_LAM_VIEC_2 m_us_v_qtlv2 = new US_V_GD_QUA_TRINH_LAM_VIEC_2();
        //IP.Core.IPUserService.US_CM_DM_TU_DIEN m_us_dm_tu_dien = new IP.Core.IPUserService.US_CM_DM_TU_DIEN();
        //IP.Core.IPData.DS_CM_DM_TU_DIEN m_ds_dm_tu_dien = new IP.Core.IPData.DS_CM_DM_TU_DIEN();
        DS_RPT_DON_VI_TRANG_THAI m_ds_rpt_dv_tt = new DS_RPT_DON_VI_TRANG_THAI();
        US_RPT_DON_VI_TRANG_THAI m_us_rpt_dv_tt = new US_RPT_DON_VI_TRANG_THAI();
        private const String m_str_goi_y_tim_kiem = "Nhập Họ tên, Mã nhân viên...";
        #endregion
        #region Data Structure

        private enum e_col_Number
        {
            EMAIL_CQ = 28
,
            TEN_DON_VI = 25
                ,
            MA_NV = 1
                ,
            NGAY_KET_THUC = 15
                ,
            NGAY_BAT_DAU = 14
                ,
            TRANG_THAI_CV = 24
                ,
            LOAI_CV = 11
                ,
            MA_QUYET_DINH = 16
                ,
            DIA_BAN = 26
                ,
            TEN = 3
                ,
            LOAI_QD = 19
                ,
            NGAY_CO_HIEU_LUC = 17
                ,
            MA_DON_VI = 7
                ,
            MA_DON_VI_CAP_TREN = 8
                ,
            MA_TTLD = 12
                ,
            HO_DEM = 2
                ,
            TY_LE_THAM_GIA = 13
                ,
            NGAY_HET_HIEU_LUC_LD = 23
                ,
            NGAY_CO_HIEU_LUC_LD = 22
                ,
            NGAY_HET_HIEU_LUC = 18
                ,
            DI_DONG = 29
                ,
            TRANG_THAI_LD_HIEN_TAI = 21
                ,
            CHO_O = 30
                ,
            MA_HEADCOUNT = 31
                ,
            MA_CV = 24
                ,
            BAC = 6
                ,
            MA_QUYET_DINH_MIEN_NHIEM = 20
                ,
            NGACH = 5
                ,
            GIOI_TINH = 27
                ,
            MA_PHAP_NHAN = 4
              ,
            NGAY_SINH = 32
                ,
            NGHE_NGHIEP_CON_THU_3 = 68
                ,
            NGHE_NGHIEP_CON_THU_2 = 65
                ,
            NGUOI_LIEN_HE = 45
                ,
            NGHE_NGHIEP_BO = 56
                ,
            TRANG_THAI = 51
                ,

            NAM_SINH_CON_THU_2 = 66
                ,

            CHI_NHANH_NGANHANG = 53
                ,
            NAM_SINH_VO_OR_CHONG = 72
                ,
            EMAIL_CA_NHAN = 42
                ,

            SO_TAI_KHOAN = 52
                ,
            TON_GIAO = 48
                ,
            HO_TEN_ME = 58
                ,
            NOI_SINH = 33
                ,
            NAM_SINH_CON_THU_3 = 69
                ,
            NGHE_NGHIEP_ME = 59
                ,
            TRINH_DO = 38
                ,
            QUAN_HE = 47
                ,
            HO_KHAU = 44
                ,
            NOI_DAO_TAO = 39
                ,
            MA_SO_THUE = 50
                ,
            DT_NHA = 43
                ,
            NGAY_CAP_CMND = 36
                ,
            HO_TEN_CON_THU_2 = 64
                ,
            NGHE_NGHIEP_CON_THU_1 = 62
                ,
            NAM_SINH_CON_THU_1 = 63
                ,
            CHUYEN_NGANH = 40
                ,
            HO_TEN_VO_OR_CHONG = 70
                ,
            NAM_SINH_BO = 57
                ,
            HO_TEN_CON_THU_1 = 61
                ,
            DI_DONG_LIEN_HE = 46
                ,
            HO_TEN_BO = 55
                ,
            HO_TEN_CON_THU_3 = 67
                ,
            NAM_TOT_NGHIEP = 41
                ,
            DIA_DIEM_LV = 54
                ,
            NOI_CAP_CMND = 37
                ,
            NGHE_NGHIEP_VO_OR_CHONG = 71
                ,
            NAM_SINH_ME = 60
                ,
            CMND = 35
                ,
            NGUYEN_QUAN = 34
                , DAN_TOC = 49
            ,ID_CAP_DON_VI = 73
            ,MA_PHONG = 9
            ,MA_DON_VI_2 = 10
        }			
        const int m_width_col = 10;
        #endregion
        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg_donvi);
            CGridUtils.AddSave_Excel_Handlers(m_fg_donvi);
            CGridUtils.AddSearch_Handlers(m_fg_donvi);
            //splitContainer1.Height = this.Height - m_pnl_out_place_dm.Height - 50;
            m_fg_donvi.Tree.Column = 1;
            m_fg_donvi.Tree.Style = TreeStyleFlags.SimpleLeaf;
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            m_fg.Tree.Column = (int)e_col_Number.MA_DON_VI;
            m_fg.Tree.Style = TreeStyleFlags.SimpleLeaf;
            //set_define_events();
            this.KeyPreview = true;

        }
        private void set_initial_form_load()
        {
            m_obj_trans = get_trans_object(m_fg);
            
            set_search_format_before();
            load_custom_source_2_m_txt_search();
            load_data_2_grid_donvi();
            //load_data_2_grid();
            //m_txt_tim_kiem.Text = "Nhập mã chức vụ, tên chức vụ";
        }
        private void set_search_format_before()
        {
            if (m_txt_search.Text == "")
            {
                m_txt_search.Text = m_str_goi_y_tim_kiem;
                m_txt_search.ForeColor = Color.Gray;
            }
        }
        private void set_search_format_after()
        {
            if (m_txt_search.Text == m_str_goi_y_tim_kiem)
            {
                m_txt_search.Text = "";
            }
            m_txt_search.ForeColor = Color.Black;
        }
        private void load_custom_source_2_m_txt_search()
        {
            m_txt_search.AutoCompleteMode = AutoCompleteMode.Suggest;
            m_txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var v_coll = new AutoCompleteStringCollection();
            var v_rows = m_ds_v_qtlv2.Tables[0].Rows;
            for (var i = 0; i < v_rows.Count - 1; i++)
            {
                v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.HO_DEM] + " " + v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN]);
                v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.TEN] + "");
                //v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.MA_DON_VI] + "");
                v_coll.Add(v_rows[i][V_GD_QUA_TRINH_LAM_VIEC_2.MA_NV] + "");
            }

            m_txt_search.AutoCompleteCustomSource = v_coll;
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
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_DV_CAP_TREN, e_col_Number.MA_DON_VI_CAP_TREN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.ID_CAP_DON_VI, e_col_Number.ID_CAP_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGHE_NGHIEP_CON_THU_3, e_col_Number.NGHE_NGHIEP_CON_THU_3);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGHE_NGHIEP_CON_THU_2, e_col_Number.NGHE_NGHIEP_CON_THU_2);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGUOI_LIEN_HE, e_col_Number.NGUOI_LIEN_HE);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGHE_NGHIEP_BO, e_col_Number.NGHE_NGHIEP_BO);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TRANG_THAI, e_col_Number.TRANG_THAI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NAM_SINH_CON_THU_2, e_col_Number.NAM_SINH_CON_THU_2);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.CHI_NHANH_NGANHANG, e_col_Number.CHI_NHANH_NGANHANG);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NAM_SINH_VO_OR_CHONG, e_col_Number.NAM_SINH_VO_OR_CHONG);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.EMAIL_CA_NHAN, e_col_Number.EMAIL_CA_NHAN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.SO_TAI_KHOAN, e_col_Number.SO_TAI_KHOAN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TON_GIAO, e_col_Number.TON_GIAO);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.HO_TEN_ME, e_col_Number.HO_TEN_ME);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NOI_SINH, e_col_Number.NOI_SINH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NAM_SINH_CON_THU_3, e_col_Number.NAM_SINH_CON_THU_3);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGHE_NGHIEP_ME, e_col_Number.NGHE_NGHIEP_ME);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TRINH_DO, e_col_Number.TRINH_DO);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.QUAN_HE, e_col_Number.QUAN_HE);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.HO_KHAU, e_col_Number.HO_KHAU);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NOI_DAO_TAO, e_col_Number.NOI_DAO_TAO);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_SO_THUE, e_col_Number.MA_SO_THUE);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.DT_NHA, e_col_Number.DT_NHA);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_CAP_CMND, e_col_Number.NGAY_CAP_CMND);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.HO_TEN_CON_THU_2, e_col_Number.HO_TEN_CON_THU_2);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGHE_NGHIEP_CON_THU_1, e_col_Number.NGHE_NGHIEP_CON_THU_1);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NAM_SINH_CON_THU_1, e_col_Number.NAM_SINH_CON_THU_1);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_SINH, e_col_Number.NGAY_SINH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.CHUYEN_NGANH, e_col_Number.CHUYEN_NGANH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.HO_TEN_VO_OR_CHONG, e_col_Number.HO_TEN_VO_OR_CHONG);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NAM_SINH_BO, e_col_Number.NAM_SINH_BO);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.HO_TEN_CON_THU_1, e_col_Number.HO_TEN_CON_THU_1);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.DI_DONG_LIEN_HE, e_col_Number.DI_DONG_LIEN_HE);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.HO_TEN_BO, e_col_Number.HO_TEN_BO);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.HO_TEN_CON_THU_3, e_col_Number.HO_TEN_CON_THU_3);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NAM_TOT_NGHIEP, e_col_Number.NAM_TOT_NGHIEP);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.DIA_DIEM_LV, e_col_Number.DIA_DIEM_LV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NOI_CAP_CMND, e_col_Number.NOI_CAP_CMND);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGHE_NGHIEP_VO_OR_CHONG, e_col_Number.NGHE_NGHIEP_VO_OR_CHONG);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NAM_SINH_ME, e_col_Number.NAM_SINH_ME);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.CMND, e_col_Number.CMND);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGUYEN_QUAN, e_col_Number.NGUYEN_QUAN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.DAN_TOC, e_col_Number.DAN_TOC);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds_v_qtlv2.V_GD_QUA_TRINH_LAM_VIEC_2.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid()
        {
            decimal v_kiem_nhiem;
            if (m_ckb_kiem_nhiem.Checked)
                v_kiem_nhiem = -1;
            else
                v_kiem_nhiem = 650;
            m_ds_v_qtlv2 = new DS_V_GD_QUA_TRINH_LAM_VIEC_2();
            var v_str_search = m_fg_donvi.Rows[m_fg_donvi.Row][2].ToString();
            /*var v_str_search = m_txt_search.Text.Trim();
            if (v_str_search.Equals(m_str_goi_y_tim_kiem))
            {
                v_str_search = "";
            }*/

            var v_dat_thoi_diem = DateTime.Now;
            if (m_dat_thoidiem.Checked)
            {
                v_dat_thoi_diem = m_dat_thoidiem.Value.Date;
            }


            m_us_v_qtlv2.FillDatase_NhanSu_TheoPhongBan(m_ds_v_qtlv2, v_str_search, v_dat_thoi_diem, CAppContext_201.getCurrentIDPhapnhan(), v_kiem_nhiem);
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds_v_qtlv2, m_fg, m_obj_trans);
            /**
             * Group (subtotal) trên grid.
             */
            //m_fg.Subtotal(AggregateEnum.Count, -1, 0, (int)e_col_Number.MA_NV, "Tổng");
            for (int i = 1; i < m_fg.Rows.Count; i++) {
                if (m_fg.Rows[i][(int)e_col_Number.ID_CAP_DON_VI].ToString() == "642") {
                    m_fg.Rows[i][(int)e_col_Number.MA_PHONG] = m_fg.Rows[i][(int)e_col_Number.MA_DON_VI];
                    m_fg.Rows[i][(int)e_col_Number.MA_DON_VI_2] = m_fg.Rows[i][(int)e_col_Number.MA_DON_VI_CAP_TREN];
                }
                else
                    m_fg.Rows[i][(int)e_col_Number.MA_DON_VI_2] = m_fg.Rows[i][(int)e_col_Number.MA_DON_VI];
            }
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
            m_us_v_qtlv2.count_nhan_vien_theo_phong_ban(m_ds_v_qtlv2, v_str_search, v_dat_thoi_diem, ref count, CAppContext_201.getCurrentIDPhapnhan(), v_kiem_nhiem);
            m_lbl_so_luong_ban_ghi.Text = CIPConvert.ToStr(count);
            // m_lbl_thong_bao.Text = m_fg.ColumnInfo;
        }
        private void insert_all_child_of_node(int i_grid_row, DS_V_DM_DON_VI ip_ds_don_vi)
        {
            //US_V_DM_DON_VI v_us_dm_don_vi = new US_V_DM_DON_VI();
            //grid2us_object(v_us_dm_don_vi, i_grid_row);

            DataRow[] v_arr_dr_child = ip_ds_don_vi.V_DM_DON_VI.Select(V_DM_DON_VI.ID_DON_VI_CAP_TREN + "=" + m_fg_donvi.Rows[i_grid_row].UserData.ToString());
            foreach (DataRow v_dr in v_arr_dr_child)
            {
                US_V_DM_DON_VI v_us_dm_don_vi_child = new US_V_DM_DON_VI();
                v_us_dm_don_vi_child.DataRow2Me(v_dr);
                int v_i_child_row = -1;
                insert_child_node(
                    v_us_dm_don_vi_child
                    , ip_ds_don_vi
                    , i_grid_row
                    , ref v_i_child_row);
                insert_all_child_of_node(v_i_child_row, ip_ds_don_vi);

            }

        }
        private void us_object_2_grid(US_V_DM_DON_VI i_us_object, DS_V_DM_DON_VI i_ds
            , int i_grid_row)
        {
            if (m_fg_donvi.Rows[i_grid_row].UserData == null)
            {
                m_fg_donvi.Rows[i_grid_row].UserData = i_ds.Tables[0].NewRow();
            }
            DataRow v_dr = (DataRow)m_fg_donvi.Rows[i_grid_row].UserData;
            i_us_object.Me2DataRow(v_dr);
            m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
        }
        private void insert_child_node(US_V_DM_DON_VI i_us_object
            , DS_V_DM_DON_VI i_ds
            , int i_parent_row
            , ref int i_row_result
            )
        {

            int v_i_new_grid_row;
            //Lay nut hien tai 
            Node v_current_node = m_fg_donvi.Rows[i_parent_row].Node;
            Node v_node_4_index;
            int v_i_level;
            //Neu them kieu nut la sibling cua nut hien tai            
            v_node_4_index = v_current_node;
            v_i_level = int.Parse(i_us_object.dcID_LEVEL.ToString());
            Node v_last_child = v_node_4_index.GetNode(NodeTypeEnum.LastChild);
            while (v_last_child != null)
            {
                v_node_4_index = v_last_child;
                v_last_child = v_node_4_index.GetNode(NodeTypeEnum.LastChild);
            }
            v_i_new_grid_row = v_node_4_index.Row.Index + 1;
            m_fg_donvi.Rows.Insert(v_i_new_grid_row);
            //us_object_2_grid(i_us_object, i_ds, v_i_new_grid_row);
            m_fg_donvi.Rows[v_i_new_grid_row][1] = i_us_object.strMA_DON_VI_CAP_TREN.ToString();
            m_fg_donvi.Rows[v_i_new_grid_row][2] = i_us_object.strMA_DON_VI.ToString();
            m_fg_donvi.Rows[v_i_new_grid_row].UserData = i_us_object.dcID;
            m_fg_donvi.Rows[v_i_new_grid_row].IsNode = true;
            m_fg_donvi.Rows[v_i_new_grid_row].Node.Level = v_i_level;

            switch (v_i_level)
            {
                case 0:
                    m_fg_donvi.Rows[v_i_new_grid_row].Style = m_fg_donvi.Styles[CellStyleEnum.Subtotal0];
                    break;
                case 1:
                    m_fg_donvi.Rows[v_i_new_grid_row].Style = m_fg_donvi.Styles[CellStyleEnum.Subtotal1];
                    break;
                case 2:
                    m_fg_donvi.Rows[v_i_new_grid_row].Style = m_fg_donvi.Styles[CellStyleEnum.Subtotal2];
                    break;
                case 3:
                    m_fg_donvi.Rows[v_i_new_grid_row].Style = m_fg_donvi.Styles[CellStyleEnum.Subtotal3];
                    break;

            }

            i_row_result = v_i_new_grid_row;
        }
        private void tao_cot_trang_thai_grid_don_vi(IP.Core.IPData.DS_CM_DM_TU_DIEN ip_ds_tu_dien)
        {
            m_fg_donvi.Cols.Count = ip_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count + 4;
            m_fg_donvi.Cols[1].Caption = "Mã đơn vị cấp trên";
            m_fg_donvi.Cols[1].Visible = false;
            m_fg_donvi.Cols[2].Caption = "Mã đơn vị";
            m_fg_donvi.Cols[3].Caption = "Tổng";
            m_fg_donvi.Cols[3].UserData = 0;
            //m_fg.Cols[1].Style.ForeColor = Color.Black; 
            for (int i = 4; i < m_fg_donvi.Cols.Count; i++)
            {
                m_fg_donvi.Cols[i].Caption = ip_ds_tu_dien.CM_DM_TU_DIEN.Rows[i - 4][3].ToString();
                m_fg_donvi.Cols[i].UserData = ip_ds_tu_dien.CM_DM_TU_DIEN.Rows[i - 4][0];
            }
        }
        private void tao_dong_don_vi_grid_don_vi()
        {
            DS_V_DM_DON_VI v_ds_v_dm_don_vi = new DS_V_DM_DON_VI();
            US_V_DM_DON_VI v_us_v_dm_don_vi = new US_V_DM_DON_VI();
            v_us_v_dm_don_vi.FillDatasetByKeyWord(v_ds_v_dm_don_vi, "Y", CAppContext_201.getCurrentIDPhapnhan());
            int v_minID_LEVEL = int.Parse(v_ds_v_dm_don_vi.V_DM_DON_VI.Compute("Min(ID_LEVEL)", "").ToString());
            DataRow[] v_dr = v_ds_v_dm_don_vi.V_DM_DON_VI.Select(V_DM_DON_VI.ID_LEVEL + "=" + v_minID_LEVEL.ToString());
            if (v_dr.Length == 0) return;
            CGridUtils.ClearDataInGrid(m_fg_donvi);
            v_us_v_dm_don_vi.DataRow2Me(v_dr[0]);
            m_fg_donvi.Rows.Count += 1;
            int v_i_root_row = m_fg_donvi.Rows.Count - 1;
            //m_fg.Rows.Count = m_ds_1.V_DM_DON_VI.Rows.Count + 1;
            //int v_i_root_row = 1;
            m_fg_donvi.Rows[v_i_root_row].IsNode = true;
            m_fg_donvi.Rows[v_i_root_row].Node.Level = int.Parse(v_us_v_dm_don_vi.dcID_LEVEL.ToString());
            switch (m_fg_donvi.Rows[v_i_root_row].Node.Level)
            {
                case 0:
                    m_fg_donvi.Rows[v_i_root_row].Style = m_fg_donvi.Styles[CellStyleEnum.Subtotal0];
                    break;
                case 1:
                    m_fg_donvi.Rows[v_i_root_row].Style = m_fg_donvi.Styles[CellStyleEnum.Subtotal1];
                    break;
                case 2:
                    m_fg_donvi.Rows[v_i_root_row].Style = m_fg_donvi.Styles[CellStyleEnum.Subtotal2];
                    break;
                case 3:
                    m_fg_donvi.Rows[v_i_root_row].Style = m_fg_donvi.Styles[CellStyleEnum.Subtotal3];
                    break;

            }
            m_fg_donvi.Rows[1][1] = v_us_v_dm_don_vi.strMA_DON_VI_CAP_TREN;
            m_fg_donvi.Rows[1][2] = v_us_v_dm_don_vi.strMA_DON_VI;
            m_fg_donvi.Rows[1].UserData = v_us_v_dm_don_vi.dcID;
            insert_all_child_of_node(v_i_root_row, v_ds_v_dm_don_vi);
        }
        private void khoi_tao_grid_don_vi()
        {

            m_fg_donvi.Clear();
            m_fg_donvi.Cols[0].Width = m_width_col;
            //DS_V_DM_DON_VI v_ds_v_dm_don_vi = new DS_V_DM_DON_VI();
            //US_V_DM_DON_VI v_us_v_dm_don_vi = new US_V_DM_DON_VI();
            IP.Core.IPUserService.US_CM_DM_TU_DIEN v_us_dm_tu_dien = new IP.Core.IPUserService.US_CM_DM_TU_DIEN();
            IP.Core.IPData.DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new IP.Core.IPData.DS_CM_DM_TU_DIEN();
            v_us_dm_tu_dien.FillDataset(v_ds_dm_tu_dien, "WHERE Id_loai_tu_dien = 5");
            //1.tạo danh sách cột trạng thái
            tao_cot_trang_thai_grid_don_vi(v_ds_dm_tu_dien);
            //m_fg.Cols[0].Width = 150;
            //m_fg.Cols[1].Caption = "Trạng thái/Chức vụ";
            
            
            //2. tạo danh sách dòng trạng thái
            tao_dong_don_vi_grid_don_vi();
            //v_ds_v_dm_don_vi.Clear();
        }
        private void load_data_2_grid_donvi()
        {
            khoi_tao_grid_don_vi();
            //3.Đưa dữ liệu lên lưới
            m_ds_rpt_dv_tt = new DS_RPT_DON_VI_TRANG_THAI();
            m_us_rpt_dv_tt.FillDatasetByProc(m_ds_rpt_dv_tt, m_dat_thoidiem.Value.Date, CAppContext_201.getCurrentIDPhapnhan());


            for (int v_i_cur_col = m_fg_donvi.Cols.Fixed+3; v_i_cur_col < m_fg_donvi.Cols.Count; v_i_cur_col++)
            {
                //if((int.Parse(row[1].ToString())) == (int.Parse(m_fg.Cols[u].UserData.ToString())))
                for (int v_i_cur_row = m_fg_donvi.Rows.Fixed; v_i_cur_row < m_fg_donvi.Rows.Count; v_i_cur_row++)
                {
                    string v_str_id_trang_thai = m_fg_donvi.Cols[v_i_cur_col].UserData.ToString();
                    string v_str_id_don_vi = m_fg_donvi.Rows[v_i_cur_row].UserData.ToString();


                    DataRow[] v_arr_dr
                        = m_ds_rpt_dv_tt.RPT_DON_VI_TRANG_THAI.Select(
                        RPT_DON_VI_TRANG_THAI.ID_TRANG_THAI + "="
                        + v_str_id_trang_thai
                        + " AND "
                        + RPT_DON_VI_TRANG_THAI.ID_DV + "="
                        + v_str_id_don_vi);
                    if (v_arr_dr.Length == 0) continue;
                    m_fg_donvi[v_i_cur_row, v_i_cur_col] = v_arr_dr[0][RPT_DON_VI_TRANG_THAI.SO_LUONG];
                }
            }
            for (int v = 1; v < m_fg_donvi.Rows.Count; v++)
            {
                int sum = 0;
                for (int t = 4; t < m_fg_donvi.Cols.Count; t++)
                    sum += Convert.ToInt32(m_fg_donvi.Rows[v][t]);
                m_fg_donvi.Rows[v][3] = sum;
            }
            m_fg_donvi.Redraw = false;
            m_fg_donvi.Redraw = true;
        }


        private void export_2_excel()
        {
            CExcelReport v_obj_excel_rpt = new CExcelReport("f408_bao_cao_don_vi_trang_thai.xlsx", 3, 2);
            v_obj_excel_rpt.AddFindAndReplaceItem("<thoi_diem>", m_dat_thoidiem.Value.Date);
            v_obj_excel_rpt.FindAndReplace(false);
            v_obj_excel_rpt.Export2ExcelWithoutFixedRows(m_fg_donvi, 1, m_fg_donvi.Cols.Count - 1, true);
        }
        #endregion

        private void f408_bao_cao_don_vi_trang_thai_Load(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorker1.IsBusy != true)
                {
                    // create a new instance of the alert form
                    alert = new AlertForm();
                    // event handler for the Cancel button in AlertForm
                    //alert.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
                    alert.Show();
                    alert.TopMost = true;
                    // Start the asynchronous operation.
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_dat_thoidiem_ValueChanged(object sender, EventArgs e)
        {
            try
            {
               load_data_2_grid_donvi();
               load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            try
            {
                close_tab_B(true);

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

        private void m_fg_donvi_Click(object sender, EventArgs e)
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= 1; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    worker.ReportProgress(i * 10);
                    //System.Threading.Thread.Sleep(500);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                alert.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%";
                alert.ProgressValue = e.ProgressPercentage;
            }
            set_initial_form_load();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            alert.Close();
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
    }
}

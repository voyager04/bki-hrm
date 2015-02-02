using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using BKI_HRM.NghiepVu;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using System.Diagnostics;
using System.Configuration;
using System.IO;

using C1.Win.C1FlexGrid;

namespace BKI_HRM.DanhMuc
{
    public partial class f410_chuyen_nhan_vien : Form
    {
        public f410_chuyen_nhan_vien()
        {
            InitializeComponent();
            format_controls();
        }
        #region Public Interface
        public void display()
        {
            ShowDialog();
        }
        #endregion

        #region Data Structure

        private enum e_col_Number
        {
            LOAI_DON_VI = 10
,
            TEN_DON_VI = 3
                ,
            MA_NV = 4
                ,
            NGAY_KET_THUC = 12
                ,
            NGAY_BAT_DAU = 11
                ,
            CAP_DON_VI = 9
                ,
            TRANG_THAI_CV = 19
                ,
            LOAI_CV = 17
                ,
            MA_QUYET_DINH = 13
                ,
            DIA_BAN = 1
                ,
            TEN = 6
                ,
            LOAI_QD = 14
                ,
            NGAY_CO_HIEU_LUC = 15
                ,
            MA_DON_VI = 2
                ,
            HO_DEM = 5
                ,
            TY_LE_THAM_GIA = 21
                ,
            TEN_CV = 8
                ,
            NGAY_HET_HIEU_LUC = 16
                ,
            TRANG_THAI_LD_HIEN_TAI = 22
                ,
            MA_CV = 7
                ,
            MA_QUYET_DINH_MIEN_NHIEM = 20
                , NGACH = 18

        }
        #endregion

        #region Members
        ITransferDataRow m_obj_trans;
        DS_V_GD_QUA_TRINH_LAM_VIEC_2 m_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC_2();
        US_V_GD_QUA_TRINH_LAM_VIEC_2 m_us = new US_V_GD_QUA_TRINH_LAM_VIEC_2();
        US_V_GD_QUA_TRINH_LAM_VIEC m_us_v_qua_trinh_lam_viec = new US_V_GD_QUA_TRINH_LAM_VIEC();
        DS_V_GD_QUA_TRINH_LAM_VIEC m_ds_v_qua_trinh_lam_viec = new DS_V_GD_QUA_TRINH_LAM_VIEC();
        US_GD_CHI_TIET_CHUC_VU m_us_chi_tiet_chuc_vu = new US_GD_CHI_TIET_CHUC_VU();
        US_DM_DON_VI m_us_dm_don_vi = new US_DM_DON_VI();
        US_DM_QUYET_DINH m_us_quyet_dinh = new US_DM_QUYET_DINH();
        DS_DM_QUYET_DINH m_ds_quyet_dinh = new DS_DM_QUYET_DINH();
       
        decimal id_nhan_su;
        bool m_b_check_quyet_dinh_null = false;
        bool m_b_check_quyet_dinh_save;
        bool m_b_check_is_mien_nhiem = false;
        string v_str_search;
        private DataEntryFileMode m_e_file_mode;
        private string m_str_domain = ConfigurationSettings.AppSettings["DOMAIN"];
        private string m_str_directory_to = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private string m_str_user_name = ConfigurationSettings.AppSettings["USERNAME_SHARE"];
        private string m_str_password = ConfigurationSettings.AppSettings["PASSWORD_SHARE"];
        private decimal m_str_id_hop_dong_old;
        private string m_str_link_old;
        #endregion

        #region Private Methods

        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            //m_fg.Tree.Column = (int)e_col_Number.DIA_BAN;
            //m_fg.Tree.Style = TreeStyleFlags.SimpleLeaf;
            
            set_define_events();
            KeyPreview = true;
        }
        private void set_initial_form_load()
        {
            m_obj_trans = get_trans_object(m_fg);
            load_data_to_cbo_chuc_vu();
            load_custom_source_2_m_txt_don_vi();
            load_cbo_ma_quyet_dinh();
            load_data_2_grid();
        }
        private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.LOAI_DON_VI, e_col_Number.LOAI_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TEN_DON_VI, e_col_Number.TEN_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_KET_THUC, e_col_Number.NGAY_KET_THUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_BAT_DAU, e_col_Number.NGAY_BAT_DAU);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.CAP_DON_VI, e_col_Number.CAP_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TRANG_THAI_CV, e_col_Number.TRANG_THAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.LOAI_CV, e_col_Number.LOAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_QUYET_DINH, e_col_Number.MA_QUYET_DINH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.DIA_BAN, e_col_Number.DIA_BAN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TEN, e_col_Number.TEN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.LOAI_QD, e_col_Number.LOAI_QD);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_CO_HIEU_LUC, e_col_Number.NGAY_CO_HIEU_LUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_DON_VI, e_col_Number.MA_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.HO_DEM, e_col_Number.HO_DEM);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TY_LE_THAM_GIA, e_col_Number.TY_LE_THAM_GIA);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TEN_CV, e_col_Number.TEN_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGAY_HET_HIEU_LUC, e_col_Number.NGAY_HET_HIEU_LUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.TRANG_THAI_LD_HIEN_TAI, e_col_Number.TRANG_THAI_LD_HIEN_TAI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_CV, e_col_Number.MA_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.MA_QUYET_DINH_MIEN_NHIEM, e_col_Number.MA_QUYET_DINH_MIEN_NHIEM);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC_2.NGACH, e_col_Number.NGACH);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds.V_GD_QUA_TRINH_LAM_VIEC_2.NewRow());
            return v_obj_trans;
        }
        public void display_for_dm_don_vi(String v_str_ma_dv)
        {
            v_str_search = v_str_ma_dv;
            this.Show();
        }
        private void load_data_2_grid()
        {
            decimal v_kiem_nhiem;
            if (m_ckb_kiem_nhiem.Checked)
                v_kiem_nhiem = -1;
            else
                v_kiem_nhiem = 650;
            m_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC_2();
            var v_dat_thoi_diem = DateTime.Now;
            if (m_dtp_thoidiem.Checked)
            {
                v_dat_thoi_diem = m_dtp_thoidiem.Value;
            }
            m_us.FillDatase_NhanSu_TheoPhongBan(m_ds, v_str_search, v_dat_thoi_diem, CAppContext_201.getCurrentIDPhapnhan(), v_kiem_nhiem);
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            m_fg.Redraw = true;
            decimal count = 0;
            m_us.count_nhan_vien_theo_phong_ban(m_ds, v_str_search, v_dat_thoi_diem, ref count, CAppContext_201.getCurrentIDPhapnhan(), v_kiem_nhiem);
            m_lbl_so_luong_ban_ghi.Text = CIPConvert.ToStr(count);
            // m_lbl_thong_bao.Text = m_fg.ColumnInfo;
        }
        private void us_object_to_form()
        {
            m_txt_ma_nv.Text = m_us.strMA_NV;
            DS_DM_NHAN_SU m_ds_nhan_su = new DS_DM_NHAN_SU();
            US_DM_NHAN_SU m_us_nhan_su = new US_DM_NHAN_SU();
            m_us_nhan_su.FillDataset(m_ds_nhan_su, "WHERE MA_NV = N'" + m_txt_ma_nv.Text.ToString()+"'");
            id_nhan_su = decimal.Parse( m_ds_nhan_su.DM_NHAN_SU.Rows[0][0].ToString());
            m_txt_ho_ten.Text = m_us.strHO_DEM + " " + m_us.strTEN;
            m_txt_ma_nv.BackColor = SystemColors.Info;
            m_txt_ma_nv.ReadOnly = true;
            m_txt_ho_ten.BackColor = SystemColors.Info;
            m_txt_ho_ten.ReadOnly = true;
            BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds_loai_quyet_dinh = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
            BKI_HRM.US.US_CM_DM_TU_DIEN v_us_loai_quyet_dinh = new BKI_HRM.US.US_CM_DM_TU_DIEN();

            v_us_loai_quyet_dinh.FillDataset_load_loai_quyet_dinh(v_ds_loai_quyet_dinh, "Tất cả", "N");
            m_cbo_loai_quyet_dinh.DataSource = v_ds_loai_quyet_dinh.CM_DM_TU_DIEN;
            m_cbo_loai_quyet_dinh.DisplayMember = CM_DM_TU_DIEN.TEN;
            m_cbo_loai_quyet_dinh.ValueMember = CM_DM_TU_DIEN.ID;
        }
        private void grid2us_object(US_V_GD_QUA_TRINH_LAM_VIEC_2 i_us
            , int i_grid_row)
        {
            /*DataRow v_dr;
            v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            m_obj_trans.GridRow2DataRow(i_grid_row, v_dr);
            i_us.DataRow2Me(v_dr);*/
            
            i_us.strMA_NV = m_fg[i_grid_row, (int)e_col_Number.MA_NV].ToString();
            i_us.strHO_DEM = m_fg[i_grid_row, (int)e_col_Number.HO_DEM].ToString();
            i_us.strTEN = m_fg[i_grid_row, (int)e_col_Number.TEN].ToString();
        }
        private void load_data_to_cbo_chuc_vu()
        {

            DS_DM_CHUC_VU v_ds_chuc_vu = new DS_DM_CHUC_VU();
            US_DM_CHUC_VU v_us_chuc_vu = new US_DM_CHUC_VU();
            v_us_chuc_vu.FillDataset(v_ds_chuc_vu);
            m_cbo_chuc_vu_moi.DataSource = v_ds_chuc_vu.DM_CHUC_VU;
            m_cbo_chuc_vu_moi.DisplayMember = DM_CHUC_VU.TEN_CV;
            m_cbo_chuc_vu_moi.ValueMember = DM_CHUC_VU.ID;

            m_cbo_ma_chuc_vu_moi.DataSource = v_ds_chuc_vu.DM_CHUC_VU;
            m_cbo_ma_chuc_vu_moi.DisplayMember = DM_CHUC_VU.MA_CV;
            m_cbo_ma_chuc_vu_moi.ValueMember = DM_CHUC_VU.ID;
        }
        private void load_custom_source_2_m_txt_don_vi()
        {
            //  int count = m_ds_qua_trinh_lam_viec.Tables["V_GD_QUA_TRINH_LAM_VIEC"].Rows.Count;
            AutoCompleteStringCollection v_acsc_search = new AutoCompleteStringCollection();
            US_V_DM_DON_VI v_us = new US_V_DM_DON_VI();
            DS_V_DM_DON_VI v_ds = new DS_V_DM_DON_VI();
            v_us.Filldataset_by_ID_phap_nhan(v_ds, CAppContext_201.getCurrentIDPhapnhan());
            foreach (DataRow dr in v_ds.V_DM_DON_VI)
            {
                v_acsc_search.Add(dr[V_DM_DON_VI.MA_DON_VI].ToString());

            }

            m_txt_don_vi_moi.AutoCompleteMode = AutoCompleteMode.Suggest;
            m_txt_don_vi_moi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            m_txt_don_vi_moi.AutoCompleteCustomSource = v_acsc_search;
        }
        private void load_cbo_ma_quyet_dinh()
        {
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.MA_QUYET_DINH
                , WinFormControls.eTAT_CA.NO
                , m_cbo_ma_quyet_dinh);
        }
        private void text_changed()
        {
            US_V_DM_DON_VI v_us = new US_V_DM_DON_VI();
            DS_V_DM_DON_VI v_ds = new DS_V_DM_DON_VI();
            v_us.FillDataset_search_by_ma_dv(v_ds, m_txt_don_vi_moi.Text.Trim(),CAppContext_201.getCurrentIDPhapnhan());
            if (v_ds.V_DM_DON_VI.Count == 0)
            {
                //  BaseMessages.MsgBox_Error("Mã đơn vị không hợp lệ.");
            }
            else
            {
                if (v_ds.V_DM_DON_VI.Count == 1)
                {
                    v_us.DataRow2Me((DataRow)v_ds.V_DM_DON_VI.Rows[0]);
                    m_us_dm_don_vi = new US_DM_DON_VI(v_us.dcID);
                    m_txt_ma_don_vi_cap_tren.Text = v_us.strMA_DON_VI_CAP_TREN;
                }
            }
        }
        private void them_quyet_dinh()
        {
            m_b_check_quyet_dinh_null = true;
            m_b_check_quyet_dinh_save = true;
            m_grb_quyet_dinh.Enabled = true;
            m_txt_ma_quyet_dinh.Focus();
            m_txt_ma_quyet_dinh.Text = "";
            m_dat_ngay_ky.Value = DateTime.Today;
            m_dat_ngay_co_hieu_luc_qd.Value = DateTime.Today;
            m_dat_ngay_het_hieu_luc_qd.Value = DateTime.Today;
            m_cbo_loai_quyet_dinh.SelectedIndex = 0;
        }
        private void chon_quyet_dinh()
        {
            m_b_check_quyet_dinh_save = false;
            m_grb_quyet_dinh.Enabled = false;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data(CHON_QUYET_DINH.TAT_CA, ref m_us_quyet_dinh);
            if (m_us_quyet_dinh.dcID != -1)
            {
                //                 string[] v_arstr = m_us_quyet_dinh.strMA_QUYET_DINH.Trim().Split('/');
                //                 m_txt_ma_quyet_dinh.Text = v_arstr[0];
                //                 BKI_HRM.US.US_CM_DM_TU_DIEN v_us = new BKI_HRM.US.US_CM_DM_TU_DIEN();
                //                 BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
                //                 decimal v_dc_id = 0;
                //                 v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
                //                 m_cbo_ma_quyet_dinh.SelectedValue = v_dc_id;
                m_txt_ma_quyet_dinh.Text = m_us_quyet_dinh.strMA_QUYET_DINH;
                m_cbo_loai_quyet_dinh.SelectedValue = m_us_quyet_dinh.dcID_LOAI_QD;
                m_dat_ngay_ky.Value = m_us_quyet_dinh.datNGAY_KY;
                if (m_us_quyet_dinh.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900") &&
                    m_us_quyet_dinh.datNGAY_CO_HIEU_LUC != null)
                    m_dat_ngay_co_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_CO_HIEU_LUC;
                else
                    m_dat_ngay_co_hieu_luc_qd.Checked = false;
                if (m_us_quyet_dinh.datNGAY_HET_HIEU_LUC != null &&
                    m_us_quyet_dinh.datNGAY_HET_HIEU_LUC > DateTime.Parse("1/1/1900"))
                    m_dat_ngay_het_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_HET_HIEU_LUC;
                else
                    m_dat_ngay_het_hieu_luc_qd.Checked = false;
                m_txt_noi_dung.Text = m_us_quyet_dinh.strNOI_DUNG;
                m_ofd_chon_file.FileName = m_us_quyet_dinh.strLINK;

            }
            else
            {
                m_b_check_quyet_dinh_null = true;
            }
        }
        private void chon_file()
        {
            FileExplorer.SelectFile(m_ofd_chon_file, m_str_link_old);
            m_lbl_file_name.Text = FileExplorer.fileName;
        }
        private void view_quyet_dinh()
        {
            f701_v_gd_hop_dong_lao_dong_View frm = new f701_v_gd_hop_dong_lao_dong_View();
            frm.display(ConfigurationSettings.AppSettings["DESTINATION_NAME"] + m_us_quyet_dinh.strLINK);
        }
        private void xoa_trang()
        {
                    m_cbo_chuc_vu_moi.SelectedIndex = 0;
                    m_cbo_loai_quyet_dinh.SelectedIndex = 0;
                    m_cbo_ma_chuc_vu_moi.SelectedIndex = 0;
                    m_txt_don_vi_moi.Text = "";
                    m_txt_ma_quyet_dinh.Text = "";
                    m_txt_noi_dung.Text = "";
                    m_dat_ngay_bat_dau.Value = DateTime.Today;
                    m_dat_ngay_co_hieu_luc_qd.Value = DateTime.Today;
                    m_dat_ngay_het_hieu_luc_qd.Value = DateTime.Today;
                    m_dat_ngay_ky.Value = DateTime.Today;
                    m_dat_ngay_het_hieu_luc_qd.Checked = false;
        }
        private bool confirm_save_data()
        {
            US_DM_CHUC_VU v_us_dm_chuc_vu = new US_DM_CHUC_VU();
            DS_DM_CHUC_VU v_ds_dm_chuc_vu = new DS_DM_CHUC_VU();

            string v_str_chuc_vu = "";

            v_us_dm_chuc_vu.FillDatasetByID(v_ds_dm_chuc_vu, CIPConvert.ToDecimal(m_cbo_chuc_vu_moi.SelectedValue), ref v_str_chuc_vu);
            if (m_b_check_is_mien_nhiem)
            {
                if (BaseMessages.MsgBox_Confirm("Bạn có thực sự muốn miễn nhiệm chức vụ \"" + v_str_chuc_vu + "\" của " + m_us.strHO_DEM + " " + m_us.strTEN + "\" tại\n \"" + m_txt_don_vi_moi.Text + "\" không?"))
                {
                    if (BaseMessages.MsgBox_Confirm("Bạn có muốn miễn nhiệm chức vụ hiện tại của " + m_us.strHO_DEM + " " + m_us.strTEN + " không ?"))
                    {
                        mien_nhiem_chuc_vu();
                        return true;
                    }
                    else return false;
                }
                else
                    return false;
            }
            else
                if (BaseMessages.MsgBox_Confirm("Bạn có thực sự muốn thay đổi chức vụ của \"" + m_us.strHO_DEM + " " + m_us.strTEN + "\" thành\n \"" + v_str_chuc_vu + "\" tại \"" + m_txt_don_vi_moi.Text + "\" không?"))
                {
                    if (BaseMessages.MsgBox_Confirm("Bạn có muốn miễn nhiệm chức vụ hiện tại của " + m_us.strHO_DEM + " " + m_us.strTEN + " không ?"))
                    {
                        mien_nhiem_chuc_vu();
                        return true;
                    }
                    else return false;
                }
                else
                    return false;


        }
        private bool check_validate_data_is_ok()
        {
            if (m_us_dm_don_vi.dcID == -1)
            {
                BaseMessages.MsgBox_Infor("Bạn chưa chọn đơn vị của nhân viên.");
                return false;
            }
            
            if (m_dat_ngay_co_hieu_luc_qd.Value.Date > m_dat_ngay_het_hieu_luc_qd.Value.Date && m_dat_ngay_het_hieu_luc_qd.Checked == true)
            {
                BaseMessages.MsgBox_Infor("Ngày có hiệu lực không thể sau ngày hết hiệu lực.");
                return false;
            }
            /*if (!check_chuc_vu_chinh())
            {
                BaseMessages.MsgBox_Infor("Không thể tồn tại 2 chức vụ chính tại thời điểm hiện tại.");
                return false;
            }*/
            return true;
        }
        private bool check_chuc_vu_chinh()
        {
            decimal v_dc_count = 0;
            m_us_v_qua_trinh_lam_viec.count_chuc_vu_chinh_hien_tai(m_ds_v_qua_trinh_lam_viec, m_us_v_qua_trinh_lam_viec.dcID_NHAN_SU, m_us_chi_tiet_chuc_vu.dcID, CAppContext_201.getCurrentIDPhapnhan(), ref v_dc_count);
            if ( m_rdb_cv_chinh.Checked == true
                && v_dc_count > 0)
            {
                return false;
            }
            return true;
        }
        private void form_to_us_object_quyet_dinh()
        {
            //- quyet dinh bo nhiem
            if (m_txt_ma_quyet_dinh.Text.Trim() == "")
            {
                m_us_quyet_dinh.dcID = -1;

            }
            m_us_quyet_dinh.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text;
            m_us_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_quyet_dinh.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh.SelectedValue);
            m_us_quyet_dinh.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_quyet_dinh.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd.Value;
            if (m_dat_ngay_het_hieu_luc_qd.Checked)
                m_us_quyet_dinh.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc_qd.Value;
            else
                m_us_quyet_dinh.SetNGAY_HET_HIEU_LUCNull();
            m_us_quyet_dinh.strLINK = m_lbl_file_name.Text;
            //- quyet dinh mien nhiem
        }
        private void form_to_us_object_chi_tiet_chuc_vu()
        {
            m_us_chi_tiet_chuc_vu = new US_GD_CHI_TIET_CHUC_VU();
            if (CIPConvert.is_valid_number(m_txt_ty_le_tham_gia.Text.Trim()))
                m_us_chi_tiet_chuc_vu.dcTY_LE_THAM_GIA = CIPConvert.ToDecimal(m_txt_ty_le_tham_gia.Text.Trim());
            else m_us_chi_tiet_chuc_vu.dcTY_LE_THAM_GIA = 0;
            m_us_chi_tiet_chuc_vu.dcID_NHAN_SU = id_nhan_su;
            m_us_chi_tiet_chuc_vu.dcID_CHUC_VU = CIPConvert.ToDecimal(m_cbo_chuc_vu_moi.SelectedValue);

            m_us_chi_tiet_chuc_vu.dcID_LOAI_CV = (m_rdb_cv_chinh.Checked) ? LOAI_CHUC_VU.CHUC_VU_CHINH : LOAI_CHUC_VU.CHUC_VU_KIEM_NHIEM;
            //    m_us_chi_tiet_chuc_vu.dcID_LOAI_CV = CIPConvert.ToDecimal(m_cbo_loai_chuc_vu.SelectedValue);
            m_us_chi_tiet_chuc_vu.dcID_DON_VI = m_us_dm_don_vi.dcID;
            if (m_txt_ma_quyet_dinh.Text != "")
                m_us_chi_tiet_chuc_vu.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
                m_us_chi_tiet_chuc_vu.SetID_QUYET_DINH_MIEN_NHIEMNull();
            m_us_chi_tiet_chuc_vu.datNGAY_BAT_DAU = m_dat_ngay_bat_dau.Value;
                m_us_chi_tiet_chuc_vu.SetNGAY_KET_THUCNull();
                m_us_chi_tiet_chuc_vu.strTRANG_THAI_CV = "Y";
        }
        private void mien_nhiem_chuc_vu()
        {
            US_GD_CHI_TIET_CHUC_VU v_us = new US_GD_CHI_TIET_CHUC_VU();
            DS_GD_CHI_TIET_CHUC_VU v_ds = new DS_GD_CHI_TIET_CHUC_VU();
            v_us.DataRow2Me((DataRow)m_fg.Rows[m_fg.Row].UserData);
            v_us = new US_GD_CHI_TIET_CHUC_VU(v_us.dcID);
            v_us.strTRANG_THAI_CV = "N";
            v_us.datNGAY_KET_THUC = DateTime.Today;
            v_us.Update();
        }
        private void save_data()
        {
            US_GD_QUYET_DINH_PHAP_NHAN v_us_gd_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
            if (confirm_save_data() && check_validate_data_is_ok())
            {
                #region Xử lý file đính kèm
                // Xử lý file đính kèm
                switch (m_e_file_mode)
                {
                    case DataEntryFileMode.UploadFile:
                        // Kiểm tra file đã tồn tại trên server hay chưa
                        if (FileExplorer.IsExistedFile(m_str_directory_to + FileExplorer.fileName))
                        {
                            BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                            return;
                        }

                        // Nếu đã chọn file 
                        if (m_lbl_file_name.Text != "")
                        {
                            // Upload server có sử dụng user và pass
                            if (m_str_user_name != "")
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to, m_str_user_name, m_str_password);
                            // Upload không sử dụng user và pass
                            else
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to);
                        }
                        break;
                    case DataEntryFileMode.EditFile:
                        // Nếu ko up lên file mới sẽ bỏ qua bước này
                        if (m_str_link_old != m_lbl_file_name.Text)
                        {
                            // Kiểm tra file vừa upload đã tồn tại hay chưa
                            if (FileExplorer.IsExistedFile(m_str_directory_to + FileExplorer.fileName))
                            {
                                BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                                return;
                            }

                            // Xóa file cũ
                            if (FileExplorer.IsExistedFile(m_str_directory_to + m_str_link_old))
                                FileExplorer.DeleteFile(m_str_directory_to + m_str_link_old);

                            // Upload file mới lên
                            if (m_str_user_name != "")
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to, m_str_user_name, m_str_password);
                            else
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to);
                        }
                        break;
                    case DataEntryFileMode.DeleteFile:
                        // Kiểm tra file có tồn tại hay không
                        if (FileExplorer.IsExistedFile(m_str_directory_to + m_str_link_old) == false)
                        {
                            BaseMessages.MsgBox_Infor("File không tồn tại!");
                            return;
                        }
                        FileExplorer.DeleteFile(m_str_directory_to + m_str_link_old);
                        break;
                }
                #endregion
                        decimal v_dc_ty_le = 0;
                        if (CIPConvert.is_valid_number(m_txt_ty_le_tham_gia.Text.Trim()))
                            v_dc_ty_le = CIPConvert.ToDecimal(m_txt_ty_le_tham_gia.Text.Trim());
                        if (m_us_v_qua_trinh_lam_viec.Sum_ty_le_tham_gia(m_us_v_qua_trinh_lam_viec.strMA_NV, m_us_v_qua_trinh_lam_viec.strTRANG_THAI_CHUC_VU_YN,CAppContext_201.getCurrentIDPhapnhan()) + v_dc_ty_le > 100)
                        {
                            BaseMessages.MsgBox_Infor("Tỷ lệ tham gia đã đã vượt quá 100%.");
                            return;
                        }
                        if (check_validate_data_is_ok() == false)
                            return;
                        else
                        {
                            if (m_txt_ma_quyet_dinh.Text != "")
                            {
                                form_to_us_object_quyet_dinh();
                                if (m_b_check_quyet_dinh_save)
                                {
                                    m_us_quyet_dinh.Insert();
                                    v_us_gd_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
                                    v_us_gd_quyet_dinh_phap_nhan.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
                                    v_us_gd_quyet_dinh_phap_nhan.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
                                    v_us_gd_quyet_dinh_phap_nhan.Insert();
                                }
                                else
                                {
                                    m_us_quyet_dinh.Update();
                                }
                            }
                            form_to_us_object_chi_tiet_chuc_vu();
                            m_us_chi_tiet_chuc_vu.Insert();   
                }
                BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhât!");
                this.Close();
            }

        }
        #endregion

        //
        //
        //		EVENT HANLDERS
        //
        //

        private void set_define_events()
        {
            m_cmd_exit.Click += m_cmd_exit_Click;
            m_txt_don_vi_moi.TextChanged += m_txt_don_vi_moi_TextChanged;
            //m_cmd_them_quyet_dinh.Click += m_cmd_them_quyet_dinh_Click;
            //m_cmd_chon_quyet_dinh.Click += m_cmd_chon_quyet_dinh_Click;
            //m_cmd_bo_quyet_dinh.Click += m_cmd_bo_quyet_dinh_Click;
            //m_cmd_chon_file.Click += m_cmd_chon_file_Click;
            //m_cmd_bo_dinh_kem.Click += m_cmd_bo_dinh_kem_Click;
            //m_cmd_xem_file.Click += m_cmd_xem_file_Click;
        }

        private void f410_chuyen_nhan_vien_Load(object sender, EventArgs e)
        {
            try
            {
                set_initial_form_load();
                set_define_events();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {

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

        private void m_fg_Click(object sender, EventArgs e)
        {
            try
            {
                grid2us_object(m_us, m_fg.Row);
                us_object_to_form();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_don_vi_moi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                text_changed();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_them_quyet_dinh_Click(object sender, EventArgs e)
        {
            try
            {
                them_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_chon_quyet_dinh_Click(object sender, EventArgs e)
        {
            try
            {
                chon_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bo_quyet_dinh_Click(object sender, EventArgs e)
        {
            m_txt_ma_quyet_dinh.Text = "";
        }

        private void m_cmd_chon_file_Click(object sender, EventArgs e)
        {
            try
            {
                chon_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bo_dinh_kem_Click(object sender, EventArgs e)
        {
            try
            {
                m_e_file_mode = DataEntryFileMode.DeleteFile;
                m_str_link_old = m_lbl_file_name.Text;
                m_lbl_file_name.Text = "";
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_xem_file_Click(object sender, EventArgs e)
        {
            try
            {
                view_quyet_dinh();
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
                xoa_trang();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

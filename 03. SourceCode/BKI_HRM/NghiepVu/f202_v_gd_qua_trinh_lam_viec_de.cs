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

namespace BKI_HRM
{
    public partial class f202_v_gd_qua_trinh_lam_viec_de : Form
    {
        #region Public Interfaces
        public void display()
        {
            this.ShowDialog();
        }
        public f202_v_gd_qua_trinh_lam_viec_de()
        {
            InitializeComponent();
            format_controls();
        }
        public void display_for_bo_nhiem(US_V_GD_QUA_TRINH_LAM_VIEC ip_us_qua_trinh_lam_viec, string ip_str_loai_thay_doi)
        {
            m_str_loai_thay_doi = ip_str_loai_thay_doi;
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_e_file_mode = DataEntryFileMode.UploadFile;
            m_tpc_quyet_dinh.SelectedTab = m_tp_bo_nhiem;
            m_cmd_them_quyet_dinh_mien_nhiem.Visible = false;
            m_cmd_chon_quyet_dinh_mien_nhiem.Visible = false;
            m_cmd_bo_quyet_dinh_mien_nhiem.Visible = false;
            m_us_v_qua_trinh_lam_viec = ip_us_qua_trinh_lam_viec;
            us_object_to_form();
            this.ShowDialog();
        }
        public void display_for_bo_nhiem(string ip_str_loai_thay_doi)
        {
            m_str_loai_thay_doi = ip_str_loai_thay_doi;
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_e_file_mode = DataEntryFileMode.UploadFile;
            m_tpc_quyet_dinh.SelectedTab = m_tp_bo_nhiem;
            m_cmd_them_quyet_dinh_mien_nhiem.Visible = false;
            m_cmd_chon_quyet_dinh_mien_nhiem.Visible = false;
            m_cmd_bo_quyet_dinh_mien_nhiem.Visible = false;
            load_custom_source_2_m_txt_tim_kiem();
            this.ShowDialog();
        }
        public void get_us(ref US_V_GD_QUA_TRINH_LAM_VIEC op_us)
        {
            op_us = m_us_v_qua_trinh_lam_viec;
        }
        public void display_for_mien_nhiem(US_V_GD_QUA_TRINH_LAM_VIEC ip_us_qua_trinh_lam_viec)
        {
            m_b_check_is_mien_nhiem = true;
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_e_file_mode = DataEntryFileMode.EditFile;
            m_tpc_quyet_dinh.SelectedTab = m_tp_mien_nhiem;
            m_cmd_them_quyet_dinh.Visible = false;
            m_cmd_chon_quyet_dinh.Visible = false;
            m_cmd_bo_quyet_dinh.Visible = false;
            m_pnl_1.Enabled = false;
            m_pnl_2.Enabled = false;
            m_str_link_old = m_lbl_file_name.Text;
            m_us_v_qua_trinh_lam_viec = ip_us_qua_trinh_lam_viec;
            m_us_chi_tiet_chuc_vu = new US_GD_CHI_TIET_CHUC_VU(ip_us_qua_trinh_lam_viec.dcID);
            m_dat_ngay_ket_thuc.ShowCheckBox = false;

            us_object_to_form();
            this.ShowDialog();
        }
        public void display_for_update(US_V_GD_QUA_TRINH_LAM_VIEC ip_us_qua_trinh_lam_viec)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_e_file_mode = DataEntryFileMode.EditFile;
            m_us_v_qua_trinh_lam_viec = ip_us_qua_trinh_lam_viec;
            m_str_link_old = m_lbl_file_name.Text;
            m_us_chi_tiet_chuc_vu = new US_GD_CHI_TIET_CHUC_VU(ip_us_qua_trinh_lam_viec.dcID);
            us_object_to_form();
         //   m_grb_quyet_dinh.Enabled = true;
         //   m_grb_quyet_dinh_mien_nhiem.Enabled = true;
            this.ShowDialog();
        }
        #endregion

        #region Members
        DataEntryFormMode m_e_form_mode;
        US_V_GD_QUA_TRINH_LAM_VIEC m_us_v_qua_trinh_lam_viec = new US_V_GD_QUA_TRINH_LAM_VIEC();
        DS_V_GD_QUA_TRINH_LAM_VIEC m_ds_v_qua_trinh_lam_viec = new DS_V_GD_QUA_TRINH_LAM_VIEC();
        US_GD_CHI_TIET_CHUC_VU m_us_chi_tiet_chuc_vu = new US_GD_CHI_TIET_CHUC_VU();
        US_DM_DON_VI m_us_dm_don_vi = new US_DM_DON_VI();
        US_DM_QUYET_DINH m_us_quyet_dinh = new US_DM_QUYET_DINH();
        DS_DM_QUYET_DINH m_ds_quyet_dinh = new DS_DM_QUYET_DINH();
        US_DM_QUYET_DINH m_us_quyet_dinh_mien_nhiem = new US_DM_QUYET_DINH();
        DS_DM_QUYET_DINH m_ds_quyet_dinh_mien_nhiem = new DS_DM_QUYET_DINH();

        bool m_b_check_quyet_dinh_null = false;
        bool m_b_check_quyet_dinh_save;
        bool m_b_check_quyet_dinh_mien_nhiem_null = false;
        bool m_b_check_quyet_dinh_mien_nhiem_save;
        string m_str_loai_thay_doi;
        bool m_b_check_is_mien_nhiem = false;

        private DataEntryFileMode m_e_file_mode;
        private string m_str_domain = ConfigurationSettings.AppSettings["DOMAIN"];
        private string m_str_directory_to = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private string m_str_user_name = ConfigurationSettings.AppSettings["USERNAME_SHARE"];
        private string m_str_password = ConfigurationSettings.AppSettings["PASSWORD_SHARE"];
        private decimal m_str_id_hop_dong_old;
        private string m_str_link_old;
        #endregion

        #region Private Methods
        private bool check_trung_ma_quyet_dinh(string ip_str_ma_quyet_dinh)
        {
            DS_V_DM_QUYET_DINH v_ds = new DS_V_DM_QUYET_DINH();
            US_V_DM_QUYET_DINH v_us = new US_V_DM_QUYET_DINH();
            decimal count_ma_quyet_dinh;
            v_us.FillDataset_By_Ma_qd(v_ds, ip_str_ma_quyet_dinh);
            count_ma_quyet_dinh = v_ds.V_DM_QUYET_DINH.Count;
            if (count_ma_quyet_dinh > 0)
                return false;
            return true;
        }
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            this.KeyPreview = true;
            load_data_to_cbo();
            load_cbo_ma_quyet_dinh();
            load_custom_source_2_m_txt_don_vi();
        }
        private void generate_ma_quyet_dinh()
        {
            m_lbl_ma_qd.Text = string.Format("{0}/{1}/{2}", m_txt_ma_quyet_dinh.Text,
                                                                  m_dat_ngay_ky.Value.Year,
                                                                  m_cbo_ma_quyet_dinh.Text);
        }

        private void generate_ma_quyet_dinh_mien_nhiem()
        {
            m_lbl_ma_qd_mien_nhiem.Text = string.Format("{0}/{1}/{2}", m_txt_ma_quyet_dinh_mien_nhiem.Text,
                                                                  m_dat_ngay_ky_mien_nhiem.Value.Year,
                                                                  m_cbo_ma_quyet_dinh_mien_nhiem.Text);
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
        private void mo_file()
        {
            Process.Start("explorer.exe", m_ofd_chon_file.FileName);
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
        private void view_quyet_dinh_mien_nhiem()
        {
            f202_v_gd_qua_trinh_lam_viec_view v_frm = new f202_v_gd_qua_trinh_lam_viec_view();
            v_frm.display_for_view_quyet_dinh(m_us_quyet_dinh_mien_nhiem);
        }
        private void load_cbo_ma_quyet_dinh()
        {
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.MA_QUYET_DINH
                , WinFormControls.eTAT_CA.NO
                , m_cbo_ma_quyet_dinh);
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.MA_QUYET_DINH
                , WinFormControls.eTAT_CA.NO
                , m_cbo_ma_quyet_dinh_mien_nhiem);
        }

        private void load_data_to_cbo()
        {
            //WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH,
            //  WinFormControls.eTAT_CA.NO,
            //  m_cbo_loai_quyet_dinh);



            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_CHUC_VU,
                WinFormControls.eTAT_CA.NO,
                m_cbo_loai_chuc_vu);

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
        private void us_object_to_form()
        {
            if (m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH > 0)
            {
                m_us_quyet_dinh = new US_DM_QUYET_DINH(m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH);
            }
            if (m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH_MIEN_NHIEM > 0)
            {
                m_us_quyet_dinh_mien_nhiem = new US_DM_QUYET_DINH(m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH_MIEN_NHIEM);
            }
            m_txt_ma_nv.Text = m_us_v_qua_trinh_lam_viec.strMA_NV;
            m_txt_ho_ten.Text = m_us_v_qua_trinh_lam_viec.strHO_DEM + " " + m_us_v_qua_trinh_lam_viec.strTEN;

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

            v_us_loai_quyet_dinh.FillDataset_load_loai_quyet_dinh(v_ds_loai_quyet_dinh, "Tất cả", "N");
            m_cbo_loai_quyet_dinh_mien_nhiem.DataSource = v_ds_loai_quyet_dinh.CM_DM_TU_DIEN;
            m_cbo_loai_quyet_dinh_mien_nhiem.DisplayMember = CM_DM_TU_DIEN.TEN;
            m_cbo_loai_quyet_dinh_mien_nhiem.ValueMember = CM_DM_TU_DIEN.ID;
            switch (m_e_form_mode)
            {
                     
                case DataEntryFormMode.InsertDataState:

                   
                    if (m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH != 0)
                    {
                        US_DM_QUYET_DINH v_us_quyet_dinh = new US_DM_QUYET_DINH(m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH);
                        m_str_link_old = v_us_quyet_dinh.strLINK;
                        if (v_us_quyet_dinh.strLINK == "") return;
                        m_lbl_file_name.Text = v_us_quyet_dinh.strLINK;
                    }

                    break;
                case DataEntryFormMode.UpdateDataState:

                    m_txt_ty_le_tham_gia.Text = CIPConvert.ToStr(m_us_v_qua_trinh_lam_viec.dcTY_LE_THAM_GIA);
                 
                    m_us_dm_don_vi = new US_DM_DON_VI(m_us_v_qua_trinh_lam_viec.dcID_DON_VI);

                    m_txt_don_vi_moi.Text = m_us_dm_don_vi.strMA_DON_VI;
                    text_changed();
                    m_dat_ngay_bat_dau.Value = m_us_v_qua_trinh_lam_viec.datNGAY_BAT_DAU;
                    if (m_us_v_qua_trinh_lam_viec.datNGAY_KET_THUC != null && m_us_v_qua_trinh_lam_viec.datNGAY_KET_THUC > DateTime.Parse("01/01/1900"))
                    {
                        m_dat_ngay_ket_thuc.Checked = true;
                        m_dat_ngay_ket_thuc.Value = m_us_v_qua_trinh_lam_viec.datNGAY_KET_THUC;
                    }
                    else
                        m_dat_ngay_ket_thuc.Checked = false;
//                     m_lbl_ngay_ket_thuc.Text = "Ngày miễn nhiệm";
//                     m_lbl_chuc_vu_moi.Text = "Chức vụ miễn nhiệm";
                    if (m_b_check_is_mien_nhiem)
                    {
                        m_dat_ngay_ket_thuc.Checked = true;
                    }
                    m_cbo_ma_chuc_vu_moi.SelectedValue = m_us_v_qua_trinh_lam_viec.dcID_CHUC_VU;
                    if (m_us_v_qua_trinh_lam_viec.strTRANG_THAI_CHUC_VU_YN == "Y")
                    {
                        m_ckb_cv_hien_tai_yn.Checked = true;
                        m_ckb_cv_hien_tai_yn.Text = "Có";
                    }
                    else
                    {
                        m_ckb_cv_hien_tai_yn.Checked = false;
                        m_ckb_cv_hien_tai_yn.Text = "Không";
                    }
//                     m_lbl_ma_chuc_vu_moi.Text = "Mã chức vụ miễn nhiệm";
//                     m_lbl_don_vi_moi.Text = "Đơn vị hiện tại";





                    US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH();

                    //-- load quyet dinh bo nhiem
                    if (m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH > 0)
                    {
                         v_us_qd = new US_DM_QUYET_DINH(m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH);
//                         string[] v_arstr = v_us_qd.strMA_QUYET_DINH.Trim().Split('/');
//                         m_txt_ma_quyet_dinh.Text = v_arstr[0];
//                         
//                         BKI_HRM.US.US_CM_DM_TU_DIEN v_us = new BKI_HRM.US.US_CM_DM_TU_DIEN();
//                         BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
//                         decimal v_dc_id = 0;
//                         v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
//                         m_cbo_ma_quyet_dinh.SelectedValue = v_dc_id;
                        m_txt_ma_quyet_dinh.Text = m_us_v_qua_trinh_lam_viec.strMA_QUYET_DINH;
                        m_cbo_loai_quyet_dinh.SelectedValue = v_us_qd.dcID_LOAI_QD;
                        m_dat_ngay_ky.Value = v_us_qd.datNGAY_KY;
                        if (v_us_qd.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900") &&
                            v_us_qd.datNGAY_CO_HIEU_LUC != null)
                            m_dat_ngay_co_hieu_luc_qd.Value = v_us_qd.datNGAY_CO_HIEU_LUC;
                        else
                            m_dat_ngay_co_hieu_luc_qd.Checked = false;
                        if (v_us_qd.datNGAY_HET_HIEU_LUC != null &&
                            v_us_qd.datNGAY_HET_HIEU_LUC > DateTime.Parse("1/1/1900"))
                            m_dat_ngay_het_hieu_luc_qd.Value = v_us_qd.datNGAY_HET_HIEU_LUC;
                        else
                            m_dat_ngay_het_hieu_luc_qd.Checked = false;
                        m_txt_noi_dung.Text = v_us_qd.strNOI_DUNG;
                        m_ofd_chon_file.FileName = v_us_qd.strLINK;
                    }

                    if (m_us_v_qua_trinh_lam_viec.dcID_LOAI_CV == LOAI_CHUC_VU.CHUC_VU_CHINH)
                    {
                        m_rdb_cv_chinh.Checked = true;
                    }
                    else
                    {
                        m_rdb_cv_kiem_nhiem.Checked = true;
                    }
                    m_lbl_file_name.Text = v_us_qd.strLINK;
                    //-- load quyet dinh mien nhiem
                    if (m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH_MIEN_NHIEM > 0)
                    {
                         v_us_qd = new US_DM_QUYET_DINH(m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH_MIEN_NHIEM);
//                         string[] v_arstr_mien_nhiem = v_us_qd.strMA_QUYET_DINH.Trim().Split('/');
//                         m_txt_ma_quyet_dinh_mien_nhiem.Text = v_arstr_mien_nhiem[0];
//                         BKI_HRM.US.US_CM_DM_TU_DIEN v_us = new BKI_HRM.US.US_CM_DM_TU_DIEN();
//                         BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
//                         decimal v_dc_id = 0;
//                         v_us.FillDatasetByName(v_ds, v_arstr_mien_nhiem[v_arstr_mien_nhiem.Length - 1], ref v_dc_id);
//                         m_cbo_ma_quyet_dinh_mien_nhiem.SelectedValue = v_dc_id;
                        m_txt_ma_quyet_dinh_mien_nhiem.Text = m_us_v_qua_trinh_lam_viec.strMA_QUYET_DINH_MIEN_NHIEM;
                        m_cbo_loai_quyet_dinh_mien_nhiem.SelectedValue = v_us_qd.dcID_LOAI_QD;
                        m_dat_ngay_ky_mien_nhiem.Value = v_us_qd.datNGAY_KY;
                        if (v_us_qd.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900") &&
                            v_us_qd.datNGAY_CO_HIEU_LUC != null)
                            m_dat_ngay_co_hieu_luc_qd_mien_nhiem.Value = v_us_qd.datNGAY_CO_HIEU_LUC;
                        else
                            m_dat_ngay_co_hieu_luc_qd_mien_nhiem.Checked = false;

                        m_txt_noi_dung_mien_nhiem.Text = v_us_qd.strNOI_DUNG;
                        m_ofd_openfile_mien_nhiem.FileName = v_us_qd.strLINK;
                    }
                    if (m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH_MIEN_NHIEM > 0)
                    {
                        US_DM_QUYET_DINH v_us_quyet_dinh_1 = new US_DM_QUYET_DINH(m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH_MIEN_NHIEM);
                        m_str_link_old = v_us_quyet_dinh_1.strLINK;
//                         if (v_us_quyet_dinh_1.strLINK == "") return;
//                         string[] v_strs_1 = v_us_quyet_dinh_1.strLINK.Split('\\');
//                         m_lbl_file_name.Text = v_strs_1[v_strs_1.Length - 1].Split('-')[v_strs_1[v_strs_1.Length - 1].Split('-').Length - 1];
                        m_lbl_file_name_mien_nhiem.Text = v_us_quyet_dinh_1.strLINK;
                    }
                    if (m_txt_ma_quyet_dinh.Text == "")
                    {
                        m_grb_quyet_dinh.Enabled = false;
                    }
                    if (m_txt_ma_quyet_dinh_mien_nhiem.Text == "")
                    {
                        m_grb_quyet_dinh_mien_nhiem.Enabled = false;
                    }
                    break;
                default: break;
            }
            if (m_b_check_is_mien_nhiem)
            {
                m_ckb_cv_hien_tai_yn.Checked = false;
                m_ckb_cv_hien_tai_yn.Text = "Không";
            }
        }
        private void form_to_us_object_chi_tiet_chuc_vu()
        {
            if (m_str_loai_thay_doi == "thang_chuc")
            {
                m_us_chi_tiet_chuc_vu.dcID_LOAI_CV = LOAI_CHUC_VU.CHUC_VU_CHINH;
            }
            else if (m_str_loai_thay_doi == "kiem_nhiem")
            {
                m_us_chi_tiet_chuc_vu.dcID_LOAI_CV = LOAI_CHUC_VU.CHUC_VU_KIEM_NHIEM;
            }
            m_us_chi_tiet_chuc_vu = new US_GD_CHI_TIET_CHUC_VU();
            if (CIPConvert.is_valid_number(m_txt_ty_le_tham_gia.Text.Trim()))
                m_us_chi_tiet_chuc_vu.dcTY_LE_THAM_GIA = CIPConvert.ToDecimal(m_txt_ty_le_tham_gia.Text.Trim());
            else m_us_chi_tiet_chuc_vu.dcTY_LE_THAM_GIA = 0;
            if (m_us_v_qua_trinh_lam_viec.dcID_NHAN_SU == 0)
            {
                DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
                US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
                v_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds_dm_nhan_su, m_txt_ma_nv.Text);
                m_us_chi_tiet_chuc_vu.dcID_NHAN_SU = (decimal)v_ds_dm_nhan_su.Tables[0].Rows[0].ItemArray[0];
            }
            else
            m_us_chi_tiet_chuc_vu.dcID_NHAN_SU = m_us_v_qua_trinh_lam_viec.dcID_NHAN_SU;
            m_us_chi_tiet_chuc_vu.dcID_CHUC_VU = CIPConvert.ToDecimal(m_cbo_chuc_vu_moi.SelectedValue);
            
            m_us_chi_tiet_chuc_vu.dcID_LOAI_CV = (m_rdb_cv_chinh.Checked) ? LOAI_CHUC_VU.CHUC_VU_CHINH : LOAI_CHUC_VU.CHUC_VU_KIEM_NHIEM;
        //    m_us_chi_tiet_chuc_vu.dcID_LOAI_CV = CIPConvert.ToDecimal(m_cbo_loai_chuc_vu.SelectedValue);
            m_us_chi_tiet_chuc_vu.dcID_DON_VI = m_us_dm_don_vi.dcID;
            if (m_txt_ma_quyet_dinh.Text != "")
                m_us_chi_tiet_chuc_vu.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
            if (m_txt_ma_quyet_dinh_mien_nhiem.Text != "")
                m_us_chi_tiet_chuc_vu.dcID_QUYET_DINH_MIEN_NHIEM = m_us_quyet_dinh_mien_nhiem.dcID;
            m_us_chi_tiet_chuc_vu.datNGAY_BAT_DAU = m_dat_ngay_bat_dau.Value;
            if (m_dat_ngay_ket_thuc.Checked)
                m_us_chi_tiet_chuc_vu.datNGAY_KET_THUC = m_dat_ngay_ket_thuc.Value;
            else
                m_us_chi_tiet_chuc_vu.SetNGAY_KET_THUCNull();
          //  m_us_chi_tiet_chuc_vu.strTRANG_THAI_CV = "Y";
            if (m_ckb_cv_hien_tai_yn.Checked == true)
            {
                m_us_chi_tiet_chuc_vu.strTRANG_THAI_CV = "Y";
            }
            else
            {
                 m_us_chi_tiet_chuc_vu.strTRANG_THAI_CV = "N";
            }
            switch (m_e_form_mode)
            {

                case DataEntryFormMode.UpdateDataState:
                    m_us_chi_tiet_chuc_vu.dcID = m_us_v_qua_trinh_lam_viec.dcID;
                   
                    if (m_us_quyet_dinh.dcID != -1)
                    {
                        m_us_chi_tiet_chuc_vu.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
                    }
                    else
                    {
                        m_us_chi_tiet_chuc_vu.SetID_QUYET_DINHNull();
                    }
                    if (m_us_quyet_dinh_mien_nhiem.dcID != -1)
                    {
                        m_us_chi_tiet_chuc_vu.dcID_QUYET_DINH_MIEN_NHIEM = m_us_quyet_dinh_mien_nhiem.dcID;
                    }
                    else
                    {
                        m_us_chi_tiet_chuc_vu.SetID_QUYET_DINH_MIEN_NHIEMNull();
                    }
                   if (m_ckb_cv_hien_tai_yn.Checked == true)
                    {
                        m_us_chi_tiet_chuc_vu.strTRANG_THAI_CV = "Y";
                    }
                    else
                    {
                        m_us_chi_tiet_chuc_vu.strTRANG_THAI_CV = "N";
                    }
                    break;

                default:
                    break;
            }
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
            if (m_txt_ma_quyet_dinh_mien_nhiem.Text.Trim() == "")
            {
                m_us_quyet_dinh_mien_nhiem.dcID = -1;
            }
            m_us_quyet_dinh_mien_nhiem.strMA_QUYET_DINH = m_txt_ma_quyet_dinh_mien_nhiem.Text;
            m_us_quyet_dinh_mien_nhiem.strNOI_DUNG = m_txt_noi_dung_mien_nhiem.Text.Trim();
          //  m_us_quyet_dinh_mien_nhiem.strLINK = m_ofd_openfile_mien_nhiem.FileName;
            m_us_quyet_dinh_mien_nhiem.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh_mien_nhiem.SelectedValue);
            m_us_quyet_dinh_mien_nhiem.datNGAY_KY = m_dat_ngay_ky_mien_nhiem.Value;
            m_us_quyet_dinh_mien_nhiem.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd_mien_nhiem.Value;
            m_us_quyet_dinh_mien_nhiem.SetNGAY_HET_HIEU_LUCNull();
            m_us_quyet_dinh_mien_nhiem.strLINK = m_lbl_file_name_mien_nhiem.Text;
        }

        private bool check_validate_data_is_ok()
        {
            if (m_us_dm_don_vi.dcID == -1)
            {
                BaseMessages.MsgBox_Infor("Bạn chưa chọn đơn vị của nhân viên.");
                return false;
            }
            if (m_dat_ngay_bat_dau.Value.Date > m_dat_ngay_ket_thuc.Value.Date && m_dat_ngay_ket_thuc.Checked == true)
            {
                BaseMessages.MsgBox_Infor("Ngày bắt đầu không thể sau ngày kết thúc.");
                return false;
            }
            if (m_dat_ngay_co_hieu_luc_qd.Value.Date > m_dat_ngay_het_hieu_luc_qd.Value.Date && m_dat_ngay_het_hieu_luc_qd.Checked == true)
            {
                BaseMessages.MsgBox_Infor("Ngày có hiệu lực không thể sau ngày hết hiệu lực.");
                return false;
            }
            if (!check_chuc_vu_chinh())
            {
                BaseMessages.MsgBox_Infor("Không thể tồn tại 2 chức vụ chính tại thời điểm hiện tại.");
                return false;
            }
            /*if (!check_trung_ma_quyet_dinh(m_txt_ma_quyet_dinh.Text.Trim()))
            {
                BaseMessages.MsgBox_Infor("Mã quyết định đã tồn tại");
                return false;
            }*/
            return true;
        }
        private bool check_quyet_dinh(string ip_str_ma_qd) {
            if (!check_trung_ma_quyet_dinh(ip_str_ma_qd)) {
                BaseMessages.MsgBox_Infor("Mã quyết định đã tồn tại");
                return false;
            }
            return true;
        }
        private bool check_chuc_vu_chinh()
        {
            decimal v_dc_count = 0;
            m_us_v_qua_trinh_lam_viec.count_chuc_vu_chinh_hien_tai(m_ds_v_qua_trinh_lam_viec, m_us_v_qua_trinh_lam_viec.dcID_NHAN_SU, m_us_chi_tiet_chuc_vu.dcID,CAppContext_201.getCurrentIDPhapnhan(), ref v_dc_count);
            if (m_ckb_cv_hien_tai_yn.Checked == true
                && m_rdb_cv_chinh.Checked == true
                && v_dc_count > 0)
            {
                return false;
            }
            return true;
        }
        private bool confirm_save_data()
        {
            US_DM_CHUC_VU v_us_dm_chuc_vu = new US_DM_CHUC_VU();
            DS_DM_CHUC_VU v_ds_dm_chuc_vu = new DS_DM_CHUC_VU();

            string v_str_chuc_vu = "";

            v_us_dm_chuc_vu.FillDatasetByID(v_ds_dm_chuc_vu, CIPConvert.ToDecimal(m_cbo_chuc_vu_moi.SelectedValue), ref v_str_chuc_vu);
            if (m_b_check_is_mien_nhiem)
                return BaseMessages.MsgBox_Confirm("Bạn có thực sự muốn miễn nhiệm chức vụ \"" + v_str_chuc_vu + "\" của " + m_us_v_qua_trinh_lam_viec.strHO_DEM + " " + m_us_v_qua_trinh_lam_viec.strTEN + "\" tại\n \"" + m_txt_don_vi_moi.Text + "\" không?");
            return BaseMessages.MsgBox_Confirm("Bạn có thực sự muốn thay đổi chức vụ của \"" + m_us_v_qua_trinh_lam_viec.strHO_DEM + " " + m_us_v_qua_trinh_lam_viec.strTEN + "\" thành\n \"" + v_str_chuc_vu + "\" tại \"" + m_txt_don_vi_moi.Text + "\" không?");

        }
        private void save_data()
        {
            US_GD_QUYET_DINH_PHAP_NHAN v_us_gd_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
            if (confirm_save_data())
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


                switch (m_e_form_mode)
                {

                    case DataEntryFormMode.UpdateDataState:
                        decimal v_dc = 0;
                        if (CIPConvert.is_valid_number(m_txt_ty_le_tham_gia.Text.Trim()))
                            v_dc = CIPConvert.ToDecimal(m_txt_ty_le_tham_gia.Text.Trim());
                        if (m_us_v_qua_trinh_lam_viec.Sum_ty_le_tham_gia(m_us_v_qua_trinh_lam_viec.strMA_NV, m_us_v_qua_trinh_lam_viec.strTRANG_THAI_CHUC_VU_YN,CAppContext_201.getCurrentIDPhapnhan()) - m_us_v_qua_trinh_lam_viec.dcTY_LE_THAM_GIA + v_dc > 100)
                        {
                            BaseMessages.MsgBox_Infor("Tỷ lệ tham gia đã vượt quá 100%.");
                            return;
                        }
                        if (check_validate_data_is_ok() == false)
                            return;
                        else
                        {

                            form_to_us_object_quyet_dinh();
                            if (m_b_check_quyet_dinh_save)
                            {
                                if (m_b_check_quyet_dinh_null&&check_quyet_dinh(m_txt_ma_quyet_dinh.Text.Trim()))
                                {
                                    if (m_txt_ma_quyet_dinh.Text.Trim() == "") {
                                        BaseMessages.MsgBox_Infor("Mã quyết định trống");
                                        return;
                                    }
                                    else {
                                        m_us_quyet_dinh.Insert();
                                        v_us_gd_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
                                        v_us_gd_quyet_dinh_phap_nhan.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
                                        v_us_gd_quyet_dinh_phap_nhan.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
                                        v_us_gd_quyet_dinh_phap_nhan.Insert();
                                    }
                                }
                                else
                                    return;
                            }
                            else
                            {
                                m_us_quyet_dinh.Update();
                            }
                            if (m_b_check_quyet_dinh_mien_nhiem_save)
                            {
                                if (m_b_check_quyet_dinh_mien_nhiem_null && check_quyet_dinh(m_txt_ma_quyet_dinh_mien_nhiem.Text.Trim())) {
                                    if (m_txt_ma_quyet_dinh_mien_nhiem.Text.Trim() == "") {
                                        BaseMessages.MsgBox_Infor("Mã quyết định miễn nhiệm trống");
                                        return;
                                    }
                                    else {
                                        m_us_quyet_dinh_mien_nhiem.Insert();
                                        v_us_gd_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
                                        v_us_gd_quyet_dinh_phap_nhan.dcID_QUYET_DINH = m_us_quyet_dinh_mien_nhiem.dcID;
                                        v_us_gd_quyet_dinh_phap_nhan.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
                                        v_us_gd_quyet_dinh_phap_nhan.Insert();
                                    }
                                }
                                else
                                    return;
                                
                            }
                                else
                                {
                                    m_us_quyet_dinh_mien_nhiem.Update();
                                }

                            form_to_us_object_chi_tiet_chuc_vu();

                            m_us_chi_tiet_chuc_vu.Update();

                        }

                        break;
                    case DataEntryFormMode.InsertDataState:
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
                                if (m_b_check_quyet_dinh_save&&check_quyet_dinh(m_txt_ma_quyet_dinh.Text.Trim()))
                                {
                                    m_us_quyet_dinh.Insert();
                                    v_us_gd_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
                                    v_us_gd_quyet_dinh_phap_nhan.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
                                    v_us_gd_quyet_dinh_phap_nhan.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
                                    v_us_gd_quyet_dinh_phap_nhan.Insert();
                                }
                                
                            }
                            if (m_txt_ma_quyet_dinh_mien_nhiem.Text != "")
                            {
                                form_to_us_object_quyet_dinh();
                                if (m_b_check_quyet_dinh_mien_nhiem_save && check_quyet_dinh(m_txt_ma_quyet_dinh_mien_nhiem.Text.Trim()))
                                {
                                    m_us_quyet_dinh_mien_nhiem.Insert();
                                    v_us_gd_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
                                    v_us_gd_quyet_dinh_phap_nhan.dcID_QUYET_DINH = m_us_quyet_dinh_mien_nhiem.dcID;
                                    v_us_gd_quyet_dinh_phap_nhan.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
                                    v_us_gd_quyet_dinh_phap_nhan.Insert();
                                }
                                else
                                {
                                    return;
                                }
                            }
                            form_to_us_object_chi_tiet_chuc_vu();
                            m_us_chi_tiet_chuc_vu.Insert();
                        }

                        break;
                    default:
                        break;
                }
                BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhât!");
                this.Close();
            }

        }
        private void load_custom_source_2_m_txt_tim_kiem()
        {
            DS_DM_NHAN_SU v_ds = new DS_DM_NHAN_SU();
            US_DM_NHAN_SU v_us = new US_DM_NHAN_SU();
            v_us.FillDataset(v_ds);
            int count = v_ds.Tables["DM_NHAN_SU"].Rows.Count;
            AutoCompleteStringCollection v_acsc_search = new AutoCompleteStringCollection();
            foreach (DataRow dr in v_ds.DM_NHAN_SU)
            {
                v_acsc_search.Add(dr[DM_NHAN_SU.MA_NV].ToString());
            }
            m_txt_ma_nv.AutoCompleteCustomSource = v_acsc_search;
        }
        private void chon_nhan_su()
        {

            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
            v_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds_dm_nhan_su, m_txt_ma_nv.Text.Trim());
            if (v_ds_dm_nhan_su.Tables[0].Rows.Count == 0)
                return;

            m_txt_ho_ten.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["HO_DEM"] + " " +
                                   v_ds_dm_nhan_su.Tables[0].Rows[0]["TEN"];
        }
        private void xoa_trang()
        {
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    m_cbo_chuc_vu_moi.SelectedIndex = 0;
                    m_cbo_loai_quyet_dinh.SelectedIndex = 0;
                    m_cbo_ma_chuc_vu_moi.SelectedIndex = 0;
                    m_cbo_loai_chuc_vu.SelectedIndex = 0;
                    m_txt_don_vi_moi.Text = "";
                    m_txt_ma_quyet_dinh.Text = "";
                    m_txt_noi_dung.Text = "";
                    m_dat_ngay_bat_dau.Value = DateTime.Today;
                    m_dat_ngay_co_hieu_luc_qd.Value = DateTime.Today;
                    m_dat_ngay_het_hieu_luc_qd.Value = DateTime.Today;
                    m_dat_ngay_ky.Value = DateTime.Today;
                    m_dat_ngay_ket_thuc.Value = DateTime.Today;
                    m_dat_ngay_ket_thuc.Checked = false;
                    m_dat_ngay_het_hieu_luc_qd.Checked = false;
                    break;
                case DataEntryFormMode.UpdateDataState:
                    us_object_to_form();
                    break;
            }

        }
        private void set_inital_form_load()
        {
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.UpdateDataState:
                    us_object_to_form();
                    break;
                case DataEntryFormMode.ViewDataState:
                    break;
                case DataEntryFormMode.InsertDataState:
                    break;
                default:
                    break;
            }
        }
        private void set_define_event()
        {
            m_txt_don_vi_moi.TextChanged += m_txt_don_vi_moi_TextChanged;
            m_cmd_them_quyet_dinh.Click += m_cmd_them_quyet_dinh_Click;
            m_cmd_chon_quyet_dinh.Click += m_cmd_chon_quyet_dinh_Click;
            m_cmd_them_quyet_dinh_mien_nhiem.Click += m_cmd_them_quyet_dinh_mien_nhiem_Click;
            m_cmd_chon_quyet_dinh_mien_nhiem.Click += m_cmd_chon_quyet_dinh_mien_nhiem_Click;
          //  m_txt_ma_quyet_dinh.TextChanged += m_txt_ma_quyet_dinh_TextChanged;
           // m_cbo_ma_quyet_dinh.SelectedIndexChanged += m_cbo_ma_quyet_dinh_SelectedIndexChanged;
          //  m_dat_ngay_ky.ValueChanged += m_dat_ngay_ky_ValueChanged;

//             m_txt_ma_quyet_dinh_mien_nhiem.TextChanged += m_txt_ma_quyet_dinh_mien_nhiem_TextChanged;
//             m_cbo_ma_quyet_dinh_mien_nhiem.SelectedIndexChanged += m_cbo_ma_quyet_dinh_mien_nhiem_SelectedIndexChanged;
//             m_dat_ngay_ky_mien_nhiem.ValueChanged += m_dat_ngay_ky_mien_nhiem_ValueChanged;
            m_ckb_cv_hien_tai_yn.CheckedChanged += m_ckb_cv_hien_tai_yn_CheckedChanged;

            m_cmd_bo_quyet_dinh.Click += m_cmd_bo_quyet_dinh_Click;
            m_cmd_bo_quyet_dinh_mien_nhiem.Click += m_cmd_bo_quyet_dinh_mien_nhiem_Click;
            m_cmd_chon_file.Click += m_cmd_chon_file_Click;
            m_cmd_bo_dinh_kem.Click += m_cmd_bo_dinh_kem_Click;
            m_cmd_xem_file.Click += m_cmd_xem_file_Click;
            m_cmd_xem_file_mien_nhiem.Click += m_cmd_xem_file_mien_nhiem_Click;
          
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
        private void them_quyet_dinh_mien_mien_nhiem()
        {
            m_b_check_quyet_dinh_mien_nhiem_null = true;
            m_b_check_quyet_dinh_mien_nhiem_save = true;
            m_grb_quyet_dinh_mien_nhiem.Enabled = true;
            m_txt_ma_quyet_dinh_mien_nhiem.Focus();

            m_txt_ma_quyet_dinh_mien_nhiem.Text = "";
            m_dat_ngay_ky_mien_nhiem.Value = DateTime.Today;
            m_dat_ngay_co_hieu_luc_qd_mien_nhiem.Value = DateTime.Today;
            m_cbo_loai_quyet_dinh_mien_nhiem.SelectedIndex = 0;
        }

        private void chon_quyet_dinh_mien_nhiem()
        {
            m_b_check_quyet_dinh_mien_nhiem_save = false;
            m_grb_quyet_dinh_mien_nhiem.Enabled = false;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data(CHON_QUYET_DINH.MIEN_NHIEM, ref m_us_quyet_dinh_mien_nhiem);
            if (m_us_quyet_dinh_mien_nhiem.dcID != -1)
            {

// 
//                 string[] v_arstr = m_us_quyet_dinh_mien_nhiem.strMA_QUYET_DINH.Trim().Split('/');
//                 m_txt_ma_quyet_dinh_mien_nhiem.Text = v_arstr[0];
//                 BKI_HRM.US.US_CM_DM_TU_DIEN v_us = new BKI_HRM.US.US_CM_DM_TU_DIEN();
//                 BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
//                 decimal v_dc_id = 0;
//                 v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
//                 m_cbo_ma_quyet_dinh_mien_nhiem.SelectedValue = v_dc_id;
                m_txt_ma_quyet_dinh_mien_nhiem.Text = m_us_quyet_dinh_mien_nhiem.strMA_QUYET_DINH;
                m_cbo_loai_quyet_dinh_mien_nhiem.SelectedValue = m_us_quyet_dinh_mien_nhiem.dcID_LOAI_QD;
                m_dat_ngay_ky_mien_nhiem.Value = m_us_quyet_dinh.datNGAY_KY;
                if (m_us_quyet_dinh.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900") &&
                    m_us_quyet_dinh.datNGAY_CO_HIEU_LUC != null)
                    m_dat_ngay_co_hieu_luc_qd_mien_nhiem.Value = m_us_quyet_dinh.datNGAY_CO_HIEU_LUC;
                else
                    m_dat_ngay_co_hieu_luc_qd_mien_nhiem.Checked = false;

                m_txt_noi_dung_mien_nhiem.Text = m_us_quyet_dinh.strNOI_DUNG;
                m_ofd_openfile_mien_nhiem.FileName = m_us_quyet_dinh.strLINK;

            }
            else
            {
                m_b_check_quyet_dinh_mien_nhiem_null = true;
            }
        }
        private void chon_quyet_dinh()
        {
            m_b_check_quyet_dinh_save = false;
            m_grb_quyet_dinh.Enabled = false;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data(CHON_QUYET_DINH.BO_NHIEM, ref m_us_quyet_dinh);
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
        #endregion


        #region Event Hanlders
        private void m_ckb_cv_hien_tai_yn_CheckedChanged(object sender, EventArgs e)
        {
            if (m_ckb_cv_hien_tai_yn.Checked == true)
            {
                m_ckb_cv_hien_tai_yn.Text = "Có";
            }
            else
            {
                m_ckb_cv_hien_tai_yn.Text = "Không";
            }
        }
        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            this.Close();

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

        private void f202_v_gd_qua_trinh_lam_viec_de_Load(object sender, EventArgs e)
        {
            try
            {
                set_inital_form_load();
                set_define_event();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_chon_don_vi_Click(object sender, EventArgs e)
        {
            try
            {
                f101_v_dm_don_vi v_frm = new f101_v_dm_don_vi();
                v_frm.select_data(ref m_us_dm_don_vi);
                m_txt_don_vi_moi.Text = m_us_dm_don_vi.strMA_DON_VI;
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
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
        private void m_cmd_xem_file_mien_nhiem_Click(object sender, EventArgs e)
        {
            try
            {
                view_quyet_dinh_mien_nhiem();
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

        private void m_cmd_chon_quyet_dinh_mien_nhiem_Click(object sender, EventArgs e)
        {
            try
            {
                chon_quyet_dinh_mien_nhiem();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_them_quyet_dinh_mien_nhiem_Click(object sender, EventArgs e)
        {
            try
            {
                them_quyet_dinh_mien_mien_nhiem();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }



        private void m_txt_ty_le_tham_gia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                )
            {
                e.Handled = true;
            }
        }

        private void m_txt_ma_quyet_dinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_txt_ma_quyet_dinh_mien_nhiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh_mien_nhiem();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cbo_ma_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cbo_ma_quyet_dinh_mien_nhiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh_mien_nhiem();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_dat_ngay_ky_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_dat_ngay_ky_mien_nhiem_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh_mien_nhiem();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bo_quyet_dinh_mien_nhiem_Click(object sender, EventArgs e)
        {
            m_txt_ma_quyet_dinh_mien_nhiem.Text = "";
        }

        private void m_cmd_bo_quyet_dinh_Click(object sender, EventArgs e)
        {
            m_txt_ma_quyet_dinh.Text = "";
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
       
        #endregion

        private void m_txt_ma_nv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                chon_nhan_su();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_ma_nv_Leave(object sender, EventArgs e)
        {
            try
            {
                chon_nhan_su();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

    }
}

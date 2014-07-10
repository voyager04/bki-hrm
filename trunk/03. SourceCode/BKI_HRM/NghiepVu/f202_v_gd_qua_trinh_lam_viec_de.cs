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
        public void display_for_insert(US_V_GD_QUA_TRINH_LAM_VIEC ip_us_qua_trinh_lam_viec, string ip_str_loai_thay_doi)
        {
            m_str_loai_thay_doi = ip_str_loai_thay_doi;
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_us_v_qua_trinh_lam_viec = ip_us_qua_trinh_lam_viec;
            us_object_to_form();
            this.ShowDialog();
        }
        public void get_us(ref US_V_GD_QUA_TRINH_LAM_VIEC op_us)
        {
            op_us = m_us_v_qua_trinh_lam_viec;
        }
        public void display_for_update(US_V_GD_QUA_TRINH_LAM_VIEC ip_us_qua_trinh_lam_viec)
        {
            m_b_check_is_mien_nhiem = true;
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_us_v_qua_trinh_lam_viec = ip_us_qua_trinh_lam_viec;
            m_dat_ngay_ket_thuc.ShowCheckBox = false;

            us_object_to_form();
            this.ShowDialog();
        }
        public void display_for_update_qd(US_V_GD_QUA_TRINH_LAM_VIEC ip_us_qua_trinh_lam_viec)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_us_v_qua_trinh_lam_viec = ip_us_qua_trinh_lam_viec;
            us_object_to_form();
            m_grb_quyet_dinh.Enabled = true;
            m_grb_quyet_dinh_mien_nhiem.Enabled = true;
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

        private string m_str_to = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private string m_str_username_share = ConfigurationSettings.AppSettings["USERNAME_SHARE"];
        private string m_str_password_share = ConfigurationSettings.AppSettings["PASSWORD_SHARE"];
        private string m_str_domain = ConfigurationSettings.AppSettings["DOMAIN"];
        private string m_str_from = "";
        private string m_str_file_name = "";
        private string m_str_path = "";
        private string m_str_time_now = DateTime.Now.Ticks.ToString();
        private string m_str_file_name_old = "";
        private bool m_b_status = false;
        #endregion

        #region Private Methods
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
            US_DM_DON_VI v_us = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
            v_us.FillDataset(v_ds);
            foreach (DataRow dr in v_ds.DM_DON_VI)
            {
                v_acsc_search.Add(dr[DM_DON_VI.MA_DON_VI].ToString());

            }

            m_txt_don_vi_moi.AutoCompleteMode = AutoCompleteMode.Suggest;
            m_txt_don_vi_moi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            m_txt_don_vi_moi.AutoCompleteCustomSource = v_acsc_search;
        }
        private void mo_file()
        {
            Process.Start("explorer.exe", m_ofd_openfile.FileName);
        }

        private void chon_file()
        {
            m_ofd_openfile.Filter = "(*.pdf)|*.pdf|(*.doc)|*.doc|(*.docx)|*.docx|(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            m_ofd_openfile.Multiselect = false;
            m_ofd_openfile.Title = "Chọn tài liệu đính kèm";
            m_ofd_openfile.FileName = "";
            DialogResult result = m_ofd_openfile.ShowDialog();
            if (result != DialogResult.OK) return;

            if (new FileInfo(m_ofd_openfile.FileName).Length > 5096000)
            {
                BaseMessages.MsgBox_Infor("File đính kèm quá lớn. \nVui lòng chọn file có dung lượng < 5Mb");
                return;
            }
            m_str_file_name = m_ofd_openfile.SafeFileName;
            m_lbl_file_name.Text = m_str_file_name;
            m_str_from = m_ofd_openfile.FileName;
            var v_i_index = m_str_from.Trim().LastIndexOf("\\");
            m_str_path = m_str_from.Trim().Substring(0, v_i_index + 1);
        }

        private bool existed_file(string ip_str_path)
        {
            if (File.Exists(ip_str_path))
                return true;
            return false;
        }

        private void upload_file()
        {
            if (m_str_file_name == "")
            {
                m_us_quyet_dinh.strLINK = "";
                return;
            }
            modify_name_file(m_str_from, m_str_path + m_str_time_now + "-" + m_str_file_name);

            var oNetworkCredential =
                    new System.Net.NetworkCredential()
                    {
                        Domain = m_str_domain,
                        UserName = m_str_domain + "\\" + m_str_username_share,
                        Password = m_str_password_share
                    };

            using (new RemoteAccessHelper.NetworkConnection(@"\\" + m_str_domain, oNetworkCredential))
            {
                File.Move(m_str_path + m_str_time_now + "-" + m_str_file_name,
                            m_str_to + m_str_time_now + "-" + m_str_file_name);
            }

            m_us_quyet_dinh.strLINK = m_str_time_now + "-" + m_str_file_name;
            m_b_status = true;
        }

        private void modify_name_file(string ip_str_source_file_name, string ip_str_desination_file_name)
        {
            //Coppy file mới
            File.Copy(ip_str_source_file_name, m_str_path + "topica" + m_str_file_name);
            //Đổi tên file mới
            File.Move(m_str_path + "topica" + m_str_file_name, ip_str_desination_file_name);
        }

        private void delete_file(string ip_str_path)
        {
            if (existed_file(m_str_from))
            {
                File.Delete(ip_str_path);
                return;
            }
            BaseMessages.MsgBox_Infor("File không tồn tại.");
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
                        m_str_file_name_old = v_us_quyet_dinh.strLINK;
                        if (v_us_quyet_dinh.strLINK == "") return;
                        string[] v_strs = v_us_quyet_dinh.strLINK.Split('\\');
                        m_lbl_file_name.Text = v_strs[v_strs.Length - 1].Split('-')[v_strs[v_strs.Length - 1].Split('-').Length - 1];
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

                    m_cbo_ma_chuc_vu_moi.SelectedValue = m_us_v_qua_trinh_lam_viec.dcID_CHUC_VU;
                    if (m_us_v_qua_trinh_lam_viec.strTRANG_THAI_CHUC_VU_YN == "Y")
                    {
                        m_ckb_cv_hien_tai_yn.Checked = true;
                    }
                    else
                    {
                        m_ckb_cv_hien_tai_yn.Checked = false;
                    }
//                     m_lbl_ma_chuc_vu_moi.Text = "Mã chức vụ miễn nhiệm";
//                     m_lbl_don_vi_moi.Text = "Đơn vị hiện tại";





                    US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH();

                    //-- load quyet dinh bo nhiem
                    if (m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH > 0)
                    {
                        v_us_qd = new US_DM_QUYET_DINH(m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH);
                        string[] v_arstr = v_us_qd.strMA_QUYET_DINH.Trim().Split('/');
                        m_txt_ma_quyet_dinh.Text = v_arstr[0];
                        BKI_HRM.US.US_CM_DM_TU_DIEN v_us = new BKI_HRM.US.US_CM_DM_TU_DIEN();
                        BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
                        decimal v_dc_id = 0;
                        v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
                        m_cbo_ma_quyet_dinh.SelectedValue = v_dc_id;

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
                        m_ofd_openfile.FileName = v_us_qd.strLINK;
                    }



                    //-- load quyet dinh mien nhiem
                    if (m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH_MIEN_NHIEM > 0)
                    {
                        v_us_qd = new US_DM_QUYET_DINH(m_us_v_qua_trinh_lam_viec.dcID_QUYET_DINH_MIEN_NHIEM);
                        string[] v_arstr_mien_nhiem = v_us_qd.strMA_QUYET_DINH.Trim().Split('/');
                        m_txt_ma_quyet_dinh_mien_nhiem.Text = v_arstr_mien_nhiem[0];
                        BKI_HRM.US.US_CM_DM_TU_DIEN v_us = new BKI_HRM.US.US_CM_DM_TU_DIEN();
                        BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
                        decimal v_dc_id = 0;
                        v_us.FillDatasetByName(v_ds, v_arstr_mien_nhiem[v_arstr_mien_nhiem.Length - 1], ref v_dc_id);
                        m_cbo_ma_quyet_dinh_mien_nhiem.SelectedValue = v_dc_id;

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
                        m_str_file_name_old = v_us_quyet_dinh_1.strLINK;
                        if (v_us_quyet_dinh_1.strLINK == "") return;
                        string[] v_strs_1 = v_us_quyet_dinh_1.strLINK.Split('\\');
                        m_lbl_file_name.Text = v_strs_1[v_strs_1.Length - 1].Split('-')[v_strs_1[v_strs_1.Length - 1].Split('-').Length - 1];
                    }

                    break;
                default: break;
            }
        }
        private void form_to_us_object_chi_tiet_chuc_vu()
        {
            if (m_str_loai_thay_doi == "thang_chuc")
            {
                m_us_chi_tiet_chuc_vu.dcID_LOAI_CV = 650;
            }
            else if (m_str_loai_thay_doi == "kiem_nhiem")
            {
                m_us_chi_tiet_chuc_vu.dcID_LOAI_CV = 651;
            }
            m_us_chi_tiet_chuc_vu = new US_GD_CHI_TIET_CHUC_VU();
            if (CIPConvert.is_valid_number(m_txt_ty_le_tham_gia.Text.Trim()))
                m_us_chi_tiet_chuc_vu.dcTY_LE_THAM_GIA = CIPConvert.ToDecimal(m_txt_ty_le_tham_gia.Text.Trim());
            else m_us_chi_tiet_chuc_vu.dcTY_LE_THAM_GIA = 0;
            m_us_chi_tiet_chuc_vu.dcID_NHAN_SU = m_us_v_qua_trinh_lam_viec.dcID_NHAN_SU;
            m_us_chi_tiet_chuc_vu.dcID_CHUC_VU = CIPConvert.ToDecimal(m_cbo_chuc_vu_moi.SelectedValue);
            m_us_chi_tiet_chuc_vu.dcID_LOAI_CV = CIPConvert.ToDecimal(m_cbo_loai_chuc_vu.SelectedValue);
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
            m_us_quyet_dinh.strMA_QUYET_DINH = m_lbl_ma_qd.Text;
            m_us_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_quyet_dinh.strLINK = m_ofd_openfile.FileName;
            m_us_quyet_dinh.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh.SelectedValue);
            m_us_quyet_dinh.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_quyet_dinh.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd.Value;
            if (m_dat_ngay_het_hieu_luc_qd.Checked)
                m_us_quyet_dinh.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc_qd.Value;
            else
                m_us_quyet_dinh.SetNGAY_HET_HIEU_LUCNull();

            //- quyet dinh mien nhiem
            if (m_txt_ma_quyet_dinh_mien_nhiem.Text.Trim() == "")
            {
                m_us_quyet_dinh_mien_nhiem.dcID = -1;
            }
            m_us_quyet_dinh_mien_nhiem.strMA_QUYET_DINH = m_lbl_ma_qd_mien_nhiem.Text;
            m_us_quyet_dinh_mien_nhiem.strNOI_DUNG = m_txt_noi_dung_mien_nhiem.Text.Trim();
            m_us_quyet_dinh_mien_nhiem.strLINK = m_ofd_openfile_mien_nhiem.FileName;
            m_us_quyet_dinh_mien_nhiem.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh_mien_nhiem.SelectedValue);
            m_us_quyet_dinh_mien_nhiem.datNGAY_KY = m_dat_ngay_ky_mien_nhiem.Value;
            m_us_quyet_dinh_mien_nhiem.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd_mien_nhiem.Value;
            m_us_quyet_dinh_mien_nhiem.SetNGAY_HET_HIEU_LUCNull();
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
            return true;
        }
        private bool check_chuc_vu_chinh()
        {
            decimal v_dc_count = 0;
            m_us_v_qua_trinh_lam_viec.count_chuc_vu_chinh_hien_tai(m_ds_v_qua_trinh_lam_viec, m_us_v_qua_trinh_lam_viec.dcID_NHAN_SU, m_us_chi_tiet_chuc_vu.dcID, ref v_dc_count);
            if (m_ckb_cv_hien_tai_yn.Checked == true
                && CIPConvert.ToDecimal( m_cbo_loai_chuc_vu.SelectedValue) == 650
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
            if (confirm_save_data())
            {

                if (existed_file(m_str_to + m_str_time_now + "-" + m_str_file_name))
                {
                    BaseMessages.MsgBox_Infor("Tên file đã tồn tại, vui lòng đổi tên khác.");
                    return;
                }
                upload_file();
                switch (m_e_form_mode)
                {

                    case DataEntryFormMode.UpdateDataState:
                        decimal v_dc = 0;
                        if (CIPConvert.is_valid_number(m_txt_ty_le_tham_gia.Text.Trim()))
                            v_dc = CIPConvert.ToDecimal(m_txt_ty_le_tham_gia.Text.Trim());
                        if (m_us_v_qua_trinh_lam_viec.Sum_ty_le_tham_gia(m_us_v_qua_trinh_lam_viec.strMA_NV, m_us_v_qua_trinh_lam_viec.strTRANG_THAI_CHUC_VU_YN) - m_us_v_qua_trinh_lam_viec.dcTY_LE_THAM_GIA + v_dc > 100)
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
                                if (m_b_check_quyet_dinh_null)
                                {
                                    m_us_quyet_dinh.Insert();
                                }
                                else
                                {
                                    m_us_quyet_dinh.Update();
                                }
                            }
                            if (m_b_check_quyet_dinh_mien_nhiem_save)
                            {
                                if (m_b_check_quyet_dinh_mien_nhiem_null)
                                {
                                    m_us_quyet_dinh_mien_nhiem.Insert();
                                }
                                else
                                {
                                    m_us_quyet_dinh_mien_nhiem.Update();
                                }
                            }

                            form_to_us_object_chi_tiet_chuc_vu();

                            m_us_chi_tiet_chuc_vu.Update();

                        }

                        break;
                    case DataEntryFormMode.InsertDataState:
                        decimal v_dc_ty_le = 0;
                        if (CIPConvert.is_valid_number(m_txt_ty_le_tham_gia.Text.Trim()))
                            v_dc = CIPConvert.ToDecimal(m_txt_ty_le_tham_gia.Text.Trim());
                        if (m_us_v_qua_trinh_lam_viec.Sum_ty_le_tham_gia(m_us_v_qua_trinh_lam_viec.strMA_NV, m_us_v_qua_trinh_lam_viec.strTRANG_THAI_CHUC_VU_YN) + v_dc_ty_le > 100)
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
                                    m_us_quyet_dinh_mien_nhiem.Insert();
                                }

                            }
                            if (m_txt_ma_quyet_dinh_mien_nhiem.Text != "")
                            {
                                form_to_us_object_quyet_dinh();
                                if (m_b_check_quyet_dinh_mien_nhiem_save)
                                {
                                    m_us_quyet_dinh_mien_nhiem.Insert();
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
            m_txt_ma_quyet_dinh.TextChanged += m_txt_ma_quyet_dinh_TextChanged;
            m_cbo_ma_quyet_dinh.SelectedIndexChanged += m_cbo_ma_quyet_dinh_SelectedIndexChanged;
            m_dat_ngay_ky.ValueChanged += m_dat_ngay_ky_ValueChanged;

            m_txt_ma_quyet_dinh_mien_nhiem.TextChanged += m_txt_ma_quyet_dinh_mien_nhiem_TextChanged;
            m_cbo_ma_quyet_dinh_mien_nhiem.SelectedIndexChanged += m_cbo_ma_quyet_dinh_mien_nhiem_SelectedIndexChanged;
            m_dat_ngay_ky_mien_nhiem.ValueChanged += m_dat_ngay_ky_mien_nhiem_ValueChanged;
            m_ckb_cv_hien_tai_yn.CheckedChanged += m_ckb_cv_hien_tai_yn_CheckedChanged;

            m_cmd_bo_quyet_dinh.Click += m_cmd_bo_quyet_dinh_Click;
            m_cmd_bo_quyet_dinh_mien_nhiem.Click += m_cmd_bo_quyet_dinh_mien_nhiem_Click;
        }

        private void text_changed()
        {
            US_V_DM_DON_VI v_us = new US_V_DM_DON_VI();
            DS_V_DM_DON_VI v_ds = new DS_V_DM_DON_VI();
            v_us.FillDataset_search_by_ma_dv(v_ds, m_txt_don_vi_moi.Text.Trim());
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
            m_b_check_quyet_dinh_save = true;
            m_grb_quyet_dinh.Enabled = true;
            m_txt_ma_quyet_dinh.Focus();
        }
        private void them_quyet_dinh_mien_mien_nhiem()
        {
            m_b_check_quyet_dinh_mien_nhiem_save = true;
            m_grb_quyet_dinh_mien_nhiem.Enabled = true;
            m_txt_ma_quyet_dinh_mien_nhiem.Focus();
        }

        private void chon_quyet_dinh_mien_nhiem()
        {
            m_b_check_quyet_dinh_mien_nhiem_save = false;
            m_grb_quyet_dinh_mien_nhiem.Enabled = true;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data("Tất cả", ref m_us_quyet_dinh_mien_nhiem);
            if (m_us_quyet_dinh_mien_nhiem.dcID != -1)
            {


                string[] v_arstr = m_us_quyet_dinh_mien_nhiem.strMA_QUYET_DINH.Trim().Split('/');
                m_txt_ma_quyet_dinh_mien_nhiem.Text = v_arstr[0];
                BKI_HRM.US.US_CM_DM_TU_DIEN v_us = new BKI_HRM.US.US_CM_DM_TU_DIEN();
                BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
                decimal v_dc_id = 0;
                v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
                m_cbo_ma_quyet_dinh_mien_nhiem.SelectedValue = v_dc_id;

                m_cbo_loai_quyet_dinh_mien_nhiem.SelectedValue = m_us_quyet_dinh.dcID_LOAI_QD;
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
            m_grb_quyet_dinh.Enabled = true;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data("Tất cả", ref m_us_quyet_dinh);
            if (m_us_quyet_dinh.dcID != -1)
            {
                string[] v_arstr = m_us_quyet_dinh.strMA_QUYET_DINH.Trim().Split('/');
                m_txt_ma_quyet_dinh.Text = v_arstr[0];
                BKI_HRM.US.US_CM_DM_TU_DIEN v_us = new BKI_HRM.US.US_CM_DM_TU_DIEN();
                BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
                decimal v_dc_id = 0;
                v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
                m_cbo_ma_quyet_dinh.SelectedValue = v_dc_id;

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
                m_ofd_openfile.FileName = m_us_quyet_dinh.strLINK;

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
                mo_file();
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
        #endregion

    }
}

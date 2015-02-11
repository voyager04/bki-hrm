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

namespace BKI_HRM
{
    public partial class f203_v_gd_trang_thai_lao_dong_de : Form
    {
        #region Public Interface
        public void display()
        {
            this.ShowDialog();
        }
        public f203_v_gd_trang_thai_lao_dong_de()
        {
            InitializeComponent();
            format_controls();
        }
        public void display_for_insert(US_V_GD_TRANG_THAI_LAO_DONG ip_us_trang_thai_ld)
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_e_file_mode = DataEntryFileMode.UploadFile;
            m_us_v_trang_thai_ld = ip_us_trang_thai_ld;
            us_object_to_form();
            this.ShowDialog();

        }
        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_e_file_mode = DataEntryFileMode.UploadFile;
            load_custom_source_2_m_txt_tim_kiem();
            this.ShowDialog();

        }
        public void display_for_update(US_V_GD_TRANG_THAI_LAO_DONG ip_us_trang_thai_ld)
        {
            m_us_v_trang_thai_ld = ip_us_trang_thai_ld;
            m_us_trang_thai_ld = new US_GD_CHI_TIET_TRANG_THAI_LD(ip_us_trang_thai_ld.dcID);
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_e_file_mode = DataEntryFileMode.EditFile;
            m_str_link_old = m_lbl_file_name.Text;
            us_object_to_form();
            this.ShowDialog();
        }
        public void display_for_view(US_V_GD_TRANG_THAI_LAO_DONG ip_us_trang_thai_ld)
        {
            m_us_v_trang_thai_ld = ip_us_trang_thai_ld;
            m_e_form_mode = DataEntryFormMode.ViewDataState;
            m_cmd_refresh.Visible = false;
            m_cmd_save.Visible = false;
            m_cmd_chon_file.Visible = false;
            us_object_to_form();
            this.ShowDialog();
        }
        #endregion

        #region Members
        DataEntryFormMode m_e_form_mode;
        US_V_GD_TRANG_THAI_LAO_DONG m_us_v_trang_thai_ld = new US_V_GD_TRANG_THAI_LAO_DONG();
        DS_V_GD_TRANG_THAI_LAO_DONG m_ds_v_trang_thai_ld = new DS_V_GD_TRANG_THAI_LAO_DONG();
        US_GD_CHI_TIET_TRANG_THAI_LD m_us_trang_thai_ld = new US_GD_CHI_TIET_TRANG_THAI_LD();

        US_DM_QUYET_DINH m_us_quyet_dinh = new US_DM_QUYET_DINH();
        DS_DM_QUYET_DINH m_ds_quyet_dinh = new DS_DM_QUYET_DINH();
        bool m_b_check_quyet_dinh_null = false;
        bool m_b_check_quyet_dinh_save;

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
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_LAO_DONG,
              WinFormControls.eTAT_CA.NO,
              m_cbo_trang_thai_moi);
            //WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH,
            //  WinFormControls.eTAT_CA.NO,
            //  m_cbo_loai_quyet_dinh);
            //  
            BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds_loai_quyet_dinh = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
            BKI_HRM.US.US_CM_DM_TU_DIEN v_us_loai_quyet_dinh = new BKI_HRM.US.US_CM_DM_TU_DIEN();
            v_us_loai_quyet_dinh.FillDataset_load_loai_quyet_dinh(v_ds_loai_quyet_dinh, "Tất cả", "N");
            m_cbo_loai_quyet_dinh.DataSource = v_ds_loai_quyet_dinh.CM_DM_TU_DIEN;
            m_cbo_loai_quyet_dinh.DisplayMember = CM_DM_TU_DIEN.TEN;
            m_cbo_loai_quyet_dinh.ValueMember = CM_DM_TU_DIEN.ID;

            m_cmd_save.Visible = true;
            m_cmd_refresh.Visible = true;
            m_cmd_exit.Visible = true;
            m_cmd_save.Enabled = true;
            m_cmd_refresh.Enabled = true;
            m_cmd_exit.Enabled = true;

            load_cbo_ma_quyet_dinh();
        }

        private void us_object_to_form()
        {
            m_txt_ma_nv.Text = m_us_v_trang_thai_ld.strMA_NV;
            m_txt_ho_ten.Text = m_us_v_trang_thai_ld.strHO_DEM + " " + m_us_v_trang_thai_ld.strTEN;

            m_txt_ma_nv.BackColor = SystemColors.Info;
            m_txt_ma_nv.ReadOnly = true;
            m_txt_ho_ten.BackColor = SystemColors.Info;
            m_txt_ho_ten.ReadOnly = true;

            m_us_v_trang_thai_ld.FillDatasetByManhanvien_trang_thai_hien_tai(m_ds_v_trang_thai_ld, m_us_v_trang_thai_ld.strMA_NV, CAppContext_201.getCurrentIDPhapnhan());

            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    if (m_ds_v_trang_thai_ld.V_GD_TRANG_THAI_LAO_DONG.Select("MA_NV is not null").Length > 0)
                    {
                        m_us_v_trang_thai_ld.DataRow2Me((DataRow)m_ds_v_trang_thai_ld.V_GD_TRANG_THAI_LAO_DONG.Rows[0]);
                        m_txt_trang_thai_hien_tai.Text = m_us_v_trang_thai_ld.strTRANG_THAI_LAO_DONG;
                        m_cbo_trang_thai_moi.SelectedValue = m_us_v_trang_thai_ld.dcID_TRANG_LAO_DONG;
                    }
                    else
                        m_txt_trang_thai_hien_tai.Text = "";

                    m_txt_trang_thai_hien_tai.BackColor = SystemColors.Info;
                    m_txt_trang_thai_hien_tai.ReadOnly = true;
                    if (m_us_v_trang_thai_ld.dcID_QUYET_DINH != 0)
                    {
                        US_DM_QUYET_DINH v_us_quyet_dinh = new US_DM_QUYET_DINH(m_us_v_trang_thai_ld.dcID_QUYET_DINH);
                        m_str_link_old = v_us_quyet_dinh.strLINK;
                        if (v_us_quyet_dinh.strLINK == "") return;
                        m_lbl_file_name.Text = v_us_quyet_dinh.strLINK;
                    }
                    break;
                case DataEntryFormMode.UpdateDataState:
                    m_cbo_trang_thai_moi.SelectedValue = m_us_v_trang_thai_ld.dcID_TRANG_LAO_DONG;
                    if (m_us_v_trang_thai_ld.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900"))
                        m_dat_ngay_co_hieu_luc.Value = m_us_v_trang_thai_ld.datNGAY_CO_HIEU_LUC;
                    //                     else
                    //                         m_dat_ngay_co_hieu_luc.Checked = false;
                    if (m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC != null && m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC > DateTime.Parse("01/01/1900"))
                    {
                        m_dat_ngay_het_hieu_luc.Checked = true;
                        m_dat_ngay_het_hieu_luc.Value = m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC;
                    }
                    else
                        m_dat_ngay_het_hieu_luc.Checked = false;
                    m_us_quyet_dinh.FillDataset_By_Ma_qd(m_ds_quyet_dinh, m_us_v_trang_thai_ld.strMA_QUYET_DINH);
                    if (m_ds_quyet_dinh.DM_QUYET_DINH.Select("MA_QUYET_DINH is not null").Length > 0)
                    {
                        US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH();
                        v_us_qd = new US_DM_QUYET_DINH(m_us_v_trang_thai_ld.dcID_QUYET_DINH);
                        //                         string[] v_arstr = v_us_qd.strMA_QUYET_DINH.Trim().Split('/');
                        //                         m_txt_ma_quyet_dinh.Text = v_arstr[0];
                        //                         BKI_HRM.US.US_CM_DM_TU_DIEN v_us = new BKI_HRM.US.US_CM_DM_TU_DIEN();
                        //                         BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
                        //                         decimal v_dc_id = 0;
                        //                         v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
                        //                         m_cbo_ma_quyet_dinh.SelectedValue = v_dc_id;
                        m_txt_ma_quyet_dinh.Text = v_us_qd.strMA_QUYET_DINH;
                        m_us_quyet_dinh.DataRow2Me((DataRow)m_ds_quyet_dinh.DM_QUYET_DINH.Rows[0]);
                        m_cbo_loai_quyet_dinh.SelectedValue = m_us_quyet_dinh.dcID_LOAI_QD;
                        m_dat_ngay_ky.Value = m_us_quyet_dinh.datNGAY_KY;
                        if (m_us_quyet_dinh.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900"))
                            m_dat_ngay_co_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_CO_HIEU_LUC;
                        //                         else
                        //                             m_dat_ngay_co_hieu_luc_qd.Checked = false;
                        if (m_us_quyet_dinh.datNGAY_HET_HIEU_LUC != null && m_us_quyet_dinh.datNGAY_HET_HIEU_LUC > DateTime.Parse("01/01/1900"))
                        {
                            m_dat_ngay_het_hieu_luc_qd.Checked = true;
                            m_dat_ngay_het_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_HET_HIEU_LUC;
                        }
                        else
                            m_dat_ngay_het_hieu_luc_qd.Checked = false;
                        m_lbl_file_name.Text = v_us_qd.strLINK;
                        m_txt_noi_dung.Text = m_us_quyet_dinh.strNOI_DUNG;
                        m_ofd_chon_file.FileName = m_us_quyet_dinh.strLINK;
                    }
                    else
                    {
                        m_txt_ma_quyet_dinh.Text = "";
                        m_cbo_loai_quyet_dinh.SelectedIndex = 0;
                        m_dat_ngay_ky.Checked = false;
                        m_dat_ngay_co_hieu_luc_qd.Checked = false;
                        m_dat_ngay_het_hieu_luc_qd.Checked = false;
                        m_txt_noi_dung.Text = "";
                        m_ofd_chon_file.FileName = "";
                    }
                    if (m_us_v_trang_thai_ld.strTRANG_THAI_HIEN_TAI_YN == "Y")
                    {
                        m_ckb_trang_thai_hien_tai_yn.Checked = true;
                    }
                    else
                    {
                        m_ckb_trang_thai_hien_tai_yn.Checked = false;
                    }
                    break;
                case DataEntryFormMode.ViewDataState:
                    if (m_us_v_trang_thai_ld.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900"))
                        m_dat_ngay_co_hieu_luc.Value = m_us_v_trang_thai_ld.datNGAY_CO_HIEU_LUC;
                    else
                        m_dat_ngay_co_hieu_luc.Checked = false;
                    if (m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC != null && m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC > DateTime.Parse("01/01/1900"))
                    {
                        m_dat_ngay_het_hieu_luc.Checked = true;
                        m_dat_ngay_het_hieu_luc.Value = m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC;
                    }
                    else
                        m_dat_ngay_het_hieu_luc.Checked = false;
                    m_us_quyet_dinh.FillDataset_By_Ma_qd(m_ds_quyet_dinh, m_us_v_trang_thai_ld.strMA_QUYET_DINH);
                    if (m_ds_quyet_dinh.DM_QUYET_DINH.Select("MA_QUYET_DINH is not null").Length > 0)
                    {
                        m_txt_ma_quyet_dinh.Text = m_us_v_trang_thai_ld.strMA_QUYET_DINH;
                        m_us_quyet_dinh.DataRow2Me((DataRow)m_ds_quyet_dinh.DM_QUYET_DINH.Rows[0]);
                        m_cbo_loai_quyet_dinh.SelectedValue = m_us_quyet_dinh.dcID_LOAI_QD;
                        m_dat_ngay_ky.Value = m_us_quyet_dinh.datNGAY_KY;
                        if (m_us_quyet_dinh.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900"))
                            m_dat_ngay_co_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_CO_HIEU_LUC;
                        else
                            m_dat_ngay_co_hieu_luc_qd.Checked = false;
                        if (m_us_quyet_dinh.datNGAY_HET_HIEU_LUC != null)
                            m_dat_ngay_het_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_HET_HIEU_LUC;
                        else
                            m_dat_ngay_het_hieu_luc_qd.Checked = false;
                        m_txt_noi_dung.Text = m_us_quyet_dinh.strNOI_DUNG;
                        m_ofd_chon_file.FileName = m_us_quyet_dinh.strLINK;
                    }
                    else
                    {
                        m_txt_ma_quyet_dinh.Text = "";
                        m_cbo_loai_quyet_dinh.SelectedIndex = 0;
                        m_dat_ngay_ky.Checked = false;
                        m_dat_ngay_co_hieu_luc_qd.Checked = false;
                        m_dat_ngay_het_hieu_luc_qd.Checked = false;
                        m_txt_noi_dung.Text = "";
                        m_ofd_chon_file.FileName = "";
                    }
                    m_txt_noi_dung.ReadOnly = true;
                    m_txt_noi_dung.BackColor = SystemColors.Info;
                    m_txt_ma_quyet_dinh.ReadOnly = true;
                    m_txt_ma_quyet_dinh.BackColor = SystemColors.Info;
                    m_txt_trang_thai_hien_tai.ReadOnly = true;
                    m_txt_trang_thai_hien_tai.BackColor = SystemColors.Info;
                    m_cbo_loai_quyet_dinh.Enabled = false;
                    m_cbo_trang_thai_moi.Visible = false;
                    m_lbl_trang_thai_moi.Visible = false;
                    m_dat_ngay_co_hieu_luc.Enabled = false;
                    m_dat_ngay_co_hieu_luc_qd.Enabled = false;
                    m_dat_ngay_co_hieu_luc.Enabled = false;
                    m_dat_ngay_ky.Enabled = false;

                    break;
                default: break;
            }
        }
        private void form_to_us_object_quyet_dinh()
        {
            if (m_txt_ma_quyet_dinh.Text.Trim() == "")
            {
                m_us_quyet_dinh.dcID = -1;
            }
            //    m_us_quyet_dinh.strMA_QUYET_DINH = m_lbl_ma_qd.Text;
            m_us_quyet_dinh.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text.Trim();
            m_us_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_quyet_dinh.strLINK = m_lbl_file_name.Text;
            m_us_quyet_dinh.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh.SelectedValue);
            m_us_quyet_dinh.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_quyet_dinh.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd.Value;
            if (m_dat_ngay_het_hieu_luc_qd.Checked)
                m_us_quyet_dinh.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc_qd.Value;
            else
                m_us_quyet_dinh.SetNGAY_HET_HIEU_LUCNull();
        }
        private void form_to_us_object_trang_thai_ld()
        {
            m_us_trang_thai_ld.dcID = m_us_v_trang_thai_ld.dcID;
            m_us_trang_thai_ld.dcID_NHAN_SU = m_us_v_trang_thai_ld.dcID_NHAN_SU;
            m_us_trang_thai_ld.dcID_TRANG_LAO_DONG = CIPConvert.ToDecimal(m_cbo_trang_thai_moi.SelectedValue);
            if (m_txt_ma_quyet_dinh.Text.Trim() != "")
                m_us_trang_thai_ld.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
            else
            {
                m_us_trang_thai_ld.SetID_QUYET_DINHNull();
            }
            m_us_trang_thai_ld.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value;

            if (m_dat_ngay_het_hieu_luc.Checked)
                m_us_trang_thai_ld.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc.Value;
            else m_us_trang_thai_ld.SetNGAY_HET_HIEU_LUCNull();
            if (m_ckb_trang_thai_hien_tai_yn.Checked == true)
            {
                m_us_trang_thai_ld.strTRANG_THAI_HIEN_TAI = "Y";
            }
            else
            {
                m_us_trang_thai_ld.strTRANG_THAI_HIEN_TAI = "N";
            }
        }
        private void form_to_us_object_v_trang_thai_ld()
        {
            //m_us_trang_thai_ld.dcID = m_us_v_trang_thai_ld.dcID;
            //m_us_trang_thai_ld.dcID_NHAN_SU = m_us_v_trang_thai_ld.dcID_NHAN_SU;
            if (m_us_v_trang_thai_ld.dcID == 0)
            {
                DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
                US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
                v_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds_dm_nhan_su, m_txt_ma_nv.Text);
                m_us_v_trang_thai_ld.dcID_NHAN_SU = (decimal)v_ds_dm_nhan_su.Tables[0].Rows[0].ItemArray[0];
            }
            m_us_v_trang_thai_ld.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
            m_us_v_trang_thai_ld.dcID_TRANG_LAO_DONG = CIPConvert.ToDecimal(m_cbo_trang_thai_moi.SelectedValue);
            if (m_txt_ma_quyet_dinh.Text.Trim() != "")
                m_us_v_trang_thai_ld.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
            else
            {
                m_us_v_trang_thai_ld.SetID_QUYET_DINHNull();
            }
            m_us_v_trang_thai_ld.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value;

            if (m_dat_ngay_het_hieu_luc.Checked)
                m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc.Value;
            else m_us_v_trang_thai_ld.SetNGAY_HET_HIEU_LUCNull();
            if (m_ckb_trang_thai_hien_tai_yn.Checked == true)
            {
                m_us_v_trang_thai_ld.strTRANG_THAI_HIEN_TAI = "Y";
            }
            else
            {
                m_us_v_trang_thai_ld.strTRANG_THAI_HIEN_TAI = "N";
            }
        }
        private void load_cbo_ma_quyet_dinh()
        {
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.MA_QUYET_DINH
                , WinFormControls.eTAT_CA.NO
                , m_cbo_ma_quyet_dinh);
        }
        private void chon_file()
        {
            FileExplorer.SelectFile(m_ofd_chon_file, m_str_link_old);
            m_lbl_file_name.Text = FileExplorer.fileName;
        }
        private void mo_file()
        {
            Process.Start("explorer.exe", m_ofd_chon_file.FileName);
        }
        private bool check_validate_data_is_ok()
        {
            if (m_dat_ngay_co_hieu_luc.Value.Date > m_dat_ngay_het_hieu_luc.Value.Date && m_dat_ngay_het_hieu_luc.Value.Date > DateTime.Parse("1/1/1900") && (m_dat_ngay_het_hieu_luc.Checked == true))
            {
                BaseMessages.MsgBox_Infor("Ngày hết hiệu lực không thể trước ngày có hiệu lực.");
                return false;
            }
            /*if (((m_dat_ngay_het_hieu_luc_qd.Value.Date < m_dat_ngay_co_hieu_luc_qd.Value.Date)
                || (m_dat_ngay_ky.Value.Date > m_dat_ngay_het_hieu_luc_qd.Value.Date)) && (m_dat_ngay_het_hieu_luc_qd.Checked == true)
                )
            {
                BaseMessages.MsgBox_Infor("Ngày hết hiệu lực quyết định không thể trước ngày có hiệu lực quyết định hoặc ngày ký.");
                return false;
            }*/
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
        private bool check_trang_thai_hien_tai_phap_nhan()
        {
            if (m_ckb_trang_thai_hien_tai_yn.Checked)
            {
                if (m_us_trang_thai_ld.count_trang_thai_hien_tai_phap_nhan(m_us_v_trang_thai_ld.dcID_NHAN_SU, CAppContext_201.getCurrentIDPhapnhan(), m_us_trang_thai_ld.dcID) > 0)
                {
                    return false;
                }
            }
            return true;
        }
        private bool confirm_save_data()
        {
            BKI_HRM.US.US_CM_DM_TU_DIEN v_us_tu_dien = new BKI_HRM.US.US_CM_DM_TU_DIEN();
            BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds_tu_dien = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
            string v_str_trang_thai_moi = "";
            v_us_tu_dien.FillDatasetByID(v_ds_tu_dien, CIPConvert.ToDecimal(m_cbo_trang_thai_moi.SelectedValue), ref v_str_trang_thai_moi);

            return BaseMessages.MsgBox_Confirm("Bạn có thực sự muốn thay đổi trạng thái lao động của \"" + m_us_v_trang_thai_ld.strHO_DEM + " " + m_us_v_trang_thai_ld.strTEN + "\" thành\n \"" + v_str_trang_thai_moi + "\" không?");

        }
        private void save_data()
        {
            if (confirm_save_data() && check_validate_data_is_ok())
            {
                US_GD_QUYET_DINH_PHAP_NHAN v_us_gd_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
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
                        if (check_validate_data_is_ok() == false)
                            return;

                        else
                        {
                            if (!check_trang_thai_hien_tai_phap_nhan())
                            {

                                BaseMessages.MsgBox_Infor("Tại thời điểm hiện tại, ứng với 1 pháp nhân, mỗi nhân viên chỉ có thể có 1 trạng thái chính thức.");
                                return;

                            }
                            form_to_us_object_quyet_dinh();
                            if (m_b_check_quyet_dinh_save)
                            {
                                if (m_b_check_quyet_dinh_null&&check_quyet_dinh(m_txt_ma_quyet_dinh.Text.Trim()))
                                {
                                    if (m_txt_ma_quyet_dinh.Text != "")
                                    {
                                        m_us_quyet_dinh.Insert();
                                        v_us_gd_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
                                        v_us_gd_quyet_dinh_phap_nhan.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
                                        v_us_gd_quyet_dinh_phap_nhan.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
                                        v_us_gd_quyet_dinh_phap_nhan.Insert();
                                        form_to_us_object_trang_thai_ld();
                                    }
                                    else
                                    {
                                        form_to_us_object_trang_thai_ld();
                                        switch ((int)CAppContext_201.getCurrentIDPhapnhan())
                                        {
                                            case (int)PHAP_NHAN.TU:
                                                m_us_trang_thai_ld.dcID_QUYET_DINH = 1515;
                                                break;
                                            case (int)PHAP_NHAN.TE:
                                                m_us_trang_thai_ld.dcID_QUYET_DINH = 1517;
                                                break;
                                            case (int)PHAP_NHAN.TEG:
                                                m_us_trang_thai_ld.dcID_QUYET_DINH = 1516;
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                form_to_us_object_trang_thai_ld();
                                if (m_txt_ma_quyet_dinh.Text == "")
                                {
                                    switch ((int)CAppContext_201.getCurrentIDPhapnhan())
                                    {
                                        case (int)PHAP_NHAN.TU:
                                            m_us_trang_thai_ld.dcID_QUYET_DINH = 1515;
                                            break;
                                        case (int)PHAP_NHAN.TE:
                                            m_us_trang_thai_ld.dcID_QUYET_DINH = 1517;
                                            break;
                                        case (int)PHAP_NHAN.TEG:
                                            m_us_trang_thai_ld.dcID_QUYET_DINH = 1516;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            m_us_trang_thai_ld.Update();

                        }

                        break;
                    case DataEntryFormMode.InsertDataState:

                        if (check_validate_data_is_ok() == false)
                            return;
                        else {
                            if (m_b_check_quyet_dinh_save) {
                                if (m_b_check_quyet_dinh_null && check_quyet_dinh(m_txt_ma_quyet_dinh.Text.Trim())) {
                                    if (m_txt_ma_quyet_dinh.Text != "") {
                                        form_to_us_object_quyet_dinh();
                                        m_us_quyet_dinh.Insert();
                                        v_us_gd_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
                                        v_us_gd_quyet_dinh_phap_nhan.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
                                        v_us_gd_quyet_dinh_phap_nhan.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
                                        v_us_gd_quyet_dinh_phap_nhan.Insert();
                                    }
                                    else {
                                        BaseMessages.MsgBox_Infor("Mã quyết định trống");
                                        return;
                                    }
                                    form_to_us_object_v_trang_thai_ld();
                                    if (m_us_v_trang_thai_ld.dcID_QUYET_DINH == 0) {
                                        switch ((int)CAppContext_201.getCurrentIDPhapnhan()) {
                                            case (int)PHAP_NHAN.TU:
                                                m_us_v_trang_thai_ld.dcID_QUYET_DINH = 1515;
                                                break;
                                            case (int)PHAP_NHAN.TE:
                                                m_us_v_trang_thai_ld.dcID_QUYET_DINH = 1517;
                                                break;
                                            case (int)PHAP_NHAN.TEG:
                                                m_us_v_trang_thai_ld.dcID_QUYET_DINH = 1516;
                                                break;
                                            default:
                                                break;
                                        }

                                    }
                                    m_us_v_trang_thai_ld.Insert();
                                }
                                else
                                    return;
                            }
                            else {
                                form_to_us_object_v_trang_thai_ld();
                                if (m_us_v_trang_thai_ld.dcID_QUYET_DINH == 0) {
                                    switch ((int)CAppContext_201.getCurrentIDPhapnhan()) {
                                        case (int)PHAP_NHAN.TU:
                                            m_us_v_trang_thai_ld.dcID_QUYET_DINH = 1515;
                                            break;
                                        case (int)PHAP_NHAN.TE:
                                            m_us_v_trang_thai_ld.dcID_QUYET_DINH = 1517;
                                            break;
                                        case (int)PHAP_NHAN.TEG:
                                            m_us_v_trang_thai_ld.dcID_QUYET_DINH = 1516;
                                            break;
                                        default:
                                            break;
                                    }

                                }
                                m_us_v_trang_thai_ld.Insert();
                            }

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
                    m_cbo_trang_thai_moi.SelectedIndex = 0;
                    m_us_quyet_dinh = null;
                    m_txt_ma_quyet_dinh.Text = "";
                    m_cbo_loai_quyet_dinh.SelectedIndex = 0;
                    m_txt_noi_dung.Text = "";
                    m_dat_ngay_co_hieu_luc.Value = DateTime.Today;
                    m_dat_ngay_co_hieu_luc_qd.Value = DateTime.Today;
                    m_dat_ngay_het_hieu_luc.Value = DateTime.Today;
                    m_dat_ngay_het_hieu_luc_qd.Value = DateTime.Today;
                    m_dat_ngay_het_hieu_luc.Checked = false;
                    m_dat_ngay_co_hieu_luc_qd.Checked = false;
                    m_dat_ngay_ky.Value = DateTime.Today;

                    break;
                case DataEntryFormMode.SelectDataState:
                    break;
                case DataEntryFormMode.UpdateDataState:
                    us_object_to_form();
                    break;
                case DataEntryFormMode.ViewDataState:
                    break;
                default:
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
        private void generate_ma_quyet_dinh()
        {
            m_lbl_ma_qd.Text = string.Format("{0}/{1}/{2}", m_txt_ma_quyet_dinh.Text,
                                                                  m_dat_ngay_ky.Value.Year,
                                                                  m_cbo_ma_quyet_dinh.Text);
        }
        private void set_define_event()
        {
            this.Load += new EventHandler(f203_v_gd_trang_thai_lao_dong_de_Load);
            m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            m_cmd_refresh.Click += new EventHandler(m_cmd_refresh_Click);
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_cmd_bo_dinh_kem.Click += m_cmd_bo_dinh_kem_Click;
            //             m_txt_ma_quyet_dinh.TextChanged += new EventHandler(m_txt_ma_quyet_dinh_TextChanged);
            //             m_cbo_ma_quyet_dinh.SelectedIndexChanged += new EventHandler(m_cbo_ma_quyet_dinh_SelectedIndexChanged);
            //             m_dat_ngay_ky.ValueChanged += new EventHandler(m_dat_ngay_ky_ValueChanged);
        }

        private void them_quyet_dinh()
        {
            m_b_check_quyet_dinh_null = true;
            m_b_check_quyet_dinh_save = true;
            m_txt_ma_quyet_dinh.Text = "";
            m_grb_quyet_dinh.Enabled = true;
            m_txt_ma_quyet_dinh.Focus();
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
            v_frm.select_data(CHON_QUYET_DINH.TRANG_THAI_LD, ref m_us_quyet_dinh);
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
        #endregion

        #region Event Hanlders
        private void f203_v_gd_trang_thai_lao_dong_de_Load(object sendrer, EventArgs e)
        {
            try
            {

                set_inital_form_load();

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
                xoa_trang();
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
                this.Close();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
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

        private void m_txt_ma_nhan_vien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                )
            {
                e.Handled = true;
            }
        }
        private void m_cmd_bo_quyet_dinh_Click(object sender, EventArgs e)
        {
            m_txt_ma_quyet_dinh.Text = "";
        }
        private void m_ckb_trang_thai_hien_tai_yn_CheckedChanged(object sender, EventArgs e)
        {
            if (m_ckb_trang_thai_hien_tai_yn.Checked == true)
            {
                m_ckb_trang_thai_hien_tai_yn.Text = "Có";
            }
            else
            {
                m_ckb_trang_thai_hien_tai_yn.Text = "Không";
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

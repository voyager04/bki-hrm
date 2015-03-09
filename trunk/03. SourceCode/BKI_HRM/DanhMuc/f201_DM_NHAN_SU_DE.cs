using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Drawing2D;
using System.Configuration;



namespace BKI_HRM
{
    public partial class f201_DM_NHAN_SU_DE : Form
    {
        #region Public Interface
        public void display()
        {
            this.ShowDialog();
        }
        public f201_DM_NHAN_SU_DE()
        {
            InitializeComponent();
            format_controls();
        }

        public DialogResult display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_cbo_gioi_tinh.SelectedIndex = 0;
            m_txt_ma_nhan_vien.Focus();
            DialogResult v_result = this.ShowDialog();
            return v_result;
        }
        public void get_us(ref US_DM_NHAN_SU op_us)
        {
            op_us = m_us_dm_nhan_su;
        }
        public DialogResult display_for_update(US_DM_NHAN_SU ip_us_dm_nhan_su)
        {
            m_us_dm_nhan_su = ip_us_dm_nhan_su;
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_to_form();
            DialogResult v_result = this.ShowDialog();
            return v_result;
        }
        public void display_for_view(US_DM_NHAN_SU ip_us_dm_nhan_su)
        {
            m_us_dm_nhan_su = ip_us_dm_nhan_su;
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_to_form();
            m_txt_ma_nhan_vien.Enabled = false;
            m_txt_ho_dem.Enabled = false;
            m_txt_ten.Enabled = false;
            m_cbo_gioi_tinh.Enabled = false;
            m_dat_ngay_sinh.Enabled = false;
            m_txt_noi_sinh.Enabled = false;
            m_txt_nguyen_quan.Enabled = false;
            m_txt_cmnd.Enabled = false;
            m_dat_ngay_cap.Enabled = false;
            m_txt_noi_cap.Enabled = false;
            m_txt_ton_giao.Enabled = false;
            m_txt_dan_toc.Enabled = false;
            m_txt_trinh_do.Enabled = false;
            m_txt_noi_dao_tao.Enabled = false;
            m_txt_nam_tot_nghiep.Enabled = false;
            m_txt_chuyen_nganh.Enabled = false;
            m_txt_email_ca_nhan.Enabled = false;
            m_txt_email_co_quan.Enabled = false;
            m_txt_dia_chi.Enabled = false;
            m_txt_ho_khau.Enabled = false;
            m_txt_sdt_nha_rieng.Enabled = false;
            m_txt_ma_so_thue.Enabled = false;

            m_txt_nguoi_lien_he.Enabled = false;
            m_txt_quan_he.Enabled = false;
            m_txt_sdt_lien_he.Enabled = false;

            // DucVT
            m_txt_so_tai_khoan.Enabled = false;
            m_txt_chi_nhanh_ngan_hang.Enabled = false;
            m_txt_dia_diem_lam_viec.Enabled = false;
            m_txt_ho_ten_bo.Enabled = false;
            m_txt_nghe_nghiep_bo.Enabled = false;
            m_txt_nam_sinh_bo.Enabled = false;
            m_txt_ho_ten_me.Enabled = false;
            m_txt_nghe_nghiep_me.Enabled = false;
            m_txt_nam_sinh_me.Enabled = false;
            m_txt_ho_ten_con_1.Enabled = false;
            m_txt_ho_ten_con_2.Enabled = false;
            m_txt_ho_ten_con_3.Enabled = false;
            m_txt_ho_ten_vo_chong.Enabled = false;
            m_txt_nam_sinh_vo_chong.Enabled = false;
            m_txt_nghe_nghiep_vo_chong.Enabled = false;
            // ~DucVT

            m_cmd_refresh.Visible = false;
            m_cmd_save.Visible = false;
            this.ShowDialog();
        }
        #endregion

        #region Members
        DataEntryFormMode m_e_form_mode;
        US_DM_NHAN_SU m_us_dm_nhan_su = new US_DM_NHAN_SU();
        US_HT_USER m_us_ht_user = new US_HT_USER();

        Guid m_id_user_group = new Guid("dff3e0e9-b0de-42b9-86bd-ea25033425e8");

        // File explorer
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
            this.KeyPreview = true;
            m_ptb_anh.Image = m_ptb_anh.ErrorImage;
        }
        private void chon_anh()
        {
            m_ofd_chon_anh.Filter = "(*.jpg)|*.jpg";
            m_ofd_chon_anh.Multiselect = false;
            m_ofd_chon_anh.Title = "Chọn ảnh";
            DialogResult result = m_ofd_chon_anh.ShowDialog();
            if (result == DialogResult.OK)
            {
                m_ptb_anh.SizeMode = PictureBoxSizeMode.Zoom;
                m_ptb_anh.Image = new Bitmap(m_ofd_chon_anh.FileName);
            }
        }
        private void us_object_to_form()
        {
            m_txt_ma_nhan_vien.Text = m_us_dm_nhan_su.strMA_NV;
            m_txt_ho_dem.Text = m_us_dm_nhan_su.strHO_DEM;
            m_txt_ten.Text = m_us_dm_nhan_su.strTEN;
            m_cbo_gioi_tinh.SelectedIndex = (m_us_dm_nhan_su.strGIOI_TINH.Equals("Nam") == true) ? 0 : 1;
            if (m_us_dm_nhan_su.datNGAY_SINH.Year > 1900)
            {
                m_dat_ngay_sinh.Checked = true;
                m_dat_ngay_sinh.Value = m_us_dm_nhan_su.datNGAY_SINH;
            }
            else
                m_dat_ngay_sinh.Checked = false;
            m_txt_noi_sinh.Text = m_us_dm_nhan_su.strNOI_SINH;
            m_txt_nguyen_quan.Text = m_us_dm_nhan_su.strNGUYEN_QUAN;
            m_txt_cmnd.Text = m_us_dm_nhan_su.strCMND;
            if (m_us_dm_nhan_su.datNGAY_CAP_CMND.Year > 1900)
            {
                m_dat_ngay_cap.Checked = true;
                m_dat_ngay_cap.Value = m_us_dm_nhan_su.datNGAY_CAP_CMND;
            }
            else
                m_dat_ngay_cap.Checked = false;
            m_txt_noi_cap.Text = m_us_dm_nhan_su.strNOI_CAP_CMND;
            m_txt_ton_giao.Text = m_us_dm_nhan_su.strTON_GIAO;
            m_txt_dan_toc.Text = m_us_dm_nhan_su.strDAN_TOC;
            if (m_us_dm_nhan_su.strANH != "")
            {
                m_ofd_chon_anh.FileName = m_str_directory_to + m_us_dm_nhan_su.strMA_NV + ".jpg";
            }

            if (m_us_dm_nhan_su.strANH != "")
            {
                m_cmd_xoa_anh.Visible = true;
                string v_str_imagepath = m_str_directory_to + m_us_dm_nhan_su.strMA_NV + ".jpg";
                FileStream fs;
                fs = new System.IO.FileStream(v_str_imagepath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                m_ptb_anh.Image = System.Drawing.Image.FromStream(fs);
                fs.Close();
            }
            m_txt_trinh_do.Text = m_us_dm_nhan_su.strTRINH_DO;
            m_txt_noi_dao_tao.Text = m_us_dm_nhan_su.strNOI_DAO_TAO;
            m_txt_chuyen_nganh.Text = m_us_dm_nhan_su.strCHUYEN_NGANH;
            m_txt_nam_tot_nghiep.Text = (m_us_dm_nhan_su.dcNAM_TOT_NGHIEP > 0) ? CIPConvert.ToStr(m_us_dm_nhan_su.dcNAM_TOT_NGHIEP) : "";
            m_txt_email_co_quan.Text = m_us_dm_nhan_su.strEMAIL_CQ;
            m_txt_email_ca_nhan.Text = m_us_dm_nhan_su.strEMAIL_CA_NHAN;
            m_txt_so_dtdd.Text = m_us_dm_nhan_su.strDI_DONG;
            m_txt_sdt_nha_rieng.Text = m_us_dm_nhan_su.strDT_NHA;
            m_txt_ma_so_thue.Text = m_us_dm_nhan_su.strMA_SO_THUE;
            m_txt_dia_chi.Text = m_us_dm_nhan_su.strCHO_O;
            m_txt_ho_khau.Text = m_us_dm_nhan_su.strHO_KHAU;
            m_txt_ma_headcount.Text = m_us_dm_nhan_su.strMA_HEADCOUNT;

            m_txt_nguoi_lien_he.Text = m_us_dm_nhan_su.strNGUOI_LIEN_HE;
            m_txt_quan_he.Text = m_us_dm_nhan_su.strQUAN_HE;
            m_txt_sdt_lien_he.Text = m_us_dm_nhan_su.strDI_DONG_LIEN_HE;

            // DucVT
            m_txt_chi_nhanh_ngan_hang.Text = m_us_dm_nhan_su.strCHI_NHANH_NGANHANG;
            m_txt_so_tai_khoan.Text = m_us_dm_nhan_su.strSO_TAI_KHOAN;
            m_txt_dia_diem_lam_viec.Text = m_us_dm_nhan_su.strDIA_DIEM_LV;
            m_txt_ho_ten_bo.Text = m_us_dm_nhan_su.strHO_TEN_BO;
            m_txt_nghe_nghiep_bo.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_BO;
            m_txt_nam_sinh_bo.Text = m_us_dm_nhan_su.dcNAM_SINH_BO.ToString();
            m_txt_ho_ten_me.Text = m_us_dm_nhan_su.strHO_TEN_ME;
            m_txt_nghe_nghiep_me.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_ME;
            m_txt_nam_sinh_me.Text = m_us_dm_nhan_su.dcNAM_SINH_ME.ToString();
            m_txt_ho_ten_con_1.Text = m_us_dm_nhan_su.strHO_TEN_CON_THU_1;
            m_txt_nam_sinh_con_1.Text = m_us_dm_nhan_su.dcNAM_SINH_CON_THU_1.ToString();
            m_txt_nghe_nghiep_con_1.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_CON_THU_1;
            m_txt_ho_ten_con_2.Text = m_us_dm_nhan_su.strHO_TEN_CON_THU_2;
            m_txt_nam_sinh_con_2.Text = m_us_dm_nhan_su.dcNAM_SINH_CON_THU_2.ToString();
            m_txt_nghe_nghiep_con_2.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_CON_THU_2;
            m_txt_ho_ten_con_3.Text = m_us_dm_nhan_su.strHO_TEN_CON_THU_3;
            m_txt_nam_sinh_con_3.Text = m_us_dm_nhan_su.dcNAM_SINH_CON_THU_3.ToString();
            m_txt_nghe_nghiep_con_3.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_CON_THU_3;
            m_txt_ho_ten_vo_chong.Text = m_us_dm_nhan_su.strHO_TEN_VO_OR_CHONG;
            m_txt_nghe_nghiep_vo_chong.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_VO_OR_CHONG;
            m_txt_nam_sinh_vo_chong.Text = m_us_dm_nhan_su.dcNAM_SINH_VO_OR_CHONG.ToString();
            // ~DucVT

            // Tài khoản facebook
            List<US_HT_USER> v_List_Users = new HT_USER_DataAccess().GetAllUsers();
            var v_User = v_List_Users.FirstOrDefault(m => m.BHYT == m_us_dm_nhan_su.strMA_NV);
            if (v_User != null)
            {
                m_txt_id_facebook.Text = v_User.MSBN;
                m_txt_name_facebook.Text = v_User.CMND;
            }
        }

        private void form_to_us_object()
        {
            m_us_dm_nhan_su.strMA_NV = m_txt_ma_nhan_vien.Text.Trim();
            m_us_dm_nhan_su.strHO_DEM = m_txt_ho_dem.Text.Trim();
            m_us_dm_nhan_su.strTEN = m_txt_ten.Text.Trim();
            m_us_dm_nhan_su.strGIOI_TINH = ((m_cbo_gioi_tinh.SelectedIndex == 0) ? "Nam" : "Nữ");

            //   m_us_dm_nhan_su.strANH = m_txt_ma_nhan_vien.Text;


            if (m_dat_ngay_sinh.Checked == true)
                m_us_dm_nhan_su.datNGAY_SINH = m_dat_ngay_sinh.Value;
            else
                m_us_dm_nhan_su.SetNGAY_SINHNull();

            m_us_dm_nhan_su.strNOI_SINH = m_txt_noi_sinh.Text.Trim();
            m_us_dm_nhan_su.strNGUYEN_QUAN = m_txt_nguyen_quan.Text.Trim();
            m_us_dm_nhan_su.strCMND = m_txt_cmnd.Text.Trim();
            if (m_dat_ngay_cap.Checked == true)
                m_us_dm_nhan_su.datNGAY_CAP_CMND = m_dat_ngay_cap.Value;
            else
                m_us_dm_nhan_su.SetNGAY_CAP_CMNDNull();

            m_us_dm_nhan_su.strNOI_CAP_CMND = m_txt_noi_cap.Text.Trim();
            m_us_dm_nhan_su.strTON_GIAO = m_txt_ton_giao.Text.Trim();
            m_us_dm_nhan_su.strDAN_TOC = m_txt_dan_toc.Text.Trim();
            m_us_dm_nhan_su.strTRINH_DO = m_txt_trinh_do.Text.Trim();
            m_us_dm_nhan_su.strNOI_DAO_TAO = m_txt_noi_dao_tao.Text.Trim();
            m_us_dm_nhan_su.strCHUYEN_NGANH = m_txt_chuyen_nganh.Text.Trim();
            if (m_txt_nam_tot_nghiep.Text.Trim().Length > 0)
                m_us_dm_nhan_su.dcNAM_TOT_NGHIEP = CIPConvert.ToDecimal(m_txt_nam_tot_nghiep.Text.Trim());
            else
                m_us_dm_nhan_su.SetNAM_TOT_NGHIEPNull();
            m_us_dm_nhan_su.strEMAIL_CQ = m_txt_email_co_quan.Text.Trim();
            m_us_dm_nhan_su.strEMAIL_CA_NHAN = m_txt_email_ca_nhan.Text.Trim();
            m_us_dm_nhan_su.strDI_DONG = m_txt_so_dtdd.Text.Trim();
            m_us_dm_nhan_su.strDT_NHA = m_txt_sdt_nha_rieng.Text.Trim();
            m_us_dm_nhan_su.strMA_SO_THUE = m_txt_ma_so_thue.Text.Trim();
            m_us_dm_nhan_su.strCHO_O = m_txt_dia_chi.Text.Trim();
            m_us_dm_nhan_su.strHO_KHAU = m_txt_ho_khau.Text.Trim();
            m_us_dm_nhan_su.strMA_HEADCOUNT = m_txt_ma_headcount.Text.Trim();

            m_us_dm_nhan_su.strNGUOI_LIEN_HE = m_txt_nguoi_lien_he.Text;
            m_us_dm_nhan_su.strQUAN_HE = m_txt_quan_he.Text;
            m_us_dm_nhan_su.strDI_DONG_LIEN_HE = m_txt_sdt_lien_he.Text;

            // DucVT
            m_us_dm_nhan_su.strCHI_NHANH_NGANHANG = m_txt_chi_nhanh_ngan_hang.Text.Trim();
            m_us_dm_nhan_su.strSO_TAI_KHOAN = m_txt_so_tai_khoan.Text.Trim();
            m_us_dm_nhan_su.strDIA_DIEM_LV = m_txt_dia_diem_lam_viec.Text.Trim();
            m_us_dm_nhan_su.strHO_TEN_BO = m_txt_ho_ten_bo.Text.Trim();
            m_us_dm_nhan_su.strNGHE_NGHIEP_BO = m_txt_nghe_nghiep_bo.Text.Trim();
            if (m_txt_nam_sinh_bo.Text.Trim().Length > 0)
                m_us_dm_nhan_su.dcNAM_SINH_BO = CIPConvert.ToDecimal(m_txt_nam_sinh_bo.Text.Trim());
            else
                m_us_dm_nhan_su.SetNAM_SINH_BONull();
            m_us_dm_nhan_su.strHO_TEN_ME = m_txt_ho_ten_me.Text.Trim();
            m_us_dm_nhan_su.strNGHE_NGHIEP_ME = m_txt_nghe_nghiep_me.Text.Trim();
            if (m_txt_nam_sinh_me.Text.Trim().Length > 0)
                m_us_dm_nhan_su.dcNAM_SINH_ME = CIPConvert.ToDecimal(m_txt_nam_sinh_me.Text.Trim());
            else
                m_us_dm_nhan_su.SetNAM_SINH_MENull();
            m_us_dm_nhan_su.strHO_TEN_CON_THU_1 = m_txt_ho_ten_con_1.Text;
            if (m_txt_nam_sinh_con_1.Text.Trim().Length > 0)
                m_us_dm_nhan_su.dcNAM_SINH_CON_THU_1 = CIPConvert.ToDecimal(m_txt_nam_sinh_con_1.Text.Trim());
            else
                m_us_dm_nhan_su.SetNAM_SINH_CON_THU_1Null();

            m_us_dm_nhan_su.strNGHE_NGHIEP_CON_THU_1 = m_txt_nghe_nghiep_con_1.Text;
            m_us_dm_nhan_su.strHO_TEN_CON_THU_2 = m_txt_ho_ten_con_2.Text;
            if (m_txt_nam_sinh_con_2.Text.Trim().Length > 0)
                m_us_dm_nhan_su.dcNAM_SINH_CON_THU_2 = CIPConvert.ToDecimal(m_txt_nam_sinh_con_2.Text.Trim());
            else
                m_us_dm_nhan_su.SetNAM_SINH_CON_THU_2Null();
            m_us_dm_nhan_su.strNGHE_NGHIEP_CON_THU_2 = m_txt_nghe_nghiep_con_2.Text;

            m_us_dm_nhan_su.strHO_TEN_CON_THU_3 = m_txt_ho_ten_con_3.Text;
            if (m_txt_nam_sinh_con_3.Text.Trim().Length > 0)
                m_us_dm_nhan_su.dcNAM_SINH_CON_THU_3 = CIPConvert.ToDecimal(m_txt_nam_sinh_con_3.Text.Trim());
            else
                m_us_dm_nhan_su.SetNAM_SINH_CON_THU_3Null();
            m_us_dm_nhan_su.strNGHE_NGHIEP_CON_THU_3 = m_txt_nghe_nghiep_con_3.Text;

            m_us_dm_nhan_su.strHO_TEN_VO_OR_CHONG = m_txt_ho_ten_vo_chong.Text;
            m_us_dm_nhan_su.strNGHE_NGHIEP_VO_OR_CHONG = m_txt_nghe_nghiep_vo_chong.Text;
            if (m_txt_nam_sinh_vo_chong.Text.Trim().Length > 0)
                m_us_dm_nhan_su.dcNAM_SINH_VO_OR_CHONG = CIPConvert.ToDecimal(m_txt_nam_sinh_vo_chong.Text.Trim());
            else
                m_us_dm_nhan_su.SetNAM_SINH_VO_OR_CHONGNull();
            // ~DucVT
        }
        private void controller_ht_user(DataEntryFormMode mode, US_DM_NHAN_SU ip_us)
        {
            m_us_ht_user.BHYT = ip_us.strMA_NV;
            m_us_ht_user.CMND = m_txt_name_facebook.Text;
            m_us_ht_user.MSBN = m_txt_id_facebook.Text;
            m_us_ht_user.USERNAME = ip_us.strEMAIL_CQ;
            m_us_ht_user.PASSWORD = "123456";
            m_us_ht_user.HO = ip_us.strHO_DEM;
            m_us_ht_user.TEN = ip_us.strTEN;
            m_us_ht_user.IS_ACTIVE = true;
            m_us_ht_user.ID_USER_GROUP = m_id_user_group;

            if (mode == DataEntryFormMode.InsertDataState)
            {
                m_us_ht_user.ID = Guid.NewGuid();
                new HT_USER_DataAccess().Insert(m_us_ht_user);
            }
            if (mode == DataEntryFormMode.UpdateDataState)
            {
                var controller = new HT_USER_DataAccess();
                var v_list_user = controller.GetAllUsers();
                var v_user = v_list_user.FirstOrDefault(m => m.BHYT == ip_us.strMA_NV);
                if (v_user != null)
                {
                    m_us_ht_user.ID = v_user.ID;
                    controller.Update(m_us_ht_user);
                }
            }
        }

        private bool check_trung_ma_nv(string ip_str_ma_nv)
        {
            DS_DM_NHAN_SU v_ds = new DS_DM_NHAN_SU();
            decimal count_ma_nv;
            m_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds, ip_str_ma_nv);
            count_ma_nv = v_ds.DM_NHAN_SU.Count;
            if (count_ma_nv > 0)
                return true;
            return false;
        }
        private bool check_validate_data_is_ok()
        {
            if (!CValidateTextBox.IsValid(m_txt_ma_nhan_vien, DataType.NumberType, allowNull.NO, true))
            {
                BaseMessages.MsgBox_Warning(201);
                return false;
            }

            if (!CValidateTextBox.IsValid(m_txt_ho_dem, DataType.StringType, allowNull.NO, true) || CIPConvert.is_valid_number(m_txt_ho_dem))
            {
                BaseMessages.MsgBox_Warning(202);
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_ten, DataType.StringType, allowNull.NO, true) || CIPConvert.is_valid_number(m_txt_ten))
            {
                BaseMessages.MsgBox_Warning(203);
                return false;
            }
            //if (m_cbo_gioi_tinh.SelectedIndex == 0)
            //{
            //    BaseMessages.MsgBox_Warning(204);
            //    return false;
            //}
            /*if ((m_dat_ngay_sinh.Checked == true) && (DateTime.Today.Year - m_dat_ngay_sinh.Value.Year) < 15)
            {
                BaseMessages.MsgBox_Warning(205);
                return false;
            }*/
            /*if ((m_dat_ngay_sinh.Checked == true)
                && (m_dat_ngay_cap.Checked == true)
                && (m_dat_ngay_cap.Value.Year - m_dat_ngay_sinh.Value.Year < 10))
            {
                BaseMessages.MsgBox_Warning(219);
                return false;
            }*/
            /*if ((m_dat_ngay_cap.Checked == true) && (m_dat_ngay_cap.Value.Date > DateTime.Today))
            {
                BaseMessages.MsgBox_Warning(220);
                return false;
            }*/
            if (!CValidateTextBox.IsValid(m_txt_noi_sinh, DataType.StringType, allowNull.YES, true))
            {
                BaseMessages.MsgBox_Warning(206);
                return false;
            }
            /*if (!CValidateTextBox.IsValid(m_txt_cmnd, DataType.NumberType, allowNull.YES, true))
            {
                BaseMessages.MsgBox_Warning(208);
                return false;
            }*/
            if (!CValidateTextBox.IsValid(m_txt_noi_cap, DataType.StringType, allowNull.YES, true))
                return false;

            /*if ((m_dat_ngay_cap.Checked == true) && (m_dat_ngay_cap.Value.Year < (m_dat_ngay_sinh.Value.Year + 14)))
            {
                BaseMessages.MsgBox_Warning(209);
                return false;
            }*/
            if (!CValidateTextBox.IsValid(m_txt_ton_giao, DataType.StringType, allowNull.YES, true))
            {

                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_dan_toc, DataType.StringType, allowNull.YES, true))
                return false;
            /*if (!CValidateTextBox.IsValid(m_txt_nam_tot_nghiep, DataType.NumberType, allowNull.YES, true)
                || ((m_txt_nam_tot_nghiep.Text.Trim().Length > 0) && (CIPConvert.ToDecimal(m_txt_nam_tot_nghiep.Text) > DateTime.Today.Year)))
            {
                //BaseMessages.MsgBox_Warning(211);
                return false;
            }*/
            /*if (!CValidateTextBox.IsValid(m_txt_email_ca_nhan, DataType.StringType, allowNull.YES, true) || !check_validate_email(m_txt_email_ca_nhan.Text))
            {
                BaseMessages.MsgBox_Warning(211);
                m_txt_email_ca_nhan.BackColor = Color.Bisque;
                m_txt_email_ca_nhan.Focus();
                m_txt_email_ca_nhan.SelectAll();
                return false;
            }*/

            /*if (!(m_txt_email_co_quan.Text.Length > 0 && check_validate_email(m_txt_email_co_quan.Text)))
            {
                BaseMessages.MsgBox_Warning(211);
                m_txt_email_co_quan.BackColor = Color.Bisque;
                m_txt_email_co_quan.Focus();
                m_txt_email_co_quan.SelectAll();
                tabControl1.SelectTab(tabPage3);
                return false;
            }*/
            if (!CValidateTextBox.IsValid(m_txt_so_dtdd, DataType.StringType, allowNull.YES, true))
            {

                BaseMessages.MsgBox_Warning(210);
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_sdt_nha_rieng, DataType.StringType, allowNull.YES, true))
            {
                BaseMessages.MsgBox_Warning(210);
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_ma_so_thue, DataType.NumberType, allowNull.YES, true))
                return false;
            if (!CValidateTextBox.IsValid(m_txt_dia_chi, DataType.StringType, allowNull.YES, true))
            {
                BaseMessages.MsgBox_Warning(210);
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_ho_khau, DataType.StringType, allowNull.YES, true))
                return false;
            if (!CValidateTextBox.IsValid(m_txt_so_tai_khoan, DataType.NumberType, allowNull.YES, true))
                return false;
            if (!CValidateTextBox.IsValid(m_txt_nam_sinh_bo, DataType.NumberType, allowNull.YES, true))
                return false;
            if (!CValidateTextBox.IsValid(m_txt_nam_sinh_me, DataType.NumberType, allowNull.YES, true))
                return false;
            return true;
        }
        private void save_image(string ip_str_pathimage)
        {

            if (ip_str_pathimage != "" && m_ofd_chon_anh.FileName != "")
            {
                if (m_e_file_mode != DataEntryFileMode.DeleteFile)
                {
                    if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\" + m_us_dm_nhan_su.strMA_NV + ".jpg"))
                    {
                        File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\" + m_us_dm_nhan_su.strMA_NV + ".jpg");
                    }
                    if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\temp.jpg"))
                    {
                        File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\temp.jpg");
                    }
                    if (ip_str_pathimage == m_str_directory_to + m_us_dm_nhan_su.strMA_NV + ".jpg")
                    {
                        File.Copy(m_str_directory_to + m_us_dm_nhan_su.strMA_NV + ".jpg", Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\temp.jpg");
                        ip_str_pathimage = Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\temp.jpg";
                    }


                    int maxWidth = 120,
                        maxHeight = 160;
                    Bitmap image = new Bitmap(ip_str_pathimage);
                    // Get the image's original width and height
                    int originalWidth = image.Width;
                    int originalHeight = image.Height;

                    // To preserve the aspect ratio
                    float ratioX = (float)maxWidth / (float)originalWidth;
                    float ratioY = (float)maxHeight / (float)originalHeight;
                    float ratio = Math.Min(ratioX, ratioY);

                    // New width and height based on aspect ratio
                    int newWidth = (int)(originalWidth * ratio);
                    int newHeight = (int)(originalHeight * ratio);

                    // Convert other formats (including CMYK) to RGB.
                    Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

                    // Draws the image in the specified size with quality mode set to HighQuality
                    using (Graphics graphics = Graphics.FromImage(newImage))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                    }
                    newImage.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\" + m_txt_ma_nhan_vien.Text + ".jpg", ImageFormat.Jpeg);
                }


                switch (m_e_file_mode)
                {
                    case DataEntryFileMode.DeleteFile:
                        File.Delete(m_str_directory_to + m_us_dm_nhan_su.strMA_NV + ".jpg");

                        m_us_dm_nhan_su.SetANHNull();
                        break;
                    case DataEntryFileMode.EditFile:
                        if (File.Exists(m_str_directory_to + m_txt_ma_nhan_vien.Text + ".jpg"))
                        {
                            File.Delete(m_str_directory_to + m_txt_ma_nhan_vien.Text + ".jpg");
                        }
                        FileExplorer.UploadFile_with_filename(m_str_domain, m_str_directory_to, Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\", m_txt_ma_nhan_vien.Text + ".jpg");
                        // m_us_dm_nhan_su.strANH = Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\" + m_us_dm_nhan_su.strMA_NV + ".jpg";
                        m_us_dm_nhan_su.strANH = m_us_dm_nhan_su.strMA_NV;
                        break;
                    case DataEntryFileMode.UploadFile:
                        if (File.Exists(m_str_directory_to + m_txt_ma_nhan_vien.Text + ".jpg"))
                        {
                            File.Delete(m_str_directory_to + m_txt_ma_nhan_vien.Text + ".jpg");
                        }
                        FileExplorer.UploadFile_with_filename(m_str_domain, m_str_directory_to, Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\", m_txt_ma_nhan_vien.Text + ".jpg");
                        // m_us_dm_nhan_su.strANH = Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\" + m_us_dm_nhan_su.strMA_NV + ".jpg";
                        m_us_dm_nhan_su.strANH = m_txt_ma_nhan_vien.Text;
                        break;
                    default:

                        break;
                }

            }

        }
        private void save_data()
        {
            switch (m_e_form_mode)
            {

                case DataEntryFormMode.UpdateDataState:
                    if (check_validate_data_is_ok() == false)
                        return;
                    else
                    {
                        save_image(m_ofd_chon_anh.FileName);
                        form_to_us_object();
                        m_us_dm_nhan_su.Update();
                        controller_ht_user(DataEntryFormMode.UpdateDataState, m_us_dm_nhan_su);
                    }

                    break;
                case DataEntryFormMode.InsertDataState:
                    if (check_trung_ma_nv(m_txt_ma_nhan_vien.Text))
                    {
                        BaseMessages.MsgBox_Warning(212);
                        m_txt_ma_nhan_vien.BackColor = Color.Bisque;
                        m_txt_ma_nhan_vien.Focus();
                        m_txt_ma_nhan_vien.SelectAll();
                        return;
                    }
                    else
                    {

                        m_txt_ma_nhan_vien.BackColor = Color.White;
                        if (check_validate_data_is_ok() == false)
                            return;
                        else
                        {
                            save_image(m_ofd_chon_anh.FileName);
                            form_to_us_object();
                            m_us_dm_nhan_su.Insert();
                            controller_ht_user(DataEntryFormMode.InsertDataState, m_us_dm_nhan_su);
                        }

                    }

                    break;
                default:
                    break;
            }

            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhât!");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        private void xoa_trang()
        {
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    m_txt_ma_nhan_vien.Text = "";
                    m_txt_ho_dem.Text = "";
                    m_txt_ten.Text = "";
                    m_cbo_gioi_tinh.SelectedIndex = 0;
                    m_dat_ngay_sinh.Value = DateTime.Today;
                    m_dat_ngay_sinh.Checked = false;
                    m_txt_noi_sinh.Text = "";
                    m_txt_nguyen_quan.Text = "";
                    m_txt_cmnd.Text = "";
                    //  m_dat_ngay_cap.Value = DateTime.Today;
                    m_dat_ngay_cap.Checked = false;
                    m_txt_noi_cap.Text = "";
                    m_txt_ton_giao.Text = "";
                    m_txt_dan_toc.Text = "";
                    m_txt_trinh_do.Text = "";
                    m_txt_noi_dao_tao.Text = "";
                    m_txt_chuyen_nganh.Text = "";
                    m_txt_nam_tot_nghiep.Text = "";
                    m_txt_email_co_quan.Text = "";
                    m_txt_email_ca_nhan.Text = "";
                    m_txt_so_dtdd.Text = "";
                    m_txt_sdt_nha_rieng.Text = "";
                    m_txt_ma_so_thue.Text = "";
                    m_txt_dia_chi.Text = "";
                    m_txt_ho_khau.Text = "";

                    m_txt_nguoi_lien_he.Text = "";
                    m_txt_quan_he.Text = "";
                    m_txt_sdt_lien_he.Text = "";

                    // DucVT
                    m_txt_chi_nhanh_ngan_hang.Text = "";
                    m_txt_so_tai_khoan.Text = "";
                    m_txt_dia_diem_lam_viec.Text = "";
                    m_txt_ho_ten_bo.Text = "";
                    m_txt_nghe_nghiep_bo.Text = "";
                    m_txt_nam_sinh_bo.Text = "";
                    m_txt_ho_ten_me.Text = "";
                    m_txt_nghe_nghiep_me.Text = "";
                    m_txt_nam_sinh_me.Text = "";
                    m_txt_ho_ten_con_1.Text = "";
                    m_txt_nam_sinh_con_1.Text = "";
                    m_txt_nghe_nghiep_con_1.Text = "";
                    m_txt_ho_ten_con_2.Text = "";
                    m_txt_nam_sinh_con_2.Text = "";
                    m_txt_nghe_nghiep_con_2.Text = "";
                    m_txt_ho_ten_con_3.Text = "";
                    m_txt_nam_sinh_con_3.Text = "";
                    m_txt_nghe_nghiep_con_3.Text = "";
                    m_txt_ho_ten_vo_chong.Text = "";
                    m_txt_nam_sinh_vo_chong.Text = "";
                    m_txt_nghe_nghiep_vo_chong.Text = "";
                    // ~DucVT

                    m_ptb_anh.Image = m_ptb_anh.ErrorImage;
                    m_ofd_chon_anh.FileName = "";
                    break;
                case DataEntryFormMode.SelectDataState:
                    break;
                case DataEntryFormMode.UpdateDataState:
                    us_object_to_form();
                    if (m_us_dm_nhan_su.strANH != "")
                    {
                        string v_str_imagepath = m_str_directory_to + m_us_dm_nhan_su.strMA_NV + ".jpg";
                        FileStream fs;
                        fs = new System.IO.FileStream(v_str_imagepath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        m_ptb_anh.Image = System.Drawing.Image.FromStream(fs);
                        fs.Close();
                    }
                    else
                    {
                        m_ptb_anh.Image = m_ptb_anh.ErrorImage;
                    }
                    m_ofd_chon_anh.FileName = "";
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
        private void send_email(US_DM_NHAN_SU ip_us)
        {
            if (ip_us.strEMAIL_CQ == "" || ip_us.strEMAIL_CQ.Length == 0)
            {
                MessageBox.Show("Nhân viên này chưa có tài khoản email cơ quan", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string v_str_confirm =
                string.Format(" Bạn muốn dùng email {0} gửi hướng dẫn thêm tài khoản Facebook cho {1} ({2})?",
                "hoangnh@topica.edu.vn", ip_us.strEMAIL_CQ, ip_us.strHO_DEM + " " + ip_us.strTEN);
            var dialog = MessageBox.Show(v_str_confirm,
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (dialog == DialogResult.Yes)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("hoangnh@topica.edu.vn");
                mail.To.Add("91apple.nguyen@gmail.com");
                mail.Subject = "Hướng dẫn: Thêm tài khoản Facebook vào website quản lý nhân sự của TOPICA";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hoangnh@topica.edu.vn", "topica@999");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Email đã được gửi! Xin cám ơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        private void set_define_event()
        {
            this.Load += new EventHandler(f201_DM_NHAN_SU_DE_Load);
            m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            m_cmd_refresh.Click += new EventHandler(m_cmd_refresh_Click);
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_cmd_xoa_anh.Click += new EventHandler(m_cmd_xoa_anh_Click);
        }


        private bool check_validate_email(string emailaddress)
        {
            if (emailaddress == "") return true;
            string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";



            return Regex.IsMatch(emailaddress, MatchEmailPattern);

        }
        #endregion

        #region Event Hanlders
        private void f201_DM_NHAN_SU_DE_Load(object sendrer, EventArgs e)
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
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    m_txt_ma_nhan_vien.Text = "";
                    m_txt_ho_dem.Text = "";
                    m_txt_ten.Text = "";
                    m_cbo_gioi_tinh.SelectedIndex = 0;
                    m_dat_ngay_sinh.Checked = false;
                    m_dat_ngay_sinh.Value = DateTime.Today;
                    m_txt_noi_sinh.Text = "";
                    m_txt_nguyen_quan.Text = "";
                    m_txt_cmnd.Text = "";
                    m_dat_ngay_cap.Checked = false;
                    m_dat_ngay_cap.Value = DateTime.Today;
                    m_txt_noi_cap.Text = "";
                    m_txt_ton_giao.Text = "";
                    m_txt_dan_toc.Text = "";
                    m_txt_ma_headcount.Text = "";
                    m_ofd_chon_anh.FileName = "";
                    m_ptb_anh.Image = m_ptb_anh.ErrorImage;
                    m_txt_trinh_do.Text = "";
                    m_txt_noi_dao_tao.Text = "";
                    m_txt_chuyen_nganh.Text = "";
                    m_txt_nam_tot_nghiep.Text = "";
                    m_txt_email_co_quan.Text = "";
                    m_txt_email_ca_nhan.Text = "";
                    m_txt_sdt_nha_rieng.Text = "";
                    m_txt_so_dtdd.Text = "";
                    m_txt_ma_so_thue.Text = "";
                    m_txt_ho_khau.Text = "";
                    m_txt_dia_chi.Text = "";

                    m_txt_nguoi_lien_he.Text = "";
                    m_txt_quan_he.Text = "";
                    m_txt_sdt_lien_he.Text = "";

                    // DucVT
                    m_txt_chi_nhanh_ngan_hang.Text = "";
                    m_txt_so_tai_khoan.Text = "";
                    m_txt_dia_diem_lam_viec.Text = "";
                    m_txt_ho_ten_bo.Text = "";
                    m_txt_nghe_nghiep_bo.Text = "";
                    m_txt_nam_sinh_bo.Text = "";
                    m_txt_ho_ten_me.Text = "";
                    m_txt_nghe_nghiep_me.Text = "";
                    m_txt_nam_sinh_me.Text = "";
                    m_txt_ho_ten_con_1.Text = "";
                    m_txt_nam_sinh_con_1.Text = "";
                    m_txt_nghe_nghiep_con_1.Text = "";
                    m_txt_ho_ten_con_2.Text = "";
                    m_txt_nam_sinh_con_2.Text = "";
                    m_txt_nghe_nghiep_con_2.Text = "";
                    m_txt_ho_ten_con_3.Text = "";
                    m_txt_nam_sinh_con_3.Text = "";
                    m_txt_nghe_nghiep_con_3.Text = "";
                    m_txt_ho_ten_vo_chong.Text = "";
                    m_txt_nam_sinh_vo_chong.Text = "";
                    m_txt_nghe_nghiep_vo_chong.Text = "";
                    // ~DucVT

                    break;
                case DataEntryFormMode.UpdateDataState:
                    m_txt_ma_nhan_vien.Text = m_us_dm_nhan_su.strMA_NV;
                    m_txt_ho_dem.Text = m_us_dm_nhan_su.strHO_DEM;
                    m_txt_ten.Text = m_us_dm_nhan_su.strTEN;
                    m_cbo_gioi_tinh.SelectedIndex = m_us_dm_nhan_su.strGIOI_TINH == "Nam" ? 0 : 1;
                    m_dat_ngay_sinh.Checked = m_us_dm_nhan_su.datNGAY_SINH > DateTime.Parse("1900/1/1") ? true : false;
                    m_dat_ngay_sinh.Value = m_us_dm_nhan_su.datNGAY_SINH > DateTime.Parse("1900/1/1") ? m_us_dm_nhan_su.datNGAY_SINH : DateTime.Today;
                    if (m_dat_ngay_sinh.Value == DateTime.Today)
                        m_dat_ngay_sinh.Checked = false;
                    m_txt_noi_sinh.Text = m_us_dm_nhan_su.strNOI_SINH;
                    m_txt_nguyen_quan.Text = m_us_dm_nhan_su.strNGUYEN_QUAN;
                    m_txt_cmnd.Text = m_us_dm_nhan_su.strCMND;
                    m_dat_ngay_cap.Checked = m_us_dm_nhan_su.datNGAY_CAP_CMND > DateTime.Parse("1900/1/1") ? true : false;
                    m_dat_ngay_cap.Value = m_us_dm_nhan_su.datNGAY_CAP_CMND > DateTime.Parse("1900/1/1") ? m_us_dm_nhan_su.datNGAY_CAP_CMND : DateTime.Today;
                    if (m_dat_ngay_cap.Value == DateTime.Today)
                    {
                        m_dat_ngay_cap.Checked = false;
                    }
                    m_txt_noi_cap.Text = m_us_dm_nhan_su.strNOI_CAP_CMND;
                    m_txt_ton_giao.Text = m_us_dm_nhan_su.strTON_GIAO;
                    m_txt_dan_toc.Text = m_us_dm_nhan_su.strDAN_TOC;
                    m_txt_ma_headcount.Text = m_us_dm_nhan_su.strMA_HEADCOUNT;
                    if (m_us_dm_nhan_su.strANH != "")
                    {
                        m_ofd_chon_anh.FileName = m_str_directory_to + m_us_dm_nhan_su.strMA_NV + ".jpg";
                    }
                    else
                        m_ofd_chon_anh.FileName = "";
                    if (m_us_dm_nhan_su.strANH != "")
                    {
                        m_cmd_xoa_anh.Visible = true;
                        string v_str_imagepath = m_str_directory_to + m_us_dm_nhan_su.strMA_NV + ".jpg";
                        FileStream fs;
                        fs = new System.IO.FileStream(v_str_imagepath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        m_ptb_anh.Image = System.Drawing.Image.FromStream(fs);
                        fs.Close();
                    }
                    else
                    {
                        m_ptb_anh.Image = m_ptb_anh.ErrorImage;
                    }
                    m_txt_trinh_do.Text = m_us_dm_nhan_su.strTRINH_DO;
                    m_txt_noi_dao_tao.Text = m_us_dm_nhan_su.strNOI_DAO_TAO;
                    m_txt_chuyen_nganh.Text = m_us_dm_nhan_su.strCHUYEN_NGANH;
                    m_txt_nam_tot_nghiep.Text = m_us_dm_nhan_su.dcNAM_TOT_NGHIEP.ToString();
                    m_txt_email_co_quan.Text = m_us_dm_nhan_su.strEMAIL_CQ;
                    m_txt_email_ca_nhan.Text = m_us_dm_nhan_su.strEMAIL_CA_NHAN;
                    m_txt_sdt_nha_rieng.Text = m_us_dm_nhan_su.strDT_NHA;
                    m_txt_so_dtdd.Text = m_us_dm_nhan_su.strDI_DONG;
                    m_txt_ma_so_thue.Text = m_us_dm_nhan_su.strMA_SO_THUE;
                    m_txt_ho_khau.Text = m_us_dm_nhan_su.strHO_KHAU;
                    m_txt_dia_chi.Text = m_us_dm_nhan_su.strCHO_O;

                    m_txt_nguoi_lien_he.Text = m_us_dm_nhan_su.strNGUOI_LIEN_HE;
                    m_txt_quan_he.Text = m_us_dm_nhan_su.strQUAN_HE;
                    m_txt_sdt_lien_he.Text = m_us_dm_nhan_su.strDI_DONG_LIEN_HE;

                    // DucVT
                    m_txt_chi_nhanh_ngan_hang.Text = m_us_dm_nhan_su.strCHI_NHANH_NGANHANG;
                    m_txt_so_tai_khoan.Text = m_us_dm_nhan_su.strSO_TAI_KHOAN;
                    m_txt_dia_diem_lam_viec.Text = m_us_dm_nhan_su.strDIA_DIEM_LV;
                    m_txt_ho_ten_bo.Text = m_us_dm_nhan_su.strHO_TEN_BO;
                    m_txt_nghe_nghiep_bo.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_BO;
                    m_txt_nam_sinh_bo.Text = m_us_dm_nhan_su.dcNAM_SINH_BO.ToString();
                    m_txt_ho_ten_me.Text = m_us_dm_nhan_su.strHO_TEN_ME;
                    m_txt_nghe_nghiep_me.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_ME;
                    m_txt_nam_sinh_me.Text = m_us_dm_nhan_su.dcNAM_SINH_ME.ToString();
                    m_txt_ho_ten_con_1.Text = m_us_dm_nhan_su.strHO_TEN_CON_THU_1;
                    m_txt_nam_sinh_con_1.Text = m_us_dm_nhan_su.dcNAM_SINH_CON_THU_1.ToString();
                    m_txt_nghe_nghiep_con_1.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_CON_THU_1;
                    m_txt_ho_ten_con_2.Text = m_us_dm_nhan_su.strHO_TEN_CON_THU_2;
                    m_txt_nam_sinh_con_2.Text = m_us_dm_nhan_su.dcNAM_SINH_CON_THU_2.ToString();
                    m_txt_nghe_nghiep_con_2.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_CON_THU_2;
                    m_txt_ho_ten_con_3.Text = m_us_dm_nhan_su.strHO_TEN_CON_THU_3;
                    m_txt_nam_sinh_con_3.Text = m_us_dm_nhan_su.dcNAM_SINH_CON_THU_3.ToString();
                    m_txt_nghe_nghiep_con_3.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_CON_THU_3;
                    m_txt_ho_ten_vo_chong.Text = m_us_dm_nhan_su.strHO_TEN_VO_OR_CHONG;
                    m_txt_nghe_nghiep_vo_chong.Text = m_us_dm_nhan_su.strNGHE_NGHIEP_VO_OR_CHONG;
                    m_txt_nam_sinh_vo_chong.Text = m_us_dm_nhan_su.dcNAM_SINH_VO_OR_CHONG.ToString();
                    // ~DucVT

                    break;
            }
        }
        private void m_cmd_exit_Click(object sender, EventArgs e)
        {

        }


        private void m_ptb_anh_Click(object sender, EventArgs e)
        {
            try
            {
                chon_anh();
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

        private void m_txt_cmnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (!char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
        }

        private void m_txt_nam_tot_nghiep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        )
            {
                e.Handled = true;
            }

            //             if ((sender as TextBox).Text.Length > 4)
            //             {
            //                 e.Handled = true;
            //             }
        }

        private void m_txt_so_dtdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }


        }

        private void m_txt_sdt_nha_rieng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }


        }

        private void m_txt_sdt_lien_he_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }


        }

        private void m_txt_ho_dem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {

                e.Handled = true;
            }


        }

        private void m_txt_ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {

                e.Handled = true;
            }
        }

        private void m_txt_ton_giao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {

                e.Handled = true;
            }
        }

        private void m_txt_dan_toc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {

                e.Handled = true;
            }
        }

        private void m_txt_noi_cap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {

                e.Handled = true;
            }
        }

        private void m_txt_ma_so_thue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void m_txt_email_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void m_ptb_anh_MouseHover(object sender, EventArgs e)
        {
            m_ptb_anh.Image = m_ptb_anh.ErrorImage;
        }

        private void m_ptb_anh_MouseLeave(object sender, EventArgs e)
        {
            if (m_us_dm_nhan_su.strANH != "")
            {
                string v_str_imagepath = m_str_directory_to + m_us_dm_nhan_su.strMA_NV + ".jpg";
                FileStream fs;
                fs = new System.IO.FileStream(v_str_imagepath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                m_ptb_anh.Image = System.Drawing.Image.FromStream(fs);
                fs.Close();
            }

        }

        private void m_cmd_xoa_anh_Click(object sender, EventArgs e)
        {
            m_e_file_mode = DataEntryFileMode.DeleteFile;
            m_ptb_anh.Image = m_ptb_anh.ErrorImage;
        }

        private void m_txt_noi_sinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            //             if (!char.IsControl(e.KeyChar)
            //         && !char.IsLetterOrDigit(e.KeyChar)
            //         && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '/' && e.KeyChar != ',')
            //             {
            //                 e.Handled = true;
            //             }
            //            
        }

        private void m_cmd_send_email_Click(object sender, EventArgs e)
        {
            try
            {
                send_email(m_us_dm_nhan_su);
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion
    }
}
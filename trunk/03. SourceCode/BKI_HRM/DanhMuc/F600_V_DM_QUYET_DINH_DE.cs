using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.NghiepVu;
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPSystemAdmin;
using IP.Core.IPUserService;
using System.IO;
namespace BKI_HRM.DanhMuc
{
    public partial class F600_V_DM_QUYET_DINH_DE : Form
    {
        #region Public Interfaces
        public F600_V_DM_QUYET_DINH_DE()
        {
            InitializeComponent();
            /*Load Combobox Loai quyet dinh*/
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH,
                WinFormControls.eTAT_CA.NO,
                m_cbo_loai_quyet_dinh);

            m_cbo_loai_quyet_dinh.SelectedIndex = 0;
            format_control();
        }

        public void get_us(ref US_DM_QUYET_DINH op_us)
        {
            op_us = m_us;
        }

        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_e_file_mode = DataEntryFileMode.UploadFile;
            this.ShowDialog();
        }

        public void display_for_update(US_V_DM_QUYET_DINH ip_m_us_v_dm_quyet_dinh)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form(ip_m_us_v_dm_quyet_dinh);
            m_e_file_mode = DataEntryFileMode.EditFile;
            m_str_link_old = m_lbl_file_name.Text;
            this.ShowDialog();
        }
        #endregion

        #region Data Structures
        #endregion

        #region Members
        private DataEntryFormMode m_e_form_mode;
        private US_V_DM_QUYET_DINH m_v_us = new US_V_DM_QUYET_DINH();
        private DS_V_DM_QUYET_DINH m_v_ds = new DS_V_DM_QUYET_DINH();
        private US_DM_QUYET_DINH m_us = new US_DM_QUYET_DINH();
        private DS_DM_QUYET_DINH m_ds = new DS_DM_QUYET_DINH();
        private US_GD_QUYET_DINH_PHAP_NHAN m_us_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
        private DS_GD_QUYET_DINH_PHAP_NHAN m_ds_quyet_dinh_phap_nhan = new DS_GD_QUYET_DINH_PHAP_NHAN();

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
            decimal count_ma_quyet_dinh;
            m_v_us.FillDataset_By_Ma_qd(v_ds, ip_str_ma_quyet_dinh);
            count_ma_quyet_dinh = v_ds.V_DM_QUYET_DINH.Count;
            if (count_ma_quyet_dinh > 0)
                return true;
            return false;
        }

        private bool check_format_ma_qd()
        {
             return m_txt_ma_quyet_dinh.Text.Contains("/")?true: false;
        }

        private void us_object_2_form(US_V_DM_QUYET_DINH ip_us_v_dm_quyet_dinh)
        {
            m_us.dcID = ip_us_v_dm_quyet_dinh.dcID;

            //m_txt_link.Text = ip_us_v_dm_quyet_dinh.strLINK;
            m_txt_ma_quyet_dinh.Text = ip_us_v_dm_quyet_dinh.strMA_QUYET_DINH;
            m_txt_noi_dung.Text = ip_us_v_dm_quyet_dinh.strNOI_DUNG;
            if (ip_us_v_dm_quyet_dinh.datNGAY_HET_HIEU_LUC.Year > 1900)
                m_dat_ngay_het_hieu_luc.Value = ip_us_v_dm_quyet_dinh.datNGAY_HET_HIEU_LUC;
            else
                m_dat_ngay_het_hieu_luc.Checked = false;
            if (ip_us_v_dm_quyet_dinh.datNGAY_CO_HIEU_LUC.Year > 1900)
                m_dat_ngay_co_hieu_luc.Value = ip_us_v_dm_quyet_dinh.datNGAY_CO_HIEU_LUC;
            else
                m_dat_ngay_co_hieu_luc.Checked = false;
            if (ip_us_v_dm_quyet_dinh.datNGAY_KY.Year > 1900)
                m_dat_ngay_ky.Value = ip_us_v_dm_quyet_dinh.datNGAY_KY;
            else
                m_dat_ngay_ky.Checked = false;

            m_cbo_loai_quyet_dinh.SelectedValue = ip_us_v_dm_quyet_dinh.dcID_LOAI_QD;
            m_str_link_old = ip_us_v_dm_quyet_dinh.strLINK;
            m_lbl_file_name.Text = ip_us_v_dm_quyet_dinh.strLINK;
            if (ip_us_v_dm_quyet_dinh.strLINK == "") return;
            string[] v_strs = ip_us_v_dm_quyet_dinh.strLINK.Split('\\');

        }

        private void chon_file()
        {
            FileExplorer.SelectFile(m_ofd_chon_file, m_str_link_old);
            m_lbl_file_name.Text = FileExplorer.fileName;
        }

        private void view_hop_dong_saved()
        {
            f701_v_gd_hop_dong_lao_dong_View frm = new f701_v_gd_hop_dong_lao_dong_View();
            frm.display(ConfigurationSettings.AppSettings["DESTINATION_NAME"] + new US_DM_QUYET_DINH(m_us.dcID).strLINK);
        }

        private bool check_data_is_ok()
        {
            //if (check_trung_ma_quyet_dinh(m_txt_ma_quyet_dinh.Text.Trim()))
            //{
            //    BaseMessages.MsgBox_Error("Đã có mã Quyết định này!");
            //    return false;
            //}
            //return CValidateTextBox.IsValid(m_txt_ma_quyet_dinh, DataType.StringType, allowNull.NO, true) && kiem_tra_ngay_truoc_sau();
            /*if (!check_format_ma_qd())
            {
                BaseMessages.MsgBox_Infor("Mã quyết định chưa đúng định dạng.");
                return false;
            }*/
            if (!CValidateTextBox.IsValid(m_txt_ma_quyet_dinh, DataType.StringType, allowNull.NO, true))
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập mã quyết định.");
                return false;
            }
            string[] v_arstr = m_txt_ma_quyet_dinh.Text.Trim().Split('/');
            if (!CIPConvert.is_valid_number(v_arstr[0].Substring(0, v_arstr[0].Length - 1)))
            {
                BaseMessages.MsgBox_Infor("Mã quyết định không đúng định dạng.");
                return false;
            }
            return kiem_tra_ngay_truoc_sau();
        }

        private bool kiem_tra_ngay_truoc_sau()
        {
            if (m_dat_ngay_co_hieu_luc.Value.Date >= m_dat_ngay_het_hieu_luc.Value.Date
                && m_dat_ngay_co_hieu_luc.Checked == true && m_dat_ngay_het_hieu_luc.Checked == true
                )
            {
                BaseMessages.MsgBox_Error("Ngày có hiệu lực phải trước ngày hết hiệu lực!");
                return false;
            }
            return true;
        }

        private void form_2_us_object()
        {
            m_us.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text.Trim();
            m_us.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value.Date;

            if (m_dat_ngay_het_hieu_luc.Checked)
            {
                m_us.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc.Value.Date;
            }
            else
            {
                m_us.SetNGAY_HET_HIEU_LUCNull();
            }
            m_us.datNGAY_KY = m_dat_ngay_ky.Value.Date;
            m_us.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh.SelectedValue.ToString());
            m_us.strLINK = m_lbl_file_name.Text;

        }

        private void form_to_us_quyet_dinh_phap_nhan()
        {
            m_us_quyet_dinh_phap_nhan.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
            m_us_quyet_dinh_phap_nhan.dcID_QUYET_DINH = m_us.dcID;
        }
       
        private void save_data()
        {
            if (check_data_is_ok() == false)
                return;

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

            // Xử lý quyết định
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.UpdateDataState:
                    if (check_data_is_ok() == false)
                        return;
                    else
                    {
                        form_2_us_object();
                        m_us.Update();
                    }
                    break;
                case DataEntryFormMode.InsertDataState:
                    if (check_trung_ma_quyet_dinh(m_txt_ma_quyet_dinh.Text))
                    {
                        BaseMessages.MsgBox_Warning(216);
                        m_txt_ma_quyet_dinh.BackColor = Color.Bisque;
                        m_txt_ma_quyet_dinh.Focus();
                        m_txt_ma_quyet_dinh.SelectAll();
                        return;
                    }
                    else
                    {
                        m_txt_ma_quyet_dinh.BackColor = Color.White;
                        if (check_data_is_ok() == false)
                            return;
                        else
                        {
                            form_2_us_object();
                            m_us.Insert();
                        }
                    }
                    break;
                default: break;
            }

            // Xử lý quyết định theo pháp nhân
            if (m_e_form_mode == DataEntryFormMode.InsertDataState)
            {
                form_to_us_quyet_dinh_phap_nhan();
                m_us_quyet_dinh_phap_nhan.Insert();
            }
            BaseMessages.MsgBox_Infor("Cập nhật dữ liệu thành công!");
            this.Close();
        }

        private void format_control()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            set_define_events();
        }

        #endregion

        #region Events
        protected void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            //m_txt_link.Text = "";
            m_txt_ma_quyet_dinh.Text = "";
            m_txt_noi_dung.Text = "";
            m_dat_ngay_co_hieu_luc.Value = DateTime.Today;
            m_dat_ngay_het_hieu_luc.Value = DateTime.Today;
            m_dat_ngay_ky.Value = DateTime.Today;
            m_cbo_loai_quyet_dinh.SelectedIndex = 0;
        }
        private void set_define_events()
        {
            this.m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            this.m_cmd_refresh.Click += new EventHandler(m_cmd_refresh_Click);
            this.m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
        }





        protected void m_cmd_save_Click(object sender, EventArgs e)
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
        protected void m_cmd_exit_Click(object sender, EventArgs e)
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



        internal void display(US_V_DM_QUYET_DINH m_us)
        {
            throw new NotImplementedException();
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
        private void m_cmd_xem_Click(object sender, EventArgs e)
        {
            try
            {
                view_hop_dong_saved();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }



        private void m_cmd_go_dinh_kem_Click(object sender, EventArgs e)
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
    }
}

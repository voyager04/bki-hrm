using System;
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
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPData;
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
        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            
            this.ShowDialog();
        }
        public void display_for_update(US_V_DM_QUYET_DINH ip_m_us_v_dm_quyet_dinh)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            
            us_object_2_form(ip_m_us_v_dm_quyet_dinh);
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
        private string m_str_destination = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private string m_str_path = "";
        private string m_str_file_name = "";
        private string m_str_origination = "";
        private string m_str_old_path = "";
        #endregion
        #region Private Methods
        private bool check_trung_ma_quyet_dinh(string ip_str_ma_quyet_dinh)
        {
            DS_V_DM_QUYET_DINH v_ds = new DS_V_DM_QUYET_DINH();
            decimal count_ma_nv;
            m_v_us.FillDataset_By_Ma_qd(v_ds, ip_str_ma_quyet_dinh);
            count_ma_nv = v_ds.V_DM_QUYET_DINH.Count;
            if (count_ma_nv > 0)
                return true;
            return false;
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





            //if (ip_us_v_dm_quyet_dinh.datNGAY_HET_HIEU_LUC.Equals(DateTime.Parse("1/1/1900 12:00:00 AM")))
            //{
            //    m_dat_ngay_het_hieu_luc.Checked = false;
            //}
            //else
            //{
            //    m_dat_ngay_het_hieu_luc.Value = ip_us_v_dm_quyet_dinh.datNGAY_HET_HIEU_LUC;
            //    m_dat_ngay_het_hieu_luc.Checked = true;
            //}

            if (ip_us_v_dm_quyet_dinh.strLINK == "") return;
            string[] v_strs = ip_us_v_dm_quyet_dinh.strLINK.Split('\\');
            //m_lbl_ten_file.Text = v_strs[v_strs.Length - 1];
        }
        private void chon_file()
        {
            //m_str_old_path = m_str_destination + m_lbl_ten_file.Text;
            int v_i_file_size = 5096000;
            m_ofd_chon_file.Filter = "(*.*)|*.*";
            m_ofd_chon_file.Multiselect = false;
            m_ofd_chon_file.Title = "Chọn file";
            m_ofd_chon_file.FileName = "";
            DialogResult result = m_ofd_chon_file.ShowDialog();
            if (result != DialogResult.OK) return;

            if (new FileInfo(m_ofd_chon_file.FileName).Length > v_i_file_size)
            {
                BaseMessages.MsgBox_Infor("File đính kèm có dung lượng quá lớn. \nVui lòng chọn file có dung lượng nhỏ hơn 5Mb");
                return;
            }
            // m_lbl_ten_file.Text = m_ofd_chon_file.SafeFileName;
            m_str_file_name = m_ofd_chon_file.SafeFileName;
            m_str_origination = m_ofd_chon_file.FileName;
        }

        
        private bool check_data_is_ok()
        {

            if (!CValidateTextBox.IsValid(m_txt_ma_quyet_dinh, DataType.StringType, allowNull.NO, true))
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập mã quyết định");
                return false;
            }
            //if (m_txt_ma_quyet_dinh.Text == "")
            //{
            //    BaseMessages.MsgBox_Infor("Bạn chưa nhập mã quyết định");
            //    return false;
            //}


            return true;
        }
        private void form_2_us_object()
        {
            m_us.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text.Trim();
            //m_us.strLINK = m_txt_link.Text.Trim();
            m_us.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            if (m_dat_ngay_co_hieu_luc.Checked)
            {
                m_us.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value.Date;
            }
            else
            {
                m_us.SetNGAY_CO_HIEU_LUCNull();
            }
            if (m_dat_ngay_het_hieu_luc.Checked)
            {
                m_us.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc.Value.Date;
            }
            else
            {
                m_us.SetNGAY_HET_HIEU_LUCNull();
            }
            if (m_dat_ngay_ky.Checked)
            {
                m_us.datNGAY_KY = m_dat_ngay_ky.Value.Date;
            }
            else
            {
                m_us.SetNGAY_KYNull();
            }

            //m_us.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value;
            //m_us.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc.Value;
            //m_us.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh.SelectedValue.ToString());

            //if (m_dat_ngay_het_hieu_luc.Checked == false)
            //    m_us.SetNGAY_HET_HIEU_LUCNull();
            //else
            //    m_us.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc.Value;

        }
        private void save_data()
        {
           
            upload_file();
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
                        BaseMessages.MsgBox_Warning(213);
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
                default:
                    break;
            }
            BaseMessages.MsgBox_Infor("Cập nhật dữ liệu thành công!");
            this.Close();
        }
        private void upload_file()
        {
            if (m_str_file_name == "")
                return;
            string v_str_path_destination = m_str_destination + m_str_file_name;
            m_str_path = m_str_destination + "TOPICA" + "-" + m_str_file_name;
            File.Copy(m_str_origination, v_str_path_destination);
            File.Move(m_str_destination + m_str_file_name, m_str_path);
            if (File.Exists(m_str_old_path))
                File.Delete(m_str_old_path);
            m_us.strLINK = m_str_path;
        }
        private void format_control()
        {
            CControlFormat.setFormStyle(this);
            set_define_events();
        }

        //TODO: Xuất Excel
        //TODO: Gen mã quyết đinh tự động
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
                if (check_data_is_ok() == false) return;
                chon_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }




        #endregion




    }
}

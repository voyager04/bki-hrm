using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BKI_HRM.DanhMuc
{
    public partial class F600_V_DM_QUYET_DINH_DE : Form
    {
        #region Public Interfaces
        public F600_V_DM_QUYET_DINH_DE()
        {
            InitializeComponent();
            format_control();
        }
        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            /*Load Combobox Loai quyet dinh*/
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH,
                WinFormControls.eTAT_CA.NO,
                m_cbo_loai_quyet_dinh);
            this.ShowDialog();
        }
        public void display_for_update(US_V_DM_QUYET_DINH ip_m_us_v_dm_quyet_dinh)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            /*Load Combobox Loai quyet dinh*/
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH,
                WinFormControls.eTAT_CA.NO,
                m_cbo_loai_quyet_dinh);
            m_cbo_loai_quyet_dinh.SelectedIndex = (int)m_us.dcID_LOAI_QD;
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
        #endregion
        #region Private Methods
        #endregion

        private void us_object_2_form(US_V_DM_QUYET_DINH ip_us_v_dm_quyet_dinh)
        {
            m_us.dcID = ip_us_v_dm_quyet_dinh.dcID;
            m_txt_link.Text = ip_us_v_dm_quyet_dinh.strLINK;
            m_txt_ma_quyet_dinh.Text = ip_us_v_dm_quyet_dinh.strMA_QUYET_DINH;
            m_txt_noi_dung.Text = ip_us_v_dm_quyet_dinh.strNOI_DUNG;
            if (ip_us_v_dm_quyet_dinh.datNGAY_CO_HIEU_LUC == null)
                m_dat_ngay_co_hieu_luc.Checked = false;
            else
                m_dat_ngay_co_hieu_luc.Value = ip_us_v_dm_quyet_dinh.datNGAY_CO_HIEU_LUC;
            if (ip_us_v_dm_quyet_dinh.datNGAY_KY == null)
                m_dat_ngay_ky.Checked = false;
            else
            m_dat_ngay_ky.Value = ip_us_v_dm_quyet_dinh.datNGAY_KY;
            if (ip_us_v_dm_quyet_dinh.datNGAY_HET_HIEU_LUC == null)
                m_dat_ngay_het_hieu_luc.Checked = false;
            else
            m_dat_ngay_het_hieu_luc.Value = ip_us_v_dm_quyet_dinh.datNGAY_HET_HIEU_LUC;
            m_cbo_loai_quyet_dinh.SelectedIndex =
                (int)CIPConvert.ToDecimal(m_us.dcID_LOAI_QD);
        }
        private void format_control()
        {
            CControlFormat.setFormStyle(this);
            set_define_events();
           
        
        }
        private bool check_data_is_ok()
        {
            if (!CValidateTextBox.IsValid(m_txt_ma_quyet_dinh, DataType.StringType, allowNull.NO, true))
            {
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_noi_dung, DataType.StringType, allowNull.NO, true))
            {
                return false;
            }
            return true;
        }
        private void form_2_us_object()
        {
            m_us.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text.Trim();
            m_us.strLINK = m_txt_link.Text.Trim();
            m_us.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value;
            m_us.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc.Value;
            m_us.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us.dcID_LOAI_QD = (m_cbo_loai_quyet_dinh.SelectedIndex);
			
        }
        private void save_data()
        {
            if (check_data_is_ok() == false)
            {
                return;
            }
            form_2_us_object();
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    m_us.Insert();
                    break;
                case DataEntryFormMode.UpdateDataState:
                    m_us.Update();
                    break;
            }
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            this.Close();
        }
        private void fomat_control()
        {
            CControlFormat.setFormStyle(this);
            set_define_events();
        }
        #region Events
        protected void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            m_txt_link.Text = "";
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
        #endregion


    }
}

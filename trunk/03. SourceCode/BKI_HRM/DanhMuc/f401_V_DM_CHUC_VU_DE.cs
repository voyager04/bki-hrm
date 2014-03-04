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
using Encoder = System.Drawing.Imaging.Encoder;

namespace BKI_HRM
{
    public partial class f401_V_DM_CHUC_VU_DE : Form
    {
        #region Public Interfaces
        public f401_V_DM_CHUC_VU_DE() {
            InitializeComponent();
            fomat_control();
        }
        public void display_for_insert() {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.ShowDialog();
        }
        public void display_for_update(US_DM_CHUC_VU ip_m_us_v_dm_chuc_vu) {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form(ip_m_us_v_dm_chuc_vu);
            this.ShowDialog();
        }
        #endregion

        #region Data Structures
        #endregion

        #region Members
        private DataEntryFormMode m_e_form_mode;
        private US_V_DM_CHUC_VU m_v_us = new US_V_DM_CHUC_VU();
        private DS_V_DM_CHUC_VU m_v_ds = new DS_V_DM_CHUC_VU();
        private US_DM_CHUC_VU m_us = new US_DM_CHUC_VU();
        private DS_DM_CHUC_VU m_ds = new DS_DM_CHUC_VU();
        #endregion

        #region Private Methods

        private void fomat_control() {
            CControlFormat.setFormStyle(this);
            set_define_events();
        }

        private bool check_data_is_ok() {
            if (!CValidateTextBox.IsValid(m_txt_macv, DataType.StringType, allowNull.YES, true)) {
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_tencv, DataType.StringType, allowNull.NO, true)) {
                return false;
            }
            return true;
        }

        private void form_2_us_object() {
            m_us.strMA_CV = m_txt_macv.Text.Trim();
            m_us.strTEN_CV = m_txt_tencv.Text.Trim();
            m_us.strTEN_CV_TA = m_txt_tenta.Text.Trim();
            m_us.datNGAY_AP_DUNG = m_dat_ngayapdung.Value.Date;
            m_us.datNGAY_KET_THUC = m_dat_ngayketthuc.Value.Date;
            m_us.strTRANG_THAI = m_rdb_khongsudung.Checked ? "n" : "y";
        }

        private void save_data() {
            if (check_data_is_ok() == false) {
                return;
            }
            form_2_us_object();
            switch (m_e_form_mode) {
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

        private void us_object_2_form(US_DM_CHUC_VU ip_us_v_dm_chuc_vu){
            m_us.dcID = ip_us_v_dm_chuc_vu.dcID;
            m_txt_macv.Text = ip_us_v_dm_chuc_vu.strMA_CV;
            m_txt_tencv.Text = ip_us_v_dm_chuc_vu.strTEN_CV;
            m_txt_tenta.Text = ip_us_v_dm_chuc_vu.strTEN_CV_TA;
            m_dat_ngayapdung.Value = ip_us_v_dm_chuc_vu.datNGAY_AP_DUNG;
            m_dat_ngayketthuc.Value = ip_us_v_dm_chuc_vu.datNGAY_KET_THUC;
            if (ip_us_v_dm_chuc_vu.strTRANG_THAI == "y")
                m_rdb_sudung.Checked = true;
            else
                m_rdb_khongsudung.Checked = true;
        }

        #endregion

        #region Events

        private void set_define_events() {
            this.m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            this.m_cmd_refresh.Click += new EventHandler(m_cmd_refresh_Click);
            this.m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
        }

        protected void m_cmd_save_Click(object sender, EventArgs e) {
            try {
                save_data();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        protected void m_cmd_refresh_Click(object sender, EventArgs e) {

        }

        protected void m_cmd_exit_Click(object sender, EventArgs e) {
            try{
                this.Close();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        
        #endregion

    }
}

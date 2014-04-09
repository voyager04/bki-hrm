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
            m_us_1 = ip_m_us_v_dm_chuc_vu;
            this.ShowDialog();
        }
        #endregion

        #region Data Structures
        #endregion

        #region Members
        private DataEntryFormMode m_e_form_mode;
        private US_DM_CHUC_VU m_us_1 = new US_DM_CHUC_VU();
        private US_V_DM_CHUC_VU m_v_us = new US_V_DM_CHUC_VU();
        private DS_V_DM_CHUC_VU m_v_ds = new DS_V_DM_CHUC_VU();
        private US_DM_CHUC_VU m_us = new US_DM_CHUC_VU();
        private DS_DM_CHUC_VU m_ds = new DS_DM_CHUC_VU();
        #endregion

        #region Private Methods

        private void fomat_control() {
            CControlFormat.setFormStyle(this);
            set_define_events();
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.NGACH,
                WinFormControls.eTAT_CA.NO,
                m_cbo_ngach);
        }

        private bool check_data_is_ok() {
            if (!CValidateTextBox.IsValid(m_txt_macv, DataType.StringType, allowNull.YES, true)) {
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_tencv, DataType.StringType, allowNull.NO, true)) {
                return false;
            }
            if (m_dat_ngayketthuc.Checked && m_dat_ngayapdung.Checked)
                if (m_dat_ngayapdung.Value > m_dat_ngayketthuc.Value)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn ngày áp dụng");
                    return false;
                }
            return true;
        }

        private void form_2_us_object() {
            m_us.strMA_CV = m_txt_macv.Text.Trim();
            m_us.strTEN_CV = m_txt_tencv.Text.Trim();
            m_us.strTEN_CV_TA = m_txt_tenta.Text.Trim();
            m_us.datNGAY_AP_DUNG = m_dat_ngayapdung.Value.Date;
            if (m_dat_ngayapdung.Checked)
            {
                m_us.datNGAY_AP_DUNG = m_dat_ngayapdung.Value;
            }
            else
            {
                m_us.SetNGAY_AP_DUNGNull();
            }
            m_us.datNGAY_KET_THUC = m_dat_ngayketthuc.Value.Date;
            if (m_dat_ngayketthuc.Checked)
            {
                m_us.datNGAY_KET_THUC = m_dat_ngayketthuc.Value;
            }
            else
            {
                m_us.SetNGAY_KET_THUCNull();
            }
            m_us.dcID_NGACH =  CIPConvert.ToDecimal(m_cbo_ngach.SelectedValue);
            m_us.strTRANG_THAI = m_rdb_khongsudung.Checked ? "N" : "Y";
        }
        private void refresh_control() {
            if (m_e_form_mode == DataEntryFormMode.InsertDataState)
            {
                m_txt_macv.Text = "";
                m_txt_tencv.Text = "";
                m_txt_tenta.Text = "";
                m_dat_ngayapdung.Value = DateTime.Now;
                m_dat_ngayketthuc.Value = DateTime.Now;
                m_rdb_sudung.Checked = true;
                m_cbo_ngach.SelectedIndex = 0;
            }
            else
                us_object_2_form(m_us_1);
        }
        public void get_us(ref US_DM_CHUC_VU op_us)
        {
            op_us = m_us;
        }
        private void save_data() {
            if (check_data_is_ok() == false) {
                return;
            }
            form_2_us_object();
            switch (m_e_form_mode) {
                case DataEntryFormMode.InsertDataState:
                    if (check_trung_ma_cv(m_txt_macv.Text.Trim()))
                    {
                        BaseMessages.MsgBox_Infor("Mã chức vụ đã bị trùng");
                        m_txt_macv.BackColor = Color.Bisque;
                        m_txt_macv.Focus();
                        m_txt_macv.SelectAll();
                        return;
                    }
                    else
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
            if (ip_us_v_dm_chuc_vu.datNGAY_AP_DUNG == DateTime.Parse("1/1/1900"))
                m_dat_ngayapdung.Value = DateTime.Now;
            else
                m_dat_ngayapdung.Value = ip_us_v_dm_chuc_vu.datNGAY_AP_DUNG;
            if (ip_us_v_dm_chuc_vu.datNGAY_KET_THUC == DateTime.Parse("1/1/1900"))
                m_dat_ngayketthuc.Value = DateTime.Now;
            else
                m_dat_ngayketthuc.Value = ip_us_v_dm_chuc_vu.datNGAY_KET_THUC;
            m_cbo_ngach.SelectedValue = ip_us_v_dm_chuc_vu.dcID_NGACH;
            if (ip_us_v_dm_chuc_vu.strTRANG_THAI == "Y")
                m_rdb_sudung.Checked = true;
            else
                m_rdb_khongsudung.Checked = true;
        }
        private bool check_trung_ma_cv(string ip_str_ma_cv)
        {

            DS_DM_CHUC_VU v_ds = new DS_DM_CHUC_VU();
            decimal count_ma_cv;
            m_us.FillDataset(v_ds, ip_str_ma_cv);
            count_ma_cv = v_ds.DM_CHUC_VU.Count;
            if (count_ma_cv > 0)
                return false;
            return true;
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
            try
            {
                refresh_control();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
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

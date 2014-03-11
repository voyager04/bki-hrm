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
using IP.Core.IPSystemAdmin;
using IP.Core.IPUserService;
using Encoder = System.Drawing.Imaging.Encoder;

namespace BKI_HRM.DanhMuc {
    public partial class f106_v_gd_chi_tiet_cap_bac_DE : Form {

        #region Public Interfaces
        public f106_v_gd_chi_tiet_cap_bac_DE() {
            InitializeComponent();
            fomat_control();
        }
        public void display_for_insert() {
            set_initial_form_load();
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.ShowDialog();
        }
        public void display_for_update(US_V_GD_CHI_TIET_CAP_BAC ip_v_us_gd_chi_tiet_cap_bac) {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form(ip_v_us_gd_chi_tiet_cap_bac);
            this.ShowDialog();
        }
        #endregion

        #region Data Structures
        #endregion

        #region Members
        private DataEntryFormMode m_e_form_mode;
        private US_DM_DON_VI m_us = new US_DM_DON_VI();
        private DS_DM_DON_VI m_ds = new DS_DM_DON_VI();
        private DS_V_DM_DON_VI m_v_ds = new DS_V_DM_DON_VI();
        #endregion

        #region Private Methods

        private void fomat_control() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            set_define_events();
        }
        private void set_initial_form_load() {
        }
        private bool check_data_is_ok() {
            if (!CValidateTextBox.IsValid(m_txt_dia_ban, DataType.StringType, allowNull.YES, true)) {
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_ma_don_vi, DataType.StringType, allowNull.NO, true)) {
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_ten_don_vi, DataType.StringType, allowNull.NO, true)) {
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_ten_tieng_anh, DataType.StringType, allowNull.YES, true)) {
                return false;
            }
            return true;
        }
        private void form_2_us_object() {
            m_us.dcID_DON_VI_CAP_TREN = CIPConvert.ToDecimal(m_cbo_ten_don_vi_cap_tren.SelectedValue);
            m_us.dcID_LOAI_DON_VI = CIPConvert.ToDecimal(m_cbo_loai_don_vi.SelectedValue);
            m_us.dcID_CAP_DON_VI = CIPConvert.ToDecimal(m_cbo_cap_don_vi.SelectedValue);
            m_us.strMA_DON_VI = m_txt_ma_don_vi.Text.Trim();
            m_us.strTEN_DON_VI = m_txt_ten_don_vi.Text.Trim();
            m_us.strTEN_TA = m_txt_ten_tieng_anh.Text.Trim();
            m_us.strDIA_BAN = m_txt_dia_ban.Text.Trim();
            m_us.strTRANG_THAI = get_trang_thai(m_cbo_trang_thai);
            m_us.dcID_LOAI_DON_VI = CIPConvert.ToDecimal(m_cbo_loai_don_vi.SelectedValue);
            m_us.dcID_CAP_DON_VI = CIPConvert.ToDecimal(m_cbo_cap_don_vi.SelectedValue);
            m_us.datTU_NGAY = m_dat_tu_ngay.Value.Date;
        }
        private static string get_trang_thai(ListControl ip_cbo) {
            return ip_cbo.SelectedIndex == 0 ? "y" : "n";
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
            Close();
        }
        private void us_object_2_form(US_V_GD_CHI_TIET_CAP_BAC ip_us_gd_chi_tiet_cap_bac) {
            //m_us.dcID = ip_us_gd_chi_tiet_cap_bac.;
            //m_cbo_cap_don_vi.SelectedValue = ip_us_dm_don_vi.dcID_CAP_DON_VI;
            //m_cbo_loai_don_vi.SelectedValue = ip_us_dm_don_vi.dcID_LOAI_DON_VI;
            //if (ip_us_dm_don_vi.dcID_DON_VI_CAP_TREN == 0) {
            //    m_cbo_ten_don_vi_cap_tren.SelectedIndex = 0;
            //} else {
            //    m_cbo_ten_don_vi_cap_tren.SelectedValue = ip_us_dm_don_vi.dcID_DON_VI_CAP_TREN;
            //}
            //m_txt_ma_don_vi.Text = ip_us_dm_don_vi.strMA_DON_VI;
            //m_txt_ten_don_vi.Text = ip_us_dm_don_vi.strTEN_DON_VI;
            //m_txt_ten_tieng_anh.Text = ip_us_dm_don_vi.strTEN_TIENG_ANH;
            //m_txt_dia_ban.Text = ip_us_dm_don_vi.strDIA_BAN;
            //m_cbo_trang_thai.SelectedIndex = ip_us_dm_don_vi.strTRANG_THAI.ToUpper().Equals("Y") ? 0 : 1;
            //m_dat_tu_ngay.Value = ip_us_dm_don_vi.datTU_NGAY.Date;
        }

        #endregion

        #region Events

        private void set_define_events() {
            m_cmd_save.Click += m_cmd_save_Click;
            m_cmd_exit.Click += m_cmd_exit_Click;
            m_cbo_ten_don_vi_cap_tren.SelectedIndexChanged +=
                m_cbo_ten_don_vi_cap_tren_SelectedIndexChanged;
            m_cbo_cap_don_vi.SelectedIndexChanged +=
                m_cbo_cap_don_vi_SelectedIndexChanged;
        }

        protected void m_cmd_save_Click(object sender, EventArgs e) {
            try {
                save_data();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        protected void m_cbo_ma_don_vi_cap_tren_SelectedIndexChanged(object sender, EventArgs e) {
        }

        protected void m_cbo_ten_don_vi_cap_tren_SelectedIndexChanged(object sender, EventArgs e) {
        }

        protected void m_cmd_refresh_Click(object sender, EventArgs e) {

        }

        protected void m_cmd_exit_Click(object sender, EventArgs e) {
            try {
                Close();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void f102_v_dm_don_vi_de_Load(object sender, EventArgs e) {
            try {
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_cap_don_vi_SelectedIndexChanged(object sender, EventArgs e) {
            try {
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        #endregion

    }
}

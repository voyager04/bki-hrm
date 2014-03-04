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

namespace BKI_HRM.DanhMuc {
    public partial class f102_v_dm_don_vi_de : Form {

        #region Public Interfaces
        public f102_v_dm_don_vi_de() {
            InitializeComponent();
            fomat_control();
        }
        public void display_for_insert() {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.ShowDialog();
        }
        public void display_for_update(US_V_DM_DON_VI ip_v_us_dm_don_vi) {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form(ip_v_us_dm_don_vi);
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
            CControlFormat.setFormStyle(this);
            set_define_events();
            /*Load Combobox Loai don vi*/
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_DON_VI,
                WinFormControls.eTAT_CA.NO,
                m_cbo_loai_don_vi);
            /*Load Combobox Cap don vi*/
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.CAP_DON_VI,
                WinFormControls.eTAT_CA.NO,
                m_cbo_cap_don_vi);
            load_data_2_cbo_don_vi();
        }

        private void set_initial_form_load(){
            m_cbo_trang_thai.SelectedIndex = 0;
        }
        private void load_data_2_cbo_don_vi() {
            var v_ds = new DS_DM_DON_VI();
            var v_us = new US_DM_DON_VI();
            v_us.FillDataset(v_ds);

            m_cbo_ten_don_vi_cap_tren.DisplayMember = DM_DON_VI.TEN_DON_VI;
            m_cbo_ten_don_vi_cap_tren.ValueMember = DM_DON_VI.ID;
            m_cbo_ten_don_vi_cap_tren.DataSource = v_ds.DM_DON_VI;

            DataRow v_row = v_ds.DM_DON_VI.NewRow();
            v_row[DM_DON_VI.ID] = -1;
            v_row[DM_DON_VI.ID_CAP_DON_VI] = 0;
            v_row[DM_DON_VI.ID_DON_VI_CAP_TREN] = -1;
            v_row[DM_DON_VI.ID_LOAI_DON_VI] = -1;
            v_row[DM_DON_VI.MA_DON_VI] = "NULL";
            v_row[DM_DON_VI.TEN_DON_VI] = "Không có đơn vị cấp trên";
            v_row[DM_DON_VI.TEN_TA] = "NULL";
            v_row[DM_DON_VI.TRANG_THAI] = "Y";
            v_row[DM_DON_VI.TU_NGAY] = "1/1/1800";
            v_row[DM_DON_VI.DIA_BAN] = "NULL";

            v_ds.DM_DON_VI.Rows.InsertAt(v_row, 0);
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
            m_us.strMA_DON_VI = m_txt_ma_don_vi.Text.Trim();
            m_us.strTEN_DON_VI = m_txt_ten_don_vi.Text.Trim();
            m_us.strTEN_TA = m_txt_ten_tieng_anh.Text.Trim();
            m_us.strDIA_BAN = m_txt_dia_ban.Text.Trim();
            m_us.strTRANG_THAI = get_trang_thai(m_cbo_trang_thai);
            m_us.dcID_LOAI_DON_VI = CIPConvert.ToDecimal(m_cbo_loai_don_vi.SelectedValue);
            m_us.dcID_CAP_DON_VI = CIPConvert.ToDecimal(m_cbo_cap_don_vi.SelectedValue);
            m_us.datTU_NGAY = m_dat_tu_ngay.Value.Date;
        }
        private string get_trang_thai(ComboBox ip_cbo) {
            if (ip_cbo.SelectedIndex == 0) {
                return "y";
            }
            return "n";
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
        private void us_object_2_form(US_V_DM_DON_VI ip_us_dm_don_vi) {
            m_us.dcID = ip_us_dm_don_vi.dcID;
            m_cbo_cap_don_vi.SelectedValue = ip_us_dm_don_vi.dcID_CAP_DON_VI;
            m_cbo_loai_don_vi.SelectedValue = ip_us_dm_don_vi.dcID_LOAI_DON_VI;
            m_txt_ma_don_vi.Text = ip_us_dm_don_vi.strMA_DON_VI;
            m_txt_ten_don_vi.Text = ip_us_dm_don_vi.strTEN_DON_VI;
            m_txt_ten_tieng_anh.Text = ip_us_dm_don_vi.strTEN_TIENG_ANH;
            m_txt_dia_ban.Text = ip_us_dm_don_vi.strDIA_BAN;
            m_cbo_trang_thai.SelectedIndex = ip_us_dm_don_vi.strTRANG_THAI.ToUpper().Equals("Y") ? 0 : 1;
            m_dat_tu_ngay.Value = ip_us_dm_don_vi.datTU_NGAY.Date;
        }

        #endregion

        #region Events

        private void set_define_events() {
            this.m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            this.m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            this.m_cbo_ten_don_vi_cap_tren.SelectedIndexChanged +=
                new EventHandler(m_cbo_ten_don_vi_cap_tren_SelectedIndexChanged);
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
                this.Close();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        

        private void f102_v_dm_don_vi_de_Load(object sender, EventArgs e) {
            try{
                set_initial_form_load();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        
        #endregion
    }
}

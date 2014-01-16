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

namespace BKI_HRM.DanhMuc {
    public partial class f102_DM_DON_VI_DE : Form {

        #region Public Interfaces
        public f102_DM_DON_VI_DE() {
            InitializeComponent();
            fomat_control();
        }


        public void display_for_insert() {
            //m_e_form_mode = DataEntryFormMode.InsertDataState;
            //load_data_2_combobox();
            this.ShowDialog();
        }

        //public void display_for_update(US_VIEW_KET_QUA_HOC_TAP ip_us_view_ket_qua_hoc_tap) {
        //    //m_us_v_ket_qua_hoc_tap = ip_us_view_ket_qua_hoc_tap;
        //    //load_data_2_combobox();
        //    //m_e_form_mode = DataEntryFormMode.UpdateDataState;
        //    this.ShowDialog();
        //}
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
            load_data_2_combobox_ma_don_vi_cap_tren();
            load_data_2_combobox_loai_don_vi();
            load_data_2_combobox_ten_don_vi_cap_tren();
        }
        private void load_data_2_combobox_loai_don_vi() {
            DS_V_DM_DON_VI v_ds_v = new DS_V_DM_DON_VI();
            US_V_DM_DON_VI v_us_v = new US_V_DM_DON_VI();
            v_us_v.FillDataset(v_ds_v);
            //m_cbo_loai_don_vi.ValueMember = V_DM_DON_VI.ID_LOAI_DON_VI;
            //m_cbo_loai_don_vi.DisplayMember = V_DM_DON_VI.TEN_LOAI_DON_VI;
            m_cbo_loai_don_vi.DataSource = v_ds_v.V_DM_DON_VI;
            if (v_ds_v.V_DM_DON_VI.Rows.Count > 0) {
                m_cbo_loai_don_vi.SelectedIndex = 0;
            }
        }
        private void load_data_2_combobox_ma_don_vi_cap_tren() {

        }

        private void load_data_2_combobox_ten_don_vi_cap_tren() {

        }



        private bool check_data_is_ok() {
            return false;
        }

        private void form_2_us_object() {
            m_us.strMA_DON_VI = m_txt_ma_don_vi.Text.Trim();
            m_us.strTEN_DON_VI = m_txt_ten_don_vi.Text.Trim();
            m_us.strDIA_BAN = m_txt_dia_chi.Text.Trim();
            m_us.strTRANG_THAI = CIPConvert.ToYNString(m_ckb_trang_thai.Checked);
            m_us.dcID_LOAI_DON_VI = CIPConvert.ToDecimal(m_cbo_loai_don_vi.SelectedValue);
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

        #endregion

        #region Events

        private void set_define_events() {
            this.m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
        }

        protected void m_cmd_save_Click(object sender, EventArgs e) {
            try {
                save_data();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        #endregion

    }
}

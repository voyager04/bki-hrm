using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private US_V_GD_CHI_TIET_CAP_BAC m_us = new US_V_GD_CHI_TIET_CAP_BAC();
        private DS_V_GD_CHI_TIET_CAP_BAC m_ds = new DS_V_GD_CHI_TIET_CAP_BAC();
        private DS_V_DM_DON_VI m_v_ds = new DS_V_DM_DON_VI();
        #endregion

        #region Private Methods

        private void fomat_control() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            set_define_events();
        }
        private void set_initial_form_load() {
            load_data_2_cbo_ma_cap_bac();
        }

        private void load_data_2_cbo_ma_cap_bac(){
            var v_ds = new DS_DM_CAP_BAC();
            var v_us = new US_DM_CAP_BAC();
        }
        private bool check_data_is_ok() {
            //if (!CValidateTextBox.IsValid(m_txt_dia_ban, DataType.StringType, allowNull.YES, true)) {
            //    return false;
            //}
            return true;
        }
        private void form_2_us_object() {
            //m_us.dcID_DON_VI_CAP_TREN = CIPConvert.ToDecimal(m_cbo_ten_don_vi_cap_tren.SelectedValue);
            //m_us.dcID_LOAI_DON_VI = CIPConvert.ToDecimal(m_cbo_loai_don_vi.SelectedValue);
            //m_us.dcID_CAP_DON_VI = CIPConvert.ToDecimal(m_cbo_cap_don_vi.SelectedValue);
            //m_us.strMA_DON_VI = m_txt_ma_don_vi.Text.Trim();
            //m_us.strTEN_DON_VI = m_txt_ten_don_vi.Text.Trim();
            //m_us.strTEN_TA = m_txt_ten_tieng_anh.Text.Trim();
            //m_us.strDIA_BAN = m_txt_dia_ban.Text.Trim();
            //m_us.strTRANG_THAI = get_trang_thai(m_cbo_trang_thai);
            //m_us.dcID_LOAI_DON_VI = CIPConvert.ToDecimal(m_cbo_loai_don_vi.SelectedValue);
            //m_us.dcID_CAP_DON_VI = CIPConvert.ToDecimal(m_cbo_cap_don_vi.SelectedValue);
            //m_us.datTU_NGAY = m_dat_tu_ngay.Value.Date;
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
            m_us.dcID = ip_us_gd_chi_tiet_cap_bac.dcID;
            m_lbl_ma_nhan_vien.Text = ip_us_gd_chi_tiet_cap_bac.strMA_NV;
            m_lbl_ho_ten_nhan_vien.Text = ip_us_gd_chi_tiet_cap_bac.strHO_DEM.Trim() + @" " +
                                          ip_us_gd_chi_tiet_cap_bac.strTEN.Trim();
        }

        private void choose_file(){
            m_ofd_openfile.Filter = "(*.pdf)|*.pdf|(*.doc)|*.doc|(*.docx)|*.docx|(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            m_ofd_openfile.Multiselect = false;
            m_ofd_openfile.Title = "Chọn tài liệu đính kèm";
            DialogResult result = m_ofd_openfile.ShowDialog();
        }

        private void open_file(){
            Process.Start("explorer.exe", m_ofd_openfile.FileName);
        }

        #endregion

        //
        //
        //		EVENT HANLDERS
        //
        //

        private void set_define_events() {
            m_cmd_save.Click += m_cmd_save_Click;
            m_cmd_exit.Click += m_cmd_exit_Click;
            this.m_cmd_chon_file.Click += new System.EventHandler(this.m_cmd_chon_file_Click);

        }

        protected void m_cmd_save_Click(object sender, EventArgs e) {
            try {
                save_data();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
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

        private void m_cmd_chon_file_Click(object sender, EventArgs e) {
            try {
                choose_file();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_xem_file_Click(object sender, EventArgs e) {
            try {
                open_file();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

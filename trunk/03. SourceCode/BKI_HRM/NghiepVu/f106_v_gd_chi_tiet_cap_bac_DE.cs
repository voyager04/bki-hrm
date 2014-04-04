using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPSystemAdmin;

namespace BKI_HRM.DanhMuc {
    public partial class f106_v_gd_chi_tiet_cap_bac_DE : Form {

        #region Public Interfaces
        public f106_v_gd_chi_tiet_cap_bac_DE() {
            InitializeComponent();
            fomat_control();
        }
        public void display_for_insert(US_V_GD_CHI_TIET_CAP_BAC ip_us_gs_chi_tiet_cap_bac, DS_V_GD_CHI_TIET_CAP_BAC ip_ds_gs_chi_tiet_cap_bac)
        {
            set_initial_form_load();
            m_v_us_chi_tiet_cap_bac = ip_us_gs_chi_tiet_cap_bac;
            m_ds_gd_chi_tiet_cap_bac = ip_ds_gs_chi_tiet_cap_bac;
            us_object_2_form();
            ShowDialog();
        }
        #endregion

        #region Data Structures
        #endregion

        #region Members
        private US_V_GD_CHI_TIET_CAP_BAC m_v_us_chi_tiet_cap_bac = new US_V_GD_CHI_TIET_CAP_BAC();
        private US_DM_QUYET_DINH m_us_quyet_dinh = new US_DM_QUYET_DINH();
        private US_GD_CHI_TIET_CAP_BAC m_us_chi_tiet_cap_bac = new US_GD_CHI_TIET_CAP_BAC();
        private DS_V_GD_CHI_TIET_CAP_BAC m_ds_gd_chi_tiet_cap_bac = new DS_V_GD_CHI_TIET_CAP_BAC();
        #endregion

        #region Private Methods

        private void fomat_control() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            set_define_events();
        }
        private void set_initial_form_load() {
            load_data_to_cbo();
        }
        private bool check_data_is_ok() {
            return CValidateTextBox.IsValid(m_txt_ma_quyet_dinh, DataType.StringType, allowNull.YES, true) && kiem_tra_ngay_truoc_sau();
        }
        private bool kiem_tra_ngay_truoc_sau() {
            if (m_dat_ngay_co_hieu_luc_qd.Value < m_dat_ngay_ky.Value) {
                m_lbl_mesg.Text = @"Ngày có hiệu lực phải sau ngày ký!";
                return false;
            }
            return true;
        }
        private void form_2_us_object_chi_tiet_cap_bac() {
            /**
             * Lấy dữ liệu từ form vào US_GD_CHI_TIET_CAP_BAC
             */
            m_us_chi_tiet_cap_bac.dcID_NHAN_SU = m_v_us_chi_tiet_cap_bac.dcID_NHAN_SU;
            m_us_chi_tiet_cap_bac.dcID_CAP_BAC = CIPConvert.ToDecimal(m_cbo_ma_cap_bac.SelectedValue);
            m_us_chi_tiet_cap_bac.strTRANG_THAI_CB = "Y";
            m_us_chi_tiet_cap_bac.datNGAY_BAT_DAU = m_dat_ngay_bat_dau.Value.Date;
            if (m_txt_ma_quyet_dinh.Text.Trim() != "") {
                m_us_chi_tiet_cap_bac.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
            }

        }
        private void form_2_us_object_quyet_dinh() {
            /**
             * Lấy dữ liệu từ form vào US_DM_QUYET_DINH
             */
            m_us_quyet_dinh.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text;
            m_us_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text;
            m_us_quyet_dinh.strLINK = m_ofd_openfile.FileName;
            m_us_quyet_dinh.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh.SelectedValue);
            m_us_quyet_dinh.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_quyet_dinh.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd.Value;
            
        }
        private void save_data() {
            if (check_data_is_ok() == false) return;
            form_2_us_object_quyet_dinh();
            m_us_quyet_dinh.Insert();
            form_2_us_object_chi_tiet_cap_bac();
            m_us_chi_tiet_cap_bac.Insert();
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            Close();
        }
        private void us_object_2_form() {
            m_txt_ma_nv.Text = m_v_us_chi_tiet_cap_bac.strMA_NV;
            m_txt_ho_ten.Text = m_v_us_chi_tiet_cap_bac.strHO_DEM.Trim() + @" " + m_v_us_chi_tiet_cap_bac.strTEN.Trim();
            m_dat_ngay_bat_dau.Value = m_v_us_chi_tiet_cap_bac.datNGAY_BAT_DAU.Date;
            m_dat_ngay_ket_thuc.Value = m_v_us_chi_tiet_cap_bac.datNGAY_KET_THUC.Date;
            if (m_ds_gd_chi_tiet_cap_bac.V_GD_CHI_TIET_CAP_BAC.Select("MA_NV is not null").Length > 0)
            {
                m_v_us_chi_tiet_cap_bac.DataRow2Me((DataRow)m_ds_gd_chi_tiet_cap_bac.V_GD_CHI_TIET_CAP_BAC.Rows[0]);
                m_txt_cap_bac_hien_tai.Text = m_v_us_chi_tiet_cap_bac.strMA_CAP_BAC;
            }
        }
        private void load_data_to_cbo() {
            /**
             * Load data to combobox Loại quyết định
             */
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH,
              WinFormControls.eTAT_CA.NO,
              m_cbo_loai_quyet_dinh);

            var v_ds = new DS_V_DM_CAP_BAC();
            var v_us = new US_V_DM_CAP_BAC();
            v_us.FillDataset(v_ds);
            /**
             * Load data to combobox Mã cấp bậc
             */
            m_cbo_ma_cap_bac.DataSource = v_ds.V_DM_CAP_BAC;
            m_cbo_ma_cap_bac.DisplayMember = V_DM_CAP_BAC.MA_CAP_BAC;
            m_cbo_ma_cap_bac.ValueMember = V_DM_CAP_BAC.ID;
           
        }
        private void choose_file() {
            m_ofd_openfile.Filter = @"(*.pdf)|*.pdf|(*.doc)|*.doc|(*.docx)|*.docx|(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            m_ofd_openfile.Multiselect = false;
            m_ofd_openfile.Title = @"Chọn tài liệu đính kèm";
            m_ofd_openfile.ShowDialog();
        }
        private void open_file() {
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
            m_cmd_chon_file.Click += m_cmd_chon_file_Click;
            m_cmd_xem_file.Click += m_cmd_xem_file_Click;
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

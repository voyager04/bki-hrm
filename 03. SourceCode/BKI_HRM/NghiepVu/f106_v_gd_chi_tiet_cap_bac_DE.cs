using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPSystemAdmin;

namespace BKI_HRM {
    public partial class f106_v_gd_chi_tiet_cap_bac_DE : Form {

        #region Public Interfaces
        public f106_v_gd_chi_tiet_cap_bac_DE() {
            InitializeComponent();
            fomat_control();
        }
        public void display_for_insert(US_V_GD_CHI_TIET_CAP_BAC ip_us_gs_chi_tiet_cap_bac, DS_V_GD_CHI_TIET_CAP_BAC ip_ds_gs_chi_tiet_cap_bac) {
            m_e_formmode = DataEntryFormMode.InsertDataState;
            m_v_us_chi_tiet_cap_bac = ip_us_gs_chi_tiet_cap_bac;
            m_ds_gd_chi_tiet_cap_bac = ip_ds_gs_chi_tiet_cap_bac;
            us_object_2_form();
            ShowDialog();
        }
        public void display_for_update(US_V_GD_CHI_TIET_CAP_BAC ip_us_chi_tiet_cap_bac)
        {
            m_e_formmode = DataEntryFormMode.UpdateDataState;
            m_v_us_chi_tiet_cap_bac = ip_us_chi_tiet_cap_bac;
            m_us_chi_tiet_cap_bac = new US_GD_CHI_TIET_CAP_BAC(m_v_us_chi_tiet_cap_bac.dcID);
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
        private bool m_b_check_quyet_dinh_save;
        private bool m_b_check_quyet_dinh_null;
        DataEntryFormMode m_e_formmode;
        #endregion

        #region Private Methods

        private void fomat_control() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            set_define_events();
        }
        private void set_initial_form_load() {
            load_data_to_cbo();
            m_grb_quyet_dinh.Enabled = false;
        }
        private bool check_data_is_ok() {
            // Kiem tra nhap trung Ma Quyet Dinh
            if (m_b_check_quyet_dinh_save) {
                if (trung_ma_quyet_dinh(m_txt_ma_quyet_dinh.Text.Trim())) {
                    BaseMessages.MsgBox_Error("Đã có mã Quyết định này!");
                    return false;
                }
                if (m_b_check_quyet_dinh_null) {
                    BaseMessages.MsgBox_Error("Bạn chưa chọn được Quyết định!");
                    return false;
                }
            }
            return CValidateTextBox.IsValid(m_txt_ma_quyet_dinh, DataType.StringType, allowNull.YES, true) && kiem_tra_ngay_truoc_sau();
        }
        private bool trung_ma_quyet_dinh(string ip_str_ma_don_vi) {

            var v_ds = new DS_V_DM_QUYET_DINH();
            var v_us = new US_V_DM_QUYET_DINH();
            v_us.FillDataset_By_Ma_qd(v_ds, ip_str_ma_don_vi);
            decimal v_count = v_ds.V_DM_QUYET_DINH.Count;
            if (v_count > 0) {
                return true;
            }
            return false;
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
            //-- Cập nhật ngày kết thúc cho chức vụ cũ.
//             m_us_chi_tiet_cap_bac.datNGAY_KET_THUC = m_dat_ngay_bat_dau.Value.Date;
//             m_us_chi_tiet_cap_bac.Update();
            //-- Thêm 1 bản ghi mới
            switch (m_e_formmode)
            {
                case DataEntryFormMode.InsertDataState:
                    break;
                case DataEntryFormMode.UpdateDataState:
               //     m_us_chi_tiet_cap_bac.dcID = m_v_us_chi_tiet_cap_bac.dcID;
                    break;
            }
            m_us_chi_tiet_cap_bac.dcID_NHAN_SU = m_v_us_chi_tiet_cap_bac.dcID_NHAN_SU;
            m_us_chi_tiet_cap_bac.dcID_CAP_BAC = CIPConvert.ToDecimal(m_cbo_ma_cap_bac.SelectedValue);
            m_us_chi_tiet_cap_bac.strTRANG_THAI_CB = "Y";
            m_us_chi_tiet_cap_bac.datNGAY_BAT_DAU = m_dat_ngay_bat_dau.Value.Date;
            if (m_dat_ngay_ket_thuc.Checked == true)
            {
                m_us_chi_tiet_cap_bac.datNGAY_KET_THUC = m_dat_ngay_ket_thuc.Value;
            }
            else
            {
                m_us_chi_tiet_cap_bac.SetNGAY_KET_THUCNull();
            }
            if (m_txt_ma_quyet_dinh.Text.Trim() != "") {
                m_us_chi_tiet_cap_bac.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
            }
          //  m_us_chi_tiet_cap_bac.SetNGAY_KET_THUCNull();
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
            
            form_2_us_object_chi_tiet_cap_bac();
            switch (m_e_formmode)
            {
                case DataEntryFormMode.InsertDataState:
                    if (m_b_check_quyet_dinh_save)
                    {
                        form_2_us_object_quyet_dinh();
                        m_us_quyet_dinh.Insert();
                    }
                    m_us_chi_tiet_cap_bac.Insert();
                    
                    break;
                case DataEntryFormMode.UpdateDataState:
                    m_us_chi_tiet_cap_bac.Update();
                    break;
            }
            //m_us_chi_tiet_cap_bac.Insert();
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            Close();
        }
        private void us_object_2_form() {
            m_txt_ma_nv.Text = m_v_us_chi_tiet_cap_bac.strMA_NV;
            m_txt_ho_ten.Text = m_v_us_chi_tiet_cap_bac.strHO_DEM.Trim() + @" " + m_v_us_chi_tiet_cap_bac.strTEN.Trim();
            if (m_v_us_chi_tiet_cap_bac.datNGAY_BAT_DAU == DateTime.Parse("1/1/1900"))
                m_dat_ngay_bat_dau.Value = DateTime.Now;
            else
                m_dat_ngay_bat_dau.Value = m_v_us_chi_tiet_cap_bac.datNGAY_BAT_DAU;
            //m_dat_ngay_bat_dau.Value = m_v_us_chi_tiet_cap_bac.datNGAY_BAT_DAU.Date;
//             var v_ds = new DS_V_GD_CHI_TIET_CAP_BAC();
//             var v_us = new US_V_GD_CHI_TIET_CAP_BAC();
//             v_us.FillDatasetByManhanvien(v_ds, m_v_us_chi_tiet_cap_bac.strMA_NV);
//             var t = v_ds.V_GD_CHI_TIET_CAP_BAC.Rows[0][13];
//             m_txt_cap_bac_hien_tai.Text = v_ds.V_GD_CHI_TIET_CAP_BAC.Rows[0][13].ToString();
//             
            if (m_v_us_chi_tiet_cap_bac.datNGAY_KET_THUC > DateTime.Parse("1/1/1900"))
            {
                m_dat_ngay_ket_thuc.Checked = true;
                m_dat_ngay_ket_thuc.Value = m_v_us_chi_tiet_cap_bac.datNGAY_KET_THUC;
            }
            m_txt_cap_bac_hien_tai.Text = m_v_us_chi_tiet_cap_bac.strMA_CAP_BAC;

            if (m_v_us_chi_tiet_cap_bac.dcID > 0)
            {
                US_GD_CHI_TIET_CAP_BAC v_us_chi_tiet_cap_bac = new US_GD_CHI_TIET_CAP_BAC(m_v_us_chi_tiet_cap_bac.dcID);
                m_us_quyet_dinh = new US_DM_QUYET_DINH(v_us_chi_tiet_cap_bac.dcID_QUYET_DINH);
                US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(v_us_chi_tiet_cap_bac.dcID_QUYET_DINH);
                m_txt_ma_quyet_dinh.Text = v_us.strMA_QUYET_DINH;
                m_cbo_loai_quyet_dinh.SelectedValue = v_us.dcID_LOAI_QD;
                m_dat_ngay_ky.Value = v_us.datNGAY_KY;
                m_dat_ngay_co_hieu_luc_qd.Value = v_us.datNGAY_CO_HIEU_LUC;
                m_txt_noi_dung.Text = v_us.strNOI_DUNG;
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
        private void them_moi_quyet_dinh() {
            m_grb_quyet_dinh.Enabled = true;
            m_b_check_quyet_dinh_save = true;
            format_allow_edited_control();
        }
        private void chon_quyet_dinh() {
            m_b_check_quyet_dinh_save = false;
            m_grb_quyet_dinh.Enabled = true;
            format_un_edited_control();
            m_cmd_xem_file.Enabled = true;
            var v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data(CHON_QUYET_DINH.TAT_CA, ref m_us_quyet_dinh);
            if (m_us_quyet_dinh.dcID != -1) {
                m_ofd_openfile.FileName = m_us_quyet_dinh.strLINK;
                m_txt_ma_quyet_dinh.Text = m_us_quyet_dinh.strMA_QUYET_DINH;
                m_cbo_loai_quyet_dinh.SelectedValue = m_us_quyet_dinh.dcID_LOAI_QD;
                m_dat_ngay_ky.Value = m_us_quyet_dinh.datNGAY_KY;
                if (m_us_quyet_dinh.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900"))
                    m_dat_ngay_co_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_CO_HIEU_LUC;
                else
                    m_dat_ngay_co_hieu_luc_qd.Checked = false;
                m_txt_noi_dung.Text = m_us_quyet_dinh.strNOI_DUNG;
                m_ofd_openfile.FileName = m_us_quyet_dinh.strLINK;
            } else {
                m_b_check_quyet_dinh_null = true;
            }
        }
        private void format_un_edited_control() {
            m_txt_ma_quyet_dinh.ReadOnly = true;
            m_txt_ma_quyet_dinh.BackColor = System.Drawing.SystemColors.Info;
            m_cbo_loai_quyet_dinh.Enabled = false;
            m_dat_ngay_co_hieu_luc_qd.Enabled = false;
            m_dat_ngay_ky.Enabled = false;
            m_cmd_chon_file.Enabled = false;
            m_txt_noi_dung.ReadOnly = true;
            m_txt_noi_dung.BackColor = System.Drawing.SystemColors.Info;
        }
        private void format_allow_edited_control() {
            m_txt_ma_quyet_dinh.ReadOnly = false;
            m_txt_ma_quyet_dinh.BackColor = System.Drawing.SystemColors.Window;
            m_cbo_loai_quyet_dinh.Enabled = true;
            m_dat_ngay_co_hieu_luc_qd.Enabled = true;
            m_dat_ngay_ky.Enabled = true;
            m_cmd_chon_file.Enabled = true;
            m_txt_noi_dung.ReadOnly = false;
            m_txt_noi_dung.BackColor = System.Drawing.SystemColors.Window;
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
            m_cmd_them_quyet_dinh.Click += m_cmd_them_quyet_dinh_Click;
            m_cmd_chon_quyet_dinh.Click += m_cmd_chon_quyet_dinh_Click;

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
                set_initial_form_load();
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

        private void m_cmd_them_quyet_dinh_Click(object sender, EventArgs e) {
            try {
                them_moi_quyet_dinh();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_chon_quyet_dinh_Click(object sender, EventArgs e) {
            try {
                chon_quyet_dinh();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

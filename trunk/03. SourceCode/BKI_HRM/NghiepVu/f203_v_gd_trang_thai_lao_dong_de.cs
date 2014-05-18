using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using System.Diagnostics;
namespace BKI_HRM
{
    public partial class f203_v_gd_trang_thai_lao_dong_de : Form
    {
        #region Public Interface
        public void display()
        {
            this.ShowDialog();
        }
        public f203_v_gd_trang_thai_lao_dong_de()
        {
            InitializeComponent();
            format_controls();
        }
        public void display_for_insert(US_V_GD_TRANG_THAI_LAO_DONG ip_us_trang_thai_ld)
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_us_v_trang_thai_ld = ip_us_trang_thai_ld;
            us_object_to_form();
            this.ShowDialog();

        }
        public void display_for_update(US_V_GD_TRANG_THAI_LAO_DONG ip_us_trang_thai_ld)
        {
            m_us_v_trang_thai_ld = ip_us_trang_thai_ld;

            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_to_form();
            this.ShowDialog();
        }
        public void display_for_view(US_V_GD_TRANG_THAI_LAO_DONG ip_us_trang_thai_ld)
        {
            m_us_v_trang_thai_ld = ip_us_trang_thai_ld;
            m_e_form_mode = DataEntryFormMode.ViewDataState;
            m_cmd_refresh.Visible = false;
            m_cmd_save.Visible = false;
            m_cmd_chon_file.Visible = false;
            us_object_to_form();
            this.ShowDialog();
        }
        #endregion

        #region Members
        DataEntryFormMode m_e_form_mode;
        US_V_GD_TRANG_THAI_LAO_DONG m_us_v_trang_thai_ld = new US_V_GD_TRANG_THAI_LAO_DONG();
        DS_V_GD_TRANG_THAI_LAO_DONG m_ds_v_trang_thai_ld = new DS_V_GD_TRANG_THAI_LAO_DONG();
        US_GD_CHI_TIET_TRANG_THAI_LD m_us_trang_thai_ld = new US_GD_CHI_TIET_TRANG_THAI_LD();

        US_DM_QUYET_DINH m_us_quyet_dinh = new US_DM_QUYET_DINH();
        DS_DM_QUYET_DINH m_ds_quyet_dinh = new DS_DM_QUYET_DINH();
        bool m_b_check_quyet_dinh_null = false;
        bool m_b_check_quyet_dinh_save;
        #endregion

        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            this.KeyPreview = true;
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_LAO_DONG,
              WinFormControls.eTAT_CA.NO,
              m_cbo_trang_thai_moi);
            //WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH,
            //  WinFormControls.eTAT_CA.NO,
            //  m_cbo_loai_quyet_dinh);
            //  
            BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds_loai_quyet_dinh = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
            BKI_HRM.US.US_CM_DM_TU_DIEN v_us_loai_quyet_dinh = new BKI_HRM.US.US_CM_DM_TU_DIEN();
            v_us_loai_quyet_dinh.FillDataset_load_loai_quyet_dinh(v_ds_loai_quyet_dinh, "Trạng thái", "N");
            m_cbo_loai_quyet_dinh.DataSource = v_ds_loai_quyet_dinh.CM_DM_TU_DIEN;
            m_cbo_loai_quyet_dinh.DisplayMember = CM_DM_TU_DIEN.TEN;
            m_cbo_loai_quyet_dinh.ValueMember = CM_DM_TU_DIEN.ID;

            m_cmd_save.Visible = true;
            m_cmd_refresh.Visible = true;
            m_cmd_exit.Visible = true;
            m_cmd_save.Enabled = true;
            m_cmd_refresh.Enabled = true;
            m_cmd_exit.Enabled = true;
        }

        private void us_object_to_form()
        {
            m_txt_ma_nv.Text = m_us_v_trang_thai_ld.strMA_NV;
            m_txt_ho_ten.Text = m_us_v_trang_thai_ld.strHO_DEM + " " + m_us_v_trang_thai_ld.strTEN;

            m_txt_ma_nv.BackColor = SystemColors.Info;
            m_txt_ma_nv.ReadOnly = true;
            m_txt_ho_ten.BackColor = SystemColors.Info;
            m_txt_ho_ten.ReadOnly = true;
            m_us_v_trang_thai_ld.FillDatasetByManhanvien_trang_thai_hien_tai(m_ds_v_trang_thai_ld, m_us_v_trang_thai_ld.strMA_NV);
            if (m_ds_v_trang_thai_ld.V_GD_TRANG_THAI_LAO_DONG.Select("MA_NV is not null").Length > 0)
            {
                m_us_v_trang_thai_ld.DataRow2Me((DataRow)m_ds_v_trang_thai_ld.V_GD_TRANG_THAI_LAO_DONG.Rows[0]);
                m_txt_trang_thai_hien_tai.Text = m_us_v_trang_thai_ld.strTRANG_THAI_LAO_DONG;
            }
            else
                m_txt_trang_thai_hien_tai.Text = "";
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:

                    m_txt_trang_thai_hien_tai.BackColor = SystemColors.Info;
                    m_txt_trang_thai_hien_tai.ReadOnly = true;
                    break;
                case DataEntryFormMode.UpdateDataState:
                    if (m_us_v_trang_thai_ld.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900"))
                        m_dat_ngay_co_hieu_luc.Value = m_us_v_trang_thai_ld.datNGAY_CO_HIEU_LUC;
                    else
                        m_dat_ngay_co_hieu_luc.Checked = false;
                    if (m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC != null)
                        m_dat_ngay_het_hieu_luc.Value = m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC;
                    else
                        m_dat_ngay_het_hieu_luc.Checked = false;
                    m_us_quyet_dinh.FillDataset_By_Ma_qd(m_ds_quyet_dinh, m_us_v_trang_thai_ld.strMA_QUYET_DINH);
                    if (m_ds_quyet_dinh.DM_QUYET_DINH.Select("MA_QUYET_DINH is not null").Length > 0)
                    {
                        m_txt_ma_quyet_dinh.Text = m_us_v_trang_thai_ld.strMA_QUYET_DINH;
                        m_us_quyet_dinh.DataRow2Me((DataRow)m_ds_quyet_dinh.DM_QUYET_DINH.Rows[0]);
                        m_cbo_loai_quyet_dinh.SelectedValue = m_us_quyet_dinh.dcID_LOAI_QD;
                        m_dat_ngay_ky.Value = m_us_quyet_dinh.datNGAY_KY;
                        if (m_us_quyet_dinh.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900"))
                            m_dat_ngay_co_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_CO_HIEU_LUC;
                        else
                            m_dat_ngay_co_hieu_luc_qd.Checked = false;
                        if (m_us_quyet_dinh.datNGAY_HET_HIEU_LUC != null)
                            m_dat_ngay_het_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_HET_HIEU_LUC;
                        else
                            m_dat_ngay_het_hieu_luc_qd.Checked = false;
                        m_txt_noi_dung.Text = m_us_quyet_dinh.strNOI_DUNG;
                        m_ofd_openfile.FileName = m_us_quyet_dinh.strLINK;
                    }
                    else
                    {
                        m_txt_ma_quyet_dinh.Text = "";
                        m_cbo_loai_quyet_dinh.SelectedIndex = 0;
                        m_dat_ngay_ky.Checked = false;
                        m_dat_ngay_co_hieu_luc_qd.Checked = false;
                        m_dat_ngay_het_hieu_luc_qd.Checked = false;
                        m_txt_noi_dung.Text = "";
                        m_ofd_openfile.FileName = "";
                    }
                    break;
                case DataEntryFormMode.ViewDataState:
                    if (m_us_v_trang_thai_ld.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900"))
                        m_dat_ngay_co_hieu_luc.Value = m_us_v_trang_thai_ld.datNGAY_CO_HIEU_LUC;
                    else
                        m_dat_ngay_co_hieu_luc.Checked = false;
                    if (m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC != null)
                        m_dat_ngay_het_hieu_luc.Value = m_us_v_trang_thai_ld.datNGAY_HET_HIEU_LUC;
                    else
                        m_dat_ngay_het_hieu_luc.Checked = false;
                    m_us_quyet_dinh.FillDataset_By_Ma_qd(m_ds_quyet_dinh, m_us_v_trang_thai_ld.strMA_QUYET_DINH);
                    if (m_ds_quyet_dinh.DM_QUYET_DINH.Select("MA_QUYET_DINH is not null").Length > 0)
                    {
                        m_txt_ma_quyet_dinh.Text = m_us_v_trang_thai_ld.strMA_QUYET_DINH;
                        m_us_quyet_dinh.DataRow2Me((DataRow)m_ds_quyet_dinh.DM_QUYET_DINH.Rows[0]);
                        m_cbo_loai_quyet_dinh.SelectedValue = m_us_quyet_dinh.dcID_LOAI_QD;
                        m_dat_ngay_ky.Value = m_us_quyet_dinh.datNGAY_KY;
                        if (m_us_quyet_dinh.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900"))
                            m_dat_ngay_co_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_CO_HIEU_LUC;
                        else
                            m_dat_ngay_co_hieu_luc_qd.Checked = false;
                        if (m_us_quyet_dinh.datNGAY_HET_HIEU_LUC != null)
                            m_dat_ngay_het_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_HET_HIEU_LUC;
                        else
                            m_dat_ngay_het_hieu_luc_qd.Checked = false;
                        m_txt_noi_dung.Text = m_us_quyet_dinh.strNOI_DUNG;
                        m_ofd_openfile.FileName = m_us_quyet_dinh.strLINK;
                    }
                    else
                    {
                        m_txt_ma_quyet_dinh.Text = "";
                        m_cbo_loai_quyet_dinh.SelectedIndex = 0;
                        m_dat_ngay_ky.Checked = false;
                        m_dat_ngay_co_hieu_luc_qd.Checked = false;
                        m_dat_ngay_het_hieu_luc_qd.Checked = false;
                        m_txt_noi_dung.Text = "";
                        m_ofd_openfile.FileName = "";
                    }
                    m_txt_noi_dung.ReadOnly = true;
                    m_txt_noi_dung.BackColor = SystemColors.Info;
                    m_txt_ma_quyet_dinh.ReadOnly = true;
                    m_txt_ma_quyet_dinh.BackColor = SystemColors.Info;
                    m_txt_trang_thai_hien_tai.ReadOnly = true;
                    m_txt_trang_thai_hien_tai.BackColor = SystemColors.Info;
                    m_cbo_loai_quyet_dinh.Enabled = false;
                    m_cbo_trang_thai_moi.Visible = false;
                    m_lbl_trang_thai_moi.Visible = false;
                    m_dat_ngay_co_hieu_luc.Enabled = false;
                    m_dat_ngay_co_hieu_luc_qd.Enabled = false;
                    m_dat_ngay_co_hieu_luc.Enabled = false;
                    m_dat_ngay_ky.Enabled = false;

                    break;
                default: break;
            }
        }
        private void form_to_us_object_quyet_dinh()
        {
            m_us_quyet_dinh.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text.Trim();
            m_us_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_quyet_dinh.strLINK = m_ofd_openfile.FileName;
            m_us_quyet_dinh.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh.SelectedValue);
            m_us_quyet_dinh.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_quyet_dinh.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd.Value;
            if (m_dat_ngay_het_hieu_luc_qd.Checked)
                m_us_quyet_dinh.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc_qd.Value;
            else
                m_us_quyet_dinh.SetNGAY_HET_HIEU_LUCNull();
        }
        private void form_to_us_object_trang_thai_ld()
        {
            m_us_trang_thai_ld.dcID = m_us_v_trang_thai_ld.dcID;
            m_us_trang_thai_ld.dcID_NHAN_SU = m_us_v_trang_thai_ld.dcID_NHAN_SU;
            m_us_trang_thai_ld.dcID_TRANG_LAO_DONG = CIPConvert.ToDecimal(m_cbo_trang_thai_moi.SelectedValue);
            if (m_txt_ma_quyet_dinh.Text != "")
                m_us_trang_thai_ld.dcID_QUYET_DINH = m_us_quyet_dinh.dcID;
            m_us_trang_thai_ld.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value;

            if (m_dat_ngay_het_hieu_luc.Checked)
                m_us_trang_thai_ld.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc.Value;

            m_us_trang_thai_ld.strTRANG_THAI_HIEN_TAI = "Y";
        }
        private void chon_file()
        {
            m_ofd_openfile.Filter = "(*.pdf)|*.pdf|(*.doc)|*.doc|(*.docx)|*.docx|(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            m_ofd_openfile.Multiselect = false;
            m_ofd_openfile.Title = "Chọn tài liệu đính kèm";
            DialogResult result = m_ofd_openfile.ShowDialog();
        }
        private void mo_file()
        {
            Process.Start("explorer.exe", m_ofd_openfile.FileName);
        }
        private bool check_validate_data_is_ok()
        {
            if (m_dat_ngay_co_hieu_luc.Value.Date > m_dat_ngay_het_hieu_luc.Value.Date && m_dat_ngay_het_hieu_luc.Value.Date > DateTime.Parse("1/1/1900"))
            {
                BaseMessages.MsgBox_Infor("Ngày hết hiệu lực không thể trước ngày có hiệu lực.");
                return false;
            }
            if ((m_dat_ngay_het_hieu_luc_qd.Value.Date < m_dat_ngay_co_hieu_luc_qd.Value.Date)
                || (m_dat_ngay_ky.Value.Date > m_dat_ngay_het_hieu_luc_qd.Value.Date)
                )
            {
                BaseMessages.MsgBox_Infor("Ngày hết hiệu lực quyết định không thể trước ngày có hiệu lực quyết định hoặc ngày ký.");
                return false;
            }
            return true;
        }
        private bool confirm_save_data()
        {
            BKI_HRM.US.US_CM_DM_TU_DIEN v_us_tu_dien = new BKI_HRM.US.US_CM_DM_TU_DIEN();
            BKI_HRM.DS.DS_CM_DM_TU_DIEN v_ds_tu_dien = new BKI_HRM.DS.DS_CM_DM_TU_DIEN();
            string v_str_trang_thai_moi = "";
           v_us_tu_dien.FillDatasetByID(v_ds_tu_dien, CIPConvert.ToDecimal(m_cbo_trang_thai_moi.SelectedValue), ref v_str_trang_thai_moi );
           
            return BaseMessages.MsgBox_Confirm("Bạn có thực sự muốn thay đổi trạng thái lao động của \"" + m_us_v_trang_thai_ld.strHO_DEM + " " + m_us_v_trang_thai_ld.strTEN + "\" thành\n \"" + v_str_trang_thai_moi + "\" không?");

        }
        private void save_data()
        {
            if (confirm_save_data())
            {
                switch (m_e_form_mode)
                {

                    case DataEntryFormMode.UpdateDataState:
                        if (check_validate_data_is_ok() == false)
                            return;
                        else
                        {
                            form_to_us_object_quyet_dinh();
                            if (m_b_check_quyet_dinh_save)
                            {
                                if (m_b_check_quyet_dinh_null)
                                {
                                    m_us_quyet_dinh.Insert();
                                }
                                else
                                {
                                    m_us_quyet_dinh.Update();
                                }
                            }
                            form_to_us_object_trang_thai_ld();
                            m_us_trang_thai_ld.Update();

                        }

                        break;
                    case DataEntryFormMode.InsertDataState:

                        if (check_validate_data_is_ok() == false)
                            return;
                        else
                        {
                            if (m_txt_ma_quyet_dinh.Text != "")
                            {
                                form_to_us_object_quyet_dinh();
                                m_us_quyet_dinh.Insert();
                            }
                            form_to_us_object_trang_thai_ld();
                            m_us_trang_thai_ld.Insert();
                        }

                        break;
                    default:
                        break;
                }
                BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhât!");
                this.Close();
            }

        }

        private void xoa_trang()
        {
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    m_cbo_trang_thai_moi.SelectedIndex = 0;
                    m_us_quyet_dinh = null;
                    m_txt_ma_quyet_dinh.Text = "";
                    m_cbo_loai_quyet_dinh.SelectedIndex = 0;
                    m_txt_noi_dung.Text = "";
                    m_dat_ngay_co_hieu_luc.Value = DateTime.Today;
                    m_dat_ngay_co_hieu_luc_qd.Value = DateTime.Today;
                    m_dat_ngay_het_hieu_luc.Value = DateTime.Today;
                    m_dat_ngay_het_hieu_luc_qd.Value = DateTime.Today;
                    m_dat_ngay_het_hieu_luc.Checked = false;
                    m_dat_ngay_co_hieu_luc_qd.Checked = false;
                    m_dat_ngay_ky.Value = DateTime.Today;

                    break;
                case DataEntryFormMode.SelectDataState:
                    break;
                case DataEntryFormMode.UpdateDataState:
                    us_object_to_form();
                    break;
                case DataEntryFormMode.ViewDataState:
                    break;
                default:
                    break;
            }




        }
        private void set_inital_form_load()
        {

            switch (m_e_form_mode)
            {
                case DataEntryFormMode.UpdateDataState:
                    us_object_to_form();
                    break;
                case DataEntryFormMode.ViewDataState:
                    break;
                case DataEntryFormMode.InsertDataState:
                    break;
                default:
                    break;
            }

        }

        private void set_define_event()
        {
            this.Load += new EventHandler(f203_v_gd_trang_thai_lao_dong_de_Load);
            m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            m_cmd_refresh.Click += new EventHandler(m_cmd_refresh_Click);
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
        }
        private void them_quyet_dinh()
        {
            m_b_check_quyet_dinh_save = true;
            m_grb_quyet_dinh.Enabled = true;
            m_txt_ma_quyet_dinh.Focus();
        }
        private void chon_quyet_dinh()
        {
            m_b_check_quyet_dinh_save = false;
            m_grb_quyet_dinh.Enabled = true;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data(ref m_us_quyet_dinh);
            if (m_us_quyet_dinh.dcID != -1)
            {

                m_ofd_openfile.FileName = m_us_quyet_dinh.strLINK;
                m_txt_ma_quyet_dinh.Text = m_us_quyet_dinh.strMA_QUYET_DINH;

                m_cbo_loai_quyet_dinh.SelectedValue = m_us_quyet_dinh.dcID_LOAI_QD;
                m_dat_ngay_ky.Value = m_us_quyet_dinh.datNGAY_KY;
                if (m_us_quyet_dinh.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900") &&
                    m_us_quyet_dinh.datNGAY_CO_HIEU_LUC != null)
                    m_dat_ngay_co_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_CO_HIEU_LUC;
                else
                    m_dat_ngay_co_hieu_luc_qd.Checked = false;
                if (m_us_quyet_dinh.datNGAY_HET_HIEU_LUC != null &&
                    m_us_quyet_dinh.datNGAY_HET_HIEU_LUC > DateTime.Parse("1/1/1900"))
                    m_dat_ngay_het_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_HET_HIEU_LUC;
                else
                    m_dat_ngay_het_hieu_luc_qd.Checked = false;
                m_txt_noi_dung.Text = m_us_quyet_dinh.strNOI_DUNG;
                m_ofd_openfile.FileName = m_us_quyet_dinh.strLINK;

            }
            else
            {
                m_b_check_quyet_dinh_null = true;
            }
        }
        #endregion

        #region Event Hanlders
        private void f203_v_gd_trang_thai_lao_dong_de_Load(object sendrer, EventArgs e)
        {
            try
            {

                set_inital_form_load();

            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_save_Click(object sender, EventArgs e)
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
        private void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                xoa_trang();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_exit_Click(object sender, EventArgs e)
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


        private void m_cmd_chon_file_Click(object sender, EventArgs e)
        {
            try
            {
                chon_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_xem_file_Click(object sender, EventArgs e)
        {
            try
            {
                mo_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_them_quyet_dinh_Click(object sender, EventArgs e)
        {
            try
            {
                them_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_chon_quyet_dinh_Click(object sender, EventArgs e)
        {
            try
            {
                chon_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_ma_nhan_vien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                )
            {
                e.Handled = true;
            }
        }

        #endregion


    }
}

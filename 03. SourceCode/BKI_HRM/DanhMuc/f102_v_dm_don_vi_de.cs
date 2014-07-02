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

namespace BKI_HRM.DanhMuc
{
    public partial class f102_v_dm_don_vi_de : Form
    {

        #region Public Interfaces
        public f102_v_dm_don_vi_de()
        {
            InitializeComponent();
            fomat_control();
        }
        public void display_for_insert()
        {
            set_initial_form_load();
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.ShowDialog();
        }
        public void display_for_update(US_V_DM_DON_VI ip_v_us_dm_don_vi)
        {
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

        private void fomat_control()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());

            /*Load Combobox Loai don vi*/
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_DON_VI,
                WinFormControls.eTAT_CA.NO,
                m_cbo_loai_don_vi);
            /*Load Combobox Cap don vi*/
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.CAP_DON_VI,
                WinFormControls.eTAT_CA.NO,
                m_cbo_cap_don_vi);
            load_data_2_cbo_don_vi_cap_tren();
            set_define_events();
        }
        private void set_initial_form_load()
        {
            m_cbo_trang_thai.SelectedIndex = 0;
            m_cbo_cap_don_vi.SelectedIndex = (int)CAP_DON_VI.PHONG_BAN - 1;
        }
        private void load_data_2_cbo_don_vi_cap_tren()
        {
            var v_ds = new DS_V_DM_DON_VI();
            var v_us = new US_V_DM_DON_VI();
            v_us.FillDatasetByCapDonVi(v_ds, CAP_DON_VI.TRUNG_TAM);
            m_cbo_ten_don_vi_cap_tren.DisplayMember = DM_DON_VI.TEN_DON_VI;
            m_cbo_ten_don_vi_cap_tren.ValueMember = DM_DON_VI.ID;
            m_cbo_ten_don_vi_cap_tren.DataSource = v_ds.V_DM_DON_VI;
            var v_row = v_ds.V_DM_DON_VI.NewRow();
            v_row[V_DM_DON_VI.ID] = -1;
            v_row[V_DM_DON_VI.ID_CAP_DON_VI] = 0;
            v_row[V_DM_DON_VI.ID_DON_VI_CAP_TREN] = -1;
            v_row[V_DM_DON_VI.ID_LOAI_DON_VI] = -1;
            v_row[V_DM_DON_VI.MA_DON_VI] = "NULL";
            v_row[V_DM_DON_VI.TEN_DON_VI] = "Không có đơn vị cấp trên";
            v_row[V_DM_DON_VI.TEN_TIENG_ANH] = "NULL";
            v_row[V_DM_DON_VI.TRANG_THAI] = "Y";
            v_row[V_DM_DON_VI.TU_NGAY] = "1/1/1800";
            v_row[V_DM_DON_VI.DIA_BAN] = "NULL";
            v_row[V_DM_DON_VI.LOAI_DON_VI] = "NULL";
            v_row[V_DM_DON_VI.MA_DON_VI_CAP_TREN] = "NULL";
            v_row[V_DM_DON_VI.TEN_TIENG_ANH_DON_VI_CAP_TREN] = "NULL";
            v_row[V_DM_DON_VI.CAP_DON_VI] = "NULL";
            v_ds.V_DM_DON_VI.Rows.InsertAt(v_row, 0);

            switch (m_cbo_cap_don_vi.SelectedIndex)
            {
                case 0: // Tổ Hợp
                    m_cbo_ten_don_vi_cap_tren.SelectedIndex = 0;
                    m_cbo_ten_don_vi_cap_tren.Enabled = false;
                    v_us.FillDatasetByCapDonVi(v_ds, CAP_DON_VI.KHOI);
                    break;
                case 1: // Khối
                    v_us.FillDatasetByCapDonVi(v_ds, CAP_DON_VI.TRUNG_TAM);
                    m_cbo_ten_don_vi_cap_tren.Enabled = true;
                    break;
                case 2: // Trung Tâm
                    v_us.FillDatasetByCapDonVi(v_ds, CAP_DON_VI.TRUNG_TAM);
                    m_cbo_ten_don_vi_cap_tren.Enabled = true;
                    break;
                default:
                    m_cbo_ten_don_vi_cap_tren.Enabled = true;
                    break;
            }
        }
        private bool check_data_is_ok()
        {
            if (!CValidateTextBox.IsValid(m_txt_dia_ban, DataType.StringType, allowNull.YES, true))
            {
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_ma_don_vi, DataType.StringType, allowNull.NO, true))
            {
                return false;
            }

            if (!CValidateTextBox.IsValid(m_txt_ten_tieng_anh, DataType.StringType, allowNull.YES, true))
            {
                return false;
            }
            // Kiem tra nhap trung Ma Don Vi
            if (m_e_form_mode == DataEntryFormMode.InsertDataState)
            {
                if (trung_ma_don_vi(m_txt_ma_don_vi.Text.Trim()))
                {
                    BaseMessages.MsgBox_Error("Đã có mã đơn vị này!");
                    return false;
                }
            }

            return true;
        }
        private void form_2_us_object()
        {
            //             if (CIPConvert.ToDecimal(m_cbo_phap_nhan.SelectedValue) == 641)
            //             {
            //m_us.dcID_PHAP_NHAN = CIPConvert.ToDecimal(m_cbo_phap_nhan.SelectedValue);
            //             }
            //             else
            //             {
            //                 m_us.SetID_PHAP_NHANNull();
            //             }
            if (CIPConvert.ToDecimal(m_cbo_ten_don_vi_cap_tren.SelectedValue) == -1)
            {
                m_us.SetID_DON_VI_CAP_TRENNull();
            }
            else
            {
                m_us.dcID_DON_VI_CAP_TREN = CIPConvert.ToDecimal(m_cbo_ten_don_vi_cap_tren.SelectedValue);
            }
            
            m_us.dcID_LOAI_DON_VI = CIPConvert.ToDecimal(m_cbo_loai_don_vi.SelectedValue);
            m_us.dcID_CAP_DON_VI = CIPConvert.ToDecimal(m_cbo_cap_don_vi.SelectedValue);
            switch (int.Parse(m_cbo_cap_don_vi.SelectedValue.ToString()))
            {
                case 691:
                    m_us.dcID_LEVEL = CIPConvert.ToDecimal(0);
                    break;
                case 738:
                    m_us.dcID_LEVEL = CIPConvert.ToDecimal(1);
                    break;
                case 641:
                    m_us.dcID_LEVEL = CIPConvert.ToDecimal(2);
                    break;
                case 640:
                    m_us.dcID_LEVEL = CIPConvert.ToDecimal(3);
                    break;
                case 642:
                    m_us.dcID_LEVEL = CIPConvert.ToDecimal(4);
                    break;
            }
            m_us.SetSO_LUONGNull();
            m_us.strMA_DON_VI = m_txt_ma_don_vi.Text.Trim();
            m_us.strTEN_DON_VI = m_txt_ten_don_vi.Text.Trim();
            m_us.strTEN_TA = m_txt_ten_tieng_anh.Text.Trim();
            m_us.strDIA_BAN = m_txt_dia_ban.Text.Trim();
            m_us.strTRANG_THAI = get_trang_thai(m_cbo_trang_thai);
            //m_us.dcID_LOAI_DON_VI = CIPConvert.ToDecimal(m_cbo_loai_don_vi.SelectedValue);
            //m_us.dcID_CAP_DON_VI = CIPConvert.ToDecimal(m_cbo_cap_don_vi.SelectedValue);
            m_us.datTU_NGAY = m_dat_tu_ngay.Value.Date;
        }
        private static string get_trang_thai(ListControl ip_cbo)
        {
            return ip_cbo.SelectedIndex == 0 ? "Y" : "N";
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
            Close();
        }
        private void us_object_2_form(US_V_DM_DON_VI ip_us_dm_don_vi)
        {
            //             if (m_us.dcID_PHAP_NHAN != null)
            //             {
            //m_cbo_phap_nhan.SelectedValue = m_us.dcID_PHAP_NHAN;
            // }
            m_us.dcID = ip_us_dm_don_vi.dcID;
            m_cbo_cap_don_vi.SelectedValue = ip_us_dm_don_vi.dcID_CAP_DON_VI;
            m_cbo_loai_don_vi.SelectedValue = ip_us_dm_don_vi.dcID_LOAI_DON_VI;
            if (ip_us_dm_don_vi.dcID_DON_VI_CAP_TREN == 0)
            {
                m_cbo_ten_don_vi_cap_tren.SelectedIndex = 0;
            }
            else
            {
                m_cbo_ten_don_vi_cap_tren.SelectedValue = ip_us_dm_don_vi.dcID_DON_VI_CAP_TREN;
            }
            m_txt_ma_don_vi.Text = ip_us_dm_don_vi.strMA_DON_VI;
            m_txt_ten_don_vi.Text = ip_us_dm_don_vi.strTEN_DON_VI;
            m_txt_ten_tieng_anh.Text = ip_us_dm_don_vi.strTEN_TIENG_ANH;
            m_txt_dia_ban.Text = ip_us_dm_don_vi.strDIA_BAN;
            m_cbo_trang_thai.SelectedIndex = ip_us_dm_don_vi.strTRANG_THAI.ToUpper().Equals("ĐANG SỬ DỤNG") ? 0 : 1;
            m_dat_tu_ngay.Value = ip_us_dm_don_vi.datTU_NGAY.Date;
        }
        private bool trung_ma_don_vi(string ip_str_ma_don_vi)
        {
            var v_ds = new DS_V_DM_DON_VI();
            var v_us = new US_V_DM_DON_VI();
            v_us.FillDatasetByKeyWord(v_ds, ip_str_ma_don_vi, -1, -1, "");
            decimal v_count = v_ds.V_DM_DON_VI.Count;
            if (v_count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Events

        private void set_define_events()
        {
            m_cmd_save.Click += m_cmd_save_Click;
            m_cmd_exit.Click += m_cmd_exit_Click;
            m_cbo_ten_don_vi_cap_tren.SelectedIndexChanged +=
                m_cbo_ten_don_vi_cap_tren_SelectedIndexChanged;
            m_cbo_cap_don_vi.SelectedIndexChanged +=
                m_cbo_cap_don_vi_SelectedIndexChanged;

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

        protected void m_cbo_ma_don_vi_cap_tren_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void m_cbo_ten_don_vi_cap_tren_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void m_cmd_refresh_Click(object sender, EventArgs e)
        {

        }

        protected void m_cmd_exit_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void f102_v_dm_don_vi_de_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_cap_don_vi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                load_data_2_cbo_don_vi_cap_tren();
                //                 if (CIPConvert.ToDecimal(m_cbo_cap_don_vi.SelectedValue) == 641)
                //                 {
                //                     m_lbl_phap_nhan.Visible = true;
                //                     m_cbo_phap_nhan.Visible = true;
                //                 }
                //                 else
                //                 {
                //                     m_lbl_phap_nhan.Visible = false;
                //                     m_cbo_phap_nhan.Visible = false;
                //                 }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        #endregion

    }
}

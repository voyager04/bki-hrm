using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using BKI_HRM.DS;
using IP.Core.IPCommon;

namespace BKI_HRM.NghiepVu
{
    public partial class F701_V_GD_HOP_DONG_LAO_DONG_DE : Form
    {
        #region Public Interfaces
        public F701_V_GD_HOP_DONG_LAO_DONG_DE()
        {
            InitializeComponent();
            CControlFormat.setFormStyle(this);
            m_cbo_trang_thai.SelectedIndex = 0;
        }

        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            load_data_2_cbo_loai_hop_dong();
            this.ShowDialog();
        }

        public void display_for_update(US_GD_HOP_DONG ip_m_us_gd_hop_dong)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            load_data_2_cbo_loai_hop_dong();
            us_object_2_form(ip_m_us_gd_hop_dong);
            this.ShowDialog();
        }
        #endregion

        #region Data Structures
        #endregion

        #region Member
        private DataEntryFormMode m_e_form_mode;
        US_GD_HOP_DONG m_us = new US_GD_HOP_DONG();
        DS_GD_HOP_DONG m_ds = new DS_GD_HOP_DONG();
        US_V_GD_HOP_DONG_LAO_DONG m_us_v = new US_V_GD_HOP_DONG_LAO_DONG();
        DS_V_GD_HOP_DONG_LAO_DONG m_ds_v = new DS_V_GD_HOP_DONG_LAO_DONG();
        US_DM_NHAN_SU m_us_dm_nhan_su = new US_DM_NHAN_SU();
        #endregion

        #region Private Methods
        private bool check_data_is_ok()
        {
            if (!CValidateTextBox.IsValid(m_txt_ma_hop_dong, DataType.StringType, allowNull.NO, true))
            {
                return false;
            }

            return true;
        }

        private void form_2_us_object()
        {
            m_us.strMA_HOP_DONG = m_txt_ma_hop_dong.Text;
            m_us.dcID_LOAI_HOP_DONG = (decimal)m_cbo_loai_hop_dong.SelectedValue;
            m_us.dcID_NHAN_SU = m_us_dm_nhan_su.dcID;
            m_us.strLINK = m_txt_link.Text;
            m_us.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value;
            m_us.datNGAY_HET_HAN = m_dat_ngay_het_han.Value;
            m_us.strTRANG_THAI_HOP_DONG = m_cbo_trang_thai.SelectedIndex.Equals(0) ? "y" : "n";
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
            this.Close();
        }

        private void us_object_2_form(US_GD_HOP_DONG ip_us_gd_hop_dong)
        {
            m_us.dcID = ip_us_gd_hop_dong.dcID;
            m_txt_ma_hop_dong.Text = ip_us_gd_hop_dong.strMA_HOP_DONG;
            m_cbo_loai_hop_dong.SelectedValue = ip_us_gd_hop_dong.dcID_LOAI_HOP_DONG;
            m_txt_link.Text = ip_us_gd_hop_dong.strLINK;
            m_dat_ngay_co_hieu_luc.Value = ip_us_gd_hop_dong.datNGAY_CO_HIEU_LUC;
            m_dat_ngay_het_han.Value = ip_us_gd_hop_dong.datNGAY_HET_HAN;
            m_cbo_trang_thai.SelectedIndex = (ip_us_gd_hop_dong.strTRANG_THAI_HOP_DONG.Equals("y")) ? 0 : 1;

            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU(ip_us_gd_hop_dong.dcID_NHAN_SU);
            m_lbl_ma_nhan_vien.Text = v_us_dm_nhan_su.strMA_NV;
            m_lbl_ho_va_ten.Text = v_us_dm_nhan_su.strHO_DEM + " " + v_us_dm_nhan_su.strTEN;
        }

        private void load_data_2_cbo_loai_hop_dong()
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_td = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_td = new US_CM_DM_TU_DIEN();
            v_us_cm_dm_td.FillDatasetByIdLoaiTuDien(v_ds_cm_dm_td, 6);
            m_cbo_loai_hop_dong.DataSource = v_ds_cm_dm_td.Tables[0];
            m_cbo_loai_hop_dong.DisplayMember = CM_DM_TU_DIEN.TEN_NGAN;
            m_cbo_loai_hop_dong.ValueMember = CM_DM_TU_DIEN.ID;
        }

        private void xoa_trang()
        {
            m_txt_ma_hop_dong.Text = "";
            m_cbo_loai_hop_dong.SelectedIndex = 0;
            //m_cbo_nhan_su.SelectedIndex = 0;
            m_txt_link.Text = "";
            m_dat_ngay_co_hieu_luc.Value = DateTime.Today;
            m_dat_ngay_het_han.Value = DateTime.Today;
            m_cbo_trang_thai.SelectedIndex = 0;
            m_txt_ma_hop_dong.Focus();
        }

        private void chon_nhan_su()
        {
            f201_dm_nhan_su v_f_dm_nhan_su = new f201_dm_nhan_su();
            v_f_dm_nhan_su.select_data(ref m_us_dm_nhan_su);
            m_lbl_ma_nhan_vien.Text = m_us_dm_nhan_su.strMA_NV;
            m_lbl_ho_va_ten.Text = m_us_dm_nhan_su.strHO_DEM + " " + m_us_dm_nhan_su.strTEN;
        }

        #endregion

        #region Events
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
        #endregion

        private void m_cmd_chon_nhan_su_Click(object sender, EventArgs e)
        {
            try
            {
                chon_nhan_su();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

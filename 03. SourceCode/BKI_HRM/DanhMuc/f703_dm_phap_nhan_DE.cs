using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKI_HRM.DS;
using BKI_HRM.US;
using IP.Core.IPCommon;

namespace BKI_HRM.DanhMuc
{
    public partial class f703_dm_phap_nhan_DE : Form
    {
        #region Public Interfaces
        public f703_dm_phap_nhan_DE()
        {
            InitializeComponent();
        }

        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.ShowDialog();
        }

        public void display_for_update(US_DM_PHAP_NHAN ip_m_us_dm_phap_nhan)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form(ip_m_us_dm_phap_nhan);
            m_str_id_phap_nhan_old = ip_m_us_dm_phap_nhan.dcID;
            this.ShowDialog();
        }
        #endregion

        #region Data Structures
        #endregion

        #region Member
        private DataEntryFormMode m_e_form_mode;
        US_DM_PHAP_NHAN m_us = new US_DM_PHAP_NHAN();
        DS_DM_PHAP_NHAN m_ds = new DS_DM_PHAP_NHAN();
        private decimal m_str_id_phap_nhan_old;
        #endregion

        #region Private Methods
        private bool check_data_is_ok()
        {
            if (m_txt_ma_phap_nhan.Text == "")
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập Mã Pháp Nhân");
                return false;
            }

            if (m_txt_ten_phap_nhan.Text == "")
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập Tên Pháp Nhân");
                return false;
            }

            if (m_txt_ma_so_thue.Text == "")
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập Mã Số Thuế");
                return false;
            }

            if (m_txt_ma_dang_ky_kinh_doanh.Text == "")
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập Mã Đăng Ký Kinh Doanh");
                return false;
            }

            if (m_txt_nguoi_dai_dien.Text == "")
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập Người Đại Diện");
                return false;
            }
            return true;
        }

        private void form_2_us_object()
        {
            m_us.strMA_PHAP_NHAN = m_txt_ma_phap_nhan.Text;
            m_us.strTEN_PHAP_NHAN = m_txt_ten_phap_nhan.Text;
            m_us.strMA_SO_THUE = m_txt_ma_so_thue.Text;
            m_us.strMA_DK_KINH_DOANH = m_txt_ma_dang_ky_kinh_doanh.Text;
            m_us.strDIA_CHI = m_txt_dia_chi.Text;
            m_us.strNGUOI_DAI_DIEN = m_txt_nguoi_dai_dien.Text;
            m_us.datNGAY_DK_KINH_DOANH = m_dat_ngay_dang_ky_kinh_doanh.Value;
        }

        private void save_data()
        {
            if (check_data_is_ok() == false)
                return;
            form_2_us_object();
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    if (check_trung_ma_phap_nhan(m_txt_ma_phap_nhan.Text))
                    {
                        BaseMessages.MsgBox_Error("Mã pháp nhân đã tồn tại.");
                        m_txt_ma_phap_nhan.Focus();
                        return;
                    }
                    m_us.Insert();
                    break;
                case DataEntryFormMode.UpdateDataState:
                    US_DM_PHAP_NHAN v_us_dm_phap_nhan = new US_DM_PHAP_NHAN(m_str_id_phap_nhan_old);
                    if (!m_txt_ma_phap_nhan.Text.Equals(v_us_dm_phap_nhan.strMA_PHAP_NHAN))
                    {
                        if (check_trung_ma_phap_nhan(m_txt_ma_phap_nhan.Text))
                        {
                            BaseMessages.MsgBox_Error("Mã pháp nhân đã tồn tại.");
                            m_txt_ma_phap_nhan.Focus();
                            return;
                        }
                    }
                    m_us.Update();
                    break;
            }
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            this.Close();
        }

        private void us_object_2_form(US_DM_PHAP_NHAN ip_us_dm_phap_nhan)
        {
            m_us.dcID = ip_us_dm_phap_nhan.dcID;
            m_txt_ma_phap_nhan.Text = ip_us_dm_phap_nhan.strMA_PHAP_NHAN;
            m_txt_ten_phap_nhan.Text = ip_us_dm_phap_nhan.strTEN_PHAP_NHAN;
            m_txt_ma_so_thue.Text = ip_us_dm_phap_nhan.strMA_SO_THUE;
            m_txt_ma_dang_ky_kinh_doanh.Text = ip_us_dm_phap_nhan.strMA_DK_KINH_DOANH;
            m_dat_ngay_dang_ky_kinh_doanh.Value = ip_us_dm_phap_nhan.datNGAY_DK_KINH_DOANH;
            m_txt_dia_chi.Text = ip_us_dm_phap_nhan.strDIA_CHI;
            m_txt_nguoi_dai_dien.Text = ip_us_dm_phap_nhan.strNGUOI_DAI_DIEN;
        }

        private bool check_trung_ma_phap_nhan(string ip_str_ma_phap_nhan)
        {

            DS_DM_PHAP_NHAN v_ds = new DS_DM_PHAP_NHAN();
            m_us.FillDatasetSearchByMaPhapNhan(v_ds, ip_str_ma_phap_nhan);
            decimal count_ma_phap_nhan = v_ds.DM_PHAP_NHAN.Count;
            if (count_ma_phap_nhan > 0)
                return true;
            return false;
        }
        #endregion

        #region Event
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
    }
}

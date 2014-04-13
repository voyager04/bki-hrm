using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using System.IO;

namespace BKI_HRM.DanhMuc
{
    public partial class F603_dm_cap_bac_de : Form
    {
        #region Public Interfaces
        public F603_dm_cap_bac_de ()
        {
            InitializeComponent();
            format_control();

        }
        public void get_us(ref US_DM_CAP_BAC op_us)
        {
            op_us = m_us;
        }
        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;

            this.ShowDialog();
        }
        public void display_for_update(US_DM_CAP_BAC ip_m_us_v_dm_cap_bac)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;

            us_object_2_form(ip_m_us_v_dm_cap_bac);
            m_us_1 = ip_m_us_v_dm_cap_bac;
            this.ShowDialog();
        }
        private void refresh_control() {
            if (m_e_form_mode == DataEntryFormMode.InsertDataState)
            {
                m_txt_ma_bac.Text = "";
                m_txt_ma_cap.Text = "";
                m_dat_ngay_ap_dung.Value = DateTime.Now;
                m_dat_ngay_ket_thuc.Value=DateTime.Now;
                m_rdb_su_dung.Checked = true;
                
            }
            else
                us_object_2_form(m_us_1);
        }
        #endregion
        #region Data Structures
        #endregion
        #region Members
        private DataEntryFormMode m_e_form_mode;
        private US_DM_CAP_BAC m_us_1 = new US_DM_CAP_BAC();
            private US_V_DM_CAP_BAC m_v_us = new US_V_DM_CAP_BAC();
        private DS_V_DM_CAP_BAC m_v_ds = new DS_V_DM_CAP_BAC();
        private US_DM_CAP_BAC m_us = new US_DM_CAP_BAC();
        private DS_DM_CAP_BAC m_ds = new DS_DM_CAP_BAC();
        #endregion

        #region Private Methods

        //private bool check_trung_ma_cap(string ip_str_ma_cap)
        //{
        //    DS_V_DM_CAP_BAC v_ds = new DS_V_DM_CAP_BAC();
        //    decimal count_ma_cap_bac;
        //    m_v_us.FillDataset(v_ds, ip_str_ma_cap);
        //    count_ma_cap_bac = v_ds.V_DM_CAP_BAC.Count;
        //    if (count_ma_cap_bac > 0)
        //        return true;
        //    return false;
        //}
        //private bool check_trung_ma_bac(string ip_str_ma_bac)
        //{
        //    DS_V_DM_CAP_BAC v_ds = new DS_V_DM_CAP_BAC();
        //    decimal count_ma_cap_bac;
        //    m_v_us.FillDataset(v_ds, ip_str_ma_bac);
        //    count_ma_cap_bac = v_ds.V_DM_CAP_BAC.Count;
        //    if (count_ma_cap_bac > 0)
        //        return true;
        //    return false;
        //}
        private void us_object_2_form(US_DM_CAP_BAC ip_us_v_dm_cap_bac)
        {
            m_us.dcID = ip_us_v_dm_cap_bac.dcID;
            m_txt_ma_cap.Text = ip_us_v_dm_cap_bac.strMA_CAP;
            m_txt_ma_bac.Text = ip_us_v_dm_cap_bac.strMA_BAC;
            if (ip_us_v_dm_cap_bac.datNGAY_AP_DUNG.Year > 1900)
                m_dat_ngay_ap_dung.Value = ip_us_v_dm_cap_bac.datNGAY_AP_DUNG;
            else
                m_dat_ngay_ap_dung.Checked = false;
            if (ip_us_v_dm_cap_bac.datNGAY_KET_THUC.Year > 1900)
                m_dat_ngay_ket_thuc.Value = ip_us_v_dm_cap_bac.datNGAY_KET_THUC;
            else
                m_dat_ngay_ket_thuc.Checked = false;

            if (ip_us_v_dm_cap_bac.strTRANG_THAI == "Y")
                m_rdb_su_dung.Checked = true;
            else
                m_rdb_khong_su_dung.Checked = true;
            
        }

        private void format_control()
        {
            CControlFormat.setFormStyle(this);
            set_define_events();


        }
        private bool check_data_is_ok()
        {
            if (!CValidateTextBox.IsValid(m_txt_ma_cap, DataType.StringType, allowNull.NO, true))
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập mã cấp");
                //    return false;
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_ma_bac, DataType.StringType, allowNull.NO, true))
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập mã bậc");
                //    return false;
                return false;
            }
            //if (m_txt_ma_bac.Text == "")
            //{
            //    BaseMessages.MsgBox_Infor("Bạn chưa nhập mã bậc");
            //    return false;
            //}
            //if (m_txt_ma_cap.Text == "")
            //{
            //    BaseMessages.MsgBox_Infor("Bạn chưa nhập mã cấp");
            //    return false;
            //}
            return true;
        }
        private void form_2_us_object()
        {
            m_us.strMA_BAC = m_txt_ma_bac.Text.Trim();
            
            m_us.strMA_CAP = m_txt_ma_cap.Text.Trim();
            m_us.datNGAY_AP_DUNG = m_dat_ngay_ap_dung.Value.Date;
            m_us.datNGAY_KET_THUC = m_dat_ngay_ket_thuc.Value.Date;
            if (m_dat_ngay_ap_dung.Checked)
            {
                m_us.datNGAY_AP_DUNG = m_dat_ngay_ap_dung.Value.Date;
            }
            else
            {
                m_us.SetNGAY_AP_DUNGNull();
            }
            if (m_dat_ngay_ket_thuc.Checked)
            {
                m_us.datNGAY_KET_THUC= m_dat_ngay_ket_thuc.Value.Date;
            }
            else
            {
                m_us.SetNGAY_KET_THUCNull();
            }
            //m_us.strTRANG_THAI
            //Fail
            m_us.strTRANG_THAI = m_rdb_khong_su_dung.Checked ? "N" : "Y";

        }

        private void save_data()
        {
            switch (m_e_form_mode)
            {

                case DataEntryFormMode.UpdateDataState:
                    if (check_data_is_ok() == false)

                        return;

                    else
                    {
                        form_2_us_object();
                        m_us.Update();
                    }

                    break;
                case DataEntryFormMode.InsertDataState:
                    
                    if (check_trung_ma_bac(m_txt_ma_bac.Text))
                    {
                        BaseMessages.MsgBox_Error(217);
                        m_txt_ma_bac.BackColor = Color.Bisque;
                        m_txt_ma_bac.Focus();
                        m_txt_ma_bac.SelectAll();
                        return;
                    } else 
                    if (check_trung_ma_cap(m_txt_ma_cap.Text))
                    {
                        BaseMessages.MsgBox_Error(218);
                        m_txt_ma_cap.BackColor = Color.Bisque;
                        m_txt_ma_cap.Focus();
                        m_txt_ma_cap.SelectAll();
                        return;
                    }
                    else
                    {
                        m_txt_ma_bac.BackColor = Color.White;
                        if (check_data_is_ok() == false)
                            return;
                        else
                        {
                            form_2_us_object();
                            m_us.Insert();
                        }

                    }

                    break;
                default: break;
            }
            BaseMessages.MsgBox_Infor("Cập nhật dữ liệu thành công!");
            this.Close();
        }
        //private bool check_trung_ma_cap(string ip_str_ma_cap)
        //{

        //    DS_V_DM_CAP_BAC v_ds = new DS_V_DM_CAP_BAC();
        //    decimal count_ma_cap;
        //    m_us.FillDataset(v_ds, ip_str_ma_cap);
        //    count_ma_cap = v_ds.V_DM_CAP_BAC.Count;
        //    if (count_ma_cap > 0)
        //        return true;
        //    return false;
        //}
        private bool kiem_tra_ngay_truoc_sau()
        {
            if (m_dat_ngay_ap_dung.Value.Date >= m_dat_ngay_ket_thuc.Value.Date)
            {
                BaseMessages.MsgBox_Error("Ngày áp dụng phải trước ngày hết hiệu lực!");
                return false;
            }
            return true;
        }
        private bool check_trung_ma_bac(string ip_str_ma_bac)
        {

            DS_V_DM_CAP_BAC v_ds = new DS_V_DM_CAP_BAC();
            decimal count_ma_bac;
            m_v_us.FillDataset_By_Ma_bac(v_ds, ip_str_ma_bac);
            count_ma_bac = v_ds.V_DM_CAP_BAC.Count;
            if (count_ma_bac > 0)
                return true;
            return false;
        }
        private bool check_trung_ma_cap(string ip_str_ma_cap)
        {

            DS_V_DM_CAP_BAC v_ds = new DS_V_DM_CAP_BAC();
            decimal count_ma_cap;
            m_v_us.FillDataset_By_Ma_cap(v_ds, ip_str_ma_cap);
            count_ma_cap = v_ds.V_DM_CAP_BAC.Count;
            if (count_ma_cap > 0)
                return true;
            return false;
        }

        private void fomat_control()
        {
            CControlFormat.setFormStyle(this);
            set_define_events();
        }
        private void refresh()
        {
            try
            {
                refresh_control();
            }
            catch (Exception v_e)
            {
                
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion
        #region Events
        private void set_define_events()
        {
            this.m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            this.m_cmd_refresh.Click += new EventHandler(m_cmd_refresh_Click);
            this.m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
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

        protected void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                refresh();
            }
            catch (Exception v_e)
            {
                
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        protected void m_cmd_exit_Click(object sender, EventArgs e)
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

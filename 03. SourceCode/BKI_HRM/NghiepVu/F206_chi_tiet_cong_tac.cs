using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPWordReport;
using System.Diagnostics;
using IP.Core.IPSystemAdmin;
using System.Collections;
namespace BKI_HRM
{
    public partial class F206_chi_tiet_cong_tac : Form
    {
        #region Public Interfaces
        public F206_chi_tiet_cong_tac()
        {
            InitializeComponent();
            format_controls();
            set_define_event();
        }
        public void display(ref US_V_GD_CONG_TAC op_us)
        {
            this.ShowDialog();
            op_us = m_us;
        }
        #endregion
        #region Data Structure
        #endregion
        #region Members
        US_V_GD_CONG_TAC m_us;
        #endregion
        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            this.KeyPreview = true;
        }
        private void form_2_us_object()
        {
           
            m_us.strMA_NV = m_txt_ma_nhan_vien.Text;
            m_us.strHO_DEM = m_txt_ho_dem.Text;
            m_us.strTEN = m_txt_ten.Text;
            m_us.datNGAY_VE = m_dat_ngay_ve.Value;
            m_us.datNGAY_DI = m_dat_ngay_di.Value;
            m_us.strDIA_DIEM = m_txt_dia_diem.Text;
            m_us.strMO_TA_CONG_VIEC = m_txt_mo_ta_cong_viec.Text;
        }
        
        private void xoa_trang()
        {
            m_txt_dia_diem.Text = "";
            m_txt_ho_dem.Text = "";
            m_txt_ten.Text = "";
            m_txt_ma_nhan_vien.Text = "";
            m_txt_mo_ta_cong_viec.Text = "";
            m_dat_ngay_di.Value = DateTime.Today;
            m_dat_ngay_ve.Value = DateTime.Today;
        }
        private void set_define_event()
        {
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            m_cmd_refresh.Click += new EventHandler(m_cmd_refresh_Click);
        }
        #endregion
        #region  Events
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
        private void m_cmd_save_Click(object sender, EventArgs e)
        {
            form_2_us_object();
            this.Close();
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
        #endregion

    }
}

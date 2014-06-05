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
        public void display(string ip_str, ref string op_str)
        {
            m_str_ip = ip_str;
            m_txt_mo_ta_cong_viec.Text = m_str_ip;
            this.ShowDialog();
            op_str = m_str_op;
        }
        #endregion
        #region Data Structure
        #endregion
        #region Members
        string m_str_op = "";
        string m_str_ip = "";
        #endregion
        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            this.KeyPreview = true;
           
        }
       
        
        private void xoa_trang()
        {
            m_txt_mo_ta_cong_viec.Text = m_str_ip;
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
                m_str_op = m_str_ip;
                this.Close();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_save_Click(object sender, EventArgs e)
        {
            m_str_op = m_txt_mo_ta_cong_viec.Text.Trim();
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

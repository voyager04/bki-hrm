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

namespace BKI_HRM
{
    public partial class f204_dm_headcount_de : Form
    {
    #region "Public Interfaces"
        public f204_dm_headcount_de()
        {
            InitializeComponent();
            format_controls();
        }
        public void display_for_insert()
        {
            
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.ShowDialog();
        }
        public void display_for_update(US_DM_HEADCOUNT ip_v_us_dm_headcount)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form(ip_v_us_dm_headcount);
            this.ShowDialog();
        }
        public void display_for_view(US_DM_HEADCOUNT ip_v_us_dm_headcount)
        {
            m_e_form_mode = DataEntryFormMode.ViewDataState;
            us_object_2_form(ip_v_us_dm_headcount);
            this.ShowDialog();
        }
#endregion
    #region "Data Structures"
        #endregion
    #region "Members"
        private DataEntryFormMode m_e_form_mode;
        private US_DM_HEADCOUNT m_us = new US_DM_HEADCOUNT();
        private DS_DM_HEADCOUNT m_ds = new DS_DM_HEADCOUNT();
        
#endregion
    #region "Private Methods"
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            
            
        }
        
        private bool check_data_is_ok()
        {
            
            return true;
        }
        private void form_2_us_object()
        {
            m_us.strMA_HEADCOUNT = m_txt_ma_headcount.Text.Trim();
            m_us.strTRANG_THAI = m_txt_trang_thai.Text.Trim();
            m_us.strMO_TA = m_txt_mo_ta.Text.Trim();
            m_us.strACTIONS = m_txt_actions.Text.Trim();
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
        private void us_object_2_form(US_DM_HEADCOUNT ip_us_dm_headcount)
        {
            m_txt_ma_headcount.Text = ip_us_dm_headcount.strMA_HEADCOUNT;
            m_txt_actions.Text = ip_us_dm_headcount.strACTIONS;
            m_txt_mo_ta.Text = ip_us_dm_headcount.strMO_TA;
            m_txt_trang_thai.Text = ip_us_dm_headcount.strTRANG_THAI;
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.ViewDataState:
                    m_txt_trang_thai.ReadOnly = true;
                    m_txt_mo_ta.ReadOnly = true;
                    m_txt_ma_headcount.ReadOnly = true;
                    m_txt_actions.ReadOnly = true;
                    m_txt_actions.BackColor = SystemColors.Info;
                    m_txt_ma_headcount.BackColor = SystemColors.Info;
                    m_txt_mo_ta.BackColor = SystemColors.Info;
                    m_txt_trang_thai.BackColor = SystemColors.Info;
                    m_cmd_save.Visible = false;
                    m_cmd_refresh.Visible = false;
                    break;
                
            }
        }
      
#endregion

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
    #region "Events"
#endregion
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
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


    public partial class f107_tach_nhap_don_vi : Form
    {


        #region Public
        public f107_tach_nhap_don_vi()
        {
            InitializeComponent();
            set_define_event();
            format_controls();
        }
        #endregion

        #region Members

        US_DM_DON_VI m_us_dm_don_vi_1 = new US_DM_DON_VI();
        US_DM_DON_VI m_us_dm_don_vi_2 = new US_DM_DON_VI();

        #endregion

        #region Data Structs
        #endregion

        #region Private Methods

        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            KeyPreview = true;
        }

        private void nhap_chon_don_vi_thu_nhat(){
            f101_v_dm_don_vi v_frm = new f101_v_dm_don_vi();
            v_frm.select_data(ref m_us_dm_don_vi_1);
            m_cmd_nhap_chon_don_vi_thu_nhat.Text = m_us_dm_don_vi_1.strMA_DON_VI + " - " + m_us_dm_don_vi_1.strTEN_DON_VI;
        }

        private void nhap_chon_don_vi_thu_hai()
        {
            f101_v_dm_don_vi v_frm = new f101_v_dm_don_vi();
            v_frm.select_data(ref m_us_dm_don_vi_2);
            m_cmd_nhap_chon_don_vi_thu_hai.Text = m_us_dm_don_vi_2.strMA_DON_VI + " - " + m_us_dm_don_vi_2.strTEN_DON_VI;
        }

        private void tach_chon_don_vi_can_tach()
        {
            f101_v_dm_don_vi v_frm = new f101_v_dm_don_vi();
            v_frm.select_data(ref m_us_dm_don_vi_1);
            m_cmd_tach_chon_don_vi_can_tach.Text = m_us_dm_don_vi_1.strMA_DON_VI + " - " + m_us_dm_don_vi_1.strTEN_DON_VI;
        }

        #endregion

        // Event

        private void set_define_event(){
            m_cmd_nhap_chon_don_vi_thu_nhat.Click += m_cmd_nhap_chon_don_vi_thu_nhat_Click;
            m_cmd_nhap_chon_don_vi_thu_hai.Click += m_cmd_nhap_chon_don_vi_thu_hai_Click;

            m_cmd_tach_chon_don_vi_can_tach.Click += m_cmd_tach_chon_don_vi_can_tach_Click;
        }

        private void m_cmd_nhap_chon_don_vi_thu_nhat_Click(object sender, EventArgs e)
        {
            try{
                nhap_chon_don_vi_thu_nhat();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_nhap_chon_don_vi_thu_hai_Click(object sender, EventArgs e)
        {
            try
            {
                nhap_chon_don_vi_thu_hai();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_tach_chon_don_vi_can_tach_Click(object sender, EventArgs e)
        {
            try
            {
                tach_chon_don_vi_can_tach();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKI_HRM.US;
using IP.Core.IPCommon;

namespace BKI_HRM.NghiepVu
{
    public partial class f701_v_gd_hop_dong_lao_dong_View : Form
    {
        #region Public Interface
        public f701_v_gd_hop_dong_lao_dong_View()
        {
            InitializeComponent();
        }

        public void display_for_view(US_GD_HOP_DONG ip_m_us_gd_hop_dong)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_us_gd_hop_dong = ip_m_us_gd_hop_dong;
            this.ShowDialog();
        }
        #endregion

        #region Member
        private DataEntryFormMode m_e_form_mode;
        US_GD_HOP_DONG m_us_gd_hop_dong = new US_GD_HOP_DONG();
        private string m_str_destination = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        #endregion

        private void f701_v_gd_hop_dong_lao_dong_View_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(ConfigurationSettings.AppSettings["DESTINATION_NAME"] + m_us_gd_hop_dong.strLINK);
        }
    }
}

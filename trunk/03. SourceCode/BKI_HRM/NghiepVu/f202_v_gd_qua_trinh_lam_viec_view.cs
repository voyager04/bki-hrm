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

namespace BKI_HRM
{
    public partial class f202_v_gd_qua_trinh_lam_viec_view : Form
    {

        #region Public Interface
        public f202_v_gd_qua_trinh_lam_viec_view()
        {
            InitializeComponent();
        }
        public void display_for_view_quyet_dinh(US_DM_QUYET_DINH ip_us)
        {
            m_us_dm_quyet_dinh = ip_us;
            this.ShowDialog();
        }


        #endregion
        #region Member
        US_DM_QUYET_DINH m_us_dm_quyet_dinh = new US_DM_QUYET_DINH();
        #endregion
        #region Private Method
        private void f202_v_gd_qua_trinh_lam_viec_view_Load(object sender, EventArgs e)
        {
            m_wbr_xem_quyet_dinh.Navigate(ConfigurationSettings.AppSettings["DESTINATION_NAME"] + m_us_dm_quyet_dinh.strLINK);
            return;
        }
        #endregion
    }
}

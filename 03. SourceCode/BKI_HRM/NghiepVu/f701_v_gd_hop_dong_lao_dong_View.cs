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

        public void display(string path)
        {
            m_str_path = path;
            this.ShowDialog();
        }
        #endregion

        #region Member
        private string m_str_path = "";
        #endregion

        private void f701_v_gd_hop_dong_lao_dong_View_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(m_str_path);
        }
    }
}

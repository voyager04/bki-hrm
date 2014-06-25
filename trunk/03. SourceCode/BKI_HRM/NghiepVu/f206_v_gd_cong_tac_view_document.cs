using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BKI_HRM
{
    public partial class f206_v_gd_cong_tac_view_document : Form
    {
        public f206_v_gd_cong_tac_view_document()
        {
            InitializeComponent();

        }
        private string m_str_link;
        public void display(string str_link)
        {
            m_str_link = str_link;
            this.Show();
        }

        private void f206_v_gd_cong_tac_view_document_Load(object sender, EventArgs e)
        {
            m_wb_xem_file.Navigate(ConfigurationSettings.AppSettings["DESTINATION_NAME"] + m_str_link);
            return;
        }
    }
}

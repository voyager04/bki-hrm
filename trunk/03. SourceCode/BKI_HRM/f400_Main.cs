using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPSystemAdmin;


namespace BKI_HRM
{
    public partial class f400_Main : Form
    {
        public f400_Main()
        {
            InitializeComponent();
            format_controls();
        }

        #region Public Interface
        #endregion

        #region Private Method
        private void format_controls() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            this.ShowInTaskbar = true;
        }
        #endregion 


        // Event handlers

        public void display(ref IP.Core.IPCommon.IPConstants.HowUserWantTo_Exit_MainForm v_exitmode)

        {
            try {
                this.ShowDialog();
            }
            catch (Exception v_e) {
                
                CSystemLog_301.ExceptionHandle(v_e);
            }
            
        }
        private void quáTrìnhLàmViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                f200_V_GD_QUA_TRINH_LAM_VIEC frm = new f200_V_GD_QUA_TRINH_LAM_VIEC();
                frm.Show();
            }
            catch (Exception v_e) {
                
                CSystemLog_301.ExceptionHandle(v_e);
            }
            
        }

        private void trạngTháiLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                f100_V_GD_TRANG_THAI_LAO_DONG frm = new f100_V_GD_TRANG_THAI_LAO_DONG();
                frm.Show();
            }
            catch (Exception v_e) {
                
                CSystemLog_301.ExceptionHandle(v_e);
            }
           
        }

        private void hợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                f300_V_GD_HOP_DONG_LAO_DONG frm = new f300_V_GD_HOP_DONG_LAO_DONG();
                frm.Show();
            }
            catch (Exception v_e) {
                
                CSystemLog_301.ExceptionHandle(v_e);
            }
            
        }

        
    }
}

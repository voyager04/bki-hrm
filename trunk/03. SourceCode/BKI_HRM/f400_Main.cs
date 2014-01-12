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
            //CControlFormat.setFormStyle(this, new CAppContext_201());
            set_define_events();
            this.ShowInTaskbar = true;
        }
        #endregion 

        private void set_define_events() {
            this.m_mnu_tu_dien_he_thong.Click += new EventHandler(m_mnu_tu_dien_he_thong_Click);
            this.m_mnu_quan_ly_nguoi_su_dung.Click += new EventHandler(m_mnu_quan_ly_nguoi_su_dung_Click);
        }

        void m_mnu_quan_ly_nguoi_su_dung_Click(object sender, EventArgs e) {
            try {
                
            }
            catch (Exception v_e) {
                
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_mnu_tu_dien_he_thong_Click(object sender, EventArgs e) {
            try {
                IP.Core.IPSystemAdmin.f100_TuDien v_f100_td = new f100_TuDien();
                v_f100_td.ShowDialog();
            }
            catch (Exception v_e) {
                
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
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

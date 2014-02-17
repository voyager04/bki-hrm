using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPSystemAdmin;


namespace BKI_HRM {
    public partial class f400_Main : Form {
        public f400_Main() {
            InitializeComponent();
            format_controls();
        }

        #region Public Interface

        public void display(ref IP.Core.IPCommon.IPConstants.HowUserWantTo_Exit_MainForm v_exitmode) {
            try {
                this.ShowDialog();
            } catch (Exception v_e) {

                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        #endregion

        #region Private Method

        private void format_controls() {
            //CControlFormat.setFormStyle(this, new CAppContext_201());
            set_define_events();
            this.ShowInTaskbar = true;
        }

        #endregion

        private void set_define_events() {
            this.m_menuitem_tudien.Click += new EventHandler(m_mnu_tu_dien_he_thong_Click);
            this.m_menuitem_user.Click += new EventHandler(m_mnu_quan_ly_nguoi_su_dung_Click);
            this.m_menuitem_thoat.Click += new EventHandler(m_menuitem_thoat_Click);
            this.m_menuitem_qldonvi.Click += new EventHandler(m_menuitem_qldonvi_Click);
        }

        private void m_mnu_quan_ly_nguoi_su_dung_Click(object sender, EventArgs e) {
            try {

            } catch (Exception v_e) {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_mnu_tu_dien_he_thong_Click(object sender, EventArgs e) {
            try {
                IP.Core.IPSystemAdmin.f100_TuDien v_f100_td = new f100_TuDien();
                v_f100_td.ShowDialog();
            } catch (Exception v_e) {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        // Event handlers

        private void m_menuitem_thoat_Click(object sender, EventArgs e) {
            try {
                Application.Exit();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_user_Click(object sender, EventArgs e) {
            try {
                f999_ht_nguoi_su_dung frm = new f999_ht_nguoi_su_dung();
                frm.Show();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qlchucvu_Click(object sender, EventArgs e) {
            try {
                f401_V_DM_CHUC_VU frm = new f401_V_DM_CHUC_VU();
                frm.Show();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        private void m_menuitem_qldonvi_Click(object sender, EventArgs e) {
            try {
                f101_v_dm_don_vi frm = new f101_v_dm_don_vi();
                frm.Show();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

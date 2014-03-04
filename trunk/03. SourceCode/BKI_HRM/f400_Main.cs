using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using IP.Core.IPCommon;
using IP.Core.IPExcelReport;
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

        // Event handlers

        private void set_define_events() {
            this.m_menuitem_tudien.Click += new EventHandler(m_mnu_tu_dien_he_thong_Click);
            this.m_menuitem_user.Click += new EventHandler(m_mnu_quan_ly_nguoi_su_dung_Click);
            this.m_menuitem_thoat.Click += new EventHandler(m_menuitem_thoat_Click);
            this.m_menuitem_qldonvi.Click += new EventHandler(m_menuitem_qldonvi_Click);
            this.m_menu_dsnhansu.Click += new EventHandler(m_menu_dsnhansu_Click);
            this.m_menuitem_bcnhansu.Click += new EventHandler(m_menuitem_bcnhansu_Click);
            m_menuitem_nhan_su_theo_phong_ban.Click += new System.EventHandler(m_menuitem_nhan_su_theo_phong_ban_Click);
        }

        private void m_menu_dsnhansu_Click(object sender, EventArgs e) {
            try {
                f201_dm_nhan_su frm = new f201_dm_nhan_su();
                frm.display();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
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

        private void m_meuitem_ttduan_Click(object sender, EventArgs e) {
            try {
                F500_DM_DU_AN frm = new F500_DM_DU_AN();
                frm.Show();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_bcnhansu_Click(object sender, EventArgs e) {
            try {
                f103_bao_cao_tra_cuu_nhan_su frm = new f103_bao_cao_tra_cuu_nhan_su();
                frm.Show();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qlquyetdinh_Click(object sender, EventArgs e) {
            try {
                F600_V_DM_QUYET_DINH frm = new F600_V_DM_QUYET_DINH();
                frm.Show();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_trangthailaodong_Click(object sender, EventArgs e) {
            try {
                f203_V_GD_TRANG_THAI_LAO_DONG frm = new f203_V_GD_TRANG_THAI_LAO_DONG();
                frm.display();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_nhan_su_theo_phong_ban_Click(object sender, EventArgs e) {
            try {
                f104_bao_cao_nhan_su_theo_phong_ban frm = new f104_bao_cao_nhan_su_theo_phong_ban();
                frm.Show();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_hopdong_Click(object sender, EventArgs e)
        {
            try
            {
                F701_V_GD_HOP_DONG_LAO_DONG frm = new F701_V_GD_HOP_DONG_LAO_DONG();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_quatrinhlamviec_Click(object sender, EventArgs e)
        {
            try
            {
                f202_V_GD_QUA_TRINH_LAM_VIEC frm = new f202_V_GD_QUA_TRINH_LAM_VIEC();
                frm.display();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void nhânSựTheoChứcVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f402_BAO_CAO_NHAN_SU_CHUC_VU frm = new f402_BAO_CAO_NHAN_SU_CHUC_VU();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_meuitem_nhansuduan_Click(object sender, EventArgs e)
        {
            try
            {
                f501_v_dm_nhan_su_du_an frm = new f501_v_dm_nhan_su_du_an();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

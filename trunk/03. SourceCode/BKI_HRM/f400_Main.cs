using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using BKI_HRM;
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPExcelReport;
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

        public void display(ref IP.Core.IPCommon.IPConstants.HowUserWantTo_Exit_MainForm v_exitmode)
        {
            try
            {
                this.ShowDialog();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        #endregion

        #region Private Method

        private void format_controls()
        {
            //CControlFormat.setFormStyle(this, new CAppContext_201());
            set_define_events();
            this.ShowInTaskbar = true;
        }

        #endregion

        // Event handlers

        private void set_define_events()
        {
            this.m_menuitem_tudien.Click += new EventHandler(m_mnu_tu_dien_he_thong_Click);
            this.m_menuitem_user.Click += new EventHandler(m_mnu_quan_ly_nguoi_su_dung_Click);
            this.m_menuitem_thoat.Click += new EventHandler(m_menuitem_thoat_Click);
            this.m_menuitem_qldonvi.Click += new EventHandler(m_menuitem_qldonvi_Click);
            this.m_menu_dsnhansu.Click += new EventHandler(m_menu_dsnhansu_Click);
            this.m_menuitem_traCuuNhanSuChung.Click += new EventHandler(m_menuitem_traCuuNhanSuChung_Click);
            m_menuitem_nhan_su_theo_phong_ban.Click += new System.EventHandler(m_menuitem_nhan_su_theo_phong_ban_Click);
        }

        private void m_menu_dsnhansu_Click(object sender, EventArgs e)
        {
            try
            {
                f201_dm_nhan_su frm = new f201_dm_nhan_su();
                frm.display();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_mnu_quan_ly_nguoi_su_dung_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_mnu_tu_dien_he_thong_Click(object sender, EventArgs e)
        {
            try
            {
                IP.Core.IPSystemAdmin.f100_TuDien v_f100_td = new f100_TuDien();
                v_f100_td.ShowDialog();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_thoat_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_user_Click(object sender, EventArgs e)
        {
            try
            {
                f999_ht_nguoi_su_dung frm = new f999_ht_nguoi_su_dung();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qlchucvu_Click(object sender, EventArgs e)
        {
            try
            {
                f401_V_DM_CHUC_VU frm = new f401_V_DM_CHUC_VU();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        private void m_menuitem_qldonvi_Click(object sender, EventArgs e)
        {
            try
            {
                f101_v_dm_don_vi frm = new f101_v_dm_don_vi();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_meuitem_ttduan_Click(object sender, EventArgs e)
        {
            try
            {
                F500_DM_DU_AN frm = new F500_DM_DU_AN();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_bcnhansu_Click(object sender, EventArgs e)
        {
            try
            {
                f103_bao_cao_tra_cuu_nhan_su frm = new f103_bao_cao_tra_cuu_nhan_su();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qlquyetdinh_Click(object sender, EventArgs e)
        {
            try
            {
                F600_V_DM_QUYET_DINH frm = new F600_V_DM_QUYET_DINH();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_trangthailaodong_Click(object sender, EventArgs e)
        {
            try
            {
                f203_v_gd_trang_thai_lao_dong frm = new f203_v_gd_trang_thai_lao_dong();
                frm.display();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_nhan_su_theo_phong_ban_Click(object sender, EventArgs e)
        {
            try
            {
                f104_bao_cao_nhan_su_theo_phong_ban frm = new f104_bao_cao_nhan_su_theo_phong_ban();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_hopdong_Click(object sender, EventArgs e)
        {
            try
            {
                f701_v_hop_dong_lao_dong frm = new f701_v_hop_dong_lao_dong();
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

        private void m_menuitem_bcduan_Click(object sender, EventArgs e)
        {
            try
            {
                f502_bao_cao_du_an frm = new f502_bao_cao_du_an();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_traCuuNhanSuChung_Click(object sender, EventArgs e)
        {
            try
            {
                f103_bao_cao_tra_cuu_nhan_su frm = new f103_bao_cao_tra_cuu_nhan_su();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }


        private void f400_Main_Load(object sender, EventArgs e)
        {
            try
            {
                US.US_DM_DU_AN v_us = new US.US_DM_DU_AN();
                DS.DS_DM_DU_AN v_ds = new DS.DS_DM_DU_AN();
                v_us.FillDatasetSapKetThuc(v_ds, DateTime.Now.Date);
                if (v_ds.Tables[0].Rows.Count > 0)
                {
                    m_lbl_du_an_sap_kt.Text = "Có " + v_ds.Tables[0].Rows.Count.ToString() + " dự án sắp kết thúc!";
                    m_lbl_du_an_sap_kt.Visible = true;
                }
                else
                {
                    m_lbl_du_an_sap_kt.Visible = false;
                }

                US.US_V_GD_HOP_DONG_LAO_DONG v_us_v_gd_hop_dong = new US.US_V_GD_HOP_DONG_LAO_DONG();
                DS.DS_V_GD_HOP_DONG_LAO_DONG v_ds_v_gd_hop_dong = new DS.DS_V_GD_HOP_DONG_LAO_DONG();
                v_us_v_gd_hop_dong.FIllDataset_By_Hop_Dong_Sap_Het_Han(v_ds_v_gd_hop_dong);
                if (v_ds_v_gd_hop_dong.Tables[0].Rows.Count > 0)
                {
                    m_lbl_thong_bao_hop_dong_sap_het_han.Text = string.Format("Có {0} hợp đồng sắp hết hạn. Click để xem chi tiết!", v_ds_v_gd_hop_dong.Tables[0].Rows.Count);
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_du_an_sap_kt_Click(object sender, EventArgs e)
        {
            try
            {
                F500_DM_DU_AN frm = new F500_DM_DU_AN();
                frm.DisplaySapKetThuc();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void báoCáoHợpĐồngĐãHếtHạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f702_bao_cao_hdld_het_han frm = new f702_bao_cao_hdld_het_han();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_thong_bao_hop_dong_sap_het_han_Click(object sender, EventArgs e)
        {
            try
            {
                f701_v_hop_dong_lao_dong frm = new f701_v_hop_dong_lao_dong();
                frm.Display_Hop_Dong_Sap_Het_Han();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }


    }
}

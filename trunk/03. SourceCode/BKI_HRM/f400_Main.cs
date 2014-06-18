using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using BKI_HRM;
using BKI_HRM.DS;
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPExcelReport;
using IP.Core.IPSystemAdmin;
using BKI_HRM.HeThong;
using System.Diagnostics;

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

        public void display(ref IPConstants.HowUserWantTo_Exit_MainForm v_exitmode)
        {
            try
            {
                ShowDialog();
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
            ShowInTaskbar = true;

            nhan_vien_hien_tai();
        }
        private void nhan_vien_hien_tai()
        {
            US_V_DM_DU_LIEU_NHAN_VIEN v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            DS_V_DM_DU_LIEU_NHAN_VIEN v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            decimal v_dc_so_luong_nv_hien_tai = 0;
            v_us.count_nhan_vien(v_ds, "hiện tại", ref v_dc_so_luong_nv_hien_tai);

            m_lbl_so_luong_nv_hien_tai.Text = "Số lượng nhân viên hiện tại: " + v_dc_so_luong_nv_hien_tai;
        }
        private void thu_viec_sap_het_han()
        {
            US_V_DM_DU_LIEU_NHAN_VIEN v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            DS_V_DM_DU_LIEU_NHAN_VIEN v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            decimal v_dc_so_luong_nv = 0;
            //  f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
            v_us.count_nhan_vien(v_ds, "thử việc hết hạn", ref v_dc_so_luong_nv);
            if (v_dc_so_luong_nv <= 0)
            {
                m_lbl_thu_viec_sap_het_han.Text = @"Không có Thử việc sắp hết hạn";
            }
            else
            {
                m_lbl_thu_viec_sap_het_han.Text = @"Có " + v_dc_so_luong_nv.ToString() +
                                                  " Thử việc sắp hết hạn. Click để xem chi tiết!";
            }
            // v_frm.display_thu_viec_sap_het_han();
        }

        private void nghi_viec_sap_quay_lai()
        {
            US_V_DM_DU_LIEU_NHAN_VIEN v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            DS_V_DM_DU_LIEU_NHAN_VIEN v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            //f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
            decimal v_dc_so_luong_nv = 0;
            v_us.count_nhan_vien(v_ds, "nghỉ việc quay lại", ref v_dc_so_luong_nv);
            if (v_dc_so_luong_nv <= 0)
            {
                m_lbl_sap_quay_lai.Text = @"Không có Nghỉ việc sắp quay lại";
            }
            else
            {
                m_lbl_sap_quay_lai.Text = @"Có " + v_dc_so_luong_nv.ToString() +
                                                  " Nghỉ việc sắp quay lại. Click để xem chi tiết!";
            }
            //v_frm.display_nghi_sap_quay_lai();
        }

        private void canh_bao_hop_dong()
        {
            f702_bao_cao_hdld frm = new f702_bao_cao_hdld();
            m_lbl_thong_bao_hop_dong_sap_het_han.Text =
                string.Format("Có {0} hợp đồng sắp hết hạn. Click để xem chi tiết!", frm.count_record_bao_cao_sap_het_han());
            m_lbl_thong_bao_hdld_da_het_han_nhung_chua_ky.Text =
                string.Format("Có {0} hợp đồng đã quá hạn và chưa ký mới. Click để xem chi tiết!",
                              frm.count_record_bao_cao_het_han_nhung_chua_ky_moi());
        }
        #endregion

        #region Members

        private DataEntryFormMode m_e_form_mode;
        decimal hien_tai;
        DS_V_GD_TRANG_THAI_LAO_DONG m_ds_trang_thai_lao_dong = new DS_V_GD_TRANG_THAI_LAO_DONG();
        US_V_GD_TRANG_THAI_LAO_DONG m_us_trang_thai_lao_dong = new US_V_GD_TRANG_THAI_LAO_DONG();

        #endregion

        #region Events
        private void set_define_events()
        {
            m_menuitem_tudien.Click += m_mnu_tu_dien_he_thong_Click;
            m_menuitem_user.Click += m_mnu_quan_ly_nguoi_su_dung_Click;
            m_menuitem_thoat.Click += m_menuitem_thoat_Click;
            m_menuitem_qldonvi.Click += m_menuitem_qldonvi_Click;
            m_menu_dsnhansu.Click += m_menu_dsnhansu_Click;
            m_menuitem_traCuuNhanSuChung.Click += m_menuitem_traCuuNhanSuChung_Click;
            m_menuitem_nhan_su_theo_phong_ban.Click += m_menuitem_nhan_su_theo_phong_ban_Click;
            m_menuitem_chi_tiet_cap_bac.Click += m_menuitem_chi_tiet_cap_bac_Click;
            m_menuitem_qldonvi.Click += m_menuitem_quan_ly_don_vi_Click;
            m_lbl_thu_viec_sap_het_han.Click += m_lbl_thu_viec_sap_het_han_Click;
            m_menuitem_chuyen_nhan_vien.Click += m_menuitem_chuyen_nhan_vien_Click;
            m_menuitem_chuyen_don_vi.Click += m_menuitem_chuyen_don_vi_Click;
        }

        private void m_menu_dsnhansu_Click(object sender, EventArgs e)
        {
            try
            {
                f201_dm_nhan_su frm = new f201_dm_nhan_su();
                frm.display();
                nhan_vien_hien_tai();
                thu_viec_sap_het_han();
                nghi_viec_sap_quay_lai();
                canh_bao_hop_dong();
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
                f100_TuDien v_f100_td = new f100_TuDien();
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
                frm.ShowDialog();
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc. Click để xem chi tiết!",
                                                        frm502.count_record_du_an_sap_ket_thuc());
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
                //f601_v_dm_quyet_dinh frm = new f601_v_dm_quyet_dinh();
                f600_v_dm_quyet_dinh frm = new f600_v_dm_quyet_dinh();
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
                nhan_vien_hien_tai();
                thu_viec_sap_het_han();
                nghi_viec_sap_quay_lai();
                canh_bao_hop_dong();
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
                frm.ShowDialog();
                f702_bao_cao_hdld frm2 = new f702_bao_cao_hdld();
                m_lbl_thong_bao_hop_dong_sap_het_han.Text =
                    string.Format("Có {0} hợp đồng sắp hết hạn. Click để xem chi tiết!", frm2.count_record_bao_cao_sap_het_han());
                m_lbl_thong_bao_hdld_da_het_han_nhung_chua_ky.Text =
                    string.Format("Có {0} hợp đồng đã quá hạn và chưa ký mới. Click để xem chi tiết!",
                                  frm2.count_record_bao_cao_het_han_nhung_chua_ky_moi());
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
                nhan_vien_hien_tai();
                thu_viec_sap_het_han();
                nghi_viec_sap_quay_lai();
                canh_bao_hop_dong();
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

        private void m_menuitem_traCuuNhanSuChung_Click(object sender, EventArgs e)
        {
            try
            {
                f103_bao_cao_tra_cuu_nhan_su frm = new f103_bao_cao_tra_cuu_nhan_su();
                frm.display();
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

                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc. Click để xem chi tiết!",
                                                        frm502.count_record_du_an_sap_ket_thuc());

                canh_bao_hop_dong();

                thu_viec_sap_het_han();
                nghi_viec_sap_quay_lai();

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
                frm.Show();
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc. Click để xem chi tiết!",
                                                        frm502.count_record_du_an_sap_ket_thuc());
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
                f702_bao_cao_hdld frm = new f702_bao_cao_hdld();
                frm.set_form_mode_for_report(1);
                frm.ShowDialog();
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
                f702_bao_cao_hdld frm = new f702_bao_cao_hdld();
                frm.set_form_mode_for_report(2);
                frm.ShowDialog();
                m_lbl_thong_bao_hop_dong_sap_het_han.Text =
                    string.Format("Có {0} hợp đồng sắp hết hạn. Click để xem chi tiết!", frm.count_record_bao_cao_sap_het_han());
                m_lbl_thong_bao_hdld_da_het_han_nhung_chua_ky.Text =
                    string.Format("Có {0} hợp đồng đã quá hạn và chưa ký mới. Click để xem chi tiết!",
                                  frm.count_record_bao_cao_het_han_nhung_chua_ky_moi());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_usergroup_Click(object sender, EventArgs e)
        {
            try
            {
                f997_ht_nhom_nguoi_su_dung frm = new f997_ht_nhom_nguoi_su_dung();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_bc_duan_Click(object sender, EventArgs e)
        {
            try
            {
                f502_bao_cao_du_an frm = new f502_bao_cao_du_an();
                frm.Show();
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc. Click để xem chi tiết!",
                                                        frm502.count_record_du_an_sap_ket_thuc());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_tra_cuu_ns_du_an_Click(object sender, EventArgs e)
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

        private void m_menuitem_qllevel_Click(object sender, EventArgs e)
        {
            try
            {
                F602_v_dm_trang_thai_ung_vien frm = new F602_v_dm_trang_thai_ung_vien();
                frm.Show();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_chi_tiet_cap_bac_Click(object sender, EventArgs e)
        {
            try
            {
                f105_v_gd_chi_tiet_cap_bac frm = new f105_v_gd_chi_tiet_cap_bac();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qlphapnhan_Click(object sender, EventArgs e)
        {
            try
            {
                f703_dm_phap_nhan frm = new f703_dm_phap_nhan();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void nhânSựTheoCấpBậcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f403_BAO_CAO_NHAN_SU_CAP_BAC frm = new f403_BAO_CAO_NHAN_SU_CAP_BAC();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_het_han_thu_viec_Click(object sender, EventArgs e)
        {

        }

        private void quáTrìnhLàmViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f404_GD_QUA_TRINH_CONG_TAC frm = new f404_GD_QUA_TRINH_CONG_TAC();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qlbac_Click(object sender, EventArgs e)
        {
            try
            {
                F604_v_dm_cap_bac frm = new F604_v_dm_cap_bac();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_thong_bao_hdld_da_het_han_nhung_chua_ky_Click(object sender, EventArgs e)
        {
            try
            {
                f702_bao_cao_hdld frm = new f702_bao_cao_hdld();
                frm.set_form_mode_for_report(3);
                frm.ShowDialog();
                m_lbl_thong_bao_hop_dong_sap_het_han.Text =
                    string.Format("Có {0} hợp đồng sắp hết hạn. Click để xem chi tiết!", frm.count_record_bao_cao_sap_het_han());
                m_lbl_thong_bao_hdld_da_het_han_nhung_chua_ky.Text =
                    string.Format("Có {0} hợp đồng đã quá hạn và chưa ký mới. Click để xem chi tiết!",
                                  frm.count_record_bao_cao_het_han_nhung_chua_ky_moi());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_phan_quyen_cho_nhom_Click(object sender, EventArgs e)
        {
            try
            {
                f995_ht_phan_quyen_cho_nhom frm = new f995_ht_phan_quyen_cho_nhom();
                frm.ShowDialog();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_phan_quyen_chi_tiet_Click(object sender, EventArgs e)
        {
            try
            {
                f994_phan_quyen_detail frm = new f994_phan_quyen_detail();
                frm.ShowDialog();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_phan_quyen_he_thong_Click(object sender, EventArgs e)
        {
            try
            {
                f993_phan_quyen_he_thong frm = new f993_phan_quyen_he_thong();
                frm.ShowDialog();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_dm_control_Click(object sender, EventArgs e)
        {
            try
            {
                f991_v_ht_control_in_form frm = new f991_v_ht_control_in_form();
                frm.ShowDialog();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_thu_viec_sap_het_han_Click(object sender, EventArgs e)
        {
            try
            {
                f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
                v_frm.display_thu_viec_sap_het_han();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_headcount_Click(object sender, EventArgs e)
        {
            try
            {
                f204_dm_headcount frm = new f204_dm_headcount();
                frm.display();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void chToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f405_bao_cao_chuc_vu_trang_thai frm = new f405_bao_cao_chuc_vu_trang_thai();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_quan_ly_don_vi_Click(object sender, EventArgs e)
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

        private void m_menuitem_chuyen_nhan_vien_Click(object sender, EventArgs e)
        {
            try
            {
                f107_chuyen_nhan_vien frm = new f107_chuyen_nhan_vien();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_chuyen_don_vi_Click(object sender, EventArgs e)
        {
            try
            {
                f108_chuyen_don_vi frm = new f108_chuyen_don_vi();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_sap_quay_lai_Click(object sender, EventArgs e)
        {
            try
            {
                f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
                v_frm.display_nghi_sap_quay_lai();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_gui_loi_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("http://goo.gl/swobCf");
                Process.Start(sInfo);
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_hdsd_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("http://goo.gl/DFhioS");
                Process.Start(sInfo);
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_chitietquyetdinh_Click(object sender, EventArgs e)
        {
            try
            {
                F205_V_GD_QUYET_DINH frm = new F205_V_GD_QUYET_DINH();
                frm.display();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void báoCáoBổNhiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f406_bao_cao_bo_nhiem frm = new f406_bao_cao_bo_nhiem();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void báoCáoDanhSáchBổNhiêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f407_bao_cao_bo_nhiem frm = new f407_bao_cao_bo_nhiem();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void biếnĐộngĐơnVịTrạngTháiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f408_bao_cao_don_vi_trang_thai frm = new f408_bao_cao_don_vi_trang_thai();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void báoCáoNghỉViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f409_bao_cao_nghi_viec frm = new f409_bao_cao_nghi_viec();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_so_luong_nv_hien_tai_Click(object sender, EventArgs e)
        {
            try
            {
                f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
                v_frm.display();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qua_trinh_di_cong_tac_Click(object sender, EventArgs e)
        {
            try
            {
                f206_v_gd_cong_tac v_frm = new f206_v_gd_cong_tac();
                v_frm.display();

            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        #endregion

        private void m_menuitem_thoat_Click_1(object sender, EventArgs e)
        {
            
        }

        private void restoreDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void saoLưuDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CDataBaseProccessing.BackupDataBase();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void phụcHồiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CDataBaseProccessing.RestoreDataBase();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

    }
}

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

namespace BKI_HRM {
    public partial class f400_Main : Form{
        public f400_Main(){
            InitializeComponent();
            format_controls();
        }

        #region Public Interface

        public void display(ref IPConstants.HowUserWantTo_Exit_MainForm v_exitmode){
            try{
                ShowDialog();
            }
            catch (Exception v_e){

                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        #endregion

        #region Private Method

        private void format_controls(){
            //CControlFormat.setFormStyle(this, new CAppContext_201());
            set_define_events();
            ShowInTaskbar = true;
        }

        private f103_bao_cao_tra_cuu_nhan_su thong_bao_thu_viec_sap_het_han(){
            var frm = new f103_bao_cao_tra_cuu_nhan_su();
            var v_count = frm.SapHetHanThuViec(DataEntryFormMode.ViewDataState);
            if (v_count <= 0){
                m_lbl_thu_viec_sap_het_han.Text = @"Không có Thử việc sắp hết hạn";
            }
            else{
                m_lbl_thu_viec_sap_het_han.Text = @"Có " + v_count.ToString() +
                                                  " Thử việc sắp hết hạn. Click để xem chi tiết!";
            }
            return frm;
        }

        #endregion

        #region Members

        private DataEntryFormMode m_e_form_mode;

        #endregion

        // Event handlers

        private void set_define_events(){
            m_menuitem_tudien.Click += m_mnu_tu_dien_he_thong_Click;
            m_menuitem_user.Click += m_mnu_quan_ly_nguoi_su_dung_Click;
            m_menuitem_thoat.Click += m_menuitem_thoat_Click;
            m_menuitem_qldonvi.Click += m_menuitem_qldonvi_Click;
            m_menu_dsnhansu.Click += m_menu_dsnhansu_Click;
            m_menuitem_traCuuNhanSuChung.Click += m_menuitem_traCuuNhanSuChung_Click;
            m_menuitem_nhan_su_theo_phong_ban.Click += m_menuitem_nhan_su_theo_phong_ban_Click;
            m_menuitem_chiTietCapBac.Click += m_menuitem_chiTietCapBac_Click;
            m_menuitem_qldonvi.Click += m_menuitem_quan_ly_don_vi_Click;
            m_lbl_thu_viec_sap_het_han.Click += m_lbl_thu_viec_sap_het_han_Click;
        }

        private void m_menu_dsnhansu_Click(object sender, EventArgs e){
            try{
                f201_dm_nhan_su frm = new f201_dm_nhan_su();
                frm.display();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_mnu_quan_ly_nguoi_su_dung_Click(object sender, EventArgs e){
            try{

            }
            catch (Exception v_e){

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_mnu_tu_dien_he_thong_Click(object sender, EventArgs e){
            try{
                f100_TuDien v_f100_td = new f100_TuDien();
                v_f100_td.ShowDialog();
            }
            catch (Exception v_e){

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_thoat_Click(object sender, EventArgs e){
            try{
                Application.Exit();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_user_Click(object sender, EventArgs e){
            try{
                f999_ht_nguoi_su_dung frm = new f999_ht_nguoi_su_dung();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qlchucvu_Click(object sender, EventArgs e){
            try{
                f401_V_DM_CHUC_VU frm = new f401_V_DM_CHUC_VU();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        private void m_menuitem_qldonvi_Click(object sender, EventArgs e){
            try{
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_meuitem_ttduan_Click(object sender, EventArgs e){
            try{
                F500_DM_DU_AN frm = new F500_DM_DU_AN();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qlquyetdinh_Click(object sender, EventArgs e){
            try{
                //f601_v_dm_quyet_dinh frm = new f601_v_dm_quyet_dinh();
                f600_v_dm_quyet_dinh frm = new f600_v_dm_quyet_dinh();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_trangthailaodong_Click(object sender, EventArgs e){
            try{
                f203_v_gd_trang_thai_lao_dong frm = new f203_v_gd_trang_thai_lao_dong();
                frm.display();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_nhan_su_theo_phong_ban_Click(object sender, EventArgs e){
            try{
                f104_bao_cao_nhan_su_theo_phong_ban frm = new f104_bao_cao_nhan_su_theo_phong_ban();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_hopdong_Click(object sender, EventArgs e){
            try{
                f701_v_hop_dong_lao_dong frm = new f701_v_hop_dong_lao_dong();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_quatrinhlamviec_Click(object sender, EventArgs e){
            try{
                f202_V_GD_QUA_TRINH_LAM_VIEC frm = new f202_V_GD_QUA_TRINH_LAM_VIEC();
                frm.display();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void nhânSựTheoChứcVuToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                f402_BAO_CAO_NHAN_SU_CHUC_VU frm = new f402_BAO_CAO_NHAN_SU_CHUC_VU();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_traCuuNhanSuChung_Click(object sender, EventArgs e){
            try{
                f103_bao_cao_tra_cuu_nhan_su frm = new f103_bao_cao_tra_cuu_nhan_su();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void f400_Main_Load(object sender, EventArgs e){
            try{
                US_DM_DU_AN v_us = new US_DM_DU_AN();
                DS_DM_DU_AN v_ds = new DS_DM_DU_AN();
                v_us.FillDatasetSapKetThuc(v_ds, DateTime.Now.Date);
                if (v_ds.Tables[0].Rows.Count > 0){
                    m_lbl_du_an_sap_kt.Text = "Có " + v_ds.Tables[0].Rows.Count.ToString() +
                                              " dự án sắp kết thúc. Click để xem chi tiết!";
                    m_lbl_du_an_sap_kt.Visible = true;
                }
                else{
                    m_lbl_du_an_sap_kt.Visible = false;
                }

                US_V_GD_HOP_DONG_LAO_DONG v_us_v_gd_hop_dong = new US_V_GD_HOP_DONG_LAO_DONG();
                DS_V_GD_HOP_DONG_LAO_DONG v_ds_v_gd_hop_dong_sap_het_han = new DS_V_GD_HOP_DONG_LAO_DONG();
                v_us_v_gd_hop_dong.FIllDataset_By_Hop_Dong_Sap_Het_Han(v_ds_v_gd_hop_dong_sap_het_han, "");
                if (v_ds_v_gd_hop_dong_sap_het_han.Tables[0].Rows.Count > 0){
                    m_lbl_thong_bao_hop_dong_sap_het_han.Text =
                        string.Format("Có {0} hợp đồng sắp hết hạn. Click để xem chi tiết!",
                            v_ds_v_gd_hop_dong_sap_het_han.Tables[0].Rows.Count);
                }

                DS_V_GD_HOP_DONG_LAO_DONG v_ds_v_gd_hop_dong_da_het_han = new DS_V_GD_HOP_DONG_LAO_DONG();
                v_us_v_gd_hop_dong.FillDataSet_Search_HDLD_da_het_han_nhung_chua_ky(v_ds_v_gd_hop_dong_da_het_han, "");
                if (v_ds_v_gd_hop_dong_da_het_han.Tables[0].Rows.Count > 0){
                    m_lbl_thong_bao_hdld_da_het_han_nhung_chua_ky.Text =
                        string.Format("Có {0} hợp đồng đã quá hạn và chưa ký mới. Click để xem chi tiết!",
                            v_ds_v_gd_hop_dong_da_het_han.Tables[0].Rows.Count);
                }
                thong_bao_thu_viec_sap_het_han();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_du_an_sap_kt_Click(object sender, EventArgs e){
            try{
                F500_DM_DU_AN frm = new F500_DM_DU_AN();
                frm.DisplaySapKetThuc();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void báoCáoHợpĐồngĐãHếtHạnToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                f702_bao_cao_hdld frm = new f702_bao_cao_hdld();
                frm.set_form_mode_for_report(1);
                frm.ShowDialog();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_thong_bao_hop_dong_sap_het_han_Click(object sender, EventArgs e){
            try{
                f702_bao_cao_hdld frm = new f702_bao_cao_hdld();
                frm.set_form_mode_for_report(2);
                frm.ShowDialog();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_usergroup_Click(object sender, EventArgs e){
            try{
                f997_ht_nhom_nguoi_su_dung frm = new f997_ht_nhom_nguoi_su_dung();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_bc_duan_Click(object sender, EventArgs e){
            try{
                f502_bao_cao_du_an frm = new f502_bao_cao_du_an();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_tra_cuu_ns_du_an_Click(object sender, EventArgs e){
            try{
                f501_v_dm_nhan_su_du_an frm = new f501_v_dm_nhan_su_du_an();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qllevel_Click(object sender, EventArgs e){
            try{
                F602_v_dm_trang_thai_ung_vien frm = new F602_v_dm_trang_thai_ung_vien();
                frm.Show();
            }
            catch (Exception v_e){

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_chiTietCapBac_Click(object sender, EventArgs e){
            try{
                f105_v_gd_chi_tiet_cap_bac frm = new f105_v_gd_chi_tiet_cap_bac();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qlphapnhan_Click(object sender, EventArgs e){
            try{
                f703_dm_phap_nhan frm = new f703_dm_phap_nhan();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void nhânSựTheoCấpBậcToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                f403_BAO_CAO_NHAN_SU_CAP_BAC frm = new f403_BAO_CAO_NHAN_SU_CAP_BAC();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_het_han_thu_viec_Click(object sender, EventArgs e){

        }

        private void quáTrìnhLàmViệcToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                f404_GD_QUA_TRINH_CONG_TAC frm = new f404_GD_QUA_TRINH_CONG_TAC();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_qlbac_Click(object sender, EventArgs e){
            //try
            //{
            //    F603_dm_cap_bac frm = new F603_dm_cap_bac();
            //    frm.Show();
            //}
            //catch (Exception v_e)
            //{

            //    CSystemLog_301.ExceptionHandle(v_e);
            //}
            try{
                F604_v_dm_cap_bac frm = new F604_v_dm_cap_bac();
                frm.Show();
            }
            catch (Exception v_e){

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_thong_bao_hdld_da_het_han_nhung_chua_ky_Click(object sender, EventArgs e){
            try{
                f702_bao_cao_hdld frm = new f702_bao_cao_hdld();
                frm.set_form_mode_for_report(3);
                frm.ShowDialog();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_phan_quyen_cho_nhom_Click(object sender, EventArgs e){
            try{
                f995_ht_phan_quyen_cho_nhom frm = new f995_ht_phan_quyen_cho_nhom();
                frm.ShowDialog();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_phan_quyen_chi_tiet_Click(object sender, EventArgs e){
            try{
                f994_phan_quyen_detail frm = new f994_phan_quyen_detail();
                frm.ShowDialog();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_phan_quyen_he_thong_Click(object sender, EventArgs e){
            try{
                f993_phan_quyen_he_thong frm = new f993_phan_quyen_he_thong();
                frm.ShowDialog();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_dm_control_Click(object sender, EventArgs e){
            try{
                f991_v_ht_control_in_form frm = new f991_v_ht_control_in_form();
                frm.ShowDialog();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_thu_viec_sap_het_han_Click(object sender, EventArgs e){
            try{
                var v_frm = thong_bao_thu_viec_sap_het_han();
                v_frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_headcount_Click(object sender, EventArgs e){
            try{
                f204_dm_headcount frm = new f204_dm_headcount();
                frm.display();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void chToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                f405_bao_cao_chuc_vu_trang_thai frm = new f405_bao_cao_chuc_vu_trang_thai();
                frm.Show();
            }
            catch (Exception v_e){
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_menuitem_quan_ly_don_vi_Click(object sender, EventArgs e){
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

        
    }
} 

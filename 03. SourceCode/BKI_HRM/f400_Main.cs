using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using BKI_HRM;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPExcelReport;
using IP.Core.IPSystemAdmin;
using BKI_HRM.HeThong;
using System.Diagnostics;
using BKI_HRM.HelperDucVT;

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
                v_exitmode = m_exitmode;
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }

        }
        public void refresh()
        {
            nhan_vien_hien_tai();
        }
        #endregion

        #region Private Method

        private void format_controls()
        {
            //CControlFormat.setFormStyle(this, new CAppContext_201());
            ControlFormat.setFormat_theo_phap_nhan(this);
            set_define_events();
            ShowInTaskbar = true;

            nhan_vien_hien_tai();
        }
        private void nhan_vien_hien_tai()
        {
            US_V_DM_DU_LIEU_NHAN_VIEN v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            DS_V_DM_DU_LIEU_NHAN_VIEN v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            decimal v_dc_so_luong_nv_hien_tai = 0;
            v_us.count_nhan_vien(v_ds, "hiện tại",
                CAppContext_201.getCurrentIDPhapnhan(),
                ref v_dc_so_luong_nv_hien_tai);

            toolStripStatusLabel2.Text = "Số lượng nhân viên hiện tại: " + v_dc_so_luong_nv_hien_tai;
        }
        private void thu_viec_sap_het_han()
        {
            US_V_DM_DU_LIEU_NHAN_VIEN v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            DS_V_DM_DU_LIEU_NHAN_VIEN v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            decimal v_dc_so_luong_nv = 0;
            //  f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
            v_us.count_nhan_vien(v_ds, "thử việc hết hạn"
                , CAppContext_201.getCurrentIDPhapnhan()
                , ref v_dc_so_luong_nv);
            if (v_dc_so_luong_nv <= 0)
            {
                m_lbl_thu_viec_sap_het_han.Text = @"Không có Thử việc sắp hết hạn";
            }
            else
            {
                m_lbl_thu_viec_sap_het_han.Text = @"Có " + v_dc_so_luong_nv.ToString() +
                                                  " Thử việc sắp hết hạn!";
            }
            // v_frm.display_thu_viec_sap_het_han();
        }
        private void nhan_vien_chinh_thuc()
        {
            US_V_GD_QUA_TRINH_LAM_VIEC_2 v_us = new US_V_GD_QUA_TRINH_LAM_VIEC_2();
            DS_V_GD_QUA_TRINH_LAM_VIEC_2 v_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC_2();
            decimal v_dc_so_luong_nv = 0;
            //  f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
            v_us.count_nhan_vien_chinh_thuc(v_ds,DateTime.Now
                , ref v_dc_so_luong_nv, CAppContext_201.getCurrentIDPhapnhan());
            
                m_lbl_nv_chinh_thuc.Text = @"Có " + v_dc_so_luong_nv.ToString() +
                                                  " nhân viên chính thức trên 6 tháng.";
            
            // v_frm.display_thu_viec_sap_het_han();
        }
        private void nghi_viec_sap_quay_lai()
        {
            US_V_DM_DU_LIEU_NHAN_VIEN v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            DS_V_DM_DU_LIEU_NHAN_VIEN v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            //f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
            decimal v_dc_so_luong_nv = 0;
            v_us.count_nhan_vien(v_ds, "nghỉ việc quay lại"
                , CAppContext_201.getCurrentIDPhapnhan()
                , ref v_dc_so_luong_nv);
            if (v_dc_so_luong_nv <= 0)
            {
                m_lbl_sap_quay_lai.Text = @"Không có Nghỉ sắp quay lại";
            }
            else
            {
                m_lbl_sap_quay_lai.Text = @"Có " + v_dc_so_luong_nv.ToString() +
                                                  " Nhân viên đang nghỉ!";
            }
            //v_frm.display_nghi_sap_quay_lai();
        }

        private void canh_bao_hop_dong()
        {
            f702_bao_cao_hdld frm = new f702_bao_cao_hdld();
            m_lbl_thong_bao_hop_dong_sap_het_han.Text =
                string.Format("Có {0} hợp đồng sắp hết hạn!", frm.count_record_bao_cao_sap_het_han());
            m_lbl_thong_bao_hdld_da_het_han_nhung_chua_ky.Text =
                string.Format("Có {0} hợp đồng đã quá hạn và chưa ký mới!",
                              frm.count_record_bao_cao_het_han_nhung_chua_ky_moi());
        }

        private void show_form(Form frm)
        {
            try
            {
                bool tabExist = false;
                foreach (TabPage tabPage in m_tab_form.TabPages)
                {
                    if (frm.Text.Equals(tabPage.Text))
                    {
                        m_tab_form.SelectedTab = tabPage;
                        tabExist = true;
                    }
                }

                if (!tabExist)
                {
                    frm.MdiParent = this;
                    frm.Height = m_cmd_thong_bao.Height - m_tab_form.Height + 30;
                    frm.Width = m_tab_form.Width + 10;

                    frm.Show();
                    frm.FormBorderStyle = FormBorderStyle.None;
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void load_phap_nhan_to_cbo_phap_nhan()
        {
            US_DM_PHAP_NHAN v_us_pn = new US_DM_PHAP_NHAN();
            DS_DM_PHAP_NHAN v_ds_pn = new DS_DM_PHAP_NHAN();
            v_us_pn.FillDataset(v_ds_pn);

            m_cbo_phap_nhan.DataSource = v_ds_pn.DM_PHAP_NHAN;
            m_cbo_phap_nhan.DisplayMember = DM_PHAP_NHAN.TEN_PHAP_NHAN;
            m_cbo_phap_nhan.ValueMember = DM_PHAP_NHAN.ID;

            for (int i = 0; i < v_ds_pn.DM_PHAP_NHAN.Rows.Count; i++)
            {
                if ((decimal)v_ds_pn.DM_PHAP_NHAN.Rows[i][DM_PHAP_NHAN.ID] == CAppContext_201.getCurrentIDPhapnhan())
                    m_cbo_phap_nhan.SelectedValue = CAppContext_201.getCurrentIDPhapnhan();
                    //m_clk_phap_nhan.SetItemChecked(i, true);
                //else
                    //m_clk_phap_nhan.SetItemChecked(i, false);
            }
        }

        private void auto_sugget_phap_nhan()
        {
            US_HT_FORM v_us = new US_HT_FORM();
            DS_HT_FORM v_ds = new DS_HT_FORM();
            v_us.FillDataset(v_ds);
            cbbPhapNhan.DataSource = v_ds.HT_FORM;
            cbbPhapNhan.DisplayMember = HT_FORM.DISPLAY_NAME;
            cbbPhapNhan.ValueMember = HT_FORM.ID;
            cbbPhapNhan.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        #endregion

        #region Members
        AlertForm alert;
        private int m_i_selected_tab_index = 0;
        private DataEntryFormMode m_e_form_mode;
        decimal hien_tai;
        DS_V_GD_TRANG_THAI_LAO_DONG m_ds_trang_thai_lao_dong = new DS_V_GD_TRANG_THAI_LAO_DONG();
        US_V_GD_TRANG_THAI_LAO_DONG m_us_trang_thai_lao_dong = new US_V_GD_TRANG_THAI_LAO_DONG();
        IPConstants.HowUserWantTo_Exit_MainForm m_exitmode = IPConstants.HowUserWantTo_Exit_MainForm.ExitFromSystem;
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
            //m_lbl_thu_viec_sap_het_han.Click += m_lbl_thu_viec_sap_het_han_Click;
            //   m_menuitem_chuyen_nhan_vien.Click += m_menuitem_chuyen_nhan_vien_Click;
            //   m_menuitem_chuyen_don_vi.Click += m_menuitem_chuyen_don_vi_Click;
            m_menuitem_dang_xuat.Click += m_menuitem_dang_xuat_Click;
            m_cmd_bc_luong_theo_qd.Click += new EventHandler(m_cmd_bc_luong_theo_qd_Click);
            m_cmd_import_luong_theo_qd.Click +=m_cmd_import_luong_theo_qd_Click;
        }

        private void m_cmd_import_luong_theo_qd_Click(object sender, EventArgs e) {
            try {
                show_form(new f801_import_excel_luong_theo_qd());
            }
            catch(Exception v_e) {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bc_luong_theo_qd_Click(object sender, EventArgs e) {
            try {
                show_form(new f800_BC_LUONG_THEO_QD());
            }
            catch(Exception) {
                
                throw;
            }
        }

        private void m_menuitem_dang_xuat_Click(object sender, EventArgs e)
        {
            try
            {
                m_exitmode = IPConstants.HowUserWantTo_Exit_MainForm.Login_As_DifferentUser;
                List<Form> v_list_openForms = new List<Form>();

                foreach (Form v_f in Application.OpenForms)
                    v_list_openForms.Add(v_f);

                foreach (Form v_f in v_list_openForms)
                {

                    v_f.Close();
                }

            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
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
                nhan_vien_chinh_thuc();
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
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
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
                //f203_v_gd_trang_thai_lao_dong frm = new f203_v_gd_trang_thai_lao_dong(this);
                //frm.display();
                //nhan_vien_hien_tai();
                //thu_viec_sap_het_han();
                //nghi_viec_sap_quay_lai();
                //canh_bao_hop_dong();
                //nhan_vien_chinh_thuc();
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
                f104_tra_cuu_nhan_su_theo_ma frm = new f104_tra_cuu_nhan_su_theo_ma();
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
                //f202_V_GD_QUA_TRINH_LAM_VIEC frm = new f202_V_GD_QUA_TRINH_LAM_VIEC(this);
                //frm.display();
                //nhan_vien_hien_tai();
                //thu_viec_sap_het_han();
                //nghi_viec_sap_quay_lai();
                //canh_bao_hop_dong();
                //nhan_vien_chinh_thuc();
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
                /*if (backgroundWorker1.IsBusy != true)
                {
                    // create a new instance of the alert form
                    alert = new AlertForm();
                    // event handler for the Cancel button in AlertForm
                    //alert.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
                    alert.Show();
                    alert.TopMost = true;
                    // Start the asynchronous operation.
                    backgroundWorker1.RunWorkerAsync();
                }*/
                m_pnl_thong_bao.Height = m_cmd_thong_bao.Height - m_tab_form.Height;

                load_phap_nhan_to_cbo_phap_nhan();
                //auto_sugget_phap_nhan();


                if (CAppContext_201.getCurrentIDPhapnhan() == 3)
                {
                    m_menuitem_hopdong.Visible = false;
                    m_menuitem_bao_cao_hop_dong.Visible = false;
                }
                if (CAppContext_201.getCurrentIDPhapnhan() != -1)
                {
                    US_DM_PHAP_NHAN v_us = new US_DM_PHAP_NHAN(CAppContext_201.getCurrentIDPhapnhan());
                    toolStripStatusLabel1.Text = "Pháp nhân: " + v_us.strMA_PHAP_NHAN + " - " + v_us.strTEN_PHAP_NHAN;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Tất cả";
                }
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                                                        frm502.count_record_du_an_sap_ket_thuc());
                m_tab_menu.SelectedTab = tabPage3;
                canh_bao_hop_dong();
                thu_viec_sap_het_han();
                nghi_viec_sap_quay_lai();
                nhan_vien_chinh_thuc();
                show_form(new f408_bao_cao_don_vi_trang_thai());
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
                ProcessStartInfo sInfo = new ProcessStartInfo("http://1drv.ms/XzwLat");
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

        private void restoreDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f400_dialog frm = new f400_dialog();
                frm.Show();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private bool statusPanel = true;

        private void m_cmd_thong_bao_Click(object sender, EventArgs e)
        {
            try
            {
                if (statusPanel)
                {
                    statusPanel = false;
                    m_pnl_thong_bao.Visible = true;
                }
                else
                {
                    statusPanel = true;
                    m_pnl_thong_bao.Visible = false;
                }
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                                                        frm502.count_record_du_an_sap_ket_thuc());

                canh_bao_hop_dong();
                thu_viec_sap_het_han();
                nghi_viec_sap_quay_lai();
                nhan_vien_chinh_thuc();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void f400_Main_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                m_tab_form.Visible = false; // If no any child form, hide tabControl
            else
            {
                // If child form is new and no has tabPage, create new tabPage
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child form caption
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = m_tab_form;
                    m_tab_form.SelectedTab = tp;
                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
                }

                if (!m_tab_form.Visible) m_tab_form.Visible = true;
            }
        }

        void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((m_tab_form.SelectedTab != null) && (m_tab_form.SelectedTab.Tag != null))
                m_tab_form.SelectTab(m_i_selected_tab_index - 1);
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void m_cmd_ql_chuc_vu_Click(object sender, EventArgs e)
        {
            show_form(new f401_V_DM_CHUC_VU());
        }

        private void m_cmd_ql_cap_bac_Click(object sender, EventArgs e)
        {
            show_form(new F604_v_dm_cap_bac());
        }

        private void m_tab_form_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if ((m_tab_form.SelectedTab != null) && (m_tab_form.SelectedTab.Tag != null))
            {
                (m_tab_form.SelectedTab.Tag as Form).Select();
                m_i_selected_tab_index = m_tab_form.SelectedIndex;
            }
        }

        #region Hover Notice
        private void panel1_Click(object sender, EventArgs e)
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

        private void panel2_Click(object sender, EventArgs e)
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

        private void panel3_Click(object sender, EventArgs e)
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

        private void panel4_Click(object sender, EventArgs e)
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

        private void 
            
            
            _Click(object sender, EventArgs e)
        {
            try
            {
                F500_DM_DU_AN frm = new F500_DM_DU_AN();
                frm.DisplaySapKetThuc();
                frm.ShowDialog();
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                                                        frm502.count_record_du_an_sap_ket_thuc());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Aquamarine;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = SystemColors.Control;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Aquamarine;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = SystemColors.Control;
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Aquamarine;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = SystemColors.Control;
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Aquamarine;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = SystemColors.Control;
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Aquamarine;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = SystemColors.Control;
        }

        private void panel_change_bgcolor_MouseHover(object sender, EventArgs e)
        {
            try
            {
                Panel v_pnl = (Panel)sender;
                v_pnl.BackColor = Color.Aquamarine;
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void panel_change_bgcolor_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Panel v_pnl = (Panel)sender;
                v_pnl.BackColor = SystemColors.Control;
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_sap_quay_lai_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Aquamarine;
        }

        private void m_lbl_thu_viec_sap_het_han_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Aquamarine;
        }

        private void m_lbl_thong_bao_hop_dong_sap_het_han_MouseHover(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Aquamarine;
        }

        private void m_lbl_thong_bao_hdld_da_het_han_nhung_chua_ky_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Aquamarine;
        }

        private void m_lbl_du_an_sap_kt_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Aquamarine;
        }
        #endregion

        private void m_cmd_phan_quyen_chi_tiet_Click(object sender, EventArgs e)
        {
            show_form(new f994_phan_quyen_detail());
        }

        private void m_cmd_phan_quyen_he_thong_Click(object sender, EventArgs e)
        {
            show_form(new f993_phan_quyen_he_thong());
        }

        private void m_cmd_nhom_nguoi_su_dung_Click(object sender, EventArgs e)
        {
            show_form(new f997_ht_nhom_nguoi_su_dung());
        }

        private void m_cmd_phan_quyen_cho_nhom_Click(object sender, EventArgs e)
        {
            show_form(new f995_ht_phan_quyen_cho_nhom());
        }

        private void m_cmd_nguoi_su_dung_Click(object sender, EventArgs e)
        {
            show_form(new f999_ht_nguoi_su_dung());
        }

        private void m_cmd_danh_muc_control_Click(object sender, EventArgs e)
        {
            show_form(new f991_v_ht_control_in_form());
        }

        private void m_cmd_tu_dien_he_thong_Click(object sender, EventArgs e)
        {
            show_form(new f100_TuDien());
        }

        private void m_cmd_backup_recovery_Click(object sender, EventArgs e)
        {
            show_form(new f400_dialog());
        }

        private void m_cmd_huong_dan_su_dung_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("http://1drv.ms/XzwLat");
                Process.Start(sInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void m_cmd_phan_hoi_loi_pm_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("http://goo.gl/swobCf");
                Process.Start(sInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void m_cmd_ql_don_vi_Click(object sender, EventArgs e)
        {
            show_form(new f101_v_dm_don_vi());
        }

        private void m_cmd_ql_phap_nhan_Click(object sender, EventArgs e)
        {
            show_form(new f703_dm_phap_nhan());
        }

        private void m_cmd_ql_quyet_dinh_Click(object sender, EventArgs e)
        {
            show_form(new F205_V_GD_QUYET_DINH());
        }

        private void m_cmd_ho_so_nhan_su_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f201_dm_nhan_su());
                nhan_vien_hien_tai();
                thu_viec_sap_het_han();
                nghi_viec_sap_quay_lai();
                canh_bao_hop_dong();
                nhan_vien_chinh_thuc();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_thay_doi_chuc_vu_don_vi_Click(object sender, EventArgs e)
        {
            try
            {
                //f202_V_GD_QUA_TRINH_LAM_VIEC frm = new f202_V_GD_QUA_TRINH_LAM_VIEC(this);
                //bool tabExist = false;
                //foreach (TabPage tabPage in m_tab_form.TabPages)
                //{
                //    if (frm.Text.Equals(tabPage.Text))
                //    {
                //        m_tab_form.SelectedTab = tabPage;
                //        tabExist = true;
                //    }
                //}

                //if (!tabExist)
                //{
                //    frm.MdiParent = this;
                //    frm.Dock = DockStyle.Fill;
                //    frm.Show();
                //    frm.FormBorderStyle = FormBorderStyle.None;
                //}
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_trang_thai_lao_dong_Click(object sender, EventArgs e)
        {
            try
            {
                //f203_v_gd_trang_thai_lao_dong frm = new f203_v_gd_trang_thai_lao_dong(this);
                //bool tabExist = false;
                //foreach (TabPage tabPage in m_tab_form.TabPages)
                //{
                //    if (frm.Text.Equals(tabPage.Text))
                //    {
                //        m_tab_form.SelectedTab = tabPage;
                //        tabExist = true;
                //    }
                //}

                //if (!tabExist)
                //{
                //    frm.MdiParent = this;
                //    frm.Dock = DockStyle.Fill;
                //    frm.Show();
                //    frm.FormBorderStyle = FormBorderStyle.None;
                //}
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_chi_tiet_cap_bac_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f105_v_gd_chi_tiet_cap_bac());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_qua_trinh_di_cong_tac_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f206_v_gd_cong_tac());

            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_thong_tin_du_an_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new F500_DM_DU_AN());
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                                                        frm502.count_record_du_an_sap_ket_thuc());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_hop_dong_lao_dong_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f701_v_hop_dong_lao_dong());
                f702_bao_cao_hdld frm2 = new f702_bao_cao_hdld();
                //m_lbl_thong_bao_hop_dong_sap_het_han.Text =
                //string.Format("Có {0} hợp đồng sắp hết hạn. Click để xem chi tiết!", frm2.count_record_bao_cao_sap_het_han());
                //m_lbl_thong_bao_hdld_da_het_han_nhung_chua_ky.Text =
                //  string.Format("Có {0} hợp đồng đã quá hạn và chưa ký mới. Click để xem chi tiết!",
                //              frm2.count_record_bao_cao_het_han_nhung_chua_ky_moi());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bao_cao_du_an_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f502_bao_cao_du_an());
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc. Click để xem chi tiết!",
                                                        frm502.count_record_du_an_sap_ket_thuc());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_tra_cuu_nhan_su_du_an_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f501_v_dm_nhan_su_du_an());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bao_cao_hop_dong_lao_dong_Click(object sender, EventArgs e)
        {
            try
            {
                f702_bao_cao_hdld frm = new f702_bao_cao_hdld();
                frm.set_form_mode_for_report(1);
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                frm.FormBorderStyle = FormBorderStyle.None;
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_tra_cuu_nhan_su_chung_Click(object sender, EventArgs e)
        {
            try
            {
                //show_form(new f103_bao_cao_tra_cuu_nhan_su());
                show_form(new f103_bao_cao_tra_cuu_nhan_su());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_nhan_su_theo_phong_ban_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f104_tra_cuu_nhan_su_theo_ma());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_nhan_su_theo_chuc_vu_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f402_BAO_CAO_NHAN_SU_CHUC_VU());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_nhan_su_theo_cap_bac_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f403_BAO_CAO_NHAN_SU_CAP_BAC());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_qua_trinh_lam_viec_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f404_GD_QUA_TRINH_CONG_TAC());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bien_dong_chuc_vu_trang_thai_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f405_bao_cao_chuc_vu_trang_thai());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bao_cao_so_luong_bo_nhiem_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f406_bao_cao_bo_nhiem());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bao_cao_danh_sach_bo_nhiem_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f407_bao_cao_bo_nhiem());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bien_dong_don_vi_trang_thai_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f408_bao_cao_don_vi_trang_thai());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bao_cao_nghi_viec_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f409_bao_cao_nghi_viec());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                //show_form(new f103_bao_cao_tra_cuu_nhan_su());
                f103_bao_cao_tra_cuu_nhan_su frm = new f103_bao_cao_tra_cuu_nhan_su();
                frm.ShowDialog();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                m_exitmode = IPConstants.HowUserWantTo_Exit_MainForm.Login_As_DifferentUser;
                List<Form> v_list_openForms = new List<Form>();

                foreach (Form v_f in Application.OpenForms)
                    v_list_openForms.Add(v_f);

                foreach (Form v_f in v_list_openForms)
                {

                    v_f.Close();
                }

            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void button15_Click(object sender, EventArgs e)
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

        private void m_cmd_luongqd_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f301_V_GD_LUONG_THEO_QD());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_ky_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new f300_DM_KY());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        /*private void m_clk_phap_nhan_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // bỏ check các checkbox khác
            if (e.NewValue == CheckState.Checked)
            {
                IEnumerator myEnumerator;
                myEnumerator = m_clk_phap_nhan.CheckedIndices.GetEnumerator();
                int y;
                while (myEnumerator.MoveNext() != false)
                {
                    y = (int)myEnumerator.Current;
                    m_clk_phap_nhan.SetItemChecked(y, false);
                }
            }

            if (m_clk_phap_nhan.SelectedIndex != -1)
            {
                CAppContext_201.setCurrentIDPhapnhan(int.Parse(m_clk_phap_nhan.SelectedValue.ToString()));
                nhan_vien_hien_tai();
                US_DM_PHAP_NHAN v_us = new US_DM_PHAP_NHAN(CAppContext_201.getCurrentIDPhapnhan());
                toolStripStatusLabel1.Text = "Pháp nhân: " + v_us.strMA_PHAP_NHAN + " - " + v_us.strTEN_PHAP_NHAN;

                foreach (TabPage tabPage in m_tab_form.TabPages)
                {
                    //if (tabPage.TabIndex != 0)
                        tabPage.Dispose();
                }
                show_form(new f408_bao_cao_don_vi_trang_thai());
            }
        }
        */
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= 10; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    worker.ReportProgress(i * 10);
                    //System.Threading.Thread.Sleep(500);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                alert.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%";
                alert.ProgressValue = e.ProgressPercentage;
            }
            m_pnl_thong_bao.Height = m_cmd_thong_bao.Height - m_tab_form.Height;

            load_phap_nhan_to_cbo_phap_nhan();
            //auto_sugget_phap_nhan();


            if (CAppContext_201.getCurrentIDPhapnhan() == 3)
            {
                m_menuitem_hopdong.Visible = false;
                m_menuitem_bao_cao_hop_dong.Visible = false;
            }
            if (CAppContext_201.getCurrentIDPhapnhan() != -1)
            {
                US_DM_PHAP_NHAN v_us = new US_DM_PHAP_NHAN(CAppContext_201.getCurrentIDPhapnhan());
                toolStripStatusLabel1.Text = "Pháp nhân: " + v_us.strMA_PHAP_NHAN + " - " + v_us.strTEN_PHAP_NHAN;
            }
            else
            {
                toolStripStatusLabel1.Text = "Tất cả";
            }
            f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
            m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                                                    frm502.count_record_du_an_sap_ket_thuc());
            m_tab_menu.SelectedTab = tabPage3;
            canh_bao_hop_dong();
            thu_viec_sap_het_han();
            nghi_viec_sap_quay_lai();
            nhan_vien_chinh_thuc();
            //show_form(new f408_bao_cao_don_vi_trang_thai());
            //alert.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%";
            //alert.ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            alert.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
                // Close the AlertForm
                alert.Close();
            }
        }

        private void m_cbo_phap_nhan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CAppContext_201.setCurrentIDPhapnhan(int.Parse(m_cbo_phap_nhan.SelectedValue.ToString()));
                nhan_vien_hien_tai();
                US_DM_PHAP_NHAN v_us = new US_DM_PHAP_NHAN(CAppContext_201.getCurrentIDPhapnhan());
                toolStripStatusLabel1.Text = "Pháp nhân: " + v_us.strMA_PHAP_NHAN + " - " + v_us.strTEN_PHAP_NHAN;

                foreach (TabPage tabPage in m_tab_form.TabPages)
                {
                    //if (tabPage.TabIndex != 0)
                    tabPage.Dispose();
                }
                show_form(new f408_bao_cao_don_vi_trang_thai());
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void panel7_MouseHover(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Aquamarine;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = SystemColors.Control;
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            try
            {
                F411_bao_cao_so_luong_nv_theo_loai frm = new F411_bao_cao_so_luong_nv_theo_loai();
                frm.ShowDialog();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_rpt_tong_luong_Click(object sender, EventArgs e)
        {
            try
            {
                show_form(new BKI_HRM.BaoCao.f302_RPT_TONG_LUONG());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
                
            }
        }

        private void m_pnl_thu_viec_da_het_han_Click(object sender, EventArgs e)
        {
            try
            {
                f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
                v_frm.display_thu_viec_da_het_han();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using IP.Core.IPCommon;
using DevExpress.XtraBars.Docking;
using GuiDev;
using DevExpress.XtraTab;
using BKI_HRM.HeThong;
using BKI_HRM.UCControl;
using IP.Core.IPSystemAdmin;
using System.Diagnostics;
using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.NghiepVu;
using BKI_HRM.BaoCao;
using BKI_HRM.DS.CDBNames;
namespace BKI_HRM
{
    public partial class f002_main_form : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public f002_main_form()
        {
            InitializeComponent();
            add_thong_bao();
            format_controls();
            m_obj_tab.setCloseButtonTab(m_xtab_control, ClosePageButtonShowMode.InAllTabPageHeaders);
        }
        #region Public Interfaces
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
        #endregion

        #region Members
        IPConstants.HowUserWantTo_Exit_MainForm m_exitmode = IPConstants.HowUserWantTo_Exit_MainForm.ExitFromSystem;
        TabAdd m_obj_tab = new TabAdd();
        #endregion

        #region Private Methods
        public void refresh()
        {
            nhan_vien_hien_tai();
        }
        private void close_tab_A(bool ip_y_n)
        {
            if (ip_y_n == true)
                m_xtab_control.TabPages.RemoveAt(m_xtab_control.SelectedTabPageIndex);
        }
        private void add_thong_bao()
        {
            DockPanel v_pnl = dockManager1.AddPanel(DockingStyle.Left);
            v_pnl.Text = "THÔNG BÁO";
            v_pnl.Width = 400;
            v_pnl.ControlContainer.Controls.Add(m_pnl_thong_bao);
            m_pnl_thong_bao.Dock = DockStyle.Fill;
            v_pnl.Options.ShowCloseButton = false;
            v_pnl.Visibility = DockVisibility.AutoHide;
            v_pnl.DockManager.DockingOptions.HideImmediatelyOnAutoHide = true;
            v_pnl.DockManager.DockMode = DevExpress.XtraBars.Docking.Helpers.DockMode.VS2005;
            //v_pnl.DockManager.auto


            v_pnl.Click += v_pnl_Click;
            v_pnl.ControlAdded += v_pnl_ControlAdded;
            v_pnl.MouseClick += v_pnl_MouseClick;
            v_pnl.Expanded += v_pnl_Expanded;
        }

        void v_pnl_Expanded(object sender, DockPanelEventArgs e)
        {
            try
            {
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                                                        frm502.count_record_du_an_sap_ket_thuc());

                canh_bao_hop_dong();
                thu_viec_sap_het_han_da_het_han();
                nghi_viec_sap_quay_lai();
                //nhan_vien_chinh_thuc();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void v_pnl_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void set_visible_thong_bao()
        {
            ControlFormat.setFormat_theo_phap_nhan(this);

            ShowInTaskbar = true;

            nhan_vien_hien_tai();
        }

        private void format_controls()
        {
            set_visible_thong_bao();
            set_define_events();
            m_tab_menu.SelectedPage = ribbonPage3;
            // m_tab_menu.Images = imageList1;
            // m_cmd_ql_chuc_vu.ImageIndex = imageList1.Images[1].;
            //CControlFormat.setFormStyle(this, new CAppContext_201());
        }
        private void nhan_vien_hien_tai()
        {
            US_V_DM_DU_LIEU_NHAN_VIEN v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            DS_V_DM_DU_LIEU_NHAN_VIEN v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            decimal v_dc_so_luong_nv_hien_tai = 0;
            v_us.count_nhan_vien(v_ds, "hiện tại",
                CAppContext_201.getCurrentIDPhapnhan(),
                ref v_dc_so_luong_nv_hien_tai);

            m_lbl_tong_so_nv.Text = "Số lượng nhân viên hiện tại: " + v_dc_so_luong_nv_hien_tai;
        }
        private void thu_viec_sap_het_han_da_het_han()
        {
            US_V_DM_DU_LIEU_NHAN_VIEN v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            DS_V_DM_DU_LIEU_NHAN_VIEN v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            decimal v_dc_so_luong_nv = 0;

            // Thử việc sắp hết hạn
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

            // Thử việc đã hết hạn
            v_us.count_nhan_vien(v_ds, "thử việc đã hết hạn"
                , CAppContext_201.getCurrentIDPhapnhan()
                , ref v_dc_so_luong_nv);
            if (v_dc_so_luong_nv <= 0)
            {
                m_lbl_thu_viec_da_het_han.Text = @"Không có Thử việc đã hết hạn";
            }
            else
            {
                m_lbl_thu_viec_da_het_han.Text = @"Có " + v_dc_so_luong_nv.ToString() +
                                                  " Thử việc đã hết hạn!";
            }
        }
        private void nhan_vien_chinh_thuc()
        {
            US_V_GD_QUA_TRINH_LAM_VIEC_2 v_us = new US_V_GD_QUA_TRINH_LAM_VIEC_2();
            DS_V_GD_QUA_TRINH_LAM_VIEC_2 v_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC_2();
            decimal v_dc_so_luong_nv = 0;
            //  f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
            v_us.count_nhan_vien_chinh_thuc(v_ds, DateTime.Now
                , ref v_dc_so_luong_nv, CAppContext_201.getCurrentIDPhapnhan());

            m_lbl_nv_chinh_thuc.Text = @"Có " + v_dc_so_luong_nv.ToString() +
                                                  " nhân viên chính thức trên 6 tháng.";

            //v_frm.display_thu_viec_sap_het_han();
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
        private void m_cbo_phap_nhan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CAppContext_201.setCurrentIDPhapnhan(int.Parse(m_cbo_phap_nhan.SelectedValue.ToString()));

                //
                decimal v_id_pn = CAppContext_201.getCurrentIDPhapnhan();
                switch (v_id_pn.ToString())
                {
                    case "3":
                        m_cmd_bao_cao_hop_dong_lao_dong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        ribbonPageGroup10.Visible = true;
                        m_cmd_bc_luong_theo_qd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        m_cmd_rpt_tong_luong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        m_cmd_thong_tin_du_an.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        m_cmd_hop_dong_lao_dong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        m_cmd_luongqd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        m_cmd_nhan_su_theo_chuc_vu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        //m_cmd_import_luong_theo_qd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        ribbonPageGroup12.Visible = false;
                        ribbonPageGroup13.Visible = false;
                        break;
                    default:
                        m_cmd_bao_cao_hop_dong_lao_dong.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        ribbonPageGroup10.Visible = false;
                        m_cmd_bc_luong_theo_qd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        m_cmd_rpt_tong_luong.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        m_cmd_thong_tin_du_an.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        m_cmd_hop_dong_lao_dong.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        m_cmd_luongqd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        m_cmd_nhan_su_theo_chuc_vu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        //m_cmd_import_luong_theo_qd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        ribbonPageGroup12.Visible = true;
                        ribbonPageGroup13.Visible = true;
                        break;
                }
                //

                nhan_vien_hien_tai();
                US_DM_PHAP_NHAN v_us = new US_DM_PHAP_NHAN(CAppContext_201.getCurrentIDPhapnhan());
                //toolStripStatusLabel1.Text = "Pháp nhân: " + v_us.strMA_PHAP_NHAN + " - " + v_us.strTEN_PHAP_NHAN;

                //foreach(XtraTabPage tabPage in m_xtab_control.TabPages) {
                //    m_xtab_control.TabPages.TabControl.Dispose();
                //}
                m_xtab_control.TabPages.Clear();
                /*f408_bao_cao_don_vi_trang_thai v_frm = new f408_bao_cao_don_vi_trang_thai();
                m_obj_tab.AddTab(m_xtab_control, v_frm.Name, v_frm.Text, v_frm, new UserControl());*/

                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                                                        frm502.count_record_du_an_sap_ket_thuc());

                canh_bao_hop_dong();
                thu_viec_sap_het_han_da_het_han();
                nghi_viec_sap_quay_lai();
                nhan_vien_chinh_thuc();

                set_visible_thong_bao();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }


        #endregion
        private void closeTabPage(EventArgs e)
        {
            m_obj_tab.setCloseTabInEventCloseForm(m_xtab_control, e);
        }

       
        #region Events
        private void set_define_events()
        {
            //
            m_xtab_control.CloseButtonClick += m_xtab_control_CloseButtonClick;
            m_cmd_phan_quyen_chi_tiet.ItemClick += m_cmd_phan_quyen_chi_tiet_ItemClick;
            m_cmd_phan_quyen_he_thong.ItemClick += m_cmd_phan_quyen_he_thong_ItemClick;
            m_cmd_phan_quyen_cho_nhom.ItemClick += m_cmd_phan_quyen_cho_nhom_ItemClick;
            m_cmd_nguoi_su_dung.ItemClick += m_cmd_nguoi_su_dung_ItemClick;
            m_cmd_nhom_nguoi_su_dung.ItemClick += m_cmd_nhom_nguoi_su_dung_ItemClick;
            m_cmd_danh_muc_control.ItemClick += m_cmd_danh_muc_control_ItemClick;
            m_cmd_tu_dien_he_thong.ItemClick += m_cmd_tu_dien_he_thong_ItemClick;
            m_cmd_backup_recovery.ItemClick += m_cmd_backup_recovery_ItemClick;
            m_cmd_huong_dan_su_dung.ItemClick += m_cmd_huong_dan_su_dung_ItemClick;

            //Danh mục
            m_cmd_ql_chuc_vu.ItemClick += m_cmd_ql_chuc_vu_ItemClick;
            m_cmd_ql_cap_bac.ItemClick += m_cmd_ql_cap_bac_ItemClick;
            m_cmd_ql_don_vi.ItemClick += m_cmd_ql_don_vi_ItemClick;
            m_cmd_ql_phap_nhan.ItemClick += m_cmd_ql_phap_nhan_ItemClick;
            m_cmd_ql_quyet_dinh.ItemClick += m_cmd_ql_quyet_dinh_ItemClick;
            m_cmd_ky.ItemClick += m_cmd_ky_ItemClick;

            //Nghiệp vụ
            m_cmd_ho_so_nhan_su.ItemClick += m_cmd_ho_so_nhan_su_ItemClick;
            m_cmd_thay_doi_chuc_vu_don_vi.ItemClick += m_cmd_thay_doi_chuc_vu_don_vi_ItemClick;
            m_cmd_trang_thai_lao_dong.ItemClick += m_cmd_trang_thai_lao_dong_ItemClick;
            m_cmd_chi_tiet_cap_bac.ItemClick += m_cmd_chi_tiet_cap_bac_ItemClick;
            m_cmd_qua_trinh_di_cong_tac.ItemClick += m_cmd_qua_trinh_di_cong_tac_ItemClick;
            m_cmd_thong_tin_du_an.ItemClick += m_cmd_thong_tin_du_an_ItemClick;
            m_cmd_hop_dong_lao_dong.ItemClick += m_cmd_hop_dong_lao_dong_ItemClick;
            m_cmd_luongqd.ItemClick += m_cmd_luongqd_ItemClick;
            //m_cmd_import_luong_theo_qd.ItemClick += m_cmd_import_luong_theo_qd_ItemClick;

            //Báo cáo
            m_cmd_bao_cao_du_an.ItemClick += m_cmd_bao_cao_du_an_ItemClick;
            m_cmd_tra_cuu_nhan_su_du_an.ItemClick += m_cmd_tra_cuu_nhan_su_du_an_ItemClick;
            m_cmd_bao_cao_hop_dong_lao_dong.ItemClick += m_cmd_bao_cao_hop_dong_lao_dong_ItemClick;
            m_cmd_tra_cuu_nhan_su_chung.ItemClick += m_cmd_tra_cuu_nhan_su_chung_ItemClick;
            m_cmd_nhan_su_theo_ma.ItemClick += m_cmd_nhan_su_theo_phong_ban_ItemClick;
            m_cmd_nhan_su_theo_chuc_vu.ItemClick += m_cmd_nhan_su_theo_chuc_vu_ItemClick;
            m_cmd_nhan_su_theo_cap_bac.ItemClick += m_cmd_nhan_su_theo_cap_bac_ItemClick;
            m_cmd_qua_trinh_lam_viec.ItemClick += m_cmd_qua_trinh_lam_viec_ItemClick;
            m_cmd_bien_dong_chuc_vu_trang_thai.ItemClick += m_cmd_bien_dong_chuc_vu_trang_thai_ItemClick;
            m_cmd_bao_cao_so_luong_bo_nhiem.ItemClick += m_cmd_bao_cao_so_luong_bo_nhiem_ItemClick;
            m_cmd_bao_cao_danh_sach_bo_nhiem.ItemClick += m_cmd_bao_cao_danh_sach_bo_nhiem_ItemClick;
            m_cmd_bien_dong_don_vi_trang_thai.ItemClick += m_cmd_bien_dong_don_vi_trang_thai_ItemClick;
            m_cmd_bao_cao_nghi_viec.ItemClick += m_cmd_bao_cao_nghi_viec_ItemClick;
            m_cmd_bc_luong_theo_qd.ItemClick += m_cmd_bc_luong_theo_qd_ItemClick;
            m_cmd_rpt_tong_luong.ItemClick += m_cmd_rpt_tong_luong_ItemClick;
            m_cmd_rpt_luong_don_vi_theo_ky.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(m_cmd_rpt_luong_don_vi_theo_ky_ItemClick);
            m_cmd_rpt_nhan_su_perfect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(m_cmd_rpt_nhan_su_perfect_ItemClick);

            ///
            m_lbl_tong_so_nv.Click += m_lbl_tong_so_nv_Click;
            m_cbo_phap_nhan.SelectionChangeCommitted += m_cbo_phap_nhan_SelectionChangeCommitted;

            //m_pnl_thu_viec_da_het_han.Click += m_pnl_thu_viec_da_het_han_Click;

            panel1.Click += panel1_Click;
            panel2.Click += panel2_Click;
            panel3.Click += panel3_Click;
            panel4.Click += panel4_Click;
            panel5.Click += panel5_Click;
            panel7.Click += panel7_Click;
            panel7.MouseHover += panel7_MouseHover;
            panel7.MouseLeave += panel7_MouseLeave;

            panel5.MouseHover += panel5_MouseHover;
            panel5.MouseLeave += panel5_MouseLeave;

            panel4.MouseHover += panel4_MouseHover;
            panel4.MouseLeave += panel4_MouseLeave;

            panel3.MouseHover += panel3_MouseHover;
            panel3.MouseLeave += panel3_MouseLeave;

            panel2.MouseHover += panel2_MouseHover;
            panel2.MouseLeave += panel2_MouseLeave;

            panel1.MouseHover += panel1_MouseHover;
            panel1.MouseLeave += panel1_MouseLeave;

            m_pnl_thu_viec_da_het_han.Click += m_pnl_thu_viec_da_het_han_Click;
            m_pnl_thu_viec_da_het_han.MouseHover += m_pnl_thu_viec_da_het_han_MouseHover;
            m_pnl_thu_viec_da_het_han.MouseLeave += m_pnl_thu_viec_da_het_han_MouseLeave;

            m_pnl_nv_chua_chuc_vu_trang_thai.Click += new EventHandler(pnl_Click);
            m_pnl_nv_chua_chuc_vu_trang_thai.MouseHover += new EventHandler(pnl_MouseHover);
            m_pnl_nv_chua_chuc_vu_trang_thai.MouseLeave += new EventHandler(pnl_MouseLeave);

            m_cmd_exit.ItemClick += m_cmd_exit_ItemClick;
        }

        private void pnl_MouseLeave(object sender, EventArgs e)
        {
            Panel v_pnl = (Panel)sender;
            v_pnl.BackColor = SystemColors.Control;
        }

        private void pnl_MouseHover(object sender, EventArgs e)
        {
            Panel v_pnl = (Panel)sender;
            v_pnl.BackColor = Color.Aquamarine;
        }

        private void pnl_Click(object sender, EventArgs e)
        {
            try
            {
                Panel v_pnl = (Panel)sender;

                if (v_pnl.Name == m_pnl_nv_chua_chuc_vu_trang_thai.Name)
                {
                    f307_RPT_NHAN_VIEN_CHUA_CHUC_VU_TRANG_THAI v_frm = new f307_RPT_NHAN_VIEN_CHUA_CHUC_VU_TRANG_THAI();
                    v_frm.display();
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_rpt_nhan_su_perfect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f306_RPT_NHAN_SU_PERFECT v_frm = new f306_RPT_NHAN_SU_PERFECT();
                m_obj_tab.AddTab(m_xtab_control, v_frm.Name, v_frm.Text, v_frm, new UserControl());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_rpt_luong_don_vi_theo_ky_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f304_RPT_LUONG_DON_VI_THEO_KY v_frm = new f304_RPT_LUONG_DON_VI_THEO_KY();
                m_obj_tab.AddTab(m_xtab_control, v_frm.Name, v_frm.Text, v_frm, new UserControl());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void m_pnl_thu_viec_da_het_han_MouseLeave(object sender, EventArgs e)
        {
            m_pnl_thu_viec_da_het_han.BackColor = SystemColors.Control;
        }

        private void m_pnl_thu_viec_da_het_han_MouseHover(object sender, EventArgs e)
        {
            m_pnl_thu_viec_da_het_han.BackColor = Color.Aquamarine;
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
        private void panel5_Click(object sender, EventArgs e)
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
        void v_pnl_ControlAdded(object sender, ControlEventArgs e)
        {
            try
            {
                //f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                //m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                //                                        frm502.count_record_du_an_sap_ket_thuc());

                //canh_bao_hop_dong();
                //thu_viec_sap_het_han();
                //nghi_viec_sap_quay_lai();
                //nhan_vien_chinh_thuc();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbl_thu_viec_sap_het_han_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Aquamarine;
        }
        private void m_lbl_sap_quay_lai_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Aquamarine;
        }
        void m_lbl_tong_so_nv_Click(object sender, EventArgs e)
        {
            try
            {
                //f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
                f104_tra_cuu_nhan_su_theo_ma v_frm = new f104_tra_cuu_nhan_su_theo_ma();
                m_obj_tab.AddTab(m_xtab_control, "tab_bc_tra_cuu_nhan_su", v_frm.Text, v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }


        void m_cmd_rpt_tong_luong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f302_RPT_TONG_LUONG v_frm = new f302_RPT_TONG_LUONG();
                m_obj_tab.AddTab(m_xtab_control, v_frm.Name, v_frm.Text, v_frm, new UserControl());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_bc_luong_theo_qd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f800_BC_LUONG_THEO_QD v_frm = new f800_BC_LUONG_THEO_QD();
                m_obj_tab.AddTab(m_xtab_control, v_frm.Name, v_frm.Text, v_frm, new UserControl());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_bao_cao_nghi_viec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f409_bao_cao_nghi_viec v_frm = new f409_bao_cao_nghi_viec();
                m_obj_tab.AddTab(m_xtab_control, v_frm.Name, v_frm.Text, v_frm, new UserControl());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_bien_dong_don_vi_trang_thai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f408_bao_cao_don_vi_trang_thai v_frm = new f408_bao_cao_don_vi_trang_thai();
                m_obj_tab.AddTab(m_xtab_control, v_frm.Name, v_frm.Text, v_frm, new UserControl());
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_bao_cao_danh_sach_bo_nhiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f407_bao_cao_bo_nhiem v_frm = new f407_bao_cao_bo_nhiem();
                m_obj_tab.AddTab(m_xtab_control, v_frm.Name, v_frm.Text, v_frm, new UserControl());
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_bao_cao_so_luong_bo_nhiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f406_bao_cao_bo_nhiem v_frm = new f406_bao_cao_bo_nhiem();
                m_obj_tab.AddTab(m_xtab_control, "bc_sl_bo_nhiem", v_frm.Text, v_frm, new UserControl());

            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_bien_dong_chuc_vu_trang_thai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frm_V_GD_QUA_TRINH_LAM_VIEC_2 v_frm = new frm_V_GD_QUA_TRINH_LAM_VIEC_2();
                m_obj_tab.AddTab(m_xtab_control, "tab_bien_dong_nhan_su", v_frm.Text, v_frm, new UserControl());

            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_qua_trinh_lam_viec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f404_GD_QUA_TRINH_CONG_TAC v_frm = new f404_GD_QUA_TRINH_CONG_TAC();
                m_obj_tab.AddTab(m_xtab_control, "tab_qua_trinh_cong_tac", v_frm.Text, v_frm, new UserControl());
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_nhan_su_theo_cap_bac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f403_BAO_CAO_NHAN_SU_CAP_BAC v_frm = new f403_BAO_CAO_NHAN_SU_CAP_BAC();
                m_obj_tab.AddTab(m_xtab_control, "tab_bc_nhan_su_cap_bac", v_frm.Text, v_frm, new UserControl());

            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_nhan_su_theo_chuc_vu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f402_BAO_CAO_NHAN_SU_CHUC_VU v_frm = new f402_BAO_CAO_NHAN_SU_CHUC_VU();
                m_obj_tab.AddTab(m_xtab_control, "tab_bc_nhan_su_chuc_vu", v_frm.Text, v_frm, new UserControl());

            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_nhan_su_theo_phong_ban_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f104_tra_cuu_nhan_su_theo_ma v_frm = new f104_tra_cuu_nhan_su_theo_ma();
                m_obj_tab.AddTab(m_xtab_control, "tab_bc_nhan_su_theo_pb", v_frm.Text, v_frm, new UserControl());

            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_tra_cuu_nhan_su_chung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f103_bao_cao_tra_cuu_nhan_su v_frm = new f103_bao_cao_tra_cuu_nhan_su();
                m_obj_tab.AddTab(m_xtab_control, "tab_bc_tra_cuu_nhan_su", v_frm.Text, v_frm, new UserControl());
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_bao_cao_hop_dong_lao_dong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f702_bao_cao_hdld v_frm = new f702_bao_cao_hdld();
                m_obj_tab.AddTab(m_xtab_control, "tab_bao_cao_hdld", v_frm.Text, v_frm, new UserControl());
                
                v_frm.set_form_mode_for_report(1);
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_tra_cuu_nhan_su_du_an_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f501_v_dm_nhan_su_du_an v_frm = new f501_v_dm_nhan_su_du_an();
                m_obj_tab.AddTab(m_xtab_control, "tab_tra_cuu_nhan_su_du_an", v_frm.Text, v_frm, new UserControl());
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_bao_cao_du_an_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f502_bao_cao_du_an v_frm = new f502_bao_cao_du_an();
                m_obj_tab.AddTab(m_xtab_control, "tab_bc_du_an", v_frm.Text, v_frm, new UserControl());
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc. Click để xem chi tiết!",
                                                        frm502.count_record_du_an_sap_ket_thuc());
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_luongqd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f301_V_GD_LUONG_THEO_QD v_frm = new f301_V_GD_LUONG_THEO_QD();
                m_obj_tab.AddTab(m_xtab_control, "tab_luong_theo_qd", v_frm.Text, v_frm, new UserControl());

            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_hop_dong_lao_dong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f701_v_hop_dong_lao_dong v_frm = new f701_v_hop_dong_lao_dong();
                m_obj_tab.AddTab(m_xtab_control, "tab_hop_dong_lao_dong", v_frm.Text, v_frm, new UserControl());

                f702_bao_cao_hdld frm2 = new f702_bao_cao_hdld();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_thong_tin_du_an_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                F500_DM_DU_AN v_frm = new F500_DM_DU_AN();
                m_obj_tab.AddTab(m_xtab_control, "tab_dm_du_an", v_frm.Text, v_frm, new UserControl());

                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                                                        frm502.count_record_du_an_sap_ket_thuc());
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_qua_trinh_di_cong_tac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f206_v_gd_cong_tac v_frm = new f206_v_gd_cong_tac();
                m_obj_tab.AddTab(m_xtab_control, "tab_qua_trinh_di_cong_tac", v_frm.Text, v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_chi_tiet_cap_bac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f105_v_gd_chi_tiet_cap_bac v_frm = new f105_v_gd_chi_tiet_cap_bac();
                m_obj_tab.AddTab(m_xtab_control, "tab_chi_tiet_cap_bac", v_frm.Text, v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_trang_thai_lao_dong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f203_v_gd_trang_thai_lao_dong v_frm = new f203_v_gd_trang_thai_lao_dong(this);
                m_obj_tab.AddTab(m_xtab_control, "tab_trang_thai_lao_dong", v_frm.Text, v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_thay_doi_chuc_vu_don_vi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f202_V_GD_QUA_TRINH_LAM_VIEC v_frm = new f202_V_GD_QUA_TRINH_LAM_VIEC(this);
                m_obj_tab.AddTab(m_xtab_control, "tab_thay_doi_chuc_vu", v_frm.Text, v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_ho_so_nhan_su_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f201_dm_nhan_su v_frm = new f201_dm_nhan_su();
                m_obj_tab.AddTab(m_xtab_control, "tab_ho_so_nhan_su", v_frm.Text, v_frm, new UserControl());
                

                nhan_vien_hien_tai();
                thu_viec_sap_het_han_da_het_han();
                nghi_viec_sap_quay_lai();
                canh_bao_hop_dong();
                nhan_vien_chinh_thuc();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_ky_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f300_DM_KY v_frm = new f300_DM_KY();
                m_obj_tab.AddTab(m_xtab_control, "tab_dm_ky", v_frm.Text, v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_ql_quyet_dinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                F205_V_GD_QUYET_DINH v_frm = new F205_V_GD_QUYET_DINH();
                m_obj_tab.AddTab(m_xtab_control, "tab_gd_quyet_dinh", v_frm.Text, v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_ql_phap_nhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f703_dm_phap_nhan v_frm = new f703_dm_phap_nhan();
                m_obj_tab.AddTab(m_xtab_control, "tab_dm_phap_nhan", v_frm.Text, v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_ql_don_vi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f101_v_dm_don_vi v_frm = new f101_v_dm_don_vi();
                m_obj_tab.AddTab(m_xtab_control, "tab_dm_don_vi", v_frm.Text, v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_ql_cap_bac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                F604_v_dm_cap_bac v_frm = new F604_v_dm_cap_bac();
                m_obj_tab.AddTab(m_xtab_control, "tab_ql_cap_bac", "F604 - Quản lý danh mục cấp bậc", v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_ql_chuc_vu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f401_V_DM_CHUC_VU v_frm = new f401_V_DM_CHUC_VU();
                m_obj_tab.AddTab(m_xtab_control, "tab_dm_chuc_vu", "F401 - Danh mục chức vụ", v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_huong_dan_su_dung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        void m_cmd_backup_recovery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f400_dialog v_frm = new f400_dialog();
                v_frm.ShowDialog();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_tu_dien_he_thong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f100_TuDien v_frm = new f100_TuDien();
                v_frm.ShowDialog();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_danh_muc_control_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f991_v_ht_control_in_form v_frm = new f991_v_ht_control_in_form();
                m_obj_tab.AddTab(m_xtab_control, "tab_dm_control", "F991 - Danh mục Control", v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_nhom_nguoi_su_dung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f997_ht_nhom_nguoi_su_dung v_frm = new f997_ht_nhom_nguoi_su_dung();
                m_obj_tab.AddTab(m_xtab_control, "tab_nhom_nguoi_sd", "F997 - Thông tin nhóm người sử dụng", v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_nguoi_su_dung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f999_ht_nguoi_su_dung v_frm = new f999_ht_nguoi_su_dung();
                m_obj_tab.AddTab(m_xtab_control, "tab_ht_nguoi_su_dung", "F999 - Thông tin người sử dụng", v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_phan_quyen_cho_nhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f995_ht_phan_quyen_cho_nhom v_frm = new f995_ht_phan_quyen_cho_nhom();
                m_obj_tab.AddTab(m_xtab_control, "tab_phan_quyen_cho_nhom", "F995 - Phân quyền cho nhóm", v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_phan_quyen_he_thong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f993_phan_quyen_he_thong v_frm = new f993_phan_quyen_he_thong();
                m_obj_tab.AddTab(m_xtab_control, "tab_phan_quyen_he_thong", "F993 - Phân quyền hệ thống", v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_phan_quyen_chi_tiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                f994_phan_quyen_detail v_frm = new f994_phan_quyen_detail();
                m_obj_tab.AddTab(m_xtab_control, "tab_phan_quyen_chi_tiet", "F994 - Phân quyền chi tiết", v_frm, new UserControl());
                
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_xtab_control_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                closeTabPage(e);
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void v_pnl_Click(object sender, EventArgs e)
        {
            try
            {
                //f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                //m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                //                                        frm502.count_record_du_an_sap_ket_thuc());

                //canh_bao_hop_dong();
                //thu_viec_sap_het_han();
                //nghi_viec_sap_quay_lai();
                //nhan_vien_chinh_thuc();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion

        private void f002_main_form_Load(object sender, EventArgs e)
        {
            try
            {
                load_phap_nhan_to_cbo_phap_nhan();
                f502_bao_cao_du_an frm502 = new f502_bao_cao_du_an();
                m_lbl_du_an_sap_kt.Text = string.Format("Có {0} dự án sắp kết thúc!",
                                                        frm502.count_record_du_an_sap_ket_thuc());


                #region Hiển thị số lượng nhân viên chưa có chức vụ, trạng thái
                DS_DM_NHAN_SU v_ds_nv = new DS_DM_NHAN_SU();
                US_DM_NHAN_SU v_us_nv = new US_DM_NHAN_SU();

                v_us_nv.FillDatasetSearch(v_ds_nv, "");

                int v_num_nv = v_ds_nv.Tables[0].Rows.Count;
                if (v_num_nv > 0)
                    m_lbl_nv_chua_chuc_vu_trang_thai.Text = string.Format("Có {0} nhân viên chưa có chức vụ, trạng thái", v_num_nv);
                else
                    m_lbl_nv_chua_chuc_vu_trang_thai.Text = "Không có nhân viên chưa có chức vụ, trạng thái";

                #endregion

                //m_tab_menu.SelectedTab = tabPage3;
                canh_bao_hop_dong();
                thu_viec_sap_het_han_da_het_han();
                nghi_viec_sap_quay_lai();
                nhan_vien_chinh_thuc();
                nhan_vien_hien_tai();
                //
                decimal v_id_pn = CAppContext_201.getCurrentIDPhapnhan();
                switch (v_id_pn.ToString())
                {
                    case "3":
                        m_cmd_bao_cao_hop_dong_lao_dong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        ribbonPageGroup10.Visible = true;
                        m_cmd_bc_luong_theo_qd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        m_cmd_rpt_tong_luong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        m_cmd_thong_tin_du_an.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        m_cmd_hop_dong_lao_dong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        m_cmd_luongqd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        //m_cmd_import_luong_theo_qd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        m_cmd_nhan_su_theo_chuc_vu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        ribbonPageGroup12.Visible = false;
                        ribbonPageGroup13.Visible = false;
                        break;
                    default:
                        m_cmd_bao_cao_hop_dong_lao_dong.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        ribbonPageGroup10.Visible = false;
                        m_cmd_bc_luong_theo_qd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        m_cmd_rpt_tong_luong.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        m_cmd_thong_tin_du_an.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        m_cmd_hop_dong_lao_dong.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        m_cmd_luongqd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        //m_cmd_import_luong_theo_qd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        m_cmd_nhan_su_theo_chuc_vu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        ribbonPageGroup12.Visible = true;
                        ribbonPageGroup13.Visible = true;
                        break;
                }

              /*  f408_bao_cao_don_vi_trang_thai v_frm = new f408_bao_cao_don_vi_trang_thai();
                m_obj_tab.AddTab(m_xtab_control, v_frm.Name, v_frm.Text, v_frm, new UserControl());*/
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}
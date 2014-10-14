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

namespace BKI_HRM {
    public partial class f002_main_form : DevComponents.DotNetBar.OfficeForm {
        public f002_main_form() {
            InitializeComponent();
            add_thong_bao();
            format_control();
        }
        #region Public Interfaces
        public void display(ref IPConstants.HowUserWantTo_Exit_MainForm v_exitmode) {
            try {
                ShowDialog();
                v_exitmode = m_exitmode;
                
            }
            catch(Exception v_e) {

                CSystemLog_301.ExceptionHandle(v_e);
            }

        }
        #endregion

        #region Members
        IPConstants.HowUserWantTo_Exit_MainForm m_exitmode = IPConstants.HowUserWantTo_Exit_MainForm.ExitFromSystem;
        TabAdd m_obj_tab = new TabAdd();
        #endregion

        #region Private Methods
        private void close_tab_A(bool ip_y_n) {
            if(ip_y_n == true)
                m_xtab_control.TabPages.RemoveAt(m_xtab_control.SelectedTabPageIndex);
        }
        private void add_thong_bao() {
            DockPanel v_pnl = dockManager1.AddPanel(DockingStyle.Left);
            v_pnl.Text = "THÔNG BÁO";

            v_pnl.ControlContainer.Controls.Add(m_pnl_thong_bao);
            m_pnl_thong_bao.Dock = DockStyle.Fill;
            v_pnl.Options.ShowCloseButton = false;
            v_pnl.Visibility = DockVisibility.AutoHide;
            v_pnl.DockManager.DockingOptions.HideImmediatelyOnAutoHide = true;
        }
        private void format_control() {
            set_define_events();
        }
        #endregion

        #region Events
        private void set_define_events() {
            m_xtab_control.CloseButtonClick += m_xtab_control_CloseButtonClick;
            m_cmd_phan_quyen_chi_tiet.ItemClick +=m_cmd_phan_quyen_chi_tiet_ItemClick;
            m_cmd_phan_quyen_he_thong.ItemClick += m_cmd_phan_quyen_he_thong_ItemClick;
            m_cmd_phan_quyen_cho_nhom.ItemClick += m_cmd_phan_quyen_cho_nhom_ItemClick;
        }

        void m_cmd_phan_quyen_cho_nhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                f995_ht_phan_quyen_cho_nhom v_frm = new f995_ht_phan_quyen_cho_nhom();
                v_frm.close_tab_B = new f995_ht_phan_quyen_cho_nhom.close_tab(close_tab_A);
                uc_for_form v_uc = new uc_for_form();
                m_obj_tab.AddFormToUC(v_frm, v_uc);
                m_obj_tab.AddTab(m_xtab_control, "tab_phan_quyen_cho_nhom", "F995 - Phân quyền cho nhóm", v_uc);
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        void m_cmd_phan_quyen_he_thong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                f993_phan_quyen_he_thong v_frm = new f993_phan_quyen_he_thong();
                v_frm.close_tab_B = new f993_phan_quyen_he_thong.close_tab(close_tab_A);
                uc_for_form v_uc = new uc_for_form();
                m_obj_tab.AddFormToUC(v_frm, v_uc);
                m_obj_tab.AddTab(m_xtab_control, "tab_phan_quyen_he_thong", "F993 - Phân quyền hệ thống", v_uc);
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_phan_quyen_chi_tiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                f994_phan_quyen_detail v_frm = new f994_phan_quyen_detail();
                v_frm.close_tab_B = new f994_phan_quyen_detail.close_tab(close_tab_A);
                uc_for_form v_uc = new uc_for_form();
                m_obj_tab.AddFormToUC(v_frm, v_uc);
                m_obj_tab.AddTab(m_xtab_control, "tab_phan_quyen_chi_tiet", "F994 - Phân quyền chi tiết", v_uc);
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_xtab_control_CloseButtonClick(object sender, EventArgs e) {
            try {
                m_xtab_control.TabPages.RemoveAt(m_xtab_control.SelectedTabPageIndex);
            }
            catch(Exception v_e) {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion

        private void f002_main_form_Load(object sender, EventArgs e) {
            try {
                
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}
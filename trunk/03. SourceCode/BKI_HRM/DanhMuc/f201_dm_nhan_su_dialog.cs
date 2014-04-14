﻿using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using IP.Core.IPWordReport;
using IP.Core.IPExcelReport;

using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;
using System.Threading;
using BKI_HRM.NghiepVu;
using BKI_HRM.DanhMuc;

namespace BKI_HRM
{
    public partial class f201_dm_nhan_su_dialog : Form
    {
#region "Public Interface"
        public f201_dm_nhan_su_dialog()
        {
            InitializeComponent();
            format_controls();
        }
        public void display(US_DM_NHAN_SU i_us)
        {
            m_us_nhan_su = i_us;
            this.Show();
        }
#endregion
#region "Members"
        US_DM_NHAN_SU m_us_nhan_su;
#endregion
#region "Private Methods"
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
           // set_define_events();
            this.KeyPreview = true;
        }
        private void them_chuc_vu()
        {
            US_V_GD_QUA_TRINH_LAM_VIEC v_us = new US_V_GD_QUA_TRINH_LAM_VIEC();
            DS_V_GD_QUA_TRINH_LAM_VIEC v_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC();
            
            v_us.FillDatasetByManhanvien(v_ds, m_us_nhan_su.strMA_NV, DateTime.Parse("1/1/1900"), DateTime.Today);
            v_us.DataRow2Me((DataRow)v_ds.V_GD_QUA_TRINH_LAM_VIEC.Rows[0]);
            
            f202_v_gd_qua_trinh_lam_viec_de v_frm = new f202_v_gd_qua_trinh_lam_viec_de();
            v_frm.display_for_insert(v_us, "thang_chuc");
            
        }
        private void them_trang_thai()
        {
            US_V_GD_TRANG_THAI_LAO_DONG v_us = new US_V_GD_TRANG_THAI_LAO_DONG();
            DS_V_GD_TRANG_THAI_LAO_DONG v_ds = new DS_V_GD_TRANG_THAI_LAO_DONG();
            v_us.FillDatasetByManhanvien(v_ds, m_us_nhan_su.strMA_NV);
            v_us.DataRow2Me((DataRow)v_ds.V_GD_TRANG_THAI_LAO_DONG.Rows[0]);
            f203_v_gd_trang_thai_lao_dong_de v_frm = new f203_v_gd_trang_thai_lao_dong_de();
            v_frm.display_for_insert(v_us);
            
        }
        private void them_hop_dong()
        {
            f701_v_gd_hop_dong_lao_dong_DE v_frm = new f701_v_gd_hop_dong_lao_dong_DE();
            v_frm.display_for_insert(m_us_nhan_su);
        }
        private void them_cap_bac()
        {
            US_V_GD_CHI_TIET_CAP_BAC v_us = new US_V_GD_CHI_TIET_CAP_BAC();
            DS_V_GD_CHI_TIET_CAP_BAC v_ds = new DS_V_GD_CHI_TIET_CAP_BAC();
            v_us.FillDatasetSearchCapCacThoiDiem(v_ds, m_us_nhan_su.strMA_NV, DateTime.Today);
            f106_v_gd_chi_tiet_cap_bac_DE v_frm = new f106_v_gd_chi_tiet_cap_bac_DE();
            v_frm.display_for_insert(v_us, v_ds);
        }
#endregion

        private void m_cmd_them_chuc_vu_Click(object sender, EventArgs e)
        {
            try
            {
                them_chuc_vu();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmd_them_trang_thai_Click(object sender, EventArgs e)
        {
            try
            {
                them_trang_thai();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_them_hop_dong_Click(object sender, EventArgs e)
        {
            try
            {
                them_hop_dong();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_them_cap_bac_Click(object sender, EventArgs e)
        {
            try
            {
                them_cap_bac();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }
#region "Events"

#endregion
        
    }
}

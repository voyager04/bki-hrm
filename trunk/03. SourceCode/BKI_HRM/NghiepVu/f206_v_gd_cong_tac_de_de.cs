using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPWordReport;
using System.Diagnostics;
using IP.Core.IPSystemAdmin;
using System.Collections;
using C1.Win.C1FlexGrid;

namespace BKI_HRM
{
    public partial class f206_v_gd_cong_tac_de_de : Form
    {

        #region Public Interfaces
        public f206_v_gd_cong_tac_de_de()
        {
            InitializeComponent();
            format_controls();
        }
        public void display_for_insert(US_DM_QUYET_DINH ip_us_quyet_dinh)
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_us_dm_quyet_dinh = ip_us_quyet_dinh;
            us_object_2_form();
            this.ShowDialog();
        }
        public void display_for_update(US_V_GD_CONG_TAC ip_us)
        {
            m_us_v_gd_cong_tac = ip_us;
            m_us_dm_quyet_dinh = new US_DM_QUYET_DINH(ip_us.dcID_QUYET_DINH);
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form();
            this.ShowDialog();

        }
        #endregion
        #region Data Structs

        #endregion
        #region Members
        ITransferDataRow m_obj_trans;
        US_V_GD_CONG_TAC m_us_v_gd_cong_tac = new US_V_GD_CONG_TAC();
        DS_V_GD_CONG_TAC m_ds_v_gd_cong_tac = new DS_V_GD_CONG_TAC();
        US_GD_CONG_TAC m_us_gd_cong_tac = new US_GD_CONG_TAC();
        DS_GD_CONG_TAC m_ds_gd_cong_tac = new DS_GD_CONG_TAC();
        US_DM_QUYET_DINH m_us_dm_quyet_dinh = new US_DM_QUYET_DINH();
        DS_DM_QUYET_DINH m_ds_dm_quyet_dinh = new DS_DM_QUYET_DINH();
        US_DM_NHAN_SU m_us_dm_nhan_su = new US_DM_NHAN_SU();
        DS_DM_NHAN_SU m_ds_dm_nhan_su = new DS_DM_NHAN_SU();
        DataEntryFormMode m_e_form_mode = new DataEntryFormMode();


        // File explorer
        private DataEntryFileMode m_e_file_mode;
        //  private FileExplorer m_fe_file_explorer;
        private string m_str_domain = ConfigurationSettings.AppSettings["DOMAIN"];
        private string m_str_directory_to = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private decimal m_str_id_hop_dong_old;
        private string m_str_link_old;
        #endregion

        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            this.KeyPreview = true;
         
        }
        private void set_inital_form_load()
        {

            switch (m_e_form_mode)
            {
                case DataEntryFormMode.UpdateDataState:
                    //us_object_2_form;
                    break;
                case DataEntryFormMode.ViewDataState:
                    break;
                case DataEntryFormMode.InsertDataState:
                    break;
                default:
                    break;
            }
            auto_suggest_text();

        }

        private bool check_data_is_ok()
        {
            return true;
        }

        private void form_2_us_object()
        {
            m_us_gd_cong_tac.dcID_QUYET_DINH = m_us_dm_quyet_dinh.dcID;
            m_us_gd_cong_tac.dcID_NHAN_SU = m_us_dm_nhan_su.dcID;
            m_us_gd_cong_tac.datNGAY_DI = m_dat_ngay_di.Value;
            m_us_gd_cong_tac.datNGAY_VE = m_dat_ngay_ve.Value;
            m_us_gd_cong_tac.strDIA_DIEM = m_txt_dia_diem.Text.Trim();
            m_us_gd_cong_tac.strMO_TA_CONG_VIEC = m_txt_mo_ta_cong_viec.Text.Trim();
        }

        private void us_object_2_form()
        {
            m_txt_ma_quyet_dinh.Text = m_us_dm_quyet_dinh.strMA_QUYET_DINH;
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    
                    break;
                case DataEntryFormMode.SelectDataState:
                    break;
                case DataEntryFormMode.UpdateDataState:
                    m_txt_tim_kiem_nhan_vien.Text = m_us_v_gd_cong_tac.strMA_NV;
                    m_txt_dia_diem.Text = m_us_v_gd_cong_tac.strDIA_DIEM;
                    m_txt_mo_ta_cong_viec.Text = m_us_v_gd_cong_tac.strMO_TA_CONG_VIEC;
                    m_dat_ngay_di.Value = m_us_v_gd_cong_tac.datNGAY_DI;
                    m_dat_ngay_ve.Value = m_us_v_gd_cong_tac.datNGAY_VE;
                    chon_nhan_su();
                    break;
                case DataEntryFormMode.ViewDataState:
                    break;
                default:
                    break;
            }
        }
        private void chon_nhan_su()
        {
            string[] v_strs = m_txt_tim_kiem_nhan_vien.Text.Split('-');
            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            m_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds_dm_nhan_su, v_strs[v_strs.Length - 1].Trim());
            
            if (v_ds_dm_nhan_su.Tables[0].Rows.Count == 0)
                return;
            m_us_dm_nhan_su.DataRow2Me((DataRow)v_ds_dm_nhan_su.DM_NHAN_SU.Rows[0]);
            m_lbl_ma_nhan_vien.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["MA_NV"].ToString();
            m_lbl_ho_va_ten.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["HO_DEM"] + " " +
                                   v_ds_dm_nhan_su.Tables[0].Rows[0]["TEN"];
            m_lbl_ngay_sinh.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["NGAY_SINH"].ToString().Split(' ')[0];
            m_lbl_dia_chi.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["CHO_O"].ToString();
        }
        private void auto_suggest_text()
        {
            US_DM_NHAN_SU us_dm_nhan_su = new US_DM_NHAN_SU();
            DS_DM_NHAN_SU ds_dm_nhan_su = new DS_DM_NHAN_SU();
            us_dm_nhan_su.FillDataset(ds_dm_nhan_su);
            var v_acsc_search = new AutoCompleteStringCollection();
            foreach (var v_rows in ds_dm_nhan_su.DM_NHAN_SU)
            {
                v_acsc_search.Add(v_rows[DM_NHAN_SU.HO_DEM] + " - " + v_rows[DM_NHAN_SU.TEN] + " - " + v_rows[DM_NHAN_SU.MA_NV]);
                v_acsc_search.Add(v_rows[DM_NHAN_SU.TEN] + " - " + v_rows[DM_NHAN_SU.HO_DEM] + " " + v_rows[DM_NHAN_SU.TEN] + " - " + v_rows[DM_NHAN_SU.MA_NV]);
                v_acsc_search.Add(v_rows[DM_NHAN_SU.MA_NV] + " - " + v_rows[DM_NHAN_SU.HO_DEM] + " " + v_rows[DM_NHAN_SU.TEN] + " - " + v_rows[DM_NHAN_SU.MA_NV]);
            }
            m_txt_tim_kiem_nhan_vien.AutoCompleteCustomSource = v_acsc_search;
        }
        private void save_data()
        {
            form_2_us_object();
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    m_us_gd_cong_tac.Insert();
                    break;
                case DataEntryFormMode.SelectDataState:
                    break;
                case DataEntryFormMode.UpdateDataState:
                    m_us_gd_cong_tac.Update();
                    break;
                case DataEntryFormMode.ViewDataState:
                    break;
                default:
                    break;
            }
            this.Close();

        }
        private void xoa_trang()
        {
            m_txt_dia_diem.Text = "";
            m_txt_mo_ta_cong_viec.Text = "";
            m_dat_ngay_di.Value = DateTime.Today;
            m_txt_tim_kiem_nhan_vien.Text = "";
        }
        private void set_define_event()
        {
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            m_cmd_refresh.Click += new EventHandler(m_cmd_refresh_Click);
            m_txt_tim_kiem_nhan_vien.Leave += new EventHandler(m_txt_tim_kiem_nhan_vien_Leave);
            m_txt_tim_kiem_nhan_vien.TextChanged += new EventHandler(m_txt_tim_kiem_nhan_vien_TextChanged);
        }
        #endregion

        private void m_dat_ngay_di_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                m_dat_ngay_ve.Value = m_dat_ngay_di.Value;
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        #region Events
        private void f206_v_gd_cong_tac_de_de_Load(object sender, EventArgs e)
        {
            try
            {
                set_inital_form_load();
                set_define_event();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_save_Click(object sender, EventArgs e)
        {
            try
            {
                save_data();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                xoa_trang();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_txt_tim_kiem_nhan_vien_Leave(object sender, EventArgs e)
        {
            try
            {
                chon_nhan_su();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_tim_kiem_nhan_vien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                chon_nhan_su();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion

       
    }
}

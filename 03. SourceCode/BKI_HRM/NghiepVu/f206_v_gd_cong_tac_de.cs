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

namespace BKI_HRM
{
    public partial class f206_v_gd_cong_tac_de : Form
    {

        #region Public Interfaces
        public f206_v_gd_cong_tac_de()
        {
            InitializeComponent();
            format_controls();
        }
        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.Show();
        }
        public void display_for_update(US_V_GD_CONG_TAC ip_us)
        {
            m_us_v_gd_cong_tac = ip_us;
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form();
            this.Show();

        }
        #endregion
        #region Data Structs
        private enum e_col_Number
        {
            NGAY_DI = 4
,
            MO_TA_CONG_VIEC = 7
                ,
            DIA_DIEM = 6
                ,
            MA_NV = 1
                ,
            NGAY_VE = 5
                ,

            HO_DEM = 2
                ,
            TEN = 3

        }
        #endregion
        #region Members
        ITransferDataRow m_obj_trans;
        US_V_GD_CONG_TAC m_us_v_gd_cong_tac = new US_V_GD_CONG_TAC();
        DS_V_GD_CONG_TAC m_ds_v_gd_cong_tac = new DS_V_GD_CONG_TAC();
        US_GD_CONG_TAC m_us_gd_cong_tac = new US_GD_CONG_TAC();
        DS_GD_CONG_TAC m_ds_gd_cong_tac = new DS_GD_CONG_TAC();
        US_DM_QUYET_DINH m_us_dm_quyet_dinh = new US_DM_QUYET_DINH();
        DS_DM_QUYET_DINH m_ds_dm_quyet_dinh = new DS_DM_QUYET_DINH();
        DataEntryFormMode m_e_form_mode = new DataEntryFormMode();
        bool m_b_check_quyet_dinh_save;
        bool m_b_check_quyet_dinh_null = false;
        #endregion

        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            this.KeyPreview = true;
            load_cbo_ma_quyet_dinh();
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

        }
        private void generate_ma_quyet_dinh()
        {
            m_lbl_ma_qd.Text = string.Format("{0}/{1}/{2}", m_txt_ma_quyet_dinh.Text,
                                                                  m_dat_ngay_ky.Value.Year,
                                                                  m_cbo_ma_quyet_dinh.Text);
        }
        private bool check_data_is_ok()
        {
            return true;
        }
        private void form_2_us_object_quyet_dinh()
        {
            m_us_dm_quyet_dinh.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text.Trim();
            m_us_dm_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_dm_quyet_dinh.strLINK = m_ofd_openfile.FileName;
            m_us_dm_quyet_dinh.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_dm_quyet_dinh.SetNGAY_HET_HIEU_LUCNull();
            m_us_dm_quyet_dinh.datNGAY_CO_HIEU_LUC = m_us_dm_quyet_dinh.datNGAY_KY;
            m_us_dm_quyet_dinh.dcID_LOAI_QD = CIPConvert.ToDecimal(TU_DIEN.QD_CONG_TAC);
        }
        private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_GD_CONG_TAC.NGAY_DI, e_col_Number.NGAY_DI);
            v_htb.Add(V_GD_CONG_TAC.MO_TA_CONG_VIEC, e_col_Number.MO_TA_CONG_VIEC);
            v_htb.Add(V_GD_CONG_TAC.DIA_DIEM, e_col_Number.DIA_DIEM);
            v_htb.Add(V_GD_CONG_TAC.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_GD_CONG_TAC.NGAY_VE, e_col_Number.NGAY_VE);

            v_htb.Add(V_GD_CONG_TAC.HO_DEM, e_col_Number.HO_DEM);
            v_htb.Add(V_GD_CONG_TAC.TEN, e_col_Number.TEN);


            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds_v_gd_cong_tac.V_GD_CONG_TAC.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid()
        {
            m_ds_v_gd_cong_tac = new DS_V_GD_CONG_TAC();

            m_us_v_gd_cong_tac.FillDatasetSearch(m_ds_v_gd_cong_tac, m_us_v_gd_cong_tac.strMA_QUYET_DINH, DateTime.Parse("1/1/1900"), DateTime.Today);
            m_fg.Redraw = false;
            m_obj_trans = get_trans_object(m_fg);
            CGridUtils.Dataset2C1Grid(m_ds_v_gd_cong_tac, m_fg, m_obj_trans);
            m_fg.Redraw = true;
        }
        private void us_object_2_form()
        {
            // m_b_check_quyet_dinh_save = false;
            m_grb_quyet_dinh.Enabled = true;

            string[] v_arstr = m_us_v_gd_cong_tac.strMA_QUYET_DINH.Trim().Split('/');
            m_ofd_openfile.FileName = m_us_v_gd_cong_tac.strLINK;
            m_txt_ma_quyet_dinh.Text = v_arstr[0];
            US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
            decimal v_dc_id = 0;
            v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
            m_cbo_ma_quyet_dinh.SelectedValue = v_dc_id;
            m_txt_loai_quyet_dinh.Text = "QĐ Đi công tác";
            m_dat_ngay_ky.Value = m_us_v_gd_cong_tac.datNGAY_KY;
            m_txt_noi_dung.Text = m_us_v_gd_cong_tac.strNOI_DUNG;
           
            load_data_2_grid();
        }

        private void save_data()
        {

        }
        private void chon_file()
        {
            m_ofd_openfile.Filter = "(*.pdf)|*.pdf|(*.doc)|*.doc|(*.docx)|*.docx|(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            m_ofd_openfile.Multiselect = false;
            m_ofd_openfile.Title = "Chọn tài liệu đính kèm";
            DialogResult result = m_ofd_openfile.ShowDialog();
        }
        private void mo_file()
        {
            Process.Start("explorer.exe", m_ofd_openfile.FileName);
        }
        private void set_define_event()
        {
            m_cmd_chon_file.Click += new EventHandler(m_cmd_chon_file_Click);
            m_cmd_xem_file.Click += new EventHandler(m_cmd_xem_file_Click);
            m_cmd_them_quyet_dinh.Click += new EventHandler(m_cmd_them_quyet_dinh_Click);
            m_cmd_chon_quyet_dinh.Click += new EventHandler(m_cmd_chon_quyet_dinh_Click);
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            m_fg.Click += new EventHandler(m_fg_Click);

        }
        private void them_quyet_dinh()
        {
            m_b_check_quyet_dinh_save = true;
            m_grb_quyet_dinh.Enabled = true;
            m_txt_ma_quyet_dinh.Focus();
        }
        private void chon_quyet_dinh()
        {
            m_b_check_quyet_dinh_save = false;
            m_grb_quyet_dinh.Enabled = true;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data(ref m_us_dm_quyet_dinh);
            if (m_us_dm_quyet_dinh.dcID != -1)
            {
                string[] v_arstr = m_us_dm_quyet_dinh.strMA_QUYET_DINH.Trim().Split('/');
                m_ofd_openfile.FileName = m_us_dm_quyet_dinh.strLINK;
                m_txt_ma_quyet_dinh.Text = v_arstr[0];
                US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
                DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
                decimal v_dc_id = 0;
                v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
                m_cbo_ma_quyet_dinh.SelectedValue = v_dc_id;
                m_txt_loai_quyet_dinh.Text = "QĐ Đi công tác";
                m_dat_ngay_ky.Value = m_us_dm_quyet_dinh.datNGAY_KY;
                m_txt_noi_dung.Text = m_us_dm_quyet_dinh.strNOI_DUNG;
               
            }
            else
            {
                m_b_check_quyet_dinh_null = true;
            }
        }

        private void load_cbo_ma_quyet_dinh()
        {
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.MA_QUYET_DINH
                , WinFormControls.eTAT_CA.NO
                , m_cbo_ma_quyet_dinh);
        }
        private void us_object2grid(US_V_GD_CONG_TAC i_us
            , int i_grid_row)
        {
            DataRow v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            i_us.Me2DataRow(v_dr);
            m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
        }
        #endregion



        #region Events
        private void f206_v_gd_cong_tac_de_Load(object sender, EventArgs e)
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

        private void m_txt_ma_quyet_dinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_ma_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_dat_ngay_ky_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_xem_file_Click(object sender, EventArgs e)
        {
            try
            {
                mo_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_chon_file_Click(object sender, EventArgs e)
        {
            try
            {
                chon_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_them_quyet_dinh_Click(object sender, EventArgs e)
        {
            try
            {
                them_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_chon_quyet_dinh_Click(object sender, EventArgs e)
        {
            try
            {
                chon_quyet_dinh();
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
        private void m_fg_Click(object sender, EventArgs e)
        {
            US_V_GD_CONG_TAC v_us = new US_V_GD_CONG_TAC();
            F206_chi_tiet_cong_tac v_frm = new F206_chi_tiet_cong_tac();
            v_frm.display(ref v_us);
            us_object2grid(v_us, m_fg.Row);
        }
        #endregion


    }


}

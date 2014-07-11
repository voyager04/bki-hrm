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
using IP.Core.IPException;


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
                , ID = 8
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
        US_V_DM_NHAN_SU m_us_v_dm_nhan_su = new US_V_DM_NHAN_SU();
        DS_V_DM_NHAN_SU m_ds_v_dm_nhan_su = new DS_V_DM_NHAN_SU();
        DataEntryFormMode m_e_form_mode = new DataEntryFormMode();
        bool m_b_check_quyet_dinh_save;
        bool m_b_check_quyet_dinh_null = false;

        // File explorer
        private DataEntryFileMode m_e_file_mode;
        private string m_str_domain = ConfigurationSettings.AppSettings["DOMAIN"];
        private string m_str_directory_to = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private string m_str_user_name = ConfigurationSettings.AppSettings["USERNAME_SHARE"];
        private string m_str_password = ConfigurationSettings.AppSettings["PASSWORD_SHARE"];
        private decimal m_str_id_hop_dong_old;
        private string m_str_link_old;
        
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
            m_us_v_dm_nhan_su.FillDataset(m_ds_v_dm_nhan_su);
        }
        private void generate_ma_quyet_dinh()
        {
            m_lbl_ma_qd.Text = string.Format("{0}/{1}/{2}", m_txt_ma_quyet_dinh.Text,
                                                                  m_dat_ngay_ky.Value.Year,
                                                                  m_cbo_ma_quyet_dinh.Text);
        }
        private bool check_is_trung_ma_quyet_dinh()
        {
            DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
            US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
            v_us.FillDataset_By_Ma_qd(v_ds, m_lbl_ma_qd.Text);
            if (m_b_check_quyet_dinh_save)
            {
                switch (m_e_form_mode)
                {
                    case DataEntryFormMode.InsertDataState:

                        if (v_ds.DM_QUYET_DINH.Count > 0)
                        {
                            return true;
                        }
                        break;
                    case DataEntryFormMode.SelectDataState:
                        if (v_ds.DM_QUYET_DINH.Count > 0 && m_lbl_ma_qd.Text != m_us_v_gd_cong_tac.strMA_QUYET_DINH)
                        {
                            return true;
                        }
                        break;
                    case DataEntryFormMode.UpdateDataState:
                        break;
                    case DataEntryFormMode.ViewDataState:
                        break;
                    default:
                        break;
                }
            }
            
            return false;
        }
        private bool check_data_is_ok()
        {
            if (m_txt_ma_quyet_dinh.Text.Trim() == "")
            {
                BaseMessages.MsgBox_Error("Bạn chưa nhập mã quyết định.");
                return false;
            }
            if (m_dat_ngay_ky.Value.Date > DateTime.Today.Date)
            {
                BaseMessages.MsgBox_Error("Ngày ký không hợp lệ.");
                return false;
            }
            
            return true;
        }
        private void form_2_us_object_quyet_dinh()
        {
            if (m_e_form_mode == DataEntryFormMode.UpdateDataState)
            {
                m_us_dm_quyet_dinh.dcID = m_us_v_gd_cong_tac.dcID_QUYET_DINH;
            }
            m_us_dm_quyet_dinh.strMA_QUYET_DINH = m_lbl_ma_qd.Text;
            m_us_dm_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_dm_quyet_dinh.strLINK = m_lbl_file_name.Text;
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
            v_htb.Add(V_GD_CONG_TAC.ID, e_col_Number.ID);
            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds_v_gd_cong_tac.V_GD_CONG_TAC.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid()
        {
            m_fg.AllowAddNew = false;
            m_ds_v_gd_cong_tac = new DS_V_GD_CONG_TAC();
            m_us_v_gd_cong_tac.FillDatasetSearch(m_ds_v_gd_cong_tac, 
                                                 m_us_dm_quyet_dinh.strMA_QUYET_DINH, 
                                                 DateTime.Parse("1/1/1900"), 
                                                 DateTime.Today.AddDays(1),
                                                 CAppContext_201.getCurrentIDPhapnhan());
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
            m_ofd_chon_file.FileName = m_us_v_gd_cong_tac.strLINK;
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
        private void save_quyet_dinh()
        {
            if (check_data_is_ok())
            {
                // Xử lý file đính kèm
                switch (m_e_file_mode)
                {
                    case DataEntryFileMode.UploadFile:
                        if (FileExplorer.IsExistedFile(m_str_directory_to + FileExplorer.fileName))
                        {
                            BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                            return;
                        }
                        FileExplorer.UploadFile(m_str_domain, m_str_directory_to, m_str_user_name, m_str_password);
                        break;
                    case DataEntryFileMode.EditFile:
                        if (FileExplorer.IsExistedFile(m_str_directory_to + FileExplorer.fileName))
                        {
                            BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                            return;
                        }
                        if (FileExplorer.IsExistedFile(m_str_directory_to + m_str_link_old))
                            FileExplorer.DeleteFile(m_str_directory_to + m_str_link_old);
                        FileExplorer.UploadFile(m_str_domain, m_str_directory_to, m_str_user_name, m_str_password);
                        break;
                    case DataEntryFileMode.DeleteFile:
                        if (FileExplorer.IsExistedFile(m_str_directory_to + m_str_link_old) == false)
                        {
                            BaseMessages.MsgBox_Infor("File không tồn tại!");
                            return;
                        }
                        FileExplorer.DeleteFile(m_str_directory_to + m_str_link_old);
                        break;
                }
                switch (m_e_form_mode)
                {
                    case DataEntryFormMode.InsertDataState:
                        if (m_b_check_quyet_dinh_save)
                        {
                            form_2_us_object_quyet_dinh();
                            m_us_dm_quyet_dinh.Insert();
                        }
                        break;
                }
            }

            BaseMessages.MsgBox_Infor("Thêm quyết định thành công.");
        }

        
        private void mo_file()
        {
            Process.Start("explorer.exe", m_ofd_chon_file.FileName);
        }

        private void them_quyet_dinh()
        {
            m_pnl_control_quyet_dinh.Visible = true;
            m_b_check_quyet_dinh_save = true;
            m_grb_quyet_dinh.Enabled = true;
            m_txt_ma_quyet_dinh.Focus();
        }
        private void chon_quyet_dinh()
        {
            m_pnl_control_quyet_dinh.Visible = false;
            m_b_check_quyet_dinh_save = false;
            m_grb_quyet_dinh.Enabled = true;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data("Đi công tác", ref m_us_dm_quyet_dinh);
            if (m_us_dm_quyet_dinh.dcID != -1)
            {
                string[] v_arstr = m_us_dm_quyet_dinh.strMA_QUYET_DINH.Trim().Split('/');
                m_ofd_chon_file.FileName = m_us_dm_quyet_dinh.strLINK;
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


        private void chon_file()
        {
            FileExplorer.SelectFile(m_ofd_chon_file, m_str_link_old);
            m_str_link_old = m_lbl_file_name.Text;
            if (m_str_link_old != "")
                m_e_file_mode = DataEntryFileMode.EditFile;
            else
                m_e_file_mode = DataEntryFileMode.UploadFile;
            m_lbl_file_name.Text = FileExplorer.fileName;
        }
        private void grid2us_object(US_V_GD_CONG_TAC i_us
            , int i_grid_row)
        {
            DataRow v_dr;
            v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            m_obj_trans.GridRow2DataRow(i_grid_row, v_dr);
            i_us.DataRow2Me(v_dr);
        }
        private void them_nhan_vien()
        {
            f206_v_gd_cong_tac_de_de v_frm = new f206_v_gd_cong_tac_de_de();
            v_frm.display_for_insert(m_us_dm_quyet_dinh);

            load_data_2_grid();
        }
        private void sua_nhan_vien(int i_row)
        {
            US_V_GD_CONG_TAC v_us = new US_V_GD_CONG_TAC();
            DataRow v_dr = (DataRow)m_fg.Rows[i_row].UserData;
            v_us.DataRow2Me(v_dr);
            f206_v_gd_cong_tac_de_de v_frm = new f206_v_gd_cong_tac_de_de();
            v_frm.display_for_update(v_us);
        }

        private void delete_v_gd_cong_tac()
        {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted) return;
            US_V_GD_CONG_TAC v_us = new US_V_GD_CONG_TAC();
            grid2us_object(v_us, m_fg.Row);
            try
            {
                v_us.BeginTransaction();
                v_us.Delete();
                v_us.CommitTransaction();
                m_fg.Rows.Remove(m_fg.Row);
                BaseMessages.MsgBox_Infor("Xóa thành công.");
            }
            catch (Exception v_e)
            {
                v_us.Rollback();
                CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e,
                    new CDBClientDBExceptionInterpret());
                v_objErrHandler.showErrorMessage();
            }
        }
        private void set_define_event()
        {
            m_cmd_xem_file.Click += new EventHandler(m_cmd_xem_file_Click);
            m_cmd_them_quyet_dinh.Click += new EventHandler(m_cmd_them_quyet_dinh_Click);
            m_cmd_chon_quyet_dinh.Click += new EventHandler(m_cmd_chon_quyet_dinh_Click);
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_txt_ma_quyet_dinh.Leave += new EventHandler(m_txt_ma_quyet_dinh_Leave);
            m_cmd_save_qd.Click += new EventHandler(m_cmd_save_qd_Click);
            m_cmd_insert.Click += new EventHandler(m_cmd_insert_Click);
            m_cmd_update.Click += new EventHandler(m_cmd_update_Click);
            m_cmd_delete.Click += new EventHandler(m_cmd_delete_Click);
           
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
                if (!check_is_trung_ma_quyet_dinh())
                {
                    m_txt_ma_quyet_dinh.BackColor = Color.White;
                    
                }
                
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_txt_ma_quyet_dinh_Leave(object sender, EventArgs e) 
        {
            if (check_is_trung_ma_quyet_dinh())
            {
                BaseMessages.MsgBox_Error("Mã quyết định đã tồn tại.");
                m_txt_ma_quyet_dinh.Focus();
                m_txt_ma_quyet_dinh.BackColor = Color.Red;
            }
            else
            {
                m_txt_ma_quyet_dinh.BackColor = Color.White;
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
        private void m_cmd_save_qd_Click(object sender, EventArgs e)
        {
            try
            {
                save_quyet_dinh();
                
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_delete_Click(object sender, EventArgs e)
        {
            try
            {
                delete_v_gd_cong_tac();
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


        private void m_cmd_chon_file_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (check_data_is_ok() == false) return;
                chon_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_go_dinh_kem_Click(object sender, EventArgs e)
        {
            try
            {
                m_e_file_mode = DataEntryFileMode.DeleteFile;
                m_str_link_old = m_lbl_file_name.Text;
                m_lbl_file_name.Text = "";
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_insert_Click(object sender, EventArgs e)
        {
            try
            {
                them_nhan_vien();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_update_Click(object sender, EventArgs e)
        {
            try
            {
                sua_nhan_vien(m_fg.Row);
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion


    }


}

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
using BKI_HRM.NghiepVu;
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
            m_e_file_mode = DataEntryFileMode.UploadFile;
            this.ShowDialog();
            m_str_ma_quyet_dinh = m_txt_ma_quyet_dinh.Text;
        }

        public void display_for_update(US_V_GD_CONG_TAC ip_us)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_grb_quyet_dinh.Enabled = true;
            us_quyet_dinh_to_form(ip_us);
            this.ShowDialog();
        }

        public string lay_ma_quyet_dinh_vua_insert()
        {
            return m_str_ma_quyet_dinh;
        }
        #endregion

        #region Data Structs
        private enum e_col_Number
        {
            MA_NV = 1,
            HO_DEM = 2,
            TEN = 3,
            NGAY_DI = 4,
            NGAY_VE = 5,
            DIA_DIEM = 6,
            MO_TA_CONG_VIEC = 7,
            ID_NHAN_SU = 8,
        }
        #endregion

        #region Members
        ITransferDataRow m_obj_trans;
        US_V_GD_CONG_TAC m_us_v_gd_cong_tac = new US_V_GD_CONG_TAC();
        DS_V_GD_CONG_TAC m_ds_v_gd_cong_tac = new DS_V_GD_CONG_TAC();
        US_DM_QUYET_DINH m_us_dm_quyet_dinh = new US_DM_QUYET_DINH();
        US_V_DM_NHAN_SU m_us_v_dm_nhan_su = new US_V_DM_NHAN_SU();
        DS_V_DM_NHAN_SU m_ds_v_dm_nhan_su = new DS_V_DM_NHAN_SU();
        DataEntryFormMode m_e_form_mode = new DataEntryFormMode();
        bool m_b_check_quyet_dinh_save;
        private string m_str_ma_quyet_dinh_old;
        private string m_str_ma_quyet_dinh;

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
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            this.KeyPreview = true;
        }

        private void set_inital_form_load()
        {
            m_obj_trans = get_trans_object(m_fg);
            m_us_v_dm_nhan_su.FillDataset(m_ds_v_dm_nhan_su);
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
            v_htb.Add(V_GD_CONG_TAC.ID_NHAN_SU, e_col_Number.ID_NHAN_SU);
            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds_v_gd_cong_tac.V_GD_CONG_TAC.NewRow());
            return v_obj_trans;
        }

        private void us_object2grid(US_V_GD_CONG_TAC i_us, int i_grid_row)
        {
            DataRow v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            i_us.Me2DataRow(v_dr);
            m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
        }

        private void grid2us_object(US_V_GD_CONG_TAC i_us, int i_grid_row)
        {
            DataRow v_dr;
            v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            m_obj_trans.GridRow2DataRow(i_grid_row, v_dr);
            i_us.DataRow2Me(v_dr);
        }

        //private void load_data_2_grid()
        //{
        //    m_fg.AllowAddNew = false;
        //    m_ds_v_gd_cong_tac = new DS_V_GD_CONG_TAC();
        //    m_us_v_gd_cong_tac.FillDatasetSearch(m_ds_v_gd_cong_tac,
        //                                         m_us_dm_quyet_dinh.strMA_QUYET_DINH,
        //                                         DateTime.Parse("1/1/1900"),
        //                                         DateTime.Today.AddDays(1),
        //                                         CAppContext_201.getCurrentIDPhapnhan());
        //    m_fg.Redraw = false;
        //    m_obj_trans = get_trans_object(m_fg);
        //    CGridUtils.Dataset2C1Grid(m_ds_v_gd_cong_tac, m_fg, m_obj_trans);
        //    m_fg.Redraw = true;
        //}

        private void form_2_us_object_quyet_dinh()
        {
            m_us_v_gd_cong_tac.dcID_QUYET_DINH = m_us_dm_quyet_dinh.dcID;
            m_us_v_gd_cong_tac.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text;
            m_us_v_gd_cong_tac.dcID_LOAI_QD = CIPConvert.ToDecimal(TU_DIEN.QD_CONG_TAC);
            m_us_v_gd_cong_tac.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_v_gd_cong_tac.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value;
            m_us_v_gd_cong_tac.strLINK = m_lbl_file_name.Text;
            m_us_v_gd_cong_tac.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_v_gd_cong_tac.SetNGAY_HET_HIEU_LUCNull();
        }

        private void form_to_us_cong_tac(US_GD_CONG_TAC op_us, US_V_GD_CONG_TAC ip_us)
        {
            if (m_e_form_mode == DataEntryFormMode.InsertDataState)
                op_us.dcID_QUYET_DINH = ip_us.dcID;
            if (m_e_form_mode == DataEntryFormMode.UpdateDataState)
                op_us.dcID_QUYET_DINH = ip_us.dcID_QUYET_DINH;
        }

        private void form_to_us_quyet_dinh_phap_nhan(US_GD_QUYET_DINH_PHAP_NHAN op_us, US_V_GD_CONG_TAC ip_us)
        {
            op_us.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
            op_us.dcID_QUYET_DINH = ip_us.dcID;
        }

        private void us_quyet_dinh_to_form(US_V_GD_CONG_TAC ip_us)
        {
            m_us_dm_quyet_dinh = new US_DM_QUYET_DINH(ip_us.dcID_QUYET_DINH);
            m_str_ma_quyet_dinh_old = ip_us.strMA_QUYET_DINH;

            m_txt_ma_quyet_dinh.Text = ip_us.strMA_QUYET_DINH.Trim();
            m_txt_loai_quyet_dinh.Text = new US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(TU_DIEN.QD_CONG_TAC)).strTEN;
            m_dat_ngay_ky.Value = ip_us.datNGAY_KY;
            m_dat_ngay_co_hieu_luc.Value = ip_us.datNGAY_CO_HIEU_LUC;
            m_lbl_file_name.Text = ip_us.strLINK;
            m_txt_noi_dung.Text = ip_us.strNOI_DUNG;

            load_data_to_grid_nhan_su(ip_us);
        }

        private void load_data_to_grid_nhan_su(US_V_GD_CONG_TAC ip_us)
        {
            US_V_GD_CONG_TAC v_us = new US_V_GD_CONG_TAC();
            DS_V_GD_CONG_TAC v_ds = new DS_V_GD_CONG_TAC();
            v_us.FillDatasetSearchByIdQuyetDinh(v_ds, ip_us.dcID_QUYET_DINH);
            if (v_ds.V_GD_CONG_TAC.Rows.Count < 1)
                return;
            CGridUtils.Dataset2C1Grid(v_ds, m_fg, get_trans_object(m_fg));
            m_fg.Rows.Add();
        }

        private void add_new_nhan_su_to_grid(US_V_GD_CONG_TAC ip_us, int ip_index)
        {
            DS_V_GD_CONG_TAC v_ds = new DS_V_GD_CONG_TAC();
            var v_dr = v_ds.V_GD_CONG_TAC.NewRow();
            v_dr[V_GD_CONG_TAC.MA_NV] = ip_us.strMA_NV;
            v_dr[V_GD_CONG_TAC.HO_DEM] = ip_us.strHO_DEM;
            v_dr[V_GD_CONG_TAC.TEN] = ip_us.strTEN;
            v_dr[V_GD_CONG_TAC.NGAY_DI] = ip_us.datNGAY_DI;
            v_dr[V_GD_CONG_TAC.NGAY_VE] = ip_us.datNGAY_VE;
            v_dr[V_GD_CONG_TAC.DIA_DIEM] = ip_us.strDIA_DIEM;
            v_dr[V_GD_CONG_TAC.NOI_DUNG] = ip_us.strNOI_DUNG;
            v_dr[V_GD_CONG_TAC.ID_NHAN_SU] = ip_us.dcID_NHAN_SU;
            ip_us.Me2DataRow(v_dr);
            m_obj_trans.DataRow2GridRow(v_dr, ip_index);
            v_dr[V_GD_CONG_TAC.MA_QUYET_DINH] = m_txt_ma_quyet_dinh.Text;
            m_fg.Rows[ip_index].UserData = v_dr;
        }

        private bool check_is_trung_ma_quyet_dinh()
        {
            DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
            US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
            v_us.FillDataset_By_Ma_qd(v_ds, m_txt_ma_quyet_dinh.Text);
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
                        if (v_ds.DM_QUYET_DINH.Count > 0 && m_txt_ma_quyet_dinh.Text != m_us_v_gd_cong_tac.strMA_QUYET_DINH)
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

        private bool is_exist_quyet_dinh(string ip_str_ma_quyet_dinh)
        {
            US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
            DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
            v_us.FillDataset_By_Ma_qd(v_ds, ip_str_ma_quyet_dinh);
            if (v_ds.DM_QUYET_DINH.Rows.Count > 0)
                return true;
            return false;
        }

        private void save_quyet_dinh()
        {
            if (check_data_is_ok() == false)
                return;

            try
            {
                m_us_v_gd_cong_tac.BeginTransaction();

                #region Xử lý file đính kèm
                switch (m_e_file_mode)
                {
                    case DataEntryFileMode.UploadFile:
                        // Kiểm tra file đã tồn tại trên server hay chưa
                        if (FileExplorer.IsExistedFile(m_str_directory_to + FileExplorer.fileName))
                        {
                            BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                            return;
                        }

                        // Nếu đã chọn file 
                        if (m_lbl_file_name.Text != "")
                        {
                            // Upload server có sử dụng user và pass
                            if (m_str_user_name != "")
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to, m_str_user_name, m_str_password);
                            // Upload không sử dụng user và pass
                            else
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to);
                        }
                        break;
                    case DataEntryFileMode.EditFile:
                        // Nếu ko up lên file mới sẽ bỏ qua bước này
                        if (m_str_link_old != m_lbl_file_name.Text)
                        {
                            // Kiểm tra file vừa upload đã tồn tại hay chưa
                            if (FileExplorer.IsExistedFile(m_str_directory_to + FileExplorer.fileName))
                            {
                                BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                                return;
                            }

                            // Xóa file cũ
                            if (FileExplorer.IsExistedFile(m_str_directory_to + m_str_link_old))
                                FileExplorer.DeleteFile(m_str_directory_to + m_str_link_old);

                            // Upload file mới lên
                            if (m_str_user_name != "")
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to, m_str_user_name, m_str_password);
                            else
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to);
                        }
                        break;
                    case DataEntryFileMode.DeleteFile:
                        // Kiểm tra file có tồn tại hay không
                        if (FileExplorer.IsExistedFile(m_str_directory_to + m_str_link_old) == false)
                        {
                            BaseMessages.MsgBox_Infor("File không tồn tại!");
                            return;
                        }
                        FileExplorer.DeleteFile(m_str_directory_to + m_str_link_old);
                        break;
                }
                #endregion

                #region Xử lý Quyết định
                form_2_us_object_quyet_dinh();
                switch (m_e_form_mode)
                {
                    case DataEntryFormMode.InsertDataState:
                        if (is_exist_quyet_dinh(m_txt_ma_quyet_dinh.Text))
                        {
                            BaseMessages.MsgBox_Error("Mã quyết định đã tồn tại.");
                            m_txt_ma_quyet_dinh.Focus();
                            return;
                        }
                        m_us_v_gd_cong_tac.Insert();
                        break;
                    case DataEntryFormMode.UpdateDataState:
                        if (!m_txt_ma_quyet_dinh.Text.Equals(m_str_ma_quyet_dinh_old))
                        {
                            if (is_exist_quyet_dinh(m_txt_ma_quyet_dinh.Text))
                            {
                                BaseMessages.MsgBox_Error("Mã quyết định đã tồn tại.");
                                m_txt_ma_quyet_dinh.Focus();
                                return;
                            }
                        }
                        m_us_v_gd_cong_tac.Update();
                        break;
                }
                #endregion

                #region Xử lý nhân sự
                US_GD_CONG_TAC v_us_gd_cong_tac = new US_GD_CONG_TAC();
                v_us_gd_cong_tac.UseTransOfUSObject(m_us_v_gd_cong_tac);

                form_to_us_cong_tac(v_us_gd_cong_tac, m_us_v_gd_cong_tac);
                v_us_gd_cong_tac.DeleteByID(m_us_dm_quyet_dinh.dcID);

                for (int i = m_fg.Rows.Fixed; i < m_fg.Rows.Count - 1; i++)
                {
                    v_us_gd_cong_tac.dcID_NHAN_SU = CIPConvert.ToDecimal(m_fg[i, (int)e_col_Number.ID_NHAN_SU]);
                    v_us_gd_cong_tac.datNGAY_DI = DateTime.Parse(m_fg[i, (int)e_col_Number.NGAY_DI].ToString());
                    v_us_gd_cong_tac.datNGAY_VE = DateTime.Parse(m_fg[i, (int)e_col_Number.NGAY_VE].ToString());
                    v_us_gd_cong_tac.strDIA_DIEM = m_fg[i, (int)e_col_Number.DIA_DIEM].ToString();
                    v_us_gd_cong_tac.strMO_TA_CONG_VIEC = m_fg[i, (int)e_col_Number.MO_TA_CONG_VIEC].ToString();
                    v_us_gd_cong_tac.Insert();
                }
                #endregion

                #region Xử lý Quyết định - Pháp nhân
                US_GD_QUYET_DINH_PHAP_NHAN v_us_quyet_dinh_phap_nhan = new US_GD_QUYET_DINH_PHAP_NHAN();
                v_us_quyet_dinh_phap_nhan.UseTransOfUSObject(m_us_v_gd_cong_tac);
                form_to_us_quyet_dinh_phap_nhan(v_us_quyet_dinh_phap_nhan, m_us_v_gd_cong_tac);

                if (m_e_form_mode == DataEntryFormMode.InsertDataState)
                {
                    v_us_quyet_dinh_phap_nhan.Insert();
                }
                #endregion

                m_us_v_gd_cong_tac.CommitTransaction();
                BaseMessages.MsgBox_Infor("Lưu dữ liệu thành công.");
                this.Close();
            }
            catch (Exception)
            {
                if (m_us_v_gd_cong_tac.is_having_transaction())
                    m_us_v_gd_cong_tac.Rollback();
                throw;
            }
        }


        private void reset_form_quyet_dinh()
        {
            m_us_dm_quyet_dinh = new US_DM_QUYET_DINH();
            m_txt_ma_quyet_dinh.Text = "";
            m_dat_ngay_ky.Value = DateTime.Now;
            m_dat_ngay_co_hieu_luc.Value = DateTime.Now;
            m_txt_noi_dung.Text = "";
            m_lbl_file_name.Text = "";
        }

        private void them_quyet_dinh()
        {
            reset_form_quyet_dinh();
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_grb_quyet_dinh.Enabled = true;
            m_txt_ma_quyet_dinh.Focus();
        }

        private void chon_quyet_dinh()
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_grb_quyet_dinh.Enabled = true;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data(CHON_QUYET_DINH.CONG_TAC, ref m_us_dm_quyet_dinh);

            if (m_us_dm_quyet_dinh.dcID == -1) return;
            m_grb_quyet_dinh.Enabled = false;

            // Dùng QĐ vừa có để lấy ra Quyết định công tác (GD_CONG_TAC)
            var v_us = new US_V_GD_CONG_TAC();
            var v_ds = new DS_V_GD_CONG_TAC();
            v_us.FillDatasetSearchByIdQuyetDinh(v_ds, m_us_dm_quyet_dinh.dcID);
            v_us.DataRow2Me(v_ds.V_GD_CONG_TAC.Rows[0]);
            us_quyet_dinh_to_form(v_us);
        }



        private void them_nhan_su()
        {
            if (m_txt_ma_quyet_dinh.Text.Trim().Length == 0)
            {
                BaseMessages.MsgBox_Error("Bạn chưa nhập mã Quyết định");
                return;
            }
            f206_v_gd_cong_tac_de_de v_frm = new f206_v_gd_cong_tac_de_de();
            v_frm.display_for_insert(m_txt_ma_quyet_dinh.Text);
            US_V_GD_CONG_TAC v_us = new US_V_GD_CONG_TAC();
            if (v_frm.handling_object(v_us) == DataEntryFormMode.InsertDataState)
            {
                add_new_nhan_su_to_grid(v_us, m_fg.Rows.Count - 1);
                m_fg.Rows.Add();
            }

        }

        private void sua_nhan_su()
        {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            if (m_fg.Row == m_fg.Rows.Count - 1)
                return;
            grid2us_object(m_us_v_gd_cong_tac, m_fg.Row);
            f206_v_gd_cong_tac_de_de v_frm = new f206_v_gd_cong_tac_de_de();
            v_frm.display_for_update(m_us_v_gd_cong_tac);
            if (v_frm.handling_object(m_us_v_gd_cong_tac) == DataEntryFormMode.UpdateDataState)
            {
                add_new_nhan_su_to_grid(m_us_v_gd_cong_tac, m_fg.Row);
            }
        }

        private void xoa_nhan_su()
        {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            if (m_fg.Row == m_fg.Rows.Count - 1)
                return;
            m_fg.Rows.Remove(m_fg.Row);
        }


        // Xử lý file
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

        private void view_quyet_dinh_saved()
        {
            f701_v_gd_hop_dong_lao_dong_View frm = new f701_v_gd_hop_dong_lao_dong_View();
            frm.display(ConfigurationSettings.AppSettings["DESTINATION_NAME"] + m_us_dm_quyet_dinh.strLINK);
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

        private void m_cmd_xem_file_Click(object sender, EventArgs e)
        {
            try
            {
                view_quyet_dinh_saved();
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
                xoa_nhan_su();
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
                them_nhan_su();
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
                sua_nhan_su();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion
    }
}

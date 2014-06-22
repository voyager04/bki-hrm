using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using IP.Core.IPCommon;
using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using IP.Core.IPUserService;
using IP.Core.IPData;

namespace BKI_HRM.NghiepVu
{
    public partial class F500_gd_chi_tiet_du_an_de : Form
    {
        #region public Interface
        public void display_for_insert(string ip_str_ma_du_an)
        {
            // insert 1 nhân viên vào dự án
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            load_data_2_control();
            m_txt_ma_du_an.Text = ip_str_ma_du_an;
            this.ShowDialog();
        }

        public void display_for_insert(US_DM_NHAN_SU ip_us_dm_nhan_su)
        {
            // insert 1 nhân viên từ f201
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            load_data_2_control();
            m_txt_ma_ns.Text = ip_us_dm_nhan_su.strMA_NV;
            m_txt_ma_ns.BackColor = SystemColors.Info;
            m_txt_ma_ns.ReadOnly = true;
            m_txt_ma_du_an.ReadOnly = false;
            m_txt_ma_du_an.Enabled = true;
            this.ShowDialog();
        }

        public void display_for_update(decimal i_dc_id_gd_chi_tiet_du_an, US_V_DM_DU_AN_QUYET_DINH_TU_DIEN m_op_v_dm_da_qd_td)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            load_data_2_control();
            us_obj_2_form(i_dc_id_gd_chi_tiet_du_an);
            m_us.dcID = i_dc_id_gd_chi_tiet_du_an;
            this.ShowDialog();
        }

        public F500_gd_chi_tiet_du_an_de()
        {
            InitializeComponent();
            format_control();
            auto_suggest_text();
        }
        #endregion

        #region Members
        US_GD_CHI_TIET_DU_AN m_us = new US_GD_CHI_TIET_DU_AN();
        DS_GD_CHI_TIET_DU_AN m_ds = new DS_GD_CHI_TIET_DU_AN();
        US_DM_QUYET_DINH m_us_quyet_dinh = new US_DM_QUYET_DINH();
        DataEntryFormMode m_e_form_mode;
        bool m_b_check_quyet_dinh_save;
        bool m_b_check_quyet_dinh_null = false;
        private string m_str_ma_qd = "";

        private DataEntryFileMode m_e_file_mode;
        private FileExplorer m_fe_file_explorer;
        private string m_str_domain = ConfigurationSettings.AppSettings["DOMAIN"];
        private string m_str_directory_to = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private decimal m_str_id_hop_dong_old;
        private string m_str_link_old;

        enum e_number
        {
            VI_TRI_DU_AN = 11,
            DANH_HIEU = 12
        }
        #endregion

        #region privateMethods
        private void format_control()
        {
            CControlFormat.setFormStyle(this);
            m_txt_ma_du_an.Enabled = false;
        }

        private void auto_suggest_text()
        {
            m_txt_ma_ns.AutoCompleteMode = AutoCompleteMode.Suggest;
            m_txt_ma_ns.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            v_us_dm_nhan_su.FillDataset_search(v_ds_dm_nhan_su, m_txt_ma_ns.Text);
            var v_rows = v_ds_dm_nhan_su.Tables[0].Rows;
            for (int i = 0; i < v_rows.Count - 1; i++)
            {
                coll.Add(v_rows[i]["HO_DEM"] + " - " + v_rows[i]["TEN"] + " - " + v_rows[i]["MA_NV"]);
                coll.Add(v_rows[i]["TEN"] + " - " + v_rows[i]["HO_DEM"] + " " + v_rows[i]["TEN"] + " - " + v_rows[i]["MA_NV"]);
            }
            m_txt_ma_ns.AutoCompleteCustomSource = coll;
        }

        private void load_data_2_control()
        {
            load_data_2_cbo_vi_tri();
            load_data_2_custom_source_ma_nv();
            load_data_2_custom_source_ma_da();
        }

        private void load_data_2_custom_source_ma_nv()
        {
            US_DM_NHAN_SU v_us = new US_DM_NHAN_SU();
            DS_DM_NHAN_SU v_ds = new DS_DM_NHAN_SU();
            v_us.FillDataset(v_ds);
            for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = v_ds.Tables[0].Rows[i];
                m_txt_ma_ns.AutoCompleteCustomSource.Add(dr["MA_NV"].ToString());
            }
        }

        private void load_data_2_custom_source_ma_da()
        {
            US_DM_DU_AN v_us = new US_DM_DU_AN();
            DS_DM_DU_AN v_ds = new DS_DM_DU_AN();
            v_us.FillDataset(v_ds);
            for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = v_ds.Tables[0].Rows[i];
                m_txt_ma_du_an.AutoCompleteCustomSource.Add(dr["MA_DU_AN"].ToString());
            }
        }

        private void load_data_2_cbo_vi_tri()
        {
            IP.Core.IPUserService.US_CM_DM_TU_DIEN v_us = new IP.Core.IPUserService.US_CM_DM_TU_DIEN();
            IP.Core.IPData.DS_CM_DM_TU_DIEN v_ds = new IP.Core.IPData.DS_CM_DM_TU_DIEN();

            v_us.FillDatasetByIdLoaiTuDien(v_ds, (int)e_number.VI_TRI_DU_AN);

            m_cbo_vi_tri.DataSource = v_ds.Tables[0];
            m_cbo_vi_tri.ValueMember = CM_DM_TU_DIEN.ID;
            m_cbo_vi_tri.DisplayMember = CM_DM_TU_DIEN.TEN_NGAN;
        }

        private void datarow_2_us_obj(DataRow v_dr, US_GD_CHI_TIET_DU_AN v_us)
        {
            v_us.dcID = CIPConvert.ToDecimal(v_dr[GD_CHI_TIET_DU_AN.ID]);
            v_us.dcID_DU_AN = CIPConvert.ToDecimal(v_dr[GD_CHI_TIET_DU_AN.ID_DU_AN]);
            v_us.dcID_NHAN_SU = CIPConvert.ToDecimal(v_dr[GD_CHI_TIET_DU_AN.ID_NHAN_SU]);
            v_us.dcID_VI_TRI = CIPConvert.ToDecimal(v_dr[GD_CHI_TIET_DU_AN.ID_VI_TRI]);
            if (v_dr[GD_CHI_TIET_DU_AN.ID_DANH_HIEU].ToString() != "")
            {
                v_us.dcID_DANH_HIEU = CIPConvert.ToDecimal(v_dr[GD_CHI_TIET_DU_AN.ID_DANH_HIEU]);
            }
            if (v_dr[GD_CHI_TIET_DU_AN.THOI_GIAN_TG].ToString() != "")
            {
                v_us.dcTHOI_GIAN_TG = CIPConvert.ToDecimal(v_dr[GD_CHI_TIET_DU_AN.THOI_GIAN_TG]);
            }

            v_us.strLUA_CHON = v_dr[GD_CHI_TIET_DU_AN.LUA_CHON].ToString();
            v_us.strMO_TA = v_dr[GD_CHI_TIET_DU_AN.MO_TA].ToString();
            v_us.strTRANG_THAI_HIEN_TAI = v_dr[GD_CHI_TIET_DU_AN.TRANG_THAI_HIEN_TAI].ToString();
            if (v_dr[GD_CHI_TIET_DU_AN.THOI_DIEM_KT].ToString() != "")
            {
                v_us.datTHOI_DIEM_KT = (DateTime)v_dr[GD_CHI_TIET_DU_AN.THOI_DIEM_KT];
            }
            v_us.datTHOI_DIEM_TG = (DateTime)v_dr[GD_CHI_TIET_DU_AN.THOI_DIEM_TG];
        }

        private void us_obj_2_form(decimal i_dc_id_gd_chi_tiet_du_an)
        {
            US_GD_CHI_TIET_DU_AN v_us_gd_ct_da = new US_GD_CHI_TIET_DU_AN(i_dc_id_gd_chi_tiet_du_an);

            m_us.strTRANG_THAI_HIEN_TAI = v_us_gd_ct_da.strTRANG_THAI_HIEN_TAI;
            m_txt_mo_ta.Text = v_us_gd_ct_da.strMO_TA;
            m_cbo_vi_tri.SelectedValue = v_us_gd_ct_da.dcID_VI_TRI;
            m_dat_tham_gia.Value = v_us_gd_ct_da.datTHOI_DIEM_TG;
            m_txt_ma_ns.Text = new US_DM_NHAN_SU(v_us_gd_ct_da.dcID_NHAN_SU).strMA_NV;
            m_txt_ma_du_an.Text = new US_V_DM_DU_AN_QUYET_DINH_TU_DIEN(v_us_gd_ct_da.dcID_DU_AN).strMA_DU_AN;

            if (v_us_gd_ct_da.dcTHOI_GIAN_TG == null)
                m_txt_thoi_gian_tham_gia.Text = v_us_gd_ct_da.dcTHOI_GIAN_TG.ToString();
            else
                m_txt_thoi_gian_tham_gia.Text = "0";

            if (v_us_gd_ct_da.dcID_DANH_HIEU != null)
                m_cbo_danh_hieu.SelectedValue = v_us_gd_ct_da.dcID_DANH_HIEU;

            if (v_us_gd_ct_da.datTHOI_DIEM_KT != null)
                m_dat_ngay_kt.Value = v_us_gd_ct_da.datTHOI_DIEM_KT;
            else
                m_dat_ngay_kt.Checked = false;

            if (v_us_gd_ct_da.dcID_QUYET_DINH != 0)
            {
                m_grb_quyet_dinh.Enabled = true;
                US_DM_QUYET_DINH v_us_dm_qd = new US_DM_QUYET_DINH(v_us_gd_ct_da.dcID_QUYET_DINH);
                m_txt_ma_quyet_dinh.Text = v_us_dm_qd.strMA_QUYET_DINH;
                m_lbl_loai_qd.Text = new US.US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(TU_DIEN.QD_THANH_LAP_DU_AN)).strTEN;
                m_dat_ngay_ky.Value = v_us_dm_qd.datNGAY_KY;
                m_dat_ngay_co_hieu_luc_qd.Value = v_us_dm_qd.datNGAY_CO_HIEU_LUC;
                if (v_us_dm_qd.datNGAY_HET_HIEU_LUC != null)
                    m_dat_ngay_het_hieu_luc_qd.Value = v_us_dm_qd.datNGAY_HET_HIEU_LUC;
                m_txt_noi_dung.Text = v_us_dm_qd.strNOI_DUNG;
                m_str_ma_qd = v_us_dm_qd.strMA_QUYET_DINH;
            }
        }

        private void form_2_us_object()
        {
            m_us.dcID_VI_TRI = CIPConvert.ToDecimal(m_cbo_vi_tri.SelectedValue.ToString());
            m_us.strMO_TA = m_txt_mo_ta.Text;

            if (m_cbo_danh_hieu.SelectedValue.ToString() != "-1")
                m_us.dcID_DANH_HIEU = CIPConvert.ToDecimal(m_cbo_danh_hieu.SelectedValue.ToString());

            if (m_dat_ngay_kt.Checked)
                m_us.datTHOI_DIEM_KT = m_dat_ngay_kt.Value.Date;
            else
                m_us.SetTHOI_DIEM_KTNull();

            m_us.datTHOI_DIEM_TG = m_dat_tham_gia.Checked ? m_dat_tham_gia.Value : DateTime.Parse("01/01/1900");

            if (m_txt_thoi_gian_tham_gia.Text != "")
                m_us.dcTHOI_GIAN_TG = CIPConvert.ToDecimal(m_txt_thoi_gian_tham_gia.Text);
            else
                m_us.SetTHOI_GIAN_TGNull();

            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
            v_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds_dm_nhan_su, m_lbl_ho_dem.Text);
            if (v_ds_dm_nhan_su.Tables[0].Rows.Count != 0)
                m_us.dcID_NHAN_SU = CIPConvert.ToDecimal(v_ds_dm_nhan_su.Tables[0].Rows[0]["ID"]);


        }

        private void form_to_us_object_quyet_dinh()
        {
            m_us_quyet_dinh.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text.Trim();
            m_us_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_quyet_dinh.strLINK = m_ofd_chon_file.FileName;
            m_us_quyet_dinh.dcID_LOAI_QD = CIPConvert.ToDecimal(TU_DIEN.QD_THANH_LAP_DU_AN);
            m_us_quyet_dinh.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_quyet_dinh.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd.Value;
            if (m_dat_ngay_het_hieu_luc_qd.Checked)
                m_us_quyet_dinh.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc_qd.Value;
            else
                m_us_quyet_dinh.SetNGAY_HET_HIEU_LUCNull();
            m_str_ma_qd = m_txt_ma_quyet_dinh.Text.Trim();
        }

        private bool check_data_is_ok()
        {
            if (!m_dat_tham_gia.Checked)
            {
                MessageBox.Show("Phải có ngày tham gia");
                return false;
            }
            if (m_dat_ngay_kt.Checked)
            {
                if (m_dat_ngay_kt.Value.Date < m_dat_tham_gia.Value.Date)
                {
                    MessageBox.Show("Ngày tham gia phải có trước ngày kết thúc");
                    return false;
                }
            }
            if (m_txt_ma_du_an.Text == "")
            {
                MessageBox.Show("Phải có mã dự án");
                return false;
            }
            if (m_txt_ma_ns.Text == "")
            {
                MessageBox.Show("Phải có mã nhân sự");
                return false;
            }
            if (m_lbl_ho_dem.Text == "")
            {
                MessageBox.Show("Phải có mã nhân sự");
                return false;
            }

            if (CIPConvert.ToDecimal(m_txt_thoi_gian_tham_gia.Text) > 100 || CIPConvert.ToDecimal(m_txt_thoi_gian_tham_gia.Text) < 0)
            {
                BaseMessages.MsgBox_Infor("Thời gian tham gia dự án phải nhỏ hơn 100% và lớn hơn 0%");
                return false;
            }
            return true;
        }

        private void chon_nhan_su()
        {
            string[] v_strs = m_txt_ma_ns.Text.Split('-');
            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
            v_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds_dm_nhan_su, v_strs[v_strs.Length - 1].Trim());
            if (v_ds_dm_nhan_su.Tables[0].Rows.Count == 0)
                return;
            m_lbl_ho_dem.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["MA_NV"].ToString();
            m_lbl_ho_va_ten.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["HO_DEM"] + " " +
                                   v_ds_dm_nhan_su.Tables[0].Rows[0]["TEN"];
            m_lbl_ngay_sinh.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["NGAY_SINH"].ToString().Split(' ')[0];
            m_lbl_dia_chi.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["CHO_O"].ToString();
        }

        private void chon_quyet_dinh()
        {
            m_b_check_quyet_dinh_save = false;
            m_grb_quyet_dinh.Enabled = true;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data(ref m_us_quyet_dinh);
            if (m_us_quyet_dinh.dcID != -1)
            {

                m_ofd_chon_file.FileName = m_us_quyet_dinh.strLINK;
                m_txt_ma_quyet_dinh.Text = m_us_quyet_dinh.strMA_QUYET_DINH;

                m_lbl_loai_qd.Text = new US.US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(TU_DIEN.QD_THANH_LAP_DU_AN)).strTEN;

                m_dat_ngay_ky.Value = m_us_quyet_dinh.datNGAY_KY;
                if (m_us_quyet_dinh.datNGAY_CO_HIEU_LUC > DateTime.Parse("01/01/1900") &&
                    m_us_quyet_dinh.datNGAY_CO_HIEU_LUC != null)
                    m_dat_ngay_co_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_CO_HIEU_LUC;
                else
                    m_dat_ngay_co_hieu_luc_qd.Checked = false;
                if (m_us_quyet_dinh.datNGAY_HET_HIEU_LUC != null &&
                    m_us_quyet_dinh.datNGAY_HET_HIEU_LUC > DateTime.Parse("1/1/1900"))
                    m_dat_ngay_het_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_HET_HIEU_LUC;
                else
                    m_dat_ngay_het_hieu_luc_qd.Checked = false;
                m_txt_noi_dung.Text = m_us_quyet_dinh.strNOI_DUNG;
                m_ofd_chon_file.FileName = m_us_quyet_dinh.strLINK;

            }
            else
            {
                m_b_check_quyet_dinh_null = true;
            }
        }

        private void them_quyet_dinh()
        {
            m_b_check_quyet_dinh_save = true;
            m_grb_quyet_dinh.Enabled = true;
            m_lbl_loai_qd.Text = new US.US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(TU_DIEN.QD_THANH_LAP_DU_AN)).strTEN;
            m_txt_ma_quyet_dinh.Focus();
        }

        private void chuyen_trang_thai_ve_no(decimal dc_id_nv)
        {
            US_GD_CHI_TIET_DU_AN v_us = new US_GD_CHI_TIET_DU_AN();
            DS_GD_CHI_TIET_DU_AN v_ds = new DS_GD_CHI_TIET_DU_AN();
            v_us.FillDatasetTrangThaiYes(v_ds, dc_id_nv);
            for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
            {
                DataRow v_dr = v_ds.Tables[0].Rows[i];
                datarow_2_us_obj(v_dr, v_us);
                v_us.strTRANG_THAI_HIEN_TAI = "N";
                v_us.Update();
            }
        }

        private void chon_file()
        {
            m_fe_file_explorer = new FileExplorer(m_ofd_chon_file,
                m_str_domain,
                ConfigurationSettings.AppSettings["USERNAME_SHARE"],
                ConfigurationSettings.AppSettings["PASSWORD_SHARE"],
                ConfigurationSettings.AppSettings["DESTINATION_NAME"]);
            m_str_link_old = m_lbl_file_name.Text;
            if (m_str_link_old != "")
                m_e_file_mode = DataEntryFileMode.EditFile;
            else
                m_e_file_mode = DataEntryFileMode.UploadFile;
            m_lbl_file_name.Text = m_fe_file_explorer.fileName;
        }

        private void save_data()
        {
            if (check_data_is_ok() == false)
                return;

            // Xử lý file đính kèm
            switch (m_e_file_mode)
            {
                case DataEntryFileMode.UploadFile:
                    m_fe_file_explorer.UploadFile();
                    break;
                case DataEntryFileMode.EditFile:
                    if (FileExplorer.IsExistedFile(m_str_directory_to + m_str_link_old))
                    {
                        FileExplorer.DeleteFile(m_str_directory_to + m_str_link_old);
                    }
                    m_fe_file_explorer.UploadFile();
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

            form_2_us_object();

            US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH();
            DS_DM_QUYET_DINH v_ds_qd = new DS_DM_QUYET_DINH();
            
            m_us_quyet_dinh.dcID = m_us.dcID_QUYET_DINH;
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    // Insert nhân sự
                    chuyen_trang_thai_ve_no(m_us.dcID_NHAN_SU);
                    m_us.strTRANG_THAI_HIEN_TAI = "Y";


                    // Quyết định
                    if (m_b_check_quyet_dinh_save)
                    {
                        form_to_us_object_quyet_dinh();
                        if (m_b_check_quyet_dinh_null)
                            m_us_quyet_dinh.Insert();
                        else
                            m_us_quyet_dinh.Update();

                        v_us_qd.FillDataset_By_Ma_qd(v_ds_qd, m_us_quyet_dinh.strMA_QUYET_DINH);
                        if (v_ds_qd.Tables[0].Rows.Count != 0)
                            m_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(v_ds_qd.Tables[0].Rows[0]["ID"]);
                    }
                    m_us.Insert();
                    break;
                case DataEntryFormMode.UpdateDataState:
                    if (m_txt_ma_quyet_dinh.Text != "")
                    {
                        form_to_us_object_quyet_dinh();
                        if (m_b_check_quyet_dinh_save)
                            m_us_quyet_dinh.Insert();
                        else
                            m_us_quyet_dinh.Update();

                        v_us_qd.FillDataset_By_Ma_qd(v_ds_qd, m_us_quyet_dinh.strMA_QUYET_DINH);
                        if (v_ds_qd.Tables[0].Rows.Count != 0)
                            m_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(v_ds_qd.Tables[0].Rows[0]["ID"]);
                    }
                    m_us_quyet_dinh.Update();

                    m_us.Update();
                    break;
            }
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            this.Close();
        }

        public static void load_data_to_cbo_tu_dien(
             WinFormControls.eLOAI_TU_DIEN ip_e
            , WinFormControls.eTAT_CA ip_e_tat_ca
            , ComboBox ip_obj_cbo_trang_thai)
        {

            IP.Core.IPUserService.US_CM_DM_TU_DIEN v_us_dm_tu_dien = new IP.Core.IPUserService.US_CM_DM_TU_DIEN();
            IP.Core.IPData.DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new IP.Core.IPData.DS_CM_DM_TU_DIEN();
            string v_str_loai_tu_dien = "";
            switch (ip_e)
            {
                case WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_CHUC_VU:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_CHUC_VU;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.LOAI_HOP_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_HOP_DONG;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.LOAI_DON_VI:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_DON_VI;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.CAP_DON_VI:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.CAP_DON_VI;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_QUYET_DINH;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_LAO_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_LAO_DONG;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.NGACH:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.NGACH;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.LOAI_CHUC_VU:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_CHUC_VU;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_HOP_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_HOP_DONG;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_DU_AN:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_DU_AN;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.MA_HOP_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.MA_HOP_DONG;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.DANH_HIEU:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.DANH_HIEU;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.CO_CHE:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.CO_CHE;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.LOAI_DU_AN:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_DU_AN;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.MA_QUYET_DINH:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.MA_QUYET_DINH;
                    break;
                case WinFormControls.eLOAI_TU_DIEN.DIA_BAN:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.DIA_BAN;
                    break;
            }
            v_us_dm_tu_dien.fill_tu_dien_cung_loai_ds(
                v_str_loai_tu_dien
                , CM_DM_TU_DIEN.GHI_CHU
                , v_ds_dm_tu_dien);


            ip_obj_cbo_trang_thai.DisplayMember = CM_DM_TU_DIEN.TEN;
            ip_obj_cbo_trang_thai.ValueMember = CM_DM_TU_DIEN.ID;
            ip_obj_cbo_trang_thai.DataSource = v_ds_dm_tu_dien.CM_DM_TU_DIEN;
            if (ip_e_tat_ca == WinFormControls.eTAT_CA.YES)
            {
                DataRow v_dr = v_ds_dm_tu_dien.CM_DM_TU_DIEN.NewRow();
                v_dr[CM_DM_TU_DIEN.ID] = -1;
                v_dr[CM_DM_TU_DIEN.TEN] = "------ Không danh hiệu ------";
                v_dr[CM_DM_TU_DIEN.MA_TU_DIEN] = "";
                v_dr[CM_DM_TU_DIEN.TEN_NGAN] = "";
                v_dr[CM_DM_TU_DIEN.ID_LOAI_TU_DIEN] = 1;
                v_dr[CM_DM_TU_DIEN.GHI_CHU] = "";
                v_ds_dm_tu_dien.CM_DM_TU_DIEN.Rows.InsertAt(v_dr, 0);
                ip_obj_cbo_trang_thai.SelectedIndex = 0;
            }
        }
        #endregion

        #region eventHandle
        private void m_txt_ma_ns_TextChanged(object sender, EventArgs e)
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
            m_txt_ma_du_an.Text = "";
            m_txt_ma_ns.Text = "";
        }

        private void m_txt_ma_du_an_TextChanged(object sender, EventArgs e)
        {
            US_DM_DU_AN v_us = new US_DM_DU_AN();
            DS_DM_DU_AN v_ds = new DS_DM_DU_AN();
            v_us.FillDataset_search_by_ma_da(v_ds, m_txt_ma_du_an.Text);
            if (v_ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = v_ds.Tables[0].Rows[0];
                m_us.dcID_DU_AN = CIPConvert.ToDecimal(dr["ID"].ToString());
            }
        }

        private void m_txt_ma_ns_Leave(object sender, EventArgs e)
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

        private void F500_gd_chi_tiet_du_an_de_Load(object sender, EventArgs e)
        {
            load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.DANH_HIEU, WinFormControls.eTAT_CA.YES, m_cbo_danh_hieu);
        }
        #endregion

        private void m_cmd_chon_file_Click(object sender, EventArgs e)
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

        private void m_cmd_xem_file_Click(object sender, EventArgs e)
        {
            f701_v_gd_hop_dong_lao_dong_View frm = new f701_v_gd_hop_dong_lao_dong_View();
            frm.display_for_view_quyet_dinh(m_us_quyet_dinh);
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
    }
}

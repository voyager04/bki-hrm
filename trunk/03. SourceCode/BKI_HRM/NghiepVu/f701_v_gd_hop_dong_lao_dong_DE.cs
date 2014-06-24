using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPWordReport;
using System.Net.NetworkInformation;

namespace BKI_HRM.NghiepVu
{
    public partial class f701_v_gd_hop_dong_lao_dong_DE : Form
    {
        #region Public Interfaces
        public f701_v_gd_hop_dong_lao_dong_DE()
        {

            InitializeComponent();
            auto_suggest_text();
            CControlFormat.setFormStyle(this);
            load_data_2_cbo_loai_hop_dong();
            load_data_2_cbo_phap_nhan();
            m_cbo_trang_thai.SelectedIndex = 0;
        }

        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.ShowDialog();
        }

        public void display_for_insert(US_DM_NHAN_SU ip_m_us_dm_nhan_su)
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_us_dm_nhan_su = ip_m_us_dm_nhan_su;
            view_info_Nhan_Su();
            this.ShowDialog();
        }

        public void display_for_update(US_GD_HOP_DONG ip_m_us_gd_hop_dong)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form(ip_m_us_gd_hop_dong);
            m_str_id_hop_dong_old = ip_m_us_gd_hop_dong.dcID;
            m_txt_tim_kiem_nhan_vien.Enabled = false;
            this.ShowDialog();
        }
        #endregion

        #region Data Structures
        #endregion

        #region Member
        private DataEntryFormMode m_e_form_mode;
        
        US_GD_HOP_DONG m_us = new US_GD_HOP_DONG();
        DS_GD_HOP_DONG m_ds = new DS_GD_HOP_DONG();
        US_V_GD_HOP_DONG_LAO_DONG m_us_v = new US_V_GD_HOP_DONG_LAO_DONG();
        DS_V_GD_HOP_DONG_LAO_DONG m_ds_v = new DS_V_GD_HOP_DONG_LAO_DONG();
        US_DM_NHAN_SU m_us_dm_nhan_su = new US_DM_NHAN_SU();

        private DataEntryFileMode m_e_file_mode;
        private string m_str_domain = ConfigurationSettings.AppSettings["DOMAIN"];
        private string m_str_directory_to = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private string m_str_user_name = ConfigurationSettings.AppSettings["USERNAME_SHARE"];
        private string m_str_password = ConfigurationSettings.AppSettings["PASSWORD_SHARE"];
        private decimal m_str_id_hop_dong_old;
        private string m_str_link_old;
        #endregion

        #region Private Methods
        private bool check_data_is_ok()
        {
            if (m_txt_ma_hop_dong.Text == "")
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập Mã Hợp Đồng.");
                return false;
            }

            if (!Regex.IsMatch(m_txt_ma_hop_dong.Text, "^[0-9]+$"))
            {
                BaseMessages.MsgBox_Infor("Bạn nhập Mã Hợp Đồng chưa đúng định dạng");
                return false;
            }

            if (!Regex.IsMatch(m_txt_nguoi_ky.Text, "[A-z0-9]*"))
            {
                BaseMessages.MsgBox_Infor("Bạn nhập tên người ký chưa đúng định dạng");
                return false;
            }

            if (!Regex.IsMatch(m_txt_chuc_vu_nguoi_ky.Text, "[A-z0-9]*"))
            {
                BaseMessages.MsgBox_Infor("Bạn nhập chức vụ người ký chưa đúng định dạng");
                return false;
            }

            if (m_lbl_ma_nhan_vien.Text == "")
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập Mã Nhân Viên.");
                return false;
            }


            if ((m_dat_ngay_co_hieu_luc.Value - m_dat_ngay_ky_hop_dong.Value).TotalHours < -1)
            {
                BaseMessages.MsgBox_Infor("Ngày ký Hợp Đồng không thể lớn hơn ngày Hợp Đồng có hiệu lực.");
                return false;
            }

            if ((m_dat_ngay_het_han.Value - m_dat_ngay_ky_hop_dong.Value).TotalHours < -1)
            {
                BaseMessages.MsgBox_Infor("Ngày ký Hợp Đồng không thể lớn hơn ngày Hợp Đồng hết hạn.");
                return false;
            }

            if ((m_dat_ngay_het_han.Value - m_dat_ngay_co_hieu_luc.Value).TotalHours < -1)
            {
                BaseMessages.MsgBox_Infor("Ngày Hợp Đồng có hiệu lực không thể lớn hơn ngày Hợp Đồng hết hạn.");
                return false;
            }
            return true;
        }

        private void form_2_us_object()
        {
            m_us.strMA_HOP_DONG = string.Format("{0}/{1}/{2}", m_txt_ma_hop_dong.Text.Trim(),
                                                                  m_dat_ngay_co_hieu_luc.Value.Year,
                                                                  m_cbo_ma_hop_dong.Text);
            m_us.dcID_LOAI_HOP_DONG = (decimal)m_cbo_loai_hop_dong.SelectedValue;
            m_us.dcID_PHAP_NHAN = (decimal)m_cbo_phap_nhan.SelectedValue;
            m_us.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value;
            m_us.strTRANG_THAI_HOP_DONG = m_cbo_trang_thai.SelectedIndex.Equals(0) ? "Y" : "N";
            m_us.strNGUOI_KY = m_txt_nguoi_ky.Text.Trim();
            m_us.strCHUC_VU_NGUOI_KY = m_txt_chuc_vu_nguoi_ky.Text.Trim();
            m_us.datNGAY_KY_HOP_DONG = m_dat_ngay_ky_hop_dong.Value;
            
            if (m_us_dm_nhan_su.dcID == -1)
            {
                DS_DM_NHAN_SU m_ds_dm_nhan_su = new DS_DM_NHAN_SU();
                m_us_dm_nhan_su.FillDataset_search_by_ma_nv(m_ds_dm_nhan_su, m_lbl_ma_nhan_vien.Text);
                m_us.dcID_NHAN_SU = (decimal)m_ds_dm_nhan_su.Tables[0].Rows[0].ItemArray[0];
            }
            else
            {
                m_us.dcID_NHAN_SU = m_us_dm_nhan_su.dcID;
            }


            if (m_dat_ngay_het_han.Checked == false)
                m_us.SetNGAY_HET_HANNull();
            else
                m_us.datNGAY_HET_HAN = m_dat_ngay_het_han.Value;

            m_us.strLINK = m_lbl_file_name.Text;
        }

        private void save_data()
        {
            if (check_data_is_ok() == false)
                return;

            // Xử lý file đính kèm
            switch (m_e_file_mode)
            {
                case DataEntryFileMode.UploadFile:
                    FileExplorer.UploadFile(m_str_domain, m_str_directory_to, m_str_user_name, m_str_password);
                    break;
                case DataEntryFileMode.EditFile:
                    if (FileExplorer.IsExistedFile(m_str_directory_to + m_str_link_old))
                    {
                        FileExplorer.DeleteFile(m_str_directory_to + m_str_link_old);
                    }
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


            form_2_us_object();
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    if (check_trung_ma_hop_dong(m_txt_ma_hop_dong.Text))
                    {
                        BaseMessages.MsgBox_Error("Mã hợp đồng đã tồn tại.");
                        m_txt_ma_hop_dong.Focus();
                        return;
                    }
                    DS_GD_HOP_DONG ds_gd_hd = new DS_GD_HOP_DONG();
                    US_GD_HOP_DONG us_gd_hd = new US_GD_HOP_DONG();
                    us_gd_hd.FillDataSet_Search_by_trang_thai_hop_dong(ds_gd_hd, "Y", m_us.dcID_NHAN_SU);
                    var v_i_total_record = ds_gd_hd.Tables[0].Rows.Count;
                    if (v_i_total_record > 0)
                    {
                        foreach (var item in ds_gd_hd.GD_HOP_DONG)
                        {
                            us_gd_hd.dcID = item.ID;
                            us_gd_hd.Upload_trang_thai_hop_dong(us_gd_hd);
                        }
                    }
                    m_us.Insert();
                    break;
                    
                case DataEntryFormMode.UpdateDataState:
                    US_GD_HOP_DONG v_us_gd_hop_dong = new US_GD_HOP_DONG(m_str_id_hop_dong_old);
                    if (!m_txt_ma_hop_dong.Text.Equals(v_us_gd_hop_dong.strMA_HOP_DONG))
                    {
                        if (check_trung_ma_hop_dong(m_txt_ma_hop_dong.Text))
                        {
                            BaseMessages.MsgBox_Error("Mã hợp đồng đã tồn tại.");
                            m_txt_ma_hop_dong.Focus();
                            return;
                        }
                    }
                    m_us.Update();
                    break;
            }
            f701_v_hop_dong_lao_dong.m_str_ma_hop_dong = m_txt_ma_hop_dong.Text;
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            this.Close();
        }

        private void view_info_Nhan_Su()
        {
            m_lbl_ma_nhan_vien.Text = m_us_dm_nhan_su.strMA_NV;
            m_lbl_ho_va_ten.Text = m_us_dm_nhan_su.strHO_DEM + " " + m_us_dm_nhan_su.strTEN;
            m_lbl_ngay_sinh.Text = m_us_dm_nhan_su.datNGAY_SINH.ToShortDateString();
            m_lbl_dia_chi.Text = m_us_dm_nhan_su.strCHO_O;
        }

        private void us_object_2_form(US_GD_HOP_DONG ip_us_gd_hop_dong)
        {
            m_us.dcID = ip_us_gd_hop_dong.dcID;


            m_txt_ma_hop_dong.Text = ip_us_gd_hop_dong.strMA_HOP_DONG.Split('/')[0];

            m_txt_nguoi_ky.Text = ip_us_gd_hop_dong.strNGUOI_KY;
            m_txt_chuc_vu_nguoi_ky.Text = ip_us_gd_hop_dong.strCHUC_VU_NGUOI_KY;
            m_dat_ngay_co_hieu_luc.Value = ip_us_gd_hop_dong.datNGAY_CO_HIEU_LUC;
            m_dat_ngay_ky_hop_dong.Value = ip_us_gd_hop_dong.datNGAY_KY_HOP_DONG;

            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU(ip_us_gd_hop_dong.dcID_NHAN_SU);
            m_lbl_ma_nhan_vien.Text = v_us_dm_nhan_su.strMA_NV;
            m_lbl_ho_va_ten.Text = v_us_dm_nhan_su.strHO_DEM + " " + v_us_dm_nhan_su.strTEN;
            m_lbl_ngay_sinh.Text = v_us_dm_nhan_su.datNGAY_SINH.ToShortDateString();
            m_lbl_dia_chi.Text = v_us_dm_nhan_su.strCHO_O;

            m_cbo_loai_hop_dong.SelectedValue = ip_us_gd_hop_dong.dcID_LOAI_HOP_DONG;
            m_cbo_trang_thai.SelectedIndex = (ip_us_gd_hop_dong.strTRANG_THAI_HOP_DONG.Equals("Y")) ? 0 : 1;
            m_cbo_phap_nhan.SelectedValue = ip_us_gd_hop_dong.dcID_PHAP_NHAN;

            if (ip_us_gd_hop_dong.datNGAY_HET_HAN.Equals(DateTime.Parse("1/1/1900 12:00:00 AM")))
            {
                m_dat_ngay_het_han.Checked = false;
            }
            else
            {
                m_dat_ngay_het_han.Value = ip_us_gd_hop_dong.datNGAY_HET_HAN;
                m_dat_ngay_het_han.Checked = true;
            }
            if (ip_us_gd_hop_dong.strLINK == "") return;
            m_lbl_file_name.Text = ip_us_gd_hop_dong.strLINK;
        }

        private void load_data_2_cbo_loai_hop_dong()
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_td = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_td = new US_CM_DM_TU_DIEN();
            v_us_cm_dm_td.FillDatasetByIdLoaiTuDien(v_ds_cm_dm_td, 6);
            m_cbo_loai_hop_dong.DataSource = v_ds_cm_dm_td.Tables[0];
            m_cbo_loai_hop_dong.DisplayMember = CM_DM_TU_DIEN.TEN_NGAN;
            m_cbo_loai_hop_dong.ValueMember = CM_DM_TU_DIEN.ID;
        }

        private void load_data_2_cbo_phap_nhan()
        {
            DS_DM_PHAP_NHAN v_ds_dm_phap_nhan = new DS_DM_PHAP_NHAN();
            US_DM_PHAP_NHAN v_us_dm_phap_nhan = new US_DM_PHAP_NHAN();
            v_us_dm_phap_nhan.FillDataset(v_ds_dm_phap_nhan);
            m_cbo_phap_nhan.DataSource = v_ds_dm_phap_nhan.Tables[0];
            m_cbo_phap_nhan.DisplayMember = DM_PHAP_NHAN.TEN_PHAP_NHAN;
            m_cbo_phap_nhan.ValueMember = DM_PHAP_NHAN.ID;
        }

        private void chon_nhan_su()
        {
            string[] v_strs = m_txt_tim_kiem_nhan_vien.Text.Split('-');
            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            m_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds_dm_nhan_su, v_strs[v_strs.Length - 1].Trim());
            if (v_ds_dm_nhan_su.Tables[0].Rows.Count == 0)
                return;
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

        private void chon_file()
        {
            FileExplorer.SelectFile(m_ofd_chon_file);
            m_str_link_old = m_lbl_file_name.Text;
            if (m_str_link_old != "")
                m_e_file_mode = DataEntryFileMode.EditFile;
            else
                m_e_file_mode = DataEntryFileMode.UploadFile;
            m_lbl_file_name.Text = FileExplorer.fileName;
        }

        private bool check_trung_ma_hop_dong(string ip_str_ma_hop_dong)
        {

            DS_GD_HOP_DONG v_ds = new DS_GD_HOP_DONG();
            m_us.FillDatasetSearchByMaHopDong(v_ds, ip_str_ma_hop_dong);
            decimal count_ma_hop_dong = v_ds.GD_HOP_DONG.Count;
            if (count_ma_hop_dong > 0)
                return true;
            return false;
        }

        private void generate_ma_hop_dong()
        {
            m_lbl_ma_hop_dong.Text = string.Format("{0}/{1}/{2}", m_txt_ma_hop_dong.Text,
                                                                  m_dat_ngay_co_hieu_luc.Value.Year,
                                                                  m_cbo_ma_hop_dong.Text);
        }

        private void xuat_word()
        {
            US_GD_HOP_DONG v_us_gd_hop_dong = new US_GD_HOP_DONG(m_us.dcID);
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU(v_us_gd_hop_dong.dcID_NHAN_SU);
            US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN(v_us_gd_hop_dong.dcID_LOAI_HOP_DONG);
            m_sfd_in_hop_dong.Filter = "(*.doc)|*.doc|(*.docx)|*.docx";
            m_sfd_in_hop_dong.Title = "Lưu Hợp Đồng Lao Động";
            DialogResult result = m_sfd_in_hop_dong.ShowDialog();
            if (result == DialogResult.OK)
            {
                CWordReport v_obj_word = new CWordReport("THR_Hopdonglaodong_KTH_v2_TU.docx", m_sfd_in_hop_dong.FileName);

                v_obj_word.AddFindAndReplace("<HO_TEN>", v_us_dm_nhan_su.strHO_DEM + " " + v_us_dm_nhan_su.strTEN);
                if (v_us_dm_nhan_su.datNGAY_SINH > DateTime.Parse("1/1/1900") && v_us_dm_nhan_su.datNGAY_SINH != null)
                    v_obj_word.AddFindAndReplace("<NGAY_SINH>", v_us_dm_nhan_su.datNGAY_SINH.ToShortDateString());
                else
                    v_obj_word.AddFindAndReplace("<NGAY_SINH>", "");
                v_obj_word.AddFindAndReplace("<CHO_O>", v_us_dm_nhan_su.strCHO_O);
                v_obj_word.AddFindAndReplace("<CMTND>", v_us_dm_nhan_su.strCMND);
                v_obj_word.AddFindAndReplace("<NGAY_CAP>", v_us_dm_nhan_su.datNGAY_CAP_CMND.ToShortDateString());
                v_obj_word.AddFindAndReplace("<NOI_CAP>", v_us_dm_nhan_su.strNOI_CAP_CMND);
                v_obj_word.AddFindAndReplace("<MOBILE>", v_us_dm_nhan_su.strDI_DONG);
                v_obj_word.AddFindAndReplace("<LOAI_HOP_DONG>", v_us_tu_dien.strTEN);
                v_obj_word.AddFindAndReplace("<NGAY_KY>", v_us_gd_hop_dong.datNGAY_KY_HOP_DONG.ToShortDateString());
                v_obj_word.AddFindAndReplace("<CHUYEN_NGANH>", v_us_dm_nhan_su.strCHUYEN_NGANH);
                v_obj_word.AddFindAndReplace("<MA_PHONG>", "...");
                v_obj_word.AddFindAndReplace("<MA_BAN>", "...");
                v_obj_word.AddFindAndReplace("<MA_NHAN_VIEN>", v_us_dm_nhan_su.strMA_NV);

                if (v_us_gd_hop_dong.datNGAY_KY_HOP_DONG > DateTime.Parse("1/1/1900") && v_us_gd_hop_dong.datNGAY_KY_HOP_DONG != null)
                {
                    v_obj_word.AddFindAndReplace("<NGAY>", v_us_gd_hop_dong.datNGAY_KY_HOP_DONG.Day.ToString());
                    v_obj_word.AddFindAndReplace("<THANG>", v_us_gd_hop_dong.datNGAY_KY_HOP_DONG.Month.ToString());
                    v_obj_word.AddFindAndReplace("<NAM>", v_us_gd_hop_dong.datNGAY_KY_HOP_DONG.Year.ToString());
                }
                else
                {
                    v_obj_word.AddFindAndReplace("<NGAY>", "...");
                    v_obj_word.AddFindAndReplace("<THANG>", "...");
                    v_obj_word.AddFindAndReplace("<NAM>", "...");
                    v_obj_word.Export2Word("", false);
                }
            }
        }

        private void xoatrang()
        {
            m_txt_ma_hop_dong.Text = "";
            m_txt_nguoi_ky.Text = "";
            m_txt_chuc_vu_nguoi_ky.Text = "";
            m_txt_tim_kiem_nhan_vien.Text = "";
            m_lbl_file_name.Text = "";

            m_cbo_loai_hop_dong.SelectedIndex = 0;
            m_cbo_trang_thai.SelectedIndex = 0;
            m_cbo_phap_nhan.SelectedIndex = 0;
            m_dat_ngay_co_hieu_luc.Value = DateTime.Now;
            m_dat_ngay_het_han.Value = DateTime.Now;
            m_dat_ngay_ky_hop_dong.Value = DateTime.Now;
        }
        #endregion

        #region Event
        private void f701_v_gd_hop_dong_lao_dong_DE_Load(object sender, EventArgs e)
        {
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.MA_HOP_DONG, WinFormControls.eTAT_CA.NO, m_cbo_ma_hop_dong);
            m_txt_ma_hop_dong.Focus();
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

        private void m_cmd_exit_Click_1(object sender, EventArgs e)
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

        private void m_cmd_xuat_word_Click(object sender, EventArgs e)
        {
            try
            {
                xuat_word();
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

        private void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                xoatrang();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bo_dinh_kem_Click(object sender, EventArgs e)
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

        private void m_txt_ma_hop_dong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_hop_dong();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_ma_hop_dong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_hop_dong();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion
    }
}



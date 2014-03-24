using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using BKI_HRM.DS;
using IP.Core.IPCommon;

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

        public void display_for_update(US_GD_HOP_DONG ip_m_us_gd_hop_dong)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form(ip_m_us_gd_hop_dong);
            m_str_id_hop_dong_old = ip_m_us_gd_hop_dong.dcID;
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
        private string m_str_destination = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private string m_str_path = "";
        private string m_str_file_name = "";
        private string m_str_origination = "";
        private string m_str_old_path = "";
        private decimal m_str_id_hop_dong_old;
        #endregion

        #region Private Methods
        private bool check_data_is_ok()
        {
            if (m_txt_ma_hop_dong.Text == "")
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập Mã Hợp Đồng");
                return false;
            }

            if (m_lbl_ma_nhan_vien.Text == "")
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập Mã Nhân Viên");
                return false;
            }
            return true;
        }

        private void form_2_us_object()
        {
            m_us.strMA_HOP_DONG = m_txt_ma_hop_dong.Text;
            m_us.dcID_LOAI_HOP_DONG = (decimal)m_cbo_loai_hop_dong.SelectedValue;
            m_us.dcID_PHAP_NHAN = (decimal) m_cbo_phap_nhan.SelectedValue;
            m_us.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc.Value;
            m_us.strTRANG_THAI_HOP_DONG = m_cbo_trang_thai.SelectedIndex.Equals(0) ? "Y" : "N";
            m_us.strLINK = m_str_destination + m_lbl_file_name.Text;
            m_us.strNGUOI_KY = m_txt_nguoi_ky.Text;
            m_us.strCHUC_VU_NGUOI_KY = m_txt_chuc_vu_nguoi_ky.Text;
            m_us.datNGAY_KY_HOP_DONG = m_dat_ngay_ky_hop_dong.Value;

            DS_DM_NHAN_SU m_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            m_us_dm_nhan_su.FillDataset_search_by_ma_nv(m_ds_dm_nhan_su, m_lbl_ma_nhan_vien.Text);
            m_us.dcID_NHAN_SU = (decimal)m_ds_dm_nhan_su.Tables[0].Rows[0].ItemArray[0];

            if (m_dat_ngay_het_han.Checked == false)
                m_us.SetNGAY_HET_HANNull();
            else
                m_us.datNGAY_HET_HAN = m_dat_ngay_het_han.Value;
        }

        private void save_data()
        {
            if (check_data_is_ok() == false)
                return;

            form_2_us_object();
            upload_file();
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    if (check_trung_ma_hop_dong(m_txt_ma_hop_dong.Text))
                    {
                        BaseMessages.MsgBox_Error("Mã hợp đồng đã tồn tại.");
                        m_txt_ma_hop_dong.Focus();
                        return;
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
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            this.Close();
        }

        private void us_object_2_form(US_GD_HOP_DONG ip_us_gd_hop_dong)
        {
            m_us.dcID = ip_us_gd_hop_dong.dcID;
            m_txt_ma_hop_dong.Text = ip_us_gd_hop_dong.strMA_HOP_DONG;
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
            string[] v_strs = ip_us_gd_hop_dong.strLINK.Split('\\');
            m_lbl_file_name.Text = v_strs[v_strs.Length - 1];
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
            m_txt_tim_kiem_nhan_vien.AutoCompleteMode = AutoCompleteMode.Suggest;
            m_txt_tim_kiem_nhan_vien.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            v_us_dm_nhan_su.FillDataset_search(v_ds_dm_nhan_su, m_txt_tim_kiem_nhan_vien.Text);
            var v_rows = v_ds_dm_nhan_su.Tables[0].Rows;
            for (int i = 0; i < v_rows.Count - 1; i++)
            {
                coll.Add(v_rows[i]["HO_DEM"] + " - " + v_rows[i]["TEN"] + " - " + v_rows[i]["MA_NV"]);
                coll.Add(v_rows[i]["TEN"] + " - " + v_rows[i]["HO_DEM"] + " " + v_rows[i]["TEN"] + " - " + v_rows[i]["MA_NV"]);
            }
            m_txt_tim_kiem_nhan_vien.AutoCompleteCustomSource = coll;
        }

        private void chon_file()
        {
            m_str_old_path = m_str_destination + m_lbl_file_name.Text;
            int v_i_file_size = 5096000;
            m_ofd_chon_file.Filter = "(*.*)|*.*";
            m_ofd_chon_file.Multiselect = false;
            m_ofd_chon_file.Title = "Chọn file";
            m_ofd_chon_file.FileName = "";
            DialogResult result = m_ofd_chon_file.ShowDialog();
            if (result != DialogResult.OK) return;

            if (new FileInfo(m_ofd_chon_file.FileName).Length > v_i_file_size)
            {
                BaseMessages.MsgBox_Infor("File đính kèm quá lớn. \nVui lòng chọn file có dung lượng < 5Mb");
                return;
            }
            m_lbl_file_name.Text = m_ofd_chon_file.SafeFileName;
            m_str_file_name = m_ofd_chon_file.SafeFileName;
            m_str_origination = m_ofd_chon_file.FileName;
        }

        private void upload_file()
        {
            if (m_str_file_name == "")
                return;
            string v_str_path_destination = m_str_destination + m_str_file_name;
            m_str_path = m_str_destination + "TOPICA" + "-" + m_str_file_name;
            File.Copy(m_str_origination, v_str_path_destination);
            File.Move(m_str_destination + m_str_file_name, m_str_path);
            if (File.Exists(m_str_old_path))
                File.Delete(m_str_old_path);
            m_us.strLINK = m_str_file_name;
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

        //TODO : generate mã hợp đồng
        private void generate_ma_hop_dong()
        {

        }

        //TODO : xuất word
        private void xuat_word()
        {

        }
        #endregion

        #region Event
        private void f701_v_gd_hop_dong_lao_dong_DE_Load(object sender, EventArgs e)
        {
            generate_ma_hop_dong();
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
        #endregion
    }
}



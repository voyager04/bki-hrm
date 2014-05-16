using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public void display_for_update(decimal i_dc_id_gd_chi_tiet_du_an)
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

        private void us_obj_2_form(decimal i_dc_id_gd_chi_tiet_du_an)
        {
            US_GD_CHI_TIET_DU_AN v_us = new US_GD_CHI_TIET_DU_AN();
            DS_GD_CHI_TIET_DU_AN v_ds = new DS_GD_CHI_TIET_DU_AN();
            v_us.FillDatasetByID(v_ds, i_dc_id_gd_chi_tiet_du_an);
            DataRow v_dr = v_ds.Tables[0].Rows[0];

            m_us.strTRANG_THAI_HIEN_TAI = v_dr[GD_CHI_TIET_DU_AN.TRANG_THAI_HIEN_TAI].ToString();

            m_txt_mo_ta.Text = v_dr["MO_TA"].ToString();
            m_cbo_vi_tri.SelectedValue = CIPConvert.ToDecimal(v_dr["ID_VI_TRI"].ToString());
            if (v_dr["ID_DANH_HIEU"].ToString() != "")
            {
                m_cbo_danh_hieu.SelectedValue = CIPConvert.ToDecimal(v_dr["ID_DANH_HIEU"].ToString());
            }
            if (v_dr[GD_CHI_TIET_DU_AN.THOI_DIEM_KT].ToString() != "")
            {
                DateTime v_dat = (DateTime)v_dr[GD_CHI_TIET_DU_AN.THOI_DIEM_KT];
                m_dat_ngay_kt.Value = (DateTime)v_dr["THOI_DIEM_KT"];
            }
            else
            {
                m_dat_ngay_kt.Checked = false;
            }

            m_dat_tham_gia.Value = (DateTime)v_dr["THOI_DIEM_TG"];

            m_txt_thoi_gian_tham_gia.Text = v_dr[GD_CHI_TIET_DU_AN.THOI_GIAN_TG].ToString();


            US_DM_NHAN_SU v_us_dm_ns = new US_DM_NHAN_SU();
            DS_DM_NHAN_SU v_ds_dm_ns = new DS_DM_NHAN_SU();
            US_DM_DU_AN v_us_dm_du_an = new US_DM_DU_AN();
            DS_DM_DU_AN v_ds_dm_du_an = new DS_DM_DU_AN();

            v_us_dm_ns.FillDatasetByID(v_ds_dm_ns, CIPConvert.ToDecimal(v_dr["ID_NHAN_SU"].ToString()));
            v_us_dm_du_an.FillDatasetByID(v_ds_dm_du_an, CIPConvert.ToDecimal(v_dr["ID_DU_AN"].ToString()));

            v_dr = v_ds_dm_ns.Tables[0].Rows[0];
            m_txt_ma_ns.Text = v_dr["MA_NV"].ToString();

            v_dr = v_ds_dm_du_an.Tables[0].Rows[0];
            m_txt_ma_du_an.Text = v_dr["MA_DU_AN"].ToString();
        }

        private void save_data()
        {
            if (check_data_is_ok() == false)
            {
                return;
            }
            form_2_us_object();
            US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH();
            DS_DM_QUYET_DINH v_ds_qd = new DS_DM_QUYET_DINH();
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    // Insert nhân sự
                    chuyen_trang_thai_ve_no(m_us.dcID_NHAN_SU);
                    m_us.strTRANG_THAI_HIEN_TAI = "Y";
                    

                    // insert quyết định
                    form_to_us_object_quyet_dinh();
                    if (m_b_check_quyet_dinh_save)
                    {
                        if (m_b_check_quyet_dinh_null)
                            m_us_quyet_dinh.Insert();
                        else
                            m_us_quyet_dinh.Update();
                    }
                    
                    v_us_qd.FillDataset_By_Ma_qd(v_ds_qd, m_str_ma_qd);
                    m_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(v_ds_qd.Tables[0].Rows[0]["ID"]);
                    m_us.Insert();
                    break;
                case DataEntryFormMode.UpdateDataState:
                    if (m_txt_ma_quyet_dinh.Text != "")
                    {
                        form_to_us_object_quyet_dinh();
                        if (m_b_check_quyet_dinh_save)
                        {
                            m_us_quyet_dinh.Insert();
                        }
                        v_us_qd.FillDataset_By_Ma_qd(v_ds_qd, m_str_ma_qd);
                        m_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(v_ds_qd.Tables[0].Rows[0]["ID"]);
                    }
                    m_us.Update();
                    break;
            }
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            this.Close();
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

        private void form_2_us_object()
        {
            m_us.dcID_DANH_HIEU = CIPConvert.ToDecimal(m_cbo_danh_hieu.SelectedValue.ToString());
            m_us.dcID_VI_TRI = CIPConvert.ToDecimal(m_cbo_vi_tri.SelectedValue.ToString());
            if (m_dat_ngay_kt.Checked)
                m_us.datTHOI_DIEM_KT = m_dat_ngay_kt.Value.Date;
            else
                m_us.SetTHOI_DIEM_KTNull();

            if (m_dat_tham_gia.Checked)
                m_us.datTHOI_DIEM_TG = m_dat_tham_gia.Value;
            else
                m_us.datTHOI_DIEM_TG = DateTime.Parse("01/01/1900");

            if (m_txt_thoi_gian_tham_gia.Text != "")
                m_us.dcTHOI_GIAN_TG = CIPConvert.ToDecimal(m_txt_thoi_gian_tham_gia.Text);
            else
                m_us.SetTHOI_GIAN_TGNull();

            m_us.strMO_TA = m_txt_mo_ta.Text;

            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
            v_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds_dm_nhan_su, m_lbl_ho_dem.Text);
            if (v_ds_dm_nhan_su.Tables[0].Rows.Count == 0)
                return;
            m_us.dcID_NHAN_SU = CIPConvert.ToDecimal(v_ds_dm_nhan_su.Tables[0].Rows[0]["ID"]);
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
            return true;
        }

        private void load_data_2_control()
        {
            load_data_2_cbo_vi_tri();
            load_data_2_cbo_danh_hieu();
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

        private void load_data_2_cbo_danh_hieu()
        {
            IP.Core.IPUserService.US_CM_DM_TU_DIEN v_us = new IP.Core.IPUserService.US_CM_DM_TU_DIEN();
            IP.Core.IPData.DS_CM_DM_TU_DIEN v_ds = new IP.Core.IPData.DS_CM_DM_TU_DIEN();

            v_us.FillDatasetByIdLoaiTuDien(v_ds, (int)e_number.DANH_HIEU);

            m_cbo_danh_hieu.DataSource = v_ds.Tables[0];
            m_cbo_danh_hieu.ValueMember = CM_DM_TU_DIEN.ID;
            m_cbo_danh_hieu.DisplayMember = CM_DM_TU_DIEN.TEN_NGAN;
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

                m_ofd_openfile.FileName = m_us_quyet_dinh.strLINK;
                m_txt_ma_quyet_dinh.Text = m_us_quyet_dinh.strMA_QUYET_DINH;

                m_cbo_loai_quyet_dinh.SelectedValue = m_us_quyet_dinh.dcID_LOAI_QD;
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
                m_ofd_openfile.FileName = m_us_quyet_dinh.strLINK;

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
            m_txt_ma_quyet_dinh.Focus();
        }

        private void form_to_us_object_quyet_dinh()
        {
            m_us_quyet_dinh.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text.Trim();
            m_us_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_quyet_dinh.strLINK = m_ofd_openfile.FileName;
            m_us_quyet_dinh.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh.SelectedValue);
            m_us_quyet_dinh.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_quyet_dinh.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd.Value;
            if (m_dat_ngay_het_hieu_luc_qd.Checked)
                m_us_quyet_dinh.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc_qd.Value;
            else
                m_us_quyet_dinh.SetNGAY_HET_HIEU_LUCNull();
            m_str_ma_qd = m_txt_ma_quyet_dinh.Text.Trim();
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
        #endregion

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
                WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH, WinFormControls.eTAT_CA.NO, m_cbo_loai_quyet_dinh);
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
                WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH, WinFormControls.eTAT_CA.NO, m_cbo_loai_quyet_dinh);
                chon_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
}

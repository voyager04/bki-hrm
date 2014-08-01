using System;
using System.Collections;
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
using IP.Core.IPSystemAdmin;
using IP.Core.IPUserService;
using IP.Core.IPData;
using US_CM_DM_TU_DIEN = BKI_HRM.US.US_CM_DM_TU_DIEN;

namespace BKI_HRM.NghiepVu
{
    public partial class F500_gd_chi_tiet_du_an_de : Form
    {
        #region public Interface
        public void display_for_insert(US_V_DM_DU_AN_QUYET_DINH_TU_DIEN ip_us)
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_e_file_mode = DataEntryFileMode.UploadFile;
            m_e_quyet_dinh_mode = DataEntryFormMode.ViewDataState;

            m_us_quyet_dinh = new US_DM_QUYET_DINH(ip_us.dcID_QUYET_DINH);
            us_quyet_dinh_to_form(m_us_quyet_dinh);

            m_us_du_an = ip_us;
            load_data_2_control();
            this.ShowDialog();
        }

        public void display_for_insert(US_DM_NHAN_SU ip_us_dm_nhan_su)
        {
            // insert 1 nhân viên từ f201
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_e_file_mode = DataEntryFileMode.UploadFile;
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
            //m_us.dcID = i_dc_id_gd_chi_tiet_du_an;
            m_e_file_mode = DataEntryFileMode.EditFile;
            m_str_link_old = m_lbl_file_name.Text;
            m_str_ma_quyet_dinh_old = m_op_v_dm_da_qd_td.strMA_QUYET_DINH;
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
        ITransferDataRow m_obj_trans;
        DataEntryFormMode m_dgl_result = DataEntryFormMode.ViewDataState;
        US_V_DM_DU_AN_QUYET_DINH_TU_DIEN m_us_du_an = new US_V_DM_DU_AN_QUYET_DINH_TU_DIEN();
        DS_V_DM_DU_AN_QUYET_DINH_TU_DIEN m_ds_du_an = new DS_V_DM_DU_AN_QUYET_DINH_TU_DIEN();
        US_V_DM_NHAN_SU_DU_AN m_us = new US_V_DM_NHAN_SU_DU_AN();
        DS_V_DM_NHAN_SU_DU_AN m_ds = new DS_V_DM_NHAN_SU_DU_AN();

        US_DM_QUYET_DINH m_us_quyet_dinh = new US_DM_QUYET_DINH();
        private string m_str_ma_quyet_dinh_old;


        DataEntryFormMode m_e_form_mode;
        DataEntryFormMode m_e_quyet_dinh_mode;
        bool m_b_check_quyet_dinh_save;
        bool m_b_check_quyet_dinh_null = false;
        private string m_str_ma_qd = "";

        private DataEntryFileMode m_e_file_mode;
        private string m_str_domain = ConfigurationSettings.AppSettings["DOMAIN"];
        private string m_str_directory_to = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private string m_str_user_name = ConfigurationSettings.AppSettings["USERNAME_SHARE"];
        private string m_str_password = ConfigurationSettings.AppSettings["PASSWORD_SHARE"];
        private decimal m_str_id_hop_dong_old;
        private string m_str_link_old;
        #endregion

        #region Data Structure
        enum e_number
        {
            VI_TRI_DU_AN = 11,
            DANH_HIEU = 12
        }

        private enum e_col_Number_nhan_vien
        {
            HO_DEM = 1,
            TEN = 2,
            VI_TRI = 3,
            TRANG_THAI_LAO_DONG = 4,
            THOI_DIEM_TG = 5,
            THOI_DIEM_KT = 6,
            THOI_GIAN_TG = 7,
            DANH_HIEU = 8,
            MA_QUYET_DINH = 9,
            LOAI_QD = 10,
            MO_TA = 11
        }
        #endregion

        #region privateMethods
        private void format_control()
        {
            CControlFormat.setFormStyle(this);
            m_txt_ma_du_an.Enabled = false;
        }

        private void set_inital_form_load()
        {
            m_obj_trans = get_trans_object_nhan_vien(m_fg_nhan_su);
        }

        private ITransferDataRow get_trans_object_nhan_vien(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_DM_NHAN_SU_DU_AN.HO_DEM, e_col_Number_nhan_vien.HO_DEM);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.TEN, e_col_Number_nhan_vien.TEN);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.VI_TRI, e_col_Number_nhan_vien.VI_TRI);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.TRANG_THAI_LAO_DONG, e_col_Number_nhan_vien.TRANG_THAI_LAO_DONG);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_DIEM_TG, e_col_Number_nhan_vien.THOI_DIEM_TG);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_DIEM_KT, e_col_Number_nhan_vien.THOI_DIEM_KT);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.THOI_GIAN_TG, e_col_Number_nhan_vien.THOI_GIAN_TG);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.DANH_HIEU, e_col_Number_nhan_vien.DANH_HIEU);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.MA_QUYET_DINH, e_col_Number_nhan_vien.MA_QUYET_DINH);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.LOAI_QD, e_col_Number_nhan_vien.LOAI_QD);
            v_htb.Add(V_DM_NHAN_SU_DU_AN.MO_TA, e_col_Number_nhan_vien.MO_TA);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds.V_DM_NHAN_SU_DU_AN.NewRow());
            return v_obj_trans;
        }

        private void add_new_nhan_su_to_grid(US_V_DM_NHAN_SU_DU_AN ip_us, int i_grid_row)
        {
            DS_V_DM_NHAN_SU_DU_AN v_ds = new DS_V_DM_NHAN_SU_DU_AN();
            var v_dr = v_ds.V_DM_NHAN_SU_DU_AN.NewRow();
            v_dr[V_DM_NHAN_SU_DU_AN.HO_DEM] = ip_us.strHO_DEM;
            v_dr[V_DM_NHAN_SU_DU_AN.TEN] = ip_us.strTEN;
            v_dr[V_DM_NHAN_SU_DU_AN.VI_TRI] = ip_us.strVI_TRI;
            v_dr[V_DM_NHAN_SU_DU_AN.TRANG_THAI_LAO_DONG] = ip_us.strTRANG_THAI_LAO_DONG;
            v_dr[V_DM_NHAN_SU_DU_AN.THOI_DIEM_TG] = ip_us.datTHOI_DIEM_TG;
            v_dr[V_DM_NHAN_SU_DU_AN.THOI_DIEM_KT] = ip_us.datTHOI_DIEM_KT;
            v_dr[V_DM_NHAN_SU_DU_AN.THOI_GIAN_TG] = ip_us.dcTHOI_GIAN_TG;
            v_dr[V_DM_NHAN_SU_DU_AN.DANH_HIEU] = ip_us.strDANH_HIEU;
            v_dr[V_DM_NHAN_SU_DU_AN.MA_QUYET_DINH] = ip_us.strMA_QUYET_DINH;
            v_dr[V_DM_NHAN_SU_DU_AN.LOAI_QD] = ip_us.strLOAI_QD;
            v_dr[V_DM_NHAN_SU_DU_AN.MO_TA] = ip_us.strMO_TA;

            ip_us.Me2DataRow(v_dr);

            m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
        }

        private void grid2us_object(US_V_DM_NHAN_SU_DU_AN i_us, int i_grid_row)
        {
            var v_dr = (DataRow)m_fg_nhan_su.Rows[i_grid_row].UserData;
            m_obj_trans.GridRow2DataRow(i_grid_row, v_dr);
            i_us.DataRow2Me(v_dr);
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
            load_data_2_custom_source_ma_nhan_vien();
            load_data_2_custom_source_ma_du_an();
        }

        private void load_data_2_custom_source_ma_nhan_vien()
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

        private void load_data_2_custom_source_ma_du_an()
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
                m_us_quyet_dinh = new US_DM_QUYET_DINH(v_us_gd_ct_da.dcID_QUYET_DINH);
                m_txt_ma_quyet_dinh.Text = m_us_quyet_dinh.strMA_QUYET_DINH;
                m_lbl_loai_qd.Text = new US.US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(TU_DIEN.QD_THANH_LAP_DU_AN)).strTEN;
                m_dat_ngay_ky.Value = m_us_quyet_dinh.datNGAY_KY;
                m_dat_ngay_co_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_CO_HIEU_LUC;
                if (m_us_quyet_dinh.datNGAY_HET_HIEU_LUC != null)
                    m_dat_ngay_het_hieu_luc_qd.Value = m_us_quyet_dinh.datNGAY_HET_HIEU_LUC;
                m_txt_noi_dung.Text = m_us_quyet_dinh.strNOI_DUNG;
                m_str_ma_qd = m_us_quyet_dinh.strMA_QUYET_DINH;
                m_lbl_file_name.Text = m_us_quyet_dinh.strLINK;
            }
        }

        private void us_quyet_dinh_to_form(US_DM_QUYET_DINH ip_us)
        {
            m_str_ma_quyet_dinh_old = ip_us.strMA_QUYET_DINH;

            m_txt_ma_quyet_dinh.Text = ip_us.strMA_QUYET_DINH.Trim();
            m_lbl_loai_qd.Text = new US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(TU_DIEN.QD_THANH_LAP_DU_AN)).strTEN;
            m_dat_ngay_ky.Value = ip_us.datNGAY_KY;
            m_dat_ngay_co_hieu_luc_qd.Value = ip_us.datNGAY_CO_HIEU_LUC;
            if (ip_us.datNGAY_HET_HIEU_LUC > DateTime.Parse("01/01/1900"))
            {
                m_dat_ngay_het_hieu_luc_qd.Checked = true;
                m_dat_ngay_het_hieu_luc_qd.Value = ip_us.datNGAY_HET_HIEU_LUC;
            }
            else
            {
                m_dat_ngay_kt.Checked = false;
            }

            m_lbl_file_name.Text = ip_us.strLINK;
            m_txt_noi_dung.Text = ip_us.strNOI_DUNG;
        }

        private void form_2_us_nhan_vien()
        {
            m_us.dcID_DU_AN = m_us_du_an.dcID;
            m_us.strMA_DU_AN = m_us_du_an.strMA_DU_AN;
            m_us.strTEN_DU_AN = m_us_du_an.strTEN_DU_AN;


            US_DM_NHAN_SU v_us_nhan_su = new US_DM_NHAN_SU();
            DS_DM_NHAN_SU v_ds_nhan_su = new DS_DM_NHAN_SU();
            v_us_nhan_su.FillDataset_search_by_ma_nv(v_ds_nhan_su, m_lbl_ma_nhan_vien.Text);
            if (v_ds_nhan_su.DM_NHAN_SU.Rows.Count > 0)
            {
                m_us.dcID_NHAN_SU = (decimal)v_ds_nhan_su.DM_NHAN_SU.Rows[0][DM_NHAN_SU.ID];
                m_us.strMA_NV = v_ds_nhan_su.DM_NHAN_SU.Rows[0][DM_NHAN_SU.MA_NV].ToString();
                m_us.strHO_DEM = v_ds_nhan_su.DM_NHAN_SU.Rows[0][DM_NHAN_SU.HO_DEM].ToString();
                m_us.strTEN = v_ds_nhan_su.DM_NHAN_SU.Rows[0][DM_NHAN_SU.TEN].ToString();
            }

            m_us.dcID_VI_TRI = (decimal)m_cbo_vi_tri.SelectedValue;
            m_us.strVI_TRI = m_cbo_vi_tri.Text;

            US_V_GD_TRANG_THAI_LAO_DONG v_us_trang_thai_ld = new US_V_GD_TRANG_THAI_LAO_DONG();
            DS_V_GD_TRANG_THAI_LAO_DONG v_ds_trang_thai_ld = new DS_V_GD_TRANG_THAI_LAO_DONG();
            v_us_trang_thai_ld.FillDatasetByManhanvien_trang_thai_hien_tai(v_ds_trang_thai_ld, m_lbl_ma_nhan_vien.Text, CAppContext_201.getCurrentIDPhapnhan());
            if (v_ds_trang_thai_ld.V_GD_TRANG_THAI_LAO_DONG.Rows.Count > 0)
            {
                m_us.strTRANG_THAI_LAO_DONG = v_ds_trang_thai_ld.V_GD_TRANG_THAI_LAO_DONG.Rows[0][V_GD_TRANG_THAI_LAO_DONG.TRANG_THAI_LAO_DONG].ToString();
            }

            m_us.datTHOI_DIEM_TG = m_dat_tham_gia.Value;
            m_us.datTHOI_DIEM_KT = m_dat_ngay_kt.Value;
            m_us.dcTHOI_GIAN_TG = CIPConvert.ToDecimal(m_txt_thoi_gian_tham_gia.Text);

            m_us.dcID_DANH_HIEU = (decimal)m_cbo_danh_hieu.SelectedValue;
            m_us.strDANH_HIEU = m_cbo_danh_hieu.Text;

            m_us.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text;
            m_us.strLOAI_QD = m_lbl_loai_quyet_dinh.Text;
            m_us.strMO_TA = m_txt_mo_ta.Text;
        }

        private void form_to_us_quyet_dinh()
        {
            m_us.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text;
            m_us.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd.Value;
            if (m_dat_ngay_het_hieu_luc_qd.Checked)
                m_us.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc_qd.Value;
            else
                m_us.SetNGAY_HET_HIEU_LUCNull();
            m_us.strNOI_DUNG = m_txt_noi_dung.Text;
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
            if (m_lbl_ma_nhan_vien.Text == "")
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
            m_lbl_ma_nhan_vien.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["MA_NV"].ToString();
            m_lbl_ho_va_ten.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["HO_DEM"] + " " +
                                   v_ds_dm_nhan_su.Tables[0].Rows[0]["TEN"];
            m_lbl_ngay_sinh.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["NGAY_SINH"].ToString().Split(' ')[0];
            m_lbl_dia_chi.Text = v_ds_dm_nhan_su.Tables[0].Rows[0]["CHO_O"].ToString();
        }

        private void chon_quyet_dinh()
        {
            m_e_quyet_dinh_mode = DataEntryFormMode.SelectDataState;
            m_grb_quyet_dinh.Enabled = true;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            //v_frm.select_data("Tấ, ref m_us_quyet_dinh);

            if (m_us_quyet_dinh.dcID == -1) return;
            m_grb_quyet_dinh.Enabled = false;

            us_quyet_dinh_to_form(m_us_quyet_dinh);
        }

        private void reset_form_quyet_dinh()
        {
            m_us_quyet_dinh = new US_DM_QUYET_DINH();
            m_txt_ma_quyet_dinh.Text = "";
            m_dat_ngay_ky.Value = DateTime.Now;
            m_dat_ngay_co_hieu_luc_qd.Value = DateTime.Now;
            m_dat_ngay_het_hieu_luc_qd.Value = DateTime.Now;
            m_txt_noi_dung.Text = "";
            m_lbl_file_name.Text = "";
        }

        private void them_quyet_dinh()
        {
            m_e_quyet_dinh_mode = DataEntryFormMode.InsertDataState;
            reset_form_quyet_dinh();
            m_lbl_loai_qd.Text = new US.US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(TU_DIEN.QD_THANH_LAP_DU_AN)).strTEN;
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_grb_quyet_dinh.Enabled = true;
            m_txt_ma_quyet_dinh.Focus();
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
            FileExplorer.SelectFile(m_ofd_chon_file, m_str_link_old);
            m_lbl_file_name.Text = FileExplorer.fileName;
        }

        private void save_data()
        {
            if (check_data_is_ok() == false)
                return;

            try
            {
                m_us.BeginTransaction();

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

                #region Xử lý quyết định
                form_to_us_quyet_dinh();
                switch (m_e_quyet_dinh_mode)
                {
                    case DataEntryFormMode.InsertDataState:
                        if (is_exist_quyet_dinh(m_txt_ma_quyet_dinh.Text))
                        {
                            BaseMessages.MsgBox_Error("Mã quyết định đã tồn tại.");
                            m_txt_ma_quyet_dinh.Focus();
                            return;
                        }
                        m_us.Insert();
                        break;
                    case DataEntryFormMode.UpdateDataState:
                        if (!m_txt_ma_quyet_dinh.Text.Equals(m_str_ma_quyet_dinh_old))
                        {
                            if (is_exist_quyet_dinh(m_txt_ma_quyet_dinh.Text))
                            {
                                BaseMessages.MsgBox_Error("Mã quyết định đã tồn tại hoặc đang được dùng cho dự án khác.");
                                m_txt_ma_quyet_dinh.Focus();
                                return;
                            }
                        }
                        m_us.Update();
                        break;
                }
                #endregion

                m_us.CommitTransaction();
            }
            catch (Exception)
            {
                if (m_us.is_having_transaction())
                    m_us.Rollback();
            }





            form_2_us_nhan_vien();

            US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH();
            DS_DM_QUYET_DINH v_ds_qd = new DS_DM_QUYET_DINH();
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    // Insert nhân sự
                    chuyen_trang_thai_ve_no(m_us.dcID_NHAN_SU);
                    m_us.strTRANG_THAI_HIEN_TAI = "Y";


                    // Quyết định
                    if (m_b_check_quyet_dinh_save)
                    {
                        form_to_us_quyet_dinh();
                        if (m_b_check_quyet_dinh_null)
                        {
                            m_us_quyet_dinh.Insert();

                            US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
                            DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
                            v_us.FillDataset_By_Ma_qd(v_ds, m_us_quyet_dinh.strMA_QUYET_DINH);
                            if (v_ds.DM_QUYET_DINH.Rows.Count != 0)
                            {
                                US_GD_QUYET_DINH_PHAP_NHAN v_us_qd_pn = new US_GD_QUYET_DINH_PHAP_NHAN();
                                v_us_qd_pn.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
                                v_us_qd_pn.dcID_QUYET_DINH = CIPConvert.ToDecimal(v_ds_qd.Tables[0].Rows[0]["ID"]);
                                v_us_qd_pn.Insert();
                            }
                        }
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
                        form_to_us_quyet_dinh();
                        if (m_b_check_quyet_dinh_save)
                            m_us_quyet_dinh.Insert();
                        else
                            m_us_quyet_dinh.Update();

                        v_us_qd.FillDataset_By_Ma_qd(v_ds_qd, m_us_quyet_dinh.strMA_QUYET_DINH);
                        if (v_ds_qd.Tables[0].Rows.Count != 0)
                            m_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(v_ds_qd.Tables[0].Rows[0]["ID"]);
                    }
                    m_us.Update();
                    break;
            }
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            this.Close();
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
            set_inital_form_load();
            m_txt_ma_du_an.Text = m_us_du_an.strMA_DU_AN;
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

        private void m_cmd_xem_file_Click(object sender, EventArgs e)
        {
            if (m_lbl_file_name.Text == "")
                return;
            f701_v_gd_hop_dong_lao_dong_View frm = new f701_v_gd_hop_dong_lao_dong_View();
            frm.display(ConfigurationSettings.AppSettings["DESTINATION_NAME"] + m_us_quyet_dinh.strLINK);
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
        #endregion
    }
}

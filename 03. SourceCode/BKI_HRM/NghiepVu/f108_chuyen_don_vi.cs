using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BKI_HRM.HeThong;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using System.Diagnostics;

namespace BKI_HRM {
    public partial class f108_chuyen_don_vi : Form {
        public f108_chuyen_don_vi() {
            InitializeComponent();
            set_define_event();
            format_controls();
        }

        #region Members
        DS_V_GD_QUA_TRINH_LAM_VIEC m_ds_qua_trinh_lam_viec = new DS_V_GD_QUA_TRINH_LAM_VIEC();
        ITransferDataRow m_obj_trans_left;
        ITransferDataRow m_obj_trans_right;

        US_DM_DON_VI m_us_dm_don_vi_1 = new US_DM_DON_VI();
        US_DM_DON_VI m_us_dm_don_vi_2 = new US_DM_DON_VI();

        private bool m_load_lbox_left = false;
        private bool m_load_lbox_right = false;

        private decimal m_dc_id_don_vi_left;
        private decimal m_dc_id_don_vi_right;


        private int v_int_with_MA_NV;
        private int v_int_with_HO_DEM;
        private int v_int_with_TEN;
        private int v_int_with_MA_CV;
        private int v_int_with_TEN_CV;

        private string v_str_caption_MA_NV;
        private string v_str_caption_HO_DEM;
        private string v_str_caption_TEN;
        private string v_str_caption_MA_CV;
        private string v_str_caption_TEN_CV;

        private ComboBox m_cbo_ten_chuc_vu = new ComboBox();
        private ComboBox m_cbo_ma_chuc_vu = new ComboBox();

        #endregion

        #region Data Structs
        private enum e_col_Number {
            MA_NV = 1,
            HO_DEM = 2,
            TEN = 3,
            NGAY_BAT_DAU = 4,
            NGAY_KET_THUC = 5,
            MA_CV = 6,
            TEN_CV = 7,
            NGACH = 8,
            LOAI_CV = 9,
            TRANG_THAI_CV = 10,
            MA_DON_VI = 11,
            TEN_DON_VI = 12,
            CAP_DON_VI = 13,
            LOAI_DON_VI = 14,
            DIA_BAN = 15,
            MA_QUYET_DINH = 16,
            NGAY_CO_HIEU_LUC = 17,
            NGAY_HET_HIEU_LUC = 18,
            MA_QUYET_DINH_MIEN_NHIEM = 18
        }
        #endregion

        #region Private Methods

        private void format_controls() {
            KeyPreview = true;
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg_left);
            CGridUtils.AddSave_Excel_Handlers(m_fg_left);
            CGridUtils.AddSearch_Handlers(m_fg_left);
            m_fg_left.Tree.Style = TreeStyleFlags.Simple;
            CControlFormat.setC1FlexFormat(m_fg_right);
            m_fg_right.AllowEditing = true;
            CGridUtils.AddSave_Excel_Handlers(m_fg_right);
            CGridUtils.AddSearch_Handlers(m_fg_right);
            m_fg_right.Tree.Style = TreeStyleFlags.Simple;
        }

        private void set_init_form_load() {
            m_obj_trans_left = get_trans_object(m_fg_left);
            m_obj_trans_right = get_trans_object(m_fg_right);
            load_data_2_cbo_don_vi_left();
            load_data_2_cbo_don_vi_right();
            init_value_fomat_grid();
            create_cbo_chuc_vu();
            create_drop_down_control();
        }

        private void init_value_fomat_grid() {
            v_int_with_MA_NV = m_fg_right.Cols[(int)e_col_Number.MA_NV].Width;
            v_int_with_HO_DEM = m_fg_right.Cols[(int)e_col_Number.HO_DEM].Width;
            v_int_with_TEN = m_fg_right.Cols[(int)e_col_Number.TEN].Width;
            v_int_with_MA_CV = m_fg_right.Cols[(int)e_col_Number.MA_CV].Width;
            v_int_with_TEN_CV = m_fg_right.Cols[(int)e_col_Number.TEN_CV].Width;

            v_str_caption_MA_NV = m_fg_right.Cols[(int)e_col_Number.MA_NV].Caption;
            v_str_caption_HO_DEM = m_fg_right.Cols[(int)e_col_Number.HO_DEM].Caption;
            v_str_caption_TEN = m_fg_right.Cols[(int)e_col_Number.TEN].Caption;
            v_str_caption_MA_CV = m_fg_right.Cols[(int)e_col_Number.MA_CV].Caption;
            v_str_caption_TEN_CV = m_fg_right.Cols[(int)e_col_Number.TEN_CV].Caption;
        }

        private ITransferDataRow get_trans_object(C1FlexGrid i_fg) {
            var v_htb = new Hashtable();
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_CO_HIEU_LUC, e_col_Number.NGAY_CO_HIEU_LUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.CAP_DON_VI, e_col_Number.CAP_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_BAT_DAU, e_col_Number.NGAY_BAT_DAU);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TEN_CV, e_col_Number.TEN_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TEN_DON_VI, e_col_Number.TEN_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_DON_VI, e_col_Number.MA_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_KET_THUC, e_col_Number.NGAY_KET_THUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_CV, e_col_Number.MA_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.HO_DEM, e_col_Number.HO_DEM);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.LOAI_DON_VI, e_col_Number.LOAI_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TEN, e_col_Number.TEN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.LOAI_CV, e_col_Number.LOAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TRANG_THAI_CV, e_col_Number.TRANG_THAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_QUYET_DINH, e_col_Number.MA_QUYET_DINH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_HET_HIEU_LUC, e_col_Number.NGAY_HET_HIEU_LUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.DIA_BAN, e_col_Number.DIA_BAN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGACH, e_col_Number.NGACH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_QUYET_DINH_MIEN_NHIEM, e_col_Number.MA_QUYET_DINH_MIEN_NHIEM);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds_qua_trinh_lam_viec.V_GD_QUA_TRINH_LAM_VIEC.NewRow());
            return v_obj_trans;
        }

        private void load_data_2_cbo_don_vi_left() {
            var v_ds = new DS_V_DM_DON_VI();
            var v_us = new US_V_DM_DON_VI();
            //v_us.FillDatasetByKeyWord(v_ds, "");
            m_cbo_don_vi_left.DataSource = v_ds.V_DM_DON_VI;
            m_cbo_don_vi_left.DisplayMember = V_DM_DON_VI.TEN_DON_VI;
            m_cbo_don_vi_left.ValueMember = V_DM_DON_VI.ID;

            m_cbo_ma_don_vi_left.DataSource = v_ds.V_DM_DON_VI;
            m_cbo_ma_don_vi_left.DisplayMember = V_DM_DON_VI.MA_DON_VI;
            m_cbo_ma_don_vi_left.ValueMember = V_DM_DON_VI.ID;

            m_load_lbox_left = true;
        }

        private void load_data_2_cbo_don_vi_right() {
            var v_ds = new DS_V_DM_DON_VI();
            var v_us = new US_V_DM_DON_VI();
            //v_us.FillDatasetByKeyWord(v_ds, "");
            m_cbo_don_vi_right.DataSource = v_ds.V_DM_DON_VI;
            m_cbo_don_vi_right.DisplayMember = V_DM_DON_VI.TEN_DON_VI;
            m_cbo_don_vi_right.ValueMember = V_DM_DON_VI.ID;

            m_cbo_ma_don_vi_right.DataSource = v_ds.V_DM_DON_VI;
            m_cbo_ma_don_vi_right.DisplayMember = V_DM_DON_VI.MA_DON_VI;
            m_cbo_ma_don_vi_right.ValueMember = V_DM_DON_VI.ID;

            m_load_lbox_right = true;

        }

        private void save_data() {
            //var v_id_don_vi_left = m_cbo_don_vi_left.SelectedValue;
            //var v_id_don_vi_right = m_cbo_don_vi_right.SelectedValue;
            //var v_us_gd_chi_tiet_chuc_vu = new US_GD_CHI_TIET_CHUC_VU();
            //var v_ds_gd_chi_tiet_chuc_vu = new DS_GD_CHI_TIET_CHUC_VU();
            //var v_us_dm_du_lieu_nhan_vien = new US_V_DM_DU_LIEU_NHAN_VIEN();
            //var v_ds_dm_du_lieu_nhan_vien = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            //var v_us_dm_nhan_su = new US_DM_NHAN_SU();
            //var v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            //var v_danh_sach_nhan_vien_new = new collection(1);
            //var v_danh_sach_nhan_vien_old = new collection(1);
            //var v_danh_sach_nhan_vien_insert = new collection(1);
            //var v_danh_sach_nhan_vien_delete = new collection(1);
            //v_us_dm_nhan_su.FillDataset(v_ds_dm_nhan_su);
            //v_us_dm_du_lieu_nhan_vien.FillDatasetByIdDonVi(v_ds_dm_du_lieu_nhan_vien, CIPConvert.ToDecimal(v_id_don_vi_left));


            //var v_count_nhan_vien = v_ds_dm_du_lieu_nhan_vien.V_DM_DU_LIEU_NHAN_VIEN.Count;
            //if (v_count_nhan_vien > 0) {
            //    var v_nhan_vien =
            //            (v_ds_dm_du_lieu_nhan_vien.V_DM_DU_LIEU_NHAN_VIEN.Rows);
            //    v_danh_sach_nhan_vien_old = new collection(v_count_nhan_vien);
            //    foreach (DS_V_DM_DU_LIEU_NHAN_VIEN.V_DM_DU_LIEU_NHAN_VIENRow v_item in v_nhan_vien) {
            //        v_danh_sach_nhan_vien_old.insert(v_item.ID.ToString());
            //    }
            //}
            //v_danh_sach_nhan_vien_delete = v_danh_sach_nhan_vien_old.InANotInB(v_danh_sach_nhan_vien_new);


        }

        private void load_data_2_grid_left() {
            if (m_load_lbox_left) {
                m_dc_id_don_vi_left = CIPConvert.ToDecimal(m_cbo_don_vi_left.SelectedValue);
                var v_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC();
                var v_us = new US_V_GD_QUA_TRINH_LAM_VIEC();
                v_us.FillDatasetByIdDonVi(v_ds, m_dc_id_don_vi_left);
                CGridUtils.Dataset2C1Grid(v_ds, m_fg_left, m_obj_trans_left);
                m_fg_left.Redraw = true;

                m_fg_left.Rows[1].Editor = m_cbo_don_vi_left;
            }
        }

        private void load_data_2_grid_right() {
            if (m_load_lbox_right) {
                m_dc_id_don_vi_right = CIPConvert.ToDecimal(m_cbo_don_vi_right.SelectedValue);
                var v_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC();
                var v_us = new US_V_GD_QUA_TRINH_LAM_VIEC();
                v_us.FillDatasetByIdDonVi(v_ds, m_dc_id_don_vi_right);
                CGridUtils.Dataset2C1Grid(v_ds, m_fg_right, m_obj_trans_right);
                m_fg_right.Redraw = true;

            }
        }

        private void left_2_right() {
            var v_row_index = m_fg_left.Row;
            var v_row = m_fg_left.Rows[v_row_index];
            var dt = (DataTable)m_fg_right.DataSource;
            if (dt == null) {
                dt = new DS_V_GD_QUA_TRINH_LAM_VIEC.V_GD_QUA_TRINH_LAM_VIECDataTable();
            }
            var dr = dt.NewRow();
            dr.ItemArray = ((DataRow)v_row.UserData).ItemArray;
            dr.ItemArray[1] = "!@#!@#@!#";
            dt.Rows.Add(dr);
            m_fg_right.DataSource = null;
            
            m_fg_right.DataSource = dt;
            m_fg_left.Rows.Remove(v_row_index);

            re_format_fg_right();
        }

        private void re_format_fg_right(){
            int v_int_count = m_fg_right.Cols.Count;
            for (int i = 0; i < v_int_count; i++) {
                m_fg_right.Cols[i].Visible = false;
            }
            m_fg_right.Cols[0].Visible = true;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.MA_NV].Visible = true;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.HO_DEM].Visible = true;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.TEN].Visible = true;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.MA_CV].Visible = true;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.TEN_CV].Visible = true;

            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.MA_NV].Width = v_int_with_MA_NV;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.HO_DEM].Width = v_int_with_HO_DEM;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.TEN].Width = v_int_with_TEN;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.MA_CV].Width = v_int_with_MA_CV;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.TEN_CV].Width = v_int_with_TEN_CV;

            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.MA_NV].Caption = v_str_caption_MA_NV;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.HO_DEM].Caption = v_str_caption_HO_DEM;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.TEN].Caption = v_str_caption_TEN;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.MA_CV].Caption = v_str_caption_MA_CV;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.TEN_CV].Caption = v_str_caption_TEN_CV;

            m_fg_right.AllowEditing = true;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.TEN_CV].Editor = m_cbo_ten_chuc_vu;
            m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.MA_CV].Editor = m_cbo_ma_chuc_vu;
            //m_fg_right.Cols[V_GD_QUA_TRINH_LAM_VIEC.MA_CV].ComboList = "TEST1|TEST2|TEST3";
            m_fg_right.Cols[(int)e_col_Number.MA_NV].AllowEditing = false;
        }

        private void create_cbo_chuc_vu() {
            var v_ds = new DS_V_DM_CHUC_VU();
            var v_us = new US_V_DM_CHUC_VU();
            v_us.FillDatasetOrderByMaChucVu(v_ds);
            m_cbo_ten_chuc_vu.DataSource = v_ds.V_DM_CHUC_VU;
            m_cbo_ten_chuc_vu.DisplayMember = V_DM_CHUC_VU.TEN_CV;
            m_cbo_ten_chuc_vu.ValueMember = V_DM_CHUC_VU.ID;

            m_cbo_ma_chuc_vu.DataSource = v_ds.V_DM_CHUC_VU;
            m_cbo_ma_chuc_vu.DisplayMember = V_DM_CHUC_VU.MA_CV;
            m_cbo_ma_chuc_vu.ValueMember = V_DM_CHUC_VU.ID;

            m_cbo_ten_chuc_vu.DropDownStyle = ComboBoxStyle.DropDownList;
            m_cbo_ma_chuc_vu.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void create_drop_down_control() {
            var v_ds = new DS_V_DM_CHUC_VU();
            var v_us = new US_V_DM_CHUC_VU();
            v_us.FillDatasetSearch(v_ds, "");
        }

        private void m_fg_right_click() {

        }

        private void m_fg_right_CellChanged() {
            //Debug.WriteLine(m_fg_right.Col);
            //Debug.WriteLine(m_fg_right.Row);
            //m_fg_right[1, (int) e_col_Number.MA_CV] = "TESTETESTE";
        }

        #endregion

        // Event
        private void set_define_event() {
            Load += f108_chuyen_don_vi_Load;
            m_cbo_don_vi_left.SelectedIndexChanged += m_cbo_don_vi_left_SelectedIndexChanged;
            m_cbo_don_vi_right.SelectedIndexChanged += m_cbo_don_vi_right_SelectedIndexChanged;
            m_cmd_right_2_left_all.Click += m_cmd_right_2_left_all_Click;
            m_cmd_right_2_left.Click += m_cmd_right_2_left_Click;
            m_cmd_left_2_right_all.Click += m_cmd_left_2_right_all_Click;
            m_cmd_left_2_right.Click += m_cmd_left_2_right_Click;
            m_cmd_save.Click += m_cmd_save_Click;
            m_cmd_exit.Click += m_cmd_exit_Click;
            m_fg_right.Click += m_fg_right_Click;
            //m_fg_right.CellChanged += m_fg_right_CellChanged;
            m_cbo_ten_chuc_vu.SelectedIndexChanged += test_Event;
        }

        private void test_Event(object sender, EventArgs e) {
            try {
                Debug.WriteLine(m_fg_right.Row);
                Debug.WriteLine(m_cbo_ten_chuc_vu.SelectedValue);
                Debug.WriteLine(m_cbo_ten_chuc_vu.SelectedIndex);
                m_cbo_ma_chuc_vu.SelectedValue = m_cbo_ten_chuc_vu.SelectedValue;
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void f108_chuyen_don_vi_Load(object sender, EventArgs e) {
            try {
                set_init_form_load();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_don_vi_left_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                load_data_2_grid_left();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_don_vi_right_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                load_data_2_grid_right();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_left_2_right_Click(object sender, EventArgs e) {
            try {
                left_2_right();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_left_2_right_all_Click(object sender, EventArgs e) {
            try {
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_right_2_left_Click(object sender, EventArgs e) {
            try {
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_right_2_left_all_Click(object sender, EventArgs e) {
            try {
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_save_Click(object sender, EventArgs e) {
            try {
                save_data();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_exit_Click(object sender, EventArgs e) {
            try {
                Close();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_fg_right_Click(object sender, EventArgs e) {
            try {
                m_fg_right_click();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_fg_right_CellChanged(object sender, EventArgs e) {
            try {
                m_fg_right_CellChanged();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

    }
}

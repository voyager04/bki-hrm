using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BKI_HRM.HeThong;
using C1.Win.C1FlexGrid;
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

    public partial class f107_chuyen_nhan_vien : Form {

        #region Public

        public f107_chuyen_nhan_vien() {
            InitializeComponent();
            set_define_event();
            format_controls();
        }
        #endregion

        #region Members

        US_DM_DON_VI m_us_dm_don_vi_1 = new US_DM_DON_VI();
        US_DM_DON_VI m_us_dm_don_vi_2 = new US_DM_DON_VI();

        private bool m_load_lbox_left = false;
        private bool m_load_lbox_right = false;

        private decimal m_dc_id_don_vi_left;
        private decimal m_dc_id_don_vi_right;

        #endregion

        #region Data Structs
        #endregion

        #region Private Methods

        private void format_controls() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            KeyPreview = true;
        }

        private void set_init_form_load() {
            load_data_2_cbo_don_vi_left();
            load_data_2_cbo_don_vi_right();
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

        private void load_data_2_lbox_nhan_vien_left(decimal ip_dc_ma_don_vi) {
            var v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            var v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            v_us.FillDatasetByIdDonVi(v_ds, ip_dc_ma_don_vi);
            int v_row_count = v_ds.Tables[0].Rows.Count;
            m_lbox_nhan_vien_left.Items.Clear();
            for (int i = 0; i < v_row_count; i++) {
                DataRow v_dr = v_ds.Tables[0].Rows[i];
                var test = v_dr[V_DM_DU_LIEU_NHAN_VIEN.MA_NV] + "-"
                           + v_dr[V_DM_DU_LIEU_NHAN_VIEN.HO_DEM] + " " + v_dr[V_DM_DU_LIEU_NHAN_VIEN.TEN];
                m_lbox_nhan_vien_left.Items.Add((String)(v_dr[V_DM_DU_LIEU_NHAN_VIEN.MA_NV] + "-"
                    + v_dr[V_DM_DU_LIEU_NHAN_VIEN.HO_DEM] + " " + v_dr[V_DM_DU_LIEU_NHAN_VIEN.TEN]));
            }
            if (m_lbox_nhan_vien_left.Items.Count > 0) {
                m_lbox_nhan_vien_left.SelectedIndex = 0;
            }
        }

        private void load_data_2_lbox_nhan_vien_right(decimal ip_dc_ma_don_vi) {
            var v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            var v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            v_us.FillDatasetByIdDonVi(v_ds, ip_dc_ma_don_vi);
            int v_row_count = v_ds.Tables[0].Rows.Count;
            m_lbox_nhan_vien_right.Items.Clear();
            for (int i = 0; i < v_row_count; i++) {
                DataRow v_dr = v_ds.Tables[0].Rows[i];
                m_lbox_nhan_vien_right.Items.Add(v_dr[V_DM_DU_LIEU_NHAN_VIEN.MA_NV] + "-"
                    + v_dr[V_DM_DU_LIEU_NHAN_VIEN.HO_DEM] + " " + v_dr[V_DM_DU_LIEU_NHAN_VIEN.TEN]);
            }
            if (m_lbox_nhan_vien_right.Items.Count > 0) {
                m_lbox_nhan_vien_right.SelectedIndex = 0;
            }
        }

        private void left_2_right_Click() {
            if (m_lbox_nhan_vien_left.Items.Count > 0) {
                m_lbox_nhan_vien_right.Items.Add(m_lbox_nhan_vien_left.SelectedItem);
                m_lbox_nhan_vien_left.Items.RemoveAt(m_lbox_nhan_vien_left.SelectedIndex);
                m_lbox_nhan_vien_right.SelectedIndex = m_lbox_nhan_vien_right.Items.Count - 1;
                if (m_lbox_nhan_vien_left.Items.Count > 0) {
                    m_lbox_nhan_vien_left.SelectedIndex = 0;
                }
            }
        }

        private void left_2_right_all_Click() {
            var count = m_lbox_nhan_vien_left.Items.Count;
            if (count > 0) {
                for (int i = 0; i < count; i++) {
                    m_lbox_nhan_vien_left.SelectedIndex = i;
                    m_lbox_nhan_vien_right.Items.Add(m_lbox_nhan_vien_left.SelectedItem);
                }
                m_lbox_nhan_vien_left.Items.Clear();
                m_lbox_nhan_vien_right.SelectedIndex = 0;
            }
        }

        private void right_2_left_Click() {
            if (m_lbox_nhan_vien_right.Items.Count > 0) {
                m_lbox_nhan_vien_left.Items.Add(m_lbox_nhan_vien_right.SelectedItem);
                m_lbox_nhan_vien_right.Items.RemoveAt(m_lbox_nhan_vien_right.SelectedIndex);
                m_lbox_nhan_vien_left.SelectedIndex = m_lbox_nhan_vien_left.Items.Count - 1;
                if (m_lbox_nhan_vien_right.Items.Count > 0) {
                    m_lbox_nhan_vien_right.SelectedIndex = 0;
                }
            }
        }

        private void right_2_left_all_Click() {
            var count = m_lbox_nhan_vien_right.Items.Count;
            if (count > 0) {
                for (int i = 0; i < count; i++) {
                    m_lbox_nhan_vien_right.SelectedIndex = i;
                    m_lbox_nhan_vien_left.Items.Add(m_lbox_nhan_vien_right.SelectedItem);
                }
                m_lbox_nhan_vien_right.Items.Clear();
                m_lbox_nhan_vien_left.SelectedIndex = 0;
            }
        }

        private void save_data() {
            var v_count_left = m_lbox_nhan_vien_left.Items.Count;
            var v_count_right = m_lbox_nhan_vien_right.Items.Count;
            var v_id_don_vi_left = m_cbo_don_vi_left.SelectedValue;
            var v_id_don_vi_right = m_cbo_don_vi_right.SelectedValue;
            var v_us_dm_du_lieu_nhan_vien = new US_V_DM_DU_LIEU_NHAN_VIEN();
            var v_ds_dm_du_lieu_nhan_vien = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            var v_us_dm_nhan_su = new US_DM_NHAN_SU();
            var v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            var v_danh_sach_nhan_vien_left_new = new collection(1);
            var v_danh_sach_nhan_vien_left_old = new collection(1);
            var v_danh_sach_nhan_vien_left_insert = new collection(1);
            var v_danh_sach_nhan_vien_left_delete = new collection(1);
            var v_danh_sach_nhan_vien_right_new = new collection(1);
            var v_danh_sach_nhan_vien_right_old = new collection(1);
            var v_danh_sach_nhan_vien_right_insert = new collection(1);
            var v_danh_sach_nhan_vien_right_delete = new collection(1);
            v_us_dm_nhan_su.FillDataset(v_ds_dm_nhan_su);
            v_us_dm_du_lieu_nhan_vien.FillDatasetByIdDonVi(v_ds_dm_du_lieu_nhan_vien, CIPConvert.ToDecimal(v_id_don_vi_left));
            ////-- Lưu nhân sự đơn vị LEFT
            //+ Danh sách nhân viên mới trong ListBox
            if (v_count_left > 0) {
                v_danh_sach_nhan_vien_left_new = new collection(v_count_left);
                foreach (var v_item in m_lbox_nhan_vien_left.Items) {
                    var v_ma_nhan_vien = get_ma_nhan_vien(v_item.ToString());
                    var v_nhan_vien = (DS_DM_NHAN_SU.DM_NHAN_SURow)(v_ds_dm_nhan_su.DM_NHAN_SU.Select("MA_NV = " + v_ma_nhan_vien)[0]);
                    v_danh_sach_nhan_vien_left_new.insert(v_nhan_vien.ID.ToString());
                }

                //+ Danh sách nhân viên cũ trước khi thay đổi ListBox
                var v_count_nhan_vien = v_ds_dm_du_lieu_nhan_vien.V_DM_DU_LIEU_NHAN_VIEN.Count;
                if (v_count_nhan_vien > 0) {
                    var v_nhan_vien =
                            (v_ds_dm_du_lieu_nhan_vien.V_DM_DU_LIEU_NHAN_VIEN.Rows);
                    v_danh_sach_nhan_vien_left_old = new collection(v_count_nhan_vien);
                    foreach (DS_V_DM_DU_LIEU_NHAN_VIEN.V_DM_DU_LIEU_NHAN_VIENRow v_item in v_nhan_vien) {
                        v_danh_sach_nhan_vien_left_old.insert(v_item.ID.ToString());
                    }
                }
                //+ Danh sách nhân viên thêm mới
                v_danh_sach_nhan_vien_left_insert =
                    new collection(v_danh_sach_nhan_vien_left_new.countInANotInB(v_danh_sach_nhan_vien_left_old));
                v_danh_sach_nhan_vien_left_insert =
                    v_danh_sach_nhan_vien_left_new.InANotInB(v_danh_sach_nhan_vien_left_old);
                for (int i = 0; i < v_danh_sach_nhan_vien_left_insert.getIndex(); i++){
                    decimal v_id = CIPConvert.ToDecimal(v_danh_sach_nhan_vien_left_insert.s[i]);
                    v_us_dm_du_lieu_nhan_vien.FillDatasetByIdDonVi(v_ds_dm_du_lieu_nhan_vien,v_id);

                }
            }
            //+ Danh sách nhân viên sẽ bị xoá
            v_danh_sach_nhan_vien_left_delete = v_danh_sach_nhan_vien_left_old.InANotInB(v_danh_sach_nhan_vien_left_new);
        }

        private string get_ma_nhan_vien(string ip_str_listbox_item) {
            string kq = "";
            var length = ip_str_listbox_item.IndexOf('-');
            kq = ip_str_listbox_item.Trim().Substring(0, length);
            return kq;
        }
        #endregion

        // Event
        private void set_define_event() {
            Load += f107_chuyen_nhan_vien_Load;
            m_cbo_don_vi_left.SelectedIndexChanged += m_cbo_don_vi_left_SelectedIndexChanged;
            m_cbo_don_vi_right.SelectedIndexChanged += m_cbo_don_vi_right_SelectedIndexChanged;
            m_cmd_right_2_left_all.Click += m_cmd_right_2_left_all_Click;
            m_cmd_right_2_left.Click += m_cmd_right_2_left_Click;
            m_cmd_left_2_right_all.Click += m_cmd_left_2_right_all_Click;
            m_cmd_left_2_right.Click += m_cmd_left_2_right_Click;
            m_lbox_nhan_vien_left.SelectedIndexChanged += m_lbox_nhan_vien_left_SelectedIndexChanged;
            m_lbox_nhan_vien_right.SelectedIndexChanged += m_lbox_nhan_vien_right_SelectedIndexChanged;
            m_cmd_save.Click += m_cmd_save_Click;
            m_cmd_exit.Click += m_cmd_exit_Click;

        }

        private void f107_chuyen_nhan_vien_Load(object sender, EventArgs e) {
            try {
                set_init_form_load();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_don_vi_left_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (m_load_lbox_left) {
                    m_dc_id_don_vi_left = CIPConvert.ToDecimal(m_cbo_don_vi_left.SelectedValue);
                    load_data_2_lbox_nhan_vien_left(m_dc_id_don_vi_left);
                }
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_don_vi_right_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (m_load_lbox_right) {
                    m_dc_id_don_vi_right = CIPConvert.ToDecimal(m_cbo_don_vi_right.SelectedValue);
                    load_data_2_lbox_nhan_vien_right(m_dc_id_don_vi_right);
                }

            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_left_2_right_Click(object sender, EventArgs e) {
            try {
                left_2_right_Click();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_left_2_right_all_Click(object sender, EventArgs e) {
            try {
                left_2_right_all_Click();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_right_2_left_Click(object sender, EventArgs e) {
            try {
                right_2_left_Click();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_right_2_left_all_Click(object sender, EventArgs e) {
            try {
                right_2_left_all_Click();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_lbox_nhan_vien_left_SelectedIndexChanged(object sender, EventArgs e) {
        }

        private void m_lbox_nhan_vien_right_SelectedIndexChanged(object sender, EventArgs e) {
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
    }
}

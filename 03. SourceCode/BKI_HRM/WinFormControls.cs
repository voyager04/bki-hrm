using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;

using BKI_HRM.DS;
using BKI_HRM.US;
using BKI_HRM.DS.CDBNames;


namespace BKI_HRM {
    public class WinFormControls {
        public WinFormControls() {
            //
            // TODO: Add constructor logic here
            //
        }
        public enum eTAT_CA {
            YES,
            NO
        }
        public enum eLOAI_TU_DIEN {
            TRANG_THAI_CHUC_VU,
            LOAI_HOP_DONG,
            LOAI_DON_VI,
            CAP_DON_VI,
            CO_CHE,
            LOAI_DU_AN,
            TRANG_THAI_DU_AN,
            LOAI_QUYET_DINH,
            TRANG_THAI_LAO_DONG,
            NGACH,
            LOAI_CHUC_VU,
            TRANG_THAI_HOP_DONG,
            MA_HOP_DONG,
            DANH_HIEU,
            MA_QUYET_DINH,
            DIA_BAN
        }
        public static void load_data_to_cbo_tu_dien(
             eLOAI_TU_DIEN ip_e
            , eTAT_CA ip_e_tat_ca
            , ComboBox ip_obj_cbo_trang_thai) {

            IP.Core.IPUserService.US_CM_DM_TU_DIEN v_us_dm_tu_dien = new IP.Core.IPUserService.US_CM_DM_TU_DIEN();
            IP.Core.IPData.DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new IP.Core.IPData.DS_CM_DM_TU_DIEN();
            string v_str_loai_tu_dien = "";
            switch (ip_e) {
                case eLOAI_TU_DIEN.TRANG_THAI_CHUC_VU:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_CHUC_VU;
                    break;
                case eLOAI_TU_DIEN.LOAI_HOP_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_HOP_DONG;
                    break;
                case eLOAI_TU_DIEN.LOAI_DON_VI:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_DON_VI;
                    break;
                case eLOAI_TU_DIEN.CAP_DON_VI:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.CAP_DON_VI;
                    break;
                case eLOAI_TU_DIEN.LOAI_QUYET_DINH:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_QUYET_DINH;
                    break;
                case eLOAI_TU_DIEN.TRANG_THAI_LAO_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_LAO_DONG;
                    break;
                case eLOAI_TU_DIEN.NGACH:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.NGACH;
                    break;
                case eLOAI_TU_DIEN.LOAI_CHUC_VU:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_CHUC_VU;
                    break;
                case eLOAI_TU_DIEN.TRANG_THAI_HOP_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_HOP_DONG;
                    break;
                case eLOAI_TU_DIEN.TRANG_THAI_DU_AN:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.TRANG_THAI_DU_AN;
                    break;
                case eLOAI_TU_DIEN.MA_HOP_DONG:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.MA_HOP_DONG;
                    break;
                case eLOAI_TU_DIEN.DANH_HIEU:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.DANH_HIEU;
                    break;
                case eLOAI_TU_DIEN.CO_CHE:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.CO_CHE;
                    break;
                case eLOAI_TU_DIEN.LOAI_DU_AN:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.LOAI_DU_AN;
                    break;
                case eLOAI_TU_DIEN.MA_QUYET_DINH:
                    v_str_loai_tu_dien = MA_LOAI_TU_DIEN.MA_QUYET_DINH;
                    break;
                case eLOAI_TU_DIEN.DIA_BAN:
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
            if (ip_e_tat_ca == eTAT_CA.YES) {
                DataRow v_dr = v_ds_dm_tu_dien.CM_DM_TU_DIEN.NewRow();
                v_dr[CM_DM_TU_DIEN.ID] = -1;
                v_dr[CM_DM_TU_DIEN.TEN] = "------ Tất cả ------";
                v_dr[CM_DM_TU_DIEN.MA_TU_DIEN] = "";
                v_dr[CM_DM_TU_DIEN.TEN_NGAN] = "";
                v_dr[CM_DM_TU_DIEN.ID_LOAI_TU_DIEN] = 1;
                v_dr[CM_DM_TU_DIEN.GHI_CHU] = "";
                v_ds_dm_tu_dien.CM_DM_TU_DIEN.Rows.InsertAt(v_dr, 0);
                ip_obj_cbo_trang_thai.SelectedIndex = 0;
            }
            }
        public static void set_focus_for_grid(C1FlexGrid ip_fg, // Grid cần tạo focus
                                                string ip_str_search, // Từ khóa để tìm ra dòng cần focus VD: Mã nhân viên là '100002' ,...
                                                int ip_i_col_search) // Cột chứa thông tin cần search VD: Cột Mã nhân viên
        {
            ip_fg.Focus();
            //var s = ip_fg.FindRow(ip_str_search, ip_fg.Row, ip_i_col_search, true);
            var s = ip_fg.FindRow(ip_str_search, 1, ip_i_col_search, true);
            ip_fg.Row = s;
        }
        public static void load_data_to_CheckboxCombobox(C1FlexGrid ip_fg, Checkbox_Combobox.CheckBoxComboBox ip_cbc
                                                                , bool load_invisible) {
            int v_count = ip_fg.Cols.Count;
            if (load_invisible) {
                for (int i = 0; i < v_count - 2; i++) {
                    ip_cbc.Items.Add(ip_fg.Cols[i + 2].Caption);//Bỏ 2 cột đầu tiên của C1Grid
                    /* 
                     * m_cbc_choose_columns tự động thêm một Item giá trị = "" vào đầu nên phải bỏ đi Item đó. 
                     */
                    ip_cbc.CheckBoxItems[i + 1].Checked = ip_fg.Cols[i + 2].Visible;
                }
            } else {
                for (int i = 0; i < v_count - 2; i++) {
                    if (ip_fg.Cols[i + 2].Visible) {
                        ip_cbc.Items.Add(ip_fg.Cols[i + 2].Caption);//Bỏ 2 cột đầu tiên của C1Grid
                        ip_cbc.CheckBoxItems[i + 1].Checked = ip_fg.Cols[i + 2].Visible;
                    }
                }
            }

        }

    }
}

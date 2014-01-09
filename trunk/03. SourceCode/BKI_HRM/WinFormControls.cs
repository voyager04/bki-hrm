using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;

using BKI_HRM.DS;
using BKI_HRM.US;
using BKI_HRM.DS.CDBNames;


namespace BKI_HRM
{
    public class WinFormControls
    {
        public WinFormControls()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public enum eTAT_CA
        {
            YES,
            NO
        }
        public enum eLOAI_TU_DIEN
        {
            TRANG_THAI_CHUC_VU
        }
        public static void load_data_to_cbo_tu_dien(
             eLOAI_TU_DIEN ip_e_trang_thai_chuc_vu
            , eTAT_CA ip_e_tat_ca
            , ComboBox ip_obj_cbo_trang_thai)
        {

            US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            string v_str_loai_trang_thai = "";
            switch (ip_e_trang_thai_chuc_vu)
            {
                case eLOAI_TU_DIEN.TRANG_THAI_CHUC_VU:
                    v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_CHUC_VU;
                    break;
            }
            v_us_dm_tu_dien.fill_tu_dien_cung_loai_ds(
                v_str_loai_trang_thai
                , CM_DM_TU_DIEN.GHI_CHU
                , v_ds_dm_tu_dien);

            ip_obj_cbo_trang_thai.DataSource = v_ds_dm_tu_dien.CM_DM_TU_DIEN;
            ip_obj_cbo_trang_thai.DisplayMember = CM_DM_TU_DIEN.TEN;
            ip_obj_cbo_trang_thai.ValueMember = CM_DM_TU_DIEN.ID;

            if (ip_e_tat_ca == eTAT_CA.YES)
            {
                ip_obj_cbo_trang_thai.Items.Insert(0, CONST_HRM.TAT_CA);
            }
        }
    }
}

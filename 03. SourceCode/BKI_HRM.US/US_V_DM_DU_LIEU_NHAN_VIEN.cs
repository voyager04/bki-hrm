///************************************************
/// Generated by: AnhLT
/// Date: 25/02/2014 04:43:00
/// Goal: Create User Service Class for V_DM_DU_LIEU_NHAN_VIEN
///************************************************
/// <summary>
/// Create User Service Class for V_DM_DU_LIEU_NHAN_VIEN
/// </summary>

using System;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;



namespace BKI_HRM.US {

    public class US_V_DM_DU_LIEU_NHAN_VIEN : US_Object {
        private const string c_TableName = "V_DM_DU_LIEU_NHAN_VIEN";

        #region "Public Properties"
        public decimal dcID {
            get {
                return CNull.RowNVLDecimal(pm_objDR, "ID", IPConstants.c_DefaultDecimal);
            }
            set {
                pm_objDR["ID"] = value;
            }
        }

        public bool IsIDNull() {
            return pm_objDR.IsNull("ID");
        }

        public void SetIDNull() {
            pm_objDR["ID"] = System.Convert.DBNull;
        }

        public string strMA_NV {
            get {
                return CNull.RowNVLString(pm_objDR, "MA_NV", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["MA_NV"] = value;
            }
        }

        public bool IsMA_NVNull() {
            return pm_objDR.IsNull("MA_NV");
        }

        public void SetMA_NVNull() {
            pm_objDR["MA_NV"] = System.Convert.DBNull;
        }

        public string strHO_DEM {
            get {
                return CNull.RowNVLString(pm_objDR, "HO_DEM", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["HO_DEM"] = value;
            }
        }

        public bool IsHO_DEMNull() {
            return pm_objDR.IsNull("HO_DEM");
        }

        public void SetHO_DEMNull() {
            pm_objDR["HO_DEM"] = System.Convert.DBNull;
        }

        public string strTEN {
            get {
                return CNull.RowNVLString(pm_objDR, "TEN", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["TEN"] = value;
            }
        }

        public bool IsTENNull() {
            return pm_objDR.IsNull("TEN");
        }

        public void SetTENNull() {
            pm_objDR["TEN"] = System.Convert.DBNull;
        }

        public string strGIOI_TINH {
            get {
                return CNull.RowNVLString(pm_objDR, "GIOI_TINH", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["GIOI_TINH"] = value;
            }
        }

        public bool IsGIOI_TINHNull() {
            return pm_objDR.IsNull("GIOI_TINH");
        }

        public void SetGIOI_TINHNull() {
            pm_objDR["GIOI_TINH"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_SINH {
            get {
                return CNull.RowNVLDate(pm_objDR, "NGAY_SINH", IPConstants.c_DefaultDate);
            }
            set {
                pm_objDR["NGAY_SINH"] = value;
            }
        }

        public bool IsNGAY_SINHNull() {
            return pm_objDR.IsNull("NGAY_SINH");
        }

        public void SetNGAY_SINHNull() {
            pm_objDR["NGAY_SINH"] = System.Convert.DBNull;
        }

        public string strTRINH_DO {
            get {
                return CNull.RowNVLString(pm_objDR, "TRINH_DO", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["TRINH_DO"] = value;
            }
        }

        public bool IsTRINH_DONull() {
            return pm_objDR.IsNull("TRINH_DO");
        }

        public void SetTRINH_DONull() {
            pm_objDR["TRINH_DO"] = System.Convert.DBNull;
        }

        public decimal dcID_CHUC_VU {
            get {
                return CNull.RowNVLDecimal(pm_objDR, "ID_CHUC_VU", IPConstants.c_DefaultDecimal);
            }
            set {
                pm_objDR["ID_CHUC_VU"] = value;
            }
        }

        public bool IsID_CHUC_VUNull() {
            return pm_objDR.IsNull("ID_CHUC_VU");
        }

        public void SetID_CHUC_VUNull() {
            pm_objDR["ID_CHUC_VU"] = System.Convert.DBNull;
        }

        public string strMA_CV {
            get {
                return CNull.RowNVLString(pm_objDR, "MA_CV", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["MA_CV"] = value;
            }
        }

        public bool IsMA_CVNull() {
            return pm_objDR.IsNull("MA_CV");
        }

        public void SetMA_CVNull() {
            pm_objDR["MA_CV"] = System.Convert.DBNull;
        }

        public string strTEN_CV {
            get {
                return CNull.RowNVLString(pm_objDR, "TEN_CV", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["TEN_CV"] = value;
            }
        }

        public bool IsTEN_CVNull() {
            return pm_objDR.IsNull("TEN_CV");
        }

        public void SetTEN_CVNull() {
            pm_objDR["TEN_CV"] = System.Convert.DBNull;
        }

        public decimal dcID_LOAI_CV {
            get {
                return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_CV", IPConstants.c_DefaultDecimal);
            }
            set {
                pm_objDR["ID_LOAI_CV"] = value;
            }
        }

        public bool IsID_LOAI_CVNull() {
            return pm_objDR.IsNull("ID_LOAI_CV");
        }

        public void SetID_LOAI_CVNull() {
            pm_objDR["ID_LOAI_CV"] = System.Convert.DBNull;
        }

        public string strLOAI_CV {
            get {
                return CNull.RowNVLString(pm_objDR, "LOAI_CV", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["LOAI_CV"] = value;
            }
        }

        public bool IsLOAI_CVNull() {
            return pm_objDR.IsNull("LOAI_CV");
        }

        public void SetLOAI_CVNull() {
            pm_objDR["LOAI_CV"] = System.Convert.DBNull;
        }

        public decimal dcTY_LE_THAM_GIA {
            get {
                return CNull.RowNVLDecimal(pm_objDR, "TY_LE_THAM_GIA", IPConstants.c_DefaultDecimal);
            }
            set {
                pm_objDR["TY_LE_THAM_GIA"] = value;
            }
        }

        public bool IsTY_LE_THAM_GIANull() {
            return pm_objDR.IsNull("TY_LE_THAM_GIA");
        }

        public void SetTY_LE_THAM_GIANull() {
            pm_objDR["TY_LE_THAM_GIA"] = System.Convert.DBNull;
        }

        public decimal dcID_DON_VI {
            get {
                return CNull.RowNVLDecimal(pm_objDR, "ID_DON_VI", IPConstants.c_DefaultDecimal);
            }
            set {
                pm_objDR["ID_DON_VI"] = value;
            }
        }

        public bool IsID_DON_VINull() {
            return pm_objDR.IsNull("ID_DON_VI");
        }

        public void SetID_DON_VINull() {
            pm_objDR["ID_DON_VI"] = System.Convert.DBNull;
        }

        public string strMA_DON_VI {
            get {
                return CNull.RowNVLString(pm_objDR, "MA_DON_VI", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["MA_DON_VI"] = value;
            }
        }

        public bool IsMA_DON_VINull() {
            return pm_objDR.IsNull("MA_DON_VI");
        }

        public void SetMA_DON_VINull() {
            pm_objDR["MA_DON_VI"] = System.Convert.DBNull;
        }

        public string strTEN_DON_VI {
            get {
                return CNull.RowNVLString(pm_objDR, "TEN_DON_VI", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["TEN_DON_VI"] = value;
            }
        }

        public bool IsTEN_DON_VINull() {
            return pm_objDR.IsNull("TEN_DON_VI");
        }

        public void SetTEN_DON_VINull() {
            pm_objDR["TEN_DON_VI"] = System.Convert.DBNull;
        }

        public decimal dcID_DON_VI_CAP_TREN {
            get {
                return CNull.RowNVLDecimal(pm_objDR, "ID_DON_VI_CAP_TREN", IPConstants.c_DefaultDecimal);
            }
            set {
                pm_objDR["ID_DON_VI_CAP_TREN"] = value;
            }
        }

        public bool IsID_DON_VI_CAP_TRENNull() {
            return pm_objDR.IsNull("ID_DON_VI_CAP_TREN");
        }

        public void SetID_DON_VI_CAP_TRENNull() {
            pm_objDR["ID_DON_VI_CAP_TREN"] = System.Convert.DBNull;
        }

        public decimal dcID_LOAI_DON_VI {
            get {
                return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_DON_VI", IPConstants.c_DefaultDecimal);
            }
            set {
                pm_objDR["ID_LOAI_DON_VI"] = value;
            }
        }

        public bool IsID_LOAI_DON_VINull() {
            return pm_objDR.IsNull("ID_LOAI_DON_VI");
        }

        public void SetID_LOAI_DON_VINull() {
            pm_objDR["ID_LOAI_DON_VI"] = System.Convert.DBNull;
        }

        public string strLOAI_DON_VI {
            get {
                return CNull.RowNVLString(pm_objDR, "LOAI_DON_VI", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["LOAI_DON_VI"] = value;
            }
        }

        public bool IsLOAI_DON_VINull() {
            return pm_objDR.IsNull("LOAI_DON_VI");
        }

        public void SetLOAI_DON_VINull() {
            pm_objDR["LOAI_DON_VI"] = System.Convert.DBNull;
        }

        public decimal dcID_CAP_DON_VI {
            get {
                return CNull.RowNVLDecimal(pm_objDR, "ID_CAP_DON_VI", IPConstants.c_DefaultDecimal);
            }
            set {
                pm_objDR["ID_CAP_DON_VI"] = value;
            }
        }

        public bool IsID_CAP_DON_VINull() {
            return pm_objDR.IsNull("ID_CAP_DON_VI");
        }

        public void SetID_CAP_DON_VINull() {
            pm_objDR["ID_CAP_DON_VI"] = System.Convert.DBNull;
        }

        public string strCAP_DON_VI {
            get {
                return CNull.RowNVLString(pm_objDR, "CAP_DON_VI", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["CAP_DON_VI"] = value;
            }
        }

        public bool IsCAP_DON_VINull() {
            return pm_objDR.IsNull("CAP_DON_VI");
        }

        public void SetCAP_DON_VINull() {
            pm_objDR["CAP_DON_VI"] = System.Convert.DBNull;
        }

        public string strDIA_BAN {
            get {
                return CNull.RowNVLString(pm_objDR, "DIA_BAN", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["DIA_BAN"] = value;
            }
        }

        public bool IsDIA_BANNull() {
            return pm_objDR.IsNull("DIA_BAN");
        }

        public void SetDIA_BANNull() {
            pm_objDR["DIA_BAN"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_BAT_DAU {
            get {
                return CNull.RowNVLDate(pm_objDR, "NGAY_BAT_DAU", IPConstants.c_DefaultDate);
            }
            set {
                pm_objDR["NGAY_BAT_DAU"] = value;
            }
        }

        public bool IsNGAY_BAT_DAUNull() {
            return pm_objDR.IsNull("NGAY_BAT_DAU");
        }

        public void SetNGAY_BAT_DAUNull() {
            pm_objDR["NGAY_BAT_DAU"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_KET_THUC {
            get {
                return CNull.RowNVLDate(pm_objDR, "NGAY_KET_THUC", IPConstants.c_DefaultDate);
            }
            set {
                pm_objDR["NGAY_KET_THUC"] = value;
            }
        }

        public bool IsNGAY_KET_THUCNull() {
            return pm_objDR.IsNull("NGAY_KET_THUC");
        }

        public void SetNGAY_KET_THUCNull() {
            pm_objDR["NGAY_KET_THUC"] = System.Convert.DBNull;
        }

        public decimal dcID_TRANG_LAO_DONG {
            get {
                return CNull.RowNVLDecimal(pm_objDR, "ID_TRANG_LAO_DONG", IPConstants.c_DefaultDecimal);
            }
            set {
                pm_objDR["ID_TRANG_LAO_DONG"] = value;
            }
        }

        public bool IsID_TRANG_LAO_DONGNull() {
            return pm_objDR.IsNull("ID_TRANG_LAO_DONG");
        }

        public void SetID_TRANG_LAO_DONGNull() {
            pm_objDR["ID_TRANG_LAO_DONG"] = System.Convert.DBNull;
        }

        public string strTRANG_THAI_LAO_DONG {
            get {
                return CNull.RowNVLString(pm_objDR, "TRANG_THAI_LAO_DONG", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["TRANG_THAI_LAO_DONG"] = value;
            }
        }

        public bool IsTRANG_THAI_LAO_DONGNull() {
            return pm_objDR.IsNull("TRANG_THAI_LAO_DONG");
        }

        public void SetTRANG_THAI_LAO_DONGNull() {
            pm_objDR["TRANG_THAI_LAO_DONG"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_CO_HIEU_LUC {
            get {
                return CNull.RowNVLDate(pm_objDR, "NGAY_CO_HIEU_LUC", IPConstants.c_DefaultDate);
            }
            set {
                pm_objDR["NGAY_CO_HIEU_LUC"] = value;
            }
        }

        public bool IsNGAY_CO_HIEU_LUCNull() {
            return pm_objDR.IsNull("NGAY_CO_HIEU_LUC");
        }

        public void SetNGAY_CO_HIEU_LUCNull() {
            pm_objDR["NGAY_CO_HIEU_LUC"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_HET_HIEU_LUC {
            get {
                return CNull.RowNVLDate(pm_objDR, "NGAY_HET_HIEU_LUC", IPConstants.c_DefaultDate);
            }
            set {
                pm_objDR["NGAY_HET_HIEU_LUC"] = value;
            }
        }

        public bool IsNGAY_HET_HIEU_LUCNull() {
            return pm_objDR.IsNull("NGAY_HET_HIEU_LUC");
        }

        public void SetNGAY_HET_HIEU_LUCNull() {
            pm_objDR["NGAY_HET_HIEU_LUC"] = System.Convert.DBNull;
        }

        public string strTRANG_THAI_HIEN_TAI {
            get {
                return CNull.RowNVLString(pm_objDR, "TRANG_THAI_HIEN_TAI", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["TRANG_THAI_HIEN_TAI"] = value;
            }
        }

        public bool IsTRANG_THAI_HIEN_TAINull() {
            return pm_objDR.IsNull("TRANG_THAI_HIEN_TAI");
        }

        public void SetTRANG_THAI_HIEN_TAINull() {
            pm_objDR["TRANG_THAI_HIEN_TAI"] = System.Convert.DBNull;
        }

        public string strTRANG_THAI_CV {
            get {
                return CNull.RowNVLString(pm_objDR, "TRANG_THAI_CV", IPConstants.c_DefaultString);
            }
            set {
                pm_objDR["TRANG_THAI_CV"] = value;
            }
        }

        public bool IsTRANG_THAI_CVNull() {
            return pm_objDR.IsNull("TRANG_THAI_CV");
        }

        public void SetTRANG_THAI_CVNull() {
            pm_objDR["TRANG_THAI_CV"] = System.Convert.DBNull;
        }

        #endregion
        #region "Init Functions"
        public US_V_DM_DU_LIEU_NHAN_VIEN() {
            pm_objDS = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            pm_strTableName = c_TableName;
            pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
        }

        public US_V_DM_DU_LIEU_NHAN_VIEN(DataRow i_objDR)
            : this() {
            this.DataRow2Me(i_objDR);
        }

        public US_V_DM_DU_LIEU_NHAN_VIEN(decimal i_dbID) {
            pm_objDS = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            pm_strTableName = c_TableName;
            IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
            v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
            SqlCommand v_cmdSQL;
            v_cmdSQL = v_objMkCmd.getSelectCmd();
            this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
            pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
        }
        #endregion

        #region "Addtional"

        public void FillDatasetByIdCV(DS_V_DM_DU_LIEU_NHAN_VIEN op_ds_nhan_su, decimal i_dc_id) {
            CStoredProc v_sp = new CStoredProc("pr_V_DM_DU_LIEU_NHAN_VIEN_select_by_ID_CHUC_VU");
            v_sp.addDecimalInputParam("@ID_CHUC_VU", i_dc_id);
            v_sp.fillDataSetByCommand(this, op_ds_nhan_su);
        }


        public void FillDatasetAll(DS_V_DM_DU_LIEU_NHAN_VIEN op_ds_v_dm_du_lieu_nhan_vien
                                            , string ip_str_search
                                            , string ip_str_ma_nhan_vien
                                            , string ip_str_ho_va_ten
                                            , string ip_str_gioi_tinh
                                            , string ip_str_ngay_sinh
                                            , string ip_str_thang_sinh
                                            , string ip_str_nam_sinh
                                            , string ip_str_trinh_do
                                            , string ip_str_ma_chuc_vu
                                            , string ip_str_ten_chuc_vu
                                            , string ip_str_loai_chuc_vu
                                            , string ip_str_ty_le_them_gia
                                            , string ip_str_ma_don_vi
                                            , string ip_str_ten_don_vi
                                            , string ip_str_loai_don_vi
                                            , string ip_str_cap_don_vi
                                            , string ip_str_dia_ban
                                            , string ip_str_ngay_bat_dau
                                            , string ip_str_thang_bat_dau
                                            , string ip_str_nam_bat_dau
                                            , string ip_str_ngay_ket_thuc
                                            , string ip_str_thang_ket_thuc
                                            , string ip_str_nam_ket_thuc
                                            , string ip_str_trang_thai_lao_dong
                                            , string ip_str_ngay_co_hieu_luc
                                            , string ip_str_thang_co_hieu_luc
                                            , string ip_str_nam_co_hieu_luc
                                            , string ip_str_ngay_het_hieu_luc
                                            , string ip_str_thang_het_hieu_luc
                                            , string ip_str_nam_het_hieu_luc
                                            , string ip_str_trang_thai_hien_tai
                                            , string ip_str_trang_thai_chuc_vu
                                            , string ip_str_oderby_01
                                            , string ip_str_oderby_02
                                            , string ip_str_oderby_03
            ) {

            CStoredProc v_stored_proc = new CStoredProc("pr_V_DM_DU_LIEU_NHAN_VIEN_search");
            v_stored_proc.addNVarcharInputParam("@ip_str_01_search", ip_str_search);
            v_stored_proc.addNVarcharInputParam("@ip_str_02_ma_nhan_vien", ip_str_ma_nhan_vien);
            v_stored_proc.addNVarcharInputParam("@ip_str_03_ho_va_ten", ip_str_ho_va_ten);
            v_stored_proc.addNVarcharInputParam("@ip_str_04_gioi_tinh", ip_str_gioi_tinh);
            v_stored_proc.addNVarcharInputParam("@ip_str_05_ngay_sinh", ip_str_ngay_sinh);
            v_stored_proc.addNVarcharInputParam("@ip_str_06_thang_sinh", ip_str_thang_sinh);
            v_stored_proc.addNVarcharInputParam("@ip_str_07_nam_sinh", ip_str_nam_sinh);
            v_stored_proc.addNVarcharInputParam("@ip_str_08_trinh_do", ip_str_trinh_do);
            v_stored_proc.addNVarcharInputParam("@ip_str_09_ma_chuc_vu", ip_str_ma_chuc_vu);
            v_stored_proc.addNVarcharInputParam("@ip_str_10_ten_chuc_vu", ip_str_ten_chuc_vu);
            v_stored_proc.addNVarcharInputParam("@ip_str_11_loai_chuc_vu", ip_str_loai_chuc_vu);
            v_stored_proc.addNVarcharInputParam("@ip_str_12_ty_le_them_gia", ip_str_ty_le_them_gia);
            v_stored_proc.addNVarcharInputParam("@ip_str_13_ma_don_vi", ip_str_ma_don_vi);
            v_stored_proc.addNVarcharInputParam("@ip_str_14_ten_don_vi", ip_str_ten_don_vi);
            v_stored_proc.addNVarcharInputParam("@ip_str_15_loai_don_vi", ip_str_loai_don_vi);
            v_stored_proc.addNVarcharInputParam("@ip_str_16_cap_don_vi", ip_str_cap_don_vi);
            v_stored_proc.addNVarcharInputParam("@ip_str_17_dia_ban", ip_str_dia_ban);
            v_stored_proc.addNVarcharInputParam("@ip_str_18_ngay_bat_dau", ip_str_ngay_bat_dau);
            v_stored_proc.addNVarcharInputParam("@ip_str_19_thang_bat_dau", ip_str_thang_bat_dau);
            v_stored_proc.addNVarcharInputParam("@ip_str_20_nam_bat_dau", ip_str_nam_bat_dau);
            v_stored_proc.addNVarcharInputParam("@ip_str_21_ngay_ket_thuc", ip_str_ngay_ket_thuc);
            v_stored_proc.addNVarcharInputParam("@ip_str_22_thang_ket_thuc", ip_str_thang_ket_thuc);
            v_stored_proc.addNVarcharInputParam("@ip_str_23_nam_ket_thuc", ip_str_nam_ket_thuc);
            v_stored_proc.addNVarcharInputParam("@ip_str_24_trang_thai_lao_dong", ip_str_trang_thai_lao_dong);
            v_stored_proc.addNVarcharInputParam("@ip_str_25_ngay_co_hieu_luc", ip_str_ngay_co_hieu_luc);
            v_stored_proc.addNVarcharInputParam("@ip_str_26_thang_co_hieu_luc", ip_str_thang_co_hieu_luc);
            v_stored_proc.addNVarcharInputParam("@ip_str_27_nam_co_hieu_luc", ip_str_nam_co_hieu_luc);
            v_stored_proc.addNVarcharInputParam("@ip_str_28_ngay_het_hieu_luc", ip_str_ngay_het_hieu_luc);
            v_stored_proc.addNVarcharInputParam("@ip_str_29_thang_het_hieu_luc", ip_str_thang_het_hieu_luc);
            v_stored_proc.addNVarcharInputParam("@ip_str_30_nam_het_hieu_luc", ip_str_nam_het_hieu_luc);
            v_stored_proc.addNVarcharInputParam("@ip_str_31_trang_thai_hien_tai", ip_str_trang_thai_hien_tai);
            v_stored_proc.addNVarcharInputParam("@ip_str_32_trang_thai_chuc_vu", ip_str_trang_thai_chuc_vu);
            v_stored_proc.addNVarcharInputParam("@ip_oderby_01", "");
            v_stored_proc.addNVarcharInputParam("@ip_oderby_02", "");
            v_stored_proc.addNVarcharInputParam("@ip_oderby_03", "");
            v_stored_proc.fillDataSetByCommand(this, op_ds_v_dm_du_lieu_nhan_vien);
        }

        public void FillDatasetGender(string ip_str_key_word, string ip_str_gender, DS_V_DM_DU_LIEU_NHAN_VIEN op_ds_v_dm_du_lieu_nhan_vien) {
            CStoredProc v_stored_proc = new CStoredProc("pr_V_DM_DU_LIEU_NHAN_VIEN_search_gioi_tinh");
            v_stored_proc.addNVarcharInputParam("@ip_str_search", ip_str_key_word);
            v_stored_proc.addNVarcharInputParam("@ip_str_gioi_tinh", ip_str_gender);
            v_stored_proc.fillDataSetByCommand(this, op_ds_v_dm_du_lieu_nhan_vien);
        }

        public void FillDatasetTraCuuThongTinNhanVienChung(DS_V_DM_DU_LIEU_NHAN_VIEN op_ds_v_dm_du_lieu_nhan_vien
                                                            , string ip_str_key_word
                                                            , string ip_str_gender
                                                            , string ip_str_trang_thai_lao_dong) {
            CStoredProc v_stored_proc = new CStoredProc("pr_V_DM_DU_LIEU_NHAN_VIEN_Search_TraCuuThongTinNhanVienChung");
            v_stored_proc.addNVarcharInputParam("@ip_str_search", ip_str_key_word);
            v_stored_proc.addNVarcharInputParam("@ip_str_gioi_tinh", ip_str_gender);
            v_stored_proc.addNVarcharInputParam("@ip_str_trang_thai_lao_dong", ip_str_trang_thai_lao_dong);
            v_stored_proc.fillDataSetByCommand(this, op_ds_v_dm_du_lieu_nhan_vien);
        }

        public void FillDataset_By_ID_Don_Vi(DS_V_DM_DU_LIEU_NHAN_VIEN op_ds_v_dm_du_lieu_nhan_vien, decimal ip_dc_id_don_vi, string ip_str_key_word, string ip_str_gender, string ip_str_trang_thai_lao_dong) {
            CStoredProc v_stored_proc = new CStoredProc("pr_V_DM_DU_LIEU_NHAN_VIEN_Search_theo_phong_ban");
            v_stored_proc.addNVarcharInputParam("@ip_dc_don_vi", ip_dc_id_don_vi);
            v_stored_proc.addNVarcharInputParam("@ip_str_search", ip_str_key_word);
            v_stored_proc.addNVarcharInputParam("@ip_str_gioi_tinh", ip_str_gender);
            v_stored_proc.addNVarcharInputParam("@ip_str_trang_thai_lao_dong", ip_str_trang_thai_lao_dong);
            v_stored_proc.fillDataSetByCommand(this, op_ds_v_dm_du_lieu_nhan_vien);
        }

        public void FillDatasetByIdCV_ThoiDiem(DS_V_DM_DU_LIEU_NHAN_VIEN op_ds_nhan_su, decimal i_dc_id, DateTime thoi_diem) {
            CStoredProc v_sp = new CStoredProc("pr_V_DM_DU_LIEU_NHAN_VIEN_select_by_ID_CHUC_VU_THOI_DIEM");
            v_sp.addDecimalInputParam("@ID_CHUC_VU", i_dc_id);
            v_sp.addDatetimeInputParam("@THOI_DIEM", thoi_diem);
            v_sp.fillDataSetByCommand(this, op_ds_nhan_su);
        }


        #endregion
    }
}

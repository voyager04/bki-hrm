///************************************************
/// Generated by: THAIPH
/// Date: 13/04/2014 10:37:20
/// Goal: Create User Service Class for V_DM_NHAN_SU_DU_AN
///************************************************
/// <summary>
/// Create User Service Class for V_DM_NHAN_SU_DU_AN
/// </summary>

using System;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;



namespace BKI_HRM.US
{

    public class US_V_DM_NHAN_SU_DU_AN : US_Object
    {
        private const string c_TableName = "V_DM_NHAN_SU_DU_AN";
        #region "Public Properties"
        public decimal dcID_DU_AN
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_DU_AN", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_DU_AN"] = value;
            }
        }

        public bool IsID_DU_ANNull()
        {
            return pm_objDR.IsNull("ID_DU_AN");
        }

        public void SetID_DU_ANNull()
        {
            pm_objDR["ID_DU_AN"] = System.Convert.DBNull;
        }

        public string strMA_DU_AN
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "MA_DU_AN", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["MA_DU_AN"] = value;
            }
        }

        public bool IsMA_DU_ANNull()
        {
            return pm_objDR.IsNull("MA_DU_AN");
        }

        public void SetMA_DU_ANNull()
        {
            pm_objDR["MA_DU_AN"] = System.Convert.DBNull;
        }

        public string strTEN_DU_AN
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TEN_DU_AN", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TEN_DU_AN"] = value;
            }
        }

        public bool IsTEN_DU_ANNull()
        {
            return pm_objDR.IsNull("TEN_DU_AN");
        }

        public void SetTEN_DU_ANNull()
        {
            pm_objDR["TEN_DU_AN"] = System.Convert.DBNull;
        }

        public decimal dcID_NHAN_SU
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_NHAN_SU", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_NHAN_SU"] = value;
            }
        }

        public bool IsID_NHAN_SUNull()
        {
            return pm_objDR.IsNull("ID_NHAN_SU");
        }

        public void SetID_NHAN_SUNull()
        {
            pm_objDR["ID_NHAN_SU"] = System.Convert.DBNull;
        }

        public string strMA_NV
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "MA_NV", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["MA_NV"] = value;
            }
        }

        public bool IsMA_NVNull()
        {
            return pm_objDR.IsNull("MA_NV");
        }

        public void SetMA_NVNull()
        {
            pm_objDR["MA_NV"] = System.Convert.DBNull;
        }

        public string strHO_DEM
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "HO_DEM", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["HO_DEM"] = value;
            }
        }

        public bool IsHO_DEMNull()
        {
            return pm_objDR.IsNull("HO_DEM");
        }

        public void SetHO_DEMNull()
        {
            pm_objDR["HO_DEM"] = System.Convert.DBNull;
        }

        public string strTEN
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TEN", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TEN"] = value;
            }
        }

        public bool IsTENNull()
        {
            return pm_objDR.IsNull("TEN");
        }

        public void SetTENNull()
        {
            pm_objDR["TEN"] = System.Convert.DBNull;
        }

        public string strVI_TRI
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "VI_TRI", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["VI_TRI"] = value;
            }
        }

        public bool IsVI_TRINull()
        {
            return pm_objDR.IsNull("VI_TRI");
        }

        public void SetVI_TRINull()
        {
            pm_objDR["VI_TRI"] = System.Convert.DBNull;
        }

        public DateTime datTHOI_DIEM_TG
        {
            get
            {
                return CNull.RowNVLDate(pm_objDR, "THOI_DIEM_TG", IPConstants.c_DefaultDate);
            }
            set
            {
                pm_objDR["THOI_DIEM_TG"] = value;
            }
        }

        public bool IsTHOI_DIEM_TGNull()
        {
            return pm_objDR.IsNull("THOI_DIEM_TG");
        }

        public void SetTHOI_DIEM_TGNull()
        {
            pm_objDR["THOI_DIEM_TG"] = System.Convert.DBNull;
        }

        public DateTime datTHOI_DIEM_KT
        {
            get
            {
                return CNull.RowNVLDate(pm_objDR, "THOI_DIEM_KT", IPConstants.c_DefaultDate);
            }
            set
            {
                pm_objDR["THOI_DIEM_KT"] = value;
            }
        }

        public bool IsTHOI_DIEM_KTNull()
        {
            return pm_objDR.IsNull("THOI_DIEM_KT");
        }

        public void SetTHOI_DIEM_KTNull()
        {
            pm_objDR["THOI_DIEM_KT"] = System.Convert.DBNull;
        }

        public decimal dcTHOI_GIAN_TG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "THOI_GIAN_TG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["THOI_GIAN_TG"] = value;
            }
        }

        public bool IsTHOI_GIAN_TGNull()
        {
            return pm_objDR.IsNull("THOI_GIAN_TG");
        }

        public void SetTHOI_GIAN_TGNull()
        {
            pm_objDR["THOI_GIAN_TG"] = System.Convert.DBNull;
        }

        public string strDANH_HIEU
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "DANH_HIEU", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["DANH_HIEU"] = value;
            }
        }

        public bool IsDANH_HIEUNull()
        {
            return pm_objDR.IsNull("DANH_HIEU");
        }

        public void SetDANH_HIEUNull()
        {
            pm_objDR["DANH_HIEU"] = System.Convert.DBNull;
        }

        public string strMO_TA
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "MO_TA", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["MO_TA"] = value;
            }
        }

        public bool IsMO_TANull()
        {
            return pm_objDR.IsNull("MO_TA");
        }

        public void SetMO_TANull()
        {
            pm_objDR["MO_TA"] = System.Convert.DBNull;
        }

        public string strLUA_CHON
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "LUA_CHON", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["LUA_CHON"] = value;
            }
        }

        public bool IsLUA_CHONNull()
        {
            return pm_objDR.IsNull("LUA_CHON");
        }

        public void SetLUA_CHONNull()
        {
            pm_objDR["LUA_CHON"] = System.Convert.DBNull;
        }

        public decimal dcID_QUYET_DINH
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_QUYET_DINH", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_QUYET_DINH"] = value;
            }
        }

        public bool IsID_QUYET_DINHNull()
        {
            return pm_objDR.IsNull("ID_QUYET_DINH");
        }

        public void SetID_QUYET_DINHNull()
        {
            pm_objDR["ID_QUYET_DINH"] = System.Convert.DBNull;
        }

        public string strMA_QUYET_DINH
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "MA_QUYET_DINH", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["MA_QUYET_DINH"] = value;
            }
        }

        public bool IsMA_QUYET_DINHNull()
        {
            return pm_objDR.IsNull("MA_QUYET_DINH");
        }

        public void SetMA_QUYET_DINHNull()
        {
            pm_objDR["MA_QUYET_DINH"] = System.Convert.DBNull;
        }

        public decimal dcID_LOAI_QD
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_QD", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_LOAI_QD"] = value;
            }
        }

        public bool IsID_LOAI_QDNull()
        {
            return pm_objDR.IsNull("ID_LOAI_QD");
        }

        public void SetID_LOAI_QDNull()
        {
            pm_objDR["ID_LOAI_QD"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_CO_HIEU_LUC
        {
            get
            {
                return CNull.RowNVLDate(pm_objDR, "NGAY_CO_HIEU_LUC", IPConstants.c_DefaultDate);
            }
            set
            {
                pm_objDR["NGAY_CO_HIEU_LUC"] = value;
            }
        }

        public bool IsNGAY_CO_HIEU_LUCNull()
        {
            return pm_objDR.IsNull("NGAY_CO_HIEU_LUC");
        }

        public void SetNGAY_CO_HIEU_LUCNull()
        {
            pm_objDR["NGAY_CO_HIEU_LUC"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_KY
        {
            get
            {
                return CNull.RowNVLDate(pm_objDR, "NGAY_KY", IPConstants.c_DefaultDate);
            }
            set
            {
                pm_objDR["NGAY_KY"] = value;
            }
        }

        public bool IsNGAY_KYNull()
        {
            return pm_objDR.IsNull("NGAY_KY");
        }

        public void SetNGAY_KYNull()
        {
            pm_objDR["NGAY_KY"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_HET_HIEU_LUC
        {
            get
            {
                return CNull.RowNVLDate(pm_objDR, "NGAY_HET_HIEU_LUC", IPConstants.c_DefaultDate);
            }
            set
            {
                pm_objDR["NGAY_HET_HIEU_LUC"] = value;
            }
        }

        public bool IsNGAY_HET_HIEU_LUCNull()
        {
            return pm_objDR.IsNull("NGAY_HET_HIEU_LUC");
        }

        public void SetNGAY_HET_HIEU_LUCNull()
        {
            pm_objDR["NGAY_HET_HIEU_LUC"] = System.Convert.DBNull;
        }

        public string strNOI_DUNG
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "NOI_DUNG", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["NOI_DUNG"] = value;
            }
        }

        public bool IsNOI_DUNGNull()
        {
            return pm_objDR.IsNull("NOI_DUNG");
        }

        public void SetNOI_DUNGNull()
        {
            pm_objDR["NOI_DUNG"] = System.Convert.DBNull;
        }

        public string strLINK
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "LINK", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["LINK"] = value;
            }
        }

        public bool IsLINKNull()
        {
            return pm_objDR.IsNull("LINK");
        }

        public void SetLINKNull()
        {
            pm_objDR["LINK"] = System.Convert.DBNull;
        }

        public string strLOAI_QD
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "LOAI_QD", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["LOAI_QD"] = value;
            }
        }

        public bool IsLOAI_QDNull()
        {
            return pm_objDR.IsNull("LOAI_QD");
        }

        public void SetLOAI_QDNull()
        {
            pm_objDR["LOAI_QD"] = System.Convert.DBNull;
        }

        public decimal dcID_TRANG_LAO_DONG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_TRANG_LAO_DONG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_TRANG_LAO_DONG"] = value;
            }
        }

        public bool IsID_TRANG_LAO_DONGNull()
        {
            return pm_objDR.IsNull("ID_TRANG_LAO_DONG");
        }

        public void SetID_TRANG_LAO_DONGNull()
        {
            pm_objDR["ID_TRANG_LAO_DONG"] = System.Convert.DBNull;
        }

        public string strTRANG_THAI_LAO_DONG
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TRANG_THAI_LAO_DONG", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TRANG_THAI_LAO_DONG"] = value;
            }
        }

        public bool IsTRANG_THAI_LAO_DONGNull()
        {
            return pm_objDR.IsNull("TRANG_THAI_LAO_DONG");
        }

        public void SetTRANG_THAI_LAO_DONGNull()
        {
            pm_objDR["TRANG_THAI_LAO_DONG"] = System.Convert.DBNull;
        }

        public string strTRANG_THAI_HIEN_TAI
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TRANG_THAI_HIEN_TAI", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TRANG_THAI_HIEN_TAI"] = value;
            }
        }

        public bool IsTRANG_THAI_HIEN_TAINull()
        {
            return pm_objDR.IsNull("TRANG_THAI_HIEN_TAI");
        }

        public void SetTRANG_THAI_HIEN_TAINull()
        {
            pm_objDR["TRANG_THAI_HIEN_TAI"] = System.Convert.DBNull;
        }

        public decimal dcID_PHAP_NHAN_QD
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_PHAP_NHAN_QD", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_PHAP_NHAN_QD"] = value;
            }
        }

        public bool IsID_PHAP_NHAN_QDNull()
        {
            return pm_objDR.IsNull("ID_PHAP_NHAN_QD");
        }

        public void SetID_PHAP_NHAN_QDNull()
        {
            pm_objDR["ID_PHAP_NHAN_QD"] = System.Convert.DBNull;
        }

        public string strMA_PHAP_NHAN
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "MA_PHAP_NHAN", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["MA_PHAP_NHAN"] = value;
            }
        }

        public bool IsMA_PHAP_NHANNull()
        {
            return pm_objDR.IsNull("MA_PHAP_NHAN");
        }

        public void SetMA_PHAP_NHANNull()
        {
            pm_objDR["MA_PHAP_NHAN"] = System.Convert.DBNull;
        }

        public decimal dcID_VI_TRI
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_VI_TRI", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_VI_TRI"] = value;
            }
        }

        public bool IsID_VI_TRINull()
        {
            return pm_objDR.IsNull("ID_VI_TRI");
        }

        public void SetID_VI_TRINull()
        {
            pm_objDR["ID_VI_TRI"] = System.Convert.DBNull;
        }

        public decimal dcID_DANH_HIEU
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_DANH_HIEU", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_DANH_HIEU"] = value;
            }
        }

        public bool IsID_DANH_HIEUNull()
        {
            return pm_objDR.IsNull("ID_DANH_HIEU");
        }

        public void SetID_DANH_HIEUNull()
        {
            pm_objDR["ID_DANH_HIEU"] = System.Convert.DBNull;
        }

        public string strTRANG_THAI_NHAN_SU_HIEN_TAI
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TRANG_THAI_NHAN_SU_HIEN_TAI", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TRANG_THAI_NHAN_SU_HIEN_TAI"] = value;
            }
        }

        public bool IsTRANG_THAI_NHAN_SU_HIEN_TAINull()
        {
            return pm_objDR.IsNull("TRANG_THAI_NHAN_SU_HIEN_TAI");
        }

        public void SetTRANG_THAI_NHAN_SU_HIEN_TAINull()
        {
            pm_objDR["TRANG_THAI_NHAN_SU_HIEN_TAI"] = System.Convert.DBNull;
        }

        public decimal dcID_PHAP_NHAN_TTLD
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_PHAP_NHAN_TTLD", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_PHAP_NHAN_TTLD"] = value;
            }
        }

        public bool IsID_PHAP_NHAN_TTLDNull()
        {
            return pm_objDR.IsNull("ID_PHAP_NHAN_TTLD");
        }

        public void SetID_PHAP_NHAN_TTLDNull()
        {
            pm_objDR["ID_PHAP_NHAN_TTLD"] = System.Convert.DBNull;
        }

        #endregion
        #region "Init Functions"
        public US_V_DM_NHAN_SU_DU_AN()
        {
            pm_objDS = new DS_V_DM_NHAN_SU_DU_AN();
            pm_strTableName = c_TableName;
            pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
        }

        public US_V_DM_NHAN_SU_DU_AN(DataRow i_objDR)
            : this()
        {
            this.DataRow2Me(i_objDR);
        }

        public US_V_DM_NHAN_SU_DU_AN(decimal i_dbID)
        {
            pm_objDS = new DS_V_DM_NHAN_SU_DU_AN();
            pm_strTableName = c_TableName;
            IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
            v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
            SqlCommand v_cmdSQL;
            v_cmdSQL = v_objMkCmd.getSelectCmd();
            this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
            pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
        }
        #endregion

        public void FillDatasetByIdDuAn(DS_V_DM_NHAN_SU_DU_AN op_ds_nhan_su, decimal i_dc_id_du_an, decimal i_dc_id_phap_nhan)
        {
            CStoredProc v_sp = new CStoredProc("pr_V_NHAN_SU_DU_AN_select_by_ID");
            v_sp.addDecimalInputParam("@id_du_an", i_dc_id_du_an);
            v_sp.addDecimalInputParam("@id_phap_nhan", i_dc_id_phap_nhan);
            v_sp.fillDataSetByCommand(this, op_ds_nhan_su);
        }

        public void FillDatasetSearch(DS_V_DM_NHAN_SU_DU_AN op_ds_nhan_su, string v_str_tu_khoa)
        {
            CStoredProc v_sp = new CStoredProc("pr_V_NHAN_SU_DU_AN_search");
            v_sp.addNVarcharInputParam("@STR_DU_AN", v_str_tu_khoa);
            v_sp.fillDataSetByCommand(this, op_ds_nhan_su);
        }

        public void FillDatasetTuNgayDenNgay(
            DS_V_DM_NHAN_SU_DU_AN op_ds_nhan_su,
            string v_str_tu_khoa,
            DateTime v_dat_tu_ngay,
            DateTime v_dat_den_ngay,
            decimal v_dc_tim_kiem_theo_ngay,
            decimal ip_dc_id_phap_nhan)
        {
            CStoredProc v_sp = new CStoredProc("pr_V_NHAN_SU_DU_AN_tu_ngay_den_ngay");
            v_sp.addNVarcharInputParam("@ip_str_keyword", v_str_tu_khoa);
            v_sp.addDatetimeInputParam("@tu_ngay", v_dat_tu_ngay);
            v_sp.addDatetimeInputParam("@den_ngay", v_dat_den_ngay);
            v_sp.addDecimalInputParam("@tim_kiem_theo_ngay", v_dc_tim_kiem_theo_ngay);
            v_sp.addDecimalInputParam("@id_phap_nhan", ip_dc_id_phap_nhan);
            v_sp.fillDataSetByCommand(this, op_ds_nhan_su);
        }
    }
}

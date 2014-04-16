///************************************************
/// Generated by: TrongHV
/// Date: 09/01/2014 05:06:40
/// Goal: Create User Service Class for V_GD_TRANG_THAI_LAO_DONG
///************************************************
/// <summary>
/// Create User Service Class for V_GD_TRANG_THAI_LAO_DONG
/// </summary>

using System;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;



namespace BKI_HRM.US{

public class US_V_GD_TRANG_THAI_LAO_DONG : US_Object
{
	private const string c_TableName = "V_GD_TRANG_THAI_LAO_DONG";
    #region "Public Properties"
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

    public string strLOAI_QUYET_DINH
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "LOAI_QUYET_DINH", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["LOAI_QUYET_DINH"] = value;
        }
    }

    public bool IsLOAI_QUYET_DINHNull()
    {
        return pm_objDR.IsNull("LOAI_QUYET_DINH");
    }

    public void SetLOAI_QUYET_DINHNull()
    {
        pm_objDR["LOAI_QUYET_DINH"] = System.Convert.DBNull;
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

    public decimal dcID
    {
        get
        {
            return CNull.RowNVLDecimal(pm_objDR, "ID", IPConstants.c_DefaultDecimal);
        }
        set
        {
            pm_objDR["ID"] = value;
        }
    }

    public bool IsIDNull()
    {
        return pm_objDR.IsNull("ID");
    }

    public void SetIDNull()
    {
        pm_objDR["ID"] = System.Convert.DBNull;
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

    #endregion
    #region "Init Functions"
    public US_V_GD_TRANG_THAI_LAO_DONG()
    {
        pm_objDS = new DS_V_GD_TRANG_THAI_LAO_DONG();
        pm_strTableName = c_TableName;
        pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
    }

    public US_V_GD_TRANG_THAI_LAO_DONG(DataRow i_objDR)
        : this()
    {
        this.DataRow2Me(i_objDR);
    }

    public US_V_GD_TRANG_THAI_LAO_DONG(decimal i_dbID)
    {
        pm_objDS = new DS_V_GD_TRANG_THAI_LAO_DONG();
        pm_strTableName = c_TableName;
        IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
        v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
        SqlCommand v_cmdSQL;
        v_cmdSQL = v_objMkCmd.getSelectCmd();
        this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
        pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
    }
    #endregion
    #region Addtional

    public void FillDataset(string ip_txt_search,DS_V_GD_TRANG_THAI_LAO_DONG op_ds_v_gd_trang_thai_lao_dong){
        CStoredProc v_stored_proc = new CStoredProc("pr_V_GD_TRANG_THAI_LAO_DONG_search");
        v_stored_proc.addNVarcharInputParam("@ip_str_search", ip_txt_search);
        v_stored_proc.fillDataSetByCommand(this,op_ds_v_gd_trang_thai_lao_dong);
    }

    public void FillDataset(DateTime ip_dat_bat_dau, DateTime ip_dat_ket_thuc, string ip_txt_search, DS_V_GD_TRANG_THAI_LAO_DONG op_ds_v_gd_trang_thai_lao_dong) {
        CStoredProc v_stored_proc = new CStoredProc("pr_V_GD_TRANG_THAI_LAO_DONG_search_datetime");
        v_stored_proc.addDatetimeInputParam("@ip_dat_bat_dau", ip_dat_bat_dau);
        v_stored_proc.addDatetimeInputParam("@ip_dat_ket_thuc", ip_dat_ket_thuc);
        v_stored_proc.addNVarcharInputParam("@ip_str_search", ip_txt_search);
        v_stored_proc.fillDataSetByCommand(this, op_ds_v_gd_trang_thai_lao_dong);
    }
    public void FillDatasetByManhanvien(DS_V_GD_TRANG_THAI_LAO_DONG op_ds, string ip_str_ma_nv)
    {
        
        CStoredProc v_sp = new CStoredProc("pr_V_GD_TRANG_THAI_LAO_DONG_By_Ma_nhan_vien");
       // CStoredProc v_sp = new CStoredProc("pr_V_GD_TRANG_THAI_LAO_DONG_hien_tai_By_Ma_nhan_vien");
        v_sp.addDecimalInputParam("@MA_NHAN_VIEN", ip_str_ma_nv);
        v_sp.fillDataSetByCommand(this, op_ds);
    }

    public void FillDatasetByManhanvien_trang_thai_hien_tai(DS_V_GD_TRANG_THAI_LAO_DONG op_ds, string ip_str_ma_nv)
    {
        CStoredProc v_sp = new CStoredProc("pr_V_GD_TRANG_THAI_LAO_DONG_hien_tai_By_Ma_nhan_vien");
      //  CStoredProc v_sp = new CStoredProc("pr_V_GD_TRANG_THAI_LAO_DONG_By_Ma_nhan_vien");
        v_sp.addNVarcharInputParam("@MA_NHAN_VIEN", ip_str_ma_nv);
        v_sp.fillDataSetByCommand(this, op_ds);
    }
    public void FillDataset_Search(DS_V_GD_TRANG_THAI_LAO_DONG op_ds, string ip_str_search)
    {
        CStoredProc v_sp = new CStoredProc("pr_V_GD_TRANG_THAI_LAO_DONG_search");
        v_sp.addNVarcharInputParam("@ip_str_search", ip_str_search);
        v_sp.fillDataSetByCommand(this, op_ds);
    }

    public void delete_by_id_gd_chi_tiet_trang_thai_ld(decimal ip_dc_id_chi_tiet_trang_thai_lao_dong)
    {
        CStoredProc v_sp = new CStoredProc("pr_V_GD_TRANG_THAI_LAO_DONG_Delete");
        v_sp.addDecimalInputParam("@ID", ip_dc_id_chi_tiet_trang_thai_lao_dong);
        v_sp.ExecuteCommand(this);
    }
    #endregion

    public void FillDatasetNVSapQuayLai(DS_V_GD_TRANG_THAI_LAO_DONG m_ds)
    {
        CStoredProc v_sp = new CStoredProc("pr_V_GD_TRANG_THAI_LAO_DONG_Nhan_vien_sap_quay_lai");
        v_sp.fillDataSetByCommand(this, m_ds);
    }
    public void Count_Nhan_vien(ref decimal op_dc_hien_tai)
    {
        CStoredProc v_sp = new CStoredProc("pr_V_GD_TRANG_THAI_LD_Count");
        SqlParameter v_pa1 = v_sp.addDecimalOutputParam("@SO_LUONG_HIEN_TAI", op_dc_hien_tai);
        v_sp.ExecuteCommand(this);
        op_dc_hien_tai = CIPConvert.ToDecimal(v_pa1.Value);
        //op_dc_hien_tai = CIPConvert.ToDecimal(cmd.Parameters["@SO_LUONG_HIEN_TAI"].Value.ToString());
        //op_dc_tong_so = CIPConvert.ToDecimal(cmd.Parameters["@TONG_SO"].Value.ToString());

    }
}
}

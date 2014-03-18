///************************************************
/// Generated by: THAIPH
/// Date: 25/02/2014 10:06:52
/// Goal: Create User Service Class for GD_CHI_TIET_DU_AN
///************************************************
/// <summary>
/// Create User Service Class for GD_CHI_TIET_DU_AN
/// </summary>

using System;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;



namespace BKI_HRM.US{

public class US_GD_CHI_TIET_DU_AN : US_Object
{
	private const string c_TableName = "GD_CHI_TIET_DU_AN";
    #region "Public Properties"
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

    #endregion
    #region "Init Functions"
    public US_GD_CHI_TIET_DU_AN()
    {
        pm_objDS = new DS_GD_CHI_TIET_DU_AN();
        pm_strTableName = c_TableName;
        pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
    }

    public US_GD_CHI_TIET_DU_AN(DataRow i_objDR)
        : this()
    {
        this.DataRow2Me(i_objDR);
    }

    public US_GD_CHI_TIET_DU_AN(decimal i_dbID)
    {
        pm_objDS = new DS_GD_CHI_TIET_DU_AN();
        pm_strTableName = c_TableName;
        IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
        v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
        SqlCommand v_cmdSQL;
        v_cmdSQL = v_objMkCmd.getSelectCmd();
        this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
        pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
    }
    #endregion
#region public method
    public void DeleteChiTietDuAnById(DS_GD_CHI_TIET_DU_AN v_ds_gd_chi_tiet_da, decimal i_dc_id)
    {
        CStoredProc v_sp = new CStoredProc("pr_GD_CHI_TIET_DU_AN_Delete");
        v_sp.addDecimalInputParam("@ID", i_dc_id);
        v_sp.fillDataSetByCommand(this, v_ds_gd_chi_tiet_da);
    }

    public void FillDatasetByID(DS_GD_CHI_TIET_DU_AN v_ds, decimal i_dc_id)
    {
        CStoredProc v_sp = new CStoredProc("pr_GD_CHI_TIET_DU_AN_select_by_ID");
        v_sp.addDecimalInputParam("@ID", i_dc_id);
        v_sp.fillDataSetByCommand(this, v_ds);
    }

    public void FillDatasetByIDNS(DS_GD_CHI_TIET_DU_AN v_ds, decimal v_dc_id_ns)
    {
        CStoredProc v_sp = new CStoredProc("pr_GD_CHI_TIET_DU_AN_select_by_ID_NS");
        v_sp.addDecimalInputParam("@ID_NS", v_dc_id_ns);
        v_sp.fillDataSetByCommand(this, v_ds);
    }
    #endregion    
}
}
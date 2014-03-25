///************************************************
/// Generated by: AnhLT
/// Date: 16/03/2014 04:43:39
/// Goal: Create User Service Class for GD_QUA_TRINH_CONG_TAC
///************************************************
/// <summary>
/// Create User Service Class for GD_QUA_TRINH_CONG_TAC
/// </summary>

using System;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;



namespace BKI_HRM.US{

public class US_GD_QUA_TRINH_CONG_TAC : US_Object
{
	private const string c_TableName = "GD_QUA_TRINH_CONG_TAC";
    #region "Public Properties"
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

    public DateTime datTU_NGAY
    {
        get
        {
            return CNull.RowNVLDate(pm_objDR, "TU_NGAY", IPConstants.c_DefaultDate);
        }
        set
        {
            pm_objDR["TU_NGAY"] = value;
        }
    }

    public bool IsTU_NGAYNull()
    {
        return pm_objDR.IsNull("TU_NGAY");
    }

    public void SetTU_NGAYNull()
    {
        pm_objDR["TU_NGAY"] = System.Convert.DBNull;
    }

    public DateTime datDEN_NGAY
    {
        get
        {
            return CNull.RowNVLDate(pm_objDR, "DEN_NGAY", IPConstants.c_DefaultDate);
        }
        set
        {
            pm_objDR["DEN_NGAY"] = value;
        }
    }

    public bool IsDEN_NGAYNull()
    {
        return pm_objDR.IsNull("DEN_NGAY");
    }

    public void SetDEN_NGAYNull()
    {
        pm_objDR["DEN_NGAY"] = System.Convert.DBNull;
    }

    public string strLAM_GI
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "LAM_GI", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["LAM_GI"] = value;
        }
    }

    public bool IsLAM_GINull()
    {
        return pm_objDR.IsNull("LAM_GI");
    }

    public void SetLAM_GINull()
    {
        pm_objDR["LAM_GI"] = System.Convert.DBNull;
    }

    public string strO_DAU
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "O_DAU", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["O_DAU"] = value;
        }
    }

    public bool IsO_DAUNull()
    {
        return pm_objDR.IsNull("O_DAU");
    }

    public void SetO_DAUNull()
    {
        pm_objDR["O_DAU"] = System.Convert.DBNull;
    }

    public string strVAI_TRO
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "VAI_TRO", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["VAI_TRO"] = value;
        }
    }

    public bool IsVAI_TRONull()
    {
        return pm_objDR.IsNull("VAI_TRO");
    }

    public void SetVAI_TRONull()
    {
        pm_objDR["VAI_TRO"] = System.Convert.DBNull;
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

    #endregion
    #region "Init Functions"
    public US_GD_QUA_TRINH_CONG_TAC()
    {
        pm_objDS = new DS_GD_QUA_TRINH_CONG_TAC();
        pm_strTableName = c_TableName;
        pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
    }

    public US_GD_QUA_TRINH_CONG_TAC(DataRow i_objDR)
        : this()
    {
        this.DataRow2Me(i_objDR);
    }

    public US_GD_QUA_TRINH_CONG_TAC(decimal i_dbID)
    {
        pm_objDS = new DS_GD_QUA_TRINH_CONG_TAC();
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
    public void FillDatasetByProc(DS_GD_QUA_TRINH_CONG_TAC op_ds_v_qua_trinh_cong_tac, string ip_str_key_word, string ip_str_lua_chon)
    {
        CStoredProc v_stored_proc = new CStoredProc("pr_GD_QUA_TRINH_CONG_TAC");
        v_stored_proc.addNVarcharInputParam("@ip_str_search", ip_str_key_word);
        v_stored_proc.addNVarcharInputParam("@ip_str_lua_chon", ip_str_lua_chon);
        v_stored_proc.fillDataSetByCommand(this, op_ds_v_qua_trinh_cong_tac);
    }
    #endregion
}

}
///************************************************
/// Generated by: AnhHT
/// Date: 05/09/2014 05:27:35
/// Goal: Create User Service Class for HT_QUYEN_USER_WEB
///************************************************
/// <summary>
/// Create User Service Class for HT_QUYEN_USER_WEB
/// </summary>

using System;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;



namespace BKI_HRM.US{

public class US_HT_QUYEN_USER_WEB : US_Object
{
	private const string c_TableName = "HT_QUYEN_USER_WEB";
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

	public bool IsIDNull()	{
		return pm_objDR.IsNull("ID");
	}

	public void SetIDNull() {
		pm_objDR["ID"] = System.Convert.DBNull;
	}

	public decimal dcID_USER 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_USER", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_USER"] = value;
		}
	}

	public bool IsID_USERNull()	{
		return pm_objDR.IsNull("ID_USER");
	}

	public void SetID_USERNull() {
		pm_objDR["ID_USER"] = System.Convert.DBNull;
	}

	public decimal dcID_QUYEN 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_QUYEN", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_QUYEN"] = value;
		}
	}

	public bool IsID_QUYENNull()	{
		return pm_objDR.IsNull("ID_QUYEN");
	}

	public void SetID_QUYENNull() {
		pm_objDR["ID_QUYEN"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_HT_QUYEN_USER_WEB() 
	{
		pm_objDS = new DS_HT_QUYEN_USER_WEB();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_HT_QUYEN_USER_WEB(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_HT_QUYEN_USER_WEB(decimal i_dbID) 
	{
		pm_objDS = new DS_HT_QUYEN_USER_WEB();
		pm_strTableName = c_TableName;
		IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
		v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
		SqlCommand v_cmdSQL;
		v_cmdSQL = v_objMkCmd.getSelectCmd();
		this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
		pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
	}
#endregion
	}
}
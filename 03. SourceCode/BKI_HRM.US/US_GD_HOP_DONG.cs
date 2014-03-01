///************************************************
/// Generated by: AnhHT
/// Date: 12/01/2014 03:03:15
/// Goal: Create User Service Class for GD_HOP_DONG
///************************************************
/// <summary>
/// Create User Service Class for GD_HOP_DONG
/// </summary>

using System;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;



namespace BKI_HRM.US
{

    public class US_GD_HOP_DONG : US_Object
    {
        private const string c_TableName = "GD_HOP_DONG";
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

        public string strMA_HOP_DONG
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "MA_HOP_DONG", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["MA_HOP_DONG"] = value;
            }
        }

        public bool IsMA_HOP_DONGNull()
        {
            return pm_objDR.IsNull("MA_HOP_DONG");
        }

        public void SetMA_HOP_DONGNull()
        {
            pm_objDR["MA_HOP_DONG"] = System.Convert.DBNull;
        }

        public decimal dcID_LOAI_HOP_DONG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_HOP_DONG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_LOAI_HOP_DONG"] = value;
            }
        }

        public bool IsID_LOAI_HOP_DONGNull()
        {
            return pm_objDR.IsNull("ID_LOAI_HOP_DONG");
        }

        public void SetID_LOAI_HOP_DONGNull()
        {
            pm_objDR["ID_LOAI_HOP_DONG"] = System.Convert.DBNull;
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

        public DateTime datNGAY_HET_HAN
        {
            get
            {
                return CNull.RowNVLDate(pm_objDR, "NGAY_HET_HAN", IPConstants.c_DefaultDate);
            }
            set
            {
                pm_objDR["NGAY_HET_HAN"] = value;
            }
        }

        public bool IsNGAY_HET_HANNull()
        {
            return pm_objDR.IsNull("NGAY_HET_HAN");
        }

        public void SetNGAY_HET_HANNull()
        {
            pm_objDR["NGAY_HET_HAN"] = System.Convert.DBNull;
        }

        public string strTRANG_THAI_HOP_DONG
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TRANG_THAI_HOP_DONG", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TRANG_THAI_HOP_DONG"] = value;
            }
        }

        public bool IsTRANG_THAI_HOP_DONGNull()
        {
            return pm_objDR.IsNull("TRANG_THAI_HOP_DONG");
        }

        public void SetTRANG_THAI_HOP_DONGNull()
        {
            pm_objDR["TRANG_THAI_HOP_DONG"] = System.Convert.DBNull;
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

        #endregion
        #region "Init Functions"
        public US_GD_HOP_DONG()
        {
            pm_objDS = new DS_GD_HOP_DONG();
            pm_strTableName = c_TableName;
            pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
        }

        public US_GD_HOP_DONG(DataRow i_objDR)
            : this()
        {
            this.DataRow2Me(i_objDR);
        }

        public US_GD_HOP_DONG(decimal i_dbID)
        {
            pm_objDS = new DS_GD_HOP_DONG();
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

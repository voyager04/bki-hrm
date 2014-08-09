using System;
using System.Web.SessionState;
using System.Web;

using BKI_HRM.DS;
using BKI_HRM.US;
using BKI_HRM.US;
using BKI_HRM.DS.CDBNames;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;
using IP.Core.IPData.DBNames;

using System.Web.UI.WebControls;

namespace IP.Core.WinFormControls
{
    /// <summary>
    /// Summary description for ApplicationControls.
    /// </summary>
    public class WinFormControls
    {
        public WinFormControls()
        {
        }

        #region Public Interfaces
        public enum eTAT_CA
        {
            YES,
            NO
        }

        public static void get_cout_grid_row(Label ip_lbl_name, string ip_str_default_text, int ip_int_count_row)
        {
            ip_lbl_name.Text = ip_str_default_text + " (Có " + ip_int_count_row + " bản ghi)";
        }


        #endregion
    }
}

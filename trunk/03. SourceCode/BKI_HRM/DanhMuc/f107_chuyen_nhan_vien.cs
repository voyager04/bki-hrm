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
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using System.Diagnostics;
namespace BKI_HRM
{

    public partial class f107_chuyen_nhan_vien : Form
    {

        #region Public
        public f107_chuyen_nhan_vien()
        {
            InitializeComponent();
            set_define_event();
            format_controls();
        }
        #endregion

        #region Members

        US_DM_DON_VI m_us_dm_don_vi_1 = new US_DM_DON_VI();
        US_DM_DON_VI m_us_dm_don_vi_2 = new US_DM_DON_VI();

        #endregion

        #region Data Structs
        #endregion

        #region Private Methods

        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            KeyPreview = true;
        }


        #endregion

        // Event

        private void set_define_event(){
        }
    }
}

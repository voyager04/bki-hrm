using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BKI_HRM.DanhMuc {
    public partial class f102_DM_DON_VI_DE : Form {

        #region Public Interfaces
        public f102_DM_DON_VI_DE() {
            InitializeComponent();
        }


        public void display_for_insert() {
            //m_e_form_mode = DataEntryFormMode.InsertDataState;
            //load_data_2_combobox();
            this.ShowDialog();
        }

        //public void display_for_update(US_VIEW_KET_QUA_HOC_TAP ip_us_view_ket_qua_hoc_tap) {
        //    //m_us_v_ket_qua_hoc_tap = ip_us_view_ket_qua_hoc_tap;
        //    //load_data_2_combobox();
        //    //m_e_form_mode = DataEntryFormMode.UpdateDataState;
        //    this.ShowDialog();
        //}
        #endregion



        #region Data Structures
        #endregion

        #region Members
        #endregion

        #region Private Methods
        #endregion

        #region Events
        #endregion

    }
}

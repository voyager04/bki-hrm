using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

namespace BKI_HRM
{
    public partial class f202_v_gd_qua_trinh_lam_viec_de : Form
    {
        #region Public Interfaces
        public void display()
        {
            this.ShowDialog();
        }
        public f202_v_gd_qua_trinh_lam_viec_de()
        {
            InitializeComponent();
            format_controls();
        }
        public void display_for_insert(US_V_GD_QUA_TRINH_LAM_VIEC ip_us_qua_trinh_lam_viec)
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_us_v_qua_trinh_lam_viec = ip_us_qua_trinh_lam_viec;
            us_object_to_form();
            this.ShowDialog();
        }
        public void display_for_update(US_V_GD_QUA_TRINH_LAM_VIEC ip_us_qua_trinh_lam_viec)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_us_v_qua_trinh_lam_viec = ip_us_qua_trinh_lam_viec;
            us_object_to_form();
            this.ShowDialog();
        }
#endregion

#region Members
        DataEntryFormMode m_e_form_mode;
        US_V_GD_QUA_TRINH_LAM_VIEC m_us_v_qua_trinh_lam_viec = new US_V_GD_QUA_TRINH_LAM_VIEC();
        DS_V_GD_QUA_TRINH_LAM_VIEC m_ds_v_qua_trinh_lam_viec = new DS_V_GD_QUA_TRINH_LAM_VIEC();
        US_GD_CHI_TIET_CHUC_VU m_us_chi_tiet_chuc_vu = new US_GD_CHI_TIET_CHUC_VU();

        US_DM_QUYET_DINH m_us_quyet_dinh = new US_DM_QUYET_DINH();
        DS_DM_QUYET_DINH m_ds_quyet_dinh = new DS_DM_QUYET_DINH();
#endregion

#region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            this.KeyPreview = true;
            
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.LOAI_QUYET_DINH,
              WinFormControls.eTAT_CA.NO,
              m_cbo_loai_quyet_dinh);
        }
        private void us_object_to_form()
        {

        }
        private void form_to_us_object_chi_tiet_chuc_vu()
        {

        }
        private void form_to_us_object_quyet_dinh()
        {

        }
        private bool check_validate_data_is_ok()
        {
            return true;
        }
        private void save_data()
        {

        }
        private void xoa_trang()
        {

        }
        private void set_inital_form_load()
        {

        }
        private void set_define_event()
        {

        }
#endregion
        
#region Event Hanlders
        
#endregion
    }
}

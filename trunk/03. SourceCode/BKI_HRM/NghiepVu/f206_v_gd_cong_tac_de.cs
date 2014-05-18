using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPWordReport;

namespace BKI_HRM
{
    public partial class f206_v_gd_cong_tac_de : Form
    {

#region Public Interfaces
        public f206_v_gd_cong_tac_de()
        {
            InitializeComponent();
        }
        public void display_for_insert()
        {

        }
        public void display_for_update()
        {

        }
#endregion

#region Members
        US_V_GD_CONG_TAC m_us_v_gd_cong_tac = new US_V_GD_CONG_TAC();
        DS_V_GD_CONG_TAC m_ds_v_gd_cong_tac = new DS_V_GD_CONG_TAC();
        US_GD_CONG_TAC m_us_gd_cong_tac = new US_GD_CONG_TAC();
        DS_GD_CONG_TAC m_ds_gd_cong_tac = new DS_GD_CONG_TAC();
        US_DM_QUYET_DINH m_us_dm_quyet_dinh = new US_DM_QUYET_DINH();
        DS_DM_QUYET_DINH m_ds_dm_quyet_dinh = new DS_DM_QUYET_DINH();
#endregion

#region Private Methods
        private void generate_ma_quyet_dinh()
        {
            m_lbl_ma_qd.Text = string.Format("{0}/{1}/{2}", m_txt_ma_quyet_dinh.Text,
                                                                  m_dat_ngay_ky.Value.Year,
                                                                  m_cbo_ma_quyet_dinh.Text);
        }
        private bool check_data_is_ok()
        {
            return true;
        }
        private void form_2_us_object()
        {
            m_us_dm_quyet_dinh.strMA_QUYET_DINH = m_lbl_ma_qd.Text;
            m_us_dm_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text;

        }
        private void us_object_2_form()
        {

        }
        private void load_data_2_cbo_loai_qd()
        {
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.MA_QUYET_DINH
                , WinFormControls.eTAT_CA.NO
                , m_cbo_ma_quyet_dinh);
        }
        private void save_data()
        {

        }

        private void set_define_event()
        {

        }
#endregion

        

#region Events
        private void m_txt_ma_quyet_dinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbo_ma_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_dat_ngay_ky_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                generate_ma_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
#endregion
        
    }


}

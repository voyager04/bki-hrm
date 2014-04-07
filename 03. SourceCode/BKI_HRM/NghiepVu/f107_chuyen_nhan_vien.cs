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

        private void set_init_form_load(){
            load_data_2_cbo_don_vi_left_right();
        }

        private void load_data_2_cbo_don_vi_left_right()
        {
            var v_ds= new DS_V_DM_DON_VI();
            var v_us = new US_V_DM_DON_VI();
            v_us.FillDatasetByCapDonVi(v_ds, CAP_DON_VI.TRUNG_TAM);
            m_cbo_don_vi_left.DataSource = v_ds.V_DM_DON_VI;
            m_cbo_don_vi_left.DisplayMember = DM_DON_VI.TEN_DON_VI;
            m_cbo_don_vi_left.ValueMember = DM_DON_VI.ID;

            m_cbo_don_vi_right.DataSource = v_ds.V_DM_DON_VI;
            m_cbo_don_vi_right.DisplayMember =  DM_DON_VI.TEN_DON_VI;
            m_cbo_don_vi_right.ValueMember = DM_DON_VI.ID;
        }

        private void load_data_2_lbox_nhan_vien_left(string ip_dc_ma_don_vi)
        {
            US_V_DM_DU_LIEU_NHAN_VIEN v_us = new US_V_DM_DU_LIEU_NHAN_VIEN();
            DS_V_DM_DU_LIEU_NHAN_VIEN v_ds = new DS_V_DM_DU_LIEU_NHAN_VIEN();
            v_us.FillDatasetAll(v_ds,"","","","","","","","","","","","",ip_dc_ma_don_vi
                ,"","","","","","","","","","","","","","","","","","","","","","");
            int v_row_count = v_ds.Tables[0].Rows.Count;
            m_lbox_nhan_vien_left.Items.Clear();
            for (int i = 0; i < v_row_count; i++)
            {
                DataRow v_dr = v_ds.Tables[0].Rows[i];
                m_lbox_nhan_vien_left.Items.Add(v_dr[HT_PHAN_QUYEN_HE_THONG.MA_PHAN_QUYEN]);
            }
        }


        #endregion

        // Event

        private void set_define_event()
        {
            Load += f107_chuyen_nhan_vien_Load;
        }

        private void f107_chuyen_nhan_vien_Load(object sender, EventArgs e)
        {
            try{
                set_init_form_load();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

    }
}

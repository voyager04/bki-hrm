using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IP.Core.IPCommon;
//using BKI_HRM.US;
//using BKI_HRM.DS;
using IP.Core.IPData;
using IP.Core.IPUserService;
using BKI_HRM.DS.CDBNames;

namespace BKI_HRM.NghiepVu
{
    public partial class f500_dm_du_an_detail : Form
    {
        #region publicInterface
        public f500_dm_du_an_detail()
        {
            InitializeComponent();
        }
        #endregion

        #region Member
        DataEntryFormMode m_e_form_mode;
        BKI_HRM.US.US_DM_DU_AN m_us = new BKI_HRM.US.US_DM_DU_AN();
        enum cm_dm_tu_dien { 
            TRANG_THAI = 10,
            LOAI_DU_AN = 9,
            CO_CHE =8
        }
        #endregion

        #region privateMethod
        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.ShowDialog();
        }

        public void load_data_2_cbo_trang_thai()
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_td = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_td = new US_CM_DM_TU_DIEN();
            v_us_cm_dm_td.FillDatasetByIdLoaiTuDien(v_ds_cm_dm_td, (int)cm_dm_tu_dien.TRANG_THAI);
            m_cbo_trang_thai.DataSource = v_ds_cm_dm_td.Tables[0];
            m_cbo_trang_thai.DisplayMember = CM_DM_TU_DIEN.TEN_NGAN;
            m_cbo_trang_thai.ValueMember = CM_DM_TU_DIEN.ID;
        }

        public void load_data_2_cbo_co_che() 
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_td = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_td = new US_CM_DM_TU_DIEN();
            v_us_cm_dm_td.FillDatasetByIdLoaiTuDien(v_ds_cm_dm_td, (int)cm_dm_tu_dien.CO_CHE);
            m_cbo_co_che.DataSource = v_ds_cm_dm_td.Tables[0];
            m_cbo_co_che.DisplayMember = CM_DM_TU_DIEN.TEN_NGAN;
            m_cbo_co_che.ValueMember = CM_DM_TU_DIEN.ID;
        }

        public void load_data_2_cbo_loai_du_an()
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_td = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_td = new US_CM_DM_TU_DIEN();
            v_us_cm_dm_td.FillDatasetByIdLoaiTuDien(v_ds_cm_dm_td, (int)cm_dm_tu_dien.LOAI_DU_AN);
            m_cbo_loai_du_an.DataSource = v_ds_cm_dm_td.Tables[0];
            m_cbo_loai_du_an.DisplayMember = CM_DM_TU_DIEN.TEN_NGAN;
            m_cbo_loai_du_an.ValueMember = CM_DM_TU_DIEN.ID;
        }
        public void load_data_2_txt_ma_quyet_dinh_custom_source()
        {
            BKI_HRM.DS.DS_DM_QUYET_DINH v_ds_quyet_dinh = new BKI_HRM.DS.DS_DM_QUYET_DINH();
            BKI_HRM.US.US_DM_QUYET_DINH v_us_quyet_dinh = new BKI_HRM.US.US_DM_QUYET_DINH();
            v_us_quyet_dinh.FillDataset(v_ds_quyet_dinh);
            int count = v_ds_quyet_dinh.Tables["DM_QUYET_DINH"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataRow dr = v_ds_quyet_dinh.Tables["DM_QUYET_DINH"].Rows[i];
                m_txt_ma_quyet_dinh.AutoCompleteCustomSource.Add(dr[1].ToString());
            }
        }
        public void form_2_us_object()
        {            
            m_us.dcID_CO_CHE = CIPConvert.ToDecimal(m_cbo_co_che.SelectedValue);
            m_us.dcID_LOAI_DU_AN = CIPConvert.ToDecimal(m_cbo_loai_du_an.SelectedValue);
            m_us.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue);

            BKI_HRM.US.US_DM_QUYET_DINH v_us = new BKI_HRM.US.US_DM_QUYET_DINH();
            BKI_HRM.DS.DS_DM_QUYET_DINH v_ds = new BKI_HRM.DS.DS_DM_QUYET_DINH();

            v_us.FillDatasetByMaQuyetDinh(v_ds,m_txt_ma_quyet_dinh.Text);

            DataRow dr = v_ds.Tables[0].Rows[0];

            m_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(dr[0].ToString());

            m_us.strMA_DU_AN = m_txt_ma_du_an.Text;
            m_us.strNOI_DUNG = m_txt_noi_dung.Text;
            m_us.strTEN_DU_AN = m_txt_ten_du_an.Text;

            m_us.datNGAY_BAT_DAU = m_dat_ngay_bd.Value;
            m_us.datNGAY_KET_THUC = m_dat_ngay_kt.Value;
        }

        private void save_data()
        {
            if (check_data_is_ok() == false)
            {
                return;
            }
            form_2_us_object();
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    m_us.Insert();
                    break;
                case DataEntryFormMode.UpdateDataState:
                    m_us.Update();
                    break;
            }
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhật");
            this.Close();
        }

        private bool check_data_is_ok()
        {
            return true;
        }
        #endregion

        #region eventHandle
        private void m_cmd_save_Click(object sender, EventArgs e)
        {
            try
            {
                save_data();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                m_txt_ma_du_an.Text = "";
                m_txt_ma_quyet_dinh.Text = "";
                m_txt_noi_dung.Text = "";
                m_txt_ten_du_an.Text = "";
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {

        }

        private void f500_dm_du_an_detail_Load(object sender, EventArgs e)
        {
            load_data_2_txt_ma_quyet_dinh_custom_source();
            load_data_2_cbo_co_che();
            load_data_2_cbo_loai_du_an();
            load_data_2_cbo_trang_thai();
        }
        #endregion        
    }
}

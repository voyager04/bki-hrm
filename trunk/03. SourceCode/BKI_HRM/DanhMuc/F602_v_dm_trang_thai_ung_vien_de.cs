using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using System.IO;


namespace BKI_HRM.DanhMuc
{
    public partial class F602_v_dm_trang_thai_ung_vien_de : Form
    {
        #region Public Interfaces
        public F602_v_dm_trang_thai_ung_vien_de()
        {
            InitializeComponent();
              format_control();

        }
        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;

            this.ShowDialog();
        }
        public void display_for_update(US_V_DM_TRANG_THAI_UNG_VIEN ip_m_us_v_dm_trang_thai_ung_vien)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;

            us_object_2_form(ip_m_us_v_dm_trang_thai_ung_vien);
            this.ShowDialog();
        }
        #endregion
        #region Data Structures
        #endregion
        #region Members
        private DataEntryFormMode m_e_form_mode;
        private US_V_DM_TRANG_THAI_UNG_VIEN m_v_us = new US_V_DM_TRANG_THAI_UNG_VIEN();
        private DS_V_DM_TRANG_THAI_UNG_VIEN m_v_ds = new DS_V_DM_TRANG_THAI_UNG_VIEN();
        private US_DM_TRANG_THAI_UNG_VIEN m_us = new US_DM_TRANG_THAI_UNG_VIEN();
        private DS_DM_TRANG_THAI_UNG_VIEN m_ds=new DS_DM_TRANG_THAI_UNG_VIEN();
        //private string m_str_destination = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        //private string m_str_path = "";
        //private string m_str_file_name = "";
        //private string m_str_origination = "";
        //private string m_str_old_path = "";
        #endregion
        #region Private Methods
        
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
            BaseMessages.MsgBox_Infor("Cập nhật dữ liệu thành công!");
            this.Close();
        }
        

        private void us_object_2_form(US_V_DM_TRANG_THAI_UNG_VIEN ip_us_v_dm_trang_thai_ung_vien)
        {
            m_us.dcID = ip_us_v_dm_trang_thai_ung_vien.dcID;
            m_txt_dau_hieu.Text = ip_us_v_dm_trang_thai_ung_vien.strDAU_HIEU;
            m_txt_dinh_nghia.Text = ip_us_v_dm_trang_thai_ung_vien.strDINH_NGHIA;
            m_txt_ma_trang_thai.Text = ip_us_v_dm_trang_thai_ung_vien.strMA_TRANG_THAI;
            m_txt_viec_can_lam.Text = ip_us_v_dm_trang_thai_ung_vien.strVIEC_CAN_LAM;
            //m_cbo_ma_trang_thai_cap_tren.SelectedValue = ip_us_v_dm_trang_thai_ung_vien.dcID_TRANG_THAI_CAP_TREN;
            if (ip_us_v_dm_trang_thai_ung_vien.dcID_TRANG_THAI_CAP_TREN == 0)
            {
                m_cbo_ma_trang_thai_cap_tren.SelectedIndex = 0;
            }
            else
            {
                m_cbo_ma_trang_thai_cap_tren.SelectedValue = ip_us_v_dm_trang_thai_ung_vien.dcID_TRANG_THAI_CAP_TREN;
            }
        }

        private void format_control()
        {
            CControlFormat.setFormStyle(this);

            set_define_events();
            load_data_2_cbo_ma_trang_thai_cap_tren();

        }
        private void load_data_2_cbo_ma_trang_thai_cap_tren()
        {

            var v_ds = new DS_V_DM_TRANG_THAI_UNG_VIEN();
            var v_us = new US_V_DM_TRANG_THAI_UNG_VIEN();
            
            v_us.FillDatasetByID_TRANG_THAI_PARENT(v_ds);
            //v_us.FillDatasetSearch(v_ds, "");
            m_cbo_ma_trang_thai_cap_tren.DisplayMember = V_DM_TRANG_THAI_UNG_VIEN.MA_TRANG_THAI_CAP_TREN;
            m_cbo_ma_trang_thai_cap_tren.ValueMember = V_DM_TRANG_THAI_UNG_VIEN.ID_TRANG_THAI_CAP_TREN;
            m_cbo_ma_trang_thai_cap_tren.DataSource = v_ds.V_DM_TRANG_THAI_UNG_VIEN;
            var v_row = v_ds.V_DM_TRANG_THAI_UNG_VIEN.NewRow();
            v_row[V_DM_TRANG_THAI_UNG_VIEN.ID] = -1;
            v_row[V_DM_TRANG_THAI_UNG_VIEN.MA_TRANG_THAI] = "NULL";
            v_row[V_DM_TRANG_THAI_UNG_VIEN.ID_TRANG_THAI_CAP_TREN] = -1;
            v_row[V_DM_TRANG_THAI_UNG_VIEN.DINH_NGHIA] = "";
            v_row[V_DM_TRANG_THAI_UNG_VIEN.DAU_HIEU] = "";
            v_row[V_DM_TRANG_THAI_UNG_VIEN.VIEC_CAN_LAM] = "";
            v_ds.V_DM_TRANG_THAI_UNG_VIEN.Rows.InsertAt(v_row, 0);

            
        }
        private bool check_data_is_ok()
        {
            if (m_txt_ma_trang_thai.Text == "")
            {
                BaseMessages.MsgBox_Infor("Bạn chưa nhập mã trạng thái");
                return false;
            }
            return true;
        }
        private void form_2_us_object()
        {
            //m_us.strMA_TRANG_THAI_CAP_TREN = m_txt_ma_trang_thai_cap_tren.Text.Trim();
            m_us.strMA_TRANG_THAI = m_txt_ma_trang_thai.Text.Trim();
            m_us.strDINH_NGHIA = m_txt_dinh_nghia.Text.Trim();
            m_us.strDAU_HIEU = m_txt_dau_hieu.Text.Trim();
            m_us.strVIEC_CAN_LAM = m_txt_viec_can_lam.Text.Trim();
            m_us.dcID_TRANG_THAI_PARENT = CIPConvert.ToDecimal(m_cbo_ma_trang_thai_cap_tren.SelectedValue.ToString());
        }

        private void refresh()
        {
            m_txt_viec_can_lam.Text = "";
            m_txt_ma_trang_thai.Text = "";
            m_txt_dinh_nghia.Text = "";
            m_txt_dau_hieu.Text = "";
            m_cbo_ma_trang_thai_cap_tren.SelectedIndex = 0;
        }

        #endregion



        
        #region Events
        protected void m_cmd_save_Click(object sender, EventArgs e)
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
        protected void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                refresh();
            }
            catch (Exception v_e)
            {
                
                CSystemLog_301.ExceptionHandle(v_e);
            } 
        }
        private void set_define_events()
        {
            this.m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            this.m_cmd_refresh.Click += new EventHandler(m_cmd_refresh_Click);
            this.m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
        }
        
        
        protected void m_cmd_exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion



        internal void display(US_V_DM_TRANG_THAI_UNG_VIEN m_us)
        {
            throw new NotImplementedException();
        }

       








    }
}

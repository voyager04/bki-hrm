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
using System.Net.Mail;
using System.Text.RegularExpressions;
namespace BKI_HRM
{
    public partial class f203_v_gd_trang_thai_lao_dong_de : Form
    {
        //public f203_v_gd_trang_thai_lao_dong_de()
        //{
        //    InitializeComponent();
        //    WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_LAO_DONG,
        //      WinFormControls.eTAT_CA.NO,
        //      m_cbo_trang_thai_moi);
        //}
        #region Public Interface
        public void display()
        {
            this.ShowDialog();
        }
        public f203_v_gd_trang_thai_lao_dong_de()
        {
            InitializeComponent();
            format_controls();
        }
        public void display_for_insert(){
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            
            this.ShowDialog();
            
        }
        public void display_for_update(US_V_GD_TRANG_THAI_LAO_DONG ip_us_trang_thai_ld)
        {
            m_us_trang_thai_ld = ip_us_trang_thai_ld;
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_to_form();
            this.ShowDialog();
        }
        public void display_for_view(US_DM_NHAN_SU ip_us_dm_nhan_su)
        {
            m_cmd_refresh.Visible = false;
            m_cmd_save.Visible = false;
            this.ShowDialog();
        }
    #endregion

    #region Members
        DataEntryFormMode m_e_form_mode;
        US_V_GD_TRANG_THAI_LAO_DONG m_us_trang_thai_ld = new US_V_GD_TRANG_THAI_LAO_DONG();
        
    #endregion

    #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            this.KeyPreview = true;
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.TRANG_THAI_LAO_DONG,
              WinFormControls.eTAT_CA.NO,
              m_cbo_trang_thai_moi);
        }
        
        private void us_object_to_form(){
           
        }
        private void form_to_us_object(){
            
        }
        private bool check_trung_ma_nv(string ip_str_ma_nv)
        {
           
            DS_DM_NHAN_SU v_ds = new DS_DM_NHAN_SU();
            decimal count_ma_nv;
          //  m_us_dm_nhan_su.FillDataset_search_by_ma_nv(v_ds, ip_str_ma_nv);
            count_ma_nv = v_ds.DM_NHAN_SU.Count;
            if (count_ma_nv > 0)
                return true;
            return false;
        }
        private bool check_validate_data_is_ok(){
            
            
            if (!CValidateTextBox.IsValid(m_txt_ho_dem, DataType.StringType, allowNull.NO, true) || CIPConvert.is_valid_number(m_txt_ho_dem)){
                BaseMessages.MsgBox_Warning(202);
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_ten, DataType.StringType, allowNull.NO, true) || CIPConvert.is_valid_number(m_txt_ten))
            {
                BaseMessages.MsgBox_Warning(203);
                return false;
            }
            return true;
        }

        private void save_data(){
            
            switch (m_e_form_mode)
            {
                    
                case DataEntryFormMode.UpdateDataState:
                    if (check_validate_data_is_ok() == false)
                        return;
                    else
                    {
                        form_to_us_object();
                        //m_us_dm_nhan_su.Update();
                    }
                        
                    break;
                case DataEntryFormMode.InsertDataState:
                    //if (check_trung_ma_nv(m_txt_ma_nhan_vien.Text))
                    //{
                    //    BaseMessages.MsgBox_Warning(212);
                        
                    //    return;
                    //}
                    //else
                    //{
                    //    m_txt_ma_nhan_vien.BackColor = Color.White;
                    //    if (check_validate_data_is_ok() == false)
                    //        return;
                    //    else
                    //    {
                    //        form_to_us_object();
                    //        //m_us_dm_nhan_su.Insert();
                    //    }
                        
                    //}
                    
                    break;
                default:
                    break;
            }
            BaseMessages.MsgBox_Infor("Dữ liệu đã được cập nhât!");
            this.Close();
        }
        private void xoa_trang(){
            
            m_txt_ho_dem.Text = "";
            m_txt_ten.Text = "";
            
        }
        private void set_inital_form_load()
        {
            
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.UpdateDataState:
                    us_object_to_form();
                    break;
                case DataEntryFormMode.ViewDataState:
                    break;
                case DataEntryFormMode.InsertDataState:
                    break;
                default:
                    break;
            }
            
        }
        
        private void set_define_event(){
            this.Load += new EventHandler(f203_v_gd_trang_thai_lao_dong_de_Load);
            m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            m_cmd_refresh.Click += new EventHandler(m_cmd_refresh_Click);
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
        }
        
    #endregion

    #region Event Hanlders
        private void f203_v_gd_trang_thai_lao_dong_de_Load(object sendrer, EventArgs e){
            try
            {
                
                set_inital_form_load();
                
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_save_Click(object sender, EventArgs e){
            try
            {
            	save_data();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle( v_e);
            }
        }
        private void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                xoa_trang();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle( v_e);
            }
        }
        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle( v_e);
            }
        }
      

       

        private void m_txt_ma_nhan_vien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                )
            {
                e.Handled = true;
            }


        }

       
       
       
    #endregion

        
        
    }

}

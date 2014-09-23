using BKI_HRM.US;
using IP.Core.IPCommon;
using System;
using System.Windows.Forms;

namespace BKI_HRM.DanhMuc
{
    public partial class f300_DM_KY_DE : Form
    {
        #region Members
        DataEntryFormMode m_e_form_mode;

        US_DM_KY m_us_dm_ky;
        #endregion

        #region Public Interfaces
        public f300_DM_KY_DE()
        {
            InitializeComponent();
            init_define_events();
        }

        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_us_dm_ky = new US_DM_KY();
            this.ShowDialog();
        }

        public void display_for_update(US_DM_KY m_us)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_us_dm_ky = m_us;
            us_obj_2_form();
            this.ShowDialog();
        }
        #endregion

        #region Private Methods
        private void us_obj_2_form()
        {
            m_txt_ma_ky.Text = m_us_dm_ky.strMA_KY;
            m_dat_ngay_bat_dau.Value = m_us_dm_ky.datNGAY_BAT_DAU_KY;
            m_dat_ngay_ket_thuc.Value = m_us_dm_ky.datNGAY_KET_THUC_KY;
        }

        private void form_2_us_obj()
        {
            m_us_dm_ky.strMA_KY = m_txt_ma_ky.Text;
            m_us_dm_ky.datNGAY_BAT_DAU_KY = m_dat_ngay_bat_dau.Value;
            m_us_dm_ky.datNGAY_KET_THUC_KY = m_dat_ngay_ket_thuc.Value;
        }

        private void init_define_events()
        {
            m_cmd_exit.Click += m_cmd_exit_Click;
            m_cmd_save.Click += m_cmd_save_Click;
            m_cmd_reset.Click += m_cmd_reset_Click;

            this.KeyUp += f300_DM_KY_DE_KeyUp;
        }

        private void reset_form()
        {
            m_txt_ma_ky.Text = String.Empty;
            m_dat_ngay_bat_dau.Value = DateTime.Today;
            m_dat_ngay_ket_thuc.Value = DateTime.Today;

            m_txt_ma_ky.Focus();
        }

        private void save_data()
        {
            try
            {
                form_2_us_obj();

                switch (m_e_form_mode)
                {
                    case DataEntryFormMode.InsertDataState:
                        m_us_dm_ky.Insert();
                        MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset_form();
                        break;
                    case DataEntryFormMode.SelectDataState:
                        break;
                    case DataEntryFormMode.UpdateDataState:
                        m_us_dm_ky.Update();
                        this.Close();
                        break;
                    case DataEntryFormMode.ViewDataState:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion

        #region Events
        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmd_save_Click(object sender, EventArgs e)
        {
            save_data();
        }

        private void m_cmd_reset_Click(object sender, EventArgs e)
        {
            try
            {
                reset_form();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void f300_DM_KY_DE_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Escape)
                //    this.Close();
            }
            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion
    }
}

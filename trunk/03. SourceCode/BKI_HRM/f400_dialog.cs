using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using BKI_HRM;
using BKI_HRM.DS;
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPExcelReport;
using IP.Core.IPSystemAdmin;
using BKI_HRM.HeThong;
using System.Diagnostics;

namespace BKI_HRM
{
    public partial class f400_dialog : Form
    {
        public f400_dialog()
        {
            InitializeComponent();
            format_controls();
        }
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            // set_define_events();
            this.KeyPreview = true;
        }
        private void m_cmd_back_up_Click(object sender, EventArgs e)
        {
            try
            {
                CDataBaseProccessing.BackupDataBase();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_restore_Click(object sender, EventArgs e)
        {
            try
            {
                CDataBaseProccessing.RestoreDataBase();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

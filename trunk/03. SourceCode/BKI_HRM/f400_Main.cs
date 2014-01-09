using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BKI_HRM
{
    public partial class f400_Main : Form
    {
        public f400_Main()
        {
            InitializeComponent();
        }

        private void quáTrìnhLàmViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f200_V_GD_QUA_TRINH_LAM_VIEC frm = new f200_V_GD_QUA_TRINH_LAM_VIEC();
            frm.Show();
        }
    }
}

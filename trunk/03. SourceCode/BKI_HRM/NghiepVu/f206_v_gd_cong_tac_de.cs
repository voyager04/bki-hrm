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
using System.Diagnostics;
using IP.Core.IPSystemAdmin;
using System.Collections;
using C1.Win.C1FlexGrid;
using System.Timers;

namespace BKI_HRM
{
    public partial class f206_v_gd_cong_tac_de : Form
    {

        #region Public Interfaces
        public f206_v_gd_cong_tac_de()
        {
            InitializeComponent();
            format_controls();
        }
        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            this.Show();
        }
        public void display_for_update(US_V_GD_CONG_TAC ip_us)
        {
            m_us_v_gd_cong_tac = ip_us;
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form();
            this.Show();

        }
        #endregion
        #region Data Structs
        private enum e_col_Number
        {
            NGAY_DI = 3
           ,
            MO_TA_CONG_VIEC = 6
                ,
            DIA_DIEM = 5
                ,
            MA_NV = 1
                ,
            NGAY_VE = 4
                , HO_TEN = 2
        }
        #endregion
        #region Members
        ITransferDataRow m_obj_trans;
        US_V_GD_CONG_TAC m_us_v_gd_cong_tac = new US_V_GD_CONG_TAC();
        DS_V_GD_CONG_TAC m_ds_v_gd_cong_tac = new DS_V_GD_CONG_TAC();
        US_GD_CONG_TAC m_us_gd_cong_tac = new US_GD_CONG_TAC();
        DS_GD_CONG_TAC m_ds_gd_cong_tac = new DS_GD_CONG_TAC();
        US_DM_QUYET_DINH m_us_dm_quyet_dinh = new US_DM_QUYET_DINH();
        DS_DM_QUYET_DINH m_ds_dm_quyet_dinh = new DS_DM_QUYET_DINH();
        US_V_DM_NHAN_SU m_us_v_dm_nhan_su = new US_V_DM_NHAN_SU();
        DS_V_DM_NHAN_SU m_ds_v_dm_nhan_su = new DS_V_DM_NHAN_SU();
        DataEntryFormMode m_e_form_mode = new DataEntryFormMode();
        bool m_b_check_quyet_dinh_save;
        bool m_b_check_quyet_dinh_null = false;
        ArrayList m_ar_txt_ma_nv = new ArrayList();
         ArrayList m_ar_txt_ho_ten = new ArrayList();
        #endregion

        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            this.KeyPreview = true;
            load_cbo_ma_quyet_dinh();
        }
        private void set_inital_form_load()
        {

            switch (m_e_form_mode)
            {
                case DataEntryFormMode.UpdateDataState:
                    //us_object_2_form;
                    break;
                case DataEntryFormMode.ViewDataState:
                    break;
                case DataEntryFormMode.InsertDataState:
                    break;
                default:
                    break;
            }
            m_us_v_dm_nhan_su.FillDataset(m_ds_v_dm_nhan_su);
           
            add_textbox_2_grid();
        }
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
        private void form_2_us_object_quyet_dinh()
        {
            m_us_dm_quyet_dinh.strMA_QUYET_DINH = m_lbl_ma_qd.Text;
            m_us_dm_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_dm_quyet_dinh.strLINK = m_ofd_openfile.FileName;
            m_us_dm_quyet_dinh.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_dm_quyet_dinh.SetNGAY_HET_HIEU_LUCNull();
            m_us_dm_quyet_dinh.datNGAY_CO_HIEU_LUC = m_us_dm_quyet_dinh.datNGAY_KY;
            m_us_dm_quyet_dinh.dcID_LOAI_QD = CIPConvert.ToDecimal(TU_DIEN.QD_CONG_TAC);
        }
        private void form_2_us_object_gd_cong_tac(int ip_i_row)
        {
            m_us_gd_cong_tac.dcID_NHAN_SU = CIPConvert.ToDecimal(m_fg.Rows[ip_i_row][(int)e_col_Number.MA_NV]);
            m_us_gd_cong_tac.dcID_QUYET_DINH = m_us_dm_quyet_dinh.dcID;
            m_us_gd_cong_tac.datNGAY_DI = CIPConvert.ToDatetime(m_fg.Rows[ip_i_row][(int)e_col_Number.NGAY_DI]);
            m_us_gd_cong_tac.datNGAY_VE = CIPConvert.ToDatetime(m_fg.Rows[ip_i_row][(int)e_col_Number.NGAY_VE]);
            if (m_fg.Rows[ip_i_row][(int)e_col_Number.DIA_DIEM] != null)
            {
                m_us_gd_cong_tac.strDIA_DIEM = CIPConvert.ToStr(m_fg.Rows[ip_i_row][(int)e_col_Number.DIA_DIEM]);
            }
            if (m_fg.Rows[ip_i_row][(int)e_col_Number.MO_TA_CONG_VIEC] != null)
            {
                m_us_gd_cong_tac.strMO_TA_CONG_VIEC = CIPConvert.ToStr(m_fg.Rows[ip_i_row][(int)e_col_Number.MO_TA_CONG_VIEC]);
            }
            
        }
        private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
        {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_GD_CONG_TAC.NGAY_DI, e_col_Number.NGAY_DI);
            v_htb.Add(V_GD_CONG_TAC.MO_TA_CONG_VIEC, e_col_Number.MO_TA_CONG_VIEC);
            v_htb.Add(V_GD_CONG_TAC.DIA_DIEM, e_col_Number.DIA_DIEM);
            v_htb.Add(V_GD_CONG_TAC.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_GD_CONG_TAC.NGAY_VE, e_col_Number.NGAY_VE);

            v_htb.Add(V_GD_CONG_TAC.HO_TEN, e_col_Number.HO_TEN);
           
            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds_v_gd_cong_tac.V_GD_CONG_TAC.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid()
        {
            m_ds_v_gd_cong_tac = new DS_V_GD_CONG_TAC();

            m_us_v_gd_cong_tac.FillDatasetSearch(m_ds_v_gd_cong_tac, m_us_v_gd_cong_tac.strMA_QUYET_DINH, DateTime.Parse("1/1/1900"), DateTime.Today);
            m_fg.Redraw = false;
            m_obj_trans = get_trans_object(m_fg);
            CGridUtils.Dataset2C1Grid(m_ds_v_gd_cong_tac, m_fg, m_obj_trans);
            m_fg.Redraw = true;
        }
        private void us_object_2_form()
        {
            // m_b_check_quyet_dinh_save = false;
            m_grb_quyet_dinh.Enabled = true;

            string[] v_arstr = m_us_v_gd_cong_tac.strMA_QUYET_DINH.Trim().Split('/');
            m_ofd_openfile.FileName = m_us_v_gd_cong_tac.strLINK;
            m_txt_ma_quyet_dinh.Text = v_arstr[0];
            US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
            decimal v_dc_id = 0;
            v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
            m_cbo_ma_quyet_dinh.SelectedValue = v_dc_id;
            m_txt_loai_quyet_dinh.Text = "QĐ Đi công tác";
            m_dat_ngay_ky.Value = m_us_v_gd_cong_tac.datNGAY_KY;
            m_txt_noi_dung.Text = m_us_v_gd_cong_tac.strNOI_DUNG;

            load_data_2_grid();
        }

        private void save_data()
        {
            switch (m_e_form_mode)
            {
                case DataEntryFormMode.InsertDataState:
                    if (m_b_check_quyet_dinh_save)
                    {
                        m_us_dm_quyet_dinh.Insert();
                    }
                    for (int i = 1; i < m_fg.Rows.Count; i++)
                    {
                        if ((m_fg.Rows[i][(int)e_col_Number.MA_NV]) != null)
                        {
                            form_2_us_object_gd_cong_tac(i);
                            m_us_gd_cong_tac.Insert();
                        }

                    }
                    break;
                case DataEntryFormMode.UpdateDataState:
                    break;
                default:
                    break;
            }
            
           
        }
        private void chon_file()
        {
            m_ofd_openfile.Filter = "(*.pdf)|*.pdf|(*.doc)|*.doc|(*.docx)|*.docx|(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            m_ofd_openfile.Multiselect = false;
            m_ofd_openfile.Title = "Chọn tài liệu đính kèm";
            DialogResult result = m_ofd_openfile.ShowDialog();
        }
        private void mo_file()
        {
            Process.Start("explorer.exe", m_ofd_openfile.FileName);
        }
       
        private void them_quyet_dinh()
        {
            m_b_check_quyet_dinh_save = true;
            m_grb_quyet_dinh.Enabled = true;
            m_txt_ma_quyet_dinh.Focus();
        }
        private void chon_quyet_dinh()
        {
            m_b_check_quyet_dinh_save = false;
            m_grb_quyet_dinh.Enabled = true;
            f600_v_dm_quyet_dinh v_frm = new f600_v_dm_quyet_dinh();
            v_frm.select_data(ref m_us_dm_quyet_dinh);
            if (m_us_dm_quyet_dinh.dcID != -1)
            {
                string[] v_arstr = m_us_dm_quyet_dinh.strMA_QUYET_DINH.Trim().Split('/');
                m_ofd_openfile.FileName = m_us_dm_quyet_dinh.strLINK;
                m_txt_ma_quyet_dinh.Text = v_arstr[0];
                US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
                DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
                decimal v_dc_id = 0;
                v_us.FillDatasetByName(v_ds, v_arstr[v_arstr.Length - 1], ref v_dc_id);
                m_cbo_ma_quyet_dinh.SelectedValue = v_dc_id;
                m_txt_loai_quyet_dinh.Text = "QĐ Đi công tác";
                m_dat_ngay_ky.Value = m_us_dm_quyet_dinh.datNGAY_KY;
                m_txt_noi_dung.Text = m_us_dm_quyet_dinh.strNOI_DUNG;

            }
            else
            {
                m_b_check_quyet_dinh_null = true;
            }
        }
        private Hashtable get_mapping_col_ma_nv()
        {
            Hashtable v_hst = new Hashtable();
            foreach (DataRow v_dr in m_ds_v_dm_nhan_su.V_DM_NHAN_SU.Rows)
            {
                v_hst.Add(v_dr[V_DM_NHAN_SU.ID], v_dr[V_DM_NHAN_SU.MA_NV]);
            }
            return v_hst;
        }
        private Hashtable get_mapping_col_ho_ten()
        {
            Hashtable v_hst = new Hashtable();
            foreach (DataRow v_dr in m_ds_v_dm_nhan_su.V_DM_NHAN_SU.Rows)
            {
                v_hst.Add(v_dr[V_DM_NHAN_SU.ID], v_dr[V_DM_NHAN_SU.HO_TEN]);
            }
            return v_hst;
        }
        private void _flex_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            foreach (HostedControl hosted in m_ar_txt_ma_nv)
                hosted.UpdatePosition();
            foreach (HostedControl hosted in m_ar_txt_ho_ten)
                hosted.UpdatePosition();
           
        }
      
        private void load_edited_grid()
        {
            switch (m_fg.Col)
            {
                case (int)e_col_Number.MA_NV:
                    m_fg.Rows[m_fg.Row][(int)e_col_Number.HO_TEN] = m_fg.Rows[m_fg.Row][(int)e_col_Number.MA_NV];
                    break;
                case (int)e_col_Number.HO_TEN:
                    m_fg.Rows[m_fg.Row][(int)e_col_Number.MA_NV] = m_fg.Rows[m_fg.Row][(int)e_col_Number.HO_TEN];
                    break;
                default: 
                    break;
            }
        }
        private void load_cbo_ma_quyet_dinh()
        {
            WinFormControls.load_data_to_cbo_tu_dien(WinFormControls.eLOAI_TU_DIEN.MA_QUYET_DINH
                , WinFormControls.eTAT_CA.NO
                , m_cbo_ma_quyet_dinh);
        }
        private void us_object2grid(US_V_GD_CONG_TAC i_us
            , int i_grid_row)
        {
            DataRow v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            i_us.Me2DataRow(v_dr);
            m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
        }

        private void add_textbox_2_grid()
        {
            
            foreach (Row r in m_fg.Rows)
            {
                if (r.Index > 0 && r.Index < m_fg.Rows.Count - 1)
                {
                    TextBox v_txt_ma_nv = new TextBox();
                    TextBox v_txt_ho_ten = new TextBox();
                    v_txt_ma_nv.TabIndex = r.Index;
                    AutoCompleteStringCollection v_acsc_ma_nv = new AutoCompleteStringCollection();
                    foreach (DataRow dr in m_ds_v_dm_nhan_su.V_DM_NHAN_SU)
                    {
                        v_acsc_ma_nv.Add(dr[V_DM_NHAN_SU.MA_NV].ToString());
                    }
                    AutoCompleteStringCollection v_acsc_ho_ten = new AutoCompleteStringCollection();
                    foreach (DataRow dr in m_ds_v_dm_nhan_su.V_DM_NHAN_SU)
                    {
                        v_acsc_ho_ten.Add(dr[V_DM_NHAN_SU.HO_TEN].ToString());
                    }
                    v_txt_ma_nv.AutoCompleteMode = AutoCompleteMode.Suggest;
                    v_txt_ma_nv.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    v_txt_ma_nv.AutoCompleteCustomSource = v_acsc_ma_nv;
                    v_txt_ho_ten.AutoCompleteMode = AutoCompleteMode.Suggest;
                    v_txt_ho_ten.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    v_txt_ho_ten.AutoCompleteCustomSource = v_acsc_ho_ten;
                    m_ar_txt_ma_nv.Add(new HostedControl(m_fg, v_txt_ma_nv, r.Index, (int)e_col_Number.MA_NV));
                    m_ar_txt_ho_ten.Add(new HostedControl(m_fg, v_txt_ho_ten, r.Index, (int)e_col_Number.HO_TEN));

                    v_txt_ma_nv.Leave += (sender, e) => v_txt_Leave(sender, e, v_txt_ma_nv.TabIndex, v_txt_ma_nv.Text, ref v_txt_ma_nv, ref v_txt_ho_ten);
                    v_txt_ho_ten.Leave += (sender, e) => v_txt_Leave(sender, e, v_txt_ma_nv.TabIndex, v_txt_ho_ten.Text, ref v_txt_ma_nv, ref v_txt_ho_ten);
                }
            }


        }

        private void v_txt_Leave(object sender, EventArgs e, int ip_row, string ip_str, ref TextBox op_txt_ma_nv, ref TextBox op_txt_ho_ten)
        {
            try
            {
                US_V_DM_NHAN_SU v_us = new US_V_DM_NHAN_SU();
                DS_V_DM_NHAN_SU v_ds = new DS_V_DM_NHAN_SU();
                v_us.FillDataset_search(v_ds, ip_str);
                if (v_ds.V_DM_NHAN_SU.Count == 0)
                {
                    MessageBox.Show("Mã nhân viên hoặc Họ Tên bạn nhập vào không chính xác !");
                }
                if (v_ds.V_DM_NHAN_SU.Count == 1)
                {
                    v_us.DataRow2Me((DataRow)v_ds.V_DM_NHAN_SU.Rows[0]);
                    op_txt_ma_nv.Text = v_us.strMA_NV;
                    op_txt_ho_ten.Text = v_us.strHO_TEN;
                    m_fg.Rows[ip_row][(int)e_col_Number.MA_NV] = v_us.dcID;
                }
                if (v_ds.V_DM_NHAN_SU.Count > 1 && ip_str != "")
                {
                    AutoCompleteStringCollection v_acsc_ma_nv = new AutoCompleteStringCollection();
                    foreach (DataRow dr in v_ds.V_DM_NHAN_SU)
                    {
                        v_acsc_ma_nv.Add(dr[V_DM_NHAN_SU.MA_NV].ToString());
                    }
//                     op_txt_ma_nv.AutoCompleteMode = AutoCompleteMode.Suggest;
//                     op_txt_ma_nv.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                     op_txt_ma_nv.AutoCompleteCustomSource = v_acsc_ma_nv;
                    v_us.DataRow2Me((DataRow)v_ds.V_DM_NHAN_SU.Rows[0]);
                    op_txt_ma_nv.Text = v_us.strMA_NV;
                    m_fg.Rows[ip_row][(int)e_col_Number.MA_NV] = v_us.dcID;
                }
                if (ip_str == "")
                {
                    m_fg.Rows[ip_row][(int)e_col_Number.MA_NV] = "";
                }
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        

     
        private void set_define_event()
        {
            m_cmd_chon_file.Click += new EventHandler(m_cmd_chon_file_Click);
            m_cmd_xem_file.Click += new EventHandler(m_cmd_xem_file_Click);
            m_cmd_them_quyet_dinh.Click += new EventHandler(m_cmd_them_quyet_dinh_Click);
            m_cmd_chon_quyet_dinh.Click += new EventHandler(m_cmd_chon_quyet_dinh_Click);
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_cmd_save.Click += new EventHandler(m_cmd_save_Click);
            m_fg.Click += new EventHandler(m_fg_Click);
        //    m_fg.Paint += new PaintEventHandler(_flex_Paint);

        }
        #endregion

        #region Events
        private void f206_v_gd_cong_tac_de_Load(object sender, EventArgs e)
        {
            try
            {
                set_inital_form_load();
                set_define_event();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

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

        private void m_cmd_xem_file_Click(object sender, EventArgs e)
        {
            try
            {
                mo_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_chon_file_Click(object sender, EventArgs e)
        {
            try
            {
                chon_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_them_quyet_dinh_Click(object sender, EventArgs e)
        {
            try
            {
                them_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_chon_quyet_dinh_Click(object sender, EventArgs e)
        {
            try
            {
                chon_quyet_dinh();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
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
        private void m_cmd_exit_Click(object sender, EventArgs e)
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
        private void m_fg_Click(object sender, EventArgs e)
        {
            string v_str_mo_ta = "";
            if (m_fg.Col == (int)e_col_Number.MO_TA_CONG_VIEC)
            {
                F206_chi_tiet_cong_tac v_frm = new F206_chi_tiet_cong_tac();
                if (m_fg.Rows[m_fg.Row][m_fg.Col] == null)
                {
                    v_frm.display("", ref v_str_mo_ta);
                }
                else
                    v_frm.display(CIPConvert.ToStr(m_fg.Rows[m_fg.Row][m_fg.Col]), ref v_str_mo_ta);
                m_fg.Rows[m_fg.Row][m_fg.Col] = v_str_mo_ta;
            }

        }
      
        private void m_fg_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                load_edited_grid();

            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion

        private void m_fg_AfterAddRow(object sender, RowColEventArgs e)
        {
            try
            {
                TextBox v_txt_ma_nv = new TextBox();
                TextBox v_txt_ho_ten = new TextBox();
                AutoCompleteStringCollection v_acsc_ma_nv = new AutoCompleteStringCollection();
                foreach (DataRow dr in m_ds_v_dm_nhan_su.V_DM_NHAN_SU)
                {
                    v_acsc_ma_nv.Add(dr[V_DM_NHAN_SU.MA_NV].ToString());
                }
                AutoCompleteStringCollection v_acsc_ho_ten = new AutoCompleteStringCollection();
                foreach (DataRow dr in m_ds_v_dm_nhan_su.V_DM_NHAN_SU)
                {
                    v_acsc_ho_ten.Add(dr[V_DM_NHAN_SU.HO_TEN].ToString());
                }
                v_txt_ma_nv.AutoCompleteMode = AutoCompleteMode.Suggest;
                v_txt_ma_nv.AutoCompleteSource = AutoCompleteSource.CustomSource;
                v_txt_ma_nv.AutoCompleteCustomSource = v_acsc_ma_nv;
                v_txt_ho_ten.AutoCompleteMode = AutoCompleteMode.Suggest;
                v_txt_ho_ten.AutoCompleteSource = AutoCompleteSource.CustomSource;
                v_txt_ho_ten.AutoCompleteCustomSource = v_acsc_ho_ten;
                m_ar_txt_ma_nv.Add(new HostedControl(m_fg, v_txt_ma_nv, m_fg.Rows.Count - 2, (int)e_col_Number.MA_NV));
                m_ar_txt_ho_ten.Add(new HostedControl(m_fg, v_txt_ho_ten, m_fg.Rows.Count - 2, (int)e_col_Number.HO_TEN));
                v_txt_ma_nv.Leave += (sender2, e2) => v_txt_Leave(sender2, e2, v_txt_ma_nv.TabIndex, v_txt_ma_nv.Text, ref v_txt_ma_nv, ref v_txt_ho_ten);
                v_txt_ho_ten.Leave += (sender2, e2) => v_txt_Leave(sender2, e2, v_txt_ma_nv.TabIndex, v_txt_ho_ten.Text, ref v_txt_ma_nv, ref v_txt_ho_ten);
            }
            catch (Exception v_e)
            {
            	CSystemLog_301.ExceptionHandle(v_e);
            }
        }

    }


}

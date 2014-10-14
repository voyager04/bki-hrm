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
using IP.Core.IPExcelReport;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;


namespace BKI_HRM
{
    public partial class f405_bao_cao_chuc_vu_trang_thai : Form
    {
        public f405_bao_cao_chuc_vu_trang_thai()
        {
            InitializeComponent();
            format_controls();
        }
        public delegate void close_tab(bool ip_y_n);
        public close_tab close_tab_B;

        #region Members
        ITransferDataRow m_obj_trans;
        private bool load_invisible = true;
        DS_DM_CHUC_VU m_ds_1 = new DS_DM_CHUC_VU();
        US_DM_CHUC_VU m_us_1 = new US_DM_CHUC_VU();
        IP.Core.IPUserService.US_CM_DM_TU_DIEN v_us_dm_tu_dien = new IP.Core.IPUserService.US_CM_DM_TU_DIEN();
        IP.Core.IPData.DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new IP.Core.IPData.DS_CM_DM_TU_DIEN();
        DS_RPT_CHUC_VU_TRANG_THAI m_ds_rpt = new DS_RPT_CHUC_VU_TRANG_THAI();
        US_RPT_CHUC_VU_TRANG_THAI m_us_rpt = new US_RPT_CHUC_VU_TRANG_THAI();
        #endregion
        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            //set_define_events();
            this.KeyPreview = true;
            
        }
        private void set_initial_form_load()
        {
            //m_obj_trans = get_trans_object(m_fg);
            //m_txt_tim_kiem.Text = "";
            load_data_2_grid();
            //m_txt_tim_kiem.Text = "Nhập mã chức vụ, tên chức vụ";
        }
        private void load_data_2_grid()
        {
            m_us_1.FillDataset(m_ds_1);
            v_us_dm_tu_dien.FillDataset(v_ds_dm_tu_dien, "WHERE Id_loai_tu_dien = 5 AND ID <> 655");
            //1.tạo danh sách cột chức vụ
            m_fg.Cols.Count = m_ds_1.DM_CHUC_VU.Rows.Count + 2;
            m_fg.Cols[0].Width = 150;
            //m_fg.Cols[1].Caption = "Trạng thái/Chức vụ";
            m_fg.Cols[1].Caption = "Tổng";
            m_fg.Cols[1].UserData = 0;
            //m_fg.Cols[1].Style.ForeColor = Color.Black; 
            for (int i = 2; i < m_fg.Cols.Count; i++)
            {
                m_fg.Cols[i].Caption = m_ds_1.DM_CHUC_VU.Rows[i - 2][1].ToString();
                m_fg.Cols[i].UserData = m_ds_1.DM_CHUC_VU.Rows[i - 2][0];
            }
            //2. tạo danh sách dòng trạng thái
            m_fg.Rows.Count = v_ds_dm_tu_dien.CM_DM_TU_DIEN.Rows.Count + 1;
            //m_fg.Rows[1][0] = "Tổng";
            //m_fg.Rows[1].UserData = 0;
            for (int j = 1; j < m_fg.Rows.Count; j++)
            {
                m_fg.Rows[j][0] = v_ds_dm_tu_dien.CM_DM_TU_DIEN.Rows[j - 1][3].ToString();
                m_fg.Rows[j].UserData = v_ds_dm_tu_dien.CM_DM_TU_DIEN.Rows[j - 1][0];
            }
           //3.Đưa dữ liệu lên lưới
            m_ds_rpt = new DS_RPT_CHUC_VU_TRANG_THAI();
            m_us_rpt.FillDatasetByProc(m_ds_rpt,m_dat_thoidiem.Value,CAppContext_201.getCurrentIDPhapnhan());
            
            
                for (int v_i_cur_col = m_fg.Cols.Fixed; v_i_cur_col < m_fg.Cols.Count; v_i_cur_col++)
                {
                    //if((int.Parse(row[1].ToString())) == (int.Parse(m_fg.Cols[u].UserData.ToString())))
                        for (int v_i_cur_row = m_fg.Rows.Fixed; v_i_cur_row < m_fg.Rows.Count; v_i_cur_row++)
                        {
                            string v_str_id_chuc_vu = m_fg.Cols[v_i_cur_col].UserData.ToString();
                            string v_str_id_trang_thai = m_fg.Rows[v_i_cur_row].UserData.ToString();
                            
                            
                            DataRow[] v_arr_dr 
                                = m_ds_rpt.RPT_CHUC_VU_TRANG_THAI.Select(
                                RPT_CHUC_VU_TRANG_THAI.ID_CV + "="
                                + v_str_id_chuc_vu
                                + " AND " 
                                + RPT_CHUC_VU_TRANG_THAI.ID_TRANG_THAI+"="
                                + v_str_id_trang_thai);
                            if (v_arr_dr.Length == 0) continue;
                            m_fg[v_i_cur_row,v_i_cur_col]= v_arr_dr[0][RPT_CHUC_VU_TRANG_THAI.SO_LUONG];
                        }
                }
                for (int v = 1; v < m_fg.Rows.Count; v++)
                {
                    int sum = 0;
                    for (int t = 2; t < m_fg.Cols.Count; t++)
                        sum += Convert.ToInt32(m_fg.Rows[v][t]);
                    m_fg.Rows[v][1] = sum;
                }
                m_fg.SubtotalPosition = SubtotalPositionEnum.BelowData;
            m_fg.Tree.Column = 0;
            m_fg.Tree.Style = TreeStyleFlags.Simple;
            m_fg.Subtotal(AggregateEnum.Clear);
            for (int u = 1; u < m_fg.Cols.Count;u++ )
                m_fg.Subtotal(AggregateEnum.Sum, -1, -1, u, "Tổng");
                m_fg.AutoSizeCols();
            WinFormControls.load_data_to_CheckboxCombobox(m_fg, m_cbc_choose_columns, load_invisible);
            
        }

        private void hien_thi_cot_duoc_check(bool load_invisible)
        {
            int v_count = m_fg.Cols.Count;
            int v_count_visible = 0;
            for (int i = 0; i < v_count; i++)
            {
                if (m_fg.Cols[i].Visible)
                {
                    v_count_visible = v_count_visible + 1;
                }
            }
            if (load_invisible)
            {
                if (v_count >= 2 && (m_cbc_choose_columns.Items.Count == v_count - 1))
                {
                    for (int i = 0; i < v_count - 2; i++)
                    {
                        m_fg.Cols[i + 2].Visible = m_cbc_choose_columns.CheckBoxItems[i + 1].Checked;
                    }
                }
            }
            else
            {
                if (v_count_visible >= 2 && (m_cbc_choose_columns.Items.Count == v_count_visible - 1))
                {
                    for (int i = 0; i < v_count_visible - 2; i++)
                    {
                        m_fg.Cols[i + 2].Visible = m_cbc_choose_columns.CheckBoxItems[i + 1].Checked;
                    }
                }
            }

        }

        private void export_2_excel()
        {
            CExcelReport v_obj_excel_rpt = new CExcelReport("f405_bien_dong_nhan_su_chuc_vu_trang_thai.xlsx", 3, 1);
            v_obj_excel_rpt.AddFindAndReplaceItem("<thoi_diem>", m_dat_thoidiem.Value.Date);
            v_obj_excel_rpt.FindAndReplace(false);
            v_obj_excel_rpt.Export2ExcelWithoutFixedRows(m_fg,1 , m_fg.Cols.Count - 1, true);
        }
        #endregion

        private void f405_bao_cao_chuc_vu_trang_thai_Load(object sender, EventArgs e)
        {
            try{
            set_initial_form_load();
                }
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
        }

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            
			try{
                close_tab_B(true);

			}
			catch (Exception v_e){
				CSystemLog_301.ExceptionHandle(v_e);
			}
        }

        private void m_dat_thoidiem_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                load_data_2_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cbc_choose_columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hien_thi_cot_duoc_check(load_invisible);
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_xuat_excel_Click(object sender, EventArgs e)
        {
            try
            {
                export_2_excel();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    }
    
}

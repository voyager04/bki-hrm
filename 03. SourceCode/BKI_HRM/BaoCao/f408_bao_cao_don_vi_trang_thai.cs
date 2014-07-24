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
    public partial class f408_bao_cao_don_vi_trang_thai : Form
    {
        public f408_bao_cao_don_vi_trang_thai()
        {
            InitializeComponent();
            format_controls();
        }

        #region Members
        ITransferDataRow m_obj_trans;
        private bool load_invisible = true;
        DS_V_DM_DON_VI m_ds_1 = new DS_V_DM_DON_VI();
        US_V_DM_DON_VI m_us_1 = new US_V_DM_DON_VI();
        IP.Core.IPUserService.US_CM_DM_TU_DIEN v_us_dm_tu_dien = new IP.Core.IPUserService.US_CM_DM_TU_DIEN();
        IP.Core.IPData.DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new IP.Core.IPData.DS_CM_DM_TU_DIEN();
        DS_RPT_DON_VI_TRANG_THAI m_ds_rpt = new DS_RPT_DON_VI_TRANG_THAI();
        US_RPT_DON_VI_TRANG_THAI m_us_rpt = new US_RPT_DON_VI_TRANG_THAI();
        #endregion
        #region Private Methods
        private void format_controls()
        {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            m_fg.Tree.Column = 1;
            m_fg.Tree.Style = TreeStyleFlags.SimpleLeaf;
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
        private void insert_all_child_of_node(int i_grid_row, DS_V_DM_DON_VI ip_ds_don_vi)
        {
            //US_V_DM_DON_VI v_us_dm_don_vi = new US_V_DM_DON_VI();
            //grid2us_object(v_us_dm_don_vi, i_grid_row);

            DataRow[] v_arr_dr_child = ip_ds_don_vi.V_DM_DON_VI.Select(V_DM_DON_VI.ID_DON_VI_CAP_TREN + "=" + m_fg.Rows[i_grid_row].UserData.ToString());
            foreach (DataRow v_dr in v_arr_dr_child)
            {
                US_V_DM_DON_VI v_us_dm_don_vi_child = new US_V_DM_DON_VI();
                v_us_dm_don_vi_child.DataRow2Me(v_dr);
                int v_i_child_row = -1;
                insert_child_node(
                    v_us_dm_don_vi_child
                    , ip_ds_don_vi
                    , i_grid_row
                    , ref v_i_child_row);
                insert_all_child_of_node(v_i_child_row, ip_ds_don_vi);

            }

        }
        private void us_object_2_grid(US_V_DM_DON_VI i_us_object, DS_V_DM_DON_VI i_ds
            , int i_grid_row)
        {
            if (m_fg.Rows[i_grid_row].UserData == null)
            {
                m_fg.Rows[i_grid_row].UserData = i_ds.Tables[0].NewRow();
            }
            DataRow v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            i_us_object.Me2DataRow(v_dr);
            m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
        }
        private void insert_child_node(US_V_DM_DON_VI i_us_object
            , DS_V_DM_DON_VI i_ds
            , int i_parent_row
            , ref int i_row_result
            )
        {

            int v_i_new_grid_row;
            //Lay nut hien tai 
            Node v_current_node = m_fg.Rows[i_parent_row].Node;
            Node v_node_4_index;
            int v_i_level;
            //Neu them kieu nut la sibling cua nut hien tai            
            v_node_4_index = v_current_node;
            v_i_level = int.Parse(i_us_object.dcID_LEVEL.ToString());
            Node v_last_child = v_node_4_index.GetNode(NodeTypeEnum.LastChild);
            while (v_last_child != null)
            {
                v_node_4_index = v_last_child;
                v_last_child = v_node_4_index.GetNode(NodeTypeEnum.LastChild);
            }
            v_i_new_grid_row = v_node_4_index.Row.Index + 1;
            m_fg.Rows.Insert(v_i_new_grid_row);
            //us_object_2_grid(i_us_object, i_ds, v_i_new_grid_row);
            m_fg.Rows[v_i_new_grid_row][1] = i_us_object.strMA_DON_VI_CAP_TREN.ToString();
            m_fg.Rows[v_i_new_grid_row][2] = i_us_object.strMA_DON_VI.ToString();
            m_fg.Rows[v_i_new_grid_row].UserData = i_us_object.dcID;
            m_fg.Rows[v_i_new_grid_row].IsNode = true;
            m_fg.Rows[v_i_new_grid_row].Node.Level = v_i_level;

            switch (v_i_level)
            {
                case 0:
                    m_fg.Rows[v_i_new_grid_row].Style = m_fg.Styles[CellStyleEnum.Subtotal0];
                    break;
                case 1:
                    m_fg.Rows[v_i_new_grid_row].Style = m_fg.Styles[CellStyleEnum.Subtotal1];
                    break;
                case 2:
                    m_fg.Rows[v_i_new_grid_row].Style = m_fg.Styles[CellStyleEnum.Subtotal2];
                    break;
                case 3:
                    m_fg.Rows[v_i_new_grid_row].Style = m_fg.Styles[CellStyleEnum.Subtotal3];
                    break;

            }

            i_row_result = v_i_new_grid_row;
        }
        private void load_data_2_grid()
        {
            m_fg.Clear();
            m_fg.Cols[0].Width = 10;
            v_us_dm_tu_dien.FillDataset(v_ds_dm_tu_dien, "WHERE Id_loai_tu_dien = 5 AND ID <> 655");
            //1.tạo danh sách cột trạng thái
            m_fg.Cols.Count = v_ds_dm_tu_dien.CM_DM_TU_DIEN.Rows.Count+4;
            //m_fg.Cols[0].Width = 150;
            //m_fg.Cols[1].Caption = "Trạng thái/Chức vụ";
            m_fg.Cols[1].Caption = "Mã đơn vị cấp trên";
            m_fg.Cols[1].Visible = false;
            m_fg.Cols[2].Caption = "Mã đơn vị";
            m_fg.Cols[3].Caption = "Tổng";
            m_fg.Cols[3].UserData = 0;
            //m_fg.Cols[1].Style.ForeColor = Color.Black; 
            for (int i = 4; i < m_fg.Cols.Count; i++)
            {
                m_fg.Cols[i].Caption = v_ds_dm_tu_dien.CM_DM_TU_DIEN.Rows[i - 4][3].ToString();
                m_fg.Cols[i].UserData = v_ds_dm_tu_dien.CM_DM_TU_DIEN.Rows[i - 4][0];
            }
            //2. tạo danh sách dòng trạng thái
            m_us_1.FillDatasetByKeyWord(m_ds_1, "Y", CAppContext_201.getCurrentIDPhapnhan());
            int minID_LEVEL = int.Parse(m_ds_1.V_DM_DON_VI.Compute("Min(ID_LEVEL)", "").ToString());
            DataRow[] v_arr_dr_1 = m_ds_1.V_DM_DON_VI.Select(V_DM_DON_VI.ID_LEVEL + "=" + minID_LEVEL.ToString());
            if (v_arr_dr_1.Length == 0) return;
            CGridUtils.ClearDataInGrid(m_fg);
            m_us_1.DataRow2Me(v_arr_dr_1[0]);
            m_fg.Rows.Count += 1;
            int v_i_root_row = m_fg.Rows.Count - 1;
            //m_fg.Rows.Count = m_ds_1.V_DM_DON_VI.Rows.Count + 1;
            //int v_i_root_row = 1;
            m_fg.Rows[v_i_root_row].IsNode = true;
            m_fg.Rows[v_i_root_row].Node.Level = int.Parse(m_us_1.dcID_LEVEL.ToString());
            switch (m_fg.Rows[v_i_root_row].Node.Level)
            {
                case 0:
                    m_fg.Rows[v_i_root_row].Style = m_fg.Styles[CellStyleEnum.Subtotal0];
                    break;
                case 1:
                    m_fg.Rows[v_i_root_row].Style = m_fg.Styles[CellStyleEnum.Subtotal1];
                    break;
                case 2:
                    m_fg.Rows[v_i_root_row].Style = m_fg.Styles[CellStyleEnum.Subtotal2];
                    break;
                case 3:
                    m_fg.Rows[v_i_root_row].Style = m_fg.Styles[CellStyleEnum.Subtotal3];
                    break;

            }
            m_fg.Rows[1][1] = m_us_1.strMA_DON_VI_CAP_TREN;
            m_fg.Rows[1][2] = m_us_1.strMA_DON_VI;
            m_fg.Rows[1].UserData = m_us_1.dcID;
            insert_all_child_of_node(v_i_root_row, m_ds_1);
            //m_fg.Rows[1][1] = "Tổng";
            //m_fg.Rows[1].UserData = 0;
            
            /*for (int j = 1; j < m_fg.Rows.Count; j++)
            {
                m_fg.Rows[j][1] = m_ds_1.V_DM_DON_VI.Rows[j - 1][4].ToString();
                m_fg.Rows[j][2] = m_ds_1.V_DM_DON_VI.Rows[j - 1][7].ToString();
                m_fg.Rows[j].UserData = m_ds_1.V_DM_DON_VI.Rows[j - 1][0];
            }*/
            m_ds_1.Clear();
            //3.Đưa dữ liệu lên lưới
            m_ds_rpt = new DS_RPT_DON_VI_TRANG_THAI();
            m_us_rpt.FillDatasetByProc(m_ds_rpt, m_dat_thoidiem.Value, CAppContext_201.getCurrentIDPhapnhan());


            for (int v_i_cur_col = m_fg.Cols.Fixed+3; v_i_cur_col < m_fg.Cols.Count; v_i_cur_col++)
            {
                //if((int.Parse(row[1].ToString())) == (int.Parse(m_fg.Cols[u].UserData.ToString())))
                for (int v_i_cur_row = m_fg.Rows.Fixed; v_i_cur_row < m_fg.Rows.Count; v_i_cur_row++)
                {
                    string v_str_id_trang_thai = m_fg.Cols[v_i_cur_col].UserData.ToString();
                    string v_str_id_don_vi = m_fg.Rows[v_i_cur_row].UserData.ToString();


                    DataRow[] v_arr_dr
                        = m_ds_rpt.RPT_DON_VI_TRANG_THAI.Select(
                        RPT_DON_VI_TRANG_THAI.ID_TRANG_THAI + "="
                        + v_str_id_trang_thai
                        + " AND "
                        + RPT_DON_VI_TRANG_THAI.ID_DV + "="
                        + v_str_id_don_vi);
                    if (v_arr_dr.Length == 0) continue;
                    m_fg[v_i_cur_row, v_i_cur_col] = v_arr_dr[0][RPT_DON_VI_TRANG_THAI.SO_LUONG];
                }
            }
            for (int v = 1; v < m_fg.Rows.Count; v++)
            {
                int sum = 0;
                for (int t = 4; t < m_fg.Cols.Count; t++)
                    sum += Convert.ToInt32(m_fg.Rows[v][t]);
                m_fg.Rows[v][3] = sum;
            }
            m_fg.Redraw = false;
            //m_fg.SubtotalPosition = SubtotalPositionEnum.AboveData;
            //m_fg.Tree.Column = 1;
           // m_fg.Tree.Style = TreeStyleFlags.SimpleLeaf;
            //m_fg.Subtotal(AggregateEnum.Clear);
            //for (int u = 1; u < m_fg.Cols.Count; u++)
            //m_fg.Subtotal(AggregateEnum.Sum, 1, 1, 3);
            m_fg.Redraw = true;
        }


        private void export_2_excel()
        {
            CExcelReport v_obj_excel_rpt = new CExcelReport("f408_bao_cao_don_vi_trang_thai.xlsx", 3, 2);
            v_obj_excel_rpt.AddFindAndReplaceItem("<thoi_diem>", m_dat_thoidiem.Value.Date);
            v_obj_excel_rpt.FindAndReplace(false);
            v_obj_excel_rpt.Export2ExcelWithoutFixedRows(m_fg, 1, m_fg.Cols.Count - 1, true);
        }
        #endregion

        private void f408_bao_cao_don_vi_trang_thai_Load(object sender, EventArgs e)
        {
            try
            {
                set_initial_form_load();
            }
            catch (Exception v_e)
            {
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

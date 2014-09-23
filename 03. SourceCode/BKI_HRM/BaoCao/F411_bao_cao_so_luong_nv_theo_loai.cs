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
    public partial class F411_bao_cao_so_luong_nv_theo_loai : Form
    {
        public F411_bao_cao_so_luong_nv_theo_loai()
        {
            InitializeComponent();
            set_initial_form_load();
        }
        #region Members
        ITransferDataRow m_obj_trans;
        private bool load_invisible = true;
        DS_RPT_SO_LUONG_NV_THEO_LOAI m_ds_rpt = new DS_RPT_SO_LUONG_NV_THEO_LOAI();
        US_RPT_SO_LUONG_NV_THEO_LOAI m_us_rpt = new US_RPT_SO_LUONG_NV_THEO_LOAI();
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
            //1.tạo danh sách cột chức vụ
            m_fg.Cols.Count = m_dat_thoidiem.Value.Month+1;
            m_fg.Cols[0].Width = 200;
            //m_fg.Cols[1].Caption = "Trạng thái/Chức vụ";
            m_fg.Cols[0].Caption = "Loại nhân viên";
            m_fg.Cols[0].UserData = 0;
            //m_fg.Cols[1].Style.ForeColor = Color.Black; 
            for (int i = 1; i < m_fg.Cols.Count; i++)
            {
                m_fg.Cols[i].Caption = "Tháng " + i.ToString(); 
                m_fg.Cols[i].UserData = i;
            }
            //2. tạo danh sách dòng trạng thái
            m_fg.Rows.Count = 5;
            //m_fg.Rows[1][0] = "Tổng";
            //m_fg.Rows[1].UserData = 0;

            m_fg.Rows[1][0] = "Nhân viên chính thức chưa đủ 6 tháng";
            m_fg.Rows[1].UserData = 1;
            m_fg.Rows[2][0] = "Nhân viên chính thức đủ 6 tháng";
            m_fg.Rows[2].UserData = 2;
            m_fg.Rows[3][0] = "Nhân viên thử việc";
            m_fg.Rows[3].UserData = 3;
            m_fg.Rows[4][0] = "Nhân viên đang nghỉ";
            m_fg.Rows[4].UserData = 4;
            //3.Đưa dữ liệu lên lưới
            m_ds_rpt = new DS_RPT_SO_LUONG_NV_THEO_LOAI();
            m_us_rpt.FillDatasetByProc(m_ds_rpt, m_dat_thoidiem.Value, CAppContext_201.getCurrentIDPhapnhan());


            for (int v_i_cur_col = m_fg.Cols.Fixed; v_i_cur_col < m_fg.Cols.Count; v_i_cur_col++)
            {
                //if((int.Parse(row[1].ToString())) == (int.Parse(m_fg.Cols[u].UserData.ToString())))
                for (int v_i_cur_row = m_fg.Rows.Fixed; v_i_cur_row < m_fg.Rows.Count; v_i_cur_row++)
                {
                    string v_str_thang = m_fg.Cols[v_i_cur_col].UserData.ToString();
                    string v_str_id_loai_nv = m_fg.Rows[v_i_cur_row].UserData.ToString();


                    DataRow[] v_arr_dr
                        = m_ds_rpt.RPT_SO_LUONG_NV_THEO_LOAI.Select(
                        RPT_SO_LUONG_NV_THEO_LOAI.THANG + "="
                        + v_str_thang
                        + " AND "
                        + RPT_SO_LUONG_NV_THEO_LOAI.LOAI_NV + "="
                        + v_str_id_loai_nv);
                    if (v_arr_dr.Length == 0) continue;
                    m_fg[v_i_cur_row, v_i_cur_col] = v_arr_dr[0][RPT_SO_LUONG_NV_THEO_LOAI.SO_LUONG];
                }
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

        /*private void export_2_excel()
        {
            CExcelReport v_obj_excel_rpt = new CExcelReport("f405_bien_dong_nhan_su_chuc_vu_trang_thai.xlsx", 3, 1);
            v_obj_excel_rpt.AddFindAndReplaceItem("<thoi_diem>", m_dat_thoidiem.Value.Date);
            v_obj_excel_rpt.FindAndReplace(false);
            v_obj_excel_rpt.Export2ExcelWithoutFixedRows(m_fg, 1, m_fg.Cols.Count - 1, true);
        }*/
        #endregion
    }
    
}

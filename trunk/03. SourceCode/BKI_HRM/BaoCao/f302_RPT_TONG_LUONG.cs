using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using C1.Win.C1FlexGrid;
using IP.Core.IPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BKI_HRM.BaoCao
{
    public partial class f302_RPT_TONG_LUONG : Form
    {
        #region Public Interfaces
        public f302_RPT_TONG_LUONG()
        {
            InitializeComponent();
            init();
        }
        
        public delegate void close_tab(bool ip_y_n);
        public close_tab close_tab_B;

        #endregion

        #region Data Structure
        enum TONG_LUONG_BY_MA
        {
            CHUC_VU,
            TRANG_THAI_LAO_DONG
        }
        #endregion

        #region Members
        Dictionary<string, DS_RPT_TONG_LUONG> m_ds_tong_luong_n;
        #endregion

        #region Properties
        /// <summary>
        /// Lấy danh sách mã trạng thái lao động cần dùng để lấy DS báo cáo tổng lương.
        /// Lưu ý:
        /// Khi thêm 1 trạng thái lao động mới, cần thêm 1 dòng kiểm tra trạng thái đó vào hàm ttld_2_id.
        /// </summary>
        /// <returns>Danh sách mã trạng thái lao động</returns>
        private IEnumerable<string> get_ttld_n()
        {
            return (new string[] { "Thử việc", "Nghỉ khác" });
        }

        /// <summary>
        /// Chuyển đổi từ tên trạng thái lao động về id của nó. (Để biết Id, vui lòng xem trong DataBase bảng CM_TU_DIEN).
        /// </summary>
        /// <param name="ip_ttld">Tên trạng thái lao động</param>
        /// <returns></returns>
        private int get_id_ttld(string ip_ttld)
        {
            if (ip_ttld == "Thử việc")
                return 653;
            else if (ip_ttld == "Nghỉ khác")
                return 701;
            else
                return 0;
        }

        /// <summary>
        /// Lấy danh sách mã chức vụ cần dùng để lấy DS báo cáo tổng lương
        /// </summary>
        /// <returns>Danh sách mã chức vụ</returns>
        private IEnumerable<string> get_ma_cv_n()
        {
            return (new string[] { "PM", "TD", "CC" });
        }

        /// <summary>
        /// Lấy ds báo cáo tổng lương bằng mã và loại của mã đó
        /// </summary>
        /// <param name="ip_ma">Mã</param>
        /// <param name="ip_type">Loại mã: Xem enum TONG_LUONG_BY_MA</param>
        /// <returns>DS báo cáo tổng lương</returns>
        private DS_RPT_TONG_LUONG get_ds_tong_luong(string ip_ma, TONG_LUONG_BY_MA ip_type)
        {
            US_RPT_TONG_LUONG v_us_tong_luong = new US_RPT_TONG_LUONG();
            DS_RPT_TONG_LUONG op_ds_tong_luong = new DS_RPT_TONG_LUONG();

            decimal v_id_phap_nhan = IP.Core.IPSystemAdmin.CAppContext_201.getCurrentIDPhapnhan();

            try
            {
                switch (ip_type)
                {
                    case TONG_LUONG_BY_MA.CHUC_VU:
                        v_us_tong_luong.FillDatasetByMaCV(op_ds_tong_luong, ip_ma, v_id_phap_nhan);
                        break;
                    case TONG_LUONG_BY_MA.TRANG_THAI_LAO_DONG:

                        decimal id_ttld = get_id_ttld(ip_ma);

                        v_us_tong_luong.FillDatasetByMaTTLD(op_ds_tong_luong, id_ttld, v_id_phap_nhan);
                        break;
                    default:
                        return null;
                }

                return op_ds_tong_luong;
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }

            return null;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Hàm setup các properties + load dữ liệu trong giai đoạn khởi động
        /// </summary>
        private void init()
        {
            // Set properties
            init_members();
            init_events();

            // Load data from DB
            load_data_2_fg();

        }

        /// <summary>
        /// Hàm setup các properties của members
        /// </summary>
        private void init_members()
        {
            // m_cmd_xuat_exel
            m_cmd_xuat_excel.Visible = false;

            // m_ds_tong_luong_n
            m_ds_tong_luong_n = new Dictionary<string, DS_RPT_TONG_LUONG>();

            // Init
            US_DM_KY v_us_ky = new US_DM_KY();
            DS_DM_KY v_ds_ky = new DS_DM_KY();
            

            // Fill DS
            v_us_ky.FillDataset(v_ds_ky);

            // m_fg
            m_fg.AllowEditing = false;

            Column v_col;

            // Add column mã tổng lương
            v_col = m_fg.Cols.Add();
            v_col.Name = "MA_TONG_LUONG";
            v_col.Caption = "Mã tổng lương";
            v_col.DataType = typeof(string);

            // Add các column mã kỳ
            foreach (DataRow v_row in v_ds_ky.DM_KY.Rows)
            {
                string v_ma_ky = (String)v_row[DM_KY.MA_KY];
                v_col = m_fg.Cols.Add();
                v_col.Name = v_ma_ky;
                v_col.Caption = v_ma_ky;
                v_col.DataType = typeof(Decimal);
                v_col.Format = "#,###";
            }
        }

        /// <summary>
        /// Hàm setup các event
        /// </summary>
        private void init_events()
        {
            m_cmd_exit.Click += m_cmd_exit_Click;
        }

        /// <summary>
        /// Load data vào datagridview
        /// </summary>
        private void load_data_2_fg()
        {
            fill_ds_tong_luong_n();
            load_ds_tong_luong_2_fg();
        }

        /// <summary>
        /// Fill DS Tổng lương từ DB
        /// </summary>
        private void fill_ds_tong_luong_n()
        {
            foreach (string key in get_ma_cv_n())
                m_ds_tong_luong_n[key] = get_ds_tong_luong(key, TONG_LUONG_BY_MA.CHUC_VU);

            foreach (string key in get_ttld_n())
                m_ds_tong_luong_n[key] = get_ds_tong_luong(key, TONG_LUONG_BY_MA.TRANG_THAI_LAO_DONG);
        }

        /// <summary>
        /// Load dữ liệu DS Tổng lương vào FlexGrid m_fg
        /// </summary>
        private void load_ds_tong_luong_2_fg()
        {
            // Clear all rows are existed
            m_fg.Rows.RemoveRange(1, m_fg.Rows.Count - 1);

            Row v_row;

            // Add new rows
            foreach (string v_ma in m_ds_tong_luong_n.Keys)
            {
                // Ô đầu tiên là cột Mã tổng lương, gán bằng mã (Key) được lưu trong từ điển
                v_row = m_fg.Rows.Add();
                v_row["MA_TONG_LUONG"] = convert_ma_2_text(v_ma);

                // Duyệt từng dòng trong DataTable trong DS tương ứng với v_ma đang đọc
                // Gán giá trị ở cột tổng lương ở DS_RPT_TONG_LUONG vào cột mã kỳ tương ứng trong m_dgv

                DataTable v_dt_tong_luong = m_ds_tong_luong_n[v_ma].RPT_TONG_LUONG;
                if (v_dt_tong_luong.Rows.Count > 0)
                {
                    foreach (DataRow v_dr in v_dt_tong_luong.Rows)
                    {
                        if (v_dr[RPT_TONG_LUONG.TONG_LUONG] != DBNull.Value)
                        {
                            v_row[(string)v_dr[RPT_TONG_LUONG.MA_KY]] = (decimal)v_dr[RPT_TONG_LUONG.TONG_LUONG];
                        }
                        else
                            v_row[(string)v_dr[RPT_TONG_LUONG.MA_KY]] = 0;
                    }
                }

            }
        }

        /// <summary>
        /// Chuyển đổi từ dạng mã sang dạng xâu ký tự hiểu được
        /// </summary>
        /// <param name="v_ma">Mã cần convert</param>
        /// <returns>Xâu ký tự hiểu được</returns>
        private string convert_ma_2_text(string v_ma)
        {
            switch (v_ma)
            {
                case "THU_VIEC":
                    return "Thử việc";
                default:
                    return v_ma;
            }
        }
        #endregion

        #region Override methods
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Events
        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            close_tab_B(true);
        }
        #endregion
    }
}

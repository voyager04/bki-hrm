using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BKI_HRM.HelperDucVT
{
    class CUtils
    {
        #region Nháp

        /* Các SP mới thêm: 
         * - 18/10/2014:
         *      pr_V_GD_LUONG_THEO_QD_is_exist_luong_hien_tai
         *      pr_V_GD_LUONG_THEO_QD_Insert
         *      
         * 
         */

        #endregion

        #region Ghi chép

        /* Ghi chép 1:
         * v_us.BeginTransaction(); // 
         * v_us.Delete();
         * v_us.CommitTransaction();
         * 
         * v_us.Rollback(); // m_HaveTrans = false và m_Connection.Close()
         *                  // Chấm dứt kết nối.
         */

        /* Ghi chép 2:
         * Tốt nhất mọi công việc Select/Insert/Update/Delete dù cho là thao tác trên 1 bảng hay nhiều bảng thì nên làm việc đó ở DataBase
         * Tức là dùng Store Procedure để thực hiện, chỉ cần truyền thông tin cần thiết cho nó.
         */


        #endregion

        #region Không dùng

        /// <summary>
        /// Tạo custom source cho autocomplete
        /// </summary>
        /// <param name="ip_dt">Lấy thông tin từ DataSet</param>
        /// <param name="ip_selected_cols">Các cột sẽ lấy thông tin trong DataTable trong DataSet</param>
        /// <param name="ip_divided_char">Ký tự ngăn cách giữa các cột</param>
        /// <returns>Custom source autocomplete</returns>
        public static AutoCompleteStringCollection create_csac(System.Data.DataTable ip_dt, String[] ip_selected_cols, String ip_divided_char = "-")
        {
            AutoCompleteStringCollection v_custom_source = new AutoCompleteStringCollection();

            // First row is empty
            v_custom_source.Add(String.Empty);

            // Add rows data
            foreach (DataRow row in ip_dt.Rows)
            {
                // Create string row
                String v_string_row = String.Empty;
                int i = 0;
                for (; i < (ip_selected_cols.Length - 1); i++)
                    v_string_row += ((String)row[ip_selected_cols[i]] + " " + ip_divided_char + " ");

                v_string_row += (String)row[ip_selected_cols[i]];

                // Add string row to custom source
                v_custom_source.Add(v_string_row);
            }

            return v_custom_source;
        }

        /// <summary>
        /// RowFilter DataView từ DataSet bằng query. Truyền FlexGrid muốn gán vào DataSource nếu muốn.
        /// </summary>
        /// <param name="ip_ds">DataSet để lọc dữ liệu</param>
        /// <param name="ip_query">Câu lệnh điều kiện lọc dữ liệu, có dạng: "(Column Name) =/like '%(Value)%'", 
        ///                         Có thể dùng: and, or.
        ///                         Có thể dùng hàm String.Format hỗ trợ</param>
        /// <param name="ip_fg">FlexGrid để áp dụng dữ liệu, mặc định = null</param>
        /// <returns>DataView đã được Filter</returns>
        public static DataView select_in_ds(DataSet ip_ds, String ip_query, C1.Win.C1FlexGrid.C1FlexGrid ip_fg = null)
        {
            DataView v_dv = ip_ds.Tables[0].DefaultView;
            v_dv.RowFilter = ip_query;

            if (ip_fg != null)
                load_dv_2_grid(v_dv, ip_fg);

            return v_dv;
        }

        /// <summary>
        /// RowFilter DataView từ DataSet bằng query. Truyền FlexGrid muốn gán vào DataSource nếu muốn.
        /// </summary>
        /// <param name="ip_ds">DataSet để lọc dữ liệu</param>
        /// <param name="ip_query">Câu lệnh điều kiện lọc dữ liệu, có dạng: "(Column Name) =/like '%(Value)%'", 
        ///                         Có thể dùng: and, or.
        ///                         Có thể dùng hàm String.Format hỗ trợ</param>
        /// <param name="ip_dgv">DataGridView để áp dụng dữ liệu, mặc định = null</param>
        /// <returns>DataView đã được Filter</returns>
        private DataView select_in_ds(DataSet ip_ds, String ip_query, DataGridView ip_dgv = null)
        {
            return null;
        }

        /// <summary>
        /// Load DataView làm DataSource của FlexGrid
        /// </summary>
        /// <param name="ip_dv"></param>
        /// <param name="ip_fg"></param>
        public static void load_dv_2_grid(DataView ip_dv, C1.Win.C1FlexGrid.C1FlexGrid ip_fg)
        {
            ip_fg.DataSource = ip_dv;
        }

        /// <summary>
        /// Load DataView làm DataSource của DataGridView
        /// </summary>
        /// <param name="ip_dv"></param>
        /// <param name="ip_fg"></param>
        private void load_dv_2_grid(DataView ip_dv, DataGridView ip_dgv)
        {
        }

        #endregion

        #region Đang dùng

        #region Public Methods

        #region Autocomplete Methods

        /// <summary>
        /// Tạo custom source cho autocomplete với dữ liệu từ DM_NHAN_SU
        /// </summary>
        /// <param name="ip_type">Loại Custom Source muốn tạo</param>
        /// <returns>Custom source autocomplete của bảng DM_NHAN_SU</returns>
        public static AutoCompleteStringCollection create_csac_nhan_su(Int16 ip_type = 0)
        {
            // Initialize
            US_DM_NHAN_SU v_us_dm_nhan_su = new US_DM_NHAN_SU();
            DS_DM_NHAN_SU v_ds_dm_nhan_su = new DS_DM_NHAN_SU();
            AutoCompleteStringCollection v_acsc = new AutoCompleteStringCollection();

            try
            {
                // Fill dataset
                v_us_dm_nhan_su.FillDataset(v_ds_dm_nhan_su);

                // Create custom source
                // Tạo thêm type mới ở đây
                switch (ip_type)
                {
                    case 0:
                        foreach (var v_rows in v_ds_dm_nhan_su.DM_NHAN_SU)
                        {
                            v_acsc.Add(v_rows[DM_NHAN_SU.HO_DEM] + " - " + v_rows[DM_NHAN_SU.TEN] + " - " + v_rows[DM_NHAN_SU.MA_NV]);
                            v_acsc.Add(v_rows[DM_NHAN_SU.TEN] + " - " + v_rows[DM_NHAN_SU.HO_DEM] + " " + v_rows[DM_NHAN_SU.TEN] + " - " + v_rows[DM_NHAN_SU.MA_NV]);
                            v_acsc.Add(v_rows[DM_NHAN_SU.MA_NV] + " - " + v_rows[DM_NHAN_SU.HO_DEM] + " " + v_rows[DM_NHAN_SU.TEN] + " - " + v_rows[DM_NHAN_SU.MA_NV]);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
                return null;
            }

            return v_acsc;
        }

        /// <summary>
        /// Init và Load autocomplete cho Textbox
        /// </summary>
        /// <param name="op_txt">Textbox cần thực hiện</param>
        /// <param name="ip_type">Loại custom source load</param>
        /// <returns>Load thành công hay không</returns>
        public static bool load_autocmp_nhan_su(TextBox op_txt, Int16 ip_type = 0)
        {
            // Create custom source and load
            AutoCompleteStringCollection v_cs = create_csac_nhan_su(ip_type);
            return load_autocmp(op_txt, v_cs);
        }

        /// <summary>
        /// Create custom source for autocomplete from DM_KY
        /// </summary>
        /// <returns>Custom source</returns>
        public static AutoCompleteStringCollection create_csac_ky()
        {
            // Initialize
            US_DM_KY v_us_dm_ky = new US_DM_KY();
            DS_DM_KY v_ds_dm_ky = new DS_DM_KY();
            AutoCompleteStringCollection v_acsc = new AutoCompleteStringCollection();

            try
            {
                // Fill dataset
                v_us_dm_ky.FillDataset(v_ds_dm_ky);

                // Create custom source
                foreach (var v_rows in v_ds_dm_ky.DM_KY)
                {
                    v_acsc.Add((String)v_rows[DM_KY.MA_KY]);
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
                return null;
            }

            return v_acsc;
        }

        /// <summary>
        /// Init and load autocomplete for TextBox
        /// </summary>
        /// <param name="op_txt">TextBox needed load data</param>
        /// <returns>True if success</returns>
        public static bool load_autocmp_ky(TextBox op_txt)
        {
            AutoCompleteStringCollection v_cs = create_csac_ky();
            return load_autocmp(op_txt, v_cs);
        }

        #endregion

        #region DataSource Methods

        /// <summary>
        /// Tạo DataSource từ loại quyết định
        /// </summary>
        /// <param name="ip_type">Loại dữ liệu quyết định: Lương, Tất cả</param>
        /// <returns>DataSource với type DataSet</returns>
        public static DataSet create_datasource_loai_quyet_dinh(String ip_type)
        {
            try
            {
                // Init
                DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
                BKI_HRM.US.US_CM_DM_TU_DIEN v_us = new BKI_HRM.US.US_CM_DM_TU_DIEN();

                // Fill Dataset
                v_us.FillDataset_load_loai_quyet_dinh(v_ds, ip_type, "N");

                return v_ds;
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
                return null;
            }
        }

        /// <summary>
        /// Load DataSource cho combobox từ dữ liệu loại quyết định
        /// </summary>
        /// <param name="op_cbo">ComboBox cần load</param>
        /// <param name="ip_type">Loại: default - Tất cả; 1 - Lương</param>
        /// <returns>Trả lại true nếu thành công</returns>
        public static bool load_datasource_loai_quyet_dinh(ComboBox op_cbo, Int16 ip_type = 0)
        {
            // Convert from int to string
            String v_type = "Tất cả";
            switch (ip_type)
            {
                case 1:
                    v_type = "Lương";
                    break;
                default:
                    v_type = "Tất cả";
                    break;
            }

            // Get datasource and load data
            DataSet v_ds = create_datasource_loai_quyet_dinh(v_type);
            if (v_ds != null)
            {
                op_cbo.DataSource = v_ds.Tables[0];
                op_cbo.DisplayMember = CM_DM_TU_DIEN.TEN;
                op_cbo.ValueMember = CM_DM_TU_DIEN.ID;
            }
            else
                return false;

            return true;
        }

        #endregion

        #region File methods
        public static bool execute_file(String ip_path_file)
        {
            try
            {
                Process.Start("explorer.exe", ip_path_file);
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
                return false;
            }

            return true;
        }

        #endregion

        #region DataBase methods
        /// <summary>
        /// Lấy auto increase Id - Id tự tăng ở vị trí hiện tại, + 1 sẽ ra Id của bản ghi tiếp theo. Dù có delete đi các dòng thì nó vẫn đúng.
        /// </summary>
        /// <param name="ip_table_name">Tên bảng cần lấy Id tự tăng hiện tại</param>
        /// <param name="ip_str_conn">String Connection kết nối tới DB. Cú pháp: Server={0};Database={1};User Id={2};Password={3};</param>
        /// <returns></returns>
        public static Decimal get_current_auto_id(String ip_table_name, String ip_str_conn = "")
        {
            // Init
            Decimal op_next_id = Decimal.Zero;

            if (ip_table_name != "")
            {
                // Init string connection
                String str_conn;
                if (ip_str_conn != "")
                    str_conn = ip_str_conn;
                else
                    str_conn = String.Format("Server={0};Database={1};User Id={2};Password={3};",
                                                    ConfigurationSettings.AppSettings["SERVER"],
                                                    ConfigurationSettings.AppSettings["INITIAL_DATABASE"],
                                                    ConfigurationSettings.AppSettings["INITIAL_USER"],
                                                    ConfigurationSettings.AppSettings["PASS_WORD"]);


                // Init sql query - Câu lệnh sql lấy ID tự tăng tiếp theo
                String sql_query = String.Format("SELECT IDENT_CURRENT('{0}')", ip_table_name);

                // Start connection and get value
                using (SqlConnection conn = new SqlConnection(str_conn))
                {
                    SqlCommand cmd = new SqlCommand(sql_query, conn);

                    try
                    {
                        // Open connection
                        conn.Open();

                        var value = cmd.ExecuteScalar();
                        // Đảm bảo giá trị trả về không Null trong trường hợp tên bảng sai
                        if (value != System.DBNull.Value)
                            op_next_id = (Decimal)value; // Chắc chắn sẽ convert được thành decimal nếu có giá trị trả về
                        
                        // Close connection
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        CSystemLog_301.ExceptionHandle(ex);
                    }
                }
            }

            return op_next_id;
        }

        #endregion

        #region Message methods
        /// <summary>
        /// Hiển thị thông báo thành công với lời nhắn
        /// </summary>
        /// <param name="ip_text">Lời thông báo</param>
        public static void show_success_message(String ip_text)
        {
            MessageBox.Show(ip_text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Load custom source to TextBox
        /// </summary>
        /// <param name="op_txt">Textbox</param>
        /// <param name="ip_custom_soure">Custom source</param>
        /// <returns>Success or not</returns>
        private static bool load_autocmp(TextBox op_txt, AutoCompleteStringCollection ip_custom_soure)
        {
            if (ip_custom_soure != null)
            {
                op_txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                op_txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                op_txt.AutoCompleteCustomSource = ip_custom_soure;
                return true;
            }
            else
                return false;
        }

        #endregion

        #endregion
    }
}

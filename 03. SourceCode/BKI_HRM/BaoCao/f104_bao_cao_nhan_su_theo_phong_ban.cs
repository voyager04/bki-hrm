using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BKI_HRM.DanhMuc;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;

namespace BKI_HRM {
    public partial class f104_bao_cao_nhan_su_theo_phong_ban : Form {

        public f104_bao_cao_nhan_su_theo_phong_ban() {
            InitializeComponent();
            format_controls();
        }

        #region Public Interface
        public void display() {
            this.ShowDialog();
        }
        #endregion

        #region Data Structure

        private enum e_col_Number {
            NGAY_BAT_DAU = 9
                ,
            TEN_CV = 7
                ,
            TEN_DON_VI = 1
                ,
            MA_NV = 3
                ,
            MA_DON_VI = 2
                ,
            NGAY_KET_THUC = 10
                ,
            MA_CV = 6
                ,
            HO_DEM = 4
                ,
            NGAY_HET_HIEU_LUC = 13
                ,
            TEN = 5
                ,
            TRANG_THAI_CV = 8
                ,
            MA_QUYET_DINH = 11
                , 
            NGAY_CO_HIEU_LUC = 12
        }
        #endregion

        #region Members
        ITransferDataRow m_obj_trans;
        DS_V_GD_QUA_TRINH_LAM_VIEC m_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC();
        US_V_GD_QUA_TRINH_LAM_VIEC m_us = new US_V_GD_QUA_TRINH_LAM_VIEC();

        #endregion

        #region Private Methods

        private void format_controls() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            m_fg.Tree.Column = (int)e_col_Number.TEN_DON_VI;
            m_fg.Tree.Style = TreeStyleFlags.Simple;

            set_define_events();
            this.KeyPreview = true;
        }
        private void set_initial_form_load() {
            m_obj_trans = get_trans_object(m_fg);
            load_data_2_grid();
            set_format_txt_search();
            
        }

        private void set_format_txt_search() {
            if (m_txt_tim_kiem.Text.Trim().Equals(String.Empty)) {
                m_txt_tim_kiem.Select(); //Đưa chuột vào ô tìm kiếm
            } else {
                m_txt_tim_kiem.SelectAll(); //Chọn tất cả dữ liệu trong ô tìm kiếm
            }
        }

        private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg) {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_BAT_DAU, e_col_Number.NGAY_BAT_DAU);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TEN_CV, e_col_Number.TEN_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TEN_DON_VI, e_col_Number.TEN_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_DON_VI, e_col_Number.MA_DON_VI);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_KET_THUC, e_col_Number.NGAY_KET_THUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_CV, e_col_Number.MA_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.HO_DEM, e_col_Number.HO_DEM);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_HET_HIEU_LUC, e_col_Number.NGAY_HET_HIEU_LUC);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TEN, e_col_Number.TEN);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.TRANG_THAI_CV, e_col_Number.TRANG_THAI_CV);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.MA_QUYET_DINH, e_col_Number.MA_QUYET_DINH);
            v_htb.Add(V_GD_QUA_TRINH_LAM_VIEC.NGAY_CO_HIEU_LUC, e_col_Number.NGAY_CO_HIEU_LUC);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds.V_GD_QUA_TRINH_LAM_VIEC.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid() {
            m_ds = new DS_V_GD_QUA_TRINH_LAM_VIEC();
            string v_str_search = m_txt_tim_kiem.Text.Trim();
            DateTime v_dat_thoi_diem = DateTime.Now;
            if (m_dtp_thoidiem.Checked){
                v_dat_thoi_diem = m_dtp_thoidiem.Value.Date;
            }
            m_us.FillDatase_NhanSu_TheoPhongBan(m_ds, v_str_search, v_dat_thoi_diem);
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            /*Group (subtotal) trên grid.*/
            m_fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count
              , 0
              , (int)e_col_Number.TEN_DON_VI   // Group theo cột này
              , (int)e_col_Number.MA_NV    // Subtotal theo cột này
              , "{0}"
              );
            m_fg.Redraw = true;
            /*Đếm số dòng dữ liệu trên Grid*/
            m_lbl_so_luong_ban_ghi.Text = m_ds.V_GD_QUA_TRINH_LAM_VIEC.Count.ToString();
        }
        #endregion

        //
        //
        //		EVENT HANLDERS
        //
        //

        private void set_define_events() {
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_txt_tim_kiem.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
            m_txt_tim_kiem.KeyDown += new KeyEventHandler(m_txt_tim_kiem_KeyDown);
            m_cmd_search.Click += new EventHandler(m_cmd_search_Click);
        }

        private void f104_bao_cao_nhan_su_theo_phong_ban_Load(object sender, System.EventArgs e) {
            try {
                set_initial_form_load();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        private void m_cmd_exit_Click(object sender, EventArgs e) {
            try {
                this.Close();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e) {
            try {
                if (e.KeyChar == (char)Keys.Return) {
                    load_data_2_grid();
                }
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_tim_kiem_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyData == Keys.Enter)
                   load_data_2_grid();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_search_Click(object sender, EventArgs e) {
            try {
                load_data_2_grid();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }


    }
}

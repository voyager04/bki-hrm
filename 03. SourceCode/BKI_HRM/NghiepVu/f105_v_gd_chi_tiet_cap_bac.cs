///************************************************
/// Generated by: TrongHV
/// Date: 11/03/2014 07:05:14
/// Goal: Create Form for V_GD_CHI_TIET_CAP_BAC
///************************************************


using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using BKI_HRM.DanhMuc;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPSystemAdmin;

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;
using SIS.Controls.Button;

namespace BKI_HRM {

    public class f105_v_gd_chi_tiet_cap_bac : Form {
        internal ImageList ImageList;
        internal Panel m_pnl_out_place_dm;
        internal SiSButton m_cmd_delete;
        internal SiSButton m_cmd_update;
        internal SiSButton m_cmd_insert;
        internal SiSButton m_cmd_exit;
        private Panel panel1;
        private Label m_lbl_so_luong_ban_ghi;
        internal SiSButton m_cmd_search;
        private TextBox m_txt_search;
        private Label label2;
        private Label m_lbl_tim_kiem;
        private Label m_lbl_phim_tat;
        private C1FlexGrid m_fg;
        private IContainer components;

        public f105_v_gd_chi_tiet_cap_bac() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            format_controls();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f105_v_gd_chi_tiet_cap_bac));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_lbl_phim_tat = new System.Windows.Forms.Label();
            this.m_cmd_insert = new SIS.Controls.Button.SiSButton();
            this.m_cmd_update = new SIS.Controls.Button.SiSButton();
            this.m_cmd_delete = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lbl_so_luong_ban_ghi = new System.Windows.Forms.Label();
            this.m_cmd_search = new SIS.Controls.Button.SiSButton();
            this.m_txt_search = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lbl_tim_kiem = new System.Windows.Forms.Label();
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_pnl_out_place_dm.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            this.ImageList.Images.SetKeyName(8, "");
            this.ImageList.Images.SetKeyName(9, "");
            this.ImageList.Images.SetKeyName(10, "");
            this.ImageList.Images.SetKeyName(11, "");
            this.ImageList.Images.SetKeyName(12, "");
            this.ImageList.Images.SetKeyName(13, "");
            this.ImageList.Images.SetKeyName(14, "");
            this.ImageList.Images.SetKeyName(15, "");
            this.ImageList.Images.SetKeyName(16, "");
            this.ImageList.Images.SetKeyName(17, "");
            this.ImageList.Images.SetKeyName(18, "");
            this.ImageList.Images.SetKeyName(19, "");
            this.ImageList.Images.SetKeyName(20, "");
            this.ImageList.Images.SetKeyName(21, "");
            // 
            // m_pnl_out_place_dm
            // 
            this.m_pnl_out_place_dm.Controls.Add(this.m_lbl_phim_tat);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_insert);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_update);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_delete);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 426);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(845, 36);
            this.m_pnl_out_place_dm.TabIndex = 19;
            // 
            // m_lbl_phim_tat
            // 
            this.m_lbl_phim_tat.AutoSize = true;
            this.m_lbl_phim_tat.Location = new System.Drawing.Point(12, 11);
            this.m_lbl_phim_tat.Name = "m_lbl_phim_tat";
            this.m_lbl_phim_tat.Size = new System.Drawing.Size(206, 13);
            this.m_lbl_phim_tat.TabIndex = 1000;
            this.m_lbl_phim_tat.Text = "Phím tắt: F6_Mở rộng-Thu gọn danh sách";
            // 
            // m_cmd_insert
            // 
            this.m_cmd_insert.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_insert.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_insert.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_insert.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_insert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_insert.ImageIndex = 21;
            this.m_cmd_insert.ImageList = this.ImageList;
            this.m_cmd_insert.Location = new System.Drawing.Point(440, 4);
            this.m_cmd_insert.Name = "m_cmd_insert";
            this.m_cmd_insert.Size = new System.Drawing.Size(137, 28);
            this.m_cmd_insert.TabIndex = 3;
            this.m_cmd_insert.Text = "&Thay đổi cấp bậc";
            // 
            // m_cmd_update
            // 
            this.m_cmd_update.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_update.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_update.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_update.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_update.ImageIndex = 3;
            this.m_cmd_update.ImageList = this.ImageList;
            this.m_cmd_update.Location = new System.Drawing.Point(577, 4);
            this.m_cmd_update.Name = "m_cmd_update";
            this.m_cmd_update.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_update.TabIndex = 4;
            this.m_cmd_update.Text = "&Sửa";
            this.m_cmd_update.Visible = false;
            // 
            // m_cmd_delete
            // 
            this.m_cmd_delete.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_delete.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_delete.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_delete.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_delete.ImageIndex = 4;
            this.m_cmd_delete.ImageList = this.ImageList;
            this.m_cmd_delete.Location = new System.Drawing.Point(665, 4);
            this.m_cmd_delete.Name = "m_cmd_delete";
            this.m_cmd_delete.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_delete.TabIndex = 5;
            this.m_cmd_delete.Text = "&Xoá";
            // 
            // m_cmd_exit
            // 
            this.m_cmd_exit.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_exit.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_exit.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_exit.ImageIndex = 12;
            this.m_cmd_exit.ImageList = this.ImageList;
            this.m_cmd_exit.Location = new System.Drawing.Point(753, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 6;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lbl_so_luong_ban_ghi);
            this.panel1.Controls.Add(this.m_cmd_search);
            this.panel1.Controls.Add(this.m_txt_search);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_lbl_tim_kiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 72);
            this.panel1.TabIndex = 22;
            // 
            // m_lbl_so_luong_ban_ghi
            // 
            this.m_lbl_so_luong_ban_ghi.AutoSize = true;
            this.m_lbl_so_luong_ban_ghi.Location = new System.Drawing.Point(179, 56);
            this.m_lbl_so_luong_ban_ghi.Name = "m_lbl_so_luong_ban_ghi";
            this.m_lbl_so_luong_ban_ghi.Size = new System.Drawing.Size(25, 13);
            this.m_lbl_so_luong_ban_ghi.TabIndex = 1;
            this.m_lbl_so_luong_ban_ghi.Text = "000";
            this.m_lbl_so_luong_ban_ghi.Visible = false;
            // 
            // m_cmd_search
            // 
            this.m_cmd_search.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search.ImageIndex = 5;
            this.m_cmd_search.ImageList = this.ImageList;
            this.m_cmd_search.Location = new System.Drawing.Point(697, 17);
            this.m_cmd_search.Name = "m_cmd_search";
            this.m_cmd_search.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_search.TabIndex = 2;
            this.m_cmd_search.Text = "Tìm kiếm";
            // 
            // m_txt_search
            // 
            this.m_txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_txt_search.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_search.ForeColor = System.Drawing.Color.DimGray;
            this.m_txt_search.Location = new System.Drawing.Point(149, 21);
            this.m_txt_search.Name = "m_txt_search";
            this.m_txt_search.Size = new System.Drawing.Size(517, 20);
            this.m_txt_search.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Số lượng dòng trong danh sách:";
            this.label2.Visible = false;
            // 
            // m_lbl_tim_kiem
            // 
            this.m_lbl_tim_kiem.AutoSize = true;
            this.m_lbl_tim_kiem.Location = new System.Drawing.Point(52, 24);
            this.m_lbl_tim_kiem.Name = "m_lbl_tim_kiem";
            this.m_lbl_tim_kiem.Size = new System.Drawing.Size(88, 13);
            this.m_lbl_tim_kiem.TabIndex = 24;
            this.m_lbl_tim_kiem.Text = "Từ khoá tìm kiếm";
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_fg.Location = new System.Drawing.Point(0, 72);
            this.m_fg.Name = "m_fg";
            this.m_fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.m_fg.Size = new System.Drawing.Size(845, 354);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 23;
            // 
            // f105_v_gd_chi_tiet_cap_bac
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(845, 462);
            this.Controls.Add(this.m_fg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f105_v_gd_chi_tiet_cap_bac";
            this.Text = "F105 - Chi tết cấp bậc";
            this.Load += new System.EventHandler(this.f105_v_gd_chi_tiet_cap_bac_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            this.m_pnl_out_place_dm.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Public Interface
        public void display() {
            ShowDialog();
        }
        #endregion

        #region Data Structure
        private enum e_col_Number {
            MA_CAP_BAC = 4
                ,
            NGAY_BAT_DAU = 5
                ,
            MA_NV = 1
                ,
            NGAY_KET_THUC = 6
                ,
            HO_DEM = 2
                ,
            TEN = 3
                ,
            LUA_CHON = 9
                ,
            MA_QUYET_DINH = 7
                , 
            TRANG_THAI_CB = 8
        }
        #endregion

        #region Members
        ITransferDataRow m_obj_trans;
        DS_V_GD_CHI_TIET_CAP_BAC m_ds = new DS_V_GD_CHI_TIET_CAP_BAC();
        US_V_GD_CHI_TIET_CAP_BAC m_us = new US_V_GD_CHI_TIET_CAP_BAC();
        private const String m_str_goi_y_tim_kiem = "Tìm kiếm Mã nhân viên, Họ tên nhân viên, Mã quyết định, Mã cấp, Mã bậc";
        #endregion

        #region Private Methods
        private void format_controls() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            m_fg.Tree.Column = (int)e_col_Number.HO_DEM; //Cột chứa tiêu đề tree
            m_fg.Tree.Style = TreeStyleFlags.Simple;
            set_define_events();
            KeyPreview = true;
        }
        private void set_initial_form_load() {
            m_obj_trans = get_trans_object(m_fg);
            load_data_2_grid();
        }
        private ITransferDataRow get_trans_object(C1FlexGrid i_fg) {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_GD_CHI_TIET_CAP_BAC.MA_CAP_BAC, e_col_Number.MA_CAP_BAC);
            v_htb.Add(V_GD_CHI_TIET_CAP_BAC.NGAY_BAT_DAU, e_col_Number.NGAY_BAT_DAU);
            v_htb.Add(V_GD_CHI_TIET_CAP_BAC.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(V_GD_CHI_TIET_CAP_BAC.NGAY_KET_THUC, e_col_Number.NGAY_KET_THUC);
            v_htb.Add(V_GD_CHI_TIET_CAP_BAC.HO_DEM, e_col_Number.HO_DEM);
            v_htb.Add(V_GD_CHI_TIET_CAP_BAC.TEN, e_col_Number.TEN);
            v_htb.Add(V_GD_CHI_TIET_CAP_BAC.LUA_CHON, e_col_Number.LUA_CHON);
            v_htb.Add(V_GD_CHI_TIET_CAP_BAC.MA_QUYET_DINH, e_col_Number.MA_QUYET_DINH);
            v_htb.Add(V_GD_CHI_TIET_CAP_BAC.TRANG_THAI_CB, e_col_Number.TRANG_THAI_CB);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds.V_GD_CHI_TIET_CAP_BAC.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid() {
            m_ds = new DS_V_GD_CHI_TIET_CAP_BAC();
            var v_str_search = m_txt_search.Text.Trim();
            if (v_str_search.Equals(m_str_goi_y_tim_kiem)) {
                v_str_search = "";
            }
            m_us.FillDatasetByKeyWord(m_ds, v_str_search);
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            m_fg.Redraw = true;
            m_fg.Subtotal(AggregateEnum.Count
              , 0
              , (int)e_col_Number.MA_NV             // Cột lấy tiêu đề tree
              , (int)e_col_Number.TEN               // Subtotal theo cột này
              , "{0}"
              );
            load_custom_source_2_m_txt_search();
            set_search_format_before();
            /*Đếm số dòng dữ liệu trên Grid*/
            m_lbl_so_luong_ban_ghi.Text = m_ds.V_GD_CHI_TIET_CAP_BAC.Count.ToString();
        }
        private void load_custom_source_2_m_txt_search() {
            m_txt_search.AutoCompleteMode = AutoCompleteMode.Suggest;
            m_txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var v_coll = new AutoCompleteStringCollection();
            var v_rows = m_ds.Tables[0].Rows;
            for (var i = 0; i < v_rows.Count - 1; i++) {
                v_coll.Add(v_rows[i]["MA_NV"] + "");
                v_coll.Add(v_rows[i]["HO_DEM"] + "");
                v_coll.Add(v_rows[i]["TEN"] + " ");
                v_coll.Add(v_rows[i]["HO_DEM"] + " " + v_rows[i]["TEN"]);
                v_coll.Add(v_rows[i]["TRANG_THAI_CB"] + "");
                v_coll.Add(v_rows[i]["MA_BAC"] + "");
                v_coll.Add(v_rows[i]["MA_QUYET_DINH"] + "");
            }
            m_txt_search.AutoCompleteCustomSource = v_coll;
        }
        private void grid2us_object(US_V_GD_CHI_TIET_CAP_BAC i_v_us, int i_grid_row) {
            DataRow v_dr;
            v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            m_obj_trans.GridRow2DataRow(i_grid_row, v_dr);
            i_v_us.DataRow2Me(v_dr);
        }
        private void insert_v_gd_chi_tiet_cap_bac() {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            if (m_fg.Rows[m_fg.Row].IsNode) return;
            grid2us_object(m_us, m_fg.Row);
            var v_fDE = new f106_v_gd_chi_tiet_cap_bac_DE();
            v_fDE.display_for_insert(m_us, m_ds);
            load_data_2_grid();
            WinFormControls.set_focus_for_grid(m_fg,m_us.strMA_NV,(int)e_col_Number.MA_NV);
        }
        private void delete_v_gd_chi_tiet_cap_bac() {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted) return;
            US_V_GD_CHI_TIET_CAP_BAC v_v_us = new US_V_GD_CHI_TIET_CAP_BAC();
            US_GD_CHI_TIET_CAP_BAC v_us = new US_GD_CHI_TIET_CAP_BAC();
            grid2us_object(v_v_us, m_fg.Row);
            v_us.dcID = v_v_us.dcID;
            try {
                v_us.BeginTransaction();
                v_us.Delete();
                v_us.CommitTransaction();
                m_fg.Rows.Remove(m_fg.Row);
            } catch (Exception v_e) {
                v_us.Rollback();
                CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e,
                    new CDBClientDBExceptionInterpret());
                v_objErrHandler.showErrorMessage();
            }
        }
        private void set_search_format_before() {
            if (m_txt_search.Text == "") {
                m_txt_search.Text = m_str_goi_y_tim_kiem;
                m_txt_search.ForeColor = Color.Gray;
            }
        }
        private void set_search_format_after() {
            if (m_txt_search.Text == m_str_goi_y_tim_kiem) {
                m_txt_search.Text = "";
            }
            m_txt_search.ForeColor = Color.Black;
        }
        #endregion

        //
        //		EVENT HANLDERS
        //
        private void set_define_events() {
            m_cmd_exit.Click += m_cmd_exit_Click;
            m_cmd_insert.Click += m_cmd_insert_Click;
            m_cmd_delete.Click += m_cmd_delete_Click;
            m_cmd_search.Click += m_cmd_search_Click;
            m_txt_search.KeyDown += m_txt_search_KeyDown;
            m_txt_search.MouseClick += m_txt_search_MouseClick;
            m_txt_search.Leave += m_txt_search_Leave;
        }

        private void f105_v_gd_chi_tiet_cap_bac_Load(object sender, EventArgs e) {
            try {
                set_initial_form_load();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        private void m_cmd_exit_Click(object sender, EventArgs e) {
            try {
                Close();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_insert_Click(object sender, EventArgs e) {
            try {
                insert_v_gd_chi_tiet_cap_bac();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_delete_Click(object sender, EventArgs e) {
            try {
                delete_v_gd_chi_tiet_cap_bac();
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

        private void m_txt_search_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyData == Keys.Enter) {
                    load_data_2_grid();
                } else {
                    set_search_format_after();
                }
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_search_MouseClick(object sender, MouseEventArgs e) {
            try {
                set_search_format_after();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_search_Leave(object sender, EventArgs e) {
            try {
                set_search_format_before();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
    
    }
}


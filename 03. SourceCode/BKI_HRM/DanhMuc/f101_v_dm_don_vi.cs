///************************************************
/// Generated by: TrongHV
/// Date: 21/01/2014 03:36:18
/// Goal: Create Form for V_DM_DON_VI
///************************************************


using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
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
using SIS.Controls.Button;

namespace BKI_HRM {

    public class f101_v_dm_don_vi : Form {
        internal ImageList ImageList;
        internal Panel m_pnl_out_place_dm;
        internal SiSButton m_cmd_delete;
        internal SiSButton m_cmd_update;
        internal SiSButton m_cmd_insert;
        internal SiSButton m_cmd_exit;
        private Panel panel1;
        internal SiSButton m_cmd_search;
        private TextBox m_txt_tim_kiem;
        private Label m_lbl_tim_kiem;
        private Label m_lbl_so_luong_ban_ghi;
        private Label label2;
        private C1FlexGrid m_fg;
        private ToolTip m_tooltip;
        internal SiSButton m_cmd_view;
        internal SiSButton m_cmd_chon_don_vi;
        private IContainer components;

        public f101_v_dm_don_vi() {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f101_v_dm_don_vi));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_chon_don_vi = new SIS.Controls.Button.SiSButton();
            this.m_cmd_insert = new SIS.Controls.Button.SiSButton();
            this.m_cmd_update = new SIS.Controls.Button.SiSButton();
            this.m_cmd_view = new SIS.Controls.Button.SiSButton();
            this.m_cmd_delete = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_lbl_so_luong_ban_ghi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmd_search = new SIS.Controls.Button.SiSButton();
            this.m_txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.m_lbl_tim_kiem = new System.Windows.Forms.Label();
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
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
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_chon_don_vi);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_insert);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_update);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_view);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_delete);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 525);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(1063, 36);
            this.m_pnl_out_place_dm.TabIndex = 19;
            // 
            // m_cmd_chon_don_vi
            // 
            this.m_cmd_chon_don_vi.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_chon_don_vi.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_chon_don_vi.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_chon_don_vi.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_chon_don_vi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_chon_don_vi.ImageIndex = 13;
            this.m_cmd_chon_don_vi.ImageList = this.ImageList;
            this.m_cmd_chon_don_vi.Location = new System.Drawing.Point(610, 4);
            this.m_cmd_chon_don_vi.Name = "m_cmd_chon_don_vi";
            this.m_cmd_chon_don_vi.Size = new System.Drawing.Size(97, 28);
            this.m_cmd_chon_don_vi.TabIndex = 34;
            this.m_cmd_chon_don_vi.Text = "&Chọn đơn vị";
            this.m_cmd_chon_don_vi.Click += new System.EventHandler(this.m_cmd_chon_don_vi_Click);
            // 
            // m_cmd_insert
            // 
            this.m_cmd_insert.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_insert.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_insert.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_insert.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cmd_insert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_insert.ImageIndex = 2;
            this.m_cmd_insert.ImageList = this.ImageList;
            this.m_cmd_insert.Location = new System.Drawing.Point(707, 4);
            this.m_cmd_insert.Name = "m_cmd_insert";
            this.m_cmd_insert.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_insert.TabIndex = 5;
            this.m_cmd_insert.Text = "&Thêm";
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
            this.m_cmd_update.Location = new System.Drawing.Point(795, 4);
            this.m_cmd_update.Name = "m_cmd_update";
            this.m_cmd_update.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_update.TabIndex = 6;
            this.m_cmd_update.Text = "&Sửa";
            // 
            // m_cmd_view
            // 
            this.m_cmd_view.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_view.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_view.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_view.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_view.ImageIndex = 18;
            this.m_cmd_view.ImageList = this.ImageList;
            this.m_cmd_view.Location = new System.Drawing.Point(4, 4);
            this.m_cmd_view.Name = "m_cmd_view";
            this.m_cmd_view.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_view.TabIndex = 4;
            this.m_cmd_view.Text = "Xem";
            this.m_cmd_view.Visible = false;
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
            this.m_cmd_delete.Location = new System.Drawing.Point(883, 4);
            this.m_cmd_delete.Name = "m_cmd_delete";
            this.m_cmd_delete.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_delete.TabIndex = 7;
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
            this.m_cmd_exit.Location = new System.Drawing.Point(971, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 8;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // m_lbl_so_luong_ban_ghi
            // 
            this.m_lbl_so_luong_ban_ghi.AutoSize = true;
            this.m_lbl_so_luong_ban_ghi.Location = new System.Drawing.Point(179, 47);
            this.m_lbl_so_luong_ban_ghi.Name = "m_lbl_so_luong_ban_ghi";
            this.m_lbl_so_luong_ban_ghi.Size = new System.Drawing.Size(25, 14);
            this.m_lbl_so_luong_ban_ghi.TabIndex = 28;
            this.m_lbl_so_luong_ban_ghi.Text = "000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "Số lượng đơn vị trong danh sách:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lbl_so_luong_ban_ghi);
            this.panel1.Controls.Add(this.m_cmd_search);
            this.panel1.Controls.Add(this.m_txt_tim_kiem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_lbl_tim_kiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1063, 64);
            this.panel1.TabIndex = 21;
            // 
            // m_cmd_search
            // 
            this.m_cmd_search.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_search.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_search.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_search.ImageIndex = 5;
            this.m_cmd_search.ImageList = this.ImageList;
            this.m_cmd_search.Location = new System.Drawing.Point(876, 12);
            this.m_cmd_search.Name = "m_cmd_search";
            this.m_cmd_search.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_search.TabIndex = 2;
            this.m_cmd_search.Text = "Tìm kiếm";
            // 
            // m_txt_tim_kiem
            // 
            this.m_txt_tim_kiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_txt_tim_kiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.m_txt_tim_kiem.ForeColor = System.Drawing.Color.DimGray;
            this.m_txt_tim_kiem.Location = new System.Drawing.Point(185, 16);
            this.m_txt_tim_kiem.Name = "m_txt_tim_kiem";
            this.m_txt_tim_kiem.Size = new System.Drawing.Size(653, 20);
            this.m_txt_tim_kiem.TabIndex = 1;
            this.m_tooltip.SetToolTip(this.m_txt_tim_kiem, "Tìm kiếm theo tên đơn vị, mã đơn vị");
            // 
            // m_lbl_tim_kiem
            // 
            this.m_lbl_tim_kiem.AutoSize = true;
            this.m_lbl_tim_kiem.Location = new System.Drawing.Point(80, 19);
            this.m_lbl_tim_kiem.Name = "m_lbl_tim_kiem";
            this.m_lbl_tim_kiem.Size = new System.Drawing.Size(87, 14);
            this.m_lbl_tim_kiem.TabIndex = 24;
            this.m_lbl_tim_kiem.Text = "Từ khoá tìm kiếm";
            // 
            // m_fg
            // 
            this.m_fg.AllowEditing = false;
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_fg.Location = new System.Drawing.Point(0, 64);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(1063, 461);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 29;
            this.m_tooltip.SetToolTip(this.m_fg, "Nháy đúp vào dòng đơn vị cần chỉnh sửa");
            this.m_fg.Tree.LineColor = System.Drawing.Color.Maroon;
            // 
            // f101_v_dm_don_vi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1063, 561);
            this.Controls.Add(this.m_fg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f101_v_dm_don_vi";
            this.Text = "F101 - Danh sách đơn vị";
            this.Load += new System.EventHandler(this.f101_v_dm_don_vi_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
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
        public void select_data(ref US_DM_DON_VI op_us_dm_don_vi) {
            m_e_form_mode = DataEntryFormMode.SelectDataState;
            this.ShowDialog();
            op_us_dm_don_vi = m_us;

        }
        #endregion

        #region Data Structure
        private enum e_col_Number {
            TEN_DON_VI_CAP_TREN = 1
                ,
            ID_CAP_DON_VI = 5
                ,
            TEN_TIENG_ANH = 10
                ,
            ID = 3
                ,
            TEN_DON_VI = 9
                ,
            TEN_TIENG_ANH_DON_VI_CAP_TREN = 8
                ,
            MA_DON_VI = 2
                ,
            TRANG_THAI = 15
                ,
            CAP_DON_VI = 11
                ,
            MA_DON_VI_CAP_TREN = 7
                ,
            TU_NGAY = 13
                ,
            ID_DON_VI_CAP_TREN = 4
                ,
            LOAI_DON_VI = 12
                ,
            ID_LOAI_DON_VI = 6
                ,
            DIA_BAN = 14

        }
        #endregion

        #region Members
        ITransferDataRow m_obj_trans;
        DS_V_DM_DON_VI m_v_ds = new DS_V_DM_DON_VI();
        US_V_DM_DON_VI m_v_us = new US_V_DM_DON_VI();
        DS_DM_DON_VI m_ds = new DS_DM_DON_VI();
        US_DM_DON_VI m_us = new US_DM_DON_VI();
        private const String m_str_goi_y_tim_kiem = "Nhập Tên đơn vị, Mã đơn vị, Địa bạn, Trạng Thái...";
        DataEntryFormMode m_e_form_mode = DataEntryFormMode.ViewDataState;
        #endregion

        #region Private Methods

        private void format_controls() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            m_fg.Tree.Column = (int)e_col_Number.MA_DON_VI;
            m_fg.Cols[(int) e_col_Number.TEN_DON_VI_CAP_TREN].Visible = false;
                m_fg.Tree.Style = TreeStyleFlags.Simple;
            set_define_events();
            KeyPreview = true;
        }
        private void set_initial_form_load() {
            switch (m_e_form_mode) {
                case DataEntryFormMode.UpdateDataState:
                    m_cmd_chon_don_vi.Visible = false;
                    break;
                case DataEntryFormMode.InsertDataState:
                    m_cmd_chon_don_vi.Visible = false;
                    break;
                case DataEntryFormMode.ViewDataState:
                    m_cmd_chon_don_vi.Visible = false;
                    break;
                case DataEntryFormMode.SelectDataState:
                    m_cmd_chon_don_vi.Visible = true;
                    m_cmd_chon_don_vi.Enabled = true;
                    m_cmd_insert.Visible = false;
                    m_cmd_update.Visible = false;
                    m_cmd_delete.Visible = false;
                    break;

            }
            m_obj_trans = get_trans_object(m_fg);
            load_data_2_grid();
            //load_custom_source_2_m_txt_tim_kiem();
        }
        private ITransferDataRow get_trans_object(C1FlexGrid i_fg) {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(V_DM_DON_VI.TEN_DON_VI_CAP_TREN, e_col_Number.TEN_DON_VI_CAP_TREN);
            v_htb.Add(V_DM_DON_VI.ID_CAP_DON_VI, e_col_Number.ID_CAP_DON_VI);
            v_htb.Add(V_DM_DON_VI.TEN_TIENG_ANH, e_col_Number.TEN_TIENG_ANH);
            v_htb.Add(V_DM_DON_VI.ID, e_col_Number.ID);
            v_htb.Add(V_DM_DON_VI.TEN_DON_VI, e_col_Number.TEN_DON_VI);
            v_htb.Add(V_DM_DON_VI.TEN_TIENG_ANH_DON_VI_CAP_TREN, e_col_Number.TEN_TIENG_ANH_DON_VI_CAP_TREN);
            v_htb.Add(V_DM_DON_VI.MA_DON_VI, e_col_Number.MA_DON_VI);
            v_htb.Add(V_DM_DON_VI.TRANG_THAI, e_col_Number.TRANG_THAI);
            v_htb.Add(V_DM_DON_VI.CAP_DON_VI, e_col_Number.CAP_DON_VI);
            v_htb.Add(V_DM_DON_VI.MA_DON_VI_CAP_TREN, e_col_Number.MA_DON_VI_CAP_TREN);
            v_htb.Add(V_DM_DON_VI.TU_NGAY, e_col_Number.TU_NGAY);
            v_htb.Add(V_DM_DON_VI.ID_DON_VI_CAP_TREN, e_col_Number.ID_DON_VI_CAP_TREN);
            v_htb.Add(V_DM_DON_VI.LOAI_DON_VI, e_col_Number.LOAI_DON_VI);
            v_htb.Add(V_DM_DON_VI.ID_LOAI_DON_VI, e_col_Number.ID_LOAI_DON_VI);
            v_htb.Add(V_DM_DON_VI.DIA_BAN, e_col_Number.DIA_BAN);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_v_ds.V_DM_DON_VI.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid() {
            m_v_ds = new DS_V_DM_DON_VI();
            var v_str_search = m_txt_tim_kiem.Text.Trim();
            if (v_str_search.Equals(m_str_goi_y_tim_kiem)) {
                v_str_search = "";
            }
            m_v_us.FillDatasetByKeyWord(m_v_ds, v_str_search);
            //m_v_us.FillDatasetByKeyWord(m_v_ds);
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_v_ds, m_fg, m_obj_trans);
            // Group (subtotal) trên grid.
            m_fg.Subtotal(AggregateEnum.Count
              , 0
              , (int)e_col_Number.TEN_DON_VI_CAP_TREN   // Group theo cột này
              , (int)e_col_Number.TEN_DON_VI             // Subtotal theo cột này
              , "{0}"
              );
            m_fg.Redraw = true;
            set_search_format_before();
            /*Đếm số dòng dữ liệu trên Grid*/
            m_lbl_so_luong_ban_ghi.Text = m_v_ds.V_DM_DON_VI.Count.ToString();
        }
        private void load_custom_source_2_m_txt_tim_kiem() {
            //var v_str_search = m_txt_tim_kiem.Text.Trim();
            //m_v_us.FillDatasetByKeyWordTop(m_v_ds, v_str_search);
            var count = m_v_ds.Tables["V_DM_DON_VI"].Rows.Count;
            for (var i = 0; i < count; i++) {
                var dr = m_v_ds.Tables["V_DM_DON_VI"].Rows[i];
                m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr["MA_DON_VI"].ToString().Trim());
                m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr["TEN_DON_VI"].ToString().Trim());
                //m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr["MA_DON_VI"].ToString().Trim() + "-" + dr["TEN_DON_VI"].ToString().Trim());
                //m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr["TEN_DON_VI"].ToString().Trim() + "-" + dr["MA_DON_VI"].ToString().Trim());
                m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr["TEN_DON_VI_CAP_TREN"].ToString().Trim());
                m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr["TEN_TIENG_ANH"].ToString().Trim());
                m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr["DIA_BAN"].ToString().Trim());
                m_txt_tim_kiem.AutoCompleteCustomSource.Add(dr["TRANG_THAI"].ToString().Trim());
            }
        }
        //private void grid2us_object(US_DM_DON_VI i_us, int i_grid_row) {
        //    DataRow v_dr;
        //    v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
        //    i_us = new US_DM_DON_VI((decimal)v_dr.ItemArray[0]);
        //}
        private void grid2us_object(int i_grid_row) {
            DataRow v_dr;
            v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            m_us = new US_DM_DON_VI((decimal)v_dr.ItemArray[0]);
        }
        private void grid2us_object(US_V_DM_DON_VI i_us, int i_grid_row) {
            DataRow v_dr;
            v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            m_obj_trans.GridRow2DataRow(i_grid_row, v_dr);
            i_us.DataRow2Me(v_dr);
        }
        private void select_data_2_us() {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg))
                return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row))
                return;

            try {
                grid2us_object(m_fg.Row);
                this.Close();
            } catch (Exception v_e) {
                MessageBox.Show("Dòng chọn không hợp lệ. Mời chọn dòng khác", "Cảnh báo");
            }

        }
        private void insert_v_dm_don_vi() {
            var v_fDE = new f102_v_dm_don_vi_de();
            v_fDE.display_for_insert();
            load_data_2_grid();
        }
        private void update_v_dm_don_vi() {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            if (m_fg.Rows[m_fg.Row].IsNode) return;
            grid2us_object(m_v_us, m_fg.Row);
            var v_f_de = new f102_v_dm_don_vi_de();
            v_f_de.display_for_update(m_v_us);
            load_data_2_grid();
        }
        private void delete_v_dm_don_vi() {
            if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            if (BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted) return;
            var v_us = new US_V_DM_DON_VI();
            grid2us_object(v_us, m_fg.Row);
            try {
                v_us.BeginTransaction();
                v_us.Delete();
                v_us.CommitTransaction();
                m_fg.Rows.Remove(m_fg.Row);
            } catch (Exception v_e) {
                v_us.Rollback();
                var v_objErrHandler = new CDBExceptionHandler(v_e,
                    new CDBClientDBExceptionInterpret());
                v_objErrHandler.showErrorMessage();
            }
        }
        private void set_search_format_before() {
            if (m_txt_tim_kiem.Text == "") {
                m_txt_tim_kiem.Text = m_str_goi_y_tim_kiem;
                m_txt_tim_kiem.ForeColor = Color.Gray;
            }
        }
        private void set_search_format_after() {
            if (m_txt_tim_kiem.Text == m_str_goi_y_tim_kiem) {
                m_txt_tim_kiem.Text = "";
            }
            m_txt_tim_kiem.ForeColor = Color.Black;
        }
        private void set_m_fg_DoubleClick(object sender, EventArgs e) {
            /**
             * Double Click vào dòng group thì nó đóng mở
             * */
            if (m_fg.Rows[m_fg.Row].IsNode) CGridUtils.grid_Double_Click(sender, e);
            else update_v_dm_don_vi();
        }
        #endregion

        //
        //
        //		EVENT HANLDERS
        //
        //

        private void set_define_events() {
            m_cmd_exit.Click += m_cmd_exit_Click;
            m_cmd_insert.Click += m_cmd_insert_Click;
            m_cmd_update.Click += m_cmd_update_Click;
            m_cmd_delete.Click += m_cmd_delete_Click;
            m_cmd_search.Click += m_cmd_search_Click;
            m_txt_tim_kiem.KeyPress += CheckEnterKeyPress;
            m_txt_tim_kiem.KeyDown += m_txt_tim_kiem_KeyDown;
            m_fg.DoubleClick += m_fg_DoubleClick;
            m_fg.Click += m_fg_Click;
            m_txt_tim_kiem.MouseClick += m_txt_tim_kiem_MouseClick;
            m_txt_tim_kiem.Leave += m_txt_tim_kiem_Leave;
            m_txt_tim_kiem.TextChanged += m_txt_tim_kiem_TextChanged;
        }

        private void f101_v_dm_don_vi_Load(object sender, EventArgs e) {
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
                insert_v_dm_don_vi();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_update_Click(object sender, EventArgs e) {
            try {
                update_v_dm_don_vi();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_delete_Click(object sender, EventArgs e) {
            try {
                delete_v_dm_don_vi();
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
                if (e.KeyData == Keys.Enter) {
                    load_data_2_grid();
                } else {
                    set_search_format_after();
                }
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_fg_DoubleClick(object sender, EventArgs e) {
            try {
                set_m_fg_DoubleClick(sender, e);
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_fg_Click(object sender, EventArgs e) {
            try {

            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_tim_kiem_MouseClick(object sender, MouseEventArgs e) {
            try {
                set_search_format_after();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_tim_kiem_Leave(object sender, EventArgs e) {
            try {
                set_search_format_before();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_txt_tim_kiem_TextChanged(object sender, EventArgs e) {
            try {

            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_chon_don_vi_Click(object sender, EventArgs e) {
            try {
                select_data_2_us();
            } catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

    }
}


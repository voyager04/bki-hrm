///************************************************
/// Generated by: TuyenNT
/// Date: 27/09/2014 08:12:11
/// Goal: Create Form for RPT_LUONG_THEO_QD
///************************************************


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

using BKI_HRM.US;
using BKI_HRM.DS;
using BKI_HRM.DS.CDBNames;

using C1.Win.C1FlexGrid;

namespace BKI_HRM {



    public class f800_BC_LUONG_THEO_QD : System.Windows.Forms.Form {
        internal System.Windows.Forms.ImageList ImageList;
        internal System.Windows.Forms.Panel m_pnl_out_place_dm;
        private C1.Win.C1FlexGrid.C1FlexGrid m_fg;
        internal SIS.Controls.Button.SiSButton m_cmd_delete;
        internal SIS.Controls.Button.SiSButton m_cmd_update;
        internal SIS.Controls.Button.SiSButton m_cmd_insert;
        internal SIS.Controls.Button.SiSButton m_cmd_exit;
        internal SIS.Controls.Button.SiSButton m_cmd_view;
        private Panel panel1;
        private DateTimePicker m_dat_nam;
        private Label label1;
        private TextBox m_txt_tim_kiem;
        internal SIS.Controls.Button.SiSButton m_cmd_tim_kiem;
        internal SIS.Controls.Button.SiSButton m_cmd_ok;
        private Label label2;
        private System.ComponentModel.IContainer components;

        public f800_BC_LUONG_THEO_QD() {
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
            if(disposing) {
                if(components != null) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f800_BC_LUONG_THEO_QD));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
            this.m_cmd_insert = new SIS.Controls.Button.SiSButton();
            this.m_cmd_update = new SIS.Controls.Button.SiSButton();
            this.m_cmd_view = new SIS.Controls.Button.SiSButton();
            this.m_cmd_delete = new SIS.Controls.Button.SiSButton();
            this.m_cmd_exit = new SIS.Controls.Button.SiSButton();
            this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmd_ok = new SIS.Controls.Button.SiSButton();
            this.m_cmd_tim_kiem = new SIS.Controls.Button.SiSButton();
            this.m_txt_tim_kiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dat_nam = new System.Windows.Forms.DateTimePicker();
            this.m_pnl_out_place_dm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_insert);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_update);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_view);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_delete);
            this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_exit);
            this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 426);
            this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
            this.m_pnl_out_place_dm.Padding = new System.Windows.Forms.Padding(4);
            this.m_pnl_out_place_dm.Size = new System.Drawing.Size(1036, 36);
            this.m_pnl_out_place_dm.TabIndex = 19;
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
            this.m_cmd_insert.Location = new System.Drawing.Point(680, 4);
            this.m_cmd_insert.Name = "m_cmd_insert";
            this.m_cmd_insert.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_insert.TabIndex = 12;
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
            this.m_cmd_update.Location = new System.Drawing.Point(768, 4);
            this.m_cmd_update.Name = "m_cmd_update";
            this.m_cmd_update.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_update.TabIndex = 13;
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
            this.m_cmd_view.TabIndex = 21;
            this.m_cmd_view.Text = "Xem";
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
            this.m_cmd_delete.Location = new System.Drawing.Point(856, 4);
            this.m_cmd_delete.Name = "m_cmd_delete";
            this.m_cmd_delete.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_delete.TabIndex = 14;
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
            this.m_cmd_exit.Location = new System.Drawing.Point(944, 4);
            this.m_cmd_exit.Name = "m_cmd_exit";
            this.m_cmd_exit.Size = new System.Drawing.Size(88, 28);
            this.m_cmd_exit.TabIndex = 11;
            this.m_cmd_exit.Text = "Thoát (Esc)";
            // 
            // m_fg
            // 
            this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
            this.m_fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_fg.Location = new System.Drawing.Point(0, 99);
            this.m_fg.Name = "m_fg";
            this.m_fg.Size = new System.Drawing.Size(1036, 327);
            this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
            this.m_fg.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_cmd_ok);
            this.panel1.Controls.Add(this.m_cmd_tim_kiem);
            this.panel1.Controls.Add(this.m_txt_tim_kiem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_dat_nam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 99);
            this.panel1.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Tìm kiếm";
            // 
            // m_cmd_ok
            // 
            this.m_cmd_ok.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_ok.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_ok.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_ok.ImageIndex = 14;
            this.m_cmd_ok.ImageList = this.ImageList;
            this.m_cmd_ok.Location = new System.Drawing.Point(175, 12);
            this.m_cmd_ok.Name = "m_cmd_ok";
            this.m_cmd_ok.Size = new System.Drawing.Size(101, 28);
            this.m_cmd_ok.TabIndex = 34;
            this.m_cmd_ok.Text = "Hiển thị";
            // 
            // m_cmd_tim_kiem
            // 
            this.m_cmd_tim_kiem.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmd_tim_kiem.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
            this.m_cmd_tim_kiem.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
            this.m_cmd_tim_kiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmd_tim_kiem.ImageIndex = 5;
            this.m_cmd_tim_kiem.ImageList = this.ImageList;
            this.m_cmd_tim_kiem.Location = new System.Drawing.Point(667, 54);
            this.m_cmd_tim_kiem.Name = "m_cmd_tim_kiem";
            this.m_cmd_tim_kiem.Size = new System.Drawing.Size(101, 28);
            this.m_cmd_tim_kiem.TabIndex = 33;
            this.m_cmd_tim_kiem.Text = "&Tìm kiếm";
            // 
            // m_txt_tim_kiem
            // 
            this.m_txt_tim_kiem.Location = new System.Drawing.Point(347, 59);
            this.m_txt_tim_kiem.Name = "m_txt_tim_kiem";
            this.m_txt_tim_kiem.Size = new System.Drawing.Size(295, 20);
            this.m_txt_tim_kiem.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn năm";
            // 
            // m_dat_nam
            // 
            this.m_dat_nam.CustomFormat = "yyyy";
            this.m_dat_nam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dat_nam.Location = new System.Drawing.Point(98, 14);
            this.m_dat_nam.Name = "m_dat_nam";
            this.m_dat_nam.ShowUpDown = true;
            this.m_dat_nam.Size = new System.Drawing.Size(54, 20);
            this.m_dat_nam.TabIndex = 0;
            // 
            // f800_BC_LUONG_THEO_QD
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1036, 462);
            this.Controls.Add(this.m_fg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_pnl_out_place_dm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f800_BC_LUONG_THEO_QD";
            this.Text = "F800 - Báo cáo lương theo quyết định";
            this.Load += new System.EventHandler(this.f800_BC_LUONG_THEO_QD_Load);
            this.m_pnl_out_place_dm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_fg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Public Interface
        public void display() {
            this.ShowDialog();
        }
        public static AutoCompleteStringCollection LoadAutoComplete(DS_RPT_LUONG_THEO_QD ip_ds) {
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            //for(int v_col = 0; v_col < ip_ds.RPT_LUONG_THEO_QD.Columns.Count -1; v_col++) {
            //    stringCol.Add(Convert.ToString(ip_ds.RPT_LUONG_THEO_QD.Rows[0]));
            //    stringCol.Add(Convert.ToString(ip_ds.RPT_LUONG_THEO_QD.Rows[1]) + Convert.ToString(ip_ds.RPT_LUONG_THEO_QD.Rows[2]));
            //}

            foreach(DataRow row in ip_ds.RPT_LUONG_THEO_QD) {
                    for(int v_col = 0; v_col < ip_ds.RPT_LUONG_THEO_QD.Columns.Count -1; v_col++){
                        if(v_col == 1) continue;
                        if(v_col == 2) {
                            stringCol.Add(Convert.ToString(row[1]) +" " + Convert.ToString(row[2]));
                            continue;
                        }
                        stringCol.Add(Convert.ToString(row[v_col]));
                }
            }
            return stringCol; //return the string collection with added records
        }
        #endregion

        #region Data Structure
        private enum e_col_Number {
            MA_NV = 1
,
            NGAY_AP_DUNG_KY_II = 15
                ,
            MA_QD_DAU_KY_I = 9
                ,
            NGAY_AP_DUNG_GIUA_KY_II = 18
                ,
            LUONG_CUOI_KY_I = 13
                ,
            TEN = 3
                ,
            LUONG_CUOI_KY_II = 20
                ,
            MA_DON_VI = 5
                ,
            HO_DEM = 2
                ,
            MA_QD_GIUA_KI_I = 12
                ,
            MA_QD_GIUA_KI_II = 19
                ,
            LUONG_DAU_KY_II = 14
                ,
            LUONG_DAU_KY_I = 7
                ,
            LUONG_GIUA_KY_II = 17
                ,
            TRANG_THAI_LD_HIEN_TAI = 6
                ,
            MA_QD_DAU_KY_II = 16
                ,
            NGAY_AP_DUNG_KY_I = 8
                ,
            MA_CV = 4
                ,
            NGAY_AP_DUNG_GIUA_KY_I = 11
                , LUONG_GIUA_KY_I = 10

        }
        #endregion

        #region Members
        ITransferDataRow m_obj_trans;
        DS_RPT_LUONG_THEO_QD m_ds = new DS_RPT_LUONG_THEO_QD();
        US_RPT_LUONG_THEO_QD m_us = new US_RPT_LUONG_THEO_QD();
        #endregion

        #region Private Methods
        public DataTable LoadDataTable() {
            return m_ds.RPT_LUONG_THEO_QD;
        }
        private void format_controls() {
            CControlFormat.setFormStyle(this, new CAppContext_201());
            CControlFormat.setC1FlexFormat(m_fg);
            CGridUtils.AddSave_Excel_Handlers(m_fg);
            CGridUtils.AddSearch_Handlers(m_fg);
            format_fixed_rows_in_grid();
            set_define_events();
            this.KeyPreview = true;
        }
        private void wrap_text_all_cells() {
            m_fg.Styles[CellStyleEnum.Normal].WordWrap = true;
            m_fg.AllowResizing = AllowResizingEnum.Rows;
            m_fg.AutoSizeRows();
        }
        private void format_fixed_rows_in_grid() {
            m_fg.Rows.Fixed = 2;
            m_fg.AllowMerging = AllowMergingEnum.FixedOnly;

            /*Merge 2 */
            m_fg.Cols[0].AllowMerging = true;
            m_fg[0, 0] = "STT";
            m_fg[1, 0] = "STT";

            m_fg.Cols[(int)e_col_Number.MA_NV].AllowMerging = true;
            m_fg[0, (int)e_col_Number.MA_NV] = "Mã NV";
            m_fg[1, (int)e_col_Number.MA_NV] = "Mã NV";

            m_fg.Cols[(int)e_col_Number.HO_DEM].AllowMerging = true;
            m_fg[0, (int)e_col_Number.HO_DEM] = "Họ đệm";
            m_fg[1, (int)e_col_Number.HO_DEM] = "Họ đệm";

            m_fg.Cols[(int)e_col_Number.TEN].AllowMerging = true;
            m_fg[0, (int)e_col_Number.TEN] = "Tên";
            m_fg[1, (int)e_col_Number.TEN] = "Tên";

            m_fg.Cols[(int)e_col_Number.MA_CV].AllowMerging = true;
            m_fg[0, (int)e_col_Number.MA_CV] = "Mã CV hiện tại";
            m_fg[1, (int)e_col_Number.MA_CV] = "Mã CV hiện tại";

            m_fg.Cols[(int)e_col_Number.MA_DON_VI].AllowMerging = true;
            m_fg[0, (int)e_col_Number.MA_DON_VI] = "Mã ĐV hiện tại";
            m_fg[1, (int)e_col_Number.MA_DON_VI] = "Mã ĐV hiện tại";

            m_fg.Cols[(int)e_col_Number.TRANG_THAI_LD_HIEN_TAI].AllowMerging = true;
            m_fg[0, (int)e_col_Number.TRANG_THAI_LD_HIEN_TAI] = "Trạng thái LĐ hiện tại";
            m_fg[1, (int)e_col_Number.TRANG_THAI_LD_HIEN_TAI] = "Trạng thái LĐ hiện tại";

            //Merge nhiều cột thành các kỳ
            string v_str_ky_1 = "KỲ I/" + m_dat_nam.Value.Year;
            m_fg.Rows[0].AllowMerging = true;
            m_fg[0, (int)e_col_Number.LUONG_DAU_KY_I] = v_str_ky_1;
            m_fg[0, (int)e_col_Number.NGAY_AP_DUNG_KY_I] = v_str_ky_1;
            m_fg[0, (int)e_col_Number.MA_QD_DAU_KY_I] = v_str_ky_1;
            m_fg[0, (int)e_col_Number.LUONG_GIUA_KY_I] = v_str_ky_1;
            m_fg[0, (int)e_col_Number.NGAY_AP_DUNG_GIUA_KY_I] = v_str_ky_1;
            m_fg[0, (int)e_col_Number.MA_QD_GIUA_KI_I] = v_str_ky_1;
            m_fg[0, (int)e_col_Number.LUONG_CUOI_KY_I] = v_str_ky_1;

            string v_str_ky_2 = "KỲ II/" + m_dat_nam.Value.Year;
            m_fg[0, (int)e_col_Number.LUONG_DAU_KY_II] = v_str_ky_2;
            m_fg[0, (int)e_col_Number.NGAY_AP_DUNG_KY_II] = v_str_ky_2;
            m_fg[0, (int)e_col_Number.MA_QD_DAU_KY_II] = v_str_ky_2;
            m_fg[0, (int)e_col_Number.LUONG_GIUA_KY_II] = v_str_ky_2;
            m_fg[0, (int)e_col_Number.NGAY_AP_DUNG_GIUA_KY_II] = v_str_ky_2;
            m_fg[0, (int)e_col_Number.MA_QD_GIUA_KI_II] = v_str_ky_2;
            m_fg[0, (int)e_col_Number.LUONG_CUOI_KY_II] = v_str_ky_2;
            //
            m_fg[1, (int)e_col_Number.LUONG_DAU_KY_I] = "Lương đầu kỳ";
            m_fg[1, (int)e_col_Number.NGAY_AP_DUNG_KY_I] = "Ngày áp dụng";
            m_fg[1, (int)e_col_Number.MA_QD_DAU_KY_I] = "Mã QĐ";
            m_fg[1, (int)e_col_Number.LUONG_GIUA_KY_I] = "Lương giữa kỳ";
            m_fg[1, (int)e_col_Number.NGAY_AP_DUNG_GIUA_KY_I] = "Ngày áp dụng";
            m_fg[1, (int)e_col_Number.MA_QD_GIUA_KI_I] = "Mã QĐ";
            m_fg[1, (int)e_col_Number.LUONG_CUOI_KY_I] = "Lương cuối kỳ";

            m_fg[1, (int)e_col_Number.LUONG_DAU_KY_II] = "Lương đầu kỳ";
            m_fg[1, (int)e_col_Number.NGAY_AP_DUNG_KY_II] = "Ngày áp dụng";
            m_fg[1, (int)e_col_Number.MA_QD_DAU_KY_II] = "Mã QĐ";
            m_fg[1, (int)e_col_Number.LUONG_GIUA_KY_II] = "Lương giữa kỳ";
            m_fg[1, (int)e_col_Number.NGAY_AP_DUNG_GIUA_KY_II] = "Ngày áp dụng";
            m_fg[1, (int)e_col_Number.MA_QD_GIUA_KI_II] = "Mã QĐ";
            m_fg[1, (int)e_col_Number.LUONG_CUOI_KY_II] = "Lương cuối kỳ";

        }
        private void set_initial_form_load() {
            m_obj_trans = get_trans_object(m_fg);

            load_data_2_grid();
            auto_complete_text();
        }
        private ITransferDataRow get_trans_object(C1.Win.C1FlexGrid.C1FlexGrid i_fg) {
            Hashtable v_htb = new Hashtable();
            v_htb.Add(RPT_LUONG_THEO_QD.MA_NV, e_col_Number.MA_NV);
            v_htb.Add(RPT_LUONG_THEO_QD.NGAY_AP_DUNG_KY_II, e_col_Number.NGAY_AP_DUNG_KY_II);
            v_htb.Add(RPT_LUONG_THEO_QD.MA_QD_DAU_KY_I, e_col_Number.MA_QD_DAU_KY_I);
            v_htb.Add(RPT_LUONG_THEO_QD.NGAY_AP_DUNG_GIUA_KY_II, e_col_Number.NGAY_AP_DUNG_GIUA_KY_II);
            v_htb.Add(RPT_LUONG_THEO_QD.LUONG_CUOI_KY_I, e_col_Number.LUONG_CUOI_KY_I);
            v_htb.Add(RPT_LUONG_THEO_QD.TEN, e_col_Number.TEN);
            v_htb.Add(RPT_LUONG_THEO_QD.LUONG_CUOI_KY_II, e_col_Number.LUONG_CUOI_KY_II);
            v_htb.Add(RPT_LUONG_THEO_QD.MA_DON_VI, e_col_Number.MA_DON_VI);
            v_htb.Add(RPT_LUONG_THEO_QD.HO_DEM, e_col_Number.HO_DEM);
            v_htb.Add(RPT_LUONG_THEO_QD.MA_QD_GIUA_KI_I, e_col_Number.MA_QD_GIUA_KI_I);
            v_htb.Add(RPT_LUONG_THEO_QD.MA_QD_GIUA_KI_II, e_col_Number.MA_QD_GIUA_KI_II);
            v_htb.Add(RPT_LUONG_THEO_QD.LUONG_DAU_KY_II, e_col_Number.LUONG_DAU_KY_II);
            v_htb.Add(RPT_LUONG_THEO_QD.LUONG_DAU_KY_I, e_col_Number.LUONG_DAU_KY_I);
            v_htb.Add(RPT_LUONG_THEO_QD.LUONG_GIUA_KY_II, e_col_Number.LUONG_GIUA_KY_II);
            v_htb.Add(RPT_LUONG_THEO_QD.TRANG_THAI_LD_HIEN_TAI, e_col_Number.TRANG_THAI_LD_HIEN_TAI);
            v_htb.Add(RPT_LUONG_THEO_QD.MA_QD_DAU_KY_II, e_col_Number.MA_QD_DAU_KY_II);
            v_htb.Add(RPT_LUONG_THEO_QD.NGAY_AP_DUNG_KY_I, e_col_Number.NGAY_AP_DUNG_KY_I);
            v_htb.Add(RPT_LUONG_THEO_QD.MA_CV, e_col_Number.MA_CV);
            v_htb.Add(RPT_LUONG_THEO_QD.NGAY_AP_DUNG_GIUA_KY_I, e_col_Number.NGAY_AP_DUNG_GIUA_KY_I);
            v_htb.Add(RPT_LUONG_THEO_QD.LUONG_GIUA_KY_I, e_col_Number.LUONG_GIUA_KY_I);

            ITransferDataRow v_obj_trans = new CC1TransferDataRow(i_fg, v_htb, m_ds.RPT_LUONG_THEO_QD.NewRow());
            return v_obj_trans;
        }
        private void load_data_2_grid() {
            //Lay ngay dau nam
            string v_str_dau_nam = "01/01/"+ m_dat_nam.Value.Year;
            DateTime v_dat = CIPConvert.ToDatetime(v_str_dau_nam);

            m_ds = new DS_RPT_LUONG_THEO_QD();
            m_us.FillDatasetByProc(m_ds, v_dat, CAppContext_201.getCurrentIDPhapnhan());
            m_fg.Redraw = false;
            CGridUtils.Dataset2C1Grid(m_ds, m_fg, m_obj_trans);
            m_fg.Redraw = true;

            wrap_text_all_cells();
            CGridUtils.MakeSoTT(0, m_fg);
        }
        private void grid2us_object(US_RPT_LUONG_THEO_QD i_us
            , int i_grid_row) {
            DataRow v_dr;
            v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            m_obj_trans.GridRow2DataRow(i_grid_row, v_dr);
            i_us.DataRow2Me(v_dr);
        }


        private void us_object2grid(US_RPT_LUONG_THEO_QD i_us
            , int i_grid_row) {
            DataRow v_dr = (DataRow)m_fg.Rows[i_grid_row].UserData;
            i_us.Me2DataRow(v_dr);
            m_obj_trans.DataRow2GridRow(v_dr, i_grid_row);
        }


        private void insert_rpt_luong_theo_qd() {
            //	f800_BC_LUONG_THEO_QD_DE v_fDE = new  f800_BC_LUONG_THEO_QD_DE();								
            //	v_fDE.display();
            load_data_2_grid();
        }

        private void update_rpt_luong_theo_qd() {
            if(!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if(!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            grid2us_object(m_us, m_fg.Row);
            //	f800_BC_LUONG_THEO_QD_DE v_fDE = new f800_BC_LUONG_THEO_QD_DE();
            //	v_fDE.display(m_us);
            load_data_2_grid();
        }

        private void delete_rpt_luong_theo_qd() {
            if(!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if(!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            if(BaseMessages.askUser_DataCouldBeDeleted(8) != BaseMessages.IsDataCouldBeDeleted.CouldBeDeleted) return;
            US_RPT_LUONG_THEO_QD v_us = new US_RPT_LUONG_THEO_QD();
            grid2us_object(v_us, m_fg.Row);
            try {
                v_us.BeginTransaction();
                v_us.Delete();
                v_us.CommitTransaction();
                m_fg.Rows.Remove(m_fg.Row);
            }
            catch(Exception v_e) {
                v_us.Rollback();
                CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e,
                    new CDBClientDBExceptionInterpret());
                v_objErrHandler.showErrorMessage();
            }
        }
        private void view_rpt_luong_theo_qd() {
            if(!CGridUtils.IsThere_Any_NonFixed_Row(m_fg)) return;
            if(!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row)) return;
            grid2us_object(m_us, m_fg.Row);
            //	f800_BC_LUONG_THEO_QD_DE v_fDE = new f800_BC_LUONG_THEO_QD_DE();			
            //	v_fDE.display(m_us);
        }
        private void auto_complete_text() {
            m_txt_tim_kiem.AutoCompleteCustomSource = LoadAutoComplete(m_ds);
            m_txt_tim_kiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            m_txt_tim_kiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void set_define_events() {
            m_cmd_exit.Click += new EventHandler(m_cmd_exit_Click);
            m_cmd_insert.Click += new EventHandler(m_cmd_insert_Click);
            m_cmd_update.Click += new EventHandler(m_cmd_update_Click);
            m_cmd_delete.Click += new EventHandler(m_cmd_delete_Click);
            m_cmd_view.Click += new EventHandler(m_cmd_view_Click);
            //m_dat_nam.ValueChanged += new EventHandler(m_dat_nam_ValueChanged);
            m_cmd_ok.Click += new EventHandler(m_cmd_ok_Click);
            m_cmd_tim_kiem.Click += m_cmd_tim_kiem_Click;
            m_txt_tim_kiem.TextChanged += m_txt_tim_kiem_TextChanged;
            m_txt_tim_kiem.KeyUp += m_txt_tim_kiem_KeyUp;
        }



        private void tim_kiem(DS_RPT_LUONG_THEO_QD ip_ds, string ip_search_text) {
            DataView v_dv = new DataView(ip_ds.RPT_LUONG_THEO_QD);
            v_dv.RowFilter = string.Format("MA_NV like '%{0}%' or " +
                                            //"NGAY_AP_DUNG_KY_II like '%{0}%' or " +
                                            "MA_QD_DAU_KY_I like '%{0}%' or " +
                                            //"NGAY_AP_DUNG_GIUA_KY_II like '%{0}%' or " +
                                            //"LUONG_CUOI_KY_I = '{0}' or " +
                                            "TEN like '%{0}%' or " +
                                            //"LUONG_CUOI_KY_II = '{0}' or " +
                                            "MA_DON_VI like '%{0}%' or " +
                                            "HO_DEM like '%{0}%' or " +
                                            "MA_QD_GIUA_KI_I like '%{0}%' or " +
                                            "MA_QD_GIUA_KI_II like '%{0}%' or " +
                                            //"LUONG_DAU_KY_II like '%{0}%' or " +
                                            //"LUONG_DAU_KY_I like '%{0}%' or " +
                                            //"LUONG_GIUA_KY_II like '%{0}%' or " +
                                            "TRANG_THAI_LD_HIEN_TAI like '%{0}%' or " +
                                            "MA_QD_DAU_KY_II like '%{0}%' or " +
                                            "HO_DEM + ' '+ TEN like '%{0}%' or " +
                                            //"NGAY_AP_DUNG_KY_I like '%{0}%' or " +
                                            "MA_CV like '%{0}%'", ip_search_text);
            //"NGAY_AP_DUNG_GIUA_KY_I like '%{0}%'", ip_search_text);
            //"LUONG_GIUA_KY_I like '%{0}%'", ip_search_text);
            DataTable v_dt = v_dv.ToTable();
            DataSet v_ds =  new DataSet();
            v_ds.Tables.Add(v_dt);

            CGridUtils.Dataset2C1Grid(v_ds, m_fg, m_obj_trans);
            m_fg.Redraw = true;

            format_fixed_rows_in_grid();
            CGridUtils.MakeSoTT(0, m_fg);
        }

        #endregion

        //
        //
        //		EVENT HANLDERS
        //


        void m_txt_tim_kiem_KeyUp(object sender, KeyEventArgs e) {
            try {
                if(e.KeyCode == Keys.Enter)
                    tim_kiem(m_ds, m_txt_tim_kiem.Text);
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }


        private void m_txt_tim_kiem_TextChanged(object sender, EventArgs e) {
            try {
                //tim_kiem(m_ds, m_txt_tim_kiem.Text);
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        private void m_cmd_tim_kiem_Click(object sender, EventArgs e) {
            try {
                tim_kiem(m_ds, m_txt_tim_kiem.Text);
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_ok_Click(object sender, EventArgs e) {
            try {
                load_data_2_grid();
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        //private void m_dat_nam_ValueChanged(object sender, EventArgs e) {
        //    try {
        //        load_data_2_grid();
        //    }
        //    catch(Exception v_e) {
        //        CSystemLog_301.ExceptionHandle(v_e);
        //    }
        //}
        private void f800_BC_LUONG_THEO_QD_Load(object sender, System.EventArgs e) {
            try {
                set_initial_form_load();
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }

        }

        private void m_cmd_exit_Click(object sender, EventArgs e) {
            try {
                this.Close();
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_insert_Click(object sender, EventArgs e) {
            try {
                insert_rpt_luong_theo_qd();
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_update_Click(object sender, EventArgs e) {
            try {
                update_rpt_luong_theo_qd();
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_delete_Click(object sender, EventArgs e) {
            try {
                delete_rpt_luong_theo_qd();
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_view_Click(object sender, EventArgs e) {
            try {
                view_rpt_luong_theo_qd();
            }
            catch(Exception v_e) {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

    }
}


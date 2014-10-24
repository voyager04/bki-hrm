using BKI_HRM.DS;
using BKI_HRM.HelperDucVT;
using BKI_HRM.US;
using BKI_HRM.DS.CDBNames;
using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPSystemAdmin;
using System;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace BKI_HRM.NghiepVu
{
    public partial class f301_V_GD_LUONG_THEO_QD_DE : Form
    {
        #region Members
        DataEntryFormMode m_e_form_mode;

        private US_DM_QUYET_DINH m_us_dm_quyet_dinh;
        private DS_DM_QUYET_DINH m_ds_dm_quyet_dinh;

        private US_V_GD_LUONG_THEO_QD m_us_v_gd_luong_theo_qd;
        private DS_GD_LUONG_THEO_QD m_ds_gd_luong_theo_qd;

        DataEntryFileMode m_e_file_mode;

        private string m_str_domain = ConfigurationSettings.AppSettings["DOMAIN"];
        private string m_str_directory_to = ConfigurationSettings.AppSettings["DESTINATION_NAME"];
        private string m_str_user_name = ConfigurationSettings.AppSettings["USERNAME_SHARE"];
        private string m_str_password = ConfigurationSettings.AppSettings["PASSWORD_SHARE"];

        private string m_str_previous_link;
        #endregion

        #region Public Interfaces
        public f301_V_GD_LUONG_THEO_QD_DE()
        {
            InitializeComponent();

            // Initialize 
            init();

            // Format form
            CControlFormat.setFormStyle(this);
        }

        public void display_for_insert()
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_e_file_mode = DataEntryFileMode.UploadFile;
            this.ShowDialog();
        }

        public void display_for_update(US_V_GD_LUONG_THEO_QD m_us)
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_e_file_mode = DataEntryFileMode.EditFile;

            us_2_form(m_us);
            this.ShowDialog();
        }
        #endregion

        #region Private Methods

        #region Init methods

        private void init()
        {
            init_comps();
            init_events();
            init_members();
        }

        private void init_events()
        {
            m_cmd_save.Click += m_cmd_save_Click;
            m_cmd_exit.Click += m_cmd_exit_Click;
            m_cmd_refresh.Click += m_cmd_refresh_Click;

            m_cmd_dinh_kem.Click += m_cmd_dinh_kem_Click;
            m_cmd_bo_dinh_kem.Click += m_cmd_bo_dinh_kem_Click;
            m_cmd_xem_tai_lieu.Click += m_cmd_xem_tai_lieu_Click;

        }

        private void init_comps()
        {
            // m_txt_nhan_vien
            CUtils.load_autocmp_nhan_su(m_txt_nhan_vien);

            // m_cbo_loai_quyet_dinh
            CUtils.load_datasource_loai_quyet_dinh(m_cbo_loai_quyet_dinh, 1);

            // m_txt_ky
            CUtils.load_autocmp_ky(m_txt_ky);
        }

        private void init_members()
        {
            m_us_dm_quyet_dinh = new US_DM_QUYET_DINH();
            m_ds_dm_quyet_dinh = new DS_DM_QUYET_DINH();

            m_us_v_gd_luong_theo_qd = new US_V_GD_LUONG_THEO_QD();
            m_ds_gd_luong_theo_qd = new DS_GD_LUONG_THEO_QD();
        }

        #endregion

        #region Load data to us methods

        private void load_data_2_us_qd()
        {
            m_us_dm_quyet_dinh.strMA_QUYET_DINH = m_txt_ma_quyet_dinh.Text;
            m_us_dm_quyet_dinh.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
            m_us_dm_quyet_dinh.dcID_LOAI_QD = CIPConvert.ToDecimal(m_cbo_loai_quyet_dinh.SelectedValue);

            m_us_dm_quyet_dinh.datNGAY_KY = m_dat_ngay_ky.Value;
            m_us_dm_quyet_dinh.datNGAY_CO_HIEU_LUC = m_dat_ngay_co_hieu_luc_qd.Value;
            if (m_dat_ngay_het_hieu_luc_qd.Checked)
                m_us_dm_quyet_dinh.datNGAY_HET_HIEU_LUC = m_dat_ngay_het_hieu_luc_qd.Value;
            else
                m_us_dm_quyet_dinh.SetNGAY_HET_HIEU_LUCNull();
            m_us_dm_quyet_dinh.strLINK = m_lbl_file_name.Text;
        }

        private void load_data_2_us_gd_luong_theo_qd()
        {
            m_us_v_gd_luong_theo_qd.dcLUONG = m_num_luong.Value;
            m_us_v_gd_luong_theo_qd.datNGAY_AP_DUNG = m_dat_ngay_ap_dung.Value.Date;
            m_us_v_gd_luong_theo_qd.dcTHANG_AP_DUNG = m_dat_ngay_ap_dung.Value.Month;
            m_us_v_gd_luong_theo_qd.dcNAM_AP_DUNG = m_dat_ngay_ap_dung.Value.Year;
            m_us_v_gd_luong_theo_qd.strLUONG_HIEN_TAI_YN = m_ckb_luong_hien_tai.Checked ? "Y" : "N";

            m_us_v_gd_luong_theo_qd.strMA_KY = m_txt_ky.Text;
            m_us_v_gd_luong_theo_qd.strMA_NV = get_ma_nv_from(m_txt_nhan_vien.Text, '-');


            m_us_v_gd_luong_theo_qd.strMA_QD = m_txt_ma_quyet_dinh.Text;

            m_us_v_gd_luong_theo_qd.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();
        }

        #endregion

        #region Load data to form methods
        /// <summary>
        /// Dùng cho việc Update. Load dữ liệu lên form + m_us tương ứng (thường là load ID cho us object)
        /// </summary>
        /// <param name="ip_us">US dùng để load dữ liệu lên form + m_us</param>
        private void us_2_form(US_V_GD_LUONG_THEO_QD ip_us)
        {
            // To group box Quyết định
            m_us_dm_quyet_dinh.dcID = ip_us.dcID_QUYET_DINH > 0 ? ip_us.dcID_QUYET_DINH : -1;

            m_txt_ma_quyet_dinh.Text = ip_us.strMA_QD;
            m_dat_ngay_ky.Value = ip_us.datNGAY_KY;
            m_dat_ngay_het_hieu_luc_qd.Value = ip_us.datNGAY_CO_HIEU_LUC;

            DateTime v_dat = ip_us.datNGAY_HET_HIEU_LUC;
            DateTime v_null_dat = new DateTime(1900, 1, 1, 0, 0, 0); // Nếu giá trị trong DataBase là NULL thì giá trị DateTime sẽ bằng 1/1/1900 12:00:00 AM
            if (v_dat == v_null_dat)
            {
                m_dat_ngay_het_hieu_luc_qd.Checked = false;
                m_dat_ngay_het_hieu_luc_qd.Value = DateTime.Today;
            }
            else
            {
                m_dat_ngay_het_hieu_luc_qd.Checked = true;
                m_dat_ngay_het_hieu_luc_qd.Value = v_dat;
            }
            
            m_cbo_loai_quyet_dinh.SelectedValue = ip_us.dcID_LOAI_QD;
            m_txt_noi_dung.Text = ip_us.strNOI_DUNG;
            // Tài liệu đính kèm
            m_ofd_chon_file.FileName = ip_us.strLINK;

            // To group box Lương
            m_us_v_gd_luong_theo_qd.dcID = ip_us.dcID > 0 ? ip_us.dcID : -1;

            m_txt_nhan_vien.Text = ip_us.strHO_DEM + " - " + ip_us.strTEN + " - " + ip_us.strMA_NV;
            m_txt_ky.Text = ip_us.strMA_KY;
            m_num_luong.Value = ip_us.dcLUONG;
            m_dat_ngay_ap_dung.Value = ip_us.datNGAY_AP_DUNG;
            m_ckb_luong_hien_tai.Checked = ip_us.strLUONG_HIEN_TAI_YN == "Y" ? true : false;
        }

        #endregion

        #region Validate Data
        /// <summary>
        /// Kiểm tra tính hợp lý của dữ liệu trên form
        /// </summary>
        /// <returns>Nếu có vấn đề trả lại false, không có vấn đề trả lại true</returns>
        private bool validate_data()
        {
            if (!validate_txt_ma_quyet_dinh())
                return false;

            if (!validate_txt_nhan_vien())
                return false;

            if (!validate_txt_ma_ky())
                return false;

            if (!validate_luong_hien_tai())
                return false;

            return true;
        }

        private bool validate_txt_ma_quyet_dinh()
        {
            try
            {
                if (m_txt_ma_quyet_dinh.Text == "")
                    throw new Exception("Không được để trống Mã quyết định");

                if (m_e_form_mode != DataEntryFormMode.UpdateDataState)
                {
                    m_us_dm_quyet_dinh.FillDataset(m_ds_dm_quyet_dinh);

                    DataRow[] v_drs = m_ds_dm_quyet_dinh.DM_QUYET_DINH.Select(String.Format("MA_QUYET_DINH = '{0}'", m_txt_ma_quyet_dinh.Text));

                    if (v_drs.Length > 0)
                        throw new Exception("Mã quyết định đã tồn tại");
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
                m_txt_ma_quyet_dinh.Focus();
                return false;
            }

            return true;
        }

        private bool validate_txt_nhan_vien()
        {
            try
            {
                if (m_txt_nhan_vien.Text == "")
                    throw new Exception("Không được để trống ô nhân viên");
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
                m_txt_nhan_vien.Focus();
                return false;
            }

            return true;
        }

        private bool validate_txt_ma_ky()
        {
            try
            {
                if (m_txt_ky.Text == "")
                    throw new Exception("Không được để trống ô kỳ");
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
                m_txt_ky.Focus();
                return false;
            }

            return true;
        }

        private bool validate_dat()
        {
            try
            {
                if (m_dat_ngay_het_hieu_luc_qd.Checked)
                {
                    if (m_dat_ngay_het_hieu_luc_qd.Value < m_dat_ngay_co_hieu_luc_qd.Value)
                        throw new Exception("Ngày hết hiệu lực không được nhỏ hơn ngày có hiệu lực");
                    if (m_dat_ngay_het_hieu_luc_qd.Value < m_dat_ngay_ap_dung.Value)
                        throw new Exception("Ngày hết hiệu lực không được nhỏ hơn ngày áp dụng");
                    if (m_dat_ngay_co_hieu_luc_qd.Value < m_dat_ngay_ap_dung.Value)
                        throw new Exception("Ngày có hiệu lực không được nhỏ hơn ngày áp dụng");
                }
                    
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
                return false;
            }

            return true;
        }

        private bool validate_luong_hien_tai()
        {
            try
            {
                // Trong trạng thái update
                // Nếu Check vào ô luong_hien_tai và tồn tại lương hiện tại rồi thì thông báo không cho phép check vào ô luong_hien_tai
                if (m_e_form_mode == DataEntryFormMode.UpdateDataState)
                {
                    if (m_ckb_luong_hien_tai.Checked)
                    {
                        if (m_us_v_gd_luong_theo_qd.is_exist_luong_hien_tai(m_us_v_gd_luong_theo_qd.dcID, get_ma_nv_from(m_txt_nhan_vien.Text, '-'), CAppContext_201.getCurrentIDPhapnhan()))
                            throw new Exception("Đã tồn tại lương hiện tại");
                    }
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
                return false;
            }

            return true;
        }
        #endregion

        #region Save Event methods

        /// <summary>
        /// Insert/Update vào Table DM_QUYET_DINH trước, nếu thành công thì tiếp tục với GD_LUONG_THEO_QD.
        /// Nếu GD_LUONG_THEO_QD gặp exception thì Rollback() bản ghi DM_QUYET_DINH đã Insert/Update trước đó.
        /// </summary>
        /// <returns>Trả về True nếu thành công</returns>
        private bool save_data()
        {
            US_GD_QUYET_DINH_PHAP_NHAN v_us_qd_pn;

            try
            {
                #region Validate Data
                // Nếu validate có vấn đề
                if (!validate_data())
                {
                    return false;
                }
                #endregion

                // Chưa hiểu rõ về xử lý file lắm
                #region Xử lý file đính kèm
                // Xử lý file đính kèm
                switch (m_e_file_mode)
                {
                    case DataEntryFileMode.UploadFile:
                        // Kiểm tra file đã tồn tại trên server hay chưa
                        if (FileExplorer.IsExistedFile(m_str_directory_to + FileExplorer.fileName))
                        {
                            BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                            return false;
                        }

                        // Nếu đã chọn file 
                        if (m_lbl_file_name.Text != "")
                        {
                            // Upload server có sử dụng user và pass
                            if (m_str_user_name != "")
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to, m_str_user_name, m_str_password);
                            // Upload không sử dụng user và pass
                            else
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to);
                        }
                        break;
                    case DataEntryFileMode.EditFile:
                        // Nếu ko up lên file mới sẽ bỏ qua bước này
                        if (m_str_previous_link != m_lbl_file_name.Text && m_lbl_file_name.Text != "")
                        {
                            // Kiểm tra file vừa upload đã tồn tại hay chưa
                            if (FileExplorer.IsExistedFile(m_str_directory_to + FileExplorer.fileName))
                            {
                                BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                                return false;
                            }

                            // Xóa file cũ
                            if (FileExplorer.IsExistedFile(m_str_directory_to + m_str_previous_link))
                                FileExplorer.DeleteFile(m_str_directory_to + m_str_previous_link);

                            // Upload file mới lên
                            if (m_str_user_name != "")
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to, m_str_user_name, m_str_password);
                            else
                                FileExplorer.UploadFile(m_str_domain, m_str_directory_to);
                        }
                        break;
                    case DataEntryFileMode.DeleteFile:
                        // Kiểm tra file có tồn tại hay không
                        if (FileExplorer.IsExistedFile(m_str_directory_to + m_str_previous_link) == false)
                        {
                            BaseMessages.MsgBox_Infor("File không tồn tại!");
                            return false;
                        }
                        FileExplorer.DeleteFile(m_str_directory_to + m_str_previous_link);
                        break;
                }
                #endregion

                m_us_v_gd_luong_theo_qd.BeginTransaction();

                #region Prepare for update

                // Bởi vì ở đây ta cần Update bảng DM_QUYET_DINH nhưng mà nó lại relate với GD_LUONG_THEO_QD theo MA_QD chứ không phải ID
                // Do đó ở đây ta cần Update cột MA_QD trong GD_LUONG_THEO_QD thành NULL để có thể Update ở DM_QUYET_DINH

                if (m_e_form_mode == DataEntryFormMode.UpdateDataState)
                {
                    load_data_2_us_gd_luong_theo_qd();
                    m_us_v_gd_luong_theo_qd.strMA_QD = String.Empty;

                    m_us_v_gd_luong_theo_qd.Update();
                }

                #endregion

                #region Save Quyết định
                load_data_2_us_qd();

                // Commit trans thông qua US m_us_gd_luong_theo_qd.
                // Việc này giúp Rollback() - ngừng connection tới DB nếu xảy ra lỗi.
                m_us_dm_quyet_dinh.UseTransOfUSObject(m_us_v_gd_luong_theo_qd);

                switch (m_e_form_mode)
                {
                    case DataEntryFormMode.InsertDataState:
                        m_us_dm_quyet_dinh.Insert(); // Trực tiếp thêm vào DataBase thành công ở bước này.

                        // throw new Exception("DucVT: DEBUG");
                        // Đã Test OK. Nếu giả sử ở bước này xảy ra lỗi thì sẽ catch exception gọi RollBack() và 
                        // Xóa đi bản ghi vừa được m_us_dm_quyet_dinh.Insert() khỏi DataBase ở dòng trên đây.

                        #region Save Gd quyết định, pháp nhân
                        v_us_qd_pn = new US_GD_QUYET_DINH_PHAP_NHAN();
                        v_us_qd_pn.dcID_PHAP_NHAN = CAppContext_201.getCurrentIDPhapnhan();

                        // Lấy Id của bản ghi quyết định vừa được Insert ở trên vào Table DM_QUYET_DINH
                        v_us_qd_pn.dcID_QUYET_DINH = CUtils.get_current_auto_id("DM_QUYET_DINH");

                        // Commit trans thông qua US m_us_gd_luong_theo_qd.
                        v_us_qd_pn.UseTransOfUSObject(m_us_v_gd_luong_theo_qd);

                        // Insert gd quyết định, pháp nhân
                        v_us_qd_pn.Insert();
                        #endregion

                        break;
                    case DataEntryFormMode.SelectDataState:
                        break;
                    case DataEntryFormMode.UpdateDataState:
                        m_us_dm_quyet_dinh.Update();
                        break;
                    case DataEntryFormMode.ViewDataState:
                        break;
                    default:
                        break;
                }

                #endregion

                #region Save Gd lương theo quyết định
                load_data_2_us_gd_luong_theo_qd();

                switch (m_e_form_mode)
                {
                    case DataEntryFormMode.InsertDataState:
                        m_us_v_gd_luong_theo_qd.Insert();
                        // Refresh mới lại form để insert bản ghi mới
                        CUtils.show_success_message("Thêm thành công Lương theo quyết định mới");
                        reset_form();
                        break;
                    case DataEntryFormMode.SelectDataState:
                        break;
                    case DataEntryFormMode.UpdateDataState:
                        m_us_v_gd_luong_theo_qd.Update();
                        this.Close();
                        break;
                    case DataEntryFormMode.ViewDataState:
                        break;
                    default:
                        break;
                }

                #endregion

                m_us_v_gd_luong_theo_qd.CommitTransaction();

                if (m_e_form_mode == DataEntryFormMode.UpdateDataState)
                    this.Close();
            }
            catch (Exception v_e)
            {
                if (m_us_v_gd_luong_theo_qd.is_having_transaction())
                    m_us_v_gd_luong_theo_qd.Rollback();

                CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e,
                    new CDBClientDBExceptionInterpret());
                v_objErrHandler.showErrorMessage();
                return false;
            }

            return true;
        }

        #endregion

        #region File methods
        /// <summary>
        /// Chạy file với đường dẫn lưu trong m_ofd
        /// </summary>
        private void execute_file()
        {
            CUtils.execute_file(m_ofd_chon_file.FileName);
        }

        /// <summary>
        /// Chọn file
        /// </summary>
        private void select_file()
        {
            FileExplorer.SelectFile(m_ofd_chon_file, m_str_previous_link);
            m_lbl_file_name.Text = FileExplorer.fileName;
        }

        /// <summary>
        /// Không chọn file nữa
        /// </summary>
        private void remove_file()
        {
            m_e_file_mode = DataEntryFileMode.DeleteFile;
            m_str_previous_link = m_lbl_file_name.Text;
            m_lbl_file_name.Text = String.Empty;
        }

        #endregion

        #region Util methods
        /// <summary>
        /// Tách lấy mã nhân viên từ xâu text với cấu trúc. Ví dụ: Value - ... - Mã nhân viên. 
        /// Các giá trị ngăn bởi 1 ký tự.
        /// </summary>
        /// <param name="ip_text">Đoạn text</param>
        /// <param name="ip_split_char">Ký tự ngăn cách giữa các giá trị</param>
        /// <returns>Mã nhân viên trong xâu ký tự</returns>
        private string get_ma_nv_from(string ip_text, char ip_split_char)
        {
            // Split text 2 string[]
            char[] v_split_char = { ip_split_char };
            string[] v_strings = ip_text.Split(v_split_char);

            // Lấy String cuối cùng của string[]
            return v_strings[v_strings.Length - 1].Trim();
        }

        /// <summary>
        /// Setup lại form để insert bản ghi mới
        /// </summary>
        private void reset_form()
        {
            // Reset group quyet dinh
            m_txt_ma_quyet_dinh.Text = "";
            m_txt_noi_dung.Text = "";
            m_cbo_loai_quyet_dinh.SelectedIndex = 0;
            m_dat_ngay_ky.Value = DateTime.Today;
            m_dat_ngay_co_hieu_luc_qd.Value = DateTime.Today;
            m_dat_ngay_het_hieu_luc_qd.Checked = false;
            m_dat_ngay_het_hieu_luc_qd.Value = DateTime.Today;
            m_lbl_file_name.Text = "";

            // Reset group luong
            m_txt_nhan_vien.Text = "";
            m_txt_ky.Text = "";
            m_num_luong.Value = 0;
            m_ckb_luong_hien_tai.Checked = false;
            m_dat_ngay_ap_dung.Value = DateTime.Today;

            m_txt_ma_quyet_dinh.Focus();
        }
        #endregion

        #endregion

        #region Override methods
        /// <summary>
        /// Bắt sự kiện nhấn Escapse và thoát form
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
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
        private void m_cmd_save_Click(object sender, EventArgs e)
        {
            // Đã try catch trong hàm nên ở đây không cần nữa.
            save_data();
        }

        private void m_cmd_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmd_refresh_Click(object sender, EventArgs e)
        {
            reset_form();
        }
        
        private void m_cmd_xem_tai_lieu_Click(object sender, EventArgs e)
        {
            try
            {
                execute_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_dinh_kem_Click(object sender, EventArgs e)
        {
            try
            {
                select_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

        private void m_cmd_bo_dinh_kem_Click(object sender, EventArgs e)
        {
            try
            {
                remove_file();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }
        #endregion
    }
}

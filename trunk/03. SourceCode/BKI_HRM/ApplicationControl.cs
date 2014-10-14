using System;
using System.Diagnostics;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPSystemAdmin;
using IP.Core.IPBusinessService;
using IP.Core.IPUserService;
using BKI_HRM;
using System.IO;



namespace BKI_HRM
{
	#region Nhiệm vụ của Class
	//*********************************************************************************
	//*  Là khởi động và điều khiển dăng nhập mới vào  Hệ thống
	//*  - hiện thị form login
	//*  - nếu OK thì tạo context và hiện thị form main, User không muốn vào thì thoát ra
	//*  - nếu trở lại từ main theo kiểu login mới thì lại hiện thị form login
	//*  - nếu trở lại từ main theo kiểu "exit from system" thì thoát
	//*********************************************************************************
#endregion
	public class ApplicationControl
	{
        [STAThread]
		static void Main(){

            try
            {



                IP.Core.IPSystemAdmin.f101_Dang_Nhap v_frm_login_form = new f101_Dang_Nhap();
                US_HT_NGUOI_SU_DUNG v_us_user = new US_HT_NGUOI_SU_DUNG();
                decimal v_dc_id_phap_nhan = CAppContext_201.getCurrentIDPhapnhan();
                CLoginInformation_302 v_obj_login_info = new CLoginInformation_302(v_us_user, v_dc_id_phap_nhan);
                DialogResult v_login_result = DialogResult.Cancel;
                bool v_UserWant2ExitFromSystem = false;
                IPConstants.HowUserWantTo_Exit_MainForm v_exitmode = IPConstants.HowUserWantTo_Exit_MainForm.ExitFromSystem;
                //load user - pass lần đăng nhập gần nhất 
                
                string v_str_path = Path.GetDirectoryName(Application.ExecutablePath) + "\\login.txt";
                if (!File.Exists(v_str_path))
                {
                    System.IO.StreamWriter file = new StreamWriter(v_str_path);
//                     file.WriteLine("");
//                     file.WriteLine("");
                    file.Close();
                }
                System.IO.StreamReader file_read = new System.IO.StreamReader(v_str_path);
                string v_str_user = "",
                    v_str_pass = "";
                v_str_user = file_read.ReadLine();
                v_str_pass = file_read.ReadLine();
                if (v_str_user == null || v_str_pass == null)
                {
                    v_str_user = "";
                    v_str_pass = "";
                }
                if (v_str_pass != "")
                {
                    v_str_pass = CIPConvert.Deciphering(v_str_pass);
                }
                file_read.Close();
                // Login lan 1
                v_frm_login_form.displayLogin(v_str_user, v_str_pass, ref v_obj_login_info, ref v_login_result);
                
                if (v_login_result == DialogResult.Cancel)
                {
                    v_frm_login_form.Dispose();
                    v_frm_login_form.Close();
                    return;
                }
                v_frm_login_form.Dispose();
                while (!v_UserWant2ExitFromSystem)
                {

                    CAppContext_201.InitializeContext(v_obj_login_info);
                    CAppContext_201.LoadDecentralizationByUserLogin();
                   // string v_str_path = Path.GetDirectoryName(Application.ExecutablePath) + "\\login.txt";
                    System.IO.StreamWriter file_write = new System.IO.StreamWriter(v_str_path);
                    file_write.WriteLine(v_obj_login_info.m_us_user.strTEN_TRUY_CAP);
                    file_write.WriteLine(v_obj_login_info.m_us_user.strMAT_KHAU);
                    file_write.Close();
	                //v_obj_login_info.m_us_user.str
                    f002_main_form v_frm_main = new f002_main_form();
                    v_frm_main.display(ref v_exitmode);
                    v_frm_main.Dispose();
                    // sau main form hiện thì login hoặc thóat
                    switch (v_exitmode)
                    {
                        case IPConstants.HowUserWantTo_Exit_MainForm.ExitFromSystem:
                            v_UserWant2ExitFromSystem = true;
                            break;
                        case IPConstants.HowUserWantTo_Exit_MainForm.Login_As_DifferentUser:
                            // vào bằng user khác ( hoặc nhóm khác)
                            file_read = new System.IO.StreamReader(v_str_path);
               
                            v_str_user = file_read.ReadLine();
                            v_str_pass = file_read.ReadLine();
                            if (v_str_user == null || v_str_pass == null)
                            {
                                v_str_user = "";
                                v_str_pass = "";
                            }
                            if (v_str_pass != "")
                            {
                                v_str_pass = CIPConvert.Deciphering(v_str_pass);
                            }
                            file_read.Close();
                            v_frm_login_form = new f101_Dang_Nhap();
                            v_frm_login_form.displayLogin(v_str_user, v_str_pass, ref v_obj_login_info, ref v_login_result);
                            v_frm_login_form.Dispose();
                            break;
                        default:
                            // should never happens
                            Debug.Assert(false);
                            break;
                    }

                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
		}		
	}
}

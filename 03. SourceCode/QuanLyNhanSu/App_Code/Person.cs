using System.Collections.Generic;
using System.Web;
using BKI_HRM.US;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using BKI_HRM.DS;
using IP.Core.IPUserService;
/// <summary>
/// Summary description for Employee
/// </summary>
/// 
namespace IP.Core.WinFormControls
{
    public class Person
    {
        public int ID;
        public string Name;

        public Person()
        {
        }

        public static string get_chuc_nang()
        {
           
            return CIPConvert.ToStr(HttpContext.Current.Request.Url.PathAndQuery).Replace("/DatPhongHop/", "");
        }
        public static string get_chuc_nang_without_query()
        {
            return CIPConvert.ToStr(HttpContext.Current.Request.Url.AbsolutePath).Replace("/DatPhongHop/", "");
        }

        public static decimal get_id_user()
        {
            object v_obj_id_user_login = HttpContext.Current.Session[SESSION.UserID];
            if (v_obj_id_user_login == null) return -2;//-2 tuc la khong tim thay id_user_login
            else
            {
                return CIPConvert.ToDecimal(v_obj_id_user_login);
            }

        }

        public static bool check_user_have_menu()
        {

            object v_obj_id_user_login = HttpContext.Current.Session[SESSION.UserID];
            if (v_obj_id_user_login == null) return false;
            else
            {
                if (get_chuc_nang_without_query() == "ChucNang/f200_tra_cuu_nghiep_vu.aspx") return true;


                if (CIPConvert.ToDecimal(v_obj_id_user_login) == -1)
                {
                    US_HT_USER_GROUP v_us_ht_user_group = new US_HT_USER_GROUP(ID_USER_GROUP.NHAN_DAN);
                    US_HT_QUYEN_GROUP v_us_ht_quyen_group = new US_HT_QUYEN_GROUP();
                    DS_HT_QUYEN_GROUP v_ds_ht_quyen_group = new DS_HT_QUYEN_GROUP();
                    v_us_ht_quyen_group.FillDataset(v_ds_ht_quyen_group, "where id_user_group = " + v_us_ht_user_group.dcID +
                        " and id_quyen in (select id from ht_chuc_nang where url_form like N'%" + get_chuc_nang() + "%' and trang_thai_yn ='Y' and hien_thi_yn='Y')");
                    if (v_ds_ht_quyen_group.HT_QUYEN_GROUP.Count < 1) return false;
                }
                else
                {
                    DS_HT_NGUOI_SU_DUNG v_ds_ht_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
                    US_HT_NGUOI_SU_DUNG v_us_ht_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
                    v_us_ht_nguoi_su_dung.FillDataset(v_ds_ht_nguoi_su_dung, "where id = " + v_obj_id_user_login.ToString());
                    if (v_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Count < 1) return false;
                    v_us_ht_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG(CIPConvert.ToDecimal(v_obj_id_user_login));
                    US_HT_USER_GROUP v_us_ht_user_group = new US_HT_USER_GROUP(v_us_ht_nguoi_su_dung.dcID_USER_GROUP);
                    US_HT_QUYEN_GROUP v_us_ht_quyen_group = new US_HT_QUYEN_GROUP();
                    DS_HT_QUYEN_GROUP v_ds_ht_quyen_group = new DS_HT_QUYEN_GROUP();
                    v_us_ht_quyen_group.FillDataset(v_ds_ht_quyen_group, "where id_user_group = " + v_us_ht_user_group.dcID +
                        " and id_quyen in (select id from ht_chuc_nang where url_form like N'%" + get_chuc_nang() + "%' and trang_thai_yn ='Y' and hien_thi_yn='Y')");
                    if (v_ds_ht_quyen_group.HT_QUYEN_GROUP.Count < 1)
                    {
                        v_ds_ht_quyen_group.Clear();
                        v_us_ht_quyen_group.FillDataset(v_ds_ht_quyen_group, "where id_user_group = " + v_us_ht_user_group.dcID +
                        " and id_quyen in (select id from ht_chuc_nang where url_form like N'%" + get_chuc_nang_without_query() + "%' and trang_thai_yn ='Y' and hien_thi_yn='Y')");
                        if (v_ds_ht_quyen_group.HT_QUYEN_GROUP.Count < 1) return false;
                    };
                }

            }
            return true;
        }


        public static string check_menu()
        {
            object v_obj_user_quyen = HttpContext.Current.Session[SESSION.UserQuyen];
            US_HT_CHUC_NANG v_us_ht_chuc_nang = new US_HT_CHUC_NANG(CIPConvert.ToDecimal(v_obj_user_quyen));
            return v_us_ht_chuc_nang.strTEN_CHUC_NANG;
        }
        public static string get_user_name()
        {
            object v_obj_username = HttpContext.Current.Session[SESSION.UserName];
            return v_obj_username.ToString();
        }

        public static bool check_session_valid()
        {
            return HttpContext.Current.Session[SESSION.UserID] != null;
        }

        public static bool Allow2DeleteData()
        {
            return HttpContext.Current.Session[SESSION.Allow2DeleteDataYN].ToString() == "Y";
        }
    }

}

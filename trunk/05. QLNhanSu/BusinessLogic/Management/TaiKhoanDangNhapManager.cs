using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Model;
using BusinessLogic.Utils;
using Framework.Extensions;
using SQLDataAccess;

namespace BusinessLogic.Management
{
    public class UserManager
    {
        #region Singleton
        private static UserManager _instance;
        private UserManager() { }
        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserManager();
                }
                return _instance;
            }
        }
        #endregion
        public string CapNhatThongTinCaNhan(string ip_str_user_name,
            string ip_str_ho,
            string ip_str_ten,
            string ip_str_ma_thanh_vien,
            string ip_str_detal_1,
            string ip_str_detal_2,
            bool ip_i_is_active)
        {
            string result = "CapNhatThongTinCaNhanThanhCong";
            UnitOfWork uow = new UnitOfWork();
            HT_USER v_ht_user = uow.Repository<HT_USER>().Query().Filter(x => x.USERNAME.Contains(ip_str_user_name)).FirstOrDefault();
            if (v_ht_user == null) return "CapNhatThongTinCaNhanThatBai";
            v_ht_user.HO = ip_str_ho;
            v_ht_user.TEN = ip_str_ten;
            v_ht_user.BHYT = ip_str_ma_thanh_vien;
            v_ht_user.CMND = ip_str_detal_1;
            v_ht_user.MSBN = ip_str_detal_2;
            v_ht_user.IS_ACTIVE = ip_i_is_active;
            v_ht_user.State = EDataState.Modified;
            uow.Repository<HT_USER>().Update(v_ht_user);
            uow.Save();
            return result;
        }
        public UserModel GetByUsername(string ip_username)
        {
            string v_str_user_name = ip_username.Replace("@topica.edu.vn", "").Replace("@gmail.com", "").Replace("@zinmed.com", "");
            if (ip_username.IsNullOrEmpty()) { return null; }
            UnitOfWork uow = new UnitOfWork();

            var v_entity_user = uow.Repository<HT_USER>().Query()
                .Filter(x => x.USERNAME == v_str_user_name + "@gmail.com" | x.USERNAME == v_str_user_name + "@topica.edu.vn" || x.USERNAME == v_str_user_name + "@zinmed.com")
                .FirstOrDefault();

            var v_bm_user = v_entity_user.CopyAs<UserModel>();
            return v_bm_user;
        }
        public Guid getGroupByIdUser(Guid ip_id_user)
        {
            UnitOfWork uow = new UnitOfWork();
            var v_id_user_group = uow.Repository<HT_USER>().Query()
                                    .Filter(x => x.ID == ip_id_user)
                                    .FirstOrDefault()
                                    .ID_USER_GROUP;
            return v_id_user_group;
        }

        public bool CheckRolesOfUser(string ip_str_user_name, string ip_str_controller_name, string ip_str_activity_name)
        {
            UnitOfWork uow = new UnitOfWork();
            HT_USER v_ht_user = uow.Repository<HT_USER>().Query().Filter(x => x.USERNAME.Contains(ip_str_user_name)).FirstOrDefault();
            if (v_ht_user == null) return false;
            IEnumerable<HT_PHAN_QUYEN_CHUC_NANG> v_ht_quyen = uow.Repository<HT_PHAN_QUYEN_CHUC_NANG>().Query()
                .Filter(x => x.HT_USER_GROUP_WEB.ID == v_ht_user.ID_USER_GROUP
                    && x.HT_CONTROLLER.ACTIVITY_NAME == ip_str_activity_name
                    && x.HT_CONTROLLER.CONTROLLER_NAME == ip_str_controller_name)
                    .Get();
            if (v_ht_quyen.Count() > 0) return true;
            return false;
        }
        public static bool check_is_not_topica_mail(string ip_str_mail)
        {
            // Tìm account theo email
            UnitOfWork uow = new UnitOfWork();
            var v_lst_user = uow.Repository<HT_USER>().Query().Filter(x => x.USERNAME == ip_str_mail).Get();
            if (v_lst_user.Any()) // Nếu account đã đăng ký
            {
                // Nếu là email topica
                if (ip_str_mail != "91apple.nguyen@gmail.com"
                    && ip_str_mail != "tr.anh1234@gmail.com"
                    //&& ip_str_mail != "hoangnh@zinmed.com"
                    //&& ip_str_mail != "hoangnh2412@gmail.com"
                    && !ip_str_mail.EndsWith("@topica.edu.vn")
                    && !ip_str_mail.EndsWith("@zinmed.com"))
                {
                    if (v_lst_user.FirstOrDefault().BHYT.Length == 0)
                    {
                        return true;
                    }
                    return false;
                }
                if (v_lst_user.FirstOrDefault().BHYT.Length == 0) // Nếu ko phải email topica
                {
                    return true;
                }
                return false; // Nếu ko phải email topica
            }
            // Nếu account chưa đăng ký
            return false;
        }
        public bool CheckProfileIsFull(string ip_str_user)
        {
            bool v_b_result = true;
            if (ip_str_user == "") return false;
            UnitOfWork uow = new UnitOfWork();
            HT_USER v_ht_user = uow.Repository<HT_USER>().Query().Filter(x => x.USERNAME == ip_str_user).FirstOrDefault();
            if (v_ht_user == null) v_b_result = false;
            else
                return false;
            return v_b_result;
        }

        public void InsertIfDoNotHaveUser(string ip_str_user)
        {
            UnitOfWork uow = new UnitOfWork();
            if ("".Equals(ip_str_user)) return;
            string v_str_user = ip_str_user.Replace("@topica.edu.vn", "").Replace("@gmail.com", "").Replace("@zinmed.com", "");
            var v_lst_user = uow
                .Repository<HT_USER>()
                .Query()
                .Filter(x => (x.USERNAME == v_str_user + "@topica.edu.vn" || x.USERNAME == v_str_user + "@zinmed.com"
                    || x.USERNAME == v_str_user + "@gmail.com")
                    && (x.BHYT.Length > 0))
                .Get();
            if (v_lst_user == null) return;
            if (v_lst_user.Count() > 0) return;
            else
            {
                HT_USER v_ht_user = new HT_USER();
                v_ht_user.ID = System.Guid.NewGuid();
                v_ht_user.ID_USER_GROUP = Guid.Parse(CIdUserGroup.ID_NHAN_VIEN);//id user group NHAN_VIEN
                v_ht_user.USERNAME = ip_str_user;
                v_ht_user.BHYT = "";
                v_ht_user.CMND = "";
                v_ht_user.MSBN = "";
                v_ht_user.PASSWORD = "123456";
                v_ht_user.HO = "";
                v_ht_user.TEN = "";
                v_ht_user.IS_ACTIVE = true;
                v_ht_user.State = EDataState.Added;
                uow.Repository<HT_USER>().Insert(v_ht_user);
                uow.Save();
            }
        }
        public HT_USER GetFirstUser(string ip_str_user)
        {
            UnitOfWork uow = new UnitOfWork();
            string v_str_user = ip_str_user.Replace("@topica.edu.vn", "").Replace("@gmail.com", "");
            IEnumerable<HT_USER> v_lst_user = uow.Repository<HT_USER>().Query().Filter(x => x.USERNAME == v_str_user + "@topica.edu.vn" | x.USERNAME == v_str_user + "@gmail.com").Get();
            HT_USER v_ht_user = new HT_USER();
            if (v_lst_user == null) return v_ht_user;
            if (v_lst_user.Any())
            {
                v_ht_user.ID = v_lst_user.FirstOrDefault().ID;
                v_ht_user.BHYT = v_lst_user.FirstOrDefault().BHYT;
                v_ht_user.CMND = v_lst_user.FirstOrDefault().CMND;
                v_ht_user.MSBN = v_lst_user.FirstOrDefault().MSBN;
                v_ht_user.HO = v_lst_user.FirstOrDefault().HO;
                v_ht_user.TEN = v_lst_user.FirstOrDefault().TEN;
                v_ht_user.ID_USER_GROUP = v_lst_user.FirstOrDefault().ID_USER_GROUP;
                v_ht_user.IS_ACTIVE = v_lst_user.FirstOrDefault().IS_ACTIVE;
            }
            else
            {
                v_ht_user.ID = System.Guid.NewGuid();
                v_ht_user.ID_USER_GROUP = Guid.Parse(CIdUserGroup.ID_NHAN_VIEN);//id user group NHAN_VIEN
                v_ht_user.USERNAME = ip_str_user + "@topica.edu.vn";
                v_ht_user.State = EDataState.Added;
                uow.Repository<HT_USER>().Insert(v_ht_user);
                uow.Save();
            }
            return v_ht_user;
        }

        public bool IsExitUser(string ip_str_user)
        {
            UnitOfWork uow = new UnitOfWork();
            var v_lst_user = uow.Repository<HT_USER>().Query().Filter(x => x.USERNAME == ip_str_user).Get();
            if (v_lst_user == null) return false;
            if (v_lst_user.Any()) return false;
            return true;
        }
    }
}

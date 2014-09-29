using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Model;
using DataAccess;
using Framework.Extensions;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip_username"></param>
        /// <returns></returns>
        public UserModel GetByUsername(string ip_username)
        {
            if (ip_username.IsNullOrEmpty()) { return null; }
            UnitOfWork uow = new UnitOfWork();
            
            var v_entity_user = uow.Repository<HT_USER>().Query()
                .Filter(x => (x.BHYT == ip_username || x.CMND == ip_username || x.MSBN==ip_username|| x.USERNAME == ip_username))
                .FirstOrDefault();
            var v_bm_user = v_entity_user.CopyAs<UserModel>();
            v_bm_user.IS_ACTIVE = v_entity_user.IS_ACTIVE;

            return v_bm_user;
        }

        public Guid ActiveUser(Guid ip_id_benh_nhan)
        {
           // UnitOfWork uow = new UnitOfWork();
           //DM_BENH_NHAN v_dm_benh_nhan=uow.Repository<DM_BENH_NHAN>().Query()
           //    .Filter(x=>x.ID==ip_id_benh_nhan).AsNoTracking().FirstOrDefault();
           // HT_USER v_ht_user=uow.Repository<HT_USER>().Query()
           //     .Filter(x=>x.ID==v_dm_benh_nhan.ID_USER).FirstOrDefault();
           // v_ht_user.IS_ACTIVE = true;
           // v_ht_user.State = EDataState.Modified;
           // uow.Repository<HT_USER>().Update(v_ht_user);
           // uow.Save();
           // return v_ht_user.ID;
            return new Guid();
        }

        public Guid getGroupByIdUser(Guid ip_id_user) {
            UnitOfWork uow = new UnitOfWork();
            var v_id_user_group = uow.Repository<HT_USER>().Query()
                                    .Filter(x => x.ID == ip_id_user)
                                    .FirstOrDefault()
                                    .ID_USER_GROUP;
            return v_id_user_group;
        }
    }
}

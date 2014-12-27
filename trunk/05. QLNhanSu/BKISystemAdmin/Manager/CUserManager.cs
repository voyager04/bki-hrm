using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BKISystemAdmin.Model;
using Framework.Extensions;
using IP.Core.IPCommon;
using SQLDataAccess;

namespace BKISystemAdmin.Manager
{
    public class CUserManager
    {
        #region Singleton
        private static CUserManager _instance;
        private CUserManager() { }
        public static CUserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CUserManager();
                }
                return _instance;
            }
        }
        #endregion


        public IEnumerable<Model.CUserModel> GetAllUser()
        {
            UnitOfWork uow = new UnitOfWork();
            IEnumerable<CUserModel> v_list = uow.Repository<HT_USER>().Query()
                .Include(x => x.HT_USER_GROUP_WEB).Get().Select(x =>
                {
                    var y = x.CopyAs<CUserModel>();
                    y.USER_GROUP = x.HT_USER_GROUP_WEB.USER_GROUP_NAME;
                    y.DESCRIPTION = x.HT_USER_GROUP_WEB.DESCRIPTION;
                    return y;
                }).OrderByDescending(x => x.DESCRIPTION);
            return v_list;
        }
        public IEnumerable<Model.CUserModel> GetAllUserInUserGroup(Guid ip_id_user_group)
        {
            UnitOfWork uow = new UnitOfWork();
            IEnumerable<CUserModel> v_list = uow.Repository<HT_USER>().Query()
                .Filter(x => x.ID_USER_GROUP == ip_id_user_group)
                .Get()
                .OrderByDescending(x => x.USERNAME)
                .Select(x =>
                {
                    var y = x.CopyAs<CUserModel>();
                    y.USER_GROUP = x.HT_USER_GROUP_WEB.USER_GROUP_NAME;
                    return y;
                });
            return v_list;
        }

        public string getUserGroupName(Guid ip_id_user_group)
        {
            UnitOfWork uow = new UnitOfWork();
            var userGroup = uow.Repository<HT_USER_GROUP_WEB>().Query().Filter(x => x.ID == ip_id_user_group).FirstOrDefault();
            return userGroup.USER_GROUP_NAME;
        }

        public CUserModel getUserById(Guid ip_id_user)
        {
            UnitOfWork uow = new UnitOfWork();
            var v_tu_dien = uow.Repository<HT_USER>().Query()
               .Filter(x => x.ID == ip_id_user).FirstOrDefault();
            if (v_tu_dien != null)
            {
                return v_tu_dien.CopyAs<CUserModel>();
            }
            else return null;
        }
        public CUserModel getUserByUserName(string ip_userName)
        {
            UnitOfWork uow = new UnitOfWork();
            var v_tu_dien = uow.Repository<HT_USER>().Query()
               .Filter(x => x.USERNAME == ip_userName)
               .FirstOrDefault();
            if (v_tu_dien != null)
            {
                return v_tu_dien.CopyAs<CUserModel>();
            }
            else return null;
        }
        public int SaveData(CUserModel v_user, IP.Core.IPCommon.DataEntryFormMode v_e_form_mode)
        {
            HT_USER v_ht_user = v_user.CopyAs<HT_USER>();
            switch (v_e_form_mode)
            {
                case DataEntryFormMode.DeleteDataState:
                    return Delete(v_ht_user.ID);

                case DataEntryFormMode.InsertDataState:
                    return Insert(v_ht_user);

                case DataEntryFormMode.SelectDataState:
                    return 1;
                case DataEntryFormMode.UpdateDataState:
                    return Update(v_ht_user);

                case DataEntryFormMode.ViewDataState:
                    return 0;
                default:
                    return 0;
            }
        }

        private int Update(HT_USER v_ht_user)
        {
            try
            {
                UnitOfWork uow = new UnitOfWork();
                var v_user = uow.Repository<HT_USER>().Query().Filter(x => x.ID == v_ht_user.ID).FirstOrDefault();
                if (getUserById(v_ht_user.ID) != null)
                {
                    if (getUserById(v_ht_user.ID).USER_NAME == v_ht_user.USERNAME)
                    {
                        v_user.BHYT = v_ht_user.BHYT;
                        v_user.CMND = v_ht_user.CMND;
                        v_user.MSBN = v_ht_user.MSBN;
                        v_user.USERNAME = v_ht_user.USERNAME;
                        v_user.PASSWORD = v_ht_user.PASSWORD;
                        v_user.HO = v_ht_user.HO;
                        v_user.TEN = v_ht_user.TEN;
                        v_user.IS_ACTIVE = v_ht_user.IS_ACTIVE;
                        v_user.ID_USER_GROUP = v_ht_user.ID_USER_GROUP;
                        v_user.State = EDataState.Modified;
                        uow.Repository<HT_USER>().Update(v_user);
                        uow.Save();
                        return 100;
                    }
                    else
                        return 200;
                }
                v_user.BHYT = v_ht_user.BHYT;
                v_user.CMND = v_ht_user.CMND;
                v_user.MSBN = v_ht_user.MSBN;
                v_user.USERNAME = v_ht_user.USERNAME;
                v_user.PASSWORD = v_ht_user.PASSWORD;
                v_user.HO = v_ht_user.HO;
                v_user.TEN = v_ht_user.TEN;
                v_user.IS_ACTIVE = v_ht_user.IS_ACTIVE;
                v_user.ID_USER_GROUP = v_ht_user.ID_USER_GROUP;
                v_user.State = EDataState.Modified;
                uow.Repository<HT_USER>().Update(v_user);
                uow.Save();
                return 100;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int Insert(HT_USER ip_user)
        {
            try
            {
                if (getUserByUserName(ip_user.USERNAME) != null)
                {
                    return 200;
                }
                UnitOfWork uow = new UnitOfWork();
                uow.Repository<HT_USER>().Insert(ip_user);
                uow.Save();
                return 100;
            }
            catch (Exception)
            {
                throw;

            }
        }

        private int Delete(Guid ip_user)
        {
            try
            {
                UnitOfWork uow = new UnitOfWork();
                uow.Repository<HT_USER>().Delete(ip_user);
                uow.Save();
                return 100;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateUserGroupOfUser(Guid ip_guid_id_user_group, Guid ip_guid_id_user)
        {
            UnitOfWork uow = new UnitOfWork();
            HT_USER v_ht_user = uow.Repository<HT_USER>().Query().Filter(x => x.ID == ip_guid_id_user).FirstOrDefault();
            v_ht_user.ID_USER_GROUP = ip_guid_id_user_group;
            v_ht_user.State = EDataState.Modified;
            uow.Repository<HT_USER>().Update(v_ht_user);
            uow.Save();
        }

        public IEnumerable<CUserGroupModel> GetAllUserGroup()
        {
            UnitOfWork uow = new UnitOfWork();
            IEnumerable<CUserGroupModel> v_list = uow.Repository<HT_USER_GROUP_WEB>().Query().Get().Select(x => x.CopyAs<CUserGroupModel>()).OrderByDescending(x => x.USER_GROUP_NAME);
            return v_list;
        }
    }
}

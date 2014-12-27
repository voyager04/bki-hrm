using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Extensions;
using BKISystemAdmin.Model;
using SQLDataAccess;

namespace BKISystemAdmin.Manager
{
    public class CRoleManager
    {
        #region Singleton
        private static CRoleManager _instance;
        private CRoleManager() { }
        public static CRoleManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CRoleManager();
                }
                return _instance;
            }
        }
        #endregion

        #region Public Interface

        public IEnumerable<CChucNangModel> GetAllChucNangByRolForMenu(Guid ip_guid_role)
        {
            var uow = new UnitOfWork();
            return uow.Repository<HT_PHAN_QUYEN_CHUC_NANG>()
                .Query().Include(x => x.HT_PHAN_QUYEN_CHUC_NANG_CHILDREN)
                .Filter(x => x.ID_HT_USER_GROUP == ip_guid_role && !x.ID_CHUC_NANG_CHA.HasValue).OrderBy(x => x.OrderBy(y => y.VI_TRI)).Get()
                .Select(x =>
                {
                    var lp_result = Copy2ChucNangModel(x);
                    lp_result.CHUC_NANG_CON = x.HT_PHAN_QUYEN_CHUC_NANG_CHILDREN.Select(y => Copy2ChucNangModel(y));
                    return lp_result;
                });

        }

        public IEnumerable<CChucNangModel> GetAllChucNangByRoleForAuthenticate(Guid ip_guid_role)
        {
            var uow = new UnitOfWork();
            var v_lst_quyen_chuc_nang = uow.Repository<HT_PHAN_QUYEN_CHUC_NANG>()
                .Query().Filter(x => x.ID_HT_USER_GROUP == ip_guid_role).Get();

            var op_results = v_lst_quyen_chuc_nang.Select(x => Copy2ChucNangModel(x));
            return op_results;
        }

        public IEnumerable<CChucNangModel> GetAllChucNangByRoleForEdit(Guid ip_guid_role)
        {
            var uow = new UnitOfWork();
            var v_lst_quyen_chuc_nang = uow.Repository<HT_PHAN_QUYEN_CHUC_NANG>()
                .Query().Filter(x => x.ID_HT_USER_GROUP == ip_guid_role)
                .Include(x => x.HT_PHAN_QUYEN_CHUC_NANG_PARENT).Get();

            var op_lst_result = v_lst_quyen_chuc_nang.Select(x =>
            {
                var lp_result = Copy2ChucNangModel(x);
                if (x.HT_PHAN_QUYEN_CHUC_NANG_PARENT != null)
                    lp_result.CHUC_NANG_CHA = Copy2ChucNangModel(x.HT_PHAN_QUYEN_CHUC_NANG_PARENT);
                return lp_result;
            });

            return op_lst_result;
        }

        public IEnumerable<CUserGroupModel> GetAllUserGroup()
        {
            var uow = new UnitOfWork();
            var v_lst_user_group = uow.Repository<HT_USER_GROUP>()
                .Query().Get();

            return v_lst_user_group.Select(x => x.CopyAs<CUserGroupModel>());
        }

        public IEnumerable<CControlerModel> GetAllController()
        {
            var uow = new UnitOfWork();
            var v_lst_controller = uow.Repository<HT_CONTROLLER>()
                .Query().Get();

            return v_lst_controller.Select(x => x.CopyAs<CControlerModel>());
        }

        public IEnumerable<CChucNangModel> GetChucNangCon(Guid? ip_guid_id_chuc_nang_cha)
        {
            var uow = new UnitOfWork();
            var v_lst_controller = uow.Repository<HT_PHAN_QUYEN_CHUC_NANG>()
               .Query().Filter(x => x.ID_CHUC_NANG_CHA == ip_guid_id_chuc_nang_cha && x.TRANG_THAI_YN == true & x.HIEN_THI_YN == true).Get();
            return v_lst_controller.Select(x => x.CopyAs<CChucNangModel>());
        }
        public int AddController(CControlerModel ip_Model)
        {

            if (ip_Model.ACTIVITY_NAME == null || ip_Model.CONTROLLER_NAME == null || ip_Model.ACTIVITY_NAME == "" || ip_Model.CONTROLLER_NAME == "")
            {
                return 200;
            }
            else
            {
                UnitOfWork uow = new UnitOfWork();
                ip_Model.State = EDataState.Added;
                var v_bo_controll = ip_Model.CopyAs<HT_CONTROLLER>();
                uow.Repository<HT_CONTROLLER>().Insert(v_bo_controll);
                uow.Save();
                return 100;
            }
        }
        public int UpdateController(CControlerModel ip_Model)
        {
            if (ip_Model.ACTIVITY_NAME == null || ip_Model.CONTROLLER_NAME == null || ip_Model.ACTIVITY_NAME == "" || ip_Model.CONTROLLER_NAME == "")
            {
                return 200;
            }
            else
            {
                UnitOfWork uow = new UnitOfWork();
                ip_Model.State = EDataState.Modified;
                var v_bo_controll = ip_Model.CopyAs<HT_CONTROLLER>();
                uow.Repository<HT_CONTROLLER>().Update(v_bo_controll);
                uow.Save();
                return 100;
            }
        }
        public void DeleteController(CControlerModel ip_Model)
        {
            UnitOfWork uow = new UnitOfWork();
            ip_Model.State = EDataState.Deleted;
            var v_bo_controll = ip_Model.CopyAs<HT_CONTROLLER>();
            uow.Repository<HT_CONTROLLER>().Update(v_bo_controll);
            uow.Save();
        }
        public void AssignController(Guid ip_guid_role, Guid ip_guid_controller, Guid? ip_guid_control_parent
            , string ip_str_hien_thi, string ip_str_icon, bool ip_b_hien_thi_menu)
        {
            var uow = new UnitOfWork();

            var v_phan_quyen = new HT_PHAN_QUYEN_CHUC_NANG()
            {
                ID = Guid.NewGuid(),
                ID_HT_CONTROLLER = ip_guid_controller,
                TRANG_THAI_YN = true,
                VI_TRI = 1000,
                ID_HT_USER_GROUP = ip_guid_role,
                HIEN_THI_YN = ip_b_hien_thi_menu,
                HIEN_THI_MENU = ip_str_hien_thi,
                ICON_CLASS = ip_str_icon,
                ID_CHUC_NANG_CHA = ip_guid_control_parent,
                State = EDataState.Added
            };

            uow.Repository<HT_PHAN_QUYEN_CHUC_NANG>().Insert(v_phan_quyen);
            uow.Save();
        }

        public void UpdateAssignController(Guid ip_guid_id_phan_quyen, Guid ip_guid_controller, Guid? ip_guid_control_parent
           , string ip_str_hien_thi, string ip_str_icon, bool ip_b_hien_thi_menu)
        {
            var uow = new UnitOfWork();
            var phan_quyen_control = uow.Repository<HT_PHAN_QUYEN_CHUC_NANG>().Query().Filter(x => x.ID == ip_guid_id_phan_quyen).FirstOrDefault();
            if (phan_quyen_control != null)
            {
                phan_quyen_control.ID_CHUC_NANG_CHA = ip_guid_control_parent;
                phan_quyen_control.ID_HT_CONTROLLER = ip_guid_controller;
                phan_quyen_control.ICON_CLASS = ip_str_icon;
                phan_quyen_control.State = EDataState.Modified;
                phan_quyen_control.HIEN_THI_MENU = ip_str_hien_thi;
                phan_quyen_control.VI_TRI = 1000;
                uow.Repository<HT_PHAN_QUYEN_CHUC_NANG>().Update(phan_quyen_control);
                uow.Save();

            }
        }

        public void ResignController(Guid ip_guid_function)
        {
            var uow = new UnitOfWork();

            var v_phan_quyen = new HT_PHAN_QUYEN_CHUC_NANG()
            {
                ID = ip_guid_function,
                State = EDataState.Deleted
            };

            uow.Repository<HT_PHAN_QUYEN_CHUC_NANG>().Delete(v_phan_quyen);
            uow.Save();
        }

        #endregion

        #region Private method
        private CChucNangModel Copy2ChucNangModel(HT_PHAN_QUYEN_CHUC_NANG ip_obj_phan_quyen)
        {
            var lp_result = ip_obj_phan_quyen.CopyAs<CChucNangModel>();
            if (ip_obj_phan_quyen.HT_CONTROLLER != null)
            {
                lp_result.HAS_LINK = true;
                lp_result.CONTROLLER_NAME = ip_obj_phan_quyen.HT_CONTROLLER.CONTROLLER_NAME;
                lp_result.ACTIVITY_NAME = ip_obj_phan_quyen.HT_CONTROLLER.ACTIVITY_NAME;
            }
            else
            {
                lp_result.HAS_LINK = false;
            }

            return lp_result;
        }
        #endregion
    }
}

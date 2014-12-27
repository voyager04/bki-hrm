using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Utils;
using QLNhanSu.Models;

namespace QLNhanSu.Controllers
{
    public class SystemController : BaseController
    {
        #region Member
        BKI_HRMEntitiesModel _db = new BKI_HRMEntitiesModel();
        #endregion

        #region Public Method
        public ActionResult F301_DanhMucPhanQuyenChucNang()
        {
            return View(_db.HT_PHAN_QUYEN_CHUC_NANG.ToList());
        }
        #endregion

        #region Json Method
        public JsonResult GetAllController()
        {
            return Json(_db.HT_CONTROLLER
                .ToList()
                .Select(m => new 
                                 {
                                     ID = m.ID,
                                     CONTROLLER_NAME = m.CONTROLLER_NAME,
                                     ACTIVITY_NAME = m.ACTIVITY_NAME,
                                 }),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllUserGroup()
        {
            return Json(_db.HT_USER_GROUP_WEB
                .ToList()
                .Select(m => new
                                 {
                                     ID = m.ID,
                                     USER_GROUP_NAME = m.USER_GROUP_NAME,
                                     DESCRIPTION = m.DESCRIPTION
                                 }),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult FindUserGroupIsAdmin()
        {
            var userGroup = Guid.Parse(CIdUserGroup.ID_ADMIN);
            return Json(_db.HT_USER_GROUP_WEB
                            .Where(m => m.ID != userGroup)
                            .ToList()
                            .Select(m => new
                                             {
                                                 ID = m.ID,
                                                 USER_GROUP_NAME = m.USER_GROUP_NAME,
                                                 DESCRIPTION = m.DESCRIPTION
                                             }),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllAuthorize()
        {
            var userName = Guid.Parse(CIdUserGroup.ID_ADMIN);
            return Json(_db.HT_PHAN_QUYEN_CHUC_NANG
                .Where(m => m.ID_HT_USER_GROUP != userName)
                .OrderBy(m => m.VI_TRI)
                .ToList()
                .Select(m => new
                                 {
                                     ID = m.ID,
                                     UESR_GROUP = m.HT_USER_GROUP_WEB.USER_GROUP_NAME,
                                     CHUC_NANG_CHA = m.HT_PHAN_QUYEN_CHUC_NANG2 == null ? "" : m.HT_PHAN_QUYEN_CHUC_NANG2.HIEN_THI_MENU,
                                     CHUC_NANG_CON = m.HIEN_THI_MENU
                                 }),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult FinAuthorizeIsAdmin()
        {
            var userGroup = Guid.Parse(CIdUserGroup.ID_ADMIN);
            return Json(_db.HT_PHAN_QUYEN_CHUC_NANG
                .Where(m => m.ID_HT_USER_GROUP == userGroup)
                .OrderBy(m => m.VI_TRI)
                .ToList()
                .Select(m => new
                {
                    ID = m.ID,
                    ID_CONTROLLER = m.ID_HT_CONTROLLER,
                    CHUC_NANG_CON = m.HIEN_THI_MENU
                }),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult FindAuthorizeById(string id)
        {
            return Json(_db.V_HT_USER
                .OrderBy(m => m.USER_GROUP_NAME)
                .ThenBy(m => m.VI_TRI)
                .ToList()
                .Select(m => new
                {
                    ID = m.ID,
                    ID_USER_GROUP = m.ID_USER_GROUP,
                    UESR_GROUP = m.USER_GROUP_NAME,
                    ID_CONTROLLER = m.ID_HT_CONTROLLER,
                    CONTROLLER = m.CONTROLLER_NAME,
                    ACTIVITY = m.ACTIVITY_NAME,
                    VI_TRI = m.VI_TRI,
                    //TRANG_THAI = m.TRANG_THAI_YN,
                    ID_CHUC_NANG_CHA = m.ID_CHUC_NANG_CHA,
                    HIEN_THI = m.HIEN_THI_YN,
                    ICON_CLASS = m.ICON_CLASS,
                    CHUC_NANG_CHA = m.CHUC_NANG_CHA,
                    CHUC_NANG_CON = m.CHUC_NANG_CON
                }),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult FindAuthorizeByUserGroup(string idUserGroup)
        {
            var userGroup = Guid.Parse(idUserGroup);
            return Json(_db.HT_PHAN_QUYEN_CHUC_NANG
                .Where(m => m.ID_HT_USER_GROUP == userGroup)
                .OrderBy(m => m.VI_TRI)
                .ToList()
                .Select(m => new
                {
                    ID = m.ID,
                    ID_CONTROLLER = m.ID_HT_CONTROLLER,
                    CHUC_NANG_CON = m.HIEN_THI_MENU
                }),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertAuthorizeByUserGroup(string idAuthorize, string idUserGroup)
        {
            var guidAuthorize = Guid.Parse(idAuthorize);
            var guidUserGroup = Guid.Parse(idUserGroup);
            var userGroupAdmin = Guid.Parse(CIdUserGroup.ID_ADMIN);
            var functions = _db.HT_PHAN_QUYEN_CHUC_NANG.FirstOrDefault(m => m.ID_HT_CONTROLLER == guidAuthorize);
            if (functions == null) return null;

            _db.HT_PHAN_QUYEN_CHUC_NANG.Add(new HT_PHAN_QUYEN_CHUC_NANG()
                                                {
                                                    ID = Guid.NewGuid(),
                                                    ID_HT_USER_GROUP = guidUserGroup,
                                                    ID_HT_CONTROLLER = functions.ID_HT_CONTROLLER,
                                                    VI_TRI = functions.VI_TRI,
                                                    TRANG_THAI_YN =functions.TRANG_THAI_YN,
                                                    ID_CHUC_NANG_CHA = functions.ID_CHUC_NANG_CHA,
                                                    HIEN_THI_YN = functions.HIEN_THI_YN,
                                                    ICON_CLASS = functions.ICON_CLASS,
                                                    HIEN_THI_MENU = functions.HIEN_THI_MENU
                                                });
            _db.SaveChanges();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveAuthorizeByUserGroup(string idUserGroup)
        {
            var guidUserGroup = Guid.Parse(idUserGroup);
            var listFunctions = _db.HT_PHAN_QUYEN_CHUC_NANG.Where(m => m.ID_HT_USER_GROUP == guidUserGroup).ToList();
            foreach (var item in listFunctions)
            {
                _db.HT_PHAN_QUYEN_CHUC_NANG.Remove(item);
            }
            _db.SaveChanges();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

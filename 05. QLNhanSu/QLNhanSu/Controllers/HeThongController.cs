using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNhanSu.Models;

namespace QLNhanSu.Controllers
{
    public class HeThongController : BaseController
    {
        BKI_HRMEntitiesModel _db = new BKI_HRMEntitiesModel();
        public ActionResult F201_DanhMucNhanVien()
        {
            return View(_db.HT_USER);
        }

        public ActionResult F202_Insert()
        {
            LoadCombobox();
            return View(new HT_USER());
        }

        [HttpPost]
        public ActionResult F202_Insert(FormCollection collection)
        {
            var txtMaNhanVien = collection["txtMaNhanVien"];
            var txtUserName = collection["txtUserName"];
            var cbbUserGroup = collection["ID_USER_GROUP"];

            var nhanVien = _db.DM_NHAN_SU.FirstOrDefault(m => m.MA_NV == txtMaNhanVien);
            if (nhanVien != null)
            {
                _db.HT_USER.Add(new HT_USER()
                {
                    ID = Guid.NewGuid(),
                    BHYT = txtMaNhanVien,
                    CMND = null,
                    MSBN = null,
                    USERNAME = txtUserName,
                    PASSWORD = "123456",
                    HO = nhanVien.HO_DEM,
                    TEN = nhanVien.TEN,
                    IS_ACTIVE = true,
                    ID_USER_GROUP = Guid.Parse(cbbUserGroup)
                });
                _db.SaveChanges();
                return RedirectToAction("F201_DanhMucNhanVien", "HeThong");
            }
            LoadCombobox();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult F203_Update(string id)
        {
            var objId = new Guid();
            if (Guid.TryParse(id, out objId))
            {
                var user = _db.HT_USER.FirstOrDefault(m => m.ID == objId);
                LoadCombobox();
                return View(user);
            }
            return RedirectToAction("F201_DanhMucNhanVien", "HeThong");
        }

        [HttpPost]
        public ActionResult F203_Update(FormCollection collection)
        {
            var txtMaNhanVien = collection["v_MaNhanVien"];
            var txtUserName = collection["txtUserName"];
            var cbbUserGroup = Guid.Parse(collection["ID_USER_GROUP"]);

            var user = _db.HT_USER.FirstOrDefault(m => m.BHYT == txtMaNhanVien);
            if (user != null)
            {
                user.USERNAME = txtUserName;
                user.ID_USER_GROUP = cbbUserGroup;
                _db.SaveChanges();
            }
            return RedirectToAction("F201_DanhMucNhanVien", "HeThong");
        }

        public ActionResult F204_Remove(string id)
        {
            var ipId = Guid.Parse(id);
            var user = _db.HT_USER.FirstOrDefault(m => m.ID == ipId);
            if (user != null)
            {
                _db.HT_USER.Remove(user);
                _db.SaveChanges();
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public void LoadCombobox()
        {
            ViewBag.ID_USER_GROUP = new SelectList(_db.HT_USER_GROUP_WEB, "ID", "USER_GROUP_NAME");
        }

        public JsonResult GetAllUser()
        {
            return Json(_db.HT_USER.Select(m => new
            {
                ID = m.ID,
                MA_NHAN_VIEN = m.BHYT,
                USERNAME = m.USERNAME,
                PASSWORD = m.PASSWORD,
                HO = m.HO,
                TEN = m.TEN,
                ID_USER_GROUP = m.ID_USER_GROUP,
                USER_GROUP = _db.HT_USER_GROUP_WEB.FirstOrDefault(x => x.ID == m.ID_USER_GROUP).USER_GROUP_NAME
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllNhanVien()
        {
            return Json(_db.pr_V_NHAN_SU_HIEN_TAI().Select(m => new
            {
                ID = m.ID,
                MA_NHAN_VIEN = m.MA_NV,
                HO_DEM = m.HO_DEM,
                TEN = m.TEN,
                MA_CHUC_VU = m.MA_CV,
                MA_DON_VI = m.MA_DON_VI
            }), JsonRequestBehavior.AllowGet);
        }
    }
}

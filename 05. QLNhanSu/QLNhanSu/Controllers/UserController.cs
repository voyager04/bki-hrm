using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Facebook;
using QLNhanSu.Models;

namespace QLNhanSu.Controllers
{
    public class UserController : BaseController
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
            var txtAccountFb = collection["txtFacebook"];

            var nhanVien = _db.DM_NHAN_SU.FirstOrDefault(m => m.MA_NV == txtMaNhanVien);
            if (nhanVien != null)
            {
                _db.HT_USER.Add(new HT_USER()
                {
                    ID = Guid.NewGuid(),
                    BHYT = txtMaNhanVien,
                    CMND = null,
                    MSBN = txtAccountFb,
                    USERNAME = txtUserName,
                    PASSWORD = "123456",
                    HO = nhanVien.HO_DEM,
                    TEN = nhanVien.TEN,
                    IS_ACTIVE = true,
                    ID_USER_GROUP = Guid.Parse(cbbUserGroup)
                });
                _db.SaveChanges();
                return RedirectToAction("F201_DanhMucNhanVien", "User");
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
            return RedirectToAction("F201_DanhMucNhanVien", "User");
        }

        [HttpPost]
        public ActionResult F203_Update(FormCollection collection)
        {
            var txtMaNhanVien = collection["txtMaNhanVien"];
            var txtUserName = collection["txtUserName"];
            var cbbUserGroup = Guid.Parse(collection["ID_USER_GROUP"]);
            var txtAccountFb = collection["txtFacebook"];

            var user = _db.HT_USER.FirstOrDefault(m => m.USERNAME == txtUserName);
            if (user != null)
            {
                user.USERNAME = txtUserName;
                user.BHYT = txtMaNhanVien;

                var dmNhanSu = _db.DM_NHAN_SU.FirstOrDefault(m => m.MA_NV == txtMaNhanVien);
                if (dmNhanSu != null)
                {
                    user.HO = dmNhanSu.HO_DEM;
                    user.TEN = dmNhanSu.TEN;
                }

                user.ID_USER_GROUP = cbbUserGroup;
                user.MSBN = txtAccountFb;
                _db.SaveChanges();
            }
            return RedirectToAction("F201_DanhMucNhanVien", "User");
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
            var listUser = new List<FacebookAccount>();
            var client = new FacebookClient();

            foreach (var user in _db.HT_USER)
            {
                if (!string.IsNullOrEmpty(user.MSBN))
                {
                    dynamic me = client.Get(user.MSBN);
                    listUser.Add(new FacebookAccount()
                    {
                        ID = user.ID,
                        MA_NHAN_VIEN = user.BHYT,
                        USERNAME = user.USERNAME,
                        ID_FB = me.name,
                        AVATAR = GetPictureUrl(user.MSBN),
                        USER_GROUP = _db.HT_USER_GROUP_WEB.FirstOrDefault(x => x.ID == user.ID_USER_GROUP).USER_GROUP_NAME
                    });
                }
                else
                {
                    listUser.Add(new FacebookAccount()
                    {
                        ID = user.ID,
                        MA_NHAN_VIEN = user.BHYT,
                        USERNAME = user.USERNAME,
                        ID_FB = "",
                        USER_GROUP = _db.HT_USER_GROUP_WEB.FirstOrDefault(x => x.ID == user.ID_USER_GROUP).USER_GROUP_NAME
                    });
                }
            }

            return Json(listUser, JsonRequestBehavior.AllowGet);
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

        public static string GetPictureUrl(string faceBookId)
        {
            WebResponse response = null;
            string pictureUrl = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(string.Format("https://graph.facebook.com/{0}/picture", faceBookId));
                response = request.GetResponse();
                pictureUrl = response.ResponseUri.ToString();
            }
            catch (Exception ex)
            {
                //? handle
            }
            finally
            {
                if (response != null) response.Close();
            }
            return pictureUrl;
        }

        public JsonResult GetUserByMaNv(string maNhanVien)
        {
            var user = _db.HT_USER.FirstOrDefault(m => m.BHYT == maNhanVien);
            if (user != null)
            {
                return Json(new
                {
                    ID = user.ID,
                    BHYT = user.BHYT,
                    CMND = user.CMND,
                    MSBN = user.MSBN,
                    USERNAME = user.USERNAME
                }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public JsonResult UpdateIdFb(string ip_MaNhanVien, string ip_IdFb, string ip_NameFb)
        {
            var user = _db.HT_USER.FirstOrDefault(m => m.BHYT == ip_MaNhanVien);
            if (user != null)
            {
                user.MSBN = ip_IdFb;
                user.CMND = ip_NameFb;
                _db.SaveChanges();
            }
            return Json("Done", JsonRequestBehavior.AllowGet);
        }
    }
}

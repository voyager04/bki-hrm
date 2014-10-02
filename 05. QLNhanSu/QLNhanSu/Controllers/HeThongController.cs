using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Model;
using BusinessLogic.Management;
using DataAccess;

namespace QLNhanSu.Controllers
{
    public class HeThongController : BaseController
    {
        #region Member
        private string _result = "";
        private UserManager m_UserManager = UserManager.Instance;
        private V_DM_DON_VI_Manager m_dmDonVi = V_DM_DON_VI_Manager.Instance;
        #endregion

        [HttpGet]
        public ActionResult F201_GetAllUsers()
        {
            BKI_HRMEntities db = new BKI_HRMEntities();

            var v_allDonVi = db.pr_V_DM_DON_VI_search("", -1, -1, "Y", 3).ToList();

            foreach (var item in v_allDonVi)
            {
                if (item.ID_DON_VI_CAP_TREN == null)
                {
                    _result += "<tr class='treegrid-"+ item.ID +"'>";
                    _result += "<td>" + item.MA_DON_VI + "</td>";
                    _result += "<td>" + item.TEN_DON_VI + "</td>";
                    _result += "<td>" + item.SO_LUONG + "</td>";
                    _result += "<td>" + item.TEN_PHAP_NHAN + "</td>";
                    _result += "</tr>";
                }
                else
                {
                    _result += "<tr class='treegrid-" + item.ID + " treegrid-parent-" + item.ID_DON_VI_CAP_TREN + "'>";
                    _result += "<td>" + item.MA_DON_VI + "</td>";
                    _result += "<td>" + item.TEN_DON_VI + "</td>";
                    _result += "<td>" + item.SO_LUONG + "</td>";
                    _result += "<td>" + item.TEN_PHAP_NHAN + "</td>";
                    _result += "</tr>";
                    GetAllChildNode(item.ID, v_allDonVi);
                }
            }
            ViewBag.CoCauTOPICA = _result;
            var v_allUser = m_UserManager.GetAllUsers();
            return View(v_allDonVi);
        }

        private void GetAllChildNode(decimal id_parent, List<V_DM_DON_VI> ip_allDonVi)
        {
            var childNode = ip_allDonVi.Where(m => m.ID_DON_VI_CAP_TREN == id_parent);
            foreach (var item in childNode)
            {
                _result += "<tr class='treegrid-" + item.ID + " treegrid-parent-" + item.ID_DON_VI_CAP_TREN + "'>";
                _result += "<td>" + item.MA_DON_VI + "</td>";
                _result += "<td>" + item.TEN_DON_VI + "</td>";
                _result += "<td>" + item.SO_LUONG + "</td>";
                _result += "<td>" + item.TEN_PHAP_NHAN + "</td>";
                _result += "</tr>";
                GetAllChildNode(item.ID, ip_allDonVi);
            }
        }

    }
}

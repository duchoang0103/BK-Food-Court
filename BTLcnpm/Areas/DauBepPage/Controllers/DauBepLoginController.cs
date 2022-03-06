using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLcnpm.Areas.Admin.Data;
using BTLcnpm.Areas.DauBepPage.Common;
using BTLcnpm.Areas.DauBepPage.Data;
using Model.Dao;

namespace BTLcnpm.Areas.DauBepPage.Controllers
{
    public class DauBepLoginController : Controller
    {
        // GET: DauBepPage/DauBepLogin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CookerLogin model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CookerDao();
                var result = dao.CookerLogin(model.UserName, model.Password);
                if (result == true)
                {
                    var cooker = dao.GetCookerByUserName(model.UserName);
                    var cookerSession = new CookerLoginSession();
                    cookerSession.UserName = cooker.UserName;
                    cookerSession.VendorID = cooker.VendorId;
                    Session.Add(Constant.COOKER_SESSION, cookerSession);
                    return RedirectToAction("Index", "TrangDauBep");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu.");
                }
            }
            return View(model);
        }
    }
}
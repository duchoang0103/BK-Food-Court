using BTLcnpm.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLcnpm.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.AdminLogin(model.UserName, model.Password);
                if (result == true)
                {
                    var admin = dao.GetAdminByUserName(model.UserName);
                    var adminSession = new AdminLoginModel();
                    adminSession.UserName = admin.UserName;
                    adminSession.UserID = admin.ID;
                    adminSession.Password = admin.Password;
                    Session.Add(CommonConstants.ADMIN_SESSION, adminSession);
                    return RedirectToAction("Index", "Home");
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
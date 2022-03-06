using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLcnpm.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            var model = new UserDao().ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                var res = new UserDao().Insert(user);
                return RedirectToAction("Index", "User");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }
        [HttpGet]
        public ActionResult Edit(long userId)
        {
            var user = new UserDao().ViewDetail(userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                var res = new UserDao().Update(user);
                return RedirectToAction("Index", "User");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }
        public ActionResult Delete(long userId)
        {
            new UserDao().Delete(userId);
            return RedirectToAction("Index", "User");
        }
        public ActionResult ChangeStatus(long userId)
        {
            new UserDao().ChangeStatus(userId);
            return RedirectToAction("Index", "User");
        }
    }
}
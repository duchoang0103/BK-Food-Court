using BTLcnpm.Common;
using BTLcnpm.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bank;
using System.Web.Security;
using BTLcnpm.Common;

namespace BTLcnpm.Controllers
{

    public class UserController : Controller
    {
       
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            //if(Membership.ValidateUser(model.UserName, model.Password) &&ModelState.IsValid)
            //{
            //    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            //    var userSession = new UserDao().GetByUserName(model.UserName);
            //    Session.Add(CommonConstants.USER_SESSION, userSession);
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            //}
            //return View(model);
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result == true)
                {
                    var user = dao.GetByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserID = user.ID;
                    userSession.UserName = user.UserName;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return Redirect("/");
                }
                //else if (result == 0)
                //{
                //    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                //}
                //else if (result == -1)
                //{
                //    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                //}
                //else if (result == -2)
                //{
                //    ModelState.AddModelError("", "Mật khẩu không đúng.");
                //}
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View(model);
        }
        //[HttpPost]
        //public ActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new UserDao();
        //        if (dao.CheckUserName(model.UserName))
        //        {
        //            ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
        //        }
        //        else if (dao.CheckEmail(model.Email))
        //        {
        //            ModelState.AddModelError("", "Email đã tồn tại");
        //        }
        //        else
        //        {
        //            var user = new User();
        //            user.Name = model.Name;
        //            user.Password = Encryptor.MD5Hash(model.Password);
        //            user.Phone = model.Phone;
        //            user.Email = model.Email;
        //            user.Status = true;
                    
        //            var result = dao.Insert(user);
        //            if (result > 0)
        //            {
        //                ViewBag.Success = "Đăng ký thành công";
        //                model = new RegisterModel();
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Đăng ký không thành công.");
        //            }
        //        }
        //    }
        //    return View(model);
        //}
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
        public ActionResult Recharge()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Recharge(SoTien so_tien)
        {
            string mesg;
            if (Session[CommonConstants.USER_SESSION] == null)
            {
                mesg = "Bạn cần đăng nhập.";
                ViewBag.mes = mesg;
                return View();
            }
            var userSession = (UserLogin)Session[CommonConstants.USER_SESSION];
            
            var user = new UserDao().GetByUserName(userSession.UserName);
            var res = new UserDao().recharge(user.ID, so_tien.money);
            
            if(res)
            {
                mesg = "Nạp thành công";
            } 
            else
                mesg = "Nạp thất bại.";
            ViewBag.mes = mesg;
            return View();
        }
        public ActionResult Info()
        {
            return View();
        }
        public ActionResult Bank()
        {
            var userSession = (UserLogin)Session[CommonConstants.USER_SESSION];
            if(userSession != null)
            {
                var userId = new UserDao().GetByUserName(userSession.UserName).ID;
                var listAccount = new BankDao().ListAccount(userId);
                return View(listAccount);
            }
            return View();
        }

        public ActionResult AddUserBank()
        {
            var userSession = (UserLogin)Session[CommonConstants.USER_SESSION];
            var userId = new UserDao().GetByUserName(userSession.UserName).ID;

            return View();
        }
        [HttpPost]
        public ActionResult AddUserBank(UserBank userBank)
        {
            var tai_khoan = new BankDao().Insert(userBank);
            return Redirect("/tai-khoan-ngan-hang");
        }
        public ActionResult UpdateBank(UserBank userBank)
        {
            var tai_khoan = new BankDao().Update(userBank);
            return Redirect("/tai-khoan-ngan-hang");
        }
    }
}
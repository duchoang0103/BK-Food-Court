using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLcnpm.Common;
using BTLcnpm.Models;
using Model.EF;

namespace BTLcnpm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            var model = productDao.ListAllProduct1();
           
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var listCategory = new VendorDao().Menu();
            return PartialView(listCategory);
        }
        
       [ChildActionOnly]
        public ActionResult DemGioHang()
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            if (sessionCart != null)
            {
                int dem = 0;
                foreach (var item in sessionCart)
                {
                    dem += item.Quantity;
                }
                ViewBag.dem_gio_hang = dem;
            }    
            else
                ViewBag.dem_gio_hang = 0;
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult HienThiTen()
        {
            var userSession = (UserLogin)Session[CommonConstants.USER_SESSION];
            if(userSession != null)
            {
                var user = new UserDao().GetByUserName(userSession.UserName);
                
                ViewBag.ten_khach_hang = user.UserName;
                ViewBag.so_du = user.Balance;
            }
            return PartialView();
        }
    }
}
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLcnpm.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Home/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Admin/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DoanhThuDonHang()
        {
            ViewBag.listOrder = new OrderDao().ListAllOrder2();
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            ViewBag.tat_ca_san_pham = new ProductDao().ListAllProduct();
            ViewBag.tat_ca_user = new UserDao().ListAll();
            return View();
        }
        [HttpPost]
        public ActionResult DoanhThuDonHang(DateTime ngay1, DateTime ngay2)
        {
            if (ngay1 == null || ngay2 == null)
            {
                return View();
            }
            ViewBag.listOrder = new OrderDao().ListAllOrder_TheoNgay2(ngay1, ngay2);
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            ViewBag.tat_ca_san_pham = new ProductDao().ListAllProduct();
            ViewBag.tat_ca_user = new UserDao().ListAll();
            ViewBag.ngay1 = ngay1;
            ViewBag.ngay2 = ngay2;
            return View();
        }
        [HttpGet]
        public ActionResult DoanhThuMonAn()
        {
            ViewBag.listOrder = new OrderDao().ListAllOrder2();
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            ViewBag.tat_ca_san_pham = new ProductDao().ListAllProduct();
            ViewBag.tat_ca_user = new UserDao().ListAll();
            return View();
        }
        [HttpPost]
        public ActionResult DoanhThuMonAn(DateTime ngay1, DateTime ngay2)
        {
            if (ngay1 == null || ngay2 == null)
            {
                return View();
            }
            ViewBag.listOrder = new OrderDao().ListAllOrder_TheoNgay2(ngay1, ngay2);
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            ViewBag.tat_ca_san_pham = new ProductDao().ListAllProduct();
            ViewBag.tat_ca_user = new UserDao().ListAll();
            ViewBag.ngay1 = ngay1;
            ViewBag.ngay2 = ngay2;
            return View();
        }
        public ActionResult Logout()
        {
            Session[Common.CommonConstants.ADMIN_SESSION] = null;
            return RedirectToAction("Login", "AdminLogin");
        }
    }
}

using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLcnpm.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        // GET: Admin/Product
        
        public ActionResult Index(long vendorId = 0)
        {
            if(vendorId == 0)
            {
                ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
                var pro = new ProductDao().ListAllProduct();
                return View(pro);
            }    
            var model = new ProductDao().ListAllProductByVendorId(vendorId);
            var gian_hang = new VendorDao().GetVendorById(vendorId);

            ViewBag.gian_hang = gian_hang;
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create(long vendorId = 0)
        {
            if(vendorId != 0)
            {
                var gian_hang = new VendorDao().GetVendorById(vendorId);
                ViewBag.gian_hang = gian_hang;
            }
            var tat_ca_gian_hang = new VendorDao().ListAll();
            ViewBag.danhSachGianHang = tat_ca_gian_hang;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.CreatedDate = DateTime.Today;
            try
            {
                var result = new ProductDao().Insert(product);
                var VendorId = new ProductDao().GetProductById(product.ID).VendorID;
                return RedirectToAction("Index", "Product", new { vendorId = VendorId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var gian_hang = new VendorDao().GetVendorById(product.VendorID);
                ViewBag.gian_hang = gian_hang;
                var tat_ca_gian_hang = new VendorDao().ListAll();
                ViewBag.danhSachGianHang = tat_ca_gian_hang;
                return View(product);
            }
        }
        [HttpGet]
        public ActionResult Edit(long productId)
        {
            var tat_ca_gian_hang = new VendorDao().ListAll();
            ViewBag.danhSachGianHang = tat_ca_gian_hang;
            var product = new ProductDao().GetProductById(productId);
            ViewBag.gian_hang = new VendorDao().GetVendorById(product.VendorID);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                var result = new ProductDao().Update(product);
                var VendorId = new ProductDao().GetProductById(product.ID).VendorID;
                return RedirectToAction("Index", "Product", new { vendorId = VendorId });

            }
            catch (Exception ex)
            {
                var tat_ca_gian_hang = new VendorDao().ListAll();
                ViewBag.danhSachGianHang = tat_ca_gian_hang;
                ViewBag.gian_hang = new VendorDao().GetVendorById(product.VendorID);
                ModelState.AddModelError("", ex.Message);
                return View(product);
            }
        }
        public ActionResult Delete(long productId)
        {
            var VendorId = new ProductDao().GetProductById(productId).VendorID;
            try
            {
                var result = new ProductDao().Delete(productId);
                return RedirectToAction("Index", "Product", new { vendorId = VendorId });
               

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Product", new { vendorId = VendorId });
            }
        }
        public ActionResult EditStatus(long productId)
        {
            try
            {
                new ProductDao().UpdateStatus(productId);
                var VendorId = new ProductDao().GetProductById(productId).VendorID;
                return RedirectToAction("Index", "Product");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var VendorId = new ProductDao().GetProductById(productId).VendorID;
                return RedirectToAction("Index", "Product");

            }
        }
    }
}

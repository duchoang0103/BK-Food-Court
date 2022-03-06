using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLcnpm.Areas.Admin.Controllers
{
    public class CookerController : BaseAdminController
    {
        // GET: Admin/Cooker
        public ActionResult Index(long vendorId = 0)
        {
            ViewBag.gian_hang = new VendorDao().GetVendorById(vendorId);
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            if (vendorId == 0)
            {
                var listcooker = new CookerDao().ListAllCooker();
                return View(listcooker);
            }
            var model = new CookerDao().ListAllCookerByVendorId(vendorId);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create(long vendorId = 0)
        {
            if(vendorId != 0)
            {
                ViewBag.gian_hang = new VendorDao().GetVendorById(vendorId);
            }
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cooker cooker)
        {
            ViewBag.danhSachDauBep = new VendorDao().ListAll();
            try
            {
                var result = new CookerDao().Insert(cooker);
                return RedirectToAction("Index", "Cooker", new {vendorId = cooker.VendorId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cooker);
            }
        }
        [HttpGet]
        public ActionResult Edit(long cookerId)
        {
            ViewBag.danhSachGianHang = new VendorDao().ListAll();
            var cooker = new CookerDao().GetCookerById(cookerId);
            ViewBag.gian_hang = new VendorDao().GetVendorById(cooker.VendorId);
            return View(cooker);
        }
        [HttpPost]
        public ActionResult Edit(Cooker cooker)
        {
            try
            {
                var result = new CookerDao().Update(cooker);
                var VendorId = new CookerDao().GetCookerById(cooker.ID).VendorId;
                return RedirectToAction("Index", "Cooker", new { vendorId = VendorId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.danhSachGianHang = new VendorDao().ListAll();
                ViewBag.gian_hang = new VendorDao().GetVendorById(cooker.VendorId);
                return View(cooker);
            }
        }
        public ActionResult Delete(long cookerId)
        {
            var VendorId = new CookerDao().GetCookerById(cookerId).VendorId;
            try
            {
                var result = new CookerDao().Delete(cookerId);
                return RedirectToAction("Index", "Cooker", new { vendorId = VendorId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Cooker", new { vendorId = VendorId });
            }
        }
        public ActionResult EditStatus(long cookerId)
        {
            try
            {
                new CookerDao().UpdateStatus(cookerId);
                var VendorId = new CookerDao().GetCookerById(cookerId).VendorId;
                return RedirectToAction("Index", "Cooker", new { vendorId = VendorId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var VendorId = new CookerDao().GetCookerById(cookerId).VendorId;
                return RedirectToAction("Index", "Cooker", new { vendorId = VendorId });
            }
        }
    }
}
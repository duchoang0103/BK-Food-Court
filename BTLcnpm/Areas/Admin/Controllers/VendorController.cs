using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLcnpm.Areas.Admin.Controllers
{
    public class VendorController : BaseAdminController
    {
        // GET: Admin/Vendor
        public ActionResult Index()
        {
            var model = new VendorDao().ListAllVendor();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Vendor vendor)
        {
            try
            {
                var result = new VendorDao().Insert(vendor);
                return RedirectToAction("Index", "Vendor");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vendor);
            }
        }
        [HttpGet]
        public ActionResult Edit(long vendorId)
        {
            var vendor = new VendorDao().GetVendorById(vendorId);
            return View(vendor);
        }
        [HttpPost]
        public ActionResult Edit(Vendor vendor)
        {
            try
            {
                var result = new VendorDao().Update(vendor);
                return RedirectToAction("Index", "Vendor");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vendor);
            }
        }
        public ActionResult Delete(long vendorId)
        {
            try
            {
                var result = new VendorDao().Delete(vendorId);
                return RedirectToAction("Index", "Vendor");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Vendor");
            }
        }
        public ActionResult EditStatus(long vendorId)
        {
            try
            {
                new VendorDao().UpdateStatus(vendorId);
                return RedirectToAction("Index", "Vendor");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Vendor");
            }
        }
    }
}
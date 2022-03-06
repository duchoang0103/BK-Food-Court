using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLcnpm.Controllers
{

    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListProductByMenu(long vendorId)
        {
            var model = new ProductDao().ListByVendorId(vendorId);
            ViewBag.vendorName = new VendorDao().ViewDetail(vendorId);
            return View(model);
        }
        public ActionResult Search(string keyword)
        {
            var model = new ProductDao().Search(keyword);
            return View(model);
        }
        public ActionResult ProductDetail(int productID)
        {
            var model = new ProductDao().ProductDetail(productID);
            return View(model);
        }
    }
}
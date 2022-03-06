using BTLcnpm.Areas.DauBepPage.Common;
using BTLcnpm.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLcnpm.Areas.DauBepPage.Controllers
{
    public class TrangDauBepController : BaseController
    {
        // GET: DauBepPage/TrangDauBep
        public ActionResult Index()
        {
            var CookerSession = (CookerLoginSession)Session[Constant.COOKER_SESSION];
            var listOrder = new OrderDao().ListAllOrder(CookerSession.VendorID);
            ViewBag.gian_hang = new VendorDao().GetVendorById(CookerSession.VendorID);
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            ViewBag.tat_ca_san_pham = new ProductDao().ListAllProductByVendorId(CookerSession.VendorID);
            ViewBag.tat_ca_user = new UserDao().ListAll();
            return View(listOrder);
        }
        public ActionResult EditPaymentMethod(long orderID)
        {
            try
            {
                new OrderDao().UpdatePaymentMethod(orderID);
                return RedirectToAction("Index", "TrangDauBep");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "TrangDauBep");
            }
        }
        public ActionResult EditPaymentStatus(long orderID)
        {
            try
            {
                new OrderDao().UpdatePaymentStatus(orderID);
                return RedirectToAction("Index", "TrangDauBep");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "TrangDauBep");
            }
        }
        public ActionResult EditFoodStatus(long orderID)
        {
            try
            {
                new OrderDao().UpdateFoodStatus(orderID);
                return RedirectToAction("Index", "TrangDauBep");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "TrangDauBep");
            }
        }
        public ActionResult EditStatus(long orderID)
        {
            try
            {
                new OrderDao().UpdateStatus(orderID);
                return RedirectToAction("Index", "TrangDauBep");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "TrangDauBep");
            }
        }
        public ActionResult ListFood()
        {
            var CookerSession = (CookerLoginSession)Session[Constant.COOKER_SESSION];
            var vendorId = CookerSession.VendorID;
            if (vendorId == 0)
            {
                return View();
            }
            var model = new ProductDao().ListAllProductByVendorId(vendorId);
            var gian_hang = new VendorDao().GetVendorById(vendorId);

            ViewBag.gian_hang = gian_hang;
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            return View(model);
        }
        public ActionResult EditProductStatus(long productId)
        {
            try
            {
                new ProductDao().UpdateStatus(productId);
                return RedirectToAction("ListFood", "TrangDauBep");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("ListFood", "TrangDauBep");
            }
        }
        [HttpGet]
        public ActionResult Edit(long productId)
        {
            var product = new ProductDao().GetProductById(productId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                var pro = new ProductDao().GetProductById(product.ID);
                pro.Quantity = product.Quantity;
                try
                {
                    var CookerSession = (CookerLoginSession)Session[Constant.COOKER_SESSION];
                    var vendorId = CookerSession.VendorID;
                    if (pro.VendorID == vendorId)
                    {
                        var result = new ProductDao().Update(pro);
                        return RedirectToAction("ListFood", "TrangDauBep");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bạn không được chỉnh sửa sản phẩm ngoài gian hàng.");
                        return View(product);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(product);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Không tồn tại sản phẩm có mã vừa nhập.");
                return View(product);
            }
        }
        [HttpGet]
        public ActionResult DoanhThuDonHang()
        {
            var CookerSession = (CookerLoginSession)Session[Constant.COOKER_SESSION];
            ViewBag.listOrder = new OrderDao().ListAllOrder1(CookerSession.VendorID);
            ViewBag.gian_hang = new VendorDao().GetVendorById(CookerSession.VendorID);
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            ViewBag.tat_ca_san_pham = new ProductDao().ListAllProductByVendorId(CookerSession.VendorID);
            ViewBag.tat_ca_user = new UserDao().ListAll();
            return View();
        }
        [HttpPost]
        public ActionResult DoanhThuDonHang(DateTime ngay1, DateTime ngay2)
        {
            if(ngay1 == null || ngay2 == null)
            {
                return View();
            }
            var CookerSession = (CookerLoginSession)Session[Constant.COOKER_SESSION];
            ViewBag.listOrder = new OrderDao().ListAllOrder_TheoNgay(ngay1, ngay2, CookerSession.VendorID);
            ViewBag.gian_hang = new VendorDao().GetVendorById(CookerSession.VendorID);
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            ViewBag.tat_ca_san_pham = new ProductDao().ListAllProductByVendorId(CookerSession.VendorID);
            ViewBag.tat_ca_user = new UserDao().ListAll();
            ViewBag.ngay1 = ngay1;
            ViewBag.ngay2 = ngay2;
            return View();
        }
        [HttpGet]
        public ActionResult DoanhThuMonAn()
        {
            var CookerSession = (CookerLoginSession)Session[Constant.COOKER_SESSION];
            ViewBag.listOrder = new OrderDao().ListAllOrder1(CookerSession.VendorID);
            ViewBag.gian_hang = new VendorDao().GetVendorById(CookerSession.VendorID);
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            ViewBag.tat_ca_san_pham = new ProductDao().ListAllProductByVendorId(CookerSession.VendorID);
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
            var CookerSession = (CookerLoginSession)Session[Constant.COOKER_SESSION];
            ViewBag.listOrder = new OrderDao().ListAllOrder_TheoNgay(ngay1, ngay2, CookerSession.VendorID);
            ViewBag.gian_hang = new VendorDao().GetVendorById(CookerSession.VendorID);
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            ViewBag.tat_ca_san_pham = new ProductDao().ListAllProductByVendorId(CookerSession.VendorID);
            ViewBag.tat_ca_user = new UserDao().ListAll();
            ViewBag.ngay1 = ngay1;
            ViewBag.ngay2 = ngay2;
            return View();
        }
        public ActionResult Logout()
        {
            Session[Constant.COOKER_SESSION] = null;
            return RedirectToAction("Login", "DauBepLogin");
        }
    }
}
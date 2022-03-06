using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using BTLcnpm.Common;
using BTLcnpm.Models;
using Model.EF;

namespace BTLcnpm.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var sessionUser = (UserLogin)Session[CommonConstants.USER_SESSION];
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            if(sessionCart != null)
            {
                decimal tong_tien = 0;
                foreach (var item in sessionCart)
                {
                    tong_tien += (item.Quantity * item.Product.Price);
                }
                var user = new UserDao().GetByUserName(sessionUser.UserName);
                if (user.Balance < tong_tien)
                {
                    ViewBag.KhongDuTien = "Số dư không đủ";
                }
            }

            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(long productID)
        {
            string mesg;
            if (Session[CommonConstants.USER_SESSION] == null)
            {
                mesg = "Bạn cần đăng nhập.";
                ViewBag.mes = mesg;
                return RedirectToAction("Login", "User");
            }
            var product = new ProductDao().ProductDetail(productID);
            var cart = Session[CommonConstants.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += 1;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = 1;
                    list.Add(item);
                }
                //Gán vào session
                Session[CommonConstants.CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = 1;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CommonConstants.CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteItem(long productID)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == productID);
            Session[CommonConstants.CartSession] = sessionCart;
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAll()
        {
            Session[CommonConstants.CartSession] = null;
            return RedirectToAction("Index");
        }
        public ActionResult Update(long productID, int quantity)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];

            foreach (var item in sessionCart)
            {
                if (item.Product.ID == productID)
                {
                    item.Quantity = quantity;
                }
            }
            Session[CommonConstants.CartSession] = sessionCart;
            return RedirectToAction("Index");
        }
        public ActionResult ThanhToanTienMat()
        {
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            var sessionUser = (UserLogin)Session[CommonConstants.USER_SESSION];
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            if(sessionCart != null)
            {
                foreach (var item in sessionCart)
                {
                    var order = new Order();
                    order.UserID = sessionUser.UserID;
                    order.VendorID = item.Product.VendorID;
                    order.ProductID = item.Product.ID;
                    order.Quantity = item.Quantity;
                    order.Price = item.Product.Price;
                    order.CreatedDate = DateTime.Now;
                    order.PaymentMethod = 0;    // O: Thanh toán bằng tiền mặt
                    order.PaymentStatus = 0;    // 0: Trạng thái thanh toán: Chưa thanh toán
                    new OrderDao().Insert(order);
                }
                ViewBag.message = "Hình thức thanh toán: Thanh toán tại quầy.";
                ViewBag.message2 = "Tình trạng thanh toán: Chưa thanh toán.";
                Session[CommonConstants.CartSession] = null;
                return View(sessionCart);
            }
            else
            {
                ViewBag.message = "Đã có lỗi xảy ra.";
                return View();
            }
            
        }
        public ActionResult ThanhToanSFC()
        {
            ViewBag.tat_ca_gian_hang = new VendorDao().ListAllVendor();
            var sessionUser = (UserLogin)Session[CommonConstants.USER_SESSION];
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            long tong_tien = 0;
            foreach (var item in sessionCart)
            {
                tong_tien += (long)(item.Quantity * item.Product.Price);
            }
            var user = new UserDao().GetByUserName(sessionUser.UserName);
            if(user.Balance < tong_tien)
            {
                ViewBag.KhongDuTien = "Số dư không đủ";
                return RedirectToAction("Index", "Cart");
            }
            if (sessionCart != null)
            {
                foreach (var item in sessionCart)
                {
                    var order = new Order();
                    order.UserID = sessionUser.UserID;
                    order.ProductID = item.Product.ID;
                    order.VendorID = item.Product.VendorID;
                    order.Quantity = item.Quantity;
                    order.Price = item.Product.Price;
                    order.CreatedDate = DateTime.Now;
                    order.PaymentMethod = 1;    // 1: Thanh toán bằng ví SFC
                    order.PaymentStatus = 1;    // 1: Trạng thái thanh toán: Đã thanh toán
                    new OrderDao().Insert(order);
                }
                ViewBag.message = "Hình thức thanh toán: Online.";
                ViewBag.message2 = "Tình trạng thanh toán: Đã thanh toán.";

                var res = new UserDao().TruTien(user.ID, tong_tien);

                Session[CommonConstants.CartSession] = null;
                return View(sessionCart);
            }
            else
            {
                ViewBag.message = "Đã có lỗi xảy ra.";
                return View();
            }
        }
    }
}
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDao
    {
        SmartFoodDbContext db = null;
        public OrderDao()
        {
            db = new SmartFoodDbContext();
        }
        public long Insert(Order entity)
        {
            db.Order.Add(entity);
            db.SaveChanges();
            return entity.OrderID;
        }
        public List<Order> ListAllOrder(long vendorID)
        {
            var baselineDate = DateTime.Now.AddHours(-10);

            return db.Order.Where(x=>x.CreatedDate > baselineDate && x.Status == false && x.VendorID == vendorID).OrderByDescending(x => x.OrderID).ToList();
        }
        public List<Order> ListAllOrder1(long vendorID)
        {
            var baselineDate = DateTime.Now.AddMonths(-1);

            return db.Order.Where(x => x.CreatedDate > baselineDate && x.Status == true && x.VendorID == vendorID).OrderByDescending(x => x.OrderID).ToList();
        }
        public List<Order> ListAllOrder2()
        {
            var baselineDate = DateTime.Now.AddMonths(-1);

            return db.Order.Where(x => x.CreatedDate > baselineDate && x.Status == true).OrderByDescending(x => x.OrderID).ToList();
        }
        public List<Order> ListAllOrder_TheoNgay(DateTime ngay1, DateTime ngay2, long vendorID)
        {
            ngay2 = ngay2.AddDays(1);
            return db.Order.Where(x => x.CreatedDate >= ngay1 && x.CreatedDate <= ngay2 && x.Status == true && x.VendorID == vendorID).OrderByDescending(x => x.OrderID).ToList();
        }
        public List<Order> ListAllOrder_TheoNgay2(DateTime ngay1, DateTime ngay2)
        {
            ngay2 = ngay2.AddDays(1);
            return db.Order.Where(x => x.CreatedDate >= ngay1 && x.CreatedDate <= ngay2 && x.Status == true).OrderByDescending(x => x.OrderID).ToList();
        }
        public long UpdatePaymentMethod(long orderID)
        {
            var order = db.Order.Find(orderID);

            if(order.PaymentMethod == 0)
            {
                order.PaymentMethod = 1;
            }
            else
            {
                order.PaymentMethod = 0;
            }
            db.SaveChanges();
            return orderID;
        }
        public long UpdatePaymentStatus(long orderID)
        {
            var order = db.Order.Find(orderID);

            if (order.PaymentStatus == 0)
            {
                order.PaymentStatus = 1;
            }
            else
            {
                order.PaymentStatus = 0;
            }
            db.SaveChanges();
            return orderID;
        }
        public long UpdateFoodStatus(long orderID)
        {
            var order = db.Order.Find(orderID);

            if (order.FoodStatus == 0)
            {
                order.FoodStatus = 1;
            }
            else
            {
                order.FoodStatus = 0;
            }
            db.SaveChanges();
            return orderID;
        }
        public long UpdateStatus(long orderID)
        {
            
            var order = db.Order.Find(orderID);
            order.Status = !order.Status;
            db.SaveChanges();
            return orderID;
        }
       
    }
}

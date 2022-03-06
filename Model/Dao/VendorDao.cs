using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class VendorDao
    {
        SmartFoodDbContext db = null;
        public VendorDao()
        {
            db = new SmartFoodDbContext();
        }
        public List<Vendor> ListAllVendor()
        {
            return db.Vendor.OrderBy(x => x.VendorID).ToList();
        }
        public List<Vendor> Menu()
        {
            return db.Vendor.OrderBy(x => x.VendorID).Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        public Vendor ViewDetail(long vendorID)
        {
            var vendor = db.Vendor.SingleOrDefault(x => x.VendorID == vendorID);
            return vendor;
        }
        public List<Vendor> ListAll()
        {
            return db.Vendor.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        public long Insert(Vendor vendor)
        {
            db.Vendor.Add(vendor);
            db.SaveChanges();
            return vendor.VendorID;
        }
        public long Update(Vendor entity)
        {
            var vendor = db.Vendor.Find(entity.VendorID);
            if (!string.IsNullOrEmpty(entity.VendorName))
            {
                vendor.VendorName = entity.VendorName;
            }
            if (!string.IsNullOrEmpty(entity.Email))
            {
                vendor.Email = entity.Email;
            }
            if (!string.IsNullOrEmpty(entity.Phone))
            {
                vendor.Phone = entity.Phone;
            }
            vendor.DisplayOrder = entity.DisplayOrder;
            vendor.Status = entity.Status;
            db.SaveChanges();
            return entity.VendorID;
        }
        public long UpdateStatus(long vendorId)
        {
            var vendor = db.Vendor.Find(vendorId);
           
            vendor.Status = !vendor.Status;
            db.SaveChanges();
            return vendorId;
        }
        public long Delete(long vendorID)
        {
            var vendor = db.Vendor.Find(vendorID);
            db.Vendor.Remove(vendor);
            db.SaveChanges();
            return vendorID;
        }
        public Vendor GetVendorById(long vendorID)
        {
            var vendor = db.Vendor.Find(vendorID);
            return vendor;
        }
    }
}

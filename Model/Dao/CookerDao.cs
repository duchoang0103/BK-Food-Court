using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CookerDao
    {
        SmartFoodDbContext db = null;
        public CookerDao()
        {
            db = new SmartFoodDbContext();
        }
        public List<Cooker> ListAllCooker()
        {
            return db.Cooker.OrderBy(x => x.ID).ToList();
        }
        public List<Cooker> ListAllCookerByVendorId(long vendorId)
        {
            return db.Cooker.Where(x => x.VendorId == vendorId).OrderBy(x => x.ID).ToList();
        }
        public long Insert(Cooker cooker)
        {
            db.Cooker.Add(cooker);
            db.SaveChanges();
            return cooker.ID;
        }
        public long Update(Cooker entity)
        {
            var cooker = db.Cooker.Find(entity.ID);
            if (!string.IsNullOrEmpty(entity.Name))
            {
                cooker.Name = entity.Name;
            }
            if (!string.IsNullOrEmpty(entity.Email))
            {
                cooker.Email = entity.Email;
            }
            if (!string.IsNullOrEmpty(entity.Phone))
            {
                cooker.Phone = entity.Phone;
            }
            cooker.Status = entity.Status;
            db.SaveChanges();
            return entity.ID;
        }
        public long UpdateStatus(long cookerId)
        {
            var cooker = db.Cooker.Find(cookerId);
            cooker.Status = !cooker.Status;
            db.SaveChanges();
            return cookerId;
        }
        public long Delete(long cookerID)
        {
            var cooker = db.Cooker.Find(cookerID);
            db.Cooker.Remove(cooker);
            db.SaveChanges();
            return cookerID;
        }
        public Cooker GetCookerById(long cookerID)
        {
            var cooker = db.Cooker.Find(cookerID);
            return cooker;
        }
        public Cooker GetCookerByUserName(string userName)
        {
            var cooker = db.Cooker.Where(x=>x.UserName == userName).First();
            return cooker;
        }
        public bool CookerLogin(string userName, string password)
        {
            var result = db.Cooker.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            if (result == null)
            {
                return false;
            }
            else
                return true;
        }
    }
}

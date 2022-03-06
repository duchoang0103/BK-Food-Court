using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Dao
{
    public class BankDao
    {
        SmartFoodDbContext db = null;
        public BankDao()
        {
            db = new SmartFoodDbContext();
        }
        public long Insert(UserBank userBank)
        {
            db.UserBank.Add(userBank);
            db.SaveChanges();
            return userBank.UserID;
        }
        public bool Update(UserBank entity)
        {
            try
            {
                var userBank = db.UserBank.SingleOrDefault(x=>x.UserID == entity.UserID && x.BankName == entity.BankName);
               
                if (!string.IsNullOrEmpty(entity.BankName) && !string.IsNullOrEmpty(entity.STK) && !string.IsNullOrEmpty(entity.Pass))
                {
                    userBank.BankName = entity.BankName;
                    userBank.STK = entity.STK;
                    userBank.Pass = entity.Pass;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public List<UserBank> ListAccount(long userId)
        {
            return db.UserBank.Where(x => x.UserID == userId).ToList();
        }
    }
}

using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace Model.Dao
{
    public class UserDao
    {
        SmartFoodDbContext db = null;
        public UserDao()
        {
            db = new SmartFoodDbContext();
        }

        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        
        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Email = entity.Email;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public User GetByUserName(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(long id)
        {
            return db.User.Find(id);
        }
        
        //public int Login(string userName, string passWord, bool isAdmin = false)
        //{
        //    var result = db.User.SingleOrDefault(x => x.UserName == userName);
        //    if (result == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        if (isAdmin == true)
        //        {
        //            if(result.GroupID == "MOD")
        //            {
        //                if (result.Status == false)
        //                {
        //                    return -1;
        //                }
        //                else
        //                {
        //                    if (result.Password == passWord)
        //                        return 1;
        //                    else
        //                        return -2;
        //                }
        //            }
        //            else
        //            {
        //                return -3;
        //            }

        //        }
        //        else
        //        {
        //            if (result.Status == false)
        //            {
        //                return -1;
        //            }
        //            else
        //            {
        //                if (result.Password == passWord)
        //                    return 1;
        //                else
        //                    return -2;
        //            }
        //        }
        //    }
        //}
        public bool Login(string userName, string password)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            if (result == null)
            {
                return false;
            }
            else
                return true;
        }
        public List<User> ListAll()
        {
            return db.User.OrderBy(x=>x.ID).ToList();
        }
        public bool ChangeStatus(long id)
        {
            var user = db.User.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(long id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool recharge(long userID, long money)
        {
            var u = db.User.SingleOrDefault(x => x.ID == userID);
            var taikhoan = db.UserBank.SingleOrDefault(x => x.UserID == userID);
            bool res = new RechargeAPI().Recharge(money, taikhoan.STK, taikhoan.Pass);
            if (res)
            {
                u.Balance += money;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool TruTien(long userID, long money)
        {
            try
            {
                var u = db.User.SingleOrDefault(x => x.ID == userID);
                u.Balance = u.Balance - money;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AdminLogin(string userName, string password)
        {
            var result = db.Manager.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            if (result == null)
            {
                return false;
            }
            else
                return true;
        }
        public Manager GetAdminByUserName(string userName)
        {
            return db.Manager.SingleOrDefault(x => x.UserName == userName);
        }
    }
}

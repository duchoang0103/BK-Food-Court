using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        SmartFoodDbContext db = null;
        public ProductDao()
        {
            db = new SmartFoodDbContext();
        }

        public List<Product> ListAllProduct()
        {
            return db.Product.OrderBy(x => x.ID).ToList();
        }

        public List<Product> ListAllProduct1()
        {
            return db.Product.Where(x => x.Quantity > 0 && x.Status == true).OrderBy(x => x.ID).ToList();
        }
        public List<Product> ListAllProductByVendorId(long vendorId)
        {
            return db.Product.Where(x=>x.VendorID == vendorId ).OrderBy(x => x.ID).ToList();
        }
        public List<Product> ListByVendorId(long VendorID)
        {
            return db.Product.Where(x => x.Status == true && x.VendorID == VendorID && x.Quantity > 0).OrderBy(x => x.DisplayOrder).ToList();
        }      
        public List<Product> Search(string keyword)
        {
            var list = db.Product.Where(x => x.Name.Contains(keyword) && x.Quantity > 0 && x.Status == true).OrderBy(x => x.CreatedDate).ToList();
            return list;
        }
        public Product ProductDetail(long id)
        {
            return db.Product.Find(id);
        }
        public long Insert(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
            return product.ID;
        }
        public long Update(Product entity)
        {
            var product = db.Product.Find(entity.ID);
            if (!string.IsNullOrEmpty(entity.Name))
            {
                product.Name = entity.Name;
            }
            if (!string.IsNullOrEmpty(entity.Image))
            {
                product.Image = entity.Image;
            }
            product.Price = entity.Price;
            product.Quantity = entity.Quantity;
            product.VendorID = entity.VendorID;
            product.DisplayOrder = entity.DisplayOrder;
            product.Status = entity.Status;
            db.SaveChanges();
            return entity.ID;
        }
        public long UpdateStatus(long productId)
        {
            var product = db.Product.Find(productId);

            product.Status = !product.Status;
            db.SaveChanges();
            return productId;
        }
        public long Delete(long productID)
        {
            var Product = db.Product.Find(productID);
            db.Product.Remove(Product);
            db.SaveChanges();
            return productID;
        }
        public Product GetProductById(long ProductID)
        {
            var product = db.Product.Find(ProductID);
            return product;
        }
    }
}

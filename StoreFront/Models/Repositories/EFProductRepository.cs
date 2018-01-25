using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreFront.Models {
    public class EFProductRepository : IProductRepository
    {
        StoreDbContext db = new StoreDbContext();

        public IQueryable<Product> Products
        { get { return db.Products; } }

        public Product Save(Product Product)
        {
            db.Products.Add(Product);
            db.SaveChanges();
            return Product;
        }

        public Product Edit(Product Product)
        {
            db.Entry(Product).State = EntityState.Modified;
            db.SaveChanges();
            return Product;
        }

        public void Remove(Product Product)
        {
            db.Products.Remove(Product);
            db.SaveChanges();
        }
    }
}
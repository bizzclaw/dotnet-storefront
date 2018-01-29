using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreFront.Models
{
    public class EFStoreFrontRepository : IStoreFrontRepository
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

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public Review Save(Review Review)
        {
            db.Reviews.Add(Review);
            db.SaveChanges();
            return Review;
        }

        public Review Edit(Review Review)
        {
            db.Entry(Review).State = EntityState.Modified;
            db.SaveChanges();
            return Review;
        }

        public void Remove(Review Review)
        {
            db.Reviews.Remove(Review);
            db.SaveChanges();
        }
    }
}
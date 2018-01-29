using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreFront.Models
{
    public class EFReveiwRepository : IReviewRepository
    {
        StoreDbContext db = new StoreDbContext();

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

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand($"DELETE FROM {Review.DbTable}");
        }
    }
}
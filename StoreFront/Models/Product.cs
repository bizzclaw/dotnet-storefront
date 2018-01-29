using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StoreFront.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

        //TODO: This should probably be something to redo later in Javascript (client-side) to support the users local regional currency.
        public virtual string DisplayPrice(string currency)
        {
            var floatPrice = (float) Price;
            return (floatPrice * 0.01).ToString() + currency;
        }

        public virtual double GetAverageRating()
        {
            StoreDbContext db = new StoreDbContext();
            var reviews = from r in db.Reviews
                          select r.Rating;
            List<int> allRatings = reviews.ToList();
            int reviewCount = allRatings.Count();
            if (reviewCount < 1)
            {
                return -1.0;
            }

            int total = 0;
            for (int i = 0; i < reviewCount; i++)
            {
                total += allRatings[i];
            }
            double average = total / reviewCount;
            return average;
        }
    }
}
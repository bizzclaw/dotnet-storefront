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
        public virtual ICollection<Review> Reviews { get; set; }

        //TODO: This should probably be something to redo later in Javascript (client-side) to support the users local regional currency.
        public virtual string DisplayPrice(string currency)
        {
            var floatPrice = (float) Price;
            return (floatPrice * 0.01).ToString() + currency;
        }

        public virtual double GetAverageRating()
        {
            int reviewCount = Reviews != null ? Reviews.Count() : 0;
            if (reviewCount < 1)
            {
                return -1.0;
            }

            int total = 0;
            foreach (Review review in Reviews) {
                total += review.Rating;
            }
            double average = total / reviewCount;
            return average;
        }
    }
}
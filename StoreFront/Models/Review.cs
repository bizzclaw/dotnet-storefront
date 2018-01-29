using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreFront.Models
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        public override bool Equals(object obj)
        {
            Review compared = obj as Review;
            return compared.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

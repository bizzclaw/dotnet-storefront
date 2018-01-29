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
        [NotMapped]
        public static int TitleMaxCharacters = 40;
        [NotMapped]
        public static int TextMaxCharacters = 255;
        [NotMapped]
        public static int RatingMax = 5;

        private string _title;
        private string _text;
        private int _rating;

        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title
        {
            get => _title;
            set => _title = value.Length > TitleMaxCharacters ? value.Substring(0, TitleMaxCharacters) : value;
        }

        public string Text
        {
            get => _text;
            set => _text = value.Length > TextMaxCharacters ? value.Substring(0, TextMaxCharacters) : value;
        }

        public int Rating {
            get => _rating;
            set => _rating = Math.Min(RatingMax, Math.Max(0, value));
        }

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

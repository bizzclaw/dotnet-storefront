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
        private string _title;
        private string _text;
        private int _rating;
        private int _maxStringLength = 255;

        public string ClampString(string str, int clamp)
        {
            return str.Length > clamp ? str.Substring(0, clamp) : str;
        }

        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title {
            get => _title;
            set => _title = ClampString(_title, _maxStringLength);
        }

        public string Text
        {
            get => _text;
            set => _text = ClampString(_text, _maxStringLength);
        }

        public int Rating {
            get => _rating;
            set => _rating = Math.Min(10, Math.Max(0, value));
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

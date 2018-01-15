using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gummi.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        //TODO: This should probably be something to redo later in Javascript (client-side) to support the users local regional currency.
        public virtual string DisplayPrice(string currency)
        {
            var floatPrice = (float) Price;
            return (floatPrice * 0.01).ToString() + currency;
        }
    }
}
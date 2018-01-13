using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gummi.Models
{
    [Table("experiences")]
    public class Experience
    {
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int LocationId { get; set; }
		public virtual Location Location { get; set; }
        public virtual ICollection<Person> People { get; set; }

    }
}

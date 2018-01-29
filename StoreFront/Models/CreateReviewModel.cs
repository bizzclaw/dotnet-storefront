using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreFront.Models
{
    public class CreateReviewModel
    {
        public Product Product { get; set; }
        public Review Review { get; set; }
    }
}

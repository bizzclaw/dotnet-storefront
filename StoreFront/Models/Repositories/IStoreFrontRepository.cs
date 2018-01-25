using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreFront.Models
{
    public interface IStoreFrontRepository
    {
        IQueryable<Product> Products { get; }
        Product Save(Product Product);
        Product Edit(Product Product);
        void Remove(Product Product);

        IQueryable<Review> Reviews { get; }
        Review Save(Review Review);
        Review Edit(Review Review);
        void Remove(Review Review);
    }
}
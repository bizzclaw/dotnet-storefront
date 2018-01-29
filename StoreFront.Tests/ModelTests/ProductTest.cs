using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreFront.Models;
using StoreFront.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StoreFront.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Equals_ProductsHaveSameID_True()
        {
            Product product1 = new Product { Id = 1 };
            Product product2 = new Product { Id = 1 };

            Assert.AreEqual(true, product1.Equals(product2));
        }

        [TestMethod]
        public void Equals_ProductsHaveDifferentID_False()
        {
            Product product1 = new Product { Id = 1 };
            Product product2 = new Product { Id = 2 };

            Assert.AreEqual(false, product1.Equals(product2));
        }

        [TestMethod]
        public void GetAverateRating_CalculatesAverageRating_5()
        {
            Review[] reviews = {
                new Review { Rating = 1},
                new Review { Rating = 3 }
            };

            Product product = new Product { Reviews = reviews };

            Assert.AreEqual(2, product.GetAverageRating());
        }
    }
}

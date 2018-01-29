using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreFront.Models;
using StoreFront.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StoreFront.Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void Equals_ReviewsHaveSameID_True()
        {
            Review product1 = new Review { Id = 1 };
            Review product2 = new Review { Id = 1 };

            Assert.AreEqual(true, product1.Equals(product2));
        }

        [TestMethod]
        public void Equals_ReviewsHaveDifferentID_False()
        {
            Review product1 = new Review { Id = 1 };
            Review product2 = new Review { Id = 2 };

            Assert.AreEqual(false, product1.Equals(product2));
        }
    }
}

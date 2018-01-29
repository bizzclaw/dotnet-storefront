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
            Review review1 = new Review { Id = 1 };
            Review review2 = new Review { Id = 1 };

            Assert.AreEqual(true, review1.Equals(review2));
        }

        [TestMethod]
        public void Equals_ReviewsHaveDifferentID_False()
        {
            Review review1 = new Review { Id = 1 };
            Review review2 = new Review { Id = 2 };

            Assert.AreEqual(false, review1.Equals(review2));
        }

        [TestMethod]
        public void Title_TitleClamped_TitleMaxCharacters()
        {
            Review review1 = new Review { Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor i" };

            Assert.AreEqual(Review.TitleMaxCharacters, review1.Title.Length);
        }

        [TestMethod]
        public void Text_TextClamped_TextMaxCharacters()
        {
            Review review1 = new Review { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor i" };

            Assert.AreEqual(Review.TextMaxCharacters, review1.Text.Length);
        }

        [TestMethod]
        public void Rating_RatingFloored_RatingMax()
        {
            Review review1 = new Review { Rating = Review.RatingMax * 2 };

            Assert.AreEqual(Review.RatingMax, review1.Rating);
        }

        [TestMethod]
        public void Rating_RatingCeiled_0()
        {
            Review review1 = new Review { Rating = -1 };

            Assert.AreEqual(0, review1.Rating);
        }
    }
}

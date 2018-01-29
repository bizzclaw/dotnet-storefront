using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreFront.Models;
using StoreFront.Controllers;
using Moq;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StoreFront.Tests
{
    [TestClass]
    public class EFReviewRepositoryTests
    {
        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
        Mock<IProductRepository> productTestRepo = new Mock<IProductRepository>();

        private void DbSetup()
        {

            Review[] testReviews = {
                new Review {Id = 1, ProductId = 1, Rating = 7, Title = "Amazing RPG", Text = "I really liked this game, I just wish it was more true to the original"},
                new Review {Id = 2, ProductId = 1, Rating = 5, Title = "New Vegas is Better", Text = "New vegas has everything this has, but more and better. Get that one instead."}
            };

            mock.Setup(m => m.Reviews).Returns(testReviews.AsQueryable());

            productTestRepo.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {Id = 1, Name = "Fallout 3", Price = 1499, Reviews = testReviews},
            }.AsQueryable());
        }

        [TestMethod]
        public void ProductsController_DetailModelContainsCorrectData_ReviewList()
        {
            //Arrange

            DbSetup();


            ProductsController controller = new ProductsController();


            IActionResult actionResult = controller.Details(1);

            ViewResult indexView = new ProductsController(productTestRepo.Object, mock.Object).Details(1) as ViewResult;

            //Act
            var result = indexView.ViewData.Model as Product;

            //Assert
            Assert.IsInstanceOfType(result.Reviews, typeof(Review[]));
        }
    }
}
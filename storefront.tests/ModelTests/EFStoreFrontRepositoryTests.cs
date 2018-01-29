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
    public class RepoTests
    {
        Mock<IStoreFrontRepository> mock = new Mock<IStoreFrontRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {Id = 1, Name = "Fallout 3", Description = "Okay I guess", Price = 1499 },
                new Product {Id = 2, Name = "Fallout New Vegas", Description = "Best game in the series", Price = 1499 },
                new Product {Id = 3, Name = "Fallout 3", Description = "Worst \"Fallout\" game, best \"Shooter\"", Price = 1499 },
            }.AsQueryable());

            mock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review {Id = 1, ProductId = 1, Rating = 7, Title = "Amazing RPG", Text = "I really liked this game, I just wish it was more true to the original"},
                new Review {Id = 1, ProductId = 1, Rating = 5, Title = "New Vegas is Better", Text = "New vegas has everything this has, but more and better. Get that one instead."}

            }.AsQueryable());
        }

        [TestMethod]
        public void ProductsController_IndexModelContainsCorrectData_List()
        {
            //Arrange

            DbSetup();


            ProductsController controller = new ProductsController();
            IActionResult actionResult = controller.Index();
            ViewResult indexView = new ProductsController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }
    }
}
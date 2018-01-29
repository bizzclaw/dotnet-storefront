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
    public class EFProductRepositoryTests
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {Id = 1, Name = "Fallout 3", Description = "Okay I guess", Price = 1499 },
                new Product {Id = 2, Name = "Fallout New Vegas", Description = "Best game in the series", Price = 1499 },
                new Product {Id = 3, Name = "Fallout 3", Description = "Worst \"Fallout\" game, best \"Shooter\"", Price = 1499 },
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
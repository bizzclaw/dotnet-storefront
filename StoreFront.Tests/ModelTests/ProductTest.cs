using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreFront.Models;
using StoreFront.Controllers;

namespace StoreFront.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void ProductsController_IndexModelContainsCorrectData_List()
        {
            //Arrange
            ProductsController controller = new ProductsController();
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }
    }
}

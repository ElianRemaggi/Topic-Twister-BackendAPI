using BackendAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace APITests.Controllers
{
    public class CategoryControllerTest
    {
        CategoryController categoryController;

        [SetUp]
        public void Setup()
        {
            categoryController = new CategoryController();
        }

        [Test]
        public void Get_Random_Categories_Should_Return_Ok_Status()
        {
            //Arrange
            //Act
            var result = categoryController.GetRandomCategories();
            var okResult = result as OkObjectResult;
            //Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult?.StatusCode);
            Assert.IsInstanceOf<string>(okResult?.Value);
        }

        [Test]
        public void Get_Random_Categories_Should_Return_Bad_Status_If_Empty()
        {
            //Arrange
            //Act
            var result = categoryController.GetRandomCategories();
            var notFoundResult = result as NotFoundObjectResult;

            //Assert
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(StatusCodes.Status404NotFound, notFoundResult?.StatusCode);
            Assert.IsInstanceOf<string>(notFoundResult?.Value);
        }
    }
}

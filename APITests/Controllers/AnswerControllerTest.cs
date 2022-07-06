using BackendAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace APITests.Controllers
{
    public class AnswerControllerTest
    {
        CategoryController categoryController;
        ICategoryRepository categoryRepository;
        private List<Category> _testCategories = new List<Category>();
        private List<Category> _emptyCategories = new List<Category>();


        [SetUp]
        public void Setup()
        {
            categoryController = new CategoryController();
            
            categoryRepository = Substitute.For<ICategoryRepository>();

            //Category Repository Mocking
            Category testCategory = new Category(1, "TestCategory", new List<string>() { "Answer" });
            _testCategories.Add(testCategory);
            _testCategories.Add(testCategory);
            _testCategories.Add(testCategory);
            _testCategories.Add(testCategory);
            _testCategories.Add(testCategory);
        }
        //Necesitamos _sessionID UserID List<answers>

        [Test]
        public void Get_Random_Categories_Should_Return_Ok_Status()
        {
            //Arrange
            categoryRepository.LoadCategoryList().Returns(_testCategories);
            //Act
            var result = categoryController.GetRandomCategories(categoryRepository);
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
            categoryRepository.LoadCategoryList().Returns(_emptyCategories);

            //Act
            var result = categoryController.GetRandomCategories(categoryRepository);
            var notFoundResult = result as NotFoundObjectResult;

            //Assert
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(StatusCodes.Status404NotFound, notFoundResult?.StatusCode);
            Assert.IsInstanceOf<string>(notFoundResult?.Value);
        }
    }
}

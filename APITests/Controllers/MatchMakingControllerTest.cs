using BackendAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.Controllers
{
    public class MatchMakingControllerTest
    {
        MatchMakingController matchMakingController;

        [SetUp]
        public void Setup()
        {
            matchMakingController = new MatchMakingController();
        }

        //[Test]
        //public void Get_Random_Categories_Should_Return_Ok_Status()
        //{
        //    //Arrange
        //    //Act
        //    var result = matchMakingController;
        //    var okResult = result as OkObjectResult;
        //    //Assert
        //    Assert.IsNotNull(okResult);
        //    Assert.AreEqual(StatusCodes.Status200OK, okResult?.StatusCode);
        //    Assert.IsInstanceOf<string>(okResult?.Value);
        //}

        //[Test]
        //public void Get_Random_Categories_Should_Return_Bad_Status_If_Empty()
        //{
        //    //Arrange
        //    //Act
        //    var result = categoryController.GetRandomCategories();
        //    var notFoundResult = result as NotFoundObjectResult;

        //    //Assert
        //    Assert.IsNotNull(notFoundResult);
        //    Assert.AreEqual(StatusCodes.Status404NotFound, notFoundResult?.StatusCode);
        //    Assert.IsInstanceOf<string>(notFoundResult?.Value);
        //}
    }
}

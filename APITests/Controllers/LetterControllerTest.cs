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
    public class LetterControllerTest
    {
        LetterController letterController;
        [SetUp]
        public void Setup()
        {
            letterController = new LetterController();
        }

        [Test]
        public void Get_Random_Letter_Should_Return_Ok()
        {
            //Arrange
            letterController = new LetterController();
            //Act
            var result = letterController.GetRandomLetter();
            var okResult = result as OkObjectResult;
            //Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

    }
}

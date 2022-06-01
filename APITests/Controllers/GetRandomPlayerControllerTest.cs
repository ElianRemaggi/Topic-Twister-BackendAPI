using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using BackendAPI.Controllers;
using Newtonsoft.Json;

namespace APITests
{
    public class GetRandomPlayerControllerTest
    {
        GetRandomPlayerController getRandomPlayerController;// = new GetRandomPlayerController();

        [SetUp]
        public void Setup()
        {
            getRandomPlayerController = new GetRandomPlayerController();
            //getRandomPlayerController = Substitute.For<GetRandomPlayerController>();

        }

        // 
        [Test]
        public void GetRandomPlayer_Should_Return_IActionResult()
        {
            //Arrange
            IActionResult result;
            //Act
            result = getRandomPlayerController.GetRandomPlayer();
            //Assert
            Assert.IsInstanceOf(typeof(IActionResult), result);
        }

        //[Test]
        //public void GetRandomPlayer_Should_Return_IActionResult_With_Player_Formated_In_Json()
        //{
        //    //Arrange
        //    IActionResult result;
        //    Player player;
        //    //Act
        //    result = getRandomPlayerController.GetRandomPlayer();

        //    //Assert
        //    Assert.AreEqual(player, getRandomPlayerController.GetRandomPlayer());
        //}
    }
}
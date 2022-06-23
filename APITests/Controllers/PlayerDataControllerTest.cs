using BackendAPI.Controllers;
using BackendAPI.Modelo.Repository;
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
    public class PlayerDataControllerTest
    {
        PlayerDataController playerDataController;

        [SetUp]
        public void Setup()
        {
            playerDataController = new PlayerDataController();
        }

        [Test]
        public void Get_Player_Data_By_Id_Should_Return_200_Status_Code()
        {
            //Arrange
            IPlayerRepository playerRepository = new PlayerRepository();
            Player player;
            //Act
            player = playerRepository.GetAllPlayers().First();
            var result = playerDataController.GetPlayerDataByPlayerId(player.UserID);
            var okResult = result as OkObjectResult;
            //Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsInstanceOf<string>(okResult.Value);
        }

        [Test]
        public void Get_Player_Data_By_Id_Should_Return_404_Status_Code_If_Player_Id_Is_Wrong()
        {
            //Arrange
            playerDataController = new PlayerDataController();
            //Act
            var result = playerDataController.GetPlayerDataByPlayerId("PepitoUsuario");
            var notFoundResoult = result as NotFoundObjectResult;

            //Assert
            Assert.IsNotNull(notFoundResoult);
            Assert.AreEqual(StatusCodes.Status404NotFound, notFoundResoult.StatusCode);
            Assert.IsInstanceOf<string>(notFoundResoult.Value);
        }

        [Test]
        public void Get_APlayer_Data_By_Id_Should_Return_200_Status_Code()
        {
            //Arrange
            IPlayerRepository playerRepository = new PlayerRepository();
            Player player;
            //Act
            player = playerRepository.GetAllPlayers().First();
            var result = playerDataController.GetPlayerDataByPlayerId(player.UserID);
            var okResult = result as OkObjectResult;
            //Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsInstanceOf<string>(okResult.Value);
        }
    }
}

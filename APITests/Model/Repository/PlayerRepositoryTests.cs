using BackendAPI.Modelo.Repository;
using BackendAPI.Service;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace APITests.Repository
{
    public class PlayerRepositoryTests
    {
        private IPlayerRepository _playerRepository;

        Player _playerOne = new Player("eremaggi", new PlayerData(1, "Elian"));
        Player _playerTwo = new Player("lgarcia", new PlayerData(3, "Luis"));
        Player _playerThree = new Player("pepito", new PlayerData(7, "Pepe"));
        Player _playerFour = new Player("juan", new PlayerData(20, "Juan"));
        Player _playerFive = new Player("jesus", new PlayerData(34, "Jesus"));
        Player _playerSix = new Player("seba", new PlayerData(84, "Sebastian"));

        [SetUp]
        public void Setup()
        {
            _playerRepository = new PlayerRepository(PathProvider.GetPlayersJsonPath());
        }
        //

        [Test]
        public void If_Player_Is_Looking_For_Match_Should_Be_Return_True_Looking_For_Match()
        {
            //Arrange
            //Act
            _playerRepository.UpdatePlayerLookingForMatch(_playerOne.UserID, true);
            //Assert
            Assert.IsTrue(_playerRepository.FindPlayerById(_playerOne.UserID).LookingForMatch);
        }
    }
}
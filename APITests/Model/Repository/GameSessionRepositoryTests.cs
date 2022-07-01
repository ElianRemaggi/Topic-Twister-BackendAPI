using BackendAPI.Modelo.Repository;
using BackendAPI.UseCases.MatchMaking;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace APITests.Repository
{
    public class GameSessionRepositoryTests
    {
        IGameSessionRepository _sessionRepository;
        Player _playerOne = new Player("eremaggi", new PlayerData(1, "Elian"));
        Player _playerTwo = new Player("lgarcia", new PlayerData(3, "Luis"));
        
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SaveGameSession_Should_Add_GameSession_To_GameSessionList()
        {
            //Arrange
            _sessionRepository = new GameSessionRepository(@"C:\Proyectos_Unity\Topic-Twister-BackendAPI\APITests\TestData\test_sessions.json");
            //Act
            int lastSessionIdBeforeSave = _sessionRepository.GetLastSessionId();
            int newSessionId = lastSessionIdBeforeSave + 1;
            GameSession newGameSession = new GameSession(_playerOne, _playerTwo, newSessionId);
            _sessionRepository.SaveGameSession(newGameSession);
            //Assert
            Assert.AreEqual(lastSessionIdBeforeSave+1, _sessionRepository.GetLastSessionId());
        }
    }
}
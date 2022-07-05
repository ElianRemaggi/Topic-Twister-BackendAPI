using BackendAPI.UseCases.MatchMaking;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace APITests.UseCases

{
    public class FindOpenGameSessionUseCaseTests
    {
        IGameSessionRepository _sessionRepo;

        Player _player1;
        Player _player2;

        [SetUp]
        public void Setup()
        {
            _sessionRepo = Substitute.For<IGameSessionRepository>();

            _player1 = new Player("lgarcia", new PlayerData(1, "Luis"));
            _player2 = new Player("seba", new PlayerData(2, "Sebastian"));

            List<GameSession> testGameSessions = new List<GameSession> { new GameSession(_player1, _player2, 1) };
            _sessionRepo.GetGameSessions().Returns(testGameSessions);

        }
        [Test]
        public void FindOpenGameSession_Should_Return_A_List_Of_GameSession()
        {
            //Arrange
            FindOpenGameSessionUseCase findOpenGameSessionUseCase = new FindOpenGameSessionUseCase(_sessionRepo);
            //Act
            //Assert
            Assert.IsInstanceOf <List< GameSession>>(findOpenGameSessionUseCase.Execute(_player1.UserID));
        }

        [Test]
        public void FindOpenGameSession_Should_Return_A_List_Of_GameSession_For_A_Given_Player_ID()
        {
            //Arrange
            FindOpenGameSessionUseCase findOpenGameSessionUseCase = new FindOpenGameSessionUseCase(_sessionRepo);
            //Act
            List<GameSession> gameSessions = findOpenGameSessionUseCase.Execute(_player1.UserID);
            //Assert

            Assert.IsNotEmpty(gameSessions);
            foreach (var session in gameSessions)
            {
                if (_player1.UserID == session.Player1.UserID)
                    Assert.AreEqual(_player1.UserID, session.Player1.UserID);
                else if (_player1.UserID == session.Player2.UserID)
                    Assert.AreEqual(_player1.UserID, session.Player2.UserID);
            }
        }

    }
}
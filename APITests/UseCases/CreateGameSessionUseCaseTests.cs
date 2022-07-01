using BackendAPI.UseCases.MatchMaking;
using NUnit.Framework;
using NSubstitute;

namespace APITests.UseCases

{
    public class CreateGameSessionUseCaseTests
    {
        IGameSessionRepository _sessionRepository;
        Player _player1;
        Player _player2;

        [SetUp]
        public void Setup()
        {
            _sessionRepository = Substitute.For<IGameSessionRepository>();
            _player1 = new Player("eremaggi", new PlayerData(1, "Elian"));
            _player2 = new Player("lgarcia", new PlayerData(2, "Luis"));
            
        }
        [Test]
        public void CreateGameSession_Should_Return_A_New_GameSession()
        {
            //Arrange
            CreateGameSessionUseCase createGameSession = new CreateGameSessionUseCase(_sessionRepository);
            //Act
            //Assert
            Assert.IsInstanceOf<GameSession>(createGameSession.Execute(_player1,_player2));
        }

        [Test]
        public void CreateGameSession_Should_Return_A_New_GameSession_With_Last_ID()
        {
            //Arrange
            _sessionRepository.GetLastSessionId().Returns(2);
            CreateGameSessionUseCase createGameSession = new CreateGameSessionUseCase(_sessionRepository);
            //Act
            //Assert
            Assert.AreEqual(3, createGameSession.Execute(_player1, _player2).SessionID);
        }

    }
}
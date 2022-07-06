using BackendAPI.UseCases.MatchMaking;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace APITests.UseCases

{
    public class UpdatePlayerAnswersUseCaseTests
    {
        IGameSessionRepository _gameSessionRepo;
        string _userID = "eremaggi";
        int _sessionID = 0;
        List<Answer> _answers = new List<Answer>();

        [SetUp]
        public void Setup()
        {
            _gameSessionRepo = Substitute.For<IGameSessionRepository>();
        }
       
        [Test]
        public void UpdatePlayerAnwers_Should_Call_UpdateAnswers_Method_From_Repository()
        {
            //Arrange
            //Act
            UpdatePlayerAnswersUseCase updatePlayerAnswersUseCase = new UpdatePlayerAnswersUseCase(_gameSessionRepo);
            updatePlayerAnswersUseCase.Execute(_userID,_sessionID,_answers);
            //Assert
            _gameSessionRepo.Received().UpdateAnswers(_userID, _sessionID, _answers);
        }

    }
}
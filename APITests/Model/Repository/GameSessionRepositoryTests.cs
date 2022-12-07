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
        List<Answer> _testAnswers = new List<Answer>();
        private List<Category> _testCategories = new List<Category>();

        [SetUp]
        public void Setup()
        {
            _testAnswers = new List<Answer> { new Answer("Answer1", false),
                                              new Answer("Answer2", false),
                                              new Answer("Answer3", false),
                                              new Answer("Answer4", false),
                                              new Answer("Answer5", false)};

            //Category Repository Mocking
            Category testCategory = new Category(1, "TestCategory", new List<string>() { "Answer" });

            _testCategories.Add(testCategory);
            _testCategories.Add(testCategory);
            _testCategories.Add(testCategory);
            _testCategories.Add(testCategory);
            _testCategories.Add(testCategory);
        }

        [Test]
        public void SaveGameSession_Should_Add_GameSession_To_GameSessionList()
        {
            //Arrange
            _sessionRepository = new GameSessionRepository(@"C:\Users\Elian\Desktop\Workstation\Topic-Twister-BackendAPI\APITests\TestData\test_sessions.json");
            //Act
            int lastSessionIdBeforeSave = _sessionRepository.GetLastSessionId();
            int newSessionId = lastSessionIdBeforeSave + 1;
            GameSession newGameSession = new GameSession(_playerOne, _playerTwo, newSessionId);
            _sessionRepository.SaveGameSession(newGameSession);
            //Assert
            Assert.AreEqual(lastSessionIdBeforeSave+1, _sessionRepository.GetLastSessionId());
        }

        [Test]
        public void UpdateAnswers_Should_Fill_Answer_List_For_Given_UserId_And_Session_ID()
        {
            //Arrange
            _sessionRepository = new GameSessionRepository(@"C:\Users\Elian\Desktop\Workstation\Topic-Twister-BackendAPI\APITests\TestData\test_sessions.json");
            
            //Act
            int lastSessionIdBeforeSave = _sessionRepository.GetLastSessionId();
            int newSessionId = lastSessionIdBeforeSave + 1;
            GameSession newGameSession = new GameSession(_playerOne, _playerTwo, newSessionId);

            Round testRound = new Round(_testCategories, 1, 'A');
            newGameSession.CurrentRound = testRound;
            newGameSession.MatchRounds.Add(testRound);

            _sessionRepository.SaveGameSession(newGameSession);
            _sessionRepository.UpdateAnswers(_playerOne.UserID,newGameSession.SessionID,_testAnswers);
            GameSession testSession = _sessionRepository.GetGameSessionByID(newSessionId);
            
            //Assert
            Assert.AreEqual(_testAnswers, testSession.MatchRounds[testSession.MatchRounds.Count-1].Player1Answers);
        }

        [Test]
        public void GetGameSessionByID_Should_Return_Corresponding_GameSession()
        {
            //Arrange
            _sessionRepository = new GameSessionRepository(@"C:\Users\Elian\Desktop\Workstation\Topic-Twister-BackendAPI\APITests\TestData\test_sessions.json");
            //Act
            int lastSessionIdBeforeSave = _sessionRepository.GetLastSessionId();
            int newSessionId = lastSessionIdBeforeSave + 1;
            GameSession newGameSession = new GameSession(_playerOne, _playerTwo, newSessionId);
            _sessionRepository.SaveGameSession(newGameSession);

            GameSession result = _sessionRepository.GetGameSessionByID(newSessionId);
            //Assert
            Assert.AreEqual(newSessionId, result.SessionID);
        }
    }
}
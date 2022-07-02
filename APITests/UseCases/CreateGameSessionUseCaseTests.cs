using BackendAPI.UseCases.MatchMaking;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace APITests.UseCases

{
    public class CreateGameSessionUseCaseTests
    {
        IGameSessionRepository _sessionRepo;
        ICategoryRepository _categoryRepo;
        ILetterRepository _letterRepo;

        private List<Category> _mockCategoryList;

        Player _player1;
        Player _player2;

        [SetUp]
        public void Setup()
        {
            _sessionRepo = Substitute.For<IGameSessionRepository>();
            _letterRepo = Substitute.For<ILetterRepository>();

            _player1 = new Player("eremaggi", new PlayerData(1, "Elian"));
            _player2 = new Player("lgarcia", new PlayerData(2, "Luis"));

            _categoryRepo = Substitute.For<ICategoryRepository>();
            _mockCategoryList = new List<Category>()
                                             { new Category(1,"Países",  new List<string>            {"Alemania", "Argentina", "Angola", "España", "Etiopia", "Eslovaquia", "Japon", "Jamaica", "Jordania", "Oman", "Mexico", "Malasia", "Madagascar" }),
                                               new Category(2,"Nombres", new List<string>            {"Alberto", "Alejandra", "Ana", "Elian", "Esteban", "Emilia", "Jesus", "Juana", "Jessica", "Omar", "Olivia", "Orlando", "Maria", "Manuel", "Marcos"}),
                                               new Category(3,"Comidas", new List<string>            {"Arroz", "Atun", "Almejas", "Ensalada", "Empanada", "Escabeche", "Jalapeño", "Jamon", "Jardinera", "Orejones", "Olivas", "Omelet", "Milanesa", "Mermelada", "Macarrones" } ),
                                               new Category(4,"Animales", new List<string>           {"Araña", "Avestruz", "Aguila", "Escarabajo", "Elefante", "Escorpion", "Jabali", "Jaguar", "Jirafa", "Oruga", "Oso", "Orangutan", "Mamut", "Mono", "Marmota" }),
                                               new Category(5,"Profesiones", new List<string>        {"Arquitecto", "Albañil", "Agricultor", "Escribano", "Electricista", "Escritor", "Juez", "Jardinero", "Joyero", "Obrero", "Orfebre", "Odontologo", "Marinero", "Maquinista", "Mecanico" }),
                                             };

            _categoryRepo = Substitute.For<ICategoryRepository>();
            _categoryRepo.LoadCategoryList().Returns(_mockCategoryList);
        }
        [Test]
        public void CreateGameSession_Should_Return_A_New_GameSession()
        {
            //Arrange
            CreateGameSessionUseCase createGameSession = new CreateGameSessionUseCase(_sessionRepo, _categoryRepo, _letterRepo);
            //Act
            //Assert
            Assert.IsInstanceOf<GameSession>(createGameSession.Execute(_player1,_player2));
        }

        [Test]
        public void CreateGameSession_Should_Return_A_New_GameSession_With_Last_ID()
        {
            //Arrange
            _sessionRepo.GetLastSessionId().Returns(2);
            CreateGameSessionUseCase createGameSession = new CreateGameSessionUseCase(_sessionRepo, _categoryRepo, _letterRepo);
            //Act
            //Assert
            Assert.AreEqual(3, createGameSession.Execute(_player1, _player2).SessionID);
        }

        [Test]
        public void CreateGameSession_Should_Create_The_First_Session_Round()
        {
            //Arrange
            CreateGameSessionUseCase createGameSession = new CreateGameSessionUseCase(_sessionRepo, _categoryRepo, _letterRepo);
            GameSession gameSession = createGameSession.Execute(_player1, _player2);
            //Act
            //Assert
            Assert.IsInstanceOf<Round>(gameSession.CurrentRound);
            Assert.Contains(gameSession.CurrentRound, gameSession.MatchRounds);
        }
    }
}
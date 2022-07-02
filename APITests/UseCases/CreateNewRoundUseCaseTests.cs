using BackendAPI.UseCases.MatchMaking;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace APITests.UseCases

{
    public class CreateNewRoundUseCaseTests
    {
        ICategoryRepository _categoryRepository;
        private List<Category> _mockCategoryList;

        [SetUp]
        public void Setup()
        {
            _categoryRepository = Substitute.For<ICategoryRepository>();
            _mockCategoryList = new List<Category>()
                                             { new Category(1,"Países",  new List<string>            {"Alemania", "Argentina", "Angola", "España", "Etiopia", "Eslovaquia", "Japon", "Jamaica", "Jordania", "Oman", "Mexico", "Malasia", "Madagascar" }),
                                               new Category(2,"Nombres", new List<string>            {"Alberto", "Alejandra", "Ana", "Elian", "Esteban", "Emilia", "Jesus", "Juana", "Jessica", "Omar", "Olivia", "Orlando", "Maria", "Manuel", "Marcos"}),
                                               new Category(3,"Comidas", new List<string>            {"Arroz", "Atun", "Almejas", "Ensalada", "Empanada", "Escabeche", "Jalapeño", "Jamon", "Jardinera", "Orejones", "Olivas", "Omelet", "Milanesa", "Mermelada", "Macarrones" } ),
                                               new Category(4,"Animales", new List<string>           {"Araña", "Avestruz", "Aguila", "Escarabajo", "Elefante", "Escorpion", "Jabali", "Jaguar", "Jirafa", "Oruga", "Oso", "Orangutan", "Mamut", "Mono", "Marmota" }),
                                               new Category(5,"Profesiones", new List<string>        {"Arquitecto", "Albañil", "Agricultor", "Escribano", "Electricista", "Escritor", "Juez", "Jardinero", "Joyero", "Obrero", "Orfebre", "Odontologo", "Marinero", "Maquinista", "Mecanico" }),
                                             };

            _categoryRepository = Substitute.For<ICategoryRepository>();
            _categoryRepository.LoadCategoryList().Returns(_mockCategoryList);
        }

        [Test]
        public void CreateNewRound_Should_Return_A_New_Round()
        {
            //Arrange
            CreateNewRoundUseCase createNewRound = new CreateNewRoundUseCase(_categoryRepository);
            //Act
            //Assert
            Assert.IsInstanceOf<Round>(createNewRound.Execute(1));
        }

        [Test]
        public void CreateNewRound_Should_Return_A_New_Round_With_The_Given_Round_Number()
        {
            //Arrange
            CreateNewRoundUseCase createNewRound = new CreateNewRoundUseCase(_categoryRepository);
            int roundNumber = 1;
            //Act
            Round round = createNewRound.Execute(roundNumber);
            //Assert
            Assert.AreEqual(roundNumber, round.RoundNumber);
        }

        [Test]
        public void CreateNewRound_Should_Return_A_New_Round_With_A_List_Of_Categories()
        {
            //Arrange
            CreateNewRoundUseCase createNewRound = new CreateNewRoundUseCase(_categoryRepository);
            int roundNumber = 1;
            //Act
            Round round = createNewRound.Execute(roundNumber);
            //Assert
            foreach (var category in _mockCategoryList)
            {
                Assert.Contains(category, round.Categories);
            }
        }
    }
}
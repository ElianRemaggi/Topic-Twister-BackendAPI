using BackendAPI.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.Service

{
    public class ServiceProviderTests
    {
        Player _testPlayer;
        [SetUp]
        public void Setup()
        {
            _testPlayer = new Player("1", new PlayerData(3, "Luis", new List<PowerUp>()));
        }

        [Test]
        public void Service_Provider_Should_Be_Able_To_Return_A_Player_When_Find_Player_By_Id()
        {
            //Arrange
            string id = "eremaggi";
            ServiceProvider serviceProvider = new ServiceProvider();
            //Act
            //Assert
            Assert.IsInstanceOf(typeof(Player), serviceProvider.GetPlayerById(id));
        }

        [Test]
        public void Service_Provider_Should_Be_Able_To_Return_A_Player_List_Looking_For_Match()
        {
            //Arrange
            ServiceProvider serviceProvider = new ServiceProvider();
            //Act
            //Assert
            Assert.IsInstanceOf(typeof(List<Player>), serviceProvider.FindPlayersLookingForMatch());
        }

        [Test]
        public void Service_Provider_Should_Be_Able_To_Return_A_Player_List()
        {
            //Arrange
            ServiceProvider serviceProvider = new ServiceProvider();
            //Act
            //Assert
            Assert.IsInstanceOf(typeof(List<Player>), serviceProvider.GetAllPlayers());
        }

        [Test]
        public void Service_Provider_Should_Be_Able_To_Return_A_Random_Category_List()
        {
            //Arrange
            ServiceProvider serviceProvider = new ServiceProvider();
            //Act
            //Assert
            Assert.IsTrue(serviceProvider.GetRandomCategorys().Count > 0);
        }
    }
}
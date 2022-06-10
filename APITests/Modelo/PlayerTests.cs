using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace APITests
{
    public class PlayerTests
    {
        PlayerData playerData;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public static void Player_Should_Get_One_More_Win_If_Use_AddVictory_Method()
        {
            //Arrange
            Player player = new Player("hola", new PlayerData(1, "hola", new List<PowerUp>()));
            int oldWinAmount = player.GetVictories();
            //Act
            player.AddVictory();
            //Assert
            Assert.AreEqual(oldWinAmount+1,player.PlayerData.WinsAmount);
        }
    }
}
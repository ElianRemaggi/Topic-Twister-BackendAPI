using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NSubstitute;

namespace ModelTests
{
    public class MatchMakingTests
    {
        PlayerData _playerData;
        IPlayerRepository _playerRepository;

        [SetUp]
        public void Setup()
        {
             //RepositoryServiceLocator.GetPlayerRepository().FindPlayerById("1").PlayerData;
            _playerRepository = Substitute.For<IPlayerRepository>();
            _playerData = _playerRepository.FindPlayerById("eremaggi").PlayerData;
        }

        // Cuando un player busca una partida, sera añadido a una lista de players que buscan partida

        //[Test]
        //public void If_Player_Is_Looking_For_Match_Should_Be_Added_To_MatchMaking_List()
        //{
        //    //Arrange
        //    MatchMaking matchMaking = new MatchMaking();
        //    Player playerLookingForMatch = new Player("1", _playerData);
        //    //Act
        //    matchMaking.AddPlayerLookingForMatch(playerLookingForMatch);
        //    //Assert
        //    Assert.IsTrue(matchMaking.GetPlayersLookingForMatch().Contains(playerLookingForMatch));
        //}

        // Si el jugador esta buscando un oponente, deberá obtener uno que también este buscando una partida

        [Test]
        public void If_Player_Looking_For_Match_Should_Find_Another_Player_Looking_For_Match()
        {
            //Arrange
            MatchMaking matchMaking = new MatchMaking();
            Player playerLookingForMatch1 = _playerRepository.FindPlayerById("eremaggi");
            //Act
            //Assert
            Assert.IsInstanceOf<Player>(matchMaking.FindOpponent(playerLookingForMatch1.UserID));
        }

        // Si el jugador esta buscando una partida,
        // deberia encontrar un oponente con +/- 5 victorias

        [Test]
        public void If_Player_Looking_For_Match_Should_Find_Another_Player_With_5_Victories_Difference()
        {
            //Arrange
            MatchMaking matchMaking = new MatchMaking();
            Player myPlayer = new Player("1", _playerData);
            Player playerLookingForMatch2 = new Player("2", _playerData);
            //Act
            myPlayer.SetVictories(3);
            playerLookingForMatch2.SetVictories(6);
            playerLookingForMatch2.LookingForMatch = true;
            matchMaking.AddPlayerLookingForMatch(playerLookingForMatch2);
            //Assert
            Assert.IsInstanceOf<Player>(matchMaking.FindOpponent(myPlayer));
        }


        // Si el jugador esta buscando una partida y no cumple condicion anterior,
        // deberia encontrar un oponente con menos de 5 victorias

        [Test]
        public void If_Previous_Test_Not_Met_Find_Another_Player_With_Less_Than_5_Victories_Than_The_Player()
        {
            //Arrange
            MatchMaking matchMaking = new MatchMaking();
            Player myPlayer = new Player("1", _playerData);
            Player playerLookingForMatch2 = new Player("2", _playerData);
            Player playerLookingForMatch3 = new Player("3", _playerData);

            //Act
            myPlayer.SetVictories(10);
            playerLookingForMatch2.SetVictories(1);
            playerLookingForMatch3.SetVictories(2);

            playerLookingForMatch2.LookingForMatch = true;
            playerLookingForMatch3.LookingForMatch = true;
            matchMaking.AddPlayerLookingForMatch(playerLookingForMatch2);
            //Assert
            Assert.IsInstanceOf<Player>(matchMaking.FindOpponent(myPlayer));
        }

        // Si el jugador esta buscando una partida y no cumple condicion anterior,
        // deberia encontrar un oponente al azar

        [Test]
        public void If_Previous_Two_Tests_Not_Met_Find_Random_Player()
        {
            //Arrange
            MatchMaking matchMaking = new MatchMaking();
            Player myPlayer = new Player("1", _playerData);
            Player playerLookingForMatch2 = new Player("2", _playerData);
            Player playerLookingForMatch3 = new Player("3", _playerData);

            //Act
            myPlayer.SetVictories(100);
            playerLookingForMatch2.SetVictories(1);
            playerLookingForMatch3.SetVictories(2);

            playerLookingForMatch2.LookingForMatch = true;
            playerLookingForMatch3.LookingForMatch = true;
            matchMaking.AddPlayerLookingForMatch(playerLookingForMatch2);
            //Assert
            Assert.IsInstanceOf<Player>(matchMaking.FindOpponent(myPlayer));
        }

        //Si no hay jugadores buscando una partida, no encontrará ningún oponente

        [Test]
        public void If_No_Players_Looking_For_Match_Cant_Find_Any_Opponent()
        {
            //Arrange
            MatchMaking matchMaking = new MatchMaking();
            Player myPlayer = new Player("1", _playerData);
            //Act
            //RepositoryServiceLocator.GetPlayerRepository().ClearPlayerRepository();
            //Assert
            Assert.Throws<Exception>(() => matchMaking.FindOpponent(myPlayer));
        }


    }
}
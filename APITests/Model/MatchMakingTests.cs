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
        List<Player> _playersLookingForMatch;
        IPlayerRepository _playerRepository;

        Player _playerOne = new Player("eremaggi", new PlayerData(1, "Elian"));
        Player _playerTwo = new Player("lgarcia", new PlayerData(3, "Luis"));
        Player _playerThree = new Player("pepito", new PlayerData(7, "Pepe"));
        Player _playerFour = new Player("juan", new PlayerData(20, "Juan"));
        Player _playerFive = new Player("jesus", new PlayerData(34, "Jesus"));
        Player _playerSix = new Player("seba", new PlayerData(84, "Sebastian"));

        [SetUp]
        public void Setup()
        {
            _playerRepository = Substitute.For<IPlayerRepository>();
        }

        // Si el jugador esta buscando una partida,
        // deberia encontrar un oponente con +/- 5 victorias

        [Test]
        public void If_Player_Looking_For_Match_Should_Find_Another_Player_With_5_Victories_Difference()
        {
            //Arrange
            _playersLookingForMatch = new List<Player> { _playerOne, _playerTwo };
            _playerRepository.FindPlayerById("eremaggi").Returns(_playerOne);
            _playerRepository.FindPlayersLookingForMatch().Returns(_playersLookingForMatch);

            MatchMaking matchMaking = new MatchMaking(_playerRepository);
            Player opponentPlayer;

            //Act 
            opponentPlayer = matchMaking.FindOpponent(_playerOne.UserID);
            
            //Assert
            Assert.AreEqual(_playerTwo, opponentPlayer);
        }


        // Si el jugador esta buscando una partida y no cumple condicion anterior,
        // deberia encontrar un oponente con menos de 5 victorias

        [Test]
        public void If_Previous_Test_Not_Met_Find_Another_Player_With_Less_Than_5_Victories_Than_The_Player()
        {
            //Arrange
            _playersLookingForMatch = new List<Player> { _playerOne, _playerThree };
            _playerRepository.FindPlayerById("pepito").Returns(_playerThree);
            _playerRepository.FindPlayersLookingForMatch().Returns(_playersLookingForMatch);

            MatchMaking matchMaking = new MatchMaking(_playerRepository);
            Player opponentPlayer;

            //Act
            opponentPlayer = matchMaking.FindOpponent(_playerThree.UserID);

            //Assert
            Assert.AreEqual(_playerOne, opponentPlayer);
        }

        // Si el jugador esta buscando una partida y no cumple condicion anterior,
        // deberia encontrar un oponente al azar

        [Test]
        public void If_Previous_Two_Tests_Not_Met_Find_Random_Player()
        {
            //Arrange
            _playersLookingForMatch = new List<Player> { _playerOne, _playerThree, _playerFour, _playerFive, _playerSix };
            _playerRepository.FindPlayerById("eremaggi").Returns(_playerOne);
            _playerRepository.FindPlayersLookingForMatch().Returns(_playersLookingForMatch);
            
            List<Player> expectedPlayers = new List<Player> {_playerThree, _playerFour, _playerFive, _playerSix };

            MatchMaking matchMaking = new MatchMaking(_playerRepository);
            Player opponentPlayer;

            //Act
            opponentPlayer = matchMaking.FindOpponent(_playerOne.UserID);

            //Assert
            Assert.Contains(opponentPlayer, expectedPlayers);
        }

        //Si no hay jugadores buscando una partida, devolver excepción

        [Test]
        public void If_No_Players_Looking_For_Match_Cant_Find_Any_Opponent()
        {
            //Arrange
            _playersLookingForMatch = new List<Player> { _playerOne };
            _playerRepository.FindPlayerById("eremaggi").Returns(_playerOne);
            _playerRepository.FindPlayersLookingForMatch().Returns(_playersLookingForMatch);

            MatchMaking matchMaking = new MatchMaking(_playerRepository);

            //Act

            //Assert
            Assert.Throws<Exception>(() => matchMaking.FindOpponent(_playerOne.UserID));
        }
    }
}
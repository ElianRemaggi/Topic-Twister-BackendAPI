using BackendAPI.Modelo.Repository;
using System;
using System.Collections.Generic;


public class MatchMaking
{
    private List<Player> _playersLookingForMatch = new List<Player>();
    private IPlayerRepository _playerRepository;

    public MatchMaking(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    //public List<Player> GetPlayersLookingForMatch()
    //{        
    //    return _playerRepository.GetAllPlayers();
    //}

    public Player FindOpponent(string playerID) //Podria ser un caso de uso
    {
        try
        {
            Player clientPlayer = _playerRepository.FindPlayerById(playerID);
            _playersLookingForMatch = _playerRepository.FindPlayersLookingForMatch();

            if (_playersLookingForMatch.Count == 0)
                throw new Exception("No se ha encontrado ningún oponente");

            _playersLookingForMatch.Remove(clientPlayer);

            foreach (var playerLooking in _playersLookingForMatch)
            {
                if (Math.Abs(clientPlayer.PlayerData.WinsAmount - playerLooking.PlayerData.WinsAmount) <= 5)
                    return playerLooking;
            }

            foreach (var playerLooking in _playersLookingForMatch)
            {
                if (clientPlayer.PlayerData.WinsAmount > playerLooking.PlayerData.WinsAmount + 5)
                    return playerLooking;
            }

            Random rand = new Random();
            return _playersLookingForMatch[rand.Next(0, _playersLookingForMatch.Count)];

        }
        catch (Exception e)
        {
            throw new Exception("MatchMaking.FindOpponent(String) Error = " + e.Message);
        }
        throw new Exception("No se ha encontrado ningún oponente");
    }
}

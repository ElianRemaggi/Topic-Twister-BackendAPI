using BackendAPI.Modelo.Repository;
using System;
using System.Collections.Generic;


public class MatchMaking
{
    private List<Player> _playersLookingForMatch = new List<Player>();
    private IPlayerRepository _playerRepository;
    private int _timeout = 3000;
    private int _timeStep = 1500;
    private int _currentTime;

    public MatchMaking(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    //public List<Player> GetPlayersLookingForMatch()
    //{        
    //    return _playerRepository.GetAllPlayers();
    //}

    public async Task<Player> FindOpponent(string playerID) //Podria ser un caso de uso
    {
        try
        {
            Player clientPlayer = _playerRepository.FindPlayerById(playerID);
            Player opponentPlayer;
            _playerRepository.UpdatePlayerLookingForMatch(playerID);

            while (_currentTime<_timeout)
            {
                _playersLookingForMatch = _playerRepository.FindPlayersLookingForMatch();
                opponentPlayer = PlayerMatchup(clientPlayer);
                _currentTime += _timeStep;

                if (opponentPlayer != null)
                    return opponentPlayer;

                await Task.Delay(_timeStep);
            }

            throw new Exception("Opponent Not Found");

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    private Player PlayerMatchup(Player clientPlayer)
    {
        _playersLookingForMatch.Remove(clientPlayer);

        //if (_playersLookingForMatch.Count == 0)
        //    throw new Exception("Opponent Not Found");

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

        if (_playersLookingForMatch.Count != 0)
            return _playersLookingForMatch[rand.Next(0, _playersLookingForMatch.Count)];
        else
            return null;
    }
}

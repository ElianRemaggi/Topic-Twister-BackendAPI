using BackendAPI.Modelo.Repository;
using System;
using System.Collections.Generic;


public class MatchMaking
{
    private IPlayerRepository _playerRepository;
    private int _timeout = 6000;
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
            //_playerRepository.UpdatePlayerLookingForMatch(playerID, true);
            List<Player> playersLookingForMatch = new List<Player>();


            while (_currentTime<_timeout)
            {
                playersLookingForMatch = _playerRepository.FindPlayersLookingForMatch();
                opponentPlayer = PlayerMatchup(clientPlayer, playersLookingForMatch);
                _currentTime += _timeStep;

                if (opponentPlayer != null)
                {
                    //_playerRepository.UpdatePlayerLookingForMatch(playerID, false);
                    return opponentPlayer;
                }

                await Task.Delay(_timeStep);
            }

            //_playerRepository.UpdatePlayerLookingForMatch(playerID, false);
            throw new Exception("Opponent Not Found");

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    private Player PlayerMatchup(Player clientPlayer, List<Player> playersLookingForMatch)
    {
        playersLookingForMatch.Remove(playersLookingForMatch.Single(s => s.UserID == clientPlayer.UserID));

        if (playersLookingForMatch.Count == 0)
            return null;

        //if (_playersLookingForMatch.Count == 1 && _playersLookingForMatch[0].UserID == clientPlayer.UserID)
        //    return null;

        foreach (var playerLooking in playersLookingForMatch)
        {
            if (Math.Abs(clientPlayer.PlayerData.WinsAmount - playerLooking.PlayerData.WinsAmount) <= 5)
                return playerLooking;
        }

        foreach (var playerLooking in playersLookingForMatch)
        {
            if (clientPlayer.PlayerData.WinsAmount > playerLooking.PlayerData.WinsAmount + 5)
                return playerLooking;
        }

        Random rand = new Random();

        if (playersLookingForMatch.Count != 0)
            return playersLookingForMatch[rand.Next(0, playersLookingForMatch.Count)];
        else
            return null;
    }
}

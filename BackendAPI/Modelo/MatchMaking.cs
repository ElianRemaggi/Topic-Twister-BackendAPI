using BackendAPI.Modelo.Repository;
using System;
using System.Collections.Generic;


public class MatchMaking
{
    private List<Player> _playersLookingForMatch = new List<Player>();

    public List<Player> GetPlayersLookingForMatch(IPlayerRepository playerRepository)
    {        
        return playerRepository.GetAllPlayers();
    }

    public Player FindOpponent(string playerID) //Podria ser un caso de uso
    {
        try { 
        IPlayerRepository playerRepository = new PlayerRepository();
        

        Player clientPlayer = playerRepository.FindPlayerById(playerID);

        _playersLookingForMatch = GetPlayersLookingForMatch(playerRepository);
        
        if (_playersLookingForMatch.Count == 0)
            throw new Exception("No se ha encontrado ningún oponente");

        _playersLookingForMatch.Remove(clientPlayer);

        foreach (var playerLooking in _playersLookingForMatch)
        {
            if (playerLooking.UserID == clientPlayer.UserID)
                continue;

            if (Math.Abs(clientPlayer.GetVictories() - playerLooking.GetVictories()) <= 5)
                return playerLooking;
        }

        foreach (var playerLooking in _playersLookingForMatch)
        {
            if (playerLooking.UserID == clientPlayer.UserID)
                continue;

            if (clientPlayer.GetVictories() > playerLooking.GetVictories() + 5)
                return playerLooking;
        }
        Random rand = new Random();
            Console.WriteLine("Cae en el ultimo return");
        return _playersLookingForMatch[rand.Next(0, _playersLookingForMatch.Count)];
        } catch(Exception e)
        {
            throw new Exception("MatchMaking.FindOpponent(String) Error = " + e.Message);
        }
        throw new Exception("No se ha encontrado ningún oponente");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPlayerRepository
{
    public Player FindPlayerById(string ID);
    public List<Player> FindPlayersLookingForMatch();
    public void UpdatePlayerData(string playerId, PlayerData playerData);
    public List<Player> GetPlayerRepository();
    public List<Player> GetAllPlayers();
    public void UpdatePlayerLookingForMatch(string playerID);
}


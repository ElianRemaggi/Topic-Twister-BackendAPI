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
    public void ClearPlayerRepository();
    public void UpdateRepositoryData(List<Player> playerList);
}


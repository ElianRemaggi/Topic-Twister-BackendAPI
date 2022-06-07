using Newtonsoft.Json;

namespace BackendAPI.Modelo.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        public List<Player> _playerList = new List<Player>();

        public PlayerRepository()
        {
            ClearPlayerRepository();
        }

        public void ClearPlayerRepository()
        {
            string path = @"data\players.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();

                Player[] players = JsonConvert.DeserializeObject<Player[]>(json);
                _playerList = players.ToList();
            }
        }

        public Player FindPlayerById(string ID)
        {
            Player playerFound;
            playerFound = _playerList.FirstOrDefault(q => q.UserID == ID);

            if (playerFound != null)
                return playerFound;
            else
                throw new Exception("Player Not Found");
        }

        public List<Player> FindPlayersLookingForMatch()
        {
            List<Player> playersLookingForMatch = new List<Player>();

            foreach(var p in _playerList)
            {
                if (p.LookingForMatch) playersLookingForMatch.Add(p);
            }

            return playersLookingForMatch;
        }

        public List<Player> GetAllPlayers()
        {
            return _playerList;
        }

        public void UpdatePlayerData(string playerId, PlayerData playerData)
        {
            FindPlayerById(playerId).PlayerData = playerData;
        }

    }
}

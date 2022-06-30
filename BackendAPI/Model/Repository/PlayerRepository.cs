using Newtonsoft.Json;

namespace BackendAPI.Modelo.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        public List<Player> _playerList = new List<Player>();

        public PlayerRepository()
        {
            _playerList = GetPlayerRepository();
        }

        public List<Player> GetPlayerRepository()
        {
            string path = @"data\players.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();

                Player[] players = JsonConvert.DeserializeObject<Player[]>(json);
                return players.ToList();
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

            _playerList = GetPlayerRepository();

            foreach (var player in _playerList)
            {
                if (player.LookingForMatch) playersLookingForMatch.Add(player);
            }

            return playersLookingForMatch;
        }

        public List<Player> GetAllPlayers()
        {
            return _playerList;
        }

        public void UpdatePlayerData(string playerId, PlayerData playerData)
        {
            try { 
            FindPlayerById(playerId).PlayerData = playerData;
            string json = JsonConvert.SerializeObject(this._playerList);
            string path = @"data\players.json";
            System.IO.File.WriteAllText(path, json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString()) ;
                throw;
            }

        }

        public void UpdatePlayerLookingForMatch(string playerID)
        {
            try
            {
                Player playerFound;
                playerFound = _playerList.FirstOrDefault(q => q.UserID == playerID);
                playerFound.LookingForMatch = true;
                string json = JsonConvert.SerializeObject(this._playerList);
                string path = @"data\players.json";
                System.IO.File.WriteAllText(path, json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}

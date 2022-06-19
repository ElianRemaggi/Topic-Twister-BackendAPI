using BackendAPI.Modelo.Repository;

namespace BackendAPI.Service
{
    public class ServiceProvider
    {
        IPlayerRepository playerRepository;

        public Player GetPlayerById(string id)
        {
            playerRepository = new PlayerRepository();
            return playerRepository.FindPlayerById(id);
        }

        public List<Player> FindPlayersLookingForMatch()
        {
            playerRepository = new PlayerRepository();
            return playerRepository.FindPlayersLookingForMatch();
        }

        public List<Player> GetAllPlayers()
        {
            playerRepository = new PlayerRepository();
            return playerRepository.GetAllPlayers();
        }
    }
}

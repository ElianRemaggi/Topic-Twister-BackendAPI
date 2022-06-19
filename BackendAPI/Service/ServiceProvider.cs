using BackendAPI.Modelo.Repository;

namespace BackendAPI.Service
{
    public class ServiceProvider
    {

        public Player GetPlayerById(string id)
        {
            IPlayerRepository playerRepository;
            playerRepository = new PlayerRepository();
            return playerRepository.FindPlayerById(id);
        }

    }
}

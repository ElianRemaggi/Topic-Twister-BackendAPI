using BackendAPI.Modelo.Repository;
using BackendAPI.Modelo.UseCases;

namespace BackendAPI.Service
{
    public class ServiceProvider
    {
        //Player
        IPlayerRepository playerRepository;
        ICategoryRepository categoryRepository;
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

        //Category

        public List<Category> GetRandomCategorys()
        {
            FindRandomCategoryListUseCase findRandomCategoryListUseCase = new FindRandomCategoryListUseCase(categoryRepository = new CategoryRepository());
            return findRandomCategoryListUseCase.Execute();
        }

        public Category FindCategoryById(int id)
        {
            categoryRepository = new CategoryRepository();
            return categoryRepository.FindCategoryById(id);
        }
    }
}

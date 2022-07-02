using BackendAPI.Modelo.Repository;
using BackendAPI.Service;

public static class RepoLocator
{
    private static CategoryRepository _categoryRepository = new CategoryRepository(PathProvider.GetCategoryJsonPath());
    private static PlayerRepository _playerRepository = new PlayerRepository(PathProvider.GetPlayersJsonPath());
    private static LetterRepository _letterRepository = new LetterRepository(PathProvider.GetLetterJsonPath());
    private static GameSessionRepository _gameSessionRepository = new GameSessionRepository(PathProvider.GetGameSessionJsonPath());

    public static ICategoryRepository GetCategoryRepo()
    {
        return _categoryRepository;
    }

    public static IPlayerRepository GetPlayerRepo()
    {
        return _playerRepository;
    }

    public static ILetterRepository GetLetterRepo()
    {
        return _letterRepository;
    }

    public static IGameSessionRepository GetGameSessionRepo()
    {
        return _gameSessionRepository;
    }
}

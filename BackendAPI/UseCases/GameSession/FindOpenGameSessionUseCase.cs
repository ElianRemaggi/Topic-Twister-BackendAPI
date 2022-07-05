using BackendAPI.Modelo.UseCases;

public class FindOpenGameSessionUseCase
{
    private IGameSessionRepository _gameSessionRepo;


    public FindOpenGameSessionUseCase(IGameSessionRepository gameSessionRepo)
    {
        _gameSessionRepo = gameSessionRepo;
    }

    public List<GameSession> Execute(string UserID)
    {
        List<GameSession> gameSessions = _gameSessionRepo.GetGameSessions();
        List<GameSession> results = new List<GameSession>();
        foreach (var session in gameSessions)
        {
            if (session.Player1.UserID == UserID || session.Player2.UserID == UserID)
                results.Add(session);
        }

        return results;
    }
}
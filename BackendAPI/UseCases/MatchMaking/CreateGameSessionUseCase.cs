namespace BackendAPI.UseCases.MatchMaking
{
    public class CreateGameSessionUseCase
    {
        IGameSessionRepository _gameSessionRepository;
        public CreateGameSessionUseCase(IGameSessionRepository gameSessionRepository)
        {
            _gameSessionRepository = gameSessionRepository;
        }

        public GameSession Execute(Player player1, Player player2)
        {
            int newSessionId = _gameSessionRepository.GetLastSessionId() + 1;
            
            GameSession gameSession = new GameSession(player1, player2, newSessionId);
            
            return gameSession;
        }
    }
}

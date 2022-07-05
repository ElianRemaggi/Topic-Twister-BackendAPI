namespace BackendAPI.UseCases.MatchMaking
{
    public class CreateGameSessionUseCase
    {
        private IGameSessionRepository _gameSessionRepository;
        private ICategoryRepository _categoryRepository;
        private ILetterRepository _letterRepository;

        public CreateGameSessionUseCase(IGameSessionRepository gameSessionRepository, ICategoryRepository categoryRepository, ILetterRepository letterRepository)
        {
            _gameSessionRepository = gameSessionRepository;
            _categoryRepository = categoryRepository;
            _letterRepository = letterRepository;
        }

        public GameSession Execute(Player player1, Player player2)
        {
            int newSessionId = _gameSessionRepository.GetLastSessionId() + 1;
            
            GameSession gameSession = new GameSession(player1, player2, newSessionId);

            Round firstRound = new CreateNewRoundUseCase(_categoryRepository, _letterRepository).Execute(1);

            gameSession.CurrentRound = firstRound;
            gameSession.MatchRounds.Add(firstRound);

            _gameSessionRepository.SaveGameSession(gameSession);

            return gameSession;
        }
    }
}

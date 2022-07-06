using BackendAPI.Modelo.UseCases;

public class UpdatePlayerAnswersUseCase
{
    private IGameSessionRepository _sessionRepo;

    public UpdatePlayerAnswersUseCase(IGameSessionRepository sessionRepo)
    {
        _sessionRepo = sessionRepo;
    }

    public void Execute(string userID, int sessionID, List<Answer> answers)
    {
        _sessionRepo.UpdateAnswers(userID, sessionID, answers);
    }
}

using Newtonsoft.Json;

public class GameSessionRepository : IGameSessionRepository
{
    private static List<GameSession> _gameSessions = new List<GameSession>();
    private string _path;
    public GameSessionRepository(string path)
    {
        _path = path;
        LoadGameSessionList();
    }

    private void LoadGameSessionList()
    {
        StreamReader jsonStream = File.OpenText(_path);
        var json = jsonStream.ReadToEnd();
        var gameSessions = JsonConvert.DeserializeObject<List<GameSession>>(json);
        jsonStream.Close();

        if (gameSessions != null)
            _gameSessions = gameSessions;
    }

    public List<GameSession> GetGameSessions()
    {
        return _gameSessions;
    }

    public int GetLastSessionId()
    {
        LoadGameSessionList();
        if (_gameSessions == null)
            return 0;
        else
            return _gameSessions.Count();
    }

    public void SaveGameSession(GameSession gameSession)
    {
        try
        {
            _gameSessions.Add(gameSession);

            string json = JsonConvert.SerializeObject(_gameSessions);
            System.IO.File.WriteAllText(_path, json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            throw;
        }
    }

    public void UpdateAnswers(string userID, int sessionID, List<Answer> playerAnswers)
    {
        try
        {
            //Set Answers

            GameSession gameSession = GetGameSessionByID(sessionID);
            int currentRoundIndex = gameSession.CurrentRound.RoundNumber - 1;
            int sessionIndex = _gameSessions.IndexOf(gameSession);

            if (gameSession.Player1.UserID == userID)
            {
                gameSession.MatchRounds[currentRoundIndex].Player1Answers = playerAnswers;
                gameSession.CurrentRound.Player1Answers = playerAnswers;
            }
            else if (gameSession.Player2.UserID == userID)
            {
                gameSession.MatchRounds[currentRoundIndex].Player2Answers = playerAnswers;
                gameSession.CurrentRound.Player2Answers = playerAnswers;
            }

            //Set Scores

            bool answerStatus;
            int categoryIndex = 0;

            foreach (Answer answer in playerAnswers)
            {
                ValidateAnswerUseCase validateAnswer = new ValidateAnswerUseCase(answer.PlayerAnswer, gameSession.CurrentRound.Categories[categoryIndex]);
                answerStatus = validateAnswer.Execute();

                if (gameSession.Player1.UserID == userID)
                    gameSession.CurrentRound.Player1Answers[categoryIndex].Correct = answerStatus;
                if (gameSession.Player2.UserID == userID)
                    gameSession.CurrentRound.Player2Answers[categoryIndex].Correct = answerStatus;

                if (answerStatus)
                {
                    if (gameSession.Player1.UserID == userID)
                        gameSession.CurrentRound.Player1Score++;
                    if (gameSession.Player2.UserID == userID)
                        gameSession.CurrentRound.Player2Score++;
                }
                categoryIndex++;
            }

            //Update Session Scores

            if (gameSession.CurrentRound.Player1Answers.Count != 0 && gameSession.CurrentRound.Player2Answers.Count != 0)
            {
                int playerRoundScore = gameSession.CurrentRound.Player1Score;
                int opponentRoundScore = gameSession.CurrentRound.Player2Score;

                if (playerRoundScore > opponentRoundScore)
                {
                    gameSession.Player1Score++;
                }
                else if (playerRoundScore < opponentRoundScore)
                {
                    gameSession.Player2Score++;
                }
                else
                {
                    gameSession.Player1Score++;
                    gameSession.Player2Score++;
                }
            }


            _gameSessions[sessionIndex] = gameSession;

            string json = JsonConvert.SerializeObject(_gameSessions);
            System.IO.File.WriteAllText(_path, json);
        }
        catch (Exception e)
        {

            throw new Exception($"UpdateAnswers {e.Message}");
        }
    }

    public GameSession GetGameSessionByID(int id)
    {
        try
        {
            return _gameSessions.Find(x => x.SessionID == id);
        }
        catch (Exception e)
        {

            throw new Exception($"GetGameSessionByID {e.Message}");
        }
    }

    public void UpdateGameSession(GameSession gameSession)
    {
        try
        {
            GameSession oldGameSession = GetGameSessionByID(gameSession.SessionID);
            _gameSessions.Remove(oldGameSession);
            _gameSessions.Add(gameSession);

            string json = JsonConvert.SerializeObject(_gameSessions);
            System.IO.File.WriteAllText(_path, json);
        }
        catch (Exception e)
        {

            throw new Exception($"UpdateGameSession {e.Message}");
        }
    }

    //public GameSession GetGameSessionByID(int sessionID)
    //{
    //    try
    //    {
    //        return _gameSessions.FirstOrDefault(q => q.SessionID == sessionID);
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine(e.ToString());
    //        throw;
    //    }
    //}
}


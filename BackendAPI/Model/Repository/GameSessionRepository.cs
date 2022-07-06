
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
            GameSession gameSession = GetGameSessionByID(sessionID);
            int lastRoundIndex = gameSession.MatchRounds.Count - 1;
            int sessionIndex = _gameSessions.IndexOf(gameSession);

            if (gameSession.Player1.UserID == userID)
                gameSession.MatchRounds[lastRoundIndex].Player1Answers = playerAnswers;
            else if (gameSession.Player2.UserID == userID)
                gameSession.MatchRounds[lastRoundIndex].Player2Answers = playerAnswers;

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


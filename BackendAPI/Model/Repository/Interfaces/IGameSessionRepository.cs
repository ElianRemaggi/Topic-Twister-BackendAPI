using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGameSessionRepository
{
    int GetLastSessionId();
    void SaveGameSession(GameSession gameSession);
    List<GameSession> GetGameSessions();
    void UpdateAnswers(string userID, int sessionID, List<Answer> playerAnswers);
    GameSession GetGameSessionByID(int id);
}



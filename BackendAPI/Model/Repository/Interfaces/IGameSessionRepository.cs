using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGameSessionRepository
{
    int GetLastSessionId();
    void SaveGameSession(GameSession gameSession);


}



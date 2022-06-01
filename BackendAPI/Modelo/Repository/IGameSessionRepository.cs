using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGameSessionRepository
{
    GameSession GetCurrentGameSession();

    GameSession CreateNewGameSession(Player player1, Player player2);

}



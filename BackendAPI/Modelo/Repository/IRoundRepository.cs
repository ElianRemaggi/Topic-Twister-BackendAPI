using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IRoundRepository
{
    Round GetCurrentRound();
    Round GetOpponentCurrentRound();

    Round CreateNewRound(List<Category> categories);

    void UpdateRoundLetter(char roundLetter);
    void CreateOpponentRoundSimulated();
    List<Round> GetPlayerRounds();
    List<Round> GetOpponentRounds();
    void ClearAllRounds();

}


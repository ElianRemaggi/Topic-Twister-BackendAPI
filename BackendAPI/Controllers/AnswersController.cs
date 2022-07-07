using BackendAPI.Modelo.Repository;
using BackendAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAPI.Controllers
{
    [Route("UpdateAnswers")]
    [ApiController]
    public class AnswersController : ControllerBase
    {

        [HttpPut]
        public IActionResult Put(string userID, int sessionID, object parameters)
        {
            try
            {
                if (userID == null || userID.Equals(""))
                {
                    Exception e = new Exception("userID null or empty");
                }

                List<Answer> playerAnswers = JsonConvert.DeserializeObject<List<Answer>>(parameters.ToString());

                UpdatePlayerAnswersUseCase update = new UpdatePlayerAnswersUseCase(RepoLocator.GetGameSessionRepo());
                update.Execute(userID, sessionID, playerAnswers);




                //Caso de uso setear current Round
                GameSession currentSession = RepoLocator.GetGameSessionRepo().GetGameSessionByID(sessionID);
                if (currentSession.CurrentRound.Player1Answers.Count != 0 &&
currentSession.CurrentRound.Player2Answers.Count != 0)
                {

                }
                if (currentSession.CurrentRound.Player1Answers.Count != 0 &&
                    currentSession.CurrentRound.Player2Answers.Count != 0 &&
                    currentSession.CurrentRound.RoundNumber < 3)
                    currentSession.CurrentRound = currentSession.MatchRounds[currentSession.CurrentRound.RoundNumber];

                RepoLocator.GetGameSessionRepo().UpdateGameSession(currentSession);
                //Caso de uso setear current Round

                return Ok("");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
                return BadRequest(e.Message);
            }

        }

    }
}

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



                GameSession currentSession = RepoLocator.GetGameSessionRepo().GetGameSessionByID(sessionID);

                //Obtener Respuestas para devolver
                List<Answer> validatedAnswers = new List<Answer>();

                if (currentSession.Player1.UserID == userID)
                    validatedAnswers = currentSession.CurrentRound.Player1Answers;
                else if (currentSession.Player2.UserID == userID)
                    validatedAnswers = currentSession.CurrentRound.Player2Answers;
                //Obtener Respuestas para devolver

                //Caso de uso setear current Round
                if (currentSession.CurrentRound.Player1Answers.Count != 0 &&
                    currentSession.CurrentRound.Player2Answers.Count != 0 &&
                    currentSession.CurrentRound.RoundNumber < 3)
                    currentSession.CurrentRound = currentSession.MatchRounds[currentSession.CurrentRound.RoundNumber];
                //Caso de uso setear current Round

                RepoLocator.GetGameSessionRepo().UpdateGameSession(currentSession);


                return Ok(JsonConvert.SerializeObject(validatedAnswers));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
                return BadRequest(e.Message);
            }

        }

    }
}

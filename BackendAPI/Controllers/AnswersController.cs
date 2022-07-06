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

                //Caso de uso UpdatePlayerAnswers

                UpdatePlayerAnswersUseCase update = new UpdatePlayerAnswersUseCase(RepoLocator.GetGameSessionRepo());
                update.Execute(userID,sessionID, playerAnswers);

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

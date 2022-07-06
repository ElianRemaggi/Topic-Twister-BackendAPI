using BackendAPI.Modelo.Repository;
using BackendAPI.Modelo.UseCases;
using BackendAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BackendAPI.Controllers
{
    [Route("FindOpenGameSessions")]
    [ApiController]
    public class GameSessionController : ControllerBase
    {
        [HttpGet("id")]
        public IActionResult FindOpenGameSessions([FromServices] IGameSessionRepository gameSessionRepository, string id)
        {
            if (gameSessionRepository == null)
            {
                gameSessionRepository = new GameSessionRepository(PathProvider.GetGameSessionJsonPath());
            }

            try
            {

                List<GameSession> result = new FindOpenGameSessionUseCase(RepoLocator.GetGameSessionRepo()).Execute(id);

                if (result.Count != 0)
                    return Ok(JsonConvert.SerializeObject(result));
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                return NotFound($"No GameSessions Found for user {id}");
            }
        }
    }
}

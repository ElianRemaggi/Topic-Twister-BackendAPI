using BackendAPI.Modelo.Repository;
using BackendAPI.Service;
using BackendAPI.UseCases.MatchMaking;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAPI.Controllers
{
    [Route("FindOpponent")]
    [ApiController]
    public class MatchMakingController : ControllerBase
    {
        IPlayerRepository _playerRepository;
        public MatchMakingController()
        {
            _playerRepository = new PlayerRepository(PathProvider.GetPlayersJsonPath());
        }

        [HttpGet("id")]
        public async Task<IActionResult> FindOpponent(string playerID)
        {
            try
            {
                MatchMaking matchMaking = new MatchMaking(_playerRepository);
                Player opponent = await matchMaking.FindOpponent(playerID);

                CreateGameSessionUseCase createGameSession = new CreateGameSessionUseCase(RepoLocator.GetGameSessionRepo(),
                                                                                          RepoLocator.GetCategoryRepo());

                GameSession gameSession = createGameSession.Execute(RepoLocator.GetPlayerRepo().FindPlayerById(playerID),
                                                                    opponent);

                return Ok(JsonConvert.SerializeObject(gameSession));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound("Error ");
            }
        }
    }
}

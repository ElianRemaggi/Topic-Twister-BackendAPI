using BackendAPI.Modelo.Repository;
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
            _playerRepository = new PlayerRepository();
        }

        [HttpGet("id")]
        public IActionResult GetOpponentPlayer(string playerID)
        {
            MatchMaking matchMaking = new MatchMaking(_playerRepository);
            return Ok(JsonConvert.SerializeObject(matchMaking.FindOpponent(playerID)));
            return NotFound("Error ");
        }
    }
}

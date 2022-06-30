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
        public async Task<IActionResult> FindOpponent(string playerID)
        {
            try
            {
                MatchMaking matchMaking = new MatchMaking(_playerRepository);
                return Ok(JsonConvert.SerializeObject(await matchMaking.FindOpponent(playerID)));
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound("Error ");
            }

        }
    }
}

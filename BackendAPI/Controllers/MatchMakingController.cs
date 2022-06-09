using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAPI.Controllers
{
    [Route("FindOpponent")]
    [ApiController]
    public class MatchMakingController : ControllerBase
    {

        [HttpGet("id")]
        public IActionResult GetOpponentPlayer(string playerID)
        {
            MatchMaking matchMaking = new MatchMaking();
            return Ok(JsonConvert.SerializeObject(matchMaking.FindOpponent(playerID)));
            return NotFound("Error ");
        }
    }
}

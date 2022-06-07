using BackendAPI.Modelo.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;


namespace BackendAPI.Controllers
{
    [Route("GetAllPlayers")]
    [ApiController]
    public class GetPlayersLookingForMatch : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            IPlayerRepository playerRepository = new PlayerRepository();
            return Ok(JsonConvert.SerializeObject(playerRepository.FindPlayersLookingForMatch()));
            return NotFound("Error ");
        }
    }
}

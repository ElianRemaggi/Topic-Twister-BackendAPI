using BackendAPI.Modelo.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;


namespace BackendAPI.Controllers
{
    [Route("GetAllPlayers")]
    [ApiController]
    public class GetAllPlayers : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllPlayerss()
        {
            IPlayerRepository playerRepository = new PlayerRepository();
            return Ok(JsonConvert.SerializeObject(playerRepository.GetAllPlayers()));
            return NotFound("Error ");
        }
    }
}

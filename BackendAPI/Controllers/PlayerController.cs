using BackendAPI.Modelo.Repository;
using BackendAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAPI.Controllers
{
    public class PlayerController
    {
    }

    [Route("GetPlayersLookingForMatch")]
    [ApiController]
    public class GetPlayersLookingForMatch : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            IPlayerRepository playerRepository = new PlayerRepository(PathProvider.GetPlayersJsonPath());
            return Ok(JsonConvert.SerializeObject(playerRepository.FindPlayersLookingForMatch()));
            return NotFound("Error ");
        }
    }

    [Route("GetPlayerById")]
    [ApiController]
    public class GetPlayerByIdController : ControllerBase
    {
        [HttpGet("id")]
        public IActionResult GetPlayerById(string id)
        {
            IPlayerRepository playerRepository = new PlayerRepository(PathProvider.GetPlayersJsonPath());
            List<Player> Players = playerRepository.GetAllPlayers();

            foreach (Player player in Players)
            {
                if (player.UserID == id)
                {
                    return Ok(JsonConvert.SerializeObject(player));
                }
            }
            return NotFound("No existe Usuario con id " + id);
        }
    }

    [Route("GetAllPlayers")]
    [ApiController]
    public class GetAllPlayersController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            IPlayerRepository playerRepository = new PlayerRepository(PathProvider.GetPlayersJsonPath());
            return Ok(JsonConvert.SerializeObject(playerRepository.GetAllPlayers()));
            return NotFound("Error ");
        }
    }
}

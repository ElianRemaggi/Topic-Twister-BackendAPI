using BackendAPI.Modelo.Repository;
using BackendAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAPI.Controllers
{
    [Route("UpdatePlayerData")]
    [ApiController]
    public class PlayerDataController : ControllerBase
    {

        [HttpGet("id")]
        public IActionResult GetPlayerDataByPlayerId(string id)
        {
            IPlayerRepository playerRepository = new PlayerRepository(PathProvider.GetPlayersJsonPath());
            foreach (Player player in playerRepository.GetAllPlayers())
            {
                if (player.UserID == id)
                {
                    return Ok(JsonConvert.SerializeObject(player.PlayerData));
                }
            }
            return NotFound("No existe Usuario con id " + id);
        }


        [HttpPut]
        public IActionResult Put(string id, object parametro)
        {
            try
            {
                if (id == null || id.Equals(""))
                {
                    Exception e = new Exception("PlayerDataController.Put(id,parametro) = Id null");
                }

                PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(parametro.ToString());
                IPlayerRepository playerRepository = new PlayerRepository(PathProvider.GetPlayersJsonPath());

                playerRepository.UpdatePlayerData(id,playerData);
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

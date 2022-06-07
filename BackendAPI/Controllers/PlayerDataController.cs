using BackendAPI.Modelo.Repository;
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
            IPlayerRepository playerRepository = new PlayerRepository();
            foreach (Player player in playerRepository.GetAllPlayers())
            {
                if (player.UserID == id)
                {
                    return Ok(JsonConvert.SerializeObject(player.PlayerData)); // Forma correcta de formatear JSON
                }
            }
            return NotFound("No existe Usuario con id " + id);
        }


        [HttpPut]
        public IActionResult Put(string id, object parametro)
        {
            if (id == null || id.Equals(""))
            {
                Exception e = new Exception("PlayerDataController.Put(id,parametro) = Id null");
            }

            try
            {
                PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(parametro.ToString());
                Console.WriteLine("id = " + id);
                Console.WriteLine("PlayerData nombre " + playerData.Name);

                //var respuesta = JsonConvert.DeserializeObject(player.ToString());
                Console.WriteLine("go ok ");
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

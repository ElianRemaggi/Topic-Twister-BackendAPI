using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace BackendAPI.Controllers
{
    [Route("GetPlayerById")]
    [ApiController]
    public class GetPlayerByIdController : ControllerBase
    {
        private static readonly Player[] Players = new[]
        {
        new Player(1,new PlayerData(1,"Luis")),
            new Player(2,new PlayerData(5,"Elian")),
            new Player(3,new PlayerData(8,"Jesus")),
            new Player(4,new PlayerData(15,"Sebastian"))
         };

        [HttpGet("id")]
        public IActionResult GetPlayerById(int id)
        {
            foreach (Player player in Players)
            {
                if (player.UserID == id)
                {
                    return Ok(JsonConvert.SerializeObject(player)); // Forma correcta de formatear JSON
                }
            }
            return NotFound("No existe Usuario con id " + id);
        }
    }
}

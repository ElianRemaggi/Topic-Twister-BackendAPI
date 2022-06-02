using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BackendAPI.Controllers
{
    [Route("GetPlayerById")]
    [ApiController]
    public class GetPlayerByIdController : ControllerBase
    {
        private static readonly Player[] Players = new[]
        {
        new Player("lgarcia",new PlayerData(1,"Luis")),
            new Player("eremaggi",new PlayerData(5,"Elian")),
            new Player("yisus",new PlayerData(8,"Jesus")),
            new Player("seba",new PlayerData(15,"Sebastian"))
         };

        [HttpGet("id")]
        public IActionResult GetPlayerById(string id)
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

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;


namespace BackendAPI.Controllers
{
    [Route("GetAllPlayers")]
    [ApiController]
    public class GetAllPlayerController : ControllerBase
    {
        private static readonly Player[] Players = new[]
        {
        new Player(1,new PlayerData(1,"Luis")),
            new Player(2,new PlayerData(5,"Elian")),
            new Player(3,new PlayerData(8,"Jesus")),
            new Player(4,new PlayerData(15,"Sebastian"))
         };

        [HttpGet]
        public IActionResult GetAllPlayers()
        {

            return Ok(JsonConvert.SerializeObject(Players)); // Forma correcta de formatear JSON

            return NotFound("Error ");
        }
    }
}

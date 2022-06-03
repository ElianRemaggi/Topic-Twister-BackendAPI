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
        new Player("lgarcia",new PlayerData(1,"Luis")),
            new Player("eremaggi",new PlayerData(5,"Elian")),
            new Player("yisus",new PlayerData(8,"Jesus")),
            new Player("seba",new PlayerData(15,"Sebastian"))
         };

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            Console.WriteLine("Ingreso Get All Platyers");
            return Ok(JsonConvert.SerializeObject(Players)); // Forma correcta de formatear JSON

            return NotFound("Error ");
        }
    }
}

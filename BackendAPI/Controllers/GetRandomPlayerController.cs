using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("GetRandomPlayer")]
    public class GetRandomPlayerController : ControllerBase
    {
        private static readonly Player[] Players = new[]
        {
        new Player(1,new PlayerData(1,"Luis")),
            new Player(2,new PlayerData(5,"Elian")),
            new Player(3,new PlayerData(8,"Jesus")),
            new Player(4,new PlayerData(15,"Sebastian"))
         };

        [HttpGet(Name = "GetRandomPlayer")]
        public IActionResult GetRandomPlayer()
        {
            Random random = new Random();
            Player seleccionado = Players[random.Next(0, 4)];

            //Forma fea de formatear json 

            string Json = "{'id' : " + seleccionado.UserID + "," +
                "'nombre' : '" + seleccionado.PlayerData.Name + "'," +
                "'winsAmount' : " + seleccionado.PlayerData.WinsAmount + "}";

            Json.Replace("'", "\"");

            return Ok(Json);
        }


    }
}
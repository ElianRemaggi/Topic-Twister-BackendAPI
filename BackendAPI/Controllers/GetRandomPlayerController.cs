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
        new Player("lgarcia",new PlayerData(1,"Luis")),
            new Player("eremaggi",new PlayerData(5,"Elian")),
            new Player("yisus",new PlayerData(8,"Jesus")),
            new Player("seba",new PlayerData(15,"Sebastian"))
         };

        [HttpGet(Name = "GetRandomPlayer")]
        public IActionResult GetRandomPlayer()
        {
            Random random = new Random();
            Player seleccionado = Players[random.Next(0, 4)];

            //Forma fea de formatear json 

            string Json = "{'id' : '"+ seleccionado.UserID + "'," +
                "'nombre' : '" + seleccionado.PlayerData.Name + "'," +
                "'winsAmount' : " + seleccionado.PlayerData.WinsAmount + "}";

            Json.Replace("'", "\"");

            return Ok(Json);
        }


    }
}
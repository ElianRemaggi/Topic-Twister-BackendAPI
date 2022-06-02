using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAPI.Controllers
{
    [Route("UpdatePlayerData")]
    [ApiController]
    public class PlayerDataController : ControllerBase
    {
        private static readonly Player[] Players = new[]
        {
        new Player("lgarcia",new PlayerData(1,"Luis")),
            new Player("eremaggi",new PlayerData(5,"Elian")),
            new Player("yisus",new PlayerData(8,"Jesus")),
            new Player("seba",new PlayerData(15,"Sebastian"))
         };

        [HttpPost("id")]
        public void GetPlayerById(string playerDataSerialized)
        {
            Console.WriteLine(JsonConvert.DeserializeObject(playerDataSerialized).ToString());

            PlayerData respuesta = JsonConvert.DeserializeObject<PlayerData>(playerDataSerialized);

            Console.WriteLine("Nombre = " + respuesta.Name + " con una cantidad de victorias de = " + respuesta.WinsAmount);   
        }
    }
}

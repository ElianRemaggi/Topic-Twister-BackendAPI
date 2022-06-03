using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAPI.Controllers
{
    [Route("UpdatePlayerData")]
    [ApiController]
    public class PlayerDataController : ControllerBase
    {
        //[HttpPut("id")]
        //public void putTest()
        //{
        //    Console.WriteLine("Put Test");
        //}



        [HttpPut("{id}")]
        public IActionResult Put(string id, string parametro)
        {


            try
            {
                PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(parametro);
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

        /*[HttpPost("id")]
        public void UpdatePlayerData(string playerDataSerialized)
        {
            Console.WriteLine(JsonConvert.DeserializeObject(playerDataSerialized).ToString());

            PlayerData respuesta = JsonConvert.DeserializeObject<PlayerData>(playerDataSerialized);

            Console.WriteLine("Nombre = " + respuesta.Name + " con una cantidad de victorias de = " + respuesta.WinsAmount);
        }*/
    }
}

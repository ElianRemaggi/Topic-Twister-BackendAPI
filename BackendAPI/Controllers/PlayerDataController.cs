﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAPI.Controllers
{
    [Route("UpdatePlayerData")]
    [ApiController]
    public class PlayerDataController : ControllerBase
    {
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

        //este metodo no va, se usa el put
        [HttpPost("id")]
        public void UpdatePlayerData(string playerDataSerialized)
        {
            Console.WriteLine(JsonConvert.DeserializeObject(playerDataSerialized).ToString());

            PlayerData respuesta = JsonConvert.DeserializeObject<PlayerData>(playerDataSerialized);

            Console.WriteLine("Nombre = " + respuesta.Name + " con una cantidad de victorias de = " + respuesta.WinsAmount);
        }
    }
}

﻿using BackendAPI.Modelo.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAPI.Controllers
{
    public class PlayerController
    {
    }

    [Route("GetPlayersLookingForMatch")]
    [ApiController]
    public class GetPlayersLookingForMatch : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            IPlayerRepository playerRepository = new PlayerRepository();
            return Ok(JsonConvert.SerializeObject(playerRepository.FindPlayersLookingForMatch()));
            return NotFound("Error ");
        }
    }

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

    [Route("GetAllPlayers")]
    [ApiController]
    public class GetAllPlayersController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            IPlayerRepository playerRepository = new PlayerRepository();
            return Ok(JsonConvert.SerializeObject(playerRepository.GetAllPlayers()));
            return NotFound("Error ");
        }
    }
}

using BackendAPI.Modelo.Repository;
using BackendAPI.Modelo.UseCases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAPI.Controllers
{
    [Route("GetRandomLetter")]
    [ApiController]
    public class LetterController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetRandomLetter()
        {
            try { 

            ILetterRepository letterRepository = new LetterRepository();

            FindRandomLetterUseCase findRandomLetterUseCase = new FindRandomLetterUseCase(letterRepository);


            return Ok(JsonConvert.SerializeObject(findRandomLetterUseCase.Execute()));
            }catch(Exception ex)
            {
                return NotFound("LetterController.GetRandomLetter() Exception = "+ex.Message);
            }


        }
    }
}

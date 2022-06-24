using BackendAPI.Modelo.Repository;
using BackendAPI.Modelo.UseCases;
using BackendAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BackendAPI.Controllers
{
    [Route("GetRandomCategories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRandomCategories([FromServices] ICategoryRepository categoryRepository)
        {
            if (categoryRepository == null)
            {
                categoryRepository = new CategoryRepository(PathProvider.GetCategoryJsonPath());
            }

            FindRandomCategoryListUseCase findRandomCategoryUseCase = new FindRandomCategoryListUseCase(categoryRepository);

            try
            {
                return Ok(JsonConvert.SerializeObject(findRandomCategoryUseCase.Execute()));
            }
            catch (Exception)
            {
                return NotFound("error categorys");
            }


        }
    }
}

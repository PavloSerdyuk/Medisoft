using Microsoft.AspNetCore.Mvc;
using ADO_DAL.Interfaces;
using ADO_DAL;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoEndpointsController : Controller
    {
        private readonly IDishRepository dishRepository;
        public AdoEndpointsController(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }

        [HttpGet("dishes")]
        public IActionResult GetAllDishes()
        {
            return Ok(dishRepository.GetDishes());
        }

        [HttpGet("dish/{id}")]
        public IActionResult GetDishById(int id)
        {
            return Ok(dishRepository.GetDishById(id));
        }

        [HttpPost("dish")]
        public IActionResult CreateDish([FromBody] Dish dish)
        {
            return Ok(dishRepository.CreateDish(dish));
        }

        [HttpPatch("dish")]
        public IActionResult UpdateDish([FromBody] Dish trader)
        {
            return Ok(dishRepository.UpdateDish(trader));
        }

        [HttpDelete("dish")]
        public IActionResult DeleteDishById(int id)
        {
            bool isOk = dishRepository.DeleteDishById(id);

            return Ok(isOk ? $"Successfully Deleted Dish With Id: {id}" :
                $"Somethind Went Wrong While Deleting Dish With Id: {id}");
        }


    }
}

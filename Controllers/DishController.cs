using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.DishDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;

namespace Philadelphia_Sweets_booking_System__Resturant_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DishController : Controller
    {
        private readonly IDishServices _DishServices;

        public DishController(IDishServices dishServices)
        {
            _DishServices = dishServices;
        }

        [HttpPost("add")]
        public async Task<ActionResult<int>> AddDish(CreateDishDTO dish)
        {
            var dishId = await _DishServices.AddDishServicesAsync(dish);
            
            if(dishId==0)
            {
                return BadRequest($"Operation failed, dish not added to database");
            }

            return Ok(dishId);
        }
        [HttpPost("addApiDish")]
        public async Task<ActionResult<int>> AddDishFromApi(string dishName)
        {
            var dishId = await _DishServices.AddDishFromApiServices(dishName);

            if(dishId==0)
            {
                return BadRequest("error, could not add dish to database, 0 new dishes added");
            }
            return Ok(dishId);
        }
        [HttpGet("getall")]
        public async Task<ActionResult<List<DishDTO>>> GetAllDishes()
        {
            var dishes = await _DishServices.GetAllDishesServicesAsync();

            if (!dishes.Any())
            {
                return NotFound($"No dishes found in database, list empty");
            }

            return Ok(dishes);
        }
        [HttpGet]
        public async Task<ActionResult<DishDTO>> GetDishById(int id)
        {
            var dish = await _DishServices.GetDishByIdServicesAsync(id);

            if (dish==null)
            {
                return BadRequest($"failed, could not fetch Dish, objekt is null");
            }

            return Ok(dish);
        }
        [HttpGet("GetByName")]
        public async Task<ActionResult<DishDTO>> GetDishByName(string name)
        {
            var dish = await _DishServices.GetDishByNameServicesAsync(name);

            if(dish==null)
            {
                return NotFound($"No dish with that name, objekt is null");
            }

            return Ok(dish);
        }
        [HttpPost("AddToMenu")]
        public async Task<ActionResult<int>> AddDishToMenu(int dishId, int menuId)
        {
            var rowsAffected = await _DishServices.AddDishToMenuServicesAsync(dishId, menuId);

            if(rowsAffected==0)
            {
                return BadRequest($"Operation failed {rowsAffected} rows Affected");
            }

            return Ok($"Succeses, Dish with Id {dishId} added to Menu");
        }
        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateDish(UpdateDIshDTO dishDto)
        {
            var rowsAffected = await _DishServices.UpdateDishServicesAsync(dishDto);

            if(rowsAffected==0)
            {
                return BadRequest($"succeses {rowsAffected} rows in the database affected");
            }

            return Ok($"Sucesses");
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<int>> DeleteDish(int id)
        {
            var rowsAffected = await _DishServices.DeleteDishServicesAsync(id);

            if(id==0)
            {
                return BadRequest($"Operation failed {id} rows deleted");
            }

            return Ok($"sucesses {rowsAffected} item deleted in database");
        }
    }
}

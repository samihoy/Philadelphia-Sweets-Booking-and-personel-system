using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.MenuDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;

namespace Philadelphia_Sweets_booking_System__Resturant_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MenuController : Controller
    {
        private readonly IMenuServices _MenuServices;

        public MenuController(IMenuServices menuServices)
        {
            _MenuServices = menuServices;
        }

        [HttpPost("add")]
        public async Task<ActionResult<int>> CreateMenu(CreateMenuDTO menu)
        {
            var menuId = await _MenuServices.AddNewMenuServicesAsync(menu);
        
            if(menuId==0)
            {
                return BadRequest("Operation Failed, menu added");
            }

            return Ok(menuId);

        }
        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteMenu(int id)
        {
            var rowsAffected =  await _MenuServices.DeleteMenuServicesAsync(id);

            if(rowsAffected==0)
            {
                return BadRequest("Operation failed, Menu not deleted 0 rows affected");
            }
            return Ok($"Succses, Menu deledted {rowsAffected} menus deleted");
        }
        [HttpGet("getall")]
        public async Task<ActionResult<List<MenuWithDishesDTO>>> GetAllMenus()
        {
            var menus = await _MenuServices.GetAllMenusWithDishesServicesAsync();

            if(!menus.Any())
            {
                return NotFound("No menus found");
            }

            return Ok(menus);
        }
        [HttpGet("menu{id}")]
        public async Task<ActionResult<MenuWithDishesDTO>> GetMenuById(int id)
        {
            var menu = await _MenuServices.GetMenuByIdWithDishesServicesAsync(id);

            if(menu==null)
            {
                return NotFound("Menu not found, value is null");

            }
            return Ok(menu);
        }
        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateMeny(UpdateMenuThemeDTO menu, int id)
        {
            var rowAffected = await _MenuServices.UpdateMenuServicesAsync(menu, id);

            if(rowAffected==0)
            {
                return BadRequest("failed to update menu 0 rows in database affected");
            }
            return rowAffected;


        }
    }
}

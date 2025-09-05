using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantTableDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;

namespace Philadelphia_Sweets_booking_System__Resturant_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableServices _tableServices;

        public TableController(ITableServices services)
        {
            _tableServices = services;
        }

        [HttpGet("Tables")]
        public async Task<ActionResult<List<TableDTO>>> GetAllTables()
        {
            var tables = await _tableServices.GetAllTablesAsync();

            return Ok(tables);
            
        }
        [HttpGet("Tabble/{id}")]
        public async Task<ActionResult<TableDTO>> GetTableById([FromRoute]int id)
        {
            var table = await _tableServices.GetTableByIdAsync(id);

            if(table==null)
            {
                return NotFound($"No table with that ID found \nYour ID {id}");
            }

            return Ok(table);
        }
        public async Task<ActionResult<int>> AddTable([FromBody]TableDTO table)
        {
            var tableid = await _tableServices.AddTableAsync(table);

            if(tableid<0)
            {
                return BadRequest("Operation failed, Table could not be created");
            }

            return Ok($"Table created with ID: {tableid}");
            
        }

    }
}

using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantTableDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.TableDTO_s;
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

        [HttpGet("alltables")]
        public async Task<ActionResult<List<TableDTO>>> GetAllTables()
        {

            var tables = await _tableServices.GetAllTablesServicesAsync();

            if (!tables.Any())
            {
                return NotFound("Could not Fetch a list of tables, no tables found");
            }
            return Ok(tables);

        }
        [HttpGet("tables")]
        public async Task<ActionResult<List<TableDTO>>> GetTablesById(List<int> ids)
        {
            var tables = await _tableServices.GetTablesByIdServicesAsync(ids);

            if (!tables.Any())
            {
                return NotFound("Could not Fetch a list of tables, no tables found");
            }
            return Ok(tables);


        }
        [HttpGet("tabble/{id}")]
        public async Task<ActionResult<GetTableDTO>> GetTableById([FromRoute] int id)
        {
            var table = await _tableServices.GetTableByIdServicesAsync(id);

            if (table == null)
            {
                return NotFound($"No table with that ID found \nYour ID {id}");
            }

            return Ok(table);
        }
        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateTable([FromBody] TableDTO table)
        {
            var tableid = await _tableServices.AddTableServicesAsync(table);

            if (tableid <= 0)
            {
                return BadRequest("Operation failed, Table could not be created");
            }

            return Ok($"Table created with ID: {tableid}");

        }
        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateTable(TableDTO table)
        {
            var RowsAffected = await _tableServices.UpdateTableServicesAsync(table);

            if (RowsAffected <= 0)
            {
                return NotFound("failed to update table, 0 rows affected");
            }

            return Ok("Succses, table updated");
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<int>> DeleteTable(int id)
        {
            var rowsAffected = await _tableServices.DeleteTableServicesAsync(id);

            if(rowsAffected<=0)
            {
                return NotFound("Failed to delete table, could not find table with that id in database");
            }
            return Ok($"update seucceseful {rowsAffected} tables deleted from database");
        }


    }
}

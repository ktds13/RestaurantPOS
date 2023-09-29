using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Services.Interfaces;
using RestaurantPOS.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantPOS.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TablesController(ITableService tableService)
        {
            this._tableService = tableService;
        }
        // GET: api/<TablesController>
        [HttpGet]
        public IActionResult Get()
        {
            var tables = _tableService.GetAllTables();
            return this.Ok(tables);
        }

        // GET api/<TablesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var table = _tableService.GetTableById(id);
            return this.Ok(table);
        }
        [HttpGet("{status}")]
        public IActionResult GetByStatus(string status)
        {
            var tables = _tableService.GetTablesByStatus(status);
            return this.Ok(tables);
        }


        // POST api/<TablesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateTableRequest newTable)
        {
            if (newTable == null)
            {
                return BadRequest(Config.BadRequestStatus);
            }
            try
            {
                var status = _tableService.CreateTable(newTable);
                return this.Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(Config.ErrorCode, $"Error creating table: {ex.Message}");
            }
        }

        // PUT api/<TablesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UpdateTableRequest updateTable)
        {
            if(updateTable == null || string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(Config.BadRequestStatus);
            }
            try
            {
                var table = _tableService.UpdateTable(id, updateTable);
                return this.Ok(table);
            }
            catch(Exception ex)
            {
                return StatusCode(Config.ErrorCode, $"Error updating table: {ex.Message}");
            }
        }
        [HttpPut("{id}/update-status")]
        public IActionResult UpdateTableStatus(string id, [FromBody]string newStatus)
        {
            if(string.IsNullOrWhiteSpace(newStatus))
            {
                return BadRequest(Config.BadRequestStatus);
            }
            try
            {
                _tableService.UpdateTableStatus(id, newStatus);
                return Ok($"Table status for ID {id} updated to: {newStatus}");
            }
            catch(Exception ex)
            {
                return StatusCode(5000, $"Error updating table status: {ex.Message}");
            }
        }

        // DELETE api/<TablesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(Config.BadRequestStatus);
            }
            try
            {
              var status =  _tableService.DeleteTable(id);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(Config.ErrorCode, $"Error deleting table: {ex.Message}");
            }
        }
    }
}

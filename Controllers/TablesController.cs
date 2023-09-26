using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Services.Interfaces;

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
        public IActionResult Get(string id)
        {
            var table = _tableService.GetTableById(id);
            return this.Ok(table);
        }

        // POST api/<TablesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TablesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TablesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Services.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantPOS.Controllers
{
    [Route("api/menuItems")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemsController(IMenuItemService menuItemService) { 
        this._menuItemService = menuItemService;
        }
        // GET: api/<MenuItemController>
        [HttpGet]
        public  IActionResult Get()
        {
            var menuItems =  _menuItemService.GetAllMenuItems();
            return this.Ok (menuItems);
        }

        // GET api/<MenuItemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var menuItem = _menuItemService.GetMenuItemById(id);
            return this.Ok (menuItem);
        }

        // POST api/<MenuItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MenuItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Core;
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

        [HttpGet("available")]
        public IActionResult GetAllAvailableItems()
        {
            var menuItems = _menuItemService.GetAllAvailableMenuItem();
           return this.Ok (menuItems);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchMenuItems(string? name, string? categoryId, bool? isAvailable)
        {
            if(string.IsNullOrWhiteSpace(name) && string.IsNullOrEmpty(categoryId) && isAvailable is null)
            {
                return BadRequest(Config.BadRequestStatus);
            }
            try
            {
                var menuItems = await _menuItemService.SearchMenuItems(name, categoryId, isAvailable)!;
                return this.Ok (menuItems);
            }
            catch(Exception ex)
            {
                return StatusCode(Config.ErrorCode, ex.Message);
            }

        }
        // GET api/<MenuItemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(Config.BadRequestStatus);
            }
            var menuItem = _menuItemService.GetMenuItemById(id);
            return this.Ok (menuItem);
        }

        // POST api/<MenuItemController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateMenuItemRequest newMenuItem)
        {
            if(newMenuItem == null)
            {
                return BadRequest(Config.BadRequestStatus);
            }
            try
            {
                var status = _menuItemService.CreateMenuItem(newMenuItem);
                return this.Ok(status);
            }
            catch(Exception ex)
            {
                return StatusCode(5000, $"Error creating menu item: {ex.Message}");
            }
        }

        // PUT api/<MenuItemController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UpdateMenuItemRequest updateMenuItem)
        {
            if(string.IsNullOrWhiteSpace(id) && updateMenuItem is null)
            {
                return BadRequest(Config.BadRequestStatus);
            }
            try
            {
                var status = _menuItemService.UpdateMenuItem(id, updateMenuItem);
                return this.Ok(status);
            }
            catch(Exception ex)
            {
                return StatusCode(Config.ErrorCode, $"Error updating menu item: {ex.Message}");
            }
        }

        // DELETE api/<MenuItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if(id == null)
            {
                return BadRequest(Config.BadRequestStatus);
            }
            try
            {
                var status = _menuItemService.DeleteMenuItem(id);  
                return this.Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(Config.ErrorCode, $"Error deleting menu item: {ex.Message}");
            }
        }
    }
}

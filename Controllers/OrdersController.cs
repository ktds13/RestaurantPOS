using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantPOS.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderService.GetAllOrders();
            return this.Ok(orders);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var order = _orderService.GetOrderById(id);
            return this.Ok(order);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

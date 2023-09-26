using RestaurantPOS.Models;
using RestaurantPOS.Repository.Interfaces;

namespace RestaurantPOS.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public OrderRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Order> GetAllOrders()
        {
           List<Order> orders = _dbContext.Orders.ToList();
            return orders;
        }

        public Order GetOrderById(string id)
        {
           Order order = _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefault();    
            return order;
        }
    }
}

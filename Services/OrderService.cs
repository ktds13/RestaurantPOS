using RestaurantPOS.Services.Interfaces;
using RestaurantPOS.Repository.Interfaces;
using RestaurantPOS.Models;

namespace RestaurantPOS.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }
        public Order GetOrderById(string id)
        {
            return _orderRepository.GetOrderById(id);
        }
    }
}

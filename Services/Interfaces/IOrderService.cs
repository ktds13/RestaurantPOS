using RestaurantPOS.Models;

namespace RestaurantPOS.Services.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(string id);
    }
}

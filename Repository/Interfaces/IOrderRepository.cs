using RestaurantPOS.Models;
namespace RestaurantPOS.Repository.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(string id);
    }
}

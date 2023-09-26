using RestaurantPOS.Models;
namespace RestaurantPOS.Repository.Interfaces
{
    public interface IMenuItemRepository
    {
        List<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(string id);
    }
}

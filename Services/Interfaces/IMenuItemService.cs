using RestaurantPOS.Models;

namespace RestaurantPOS.Services.Interfaces
{
    public interface IMenuItemService
    {
        List<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(string id);
    }
}

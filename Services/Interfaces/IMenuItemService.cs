using RestaurantPOS.Models;
using RestaurantPOS.Core;

namespace RestaurantPOS.Services.Interfaces
{
    public interface IMenuItemService
    {
        List<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(string id);
        List<MenuItem> GetAllAvailableMenuItem();
        Task<IEnumerable<MenuItem>>? SearchMenuItems(string? name,string? categoryId, bool? isAvailable);
        string UpdateMenuItem(string id, UpdateMenuItemRequest updateMenuItem);
        string DeleteMenuItem(string id);
        string CreateMenuItem(CreateMenuItemRequest newMenuItem);
    }
}

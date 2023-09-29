using RestaurantPOS.Models;
using RestaurantPOS.Core;

namespace RestaurantPOS.Repository.Interfaces
{
    public interface IMenuItemRepository
    {
        List<MenuItem> GetAllMenuItems();
        MenuItem? GetMenuItemById(string id);
        List<MenuItem> GetAllAvailableMenuItem();
        Task<IEnumerable<MenuItem>>? SearchMenuItems(SearchRequestMenuItem request);
        string UpdateMenuItem(string id, MenuItem updateMenuItem);
        string DeleteMenuItem(string id);
        string CreateMenuItem(MenuItem newMenuItem);
           
    }
}

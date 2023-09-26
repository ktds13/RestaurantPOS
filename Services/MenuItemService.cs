using RestaurantPOS.Models;
using RestaurantPOS.Repository.Interfaces;
using RestaurantPOS.Services.Interfaces;

namespace RestaurantPOS.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItemRepository.GetAllMenuItems();
        }

        public MenuItem GetMenuItemById(string id)
        {
            return _menuItemRepository.GetMenuItemById(id);
        }
    }
}

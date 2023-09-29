using RestaurantPOS.Core;
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
            return _menuItemRepository.GetMenuItemById(id)!;
        }

        public string CreateMenuItem(CreateMenuItemRequest newMenuItem)
        {
            var menuItem = new MenuItem
            {
                MenuItemID = newMenuItem.MenuItemID,
                Name = newMenuItem.Name,
                Description = newMenuItem.Description,
                Price = newMenuItem.Price,
                CategoryId = newMenuItem.CategoryId!,
                IsAvailable = newMenuItem.IsAvailable,
            };
            var status = _menuItemRepository.CreateMenuItem(menuItem);
            return status.ToString();
        }

        public string DeleteMenuItem(string id)
        {
           var status = _menuItemRepository.DeleteMenuItem(id);
            return status.ToString();
        }

        public List<MenuItem> GetAllAvailableMenuItem()
        {
            var menuItems = _menuItemRepository.GetAllAvailableMenuItem();
            return menuItems;
        }

        public async Task<IEnumerable<MenuItem>>? SearchMenuItems(string? name, string? categoryId, bool? isAvailable)
        {
            var request = new SearchRequestMenuItem { CategoryId = categoryId, Name = name, IsAvailable = isAvailable };
            var menuItems =await  _menuItemRepository.SearchMenuItems(request)!;
            return menuItems;
        }

        public string UpdateMenuItem(string id, UpdateMenuItemRequest updateMenuItem)
        {
            var menuItem = new MenuItem
            {
                Name = updateMenuItem.Name,
                Description = updateMenuItem.Description,
                Price = updateMenuItem.Price,
                IsAvailable = updateMenuItem.IsAvailable,
            };
            var status = _menuItemRepository.UpdateMenuItem(id, menuItem);
            return status;
        }
    }
}

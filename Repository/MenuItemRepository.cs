using RestaurantPOS.Models;
using RestaurantPOS.Repository.Interfaces;

namespace RestaurantPOS.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public MenuItemRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MenuItem> GetAllMenuItems()
        {
           List<MenuItem> menuItems = _dbContext.MenuItems.ToList();
           return menuItems;
        }

        public MenuItem GetMenuItemById(string id)
        {
            MenuItem menuItem = _dbContext.MenuItems.Where(m => m.MenuItemID == id).FirstOrDefault();
            return menuItem;
        }
    }
}

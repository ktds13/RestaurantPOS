using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Core;
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

        public MenuItem? GetMenuItemById(string id)
        {
            MenuItem? menuItem = _dbContext.MenuItems.Where(m => m.MenuItemID == id).FirstOrDefault();
            return menuItem;
        }

        public string CreateMenuItem(MenuItem newMenuItem)
        {
            var menuItem = _dbContext.MenuItems.Where(m => m.MenuItemID == newMenuItem.MenuItemID).FirstOrDefault();
            if(menuItem == null)
            {
                _dbContext.MenuItems.Add(newMenuItem);
                _dbContext.SaveChanges();
                return Config.Success;
            }
        
                return Config.Error;
        }

        public string DeleteMenuItem(string id)
        {
            var menuItem = _dbContext.MenuItems.Where(m => m.MenuItemID == id).FirstOrDefault();
            if (menuItem != null)
            {
                _dbContext.MenuItems.Remove(menuItem);
                _dbContext.SaveChanges();
                return Config.Success;
            }
                return Config.Error;
            
        }

        public List<MenuItem> GetAllAvailableMenuItem()
        {
            var menuItems = _dbContext.MenuItems.Where(m => m.IsAvailable).ToList();
            return menuItems;
        }

        public async Task<IEnumerable<MenuItem>>? SearchMenuItems(SearchRequestMenuItem request)
        {
            IEnumerable<MenuItem>? menuItems = await FilterMenuItems(request)!;
            return menuItems;
        }

        public string UpdateMenuItem(string id, MenuItem updateMenuItem)
        {
          var menuItem = _dbContext.MenuItems.Where(m => m.MenuItemID == id).FirstOrDefault();
          if(menuItem is not null)
            {
                _dbContext.MenuItems.Update(menuItem);
                _dbContext.SaveChanges();
                return Config.Success;
            }
          return Config.Error;
        }
        private async Task<IEnumerable<MenuItem>>? FilterMenuItems(SearchRequestMenuItem request)
        {
            var parameters = new[]
           {
                new SqlParameter{ParameterName = "@name", Value = string.IsNullOrWhiteSpace(request.Name) ? DBNull.Value : request.Name},
                new SqlParameter{ParameterName = "@categoryId", Value = string.IsNullOrWhiteSpace(request.CategoryId) ? DBNull.Value : request.CategoryId},
                new SqlParameter{ParameterName = "@isAvailable", Value = request.IsAvailable == null ? DBNull.Value : request.IsAvailable}
             };
            String StoredProc = "exec SearchMenuItems @name, @categoryId, @isAvailable";
            var results = await _dbContext.MenuItems.FromSqlRaw(StoredProc, parameters).ToListAsync();
            
            return results;
        }
    }
}

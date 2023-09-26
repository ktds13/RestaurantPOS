using RestaurantPOS.Models;
namespace RestaurantPOS.Services.Interfaces
{
    public interface ITableService
    {
        List<Table> GetAllTables();
        Table GetTableById(string id);
       
    }
}

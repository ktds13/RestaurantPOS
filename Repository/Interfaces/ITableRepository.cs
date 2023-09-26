using RestaurantPOS.Models;
namespace RestaurantPOS.Repository.Interfaces
{
    public interface ITableRepository
    {
        List<Table> GetAllTables();
        Table GetTableById(string id);
    }
}

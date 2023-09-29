using RestaurantPOS.Core;
using RestaurantPOS.Models;
namespace RestaurantPOS.Services.Interfaces
{
    public interface ITableService
    {
        List<Table> GetAllTables();
        Table GetTableById(string id);
        List<Table> GetTablesByStatus(string status);
        void UpdateTableStatus(string id, string newStatus);
        string CreateTable(CreateTableRequest table);
        Table? UpdateTable(string id, UpdateTableRequest table);
        string DeleteTable(string id);
    }
}

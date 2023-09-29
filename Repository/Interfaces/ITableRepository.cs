using RestaurantPOS.Models;
namespace RestaurantPOS.Repository.Interfaces
{
    public interface ITableRepository
    {
        List<Table> GetAllTables();
        Table GetTableById(string id);
        List<Table> GetTablesByStatus(string status);
        void UpdateTableStatus (string id, TableStatus newStatus);
        string CreateTable(Table newTable);
        Table? UpdateTable(Table updateTable);
        string DeleteTable(string id);
    }
}

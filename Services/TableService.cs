using RestaurantPOS.Core;
using RestaurantPOS.Models;
using RestaurantPOS.Repository.Interfaces;
using RestaurantPOS.Services.Interfaces;

namespace RestaurantPOS.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public string CreateTable(CreateTableRequest table)
        {
            var newTable = new Table
            {
                TableId = table.TableId,
                TableName = table.TableName,
                Capacity = table.Capacity,
                Status = TableStatus.vacant
            };
            var status = _tableRepository.CreateTable(newTable);
            return status.ToString();
        }

        public string DeleteTable(string id)
        {
            var status = _tableRepository.DeleteTable(id);
            return status.ToString();
        }

        public List<Table> GetAllTables()
        {
           return _tableRepository.GetAllTables();
        }
        public Table GetTableById(string id)
        {
            return _tableRepository.GetTableById(id);
        }

        public List<Table> GetTablesByStatus(string status)
        {
           return _tableRepository.GetTablesByStatus(status);
        }

        public Table? UpdateTable(string id, UpdateTableRequest table)
        {
            var updateTable = new Table
            {
                TableId = id,
                TableName = table.TableName,
                Capacity = table.Capacity,
                Status = table.Status
            };
            return _tableRepository.UpdateTable(updateTable);
        }

        public void UpdateTableStatus(string id, string newStatus)
        {
           if(Enum.TryParse(typeof(TableStatus),newStatus!, out object parsedStatus))
            {
                var tableStatus = (TableStatus)parsedStatus!;
                _tableRepository.UpdateTableStatus(id, tableStatus);
            }
        }
    }
}

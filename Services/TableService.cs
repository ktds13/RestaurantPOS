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

        public List<Table> GetAllTables()
        {
           return _tableRepository.GetAllTables();
        }
        public Table GetTableById(string id)
        {
            return _tableRepository.GetTableById(id);
        }
    }
}

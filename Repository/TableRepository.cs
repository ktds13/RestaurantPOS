using RestaurantPOS.Models;
using RestaurantPOS.Repository.Interfaces;

namespace RestaurantPOS.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public TableRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Table> GetAllTables()
        {
            List<Table> tables = _dbContext.Tables.ToList();
            return tables;
        }

        public Table GetTableById(string id)
        {
           Table table = _dbContext.Tables.Where(t => t.TableId == id).FirstOrDefault();
            return table;
        }
    }
}

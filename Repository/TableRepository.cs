using RestaurantPOS.Models;
using RestaurantPOS.Repository.Interfaces;
using RestaurantPOS.Core;

namespace RestaurantPOS.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public TableRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateTableStatus(string id, TableStatus newStatus)
        {
           var table = _dbContext.Tables.Where(t => t.TableId == id).FirstOrDefault()!;
            if (table == null)
            {
                throw new InvalidOperationException("Table not found.");
            }
            else
            {
                table.Status = newStatus;
                _dbContext.SaveChanges();
            }
        }

        public List<Table> GetAllTables()
        {
            List<Table> tables = _dbContext.Tables.ToList();
            return tables;
        }

        public Table GetTableById(string id)
        {
           Table table = _dbContext.Tables.Where(t => t.TableId == id).FirstOrDefault()!;
           return table;
        }

        public List<Table> GetTablesByStatus(string status)
        {
           List<Table> tables = _dbContext.Tables.Where(t => t.Status.Equals(status)).ToList();
            return tables;
        }

        public string CreateTable(Table newTable)
        {
                var table = _dbContext.Tables.Where(t => t.TableId == newTable.TableId).FirstOrDefault();
                if(table == null)
                {
                    _dbContext.Tables.Add(newTable);
                    _dbContext.SaveChanges();
                    return Config.Success;
                }
                else
                {
                    return Config.Fail;
                }
          
        }

        public Table? UpdateTable(Table updateTable)
        {
           var table = _dbContext.Tables.Where(t => t.TableId == updateTable.TableId).FirstOrDefault();
            if(table != null)
            {
                _dbContext.Tables.Update(updateTable);
                _dbContext.SaveChanges();
                return updateTable;
            }
            else
            {
                return null;
            }
        }

        public string DeleteTable(string id)
        {
            var table = _dbContext.Tables.Where(t => t.TableId == id).FirstOrDefault();
            if(table != null)
            {
                _dbContext.Tables.Remove(table);
                _dbContext.SaveChanges();
                return Config.Success;
            }
            else
            {
                return Config.Fail;
            }
        }
    }
}

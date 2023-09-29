using RestaurantPOS.Models;

namespace RestaurantPOS.Core
{
    public class CreateTableRequest
    {
        public string TableId { get; set; }
        public string? TableName { get; set; }
        public int Capacity { get; set; }
    }
    public class UpdateTableRequest
    {
        public string? TableName { get; set; }
        public int Capacity { get; set; }
        public TableStatus Status { get; set; }
    }

}

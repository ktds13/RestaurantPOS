namespace RestaurantPOS.Models
{
    public class Table
    {
        public string? TableId { get; set; }
        public string? TableName { get; set; }
        public int Capacity { get; set; }
        public TableStatus Status { get; set; }
    }
}

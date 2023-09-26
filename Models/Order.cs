namespace RestaurantPOS.Models
{
    public class Order
    {
        public string? OrderId { get; set; }
        public string? TableId { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public string? UserId { get; set; }
        public OrderStatus Status { get; set; }
        public double TotalAmount { get; set; }
        public Table? Table { get; set; }
        public User? User { get; set; }  

    }
}

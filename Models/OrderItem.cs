namespace RestaurantPOS.Models
{
    public class OrderItem
    {
        public string? OrderItemId { get; set; } 
        public string? OrderId { get; set; }
        public string? MenuItemId { get; set; }
        public int? Quantity { get; set; }
        public string? SpecialRequests { get; set; }
        public double? ItemPrice { get; set; }
        public Order? Order { get; set; }

    }
}

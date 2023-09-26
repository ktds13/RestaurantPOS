namespace RestaurantPOS.Models
{
    public class Payment
    {
        public string? PaymentId { get; set; }
        public string? OrderId { get; set; }
        public DateTime? PaymentDateTime { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public double? AmountPaid { get; set; }
        public Order Order { get; set; }
    }
}

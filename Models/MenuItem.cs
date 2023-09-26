namespace RestaurantPOS.Models
{
    public class MenuItem
    {
        public string MenuItemID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string CategoryId { get; set; }
        public bool IsAvailable { get; set; }
        public Category? Category { get; set; }
    }
}

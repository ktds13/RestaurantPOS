namespace RestaurantPOS.Models
{
    public class Category
    {
        public string CategoryId { get; set; }
        public string? Name { get; set; }
        public List<MenuItem>? MenuItems { get; set; }
    }
}
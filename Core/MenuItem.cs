namespace RestaurantPOS.Core
{
    public class SearchRequestMenuItem
    {
        public string? Name { get; set; }
        public string? CategoryId { get; set; }
        public bool? IsAvailable { get; set; }
    }
    public class CreateMenuItemRequest
    {
        public string MenuItemID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? CategoryId { get; set; }
        public bool IsAvailable { get; set; }
    }
    public class UpdateMenuItemRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}

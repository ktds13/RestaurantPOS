using System.ComponentModel.DataAnnotations;

namespace RestaurantPOS.Models
{
    public class User
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public Role Role { get; set; }


    }
}

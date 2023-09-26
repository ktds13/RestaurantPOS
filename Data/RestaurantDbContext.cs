using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Models;

namespace RestaurantPOS
{
    public partial class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seed MenuItems
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { MenuItemID = "M1", Name = "Hamburger", Description = "Classic hamburger", Price = 2000, CategoryId = "C1", IsAvailable = true },
                 new MenuItem { MenuItemID = "M2", Name = "Caesar", Description = "Fresh Caesar salad", Price = 3000, CategoryId = "C2", IsAvailable = true },
                  new MenuItem { MenuItemID = "M3", Name = "CocaCola", Description = "Classic code", Price = 850, CategoryId = "C3", IsAvailable = true },
                   new MenuItem { MenuItemID = "M4", Name = "Fried Chicken", Description = "Cripy Fried Chicken", Price = 2700, CategoryId = "C2", IsAvailable = true },
                    new MenuItem { MenuItemID = "M5", Name = "Pizza", Description = "Classic pizza", Price = 12000, CategoryId = "C2", IsAvailable = false }
                );
            #endregion
            #region Seed Category
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "C1", Name = "Main Course" },
                new Category { CategoryId = "C2", Name = "Appetizer" },
                new Category { CategoryId = "C3", Name = "Drink" },
                new Category { CategoryId = "C4", Name = "Dessert" }
                );
            #endregion
            #region Seed Table
            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = "T1", TableName = "Table 1", Capacity = 4, Status = TableStatus.vacant },
                new Table { TableId = "T2", TableName = "Table 2", Capacity = 4, Status = TableStatus.reserved },
                 new Table { TableId = "T3", TableName = "Table 3", Capacity = 6, Status = TableStatus.reserved },
                  new Table { TableId = "T4", TableName = "Table 4", Capacity = 4, Status = TableStatus.occupied },
                   new Table { TableId = "T5", TableName = "Table 5", Capacity = 2, Status = TableStatus.vacant }
                );
            #endregion
            #region Seed Order
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = "O1", TableId = "T4", OrderDateTime = DateTime.Now, Status = OrderStatus.open, TotalAmount=5000, UserId="U1" },
                new Order { OrderId = "O2", TableId = "T3", OrderDateTime = DateTime.Now, Status = OrderStatus.closed, TotalAmount = 4500, UserId = "U3" },
                new Order { OrderId = "O3", TableId = "T1", OrderDateTime = DateTime.Now, Status = OrderStatus.closed, TotalAmount = 5000, UserId = "U2" },
                new Order { OrderId = "O4", TableId = "T4", OrderDateTime = DateTime.Now, Status = OrderStatus.closed, TotalAmount = 5000, UserId = "U1" },
                new Order { OrderId = "O5", TableId = "T2", OrderDateTime = DateTime.Now, Status = OrderStatus.closed, TotalAmount = 5000, UserId = "U4" }
                );
            #endregion
            #region Seed OrderItem
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = "OI1", OrderId = "O1", ItemPrice = 2000, MenuItemId = "M1", Quantity = 1, SpecialRequests = "" },
                new OrderItem { OrderItemId = "OI2", OrderId = "O1", ItemPrice = 3000, MenuItemId = "M2", Quantity = 1, SpecialRequests = "" }
                );
            #endregion
            #region Seed Payment
            modelBuilder.Entity<Payment>().HasData(
                new Payment { PaymentId = "P1", OrderId = "O1", PaymentDateTime = DateTime.Now, AmountPaid = 5000, PaymentMethod = PaymentMethod.cash },
                new Payment { PaymentId = "P2", OrderId = "O2", PaymentDateTime = DateTime.Now, AmountPaid = 20000, PaymentMethod = PaymentMethod.creditCard }
                );
            #endregion
            #region Seed User 
            modelBuilder.Entity<User>().HasData(
                new User { UserId = "U1", UserName = "David", Password = "su123", Role = Role.waiter },
                new User { UserId = "U2", UserName = "Mike", Password = "mike234", Role = Role.manager },
                new User { UserId = "U3", UserName = "Bob", Password = "bob456", Role = Role.cashier },
                new User { UserId = "U4", UserName = "Susan", Password = "susan678", Role = Role.chef }
                );
            #endregion
        }

    }

}

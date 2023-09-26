using Microsoft.EntityFrameworkCore;
using RestaurantPOS;
using RestaurantPOS.Repository;
using RestaurantPOS.Repository.Interfaces;
using RestaurantPOS.Services;
using RestaurantPOS.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args); 
try
{
    #region DatabaseConnection
    var connectionString = builder.Configuration.GetConnectionString("DbConnectionStr");
    builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(connectionString));
    #endregion

    #region CORS
    builder.Services.AddCors(option => option.AddDefaultPolicy(builder =>
                                builder.AllowCredentials()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .SetIsOriginAllowed((x) => true)));
    #endregion

    #region Register Services & Repositories
    builder.Services.AddScoped<IMenuItemService, MenuItemService>();
    builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
    builder.Services.AddScoped<IOrderService, OrderService>();
    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<ITableService, TableService>();
    builder.Services.AddScoped<ITableRepository, TableRepository>();
    #endregion

    builder.Services.AddControllers();
    builder.Services.AddAuthentication();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpClient();
    builder.Services.AddEndpointsApiExplorer();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    //app.MapGet("/", () => "Hello World!");
    app.MapControllers();


    app.Run();
} catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

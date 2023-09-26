using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantPOS.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialRequests",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { "C1", "Main Course" },
                    { "C2", "Appetizer" },
                    { "C3", "Drink" },
                    { "C4", "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "Status", "TableName" },
                values: new object[,]
                {
                    { "T1", 4, 0, "Table 1" },
                    { "T2", 4, 2, "Table 2" },
                    { "T3", 6, 2, "Table 3" },
                    { "T4", 4, 1, "Table 4" },
                    { "T5", 2, 0, "Table 5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { "U1", "su123", 0, "David" },
                    { "U2", "mike234", 3, "Mike" },
                    { "U3", "bob456", 2, "Bob" },
                    { "U4", "susan678", 1, "Susan" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemID", "CategoryId", "Description", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { "M1", "C1", "Classic hamburger", true, "Hamburger", 2000.0 },
                    { "M2", "C2", "Fresh Caesar salad", true, "Caesar", 3000.0 },
                    { "M3", "C3", "Classic code", true, "CocaCola", 850.0 },
                    { "M4", "C2", "Cripy Fried Chicken", true, "Fried Chicken", 2700.0 },
                    { "M5", "C2", "Classic pizza", false, "Pizza", 12000.0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDateTime", "Status", "TableId", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { "O1", new DateTime(2023, 9, 26, 13, 46, 16, 203, DateTimeKind.Local).AddTicks(8548), 0, "T4", 5000.0, "U1" },
                    { "O2", new DateTime(2023, 9, 26, 13, 46, 16, 203, DateTimeKind.Local).AddTicks(8559), 1, "T3", 4500.0, "U3" },
                    { "O3", new DateTime(2023, 9, 26, 13, 46, 16, 203, DateTimeKind.Local).AddTicks(8561), 1, "T1", 5000.0, "U2" },
                    { "O4", new DateTime(2023, 9, 26, 13, 46, 16, 203, DateTimeKind.Local).AddTicks(8562), 1, "T4", 5000.0, "U1" },
                    { "O5", new DateTime(2023, 9, 26, 13, 46, 16, 203, DateTimeKind.Local).AddTicks(8564), 1, "T2", 5000.0, "U4" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "ItemPrice", "MenuItemId", "OrderId", "Quantity", "SpecialRequests" },
                values: new object[,]
                {
                    { "OI1", 2000.0, "M1", "O1", 1, "" },
                    { "OI2", 3000.0, "M2", "O1", 1, "" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "AmountPaid", "OrderId", "PaymentDateTime", "PaymentMethod" },
                values: new object[,]
                {
                    { "P1", 5000.0, "O1", new DateTime(2023, 9, 26, 13, 46, 16, 203, DateTimeKind.Local).AddTicks(8646), 0 },
                    { "P2", 20000.0, "O2", new DateTime(2023, 9, 26, 13, 46, 16, 203, DateTimeKind.Local).AddTicks(8649), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "C4");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemID",
                keyValue: "M1");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemID",
                keyValue: "M2");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemID",
                keyValue: "M3");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemID",
                keyValue: "M4");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemID",
                keyValue: "M5");

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: "OI1");

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: "OI2");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: "O3");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: "O4");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: "O5");

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: "P1");

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: "P2");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: "T5");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "C1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "C2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "C3");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: "O1");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: "O2");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: "T1");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: "T2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "U2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "U4");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: "T3");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: "T4");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "U1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "U3");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialRequests",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

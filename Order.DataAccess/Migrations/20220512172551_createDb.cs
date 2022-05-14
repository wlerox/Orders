using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.DataAccess.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerGSM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreateDate", "Description", "Status", "Unit", "UnitPrice", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("3718c9c1-fd05-4e9b-a23b-639ae211a1df"), "Home", new DateTime(2021, 7, 11, 6, 4, 8, 361, DateTimeKind.Unspecified).AddTicks(499), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 1, 41, 52f, new DateTime(2022, 4, 21, 22, 34, 3, 153, DateTimeKind.Unspecified).AddTicks(915) },
                    { new Guid("3a8d27bb-6600-4a7c-a190-2dc9ea014f6d"), "Jewelery", new DateTime(2022, 4, 17, 14, 4, 14, 102, DateTimeKind.Unspecified).AddTicks(2240), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 0, 16, 57f, new DateTime(2021, 6, 23, 6, 39, 31, 525, DateTimeKind.Unspecified).AddTicks(9496) },
                    { new Guid("49f08698-0927-443f-aba1-2582a322b1f1"), "Garden", new DateTime(2021, 10, 10, 11, 39, 47, 423, DateTimeKind.Unspecified).AddTicks(8685), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 0, 29, 57f, new DateTime(2021, 5, 23, 22, 47, 20, 838, DateTimeKind.Unspecified).AddTicks(5915) },
                    { new Guid("56fe82f0-093b-492b-aec8-221eb7018baa"), "Beauty", new DateTime(2021, 10, 23, 23, 20, 15, 936, DateTimeKind.Unspecified).AddTicks(7791), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 1, 46, 55f, new DateTime(2022, 2, 15, 4, 11, 7, 544, DateTimeKind.Unspecified).AddTicks(816) },
                    { new Guid("5cd4200a-299e-4965-844c-ff3c936295ba"), "Sports", new DateTime(2021, 5, 29, 19, 32, 50, 473, DateTimeKind.Unspecified).AddTicks(239), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 1, 26, 54f, new DateTime(2022, 4, 3, 20, 38, 50, 201, DateTimeKind.Unspecified).AddTicks(7839) },
                    { new Guid("606fbda4-7b38-4b6a-a2a6-5bc25085ba51"), "Jewelery", new DateTime(2021, 5, 21, 16, 18, 57, 50, DateTimeKind.Unspecified).AddTicks(7873), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 1, 39, 52f, new DateTime(2022, 2, 14, 23, 29, 23, 875, DateTimeKind.Unspecified).AddTicks(7749) },
                    { new Guid("65b323ad-5ef6-4c34-8f40-d0a9baee42a2"), "Outdoors", new DateTime(2022, 3, 30, 1, 45, 59, 342, DateTimeKind.Unspecified).AddTicks(9926), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 1, 60, 51f, new DateTime(2021, 6, 16, 7, 58, 8, 188, DateTimeKind.Unspecified).AddTicks(6973) },
                    { new Guid("67386e5b-5b6f-4144-bcb0-19a1441a4772"), "Music", new DateTime(2021, 11, 16, 10, 26, 53, 234, DateTimeKind.Unspecified).AddTicks(4963), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 1, 17, 57f, new DateTime(2021, 7, 24, 0, 36, 41, 388, DateTimeKind.Unspecified).AddTicks(4418) },
                    { new Guid("6751eecc-9bd3-4f52-929e-6c8cf1f15015"), "Industrial", new DateTime(2022, 4, 9, 23, 20, 23, 117, DateTimeKind.Unspecified).AddTicks(808), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 1, 50, 57f, new DateTime(2022, 1, 3, 20, 49, 12, 921, DateTimeKind.Unspecified).AddTicks(5612) },
                    { new Guid("71efc825-1083-4cc4-b5e2-0cc05361c337"), "Shoes", new DateTime(2021, 7, 4, 0, 42, 56, 549, DateTimeKind.Unspecified).AddTicks(2633), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 0, 32, 50f, new DateTime(2021, 11, 4, 23, 41, 29, 991, DateTimeKind.Unspecified).AddTicks(2597) },
                    { new Guid("81c19555-9474-4cb5-b79e-8b8fad63e4ae"), "Outdoors", new DateTime(2021, 9, 25, 18, 38, 24, 911, DateTimeKind.Unspecified).AddTicks(2185), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 1, 16, 54f, new DateTime(2021, 8, 24, 10, 51, 50, 365, DateTimeKind.Unspecified).AddTicks(8642) },
                    { new Guid("92129ae8-c9da-410c-b649-9443eac9fa4c"), "Outdoors", new DateTime(2021, 5, 15, 22, 56, 18, 346, DateTimeKind.Unspecified).AddTicks(6215), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 1, 55, 57f, new DateTime(2021, 7, 31, 16, 44, 48, 399, DateTimeKind.Unspecified).AddTicks(1478) },
                    { new Guid("945662ea-de15-4a58-9924-bb696f7c2be2"), "Clothing", new DateTime(2021, 11, 24, 3, 43, 33, 275, DateTimeKind.Unspecified).AddTicks(5539), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 1, 32, 54f, new DateTime(2021, 7, 28, 0, 15, 0, 352, DateTimeKind.Unspecified).AddTicks(2) },
                    { new Guid("a25d0072-230f-4e61-8fa2-e1684eb47e4e"), "Health", new DateTime(2021, 12, 12, 20, 16, 3, 303, DateTimeKind.Unspecified).AddTicks(5983), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 0, 93, 55f, new DateTime(2021, 8, 4, 5, 19, 11, 951, DateTimeKind.Unspecified).AddTicks(7064) },
                    { new Guid("ae60db97-fecf-4384-aada-a18c9afe1972"), "Shoes", new DateTime(2021, 10, 9, 13, 36, 3, 942, DateTimeKind.Unspecified).AddTicks(9219), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 1, 55, 51f, new DateTime(2021, 9, 12, 19, 24, 52, 653, DateTimeKind.Unspecified).AddTicks(1035) },
                    { new Guid("b203b2d1-be33-445c-8568-3e03d1499fc9"), "Garden", new DateTime(2021, 6, 29, 7, 49, 42, 156, DateTimeKind.Unspecified).AddTicks(3959), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 1, 6, 53f, new DateTime(2022, 2, 23, 15, 26, 29, 230, DateTimeKind.Unspecified).AddTicks(9036) },
                    { new Guid("cf13f1b4-f6c8-43ea-bb20-3a965c5cf8c6"), "Electronics", new DateTime(2022, 2, 25, 18, 40, 37, 11, DateTimeKind.Unspecified).AddTicks(9957), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 1, 72, 56f, new DateTime(2022, 1, 19, 6, 13, 23, 617, DateTimeKind.Unspecified).AddTicks(7847) },
                    { new Guid("f61e863e-7da1-4fa6-bd96-9fb4a51970c5"), "Health", new DateTime(2021, 10, 17, 0, 45, 3, 924, DateTimeKind.Unspecified).AddTicks(9849), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 0, 75, 51f, new DateTime(2021, 8, 10, 9, 53, 29, 216, DateTimeKind.Unspecified).AddTicks(4255) },
                    { new Guid("f96ca098-80e7-4c80-9f0b-305729bf29cb"), "Sports", new DateTime(2022, 2, 9, 9, 29, 44, 551, DateTimeKind.Unspecified).AddTicks(8042), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 1, 7, 52f, new DateTime(2022, 2, 9, 23, 15, 34, 680, DateTimeKind.Unspecified).AddTicks(4225) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

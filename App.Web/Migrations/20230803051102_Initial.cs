using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Web.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Items = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Persons",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[] { new Guid("5eb7d209-020b-477c-9e01-db717874faf6"), "Calle 49 A Sur 87 J 29", "Harold Andrés Bartolo Moscoso", "3028305818" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("037925a1-f210-41bf-9239-bf82f6a5006f"), "Laptop", "PC Gamer Tauret Orchid TO66 Intel Core i5-12400 GTX 1660 6GB Ram", 3799000.0, 14 },
                    { new Guid("12f1bd66-3703-44af-807f-ff52e9b36fb6"), "Laptop", "PC Gamer Violet TV40 Intel Core i3-13100F GTX 1650 4GB Ram 16GB M", 2899000.0, 13 },
                    { new Guid("1af522da-29c3-4da5-9933-4debbafdbcbb"), "Laptop", "PC Gamer Tauret Amethyst TA75 AMD Ryzen 5 7600X RTX 4060 Ti 8GB R", 7999000.0, 5 },
                    { new Guid("3ec38686-7b38-40f4-9f63-d59e51454346"), "Laptop", "PC Gamer Tauret Orchid TO72 AMD Ryzen 5 5600X RTX 3050 8GB Ram 16", 5799000.0, 21 },
                    { new Guid("5a5fa050-b0e2-4a7f-ba9a-73ccfe54aafc"), "Laptop", "PC Mallow TM97 AMD Ryzen 5 4600G Ram 8GB SSD 480GB", 1650000.0, 1 },
                    { new Guid("8c5a76e0-27ae-4cd4-9606-56e536e87439"), "Laptop", "PC Gamer Tauret Orchid TO70 AMD Ryzen 5 4600G GTX 1660 Ti 6GB Ram", 3499000.0, 15 },
                    { new Guid("a070c89d-269a-4119-b627-ed8c1100d8fe"), "Laptop", "PC Gamer Tauret Amethyst TA73 Intel core 13400F RTX 3060 Ti 8GB R", 3899000.0, 10 },
                    { new Guid("a98bb094-fd89-4cb4-b05a-0e5621d0a1e3"), "Laptop", "PC Gamer Tauret Amethyst TA53 AMD Ryzen 7 5800X3D RTX 3060 12GB R", 6599000.0, 8 },
                    { new Guid("bec964c6-f87f-4507-8b96-dc79796c4684"), "Laptop", "PC Gamer Mallow TM96 AMD Ryzen 5 5600G Ram 16GB M.2 512GB", 1999000.0, 11 },
                    { new Guid("c1248fe2-4920-4c0e-ba44-84a25fe903b4"), "Laptop", "PC Mallow TM92 AMD Ryzen 3 4100 GT 1030 2GB Ram 8GB M.2 256GB *Ob", 1599000.0, 0 },
                    { new Guid("c44c0074-6782-493b-9f84-7fe02c228a6a"), "Laptop", "PC Gamer Tauret Amethyst TA70 Alto Rendimiento AMD Ryzen 7 5700X", 5150000.0, 13 },
                    { new Guid("ce0ca811-060b-4e3a-ab54-99d041b5f8f3"), "Laptop", "PC Gamer Tauret Amethyst TA66 intel Core i5-13400F RTX 3070 8GB R", 6799000.0, 4 },
                    { new Guid("e3b08ce6-6218-4e48-b8c9-7d34f520afad"), "Laptop", "PC Gamer Tauret Amethyst TA71 AMD Ryzen 7 5800X3D RTX 4070 12GB R", 7999000.0, 10 },
                    { new Guid("fda342cc-dc03-4995-9fa4-e436ead8b59f"), "Laptop", "PC Gamer Tauret Amethyst TA76 AMD Ryzen 7 7700X RTX 4070 Ti 12GB", 9799000.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a013c111-a455-4b0f-8adf-e40c04922abb"), "Regular" },
                    { new Guid("ec8367a7-e178-41c5-a2a4-882545e026ec"), "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "PasswordHash", "PasswordSalt", "PersonId", "RoleId", "Username" },
                values: new object[] { new Guid("c95ee721-efdd-4e25-b969-45a9f6235e45"), true, "omXELhhijwpUNqzdst2HTtuY8oplkmgyRi7o45Ptrjc=", "aL5obEwZGtIprvlpvLA6BQ==", new Guid("5eb7d209-020b-477c-9e01-db717874faf6"), new Guid("ec8367a7-e178-41c5-a2a4-882545e026ec"), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

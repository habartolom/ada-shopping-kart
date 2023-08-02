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
                    Stock = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("4cc04711-3fef-4701-87fc-3afbb93f0d77"), "PC Gamer Violet TV40 Intel Core i3-13100F GTX 1650 4GB Ram 16GB M", 2899000.0, 13 },
                    { new Guid("553fe4cc-4135-4d38-8d48-63e2674fefd9"), "PC Gamer Tauret Amethyst TA66 intel Core i5-13400F RTX 3070 8GB R", 6799000.0, 4 },
                    { new Guid("5549ecc8-d045-4ab3-9dee-91a5f9309168"), "PC Mallow TM97 AMD Ryzen 5 4600G Ram 8GB SSD 480GB", 1650000.0, 1 },
                    { new Guid("6d4e1dc4-f1d7-423f-99bb-730628a64d55"), "PC Gamer Tauret Amethyst TA75 AMD Ryzen 5 7600X RTX 4060 Ti 8GB R", 7999000.0, 5 },
                    { new Guid("75af7488-cb99-4832-86d3-3f8ad4ac59bd"), "PC Gamer Tauret Amethyst TA73 Intel core 13400F RTX 3060 Ti 8GB R", 3899000.0, 10 },
                    { new Guid("791418a9-f7bf-49a1-a3ba-0189b4d90c4b"), "PC Gamer Mallow TM96 AMD Ryzen 5 5600G Ram 16GB M.2 512GB", 1999000.0, 11 },
                    { new Guid("9814abc4-a82e-4ced-a580-374262cac081"), "PC Gamer Tauret Amethyst TA53 AMD Ryzen 7 5800X3D RTX 3060 12GB R", 6599000.0, 8 },
                    { new Guid("a9867bb9-8f6a-4669-96aa-297f8f25ddf2"), "PC Gamer Tauret Amethyst TA71 AMD Ryzen 7 5800X3D RTX 4070 12GB R", 7999000.0, 10 },
                    { new Guid("af655618-a03a-4517-9070-8b2db89a3a7c"), "PC Gamer Tauret Amethyst TA76 AMD Ryzen 7 7700X RTX 4070 Ti 12GB", 9799000.0, 5 },
                    { new Guid("b40a2618-34ff-434f-8536-750386ff7417"), "PC Gamer Tauret Orchid TO70 AMD Ryzen 5 4600G GTX 1660 Ti 6GB Ram", 3499000.0, 15 },
                    { new Guid("c53892e1-11c5-45af-943a-c5ed141eb8b1"), "PC Gamer Tauret Orchid TO66 Intel Core i5-12400 GTX 1660 6GB Ram", 3799000.0, 14 },
                    { new Guid("cce3fadb-ff90-4f77-8a6c-0c6df0dfb460"), "PC Gamer Tauret Amethyst TA70 Alto Rendimiento AMD Ryzen 7 5700X", 5150000.0, 13 },
                    { new Guid("d2ee4b30-b75e-413c-9657-26fe88fab079"), "PC Mallow TM92 AMD Ryzen 3 4100 GT 1030 2GB Ram 8GB M.2 256GB *Ob", 1599000.0, 0 },
                    { new Guid("e666f08f-f2f2-4b21-9f95-68592352b1d1"), "PC Gamer Tauret Orchid TO72 AMD Ryzen 5 5600X RTX 3050 8GB Ram 16", 5799000.0, 21 }
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

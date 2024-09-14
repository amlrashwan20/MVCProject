using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCProject.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Hijab for Women Soft Cotton", "Hijab" },
                    { 2, " Hijab Solid Color 3 Layers Hijab", " Khimar " },
                    { 3, "Muslim prayer long dress", " Dresses" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Code", "Description", "PathImage", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "100h", "Hijab Scarf for Women Soft Cotton ", "https://m.media-amazon.com/images/I/619BQu-V1RL._AC_SX569_.jpg", 150m, 10, "Hijab Scarf " },
                    { 2, 1, "200v", "The Voile Chic jersey hijab scarf ", "https://m.media-amazon.com/images/I/71ijjqs2hBL._AC_SX569_.jpg", 250m, 20, "VOILE CHIC Premium Jersey Hijab " },
                    { 3, 3, "300d", "OBEEII Muslim Dress for Women", "https://m.media-amazon.com/images/I/41bxd5WS9SL._AC_SX569_.jpg", 550m, 5, "Satin Dress" },
                    { 4, 3, "400d", "Abayas for Women Muslim Dress", "https://m.media-amazon.com/images/I/51BesB1bCIL._AC_SX569_.jpg", 650m, 15, "Sleeve Maxi Dress" },
                    { 5, 2, "300kh", "OLEMEK Women Muslim Long Khimar ", "https://m.media-amazon.com/images/I/71wzUtsdv3L._AC_SX569_.jpg", 200m, 10, "Long Khimar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

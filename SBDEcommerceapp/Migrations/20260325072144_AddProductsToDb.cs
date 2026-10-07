using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SBDEcommerceapp.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ListPrice", "Price", "Price100", "Price50", "SKU", "Title" },
                values: new object[,]
                {
                    { 1, "SBD", "High-performance training socks designed for comfort, durability, and support during intense workouts.", 60.0, 50.0, 40.0, 45.0, "SBD-SOCK-001", "SBD Resolve Socks" },
                    { 2, "SBD", "Heavy-duty lifting straps designed to improve grip and support during deadlifts and pulling exercises.", 180.0, 160.0, 140.0, 150.0, "SBD-STRAP-002", "SBD Nova Lifting Straps" },
                    { 3, "SBD", "Comfortable and durable training t-shirt made with breathable fabric for everyday workouts.", 120.0, 100.0, 80.0, 90.0, "SBD-TSHIRT-003", "SBD Forge T-Shirt Standard" },
                    { 4, "SBD", "Premium heavyweight hoodie designed for warmth, comfort, and durability during training or casual wear.", 300.0, 270.0, 230.0, 250.0, "SBD-HOODIE-004", "SBD Forge Hoodie" },
                    { 5, "SBD", "Soft and durable sweatshirt ideal for training sessions and everyday use.", 250.0, 220.0, 180.0, 200.0, "SBD-SWEAT-005", "SBD Forge Sweatshirt" },
                    { 6, "SBD", "Athletic joggers designed for flexibility, comfort, and performance in and out of the gym.", 200.0, 180.0, 150.0, 160.0, "SBD-JOGGER-006", "SBD Nova Joggers" },
                    { 7, "SBD", "High-performance weightlifting t-shirt built for durability and comfort during heavy training.", 130.0, 110.0, 90.0, 100.0, "SBD-TSHIRT-007", "SBD Resolve Weightlifting T-Shirt" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

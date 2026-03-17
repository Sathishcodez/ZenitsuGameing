using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZenitsuGameing.Migrations
{
    /// <inheritdoc />
    public partial class seedproduct : Migration
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
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Id", "Category", "Creator", "Description", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "RPG", "FromSoftware", "An open-world action RPG set in the Lands Between.", 59.990000000000002, 49.990000000000002, 54.990000000000002, "Elden Ring" },
                    { 2, "Action", "id Software", "Fast-paced first-person shooter with intense combat.", 49.990000000000002, 39.990000000000002, 44.990000000000002, "DOOM Eternal" },
                    { 3, "Adventure", "Nintendo", "An open-world adventure in the kingdom of Hyrule.", 69.989999999999995, 59.990000000000002, 64.989999999999995, "The Legend of Zelda: Breath of the Wild" }
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

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportsClub.WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSnacksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    SnackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SnackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SnackDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SnackPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.SnackId);
                });

            migrationBuilder.InsertData(
                table: "Snacks",
                columns: new[] { "SnackId", "SnackDescription", "SnackName", "SnackPrice" },
                values: new object[,]
                {
                    { 1, "Salted potato chips (bag)", "Chips", 1.50m },
                    { 2, "Milk chocolate 50g", "Chocolate Bar", 1.25m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snacks");
        }
    }
}

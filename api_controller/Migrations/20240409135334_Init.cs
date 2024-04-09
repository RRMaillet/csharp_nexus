using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_controller.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.FloorId);
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "FloorId", "FloorColor", "FloorDescription", "FloorName", "Price" },
                values: new object[,]
                {
                    { 12, "Beige", "Beige Laminate Floor", "Laminate", 1.53 },
                    { 15, "Brown", "Brown Cork Floor", "Cork", 2.1000000000000001 },
                    { 18, "Black", "Black Leather Floor", "Leather", 4.5300000000000002 },
                    { 19, "Green", "Green Wood Floor", "Wood", 2.9900000000000002 },
                    { 21, "Clear", "Clear Polycarbonate Floor", "Polycarbonate", 0.94999999999999996 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Floors");
        }
    }
}

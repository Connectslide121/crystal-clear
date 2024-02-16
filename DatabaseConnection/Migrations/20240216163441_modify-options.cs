using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class modifyoptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Cities_CityId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_CityId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Options");

            migrationBuilder.CreateTable(
                name: "CityOption",
                columns: table => new
                {
                    AvailableOptionsOptionId = table.Column<int>(type: "int", nullable: false),
                    CitiesCityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityOption", x => new { x.AvailableOptionsOptionId, x.CitiesCityId });
                    table.ForeignKey(
                        name: "FK_CityOption_Cities_CitiesCityId",
                        column: x => x.CitiesCityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityOption_Options_AvailableOptionsOptionId",
                        column: x => x.AvailableOptionsOptionId,
                        principalTable: "Options",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CityOption_CitiesCityId",
                table: "CityOption",
                column: "CitiesCityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityOption");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_CityId",
                table: "Options",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Cities_CityId",
                table: "Options",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class renameids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityOption_Cities_CitiesCityId",
                table: "CityOption");

            migrationBuilder.DropForeignKey(
                name: "FK_CityOption_Options_AvailableOptionsOptionId",
                table: "CityOption");

            migrationBuilder.RenameColumn(
                name: "QuoteId",
                table: "Quotes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OptionId",
                table: "Options",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CitiesCityId",
                table: "CityOption",
                newName: "CitiesId");

            migrationBuilder.RenameColumn(
                name: "AvailableOptionsOptionId",
                table: "CityOption",
                newName: "AvailableOptionsId");

            migrationBuilder.RenameIndex(
                name: "IX_CityOption_CitiesCityId",
                table: "CityOption",
                newName: "IX_CityOption_CitiesId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Cities",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CityOption_Cities_CitiesId",
                table: "CityOption",
                column: "CitiesId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityOption_Options_AvailableOptionsId",
                table: "CityOption",
                column: "AvailableOptionsId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityOption_Cities_CitiesId",
                table: "CityOption");

            migrationBuilder.DropForeignKey(
                name: "FK_CityOption_Options_AvailableOptionsId",
                table: "CityOption");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Quotes",
                newName: "QuoteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Options",
                newName: "OptionId");

            migrationBuilder.RenameColumn(
                name: "CitiesId",
                table: "CityOption",
                newName: "CitiesCityId");

            migrationBuilder.RenameColumn(
                name: "AvailableOptionsId",
                table: "CityOption",
                newName: "AvailableOptionsOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_CityOption_CitiesId",
                table: "CityOption",
                newName: "IX_CityOption_CitiesCityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cities",
                newName: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityOption_Cities_CitiesCityId",
                table: "CityOption",
                column: "CitiesCityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityOption_Options_AvailableOptionsOptionId",
                table: "CityOption",
                column: "AvailableOptionsOptionId",
                principalTable: "Options",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

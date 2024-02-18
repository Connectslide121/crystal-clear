using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class fixclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "SelectedOptionsIds",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Quotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuoteId",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CityId",
                table: "Quotes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuoteId",
                table: "Options",
                column: "QuoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Quotes_QuoteId",
                table: "Options",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "QuoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Cities_CityId",
                table: "Quotes",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Quotes_QuoteId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Cities_CityId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_CityId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Options_QuoteId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "Options");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Quotes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SelectedOptionsIds",
                table: "Quotes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

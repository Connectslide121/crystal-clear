using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class addCitytoQuote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CityId",
                table: "Quotes",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Cities_CityId",
                table: "Quotes",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Cities_CityId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_CityId",
                table: "Quotes");
        }
    }
}

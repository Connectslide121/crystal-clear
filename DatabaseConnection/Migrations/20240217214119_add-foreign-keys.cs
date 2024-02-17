using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Cities_CityId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_CityId",
                table: "Quotes");

            migrationBuilder.RenameColumn(
                name: "SelectedOptions",
                table: "Quotes",
                newName: "SelectedOptionsIds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SelectedOptionsIds",
                table: "Quotes",
                newName: "SelectedOptions");

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
    }
}

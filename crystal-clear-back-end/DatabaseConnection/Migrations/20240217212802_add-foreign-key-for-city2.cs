using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkeyforcity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Quotes_QuoteId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_QuoteId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "Options");

            migrationBuilder.AddColumn<string>(
                name: "SelectedOptions",
                table: "Quotes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedOptions",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "QuoteId",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuoteId",
                table: "Options",
                column: "QuoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Quotes_QuoteId",
                table: "Options",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id");
        }
    }
}

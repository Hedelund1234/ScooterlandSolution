using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scooterland.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedKommentarToSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kommentar",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kommentar",
                table: "Sales");
        }
    }
}

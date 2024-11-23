using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scooterland.Server.Migrations
{
    /// <inheritdoc />
    public partial class SpecializationLinkToSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SpecializationId",
                table: "Sales",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Specializations_SpecializationId",
                table: "Sales",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "SpecializationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Specializations_SpecializationId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_SpecializationId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Sales");
        }
    }
}

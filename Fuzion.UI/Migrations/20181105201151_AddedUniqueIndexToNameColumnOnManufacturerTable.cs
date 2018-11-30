using Microsoft.EntityFrameworkCore.Migrations;

namespace Fuzion.UI.Migrations
{
    public partial class AddedUniqueIndexToNameColumnOnManufacturerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers");
        }
    }
}
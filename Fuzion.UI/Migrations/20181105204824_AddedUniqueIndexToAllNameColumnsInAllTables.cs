using Microsoft.EntityFrameworkCore.Migrations;

namespace Fuzion.UI.Migrations
{
    public partial class AddedUniqueIndexToAllNameColumnsInAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Purposes_Name",
                table: "Purposes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OS_Name",
                table: "OS",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_Name",
                table: "Models",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hardware_AssetNumber",
                table: "Hardware",
                column: "AssetNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Purposes_Name",
                table: "Purposes");

            migrationBuilder.DropIndex(
                name: "IX_OS_Name",
                table: "OS");

            migrationBuilder.DropIndex(
                name: "IX_Models_Name",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Hardware_AssetNumber",
                table: "Hardware");
        }
    }
}
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fuzion.UI.Migrations
{
    public partial class AddedOneToManyRelationshipBetweeenManufacturerAndModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Models",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerId",
                table: "Models",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerId",
                table: "Models",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Manufacturers_ManufacturerId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_ManufacturerId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Models");
        }
    }
}
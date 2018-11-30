using Microsoft.EntityFrameworkCore.Migrations;

namespace Fuzion.UI.Migrations
{
    public partial class AddedNavigationPropertyForHardwareNotesRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Hardware_HardwareId",
                table: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "Notes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Hardware_HardwareId",
                table: "Notes",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Hardware_HardwareId",
                table: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "Notes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Hardware_HardwareId",
                table: "Notes",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
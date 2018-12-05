using Microsoft.EntityFrameworkCore.Migrations;

namespace Fuzion.UI.Migrations
{
    public partial class AddedHardareIdNavigationPropertyToAssignmentHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentHistory_Hardware_HardwareId",
                table: "AssignmentHistory");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "AssignmentHistory",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentHistory_Hardware_HardwareId",
                table: "AssignmentHistory",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentHistory_Hardware_HardwareId",
                table: "AssignmentHistory");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "AssignmentHistory",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentHistory_Hardware_HardwareId",
                table: "AssignmentHistory",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

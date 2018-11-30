using Microsoft.EntityFrameworkCore.Migrations;

namespace Fuzion.UI.Migrations
{
    public partial class AddedNavigationPropertiesToHardwareTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_OS_OSId",
                table: "Hardware");

            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_Purposes_PurposeId",
                table: "Hardware");

            migrationBuilder.AlterColumn<int>(
                name: "PurposeId",
                table: "Hardware",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OSId",
                table: "Hardware",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hardware_OS_OSId",
                table: "Hardware",
                column: "OSId",
                principalTable: "OS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hardware_Purposes_PurposeId",
                table: "Hardware",
                column: "PurposeId",
                principalTable: "Purposes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_OS_OSId",
                table: "Hardware");

            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_Purposes_PurposeId",
                table: "Hardware");

            migrationBuilder.AlterColumn<int>(
                name: "PurposeId",
                table: "Hardware",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OSId",
                table: "Hardware",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Hardware_OS_OSId",
                table: "Hardware",
                column: "OSId",
                principalTable: "OS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hardware_Purposes_PurposeId",
                table: "Hardware",
                column: "PurposeId",
                principalTable: "Purposes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
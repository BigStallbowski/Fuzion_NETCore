using Microsoft.EntityFrameworkCore.Migrations;

namespace Fuzion.UI.Migrations
{
    public partial class ChangedBodyColumnInAssignmentHistoryTableToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "AssignmentHistory",
                maxLength: 1055,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 1055);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Body",
                table: "AssignmentHistory",
                maxLength: 1055,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1055);
        }
    }
}

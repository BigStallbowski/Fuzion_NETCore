using Microsoft.EntityFrameworkCore.Migrations;

namespace Fuzion.UI.Migrations
{
    public partial class RemovedManyToManyRelationshipBetweenHardwareTypeAndOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardwareTypeOS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HardwareTypeOS",
                columns: table => new
                {
                    HardwareTypeId = table.Column<int>(nullable: false),
                    OSId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareTypeOS", x => new { x.HardwareTypeId, x.OSId });
                    table.ForeignKey(
                        name: "FK_HardwareTypeOS_HardwareTypes_HardwareTypeId",
                        column: x => x.HardwareTypeId,
                        principalTable: "HardwareTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HardwareTypeOS_OS_OSId",
                        column: x => x.OSId,
                        principalTable: "OS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareTypeOS_OSId",
                table: "HardwareTypeOS",
                column: "OSId");
        }
    }
}

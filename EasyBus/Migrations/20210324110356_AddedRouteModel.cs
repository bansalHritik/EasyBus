using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBus.Migrations
{
    public partial class AddedRouteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceStopId = table.Column<long>(type: "int", nullable: true),
                    DestStopId = table.Column<long>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Stops_DestStopId",
                        column: x => x.DestStopId,
                        principalTable: "Stops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routes_Stops_SourceStopId",
                        column: x => x.SourceStopId,
                        principalTable: "Stops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DestStopId",
                table: "Routes",
                column: "DestStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_SourceStopId",
                table: "Routes",
                column: "SourceStopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}

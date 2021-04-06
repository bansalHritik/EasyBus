using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBus.DAL.Migrations
{
    public partial class AddByUserPropertyInBookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ByUser",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ByUser",
                table: "Bookings");
        }
    }
}

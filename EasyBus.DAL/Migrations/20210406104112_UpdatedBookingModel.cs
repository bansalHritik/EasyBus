using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBus.DAL.Migrations
{
    public partial class UpdatedBookingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Bookings",
                newName: "PassengerName");

            migrationBuilder.AddColumn<byte>(
                name: "Age",
                table: "Bookings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdProof",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Bookings",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "IdProof",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "PassengerName",
                table: "Bookings",
                newName: "User");

            migrationBuilder.AddColumn<short>(
                name: "NumberOfSeats",
                table: "Bookings",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}

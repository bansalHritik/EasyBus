using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBus.Migrations
{
    public partial class UpdatedBookingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Stops_ArrivalStopId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Stops_DepartureStopId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ArrivalStopId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ArrivalStopId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DateAndTime",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Fare",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "DepartureStopId",
                table: "Bookings",
                newName: "BusRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_DepartureStopId",
                table: "Bookings",
                newName: "IX_Bookings_BusRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BusRoutes_BusRouteId",
                table: "Bookings",
                column: "BusRouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BusRoutes_BusRouteId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "BusRouteId",
                table: "Bookings",
                newName: "DepartureStopId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_BusRouteId",
                table: "Bookings",
                newName: "IX_Bookings_DepartureStopId");

            migrationBuilder.AddColumn<int>(
                name: "ArrivalStopId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAndTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Fare",
                table: "Bookings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ArrivalStopId",
                table: "Bookings",
                column: "ArrivalStopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Stops_ArrivalStopId",
                table: "Bookings",
                column: "ArrivalStopId",
                principalTable: "Stops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Stops_DepartureStopId",
                table: "Bookings",
                column: "DepartureStopId",
                principalTable: "Stops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

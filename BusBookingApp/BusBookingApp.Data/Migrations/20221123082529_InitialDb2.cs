using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookingApp.Data.Migrations
{
    public partial class InitialDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 1,
                column: "BusSeatCapacity",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 2,
                column: "BusSeatCapacity",
                value: 48);

            migrationBuilder.UpdateData(
                table: "TravelDetails",
                keyColumn: "TravelDetailId",
                keyValue: 2,
                column: "BusId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 1,
                column: "BusSeatCapacity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 2,
                column: "BusSeatCapacity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "TravelDetails",
                keyColumn: "TravelDetailId",
                keyValue: 2,
                column: "BusId",
                value: 1);
        }
    }
}

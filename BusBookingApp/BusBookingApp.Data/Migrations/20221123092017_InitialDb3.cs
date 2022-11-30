using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookingApp.Data.Migrations
{
    public partial class InitialDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 10,
                column: "CustomerId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 11,
                column: "CustomerId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 13,
                column: "CustomerId",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 10,
                column: "CustomerId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 11,
                column: "CustomerId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 13,
                column: "CustomerId",
                value: 5);

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 3, 3, 13, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 5, 3, 14, 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 6, 3, 15, 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 7, 4, 1, 3 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 8, 5, 2, 3 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 9, 5, 3, 3 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 12, 5, 11, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets",
                column: "CustomerId");
        }
    }
}

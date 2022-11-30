using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookingApp.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusSeatCapacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerSurname = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "TravelDetails",
                columns: table => new
                {
                    TravelDetailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    PeronNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartureCityId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArrivalCityId = table.Column<int>(type: "INTEGER", nullable: false),
                    BusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelDetails", x => x.TravelDetailId);
                    table.ForeignKey(
                        name: "FK_TravelDetails_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelDetails_Cities_ArrivalCityId",
                        column: x => x.ArrivalCityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelDetails_Cities_DepartureCityId",
                        column: x => x.DepartureCityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TravelDetailId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeatNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TravelDetails_TravelDetailId",
                        column: x => x.TravelDetailId,
                        principalTable: "TravelDetails",
                        principalColumn: "TravelDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "BusSeatCapacity" },
                values: new object[] { 1, 40 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "BusSeatCapacity" },
                values: new object[] { 2, 50 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 1, "İstanbul" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 2, "Bursa" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 3, "Balıkesir" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 4, "Manisa" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 5, "İzmir" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 6, "Bolu" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 7, "Samsun" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 8, "Ordu" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 9, "Rize" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 10, "Eskişehir" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 11, "Afyon" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 12, "Isparta" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 13, "Antalya" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerName", "CustomerSurname", "Email", "PhoneNumber" },
                values: new object[] { 1, "Ahmet", "Yılmaz", "deneme@gmail.com", "5547455843" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerName", "CustomerSurname", "Email", "PhoneNumber" },
                values: new object[] { 2, "Mert", "Yılan", "deneme2@gmail.com", "5547455843" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerName", "CustomerSurname", "Email", "PhoneNumber" },
                values: new object[] { 3, "Hakkı", "Metin", "deneme3@gmail.com", "5547455843" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerName", "CustomerSurname", "Email", "PhoneNumber" },
                values: new object[] { 4, "Mustafa", "Yıldırım", "deneme4@gmail.com", "5547455843" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerName", "CustomerSurname", "Email", "PhoneNumber" },
                values: new object[] { 5, "Caner", "Şimşek", "deneme5@gmail.com", "5547455843" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerName", "CustomerSurname", "Email", "PhoneNumber" },
                values: new object[] { 6, "Berk", "Ok", "deneme6@gmail.com", "5547455843" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerName", "CustomerSurname", "Email", "PhoneNumber" },
                values: new object[] { 7, "Semih", "Yay", "deneme7@gmail.com", "5547455843" });

            migrationBuilder.InsertData(
                table: "TravelDetails",
                columns: new[] { "TravelDetailId", "ArrivalCityId", "BusId", "Date", "DepartureCityId", "PeronNumber", "Price", "Time" },
                values: new object[] { 1, 2, 1, "1.12.2022", 1, 15, 600.0, "19:00" });

            migrationBuilder.InsertData(
                table: "TravelDetails",
                columns: new[] { "TravelDetailId", "ArrivalCityId", "BusId", "Date", "DepartureCityId", "PeronNumber", "Price", "Time" },
                values: new object[] { 2, 2, 1, "1.12.2022", 1, 15, 600.0, "20:00" });

            migrationBuilder.InsertData(
                table: "TravelDetails",
                columns: new[] { "TravelDetailId", "ArrivalCityId", "BusId", "Date", "DepartureCityId", "PeronNumber", "Price", "Time" },
                values: new object[] { 3, 2, 1, "1.12.2022", 1, 15, 600.0, "21:00" });

            migrationBuilder.InsertData(
                table: "TravelDetails",
                columns: new[] { "TravelDetailId", "ArrivalCityId", "BusId", "Date", "DepartureCityId", "PeronNumber", "Price", "Time" },
                values: new object[] { 4, 3, 1, "2.12.2022", 2, 15, 500.0, "19:00" });

            migrationBuilder.InsertData(
                table: "TravelDetails",
                columns: new[] { "TravelDetailId", "ArrivalCityId", "BusId", "Date", "DepartureCityId", "PeronNumber", "Price", "Time" },
                values: new object[] { 5, 3, 2, "2.12.2022", 2, 15, 500.0, "20:00" });

            migrationBuilder.InsertData(
                table: "TravelDetails",
                columns: new[] { "TravelDetailId", "ArrivalCityId", "BusId", "Date", "DepartureCityId", "PeronNumber", "Price", "Time" },
                values: new object[] { 6, 3, 2, "2.12.2022", 2, 15, 500.0, "21:00" });

            migrationBuilder.InsertData(
                table: "TravelDetails",
                columns: new[] { "TravelDetailId", "ArrivalCityId", "BusId", "Date", "DepartureCityId", "PeronNumber", "Price", "Time" },
                values: new object[] { 7, 5, 2, "3.12.2022", 3, 15, 400.0, "10:00" });

            migrationBuilder.InsertData(
                table: "TravelDetails",
                columns: new[] { "TravelDetailId", "ArrivalCityId", "BusId", "Date", "DepartureCityId", "PeronNumber", "Price", "Time" },
                values: new object[] { 8, 5, 2, "3.12.2022", 3, 15, 400.0, "11:00" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 1, 1, 15, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 2, 2, 11, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 3, 3, 13, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 4, 3, 13, 2 });

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
                values: new object[] { 10, 5, 4, 3 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 11, 5, 20, 4 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 12, 5, 11, 4 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 13, 5, 5, 4 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CustomerId", "SeatNumber", "TravelDetailId" },
                values: new object[] { 14, 5, 9, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TravelDetailId",
                table: "Tickets",
                column: "TravelDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelDetails_ArrivalCityId",
                table: "TravelDetails",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelDetails_BusId",
                table: "TravelDetails",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelDetails_DepartureCityId",
                table: "TravelDetails",
                column: "DepartureCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "TravelDetails");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookingApp.Data.Migrations
{
    public partial class FinalDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "CompanyIntroductions",
                columns: table => new
                {
                    CompanyIntroductionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyDescriptionTitle = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyIntroductions", x => x.CompanyIntroductionId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: true),
                    BranchPhone = table.Column<string>(type: "TEXT", nullable: true),
                    BranchAddress = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Supports",
                columns: table => new
                {
                    SupportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Topic = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.SupportId);
                });

            migrationBuilder.InsertData(
                table: "CompanyIntroductions",
                columns: new[] { "CompanyIntroductionId", "CompanyDescription", "CompanyDescriptionTitle" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Scelerisque in dictum non consectetur a erat nam at lectus. Eget aliquet nibh praesent tristique magna. Lectus nulla at volutpat diam ut venenatis tellus in metus. Felis eget nunc lobortis mattis aliquam faucibus purus in. Mattis aliquam faucibus purus in. Vulputate ut pharetra sit amet aliquam id diam. Quam elementum pulvinar etiam non quam lacus suspendisse faucibus. Ut sem viverra aliquet eget. Pellentesque habitant morbi tristique senectus et netus. Commodo elit at imperdiet dui. Dignissim enim sit amet venenatis urna cursus eget nunc scelerisque. Lectus mauris ultrices eros in cursus turpis. Proin sed libero enim sed faucibus turpis in eu mi. Ullamcorper dignissim cras tincidunt lobortis feugiat vivamus. Et tortor consequat id porta nibh venenatis cras sed. Amet purus gravida quis blandit turpis cursus.", "Misyon ve Vizyon" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "BranchAddress", "BranchName", "BranchPhone" },
                values: new object[] { 1, "euismod nisi porta lorem mollis aliquam ut", "İstanbul", "01111111111" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "BranchAddress", "BranchName", "BranchPhone" },
                values: new object[] { 2, "euismod nisi porta lorem mollis aliquam ut", "Ankara", "01111111111" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "BranchAddress", "BranchName", "BranchPhone" },
                values: new object[] { 3, "euismod nisi porta lorem mollis aliquam ut", "Bursa", "01111111111" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "BranchAddress", "BranchName", "BranchPhone" },
                values: new object[] { 4, "euismod nisi porta lorem mollis aliquam ut", "İzmir", "01111111111" });

            migrationBuilder.InsertData(
                table: "Supports",
                columns: new[] { "SupportId", "Email", "FirstName", "LastName", "PhoneNumber", "Text", "Topic" },
                values: new object[] { 1, "metintekin@gmail.com", "Metin", "Tekin", "00111225444", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet.", "Şikayet" });

            migrationBuilder.InsertData(
                table: "Supports",
                columns: new[] { "SupportId", "Email", "FirstName", "LastName", "PhoneNumber", "Text", "Topic" },
                values: new object[] { 2, "metintekin@gmail.com", "Metin", "Tekin", "00111225444", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet.", "Şikayet" });

            migrationBuilder.InsertData(
                table: "Supports",
                columns: new[] { "SupportId", "Email", "FirstName", "LastName", "PhoneNumber", "Text", "Topic" },
                values: new object[] { 3, "metintekin@gmail.com", "Metin", "Tekin", "00111225444", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet.", "Şikayet" });

            migrationBuilder.InsertData(
                table: "Supports",
                columns: new[] { "SupportId", "Email", "FirstName", "LastName", "PhoneNumber", "Text", "Topic" },
                values: new object[] { 4, "metintekin@gmail.com", "Metin", "Tekin", "00111225444", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum ut tristique et egestas quis ipsum suspendisse. Fames ac turpis egestas integer eget aliquet.", "Şikayet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyIntroductions");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Supports");

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
        }
    }
}

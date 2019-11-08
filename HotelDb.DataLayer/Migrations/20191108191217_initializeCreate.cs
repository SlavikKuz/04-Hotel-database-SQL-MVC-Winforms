using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDb.DataLayer.Migrations
{
    public partial class initializeCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookedRoomsList",
                columns: table => new
                {
                    BookingId = table.Column<long>(nullable: false),
                    RoomId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedRoomsList", x => new { x.BookingId, x.RoomId });
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(nullable: false),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    DayFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DayTill = table.Column<DateTime>(type: "date", nullable: false),
                    WithKids = table.Column<bool>(nullable: false),
                    BookingStatus = table.Column<int>(nullable: false),
                    BookingInfo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    InvoiceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ClientInfo = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "GuestsList",
                columns: table => new
                {
                    BookingId = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestsList", x => new { x.ClientId, x.BookingId });
                });

            migrationBuilder.CreateTable(
                name: "HolidaysList",
                columns: table => new
                {
                    HolidayId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayDay = table.Column<DateTime>(type: "date", nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidaysList", x => x.HolidayId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(nullable: false),
                    BookingId = table.Column<long>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "RoomPrices",
                columns: table => new
                {
                    RoomId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AveragePrice = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    WeekendPrice = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    HolidayPrice = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPrices", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    NumberBeds = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    RoomInfo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Ready = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedRoomsList");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "GuestsList");

            migrationBuilder.DropTable(
                name: "HolidaysList");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "RoomPrices");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}

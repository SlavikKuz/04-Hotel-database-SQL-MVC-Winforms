using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDb.DataLayer.Migrations
{
    public partial class initializeCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HolidayList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HolidayDay = table.Column<DateTime>(type: "date", nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(6,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomPrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AveragePrice = table.Column<decimal>(type: "decimal(5,0)", nullable: false),
                    WeekendPrice = table.Column<decimal>(type: "decimal(5,0)", nullable: false),
                    HolidayPrice = table.Column<decimal>(type: "decimal(5,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ClientInfo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BookingDLId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: true),
                    InvoiceId = table.Column<Guid>(nullable: true),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    DayFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DayTill = table.Column<DateTime>(type: "date", nullable: false),
                    WithKids = table.Column<bool>(nullable: false),
                    Info = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    NumberBeds = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    RoomInfo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Ready = table.Column<bool>(nullable: false),
                    RoomPriceId = table.Column<Guid>(nullable: true),
                    BookingDLId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Bookings_BookingDLId",
                        column: x => x.BookingDLId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomPrice_RoomPriceId",
                        column: x => x.RoomPriceId,
                        principalTable: "RoomPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientId",
                table: "Bookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_InvoiceId",
                table: "Bookings",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BookingDLId",
                table: "Clients",
                column: "BookingDLId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BookingDLId",
                table: "Rooms",
                column: "BookingDLId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomPriceId",
                table: "Rooms",
                column: "RoomPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Bookings_BookingDLId",
                table: "Clients",
                column: "BookingDLId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Clients_ClientId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "HolidayList");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomPrice");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}

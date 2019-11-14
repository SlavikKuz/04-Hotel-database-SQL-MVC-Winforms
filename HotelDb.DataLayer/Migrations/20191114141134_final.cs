using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDb.DataLayer.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestList",
                table: "GuestList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestList",
                table: "GuestList",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestList",
                table: "GuestList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestList",
                table: "GuestList",
                column: "BookingId");
        }
    }
}

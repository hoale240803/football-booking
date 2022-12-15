using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballBooking.Migrations
{
    public partial class Add_StadiumStatus_Into_Stadium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StadiumStatus",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "StadiumStatus",
                table: "Stadium",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StadiumStatus",
                table: "Stadium");

            migrationBuilder.AddColumn<int>(
                name: "StadiumStatus",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

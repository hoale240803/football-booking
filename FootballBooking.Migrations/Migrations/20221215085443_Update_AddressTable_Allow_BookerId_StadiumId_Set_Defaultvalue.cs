using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballBooking.Migrations
{
    public partial class Update_AddressTable_Allow_BookerId_StadiumId_Set_Defaultvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Booker_BookerId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Stadium_StadiumId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_BookerId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StadiumId",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "StadiumId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookerId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Address_BookerId",
                table: "Address",
                column: "BookerId",
                unique: true,
                filter: "[BookerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StadiumId",
                table: "Address",
                column: "StadiumId",
                unique: true,
                filter: "[StadiumId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Booker_BookerId",
                table: "Address",
                column: "BookerId",
                principalTable: "Booker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Stadium_StadiumId",
                table: "Address",
                column: "StadiumId",
                principalTable: "Stadium",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Booker_BookerId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Stadium_StadiumId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_BookerId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StadiumId",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "StadiumId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BookerId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_BookerId",
                table: "Address",
                column: "BookerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_StadiumId",
                table: "Address",
                column: "StadiumId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Booker_BookerId",
                table: "Address",
                column: "BookerId",
                principalTable: "Booker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Stadium_StadiumId",
                table: "Address",
                column: "StadiumId",
                principalTable: "Stadium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

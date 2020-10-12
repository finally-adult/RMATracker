using Microsoft.EntityFrameworkCore.Migrations;

namespace RMATracker.Migrations
{
    public partial class RMAonlyhasonepart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SerialNumbers_RMAId",
                table: "SerialNumbers");

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_RMAId",
                table: "SerialNumbers",
                column: "RMAId",
                unique: true,
                filter: "[RMAId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SerialNumbers_RMAId",
                table: "SerialNumbers");

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_RMAId",
                table: "SerialNumbers",
                column: "RMAId");
        }
    }
}

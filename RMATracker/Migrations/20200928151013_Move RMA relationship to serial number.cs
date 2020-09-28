using Microsoft.EntityFrameworkCore.Migrations;

namespace RMATracker.Migrations
{
    public partial class MoveRMArelationshiptoserialnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_RMAs_RMAId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_RMAId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "RMAId",
                table: "Parts");

            migrationBuilder.AddColumn<int>(
                name: "RMAId",
                table: "SerialNumbers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_RMAId",
                table: "SerialNumbers",
                column: "RMAId");

            migrationBuilder.AddForeignKey(
                name: "FK_SerialNumbers_RMAs_RMAId",
                table: "SerialNumbers",
                column: "RMAId",
                principalTable: "RMAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumbers_RMAs_RMAId",
                table: "SerialNumbers");

            migrationBuilder.DropIndex(
                name: "IX_SerialNumbers_RMAId",
                table: "SerialNumbers");

            migrationBuilder.DropColumn(
                name: "RMAId",
                table: "SerialNumbers");

            migrationBuilder.AddColumn<int>(
                name: "RMAId",
                table: "Parts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_RMAId",
                table: "Parts",
                column: "RMAId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_RMAs_RMAId",
                table: "Parts",
                column: "RMAId",
                principalTable: "RMAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

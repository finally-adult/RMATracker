using Microsoft.EntityFrameworkCore.Migrations;

namespace RMATracker.Migrations
{
    public partial class NullabelRMAinPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_RMAs_RMAId",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "RMAId",
                table: "Parts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_RMAs_RMAId",
                table: "Parts",
                column: "RMAId",
                principalTable: "RMAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_RMAs_RMAId",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "RMAId",
                table: "Parts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_RMAs_RMAId",
                table: "Parts",
                column: "RMAId",
                principalTable: "RMAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

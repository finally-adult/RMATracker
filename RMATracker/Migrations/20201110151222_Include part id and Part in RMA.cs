using Microsoft.EntityFrameworkCore.Migrations;

namespace RMATracker.Migrations
{
    public partial class IncludepartidandPartinRMA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "RMAs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RMAs_PartId",
                table: "RMAs",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_RMAs_Parts_PartId",
                table: "RMAs",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RMAs_Parts_PartId",
                table: "RMAs");

            migrationBuilder.DropIndex(
                name: "IX_RMAs_PartId",
                table: "RMAs");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "RMAs");
        }
    }
}

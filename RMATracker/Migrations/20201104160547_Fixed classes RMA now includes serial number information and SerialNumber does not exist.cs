using Microsoft.EntityFrameworkCore.Migrations;

namespace RMATracker.Migrations
{
    public partial class FixedclassesRMAnowincludesserialnumberinformationandSerialNumberdoesnotexist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerialNumbers");

            migrationBuilder.AddColumn<string>(
                name: "RepairDepot",
                table: "RMAs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepairVendor",
                table: "RMAs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumberReceived",
                table: "RMAs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumberSent",
                table: "RMAs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingVendor",
                table: "RMAs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrackingNumber",
                table: "RMAs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityInField",
                table: "Parts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityOnHand",
                table: "Parts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityOutForRepair",
                table: "Parts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepairDepot",
                table: "RMAs");

            migrationBuilder.DropColumn(
                name: "RepairVendor",
                table: "RMAs");

            migrationBuilder.DropColumn(
                name: "SerialNumberReceived",
                table: "RMAs");

            migrationBuilder.DropColumn(
                name: "SerialNumberSent",
                table: "RMAs");

            migrationBuilder.DropColumn(
                name: "ShippingVendor",
                table: "RMAs");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "RMAs");

            migrationBuilder.DropColumn(
                name: "QuantityInField",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "QuantityOnHand",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "QuantityOutForRepair",
                table: "Parts");

            migrationBuilder.CreateTable(
                name: "SerialNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutForRepair = table.Column<bool>(type: "bit", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    RMAId = table.Column<int>(type: "int", nullable: true),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerialNumbers_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerialNumbers_RMAs_RMAId",
                        column: x => x.RMAId,
                        principalTable: "RMAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_PartId",
                table: "SerialNumbers",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_RMAId",
                table: "SerialNumbers",
                column: "RMAId",
                unique: true,
                filter: "[RMAId] IS NOT NULL");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingApp.Infrastructure.Migrations
{
    public partial class initiatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookedQuantity = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, "resource_0", 10 },
                    { 2, "resource_1", 10 },
                    { 3, "resource_2", 10 },
                    { 4, "resource_3", 10 },
                    { 5, "resource_4", 10 },
                    { 6, "resource_5", 10 },
                    { 7, "resource_6", 10 },
                    { 8, "resource_7", 10 },
                    { 9, "resource_8", 10 },
                    { 10, "resource_9", 10 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookedQuantity", "DateFrom", "DateTo", "ResourceId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(322), new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7348), 1 },
                    { 2, 0, new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7684), new DateTime(2022, 2, 12, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7688), 2 },
                    { 3, 0, new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7693), new DateTime(2022, 2, 13, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7694), 3 },
                    { 4, 0, new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7695), new DateTime(2022, 2, 14, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7696), 4 },
                    { 5, 0, new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7697), new DateTime(2022, 2, 15, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7698), 5 },
                    { 6, 0, new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7699), new DateTime(2022, 2, 16, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7699), 6 },
                    { 7, 0, new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7700), new DateTime(2022, 2, 17, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7701), 7 },
                    { 8, 0, new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7702), new DateTime(2022, 2, 18, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7703), 8 },
                    { 9, 0, new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7704), new DateTime(2022, 2, 19, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7704), 9 },
                    { 10, 0, new DateTime(2022, 2, 11, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7705), new DateTime(2022, 2, 20, 1, 28, 23, 186, DateTimeKind.Local).AddTicks(7706), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ResourceId",
                table: "Bookings",
                column: "ResourceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}

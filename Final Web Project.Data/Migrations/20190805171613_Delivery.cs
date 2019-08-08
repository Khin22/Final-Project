using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Web_Project.Data.Migrations
{
    public partial class Delivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryId",
                table: "Receipts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    RecipientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_DeliveryId",
                table: "Receipts",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_RecipientId",
                table: "Deliveries",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Deliveries_DeliveryId",
                table: "Receipts",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Deliveries_DeliveryId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_DeliveryId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Receipts");
        }
    }
}

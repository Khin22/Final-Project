using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Web_Project.Data.Migrations
{
    public partial class DelDet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IssuedOn",
                table: "DeliveryDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RecipientId",
                table: "DeliveryDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_RecipientId",
                table: "DeliveryDetails",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDetails_AspNetUsers_RecipientId",
                table: "DeliveryDetails",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDetails_AspNetUsers_RecipientId",
                table: "DeliveryDetails");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryDetails_RecipientId",
                table: "DeliveryDetails");

            migrationBuilder.DropColumn(
                name: "IssuedOn",
                table: "DeliveryDetails");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "DeliveryDetails");
        }
    }
}

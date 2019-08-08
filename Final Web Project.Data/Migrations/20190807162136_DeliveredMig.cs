using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Web_Project.Data.Migrations
{
    public partial class DeliveredMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Deliveries_DeliveryId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_DeliveryId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryDetails_ReceiptId",
                table: "DeliveryDetails");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryId",
                table: "Receipts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_ReceiptId",
                table: "DeliveryDetails",
                column: "ReceiptId",
                unique: true,
                filter: "[ReceiptId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DeliveryDetails_ReceiptId",
                table: "DeliveryDetails");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryId",
                table: "Receipts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_DeliveryId",
                table: "Receipts",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_ReceiptId",
                table: "DeliveryDetails",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Deliveries_DeliveryId",
                table: "Receipts",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

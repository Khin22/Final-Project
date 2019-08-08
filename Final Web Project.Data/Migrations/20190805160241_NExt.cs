using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Web_Project.Data.Migrations
{
    public partial class NExt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_ReceiptStatuses_StatusId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Receipts",
                newName: "ReceiptStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_StatusId",
                table: "Receipts",
                newName: "IX_Receipts_ReceiptStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_ReceiptStatuses_ReceiptStatusId",
                table: "Receipts",
                column: "ReceiptStatusId",
                principalTable: "ReceiptStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_ReceiptStatuses_ReceiptStatusId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "ReceiptStatusId",
                table: "Receipts",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_ReceiptStatusId",
                table: "Receipts",
                newName: "IX_Receipts_StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_ReceiptStatuses_StatusId",
                table: "Receipts",
                column: "StatusId",
                principalTable: "ReceiptStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

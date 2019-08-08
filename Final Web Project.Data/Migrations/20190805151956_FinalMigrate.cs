using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Web_Project.Data.Migrations
{
    public partial class FinalMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Receipts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_StatusId",
                table: "Receipts",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_ReceiptStatuses_StatusId",
                table: "Receipts",
                column: "StatusId",
                principalTable: "ReceiptStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_ReceiptStatuses_StatusId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_StatusId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Receipts");
        }
    }
}

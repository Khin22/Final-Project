using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Web_Project.Data.Migrations
{
    public partial class PhoneNUmber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Deliveries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwoNames",
                table: "Deliveries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "TwoNames",
                table: "Deliveries");
        }
    }
}

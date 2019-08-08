using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Web_Project.Data.Migrations
{
    public partial class DelDetFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RecipientId = table.Column<string>(nullable: true),
                    TwoNames = table.Column<string>(nullable: true)
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
                name: "IX_Deliveries_RecipientId",
                table: "Deliveries",
                column: "RecipientId");
        }
    }
}

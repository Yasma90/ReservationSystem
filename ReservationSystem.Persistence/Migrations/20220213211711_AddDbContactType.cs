using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSystem.Persistence.Migrations
{
    public partial class AddDbContactType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservation_Date",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Contact_Name",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactTypeId",
                table: "Contact",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Date_Ranking",
                table: "Reservation",
                columns: new[] { "Date", "Ranking" });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactTypeId",
                table: "Contact",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Name",
                table: "Contact",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_ContactType_ContactTypeId",
                table: "Contact",
                column: "ContactTypeId",
                principalTable: "ContactType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_ContactType_ContactTypeId",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_Date_Ranking",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Contact_ContactTypeId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_Name",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ContactTypeId",
                table: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Date",
                table: "Reservation",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Name",
                table: "Contact",
                column: "Name",
                unique: true);
        }
    }
}

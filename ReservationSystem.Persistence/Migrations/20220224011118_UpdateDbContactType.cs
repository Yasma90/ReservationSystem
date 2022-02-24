using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSystem.Persistence.Migrations
{
    public partial class UpdateDbContactType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContactId1",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContactTypeId1",
                table: "Contact",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ContactId1",
                table: "Reservation",
                column: "ContactId1");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactTypeId1",
                table: "Contact",
                column: "ContactTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_ContactType_ContactTypeId1",
                table: "Contact",
                column: "ContactTypeId1",
                principalTable: "ContactType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Contact_ContactId1",
                table: "Reservation",
                column: "ContactId1",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_ContactType_ContactTypeId1",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Contact_ContactId1",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ContactId1",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Contact_ContactTypeId1",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ContactId1",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ContactTypeId1",
                table: "Contact");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSystem.Persistence.Migrations
{
    public partial class UpdateContactType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ContactType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactTypeId1",
                table: "Contact",
                type: "uniqueidentifier",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_ContactType_ContactTypeId1",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_ContactTypeId1",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ContactTypeId1",
                table: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ContactType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

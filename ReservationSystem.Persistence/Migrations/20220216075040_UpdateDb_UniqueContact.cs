using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSystem.Persistence.Migrations
{
    public partial class UpdateDb_UniqueContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contact_Name",
                table: "Contact");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Name_BirthDate",
                table: "Contact",
                columns: new[] { "Name", "BirthDate" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contact_Name_BirthDate",
                table: "Contact");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Name",
                table: "Contact",
                column: "Name");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSystem.Persistence.Migrations
{
    public partial class UpdatedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reservation");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contact",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservation_Date",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Contact_Name",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace KütüphaneTakip.Data.Migrations
{
    public partial class addedResStatu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationStatu",
                table: "Reservations",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationStatu",
                table: "Reservations");
        }
    }
}

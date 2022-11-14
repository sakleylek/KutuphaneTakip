using Microsoft.EntityFrameworkCore.Migrations;

namespace KütüphaneTakip.Data.Migrations
{
    public partial class addBookStatu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookStatu",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookStatu",
                table: "Books");
        }
    }
}

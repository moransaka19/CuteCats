using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "cat.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "Cat.jpg");
        }
    }
}

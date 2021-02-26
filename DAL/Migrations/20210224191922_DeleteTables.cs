using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DeleteTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Recruiters_RecruiterId",
                table: "Vacancies");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Recruiters");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_RecruiterId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "Vacancies");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecrutierName",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyName", "Location", "PhoneNumber", "Price", "RecrutierName" },
                values: new object[] { "Test Name", "Test Location", "+380990000000", "100000", "Recrutier Name 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RecrutierName",
                table: "Vacancies");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecruiterId",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recruiters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 1, "Test Location", "Test Name" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[] { 1, "Recrutier Name 1", "+380990000000" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyId", "Price", "RecruiterId" },
                values: new object[] { 1, 100000, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_RecruiterId",
                table: "Vacancies",
                column: "RecruiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Recruiters_RecruiterId",
                table: "Vacancies",
                column: "RecruiterId",
                principalTable: "Recruiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

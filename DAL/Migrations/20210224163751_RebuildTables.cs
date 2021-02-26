using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RebuildTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Recruiters_RecruiterId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_RecruiterId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecruiterId",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 1, "Test Location", "Test Name" });

            migrationBuilder.InsertData(
                table: "Recruiters",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[] { 1, "Recrutier Name 1", "+380990000000" });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "CompanyId", "Description", "Name", "Price", "RecruiterId" },
                values: new object[] { 1, 1, "Test Description 1", "Vacancy Name", 100000, 1 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Recruiters_RecruiterId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_RecruiterId",
                table: "Vacancies");

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recruiters",
                keyColumn: "Id",
                keyValue: 1);

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

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Vacancies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Recruiters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecruiterId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RecruiterId",
                table: "Companies",
                column: "RecruiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Recruiters_RecruiterId",
                table: "Companies",
                column: "RecruiterId",
                principalTable: "Recruiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

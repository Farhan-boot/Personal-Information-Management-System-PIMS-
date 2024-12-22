using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class OrganogramOfficeEmailPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfficeEmail",
                schema: "Employee",
                table: "Organogram",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficePhoneNumber",
                schema: "Employee",
                table: "Organogram",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficeEmail",
                schema: "Employee",
                table: "Organogram");

            migrationBuilder.DropColumn(
                name: "OfficePhoneNumber",
                schema: "Employee",
                table: "Organogram");
        }
    }
}

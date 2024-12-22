using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class addFingerPrintIdIntoEmployeeInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FingerPrintId",
                schema: "Employee",
                table: "EmployeeInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FingerPrintId",
                schema: "Employee",
                table: "EmployeeInformation");
        }
    }
}

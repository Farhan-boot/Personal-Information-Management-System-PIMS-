using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class addFreedomFighterInformationIdIntoEmployeeInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FreedomFighterInformationId",
                schema: "Employee",
                table: "EmployeeInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreedomFighterInformationId",
                schema: "Employee",
                table: "EmployeeInformation");
        }
    }
}

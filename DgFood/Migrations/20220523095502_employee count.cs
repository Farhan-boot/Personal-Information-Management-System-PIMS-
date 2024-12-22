using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class employeecount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DesignationClassId",
                schema: "Employee",
                table: "EmployeeInformationCount",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RankId",
                schema: "Employee",
                table: "EmployeeInformationCount",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignationClassId",
                schema: "Employee",
                table: "EmployeeInformationCount");

            migrationBuilder.DropColumn(
                name: "RankId",
                schema: "Employee",
                table: "EmployeeInformationCount");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class UserId_ForeignKey_In_EmpInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeInformationId",
                schema: "System",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_EmployeeInformationId",
                schema: "System",
                table: "User",
                column: "EmployeeInformationId",
                unique: true,
                filter: "[EmployeeInformationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_EmployeeInformation_EmployeeInformationId",
                schema: "System",
                table: "User",
                column: "EmployeeInformationId",
                principalSchema: "Employee",
                principalTable: "EmployeeInformation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_EmployeeInformation_EmployeeInformationId",
                schema: "System",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_EmployeeInformationId",
                schema: "System",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmployeeInformationId",
                schema: "System",
                table: "User");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class EmployeePostingDetailsEmployeeTypeAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeePostingDetails_EmployeeTypeId",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePostingDetails_EmployeeType_EmployeeTypeId",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "EmployeeTypeId",
                principalTable: "EmployeeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePostingDetails_EmployeeType_EmployeeTypeId",
                schema: "Employee",
                table: "EmployeePostingDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePostingDetails_EmployeeTypeId",
                schema: "Employee",
                table: "EmployeePostingDetails");
        }
    }
}

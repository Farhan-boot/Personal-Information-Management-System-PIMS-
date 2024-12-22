using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class EmployeeInformationUnderAddBcsBatchNoAndBcsOrderNoAndBcsDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BcsBatchNo",
                schema: "Employee",
                table: "EmployeeInformation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BcsDate",
                schema: "Employee",
                table: "EmployeeInformation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BcsOrderNo",
                schema: "Employee",
                table: "EmployeeInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BcsBatchNo",
                schema: "Employee",
                table: "EmployeeInformation");

            migrationBuilder.DropColumn(
                name: "BcsDate",
                schema: "Employee",
                table: "EmployeeInformation");

            migrationBuilder.DropColumn(
                name: "BcsOrderNo",
                schema: "Employee",
                table: "EmployeeInformation");
        }
    }
}

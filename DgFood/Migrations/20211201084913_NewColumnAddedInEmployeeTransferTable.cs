using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class NewColumnAddedInEmployeeTransferTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPostingCompleted",
                schema: "Employee",
                table: "EmployeeTransfer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostingDate",
                schema: "Employee",
                table: "EmployeeTransfer",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPostingCompleted",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "PostingDate",
                schema: "Employee",
                table: "EmployeeTransfer");
        }
    }
}

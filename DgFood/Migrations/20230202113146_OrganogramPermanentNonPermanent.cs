using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class OrganogramPermanentNonPermanent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPermanent",
                schema: "Employee",
                table: "Organogram",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NonPermanentDeadLine",
                schema: "Employee",
                table: "Organogram",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPermanent",
                schema: "Employee",
                table: "Organogram");

            migrationBuilder.DropColumn(
                name: "NonPermanentDeadLine",
                schema: "Employee",
                table: "Organogram");
        }
    }
}

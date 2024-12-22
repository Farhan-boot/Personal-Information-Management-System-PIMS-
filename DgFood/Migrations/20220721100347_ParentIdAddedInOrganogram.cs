using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class ParentIdAddedInOrganogram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsParent",
                schema: "Employee",
                table: "Organogram",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                schema: "Employee",
                table: "Organogram",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsParent",
                schema: "Employee",
                table: "Organogram");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "Employee",
                table: "Organogram");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class DesignationClassUnderBanglaNameAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DesignationClassNameBn",
                schema: "GS",
                table: "DesignationClass",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignationClassNameBn",
                schema: "GS",
                table: "DesignationClass");
        }
    }
}

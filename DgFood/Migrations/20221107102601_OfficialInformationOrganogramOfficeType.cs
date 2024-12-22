using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class OfficialInformationOrganogramOfficeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "JoinOrganogramOfficeType",
                schema: "Employee",
                table: "OfficialInformation",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "PresentOrganogramOfficeType",
                schema: "Employee",
                table: "OfficialInformation",
                type: "tinyint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinOrganogramOfficeType",
                schema: "Employee",
                table: "OfficialInformation");

            migrationBuilder.DropColumn(
                name: "PresentOrganogramOfficeType",
                schema: "Employee",
                table: "OfficialInformation");
        }
    }
}

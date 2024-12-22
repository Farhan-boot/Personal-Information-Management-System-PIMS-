using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class OfficialInfoPermanent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrntOrganogramOfficeType",
                schema: "Employee",
                table: "OfficialInformation",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCrntPostPermanent",
                schema: "Employee",
                table: "OfficialInformation",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrntOrganogramOfficeType",
                schema: "Employee",
                table: "OfficialInformation");

            migrationBuilder.DropColumn(
                name: "IsCrntPostPermanent",
                schema: "Employee",
                table: "OfficialInformation");
        }
    }
}

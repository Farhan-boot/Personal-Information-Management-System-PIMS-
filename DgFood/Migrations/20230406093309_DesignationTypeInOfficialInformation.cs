using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class DesignationTypeInOfficialInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFirstJoiningPostPermanent",
                schema: "Employee",
                table: "OfficialInformation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPresentPostingPermanent",
                schema: "Employee",
                table: "OfficialInformation",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstJoiningPostPermanent",
                schema: "Employee",
                table: "OfficialInformation");

            migrationBuilder.DropColumn(
                name: "IsPresentPostingPermanent",
                schema: "Employee",
                table: "OfficialInformation");
        }
    }
}

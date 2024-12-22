using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class TrainingManagementTypeTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Institute",
                schema: "Employee",
                table: "TrainingInformationManagementMaster");

            migrationBuilder.DropColumn(
                name: "Location",
                schema: "Employee",
                table: "TrainingInformationManagementMaster");

            migrationBuilder.AddColumn<string>(
                name: "Institute",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Institute",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "Location",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.AddColumn<string>(
                name: "Institute",
                schema: "Employee",
                table: "TrainingInformationManagementMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "Employee",
                table: "TrainingInformationManagementMaster",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

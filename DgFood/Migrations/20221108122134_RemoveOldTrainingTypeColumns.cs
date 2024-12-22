using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class RemoveOldTrainingTypeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "TrainingManagementTypeName",
                schema: "GS",
                table: "TrainingManagementType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingManagementTypeName",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(500)",
                nullable: true);
        }
    }
}

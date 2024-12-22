using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class TrainingInfoNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuggestedBy",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingObjective",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingSubject",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "SuggestedBy",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "TrainingObjective",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "TrainingSubject",
                schema: "GS",
                table: "TrainingManagementType");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class TrainingPlanAndTrainingPlanTypeAddIntoTrainingManagementType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainingPlan",
                schema: "GS",
                table: "TrainingManagementType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingPlanType",
                schema: "GS",
                table: "TrainingManagementType",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingPlan",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "TrainingPlanType",
                schema: "GS",
                table: "TrainingManagementType");
        }
    }
}

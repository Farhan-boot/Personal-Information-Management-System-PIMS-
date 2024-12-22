using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class TraningManagementTypeLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainingBatch",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TrainingLocationType",
                schema: "GS",
                table: "TrainingManagementType",
                type: "tinyint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingBatch",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "TrainingLocationType",
                schema: "GS",
                table: "TrainingManagementType");
        }
    }
}

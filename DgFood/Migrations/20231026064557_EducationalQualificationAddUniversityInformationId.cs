using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class EducationalQualificationAddUniversityInformationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UniversityInformationId",
                schema: "Employee",
                table: "EducationalQualification",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniversityInformationId",
                schema: "Employee",
                table: "EducationalQualification");
        }
    }
}

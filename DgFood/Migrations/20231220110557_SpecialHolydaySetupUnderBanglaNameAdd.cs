using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class SpecialHolydaySetupUnderBanglaNameAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialHolydaySetupNameBn",
                schema: "GS",
                table: "SpecialHolydaySetup",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialHolydaySetupNameBn",
                schema: "GS",
                table: "SpecialHolydaySetup");
        }
    }
}

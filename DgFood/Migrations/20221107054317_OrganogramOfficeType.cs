using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class OrganogramOfficeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PostingTypeId",
                schema: "Employee",
                table: "Organogram",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<byte>(
                name: "OrganogramOfficeType",
                schema: "Employee",
                table: "Organogram",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganogramOfficeType",
                schema: "Employee",
                table: "Organogram");

            migrationBuilder.AlterColumn<long>(
                name: "PostingTypeId",
                schema: "Employee",
                table: "Organogram",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}

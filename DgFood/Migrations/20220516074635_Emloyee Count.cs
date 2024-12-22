using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class EmloyeeCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeInformationCount",
                schema: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2 (3)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2 (3)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2 (3)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    DesignationID = table.Column<long>(type: "bigint", nullable: false),
                    ApprovedTotalPost = table.Column<int>(type: "int", nullable: false),
                    CurrentTotalActivePost = table.Column<int>(type: "int", nullable: false),
                    CurrentTotalInactivePost = table.Column<int>(type: "int", nullable: false),
                    InactiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InactiveReason = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInformationCount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInformationCount_Designation_DesignationID",
                        column: x => x.DesignationID,
                        principalSchema: "GS",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformationCount_DesignationID",
                schema: "Employee",
                table: "EmployeeInformationCount",
                column: "DesignationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeInformationCount",
                schema: "Employee");
        }
    }
}

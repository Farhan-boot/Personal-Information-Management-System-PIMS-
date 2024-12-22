using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class TrainingInformationManagementTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingInformationManagement",
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
                    TrainingManagementTypeId = table.Column<long>(nullable: false),
                    RankId = table.Column<long>(nullable: false),
                    DesignationId = table.Column<long>(nullable: false),
                    EmployeeInformationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingInformationManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingInformationManagement_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingInformationManagement_TrainingManagementType_TrainingManagementTypeId",
                        column: x => x.TrainingManagementTypeId,
                        principalSchema: "GS",
                        principalTable: "TrainingManagementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingInformationManagement_EmployeeInformationId",
                table: "TrainingInformationManagement",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingInformationManagement_TrainingManagementTypeId",
                table: "TrainingInformationManagement",
                column: "TrainingManagementTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingInformationManagement");
        }
    }
}

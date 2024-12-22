using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class TrainingInformationManagementMasterTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingInformationManagement_TrainingManagementType_TrainingManagementTypeId",
                schema: "Employee",
                table: "TrainingInformationManagement");

            migrationBuilder.RenameColumn(
                name: "TrainingManagementTypeId",
                schema: "Employee",
                table: "TrainingInformationManagement",
                newName: "TrainingInformationManagementMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingInformationManagement_TrainingManagementTypeId",
                schema: "Employee",
                table: "TrainingInformationManagement",
                newName: "IX_TrainingInformationManagement_TrainingInformationManagementMasterId");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                schema: "Employee",
                table: "TrainingInformationManagement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                schema: "Employee",
                table: "TrainingInformationManagement",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "Employee",
                table: "TrainingInformationManagement",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TrainingInformationManagementMaster",
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
                    Institute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingManagementTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingInformationManagementMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingInformationManagementMaster_TrainingManagementType_TrainingManagementTypeId",
                        column: x => x.TrainingManagementTypeId,
                        principalSchema: "GS",
                        principalTable: "TrainingManagementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingInformationManagementMaster_TrainingManagementTypeId",
                schema: "Employee",
                table: "TrainingInformationManagementMaster",
                column: "TrainingManagementTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingInformationManagement_TrainingInformationManagementMaster_TrainingInformationManagementMasterId",
                schema: "Employee",
                table: "TrainingInformationManagement",
                column: "TrainingInformationManagementMasterId",
                principalSchema: "Employee",
                principalTable: "TrainingInformationManagementMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingInformationManagement_TrainingInformationManagementMaster_TrainingInformationManagementMasterId",
                schema: "Employee",
                table: "TrainingInformationManagement");

            migrationBuilder.DropTable(
                name: "TrainingInformationManagementMaster",
                schema: "Employee");

            migrationBuilder.DropColumn(
                name: "Grade",
                schema: "Employee",
                table: "TrainingInformationManagement");

            migrationBuilder.DropColumn(
                name: "Position",
                schema: "Employee",
                table: "TrainingInformationManagement");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Employee",
                table: "TrainingInformationManagement");

            migrationBuilder.RenameColumn(
                name: "TrainingInformationManagementMasterId",
                schema: "Employee",
                table: "TrainingInformationManagement",
                newName: "TrainingManagementTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingInformationManagement_TrainingInformationManagementMasterId",
                schema: "Employee",
                table: "TrainingInformationManagement",
                newName: "IX_TrainingInformationManagement_TrainingManagementTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingInformationManagement_TrainingManagementType_TrainingManagementTypeId",
                schema: "Employee",
                table: "TrainingInformationManagement",
                column: "TrainingManagementTypeId",
                principalSchema: "GS",
                principalTable: "TrainingManagementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

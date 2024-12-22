using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class CreateOtherTrainingMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtherTrainingMember",
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
                    Name = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    AddressOrWorkplace = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    GenderId = table.Column<long>(type: "bigint", nullable: true),
                    TrainingManagementTypeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherTrainingMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherTrainingMember_TrainingManagementType_TrainingManagementTypeId",
                        column: x => x.TrainingManagementTypeId,
                        principalSchema: "GS",
                        principalTable: "TrainingManagementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtherTrainingMember_TrainingManagementTypeId",
                schema: "Employee",
                table: "OtherTrainingMember",
                column: "TrainingManagementTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherTrainingMember",
                schema: "Employee");
        }
    }
}

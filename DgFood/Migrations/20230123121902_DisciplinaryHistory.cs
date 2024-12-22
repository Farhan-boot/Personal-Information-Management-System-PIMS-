using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class DisciplinaryHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisciplinaryHistory",
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
                    SubmissonDate = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    PresentStatusId = table.Column<long>(type: "bigint", nullable: false),
                    DisciplinaryAndCriminalId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaryHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplinaryHistory_DisciplinaryActionsAndCriminalProsecution_DisciplinaryAndCriminalId",
                        column: x => x.DisciplinaryAndCriminalId,
                        principalSchema: "Employee",
                        principalTable: "DisciplinaryActionsAndCriminalProsecution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisciplinaryHistory_PresentStatus_PresentStatusId",
                        column: x => x.PresentStatusId,
                        principalSchema: "GS",
                        principalTable: "PresentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryHistory_DisciplinaryAndCriminalId",
                schema: "Employee",
                table: "DisciplinaryHistory",
                column: "DisciplinaryAndCriminalId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryHistory_PresentStatusId",
                schema: "Employee",
                table: "DisciplinaryHistory",
                column: "PresentStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinaryHistory",
                schema: "Employee");
        }
    }
}

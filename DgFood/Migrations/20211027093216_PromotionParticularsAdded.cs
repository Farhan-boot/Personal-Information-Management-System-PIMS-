using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class PromotionParticularsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromotionPartculars",
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
                    RankId = table.Column<long>(type: "bigint", nullable: true),
                    DesignationId = table.Column<long>(type: "bigint", nullable: true),
                    PromotionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GONumber = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GODate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PayScale = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PresentPosting = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false),
                    PromtionNatureId = table.Column<long>(type: "bigint", nullable: true),
                    PayScaleYearInfoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionPartculars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionPartculars_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "GS",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotionPartculars_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotionPartculars_PayScaleYearInfo_PayScaleYearInfoId",
                        column: x => x.PayScaleYearInfoId,
                        principalSchema: "GS",
                        principalTable: "PayScaleYearInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionPartculars_PromtionNature_PromtionNatureId",
                        column: x => x.PromtionNatureId,
                        principalSchema: "GS",
                        principalTable: "PromtionNature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotionPartculars_Rank_RankId",
                        column: x => x.RankId,
                        principalSchema: "GS",
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromotionPartculars_DesignationId",
                schema: "Employee",
                table: "PromotionPartculars",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionPartculars_EmployeeInformationId",
                schema: "Employee",
                table: "PromotionPartculars",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionPartculars_PayScaleYearInfoId",
                schema: "Employee",
                table: "PromotionPartculars",
                column: "PayScaleYearInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionPartculars_PromtionNatureId",
                schema: "Employee",
                table: "PromotionPartculars",
                column: "PromtionNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionPartculars_RankId",
                schema: "Employee",
                table: "PromotionPartculars",
                column: "RankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionPartculars",
                schema: "Employee");
        }
    }
}

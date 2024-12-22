using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class EmployeePostingDetailsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeePostingDetails",
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
                    EmployeeInformationId = table.Column<long>(nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JoiningRankId = table.Column<long>(type: "bigint", nullable: true),
                    OfficeEmail = table.Column<string>(nullable: true),
                    OfficeType = table.Column<int>(nullable: true),
                    DesignationTypeId = table.Column<long>(nullable: true),
                    DesignationTypeId1 = table.Column<long>(nullable: true),
                    PostingTypeId = table.Column<long>(nullable: true),
                    PostingId = table.Column<long>(nullable: true),
                    DesignationClassId = table.Column<long>(nullable: true),
                    DesignationId = table.Column<long>(type: "bigint", nullable: true),
                    GradationNumber = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GradationTypeId = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeTypeId = table.Column<long>(type: "bigint", nullable: true),
                    JobCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    PostResponsibilityId = table.Column<long>(nullable: true),
                    RecruitPromoId = table.Column<long>(nullable: true),
                    PromtionNatureId = table.Column<long>(nullable: false),
                    Section = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GradationYear = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    JobPermanentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeppostingTypeId = table.Column<long>(nullable: true),
                    SectionAt = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PRLDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Batch = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CadreId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PostingDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePostingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePostingDetails_PostingType_DeppostingTypeId",
                        column: x => x.DeppostingTypeId,
                        principalSchema: "GS",
                        principalTable: "PostingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePostingDetails_DesignationClass_DesignationClassId",
                        column: x => x.DesignationClassId,
                        principalSchema: "GS",
                        principalTable: "DesignationClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePostingDetails_Designation_DesignationTypeId",
                        column: x => x.DesignationTypeId,
                        principalSchema: "GS",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePostingDetails_Designation_DesignationTypeId1",
                        column: x => x.DesignationTypeId1,
                        principalSchema: "GS",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePostingDetails_PostResponsibility_PostResponsibilityId",
                        column: x => x.PostResponsibilityId,
                        principalSchema: "GS",
                        principalTable: "PostResponsibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePostingDetails_Posting_PostingId",
                        column: x => x.PostingId,
                        principalSchema: "GS",
                        principalTable: "Posting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePostingDetails_PostingType_PostingTypeId",
                        column: x => x.PostingTypeId,
                        principalSchema: "GS",
                        principalTable: "PostingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePostingDetails_PromtionNature_PromtionNatureId",
                        column: x => x.PromtionNatureId,
                        principalSchema: "GS",
                        principalTable: "PromtionNature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePostingDetails_RecruitPromo_RecruitPromoId",
                        column: x => x.RecruitPromoId,
                        principalSchema: "GS",
                        principalTable: "RecruitPromo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePostingDetails_DeppostingTypeId",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "DeppostingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePostingDetails_DesignationClassId",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "DesignationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePostingDetails_DesignationTypeId",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "DesignationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePostingDetails_DesignationTypeId1",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "DesignationTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePostingDetails_PostResponsibilityId",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "PostResponsibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePostingDetails_PostingId",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "PostingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePostingDetails_PostingTypeId",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "PostingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePostingDetails_PromtionNatureId",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "PromtionNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePostingDetails_RecruitPromoId",
                schema: "Employee",
                table: "EmployeePostingDetails",
                column: "RecruitPromoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePostingDetails",
                schema: "Employee");
        }
    }
}

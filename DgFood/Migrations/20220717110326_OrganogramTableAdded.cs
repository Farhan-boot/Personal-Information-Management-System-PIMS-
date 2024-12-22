using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class OrganogramTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organogram",
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
                    PostingTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ParentPostingId = table.Column<long>(type: "bigint", nullable: false),
                    PostingId = table.Column<long>(type: "bigint", nullable: false),
                    DesignationID = table.Column<long>(type: "bigint", nullable: false),
                    TotalPost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organogram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organogram_Designation_DesignationID",
                        column: x => x.DesignationID,
                        principalSchema: "GS",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organogram_Posting_ParentPostingId",
                        column: x => x.ParentPostingId,
                        principalSchema: "GS",
                        principalTable: "Posting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organogram_Posting_PostingId",
                        column: x => x.PostingId,
                        principalSchema: "GS",
                        principalTable: "Posting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organogram_PostingType_PostingTypeId",
                        column: x => x.PostingTypeId,
                        principalSchema: "GS",
                        principalTable: "PostingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformationCount_DesignationClassId",
                schema: "Employee",
                table: "EmployeeInformationCount",
                column: "DesignationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformationCount_RankId",
                schema: "Employee",
                table: "EmployeeInformationCount",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Organogram_DesignationID",
                schema: "Employee",
                table: "Organogram",
                column: "DesignationID");

            migrationBuilder.CreateIndex(
                name: "IX_Organogram_ParentPostingId",
                schema: "Employee",
                table: "Organogram",
                column: "ParentPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_Organogram_PostingId",
                schema: "Employee",
                table: "Organogram",
                column: "PostingId");

            migrationBuilder.CreateIndex(
                name: "IX_Organogram_PostingTypeId",
                schema: "Employee",
                table: "Organogram",
                column: "PostingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInformationCount_DesignationClass_DesignationClassId",
                schema: "Employee",
                table: "EmployeeInformationCount",
                column: "DesignationClassId",
                principalSchema: "GS",
                principalTable: "DesignationClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInformationCount_Rank_RankId",
                schema: "Employee",
                table: "EmployeeInformationCount",
                column: "RankId",
                principalSchema: "GS",
                principalTable: "Rank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInformationCount_DesignationClass_DesignationClassId",
                schema: "Employee",
                table: "EmployeeInformationCount");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInformationCount_Rank_RankId",
                schema: "Employee",
                table: "EmployeeInformationCount");

            migrationBuilder.DropTable(
                name: "Organogram",
                schema: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeInformationCount_DesignationClassId",
                schema: "Employee",
                table: "EmployeeInformationCount");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeInformationCount_RankId",
                schema: "Employee",
                table: "EmployeeInformationCount");
        }
    }
}

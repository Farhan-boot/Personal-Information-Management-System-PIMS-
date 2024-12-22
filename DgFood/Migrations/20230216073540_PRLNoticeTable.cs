using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class PRLNoticeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRL",
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
                    EmployeeInformationdId = table.Column<long>(type: "bigint", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    MessageSubject = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    NoticeDate = table.Column<DateTime>(nullable: false),
                    NoticeBy = table.Column<long>(type: "bigint", nullable: false),
                    IsEmail = table.Column<bool>(type: "bit", nullable: false),
                    IsSMS = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRL_EmployeeInformation_EmployeeInformationdId",
                        column: x => x.EmployeeInformationdId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRL_EmployeeInformationdId",
                schema: "Employee",
                table: "PRL",
                column: "EmployeeInformationdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRL",
                schema: "Employee");

        }
    }
}

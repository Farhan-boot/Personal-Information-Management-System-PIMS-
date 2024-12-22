using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class UnionAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Union",
                schema: "GS",
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
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    NameBn = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    UpazillaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Union", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Union_Upazilla_UpazillaId",
                        column: x => x.UpazillaId,
                        principalTable: "Upazilla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Union_UpazillaId",
                schema: "GS",
                table: "Union",
                column: "UpazillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Union",
                schema: "GS");
        }
    }
}

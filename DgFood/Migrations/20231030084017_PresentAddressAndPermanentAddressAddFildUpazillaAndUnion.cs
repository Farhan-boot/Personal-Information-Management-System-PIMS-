using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class PresentAddressAndPermanentAddressAddFildUpazillaAndUnion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "Employee",
                table: "PresentAddress",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpazillaId",
                schema: "Employee",
                table: "PresentAddress",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnionId",
                schema: "Employee",
                table: "PermanentAddress",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpazillaId",
                schema: "Employee",
                table: "PermanentAddress",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PresentAddress_UnionId",
                schema: "Employee",
                table: "PresentAddress",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentAddress_UpazillaId",
                schema: "Employee",
                table: "PresentAddress",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_PermanentAddress_UnionId",
                schema: "Employee",
                table: "PermanentAddress",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermanentAddress_UpazillaId",
                schema: "Employee",
                table: "PermanentAddress",
                column: "UpazillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermanentAddress_Union_UnionId",
                schema: "Employee",
                table: "PermanentAddress",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermanentAddress_Upazilla_UpazillaId",
                schema: "Employee",
                table: "PermanentAddress",
                column: "UpazillaId",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentAddress_Union_UnionId",
                schema: "Employee",
                table: "PresentAddress",
                column: "UnionId",
                principalSchema: "GS",
                principalTable: "Union",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentAddress_Upazilla_UpazillaId",
                schema: "Employee",
                table: "PresentAddress",
                column: "UpazillaId",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermanentAddress_Union_UnionId",
                schema: "Employee",
                table: "PermanentAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_PermanentAddress_Upazilla_UpazillaId",
                schema: "Employee",
                table: "PermanentAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentAddress_Union_UnionId",
                schema: "Employee",
                table: "PresentAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentAddress_Upazilla_UpazillaId",
                schema: "Employee",
                table: "PresentAddress");

            migrationBuilder.DropIndex(
                name: "IX_PresentAddress_UnionId",
                schema: "Employee",
                table: "PresentAddress");

            migrationBuilder.DropIndex(
                name: "IX_PresentAddress_UpazillaId",
                schema: "Employee",
                table: "PresentAddress");

            migrationBuilder.DropIndex(
                name: "IX_PermanentAddress_UnionId",
                schema: "Employee",
                table: "PermanentAddress");

            migrationBuilder.DropIndex(
                name: "IX_PermanentAddress_UpazillaId",
                schema: "Employee",
                table: "PermanentAddress");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "Employee",
                table: "PresentAddress");

            migrationBuilder.DropColumn(
                name: "UpazillaId",
                schema: "Employee",
                table: "PresentAddress");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "Employee",
                table: "PermanentAddress");

            migrationBuilder.DropColumn(
                name: "UpazillaId",
                schema: "Employee",
                table: "PermanentAddress");
        }
    }
}

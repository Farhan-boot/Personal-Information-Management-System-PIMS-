using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class PromotionParticularsTableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PromotionManagementId",
                schema: "Employee",
                table: "PromotionPartculars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PromotionPartculars_PromotionManagementId",
                schema: "Employee",
                table: "PromotionPartculars",
                column: "PromotionManagementId",
                unique: true,
                filter: "[PromotionManagementId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionPartculars_PromotionManagement_PromotionManagementId",
                schema: "Employee",
                table: "PromotionPartculars",
                column: "PromotionManagementId",
                principalSchema: "Employee",
                principalTable: "PromotionManagement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionPartculars_PromotionManagement_PromotionManagementId",
                schema: "Employee",
                table: "PromotionPartculars");

            migrationBuilder.DropIndex(
                name: "IX_PromotionPartculars_PromotionManagementId",
                schema: "Employee",
                table: "PromotionPartculars");

            migrationBuilder.DropColumn(
                name: "PromotionManagementId",
                schema: "Employee",
                table: "PromotionPartculars");
        }
    }
}

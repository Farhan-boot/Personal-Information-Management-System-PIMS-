using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class EmployeeTransferTable_Modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeTransferId",
                schema: "Employee",
                table: "PostingRecords",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_EmployeeTransferId",
                schema: "Employee",
                table: "PostingRecords",
                column: "EmployeeTransferId",
                unique: true,
                filter: "[EmployeeTransferId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PostingRecords_EmployeeTransfer_EmployeeTransferId",
                schema: "Employee",
                table: "PostingRecords",
                column: "EmployeeTransferId",
                principalSchema: "Employee",
                principalTable: "EmployeeTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostingRecords_EmployeeTransfer_EmployeeTransferId",
                schema: "Employee",
                table: "PostingRecords");

            migrationBuilder.DropIndex(
                name: "IX_PostingRecords_EmployeeTransferId",
                schema: "Employee",
                table: "PostingRecords");

            migrationBuilder.DropColumn(
                name: "EmployeeTransferId",
                schema: "Employee",
                table: "PostingRecords");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class EmployeeTransferPostingRecordsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostingDate",
                schema: "Employee",
                table: "PostingRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttachSection",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CrntDesgId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CurrDesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DepPostingId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeppostingTypeId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DesignationId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IfEmployeeContinuing",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MemoNo",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodFrom",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodTo",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostResponsibilityId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RankId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TransferFromDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TransferFromDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TransferToDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TransferToDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadFiles",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingAsId",
                schema: "Employee",
                table: "EmployeeTransfer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_CrntDesgId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "CrntDesgId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_CurrDesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "CurrDesignationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_DepPostingId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "DepPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_DeppostingTypeId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "DeppostingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_DesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "DesignationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_DesignationId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_PostResponsibilityId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "PostResponsibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_RankId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_TransferFromDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "TransferFromDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_TransferFromDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "TransferFromDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_TransferToDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "TransferToDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_TransferToDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "TransferToDivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_Designation_CrntDesgId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "CrntDesgId",
                principalSchema: "GS",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_DesignationClass_CurrDesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "CurrDesignationClassId",
                principalSchema: "GS",
                principalTable: "DesignationClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_Posting_DepPostingId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "DepPostingId",
                principalSchema: "GS",
                principalTable: "Posting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_PostingType_DeppostingTypeId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "DeppostingTypeId",
                principalSchema: "GS",
                principalTable: "PostingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_DesignationClass_DesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "DesignationClassId",
                principalSchema: "GS",
                principalTable: "DesignationClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_Designation_DesignationId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "DesignationId",
                principalSchema: "GS",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_PostResponsibility_PostResponsibilityId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "PostResponsibilityId",
                principalSchema: "GS",
                principalTable: "PostResponsibility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_Rank_RankId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "RankId",
                principalSchema: "GS",
                principalTable: "Rank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_District_TransferFromDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "TransferFromDistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_Division_TransferFromDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "TransferFromDivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_District_TransferToDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "TransferToDistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTransfer_Division_TransferToDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "TransferToDivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_Designation_CrntDesgId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_DesignationClass_CurrDesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_Posting_DepPostingId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_PostingType_DeppostingTypeId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_DesignationClass_DesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_Designation_DesignationId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_PostResponsibility_PostResponsibilityId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_Rank_RankId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_District_TransferFromDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_Division_TransferFromDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_District_TransferToDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTransfer_Division_TransferToDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_CrntDesgId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_CurrDesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_DepPostingId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_DeppostingTypeId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_DesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_DesignationId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_PostResponsibilityId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_RankId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_TransferFromDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_TransferFromDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_TransferToDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTransfer_TransferToDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "PostingDate",
                schema: "Employee",
                table: "PostingRecords");

            migrationBuilder.DropColumn(
                name: "AttachSection",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "CrntDesgId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "CurrDesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "DepPostingId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "DeppostingTypeId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "DesignationClassId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "IfEmployeeContinuing",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "MemoNo",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "PeriodFrom",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "PeriodTo",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "PostResponsibilityId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "RankId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "Section",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "TransferFromDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "TransferFromDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "TransferToDistrictId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "TransferToDivisionId",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "UploadFiles",
                schema: "Employee",
                table: "EmployeeTransfer");

            migrationBuilder.DropColumn(
                name: "WorkingAsId",
                schema: "Employee",
                table: "EmployeeTransfer");
        }
    }
}

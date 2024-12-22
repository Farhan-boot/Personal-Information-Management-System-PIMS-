using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class TrainingInformationManagementTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingInformationManagement_EmployeeInformation_EmployeeInformationId",
                table: "TrainingInformationManagement");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingInformationManagement_TrainingManagementType_TrainingManagementTypeId",
                table: "TrainingInformationManagement");

            migrationBuilder.RenameTable(
                name: "TrainingInformationManagement",
                newName: "TrainingInformationManagement",
                newSchema: "Employee");

            migrationBuilder.AlterColumn<long>(
                name: "RankId",
                schema: "Employee",
                table: "TrainingInformationManagement",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DesignationId",
                schema: "Employee",
                table: "TrainingInformationManagement",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingInformationManagement_EmployeeInformation_EmployeeInformationId",
                schema: "Employee",
                table: "TrainingInformationManagement",
                column: "EmployeeInformationId",
                principalSchema: "Employee",
                principalTable: "EmployeeInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingInformationManagement_TrainingManagementType_TrainingManagementTypeId",
                schema: "Employee",
                table: "TrainingInformationManagement",
                column: "TrainingManagementTypeId",
                principalSchema: "GS",
                principalTable: "TrainingManagementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingInformationManagement_EmployeeInformation_EmployeeInformationId",
                schema: "Employee",
                table: "TrainingInformationManagement");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingInformationManagement_TrainingManagementType_TrainingManagementTypeId",
                schema: "Employee",
                table: "TrainingInformationManagement");

            migrationBuilder.RenameTable(
                name: "TrainingInformationManagement",
                schema: "Employee",
                newName: "TrainingInformationManagement");

            migrationBuilder.AlterColumn<long>(
                name: "RankId",
                table: "TrainingInformationManagement",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DesignationId",
                table: "TrainingInformationManagement",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingInformationManagement_EmployeeInformation_EmployeeInformationId",
                table: "TrainingInformationManagement",
                column: "EmployeeInformationId",
                principalSchema: "Employee",
                principalTable: "EmployeeInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingInformationManagement_TrainingManagementType_TrainingManagementTypeId",
                table: "TrainingInformationManagement",
                column: "TrainingManagementTypeId",
                principalSchema: "GS",
                principalTable: "TrainingManagementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

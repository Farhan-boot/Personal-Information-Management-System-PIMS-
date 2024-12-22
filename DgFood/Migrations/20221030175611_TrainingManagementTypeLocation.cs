using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class TrainingManagementTypeLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrainingManagementTypeName",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");

            migrationBuilder.AddColumn<long>(
                name: "DistrictId",
                schema: "GS",
                table: "TrainingManagementType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DivisionId",
                schema: "GS",
                table: "TrainingManagementType",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TrainingManagementTypeForeignType",
                schema: "GS",
                table: "TrainingManagementType",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TrainingManagementTypeLocalType",
                schema: "GS",
                table: "TrainingManagementType",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingTitle",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpazillaId",
                schema: "GS",
                table: "TrainingManagementType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vanue",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryTrainingManagementTypeMap",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<int>(nullable: false),
                    TrainingManagementTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTrainingManagementTypeMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTrainingManagementTypeMap_TrainingManagementType_TrainingManagementTypeId",
                        column: x => x.TrainingManagementTypeId,
                        principalSchema: "GS",
                        principalTable: "TrainingManagementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upazilla",
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
                    Name = table.Column<string>(nullable: true),
                    NameBn = table.Column<string>(nullable: true),
                    DistrictId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upazilla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upazilla_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingManagementType_DistrictId",
                schema: "GS",
                table: "TrainingManagementType",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingManagementType_DivisionId",
                schema: "GS",
                table: "TrainingManagementType",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingManagementType_UpazillaId",
                schema: "GS",
                table: "TrainingManagementType",
                column: "UpazillaId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTrainingManagementTypeMap_TrainingManagementTypeId",
                table: "CountryTrainingManagementTypeMap",
                column: "TrainingManagementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Upazilla_DistrictId",
                table: "Upazilla",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingManagementType_District_DistrictId",
                schema: "GS",
                table: "TrainingManagementType",
                column: "DistrictId",
                principalSchema: "GS",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingManagementType_Division_DivisionId",
                schema: "GS",
                table: "TrainingManagementType",
                column: "DivisionId",
                principalSchema: "GS",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingManagementType_Upazilla_UpazillaId",
                schema: "GS",
                table: "TrainingManagementType",
                column: "UpazillaId",
                principalTable: "Upazilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(@"UPDATE [PrimeDgFoodMigration].[GS].[TrainingManagementType] SET [PrimeDgFoodMigration].[GS].[TrainingManagementType].[TrainingTitle] = [PrimeDgFoodMigration].[GS].[TrainingManagementType].[TrainingManagementTypeName];");
            migrationBuilder.Sql(@"UPDATE [PrimeDgFoodMigration].[GS].[TrainingManagementType] SET [PrimeDgFoodMigration].[GS].[TrainingManagementType].[Vanue] = [PrimeDgFoodMigration].[GS].[TrainingManagementType].[Location];");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingManagementType_District_DistrictId",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingManagementType_Division_DivisionId",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingManagementType_Upazilla_UpazillaId",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropTable(
                name: "CountryTrainingManagementTypeMap");

            migrationBuilder.DropTable(
                name: "Upazilla");

            migrationBuilder.DropIndex(
                name: "IX_TrainingManagementType_DistrictId",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropIndex(
                name: "IX_TrainingManagementType_DivisionId",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropIndex(
                name: "IX_TrainingManagementType_UpazillaId",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "TrainingManagementTypeForeignType",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "TrainingManagementTypeLocalType",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "TrainingTitle",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "UpazillaId",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.DropColumn(
                name: "Vanue",
                schema: "GS",
                table: "TrainingManagementType");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingManagementTypeName",
                schema: "GS",
                table: "TrainingManagementType",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldNullable: true);
        }
    }
}

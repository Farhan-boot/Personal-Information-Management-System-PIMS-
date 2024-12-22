using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSL.DgFood.Api.Migrations
{
    public partial class Initv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "System");

            migrationBuilder.EnsureSchema(
                name: "BdArmy");

            migrationBuilder.EnsureSchema(
                name: "Employee");

            migrationBuilder.EnsureSchema(
                name: "GS");

            migrationBuilder.CreateTable(
                name: "EmployeeType",
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
                    EmployeeTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradationType",
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
                    GradationTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
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
                    JobCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                schema: "BdArmy",
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IsArrived = table.Column<bool>(type: "bit", nullable: false),
                    JsonFileName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SessionName = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cadre",
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
                    CadreNameEnglish = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CadreNameBangla = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ClassType = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalculationMethod",
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
                    CalculationMethodName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
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
                    CategoryName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
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
                    ColorName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
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
                    DegreeName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesignationClass",
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
                    DesignationClassName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Division",
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
                    DivisionName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DivisionNameBangla = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatus",
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
                    EmployeeStatusName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EmployeeStatusNameBangla = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
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
                    EventName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institute",
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
                    InstituteName = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
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
                    LanguageName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayScaleYearInfo",
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
                    PayScaleYearInfoName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ImplementationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayScaleYearInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostingType",
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
                    PostingTypeName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PostingTypeNameBangla = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostResponsibility",
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
                    PostResponsibilityName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostResponsibility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PresentStatus",
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
                    PresentStatusName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromtionNature",
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
                    PromtionNatureName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PromtionNatureNameBangla = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromtionNature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
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
                    RankName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    RankNameBangla = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecruitPromo",
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
                    RecruitPromoEnglish = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    RecruitPromoBangla = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitPromo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialHolydaySetup",
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
                    SpecialHolydaySetupName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialHolydaySetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Years",
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
                    YearsName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accesslist",
                schema: "System",
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
                    ControllerName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Mask = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AccessStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    IsVisible = table.Column<byte>(type: "tinyint", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BaseModule = table.Column<int>(type: "int", nullable: false),
                    BaseModuleIndex = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesslist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessMapper",
                schema: "System",
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
                    AccessList = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    RoleStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    IsVisible = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessMapper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "System",
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
                    ModuleName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ModuleIcon = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsVisible = table.Column<byte>(nullable: false),
                    MenueOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PmsGroup",
                schema: "System",
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
                    GroupName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    GroupDescription = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    GroupStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    IsVisible = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmsGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                schema: "System",
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
                    GroupName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    ModuleActionNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<byte>(type: "tinyint", nullable: false),
                    IsDefault = table.Column<byte>(type: "tinyint", nullable: false),
                    IsVisible = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "System",
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
                    RoleName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutesDetails",
                schema: "BdArmy",
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
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<double>(type: "float", nullable: false),
                    EndTime = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Radius = table.Column<double>(type: "float", nullable: true),
                    PlaceName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    RoutesId = table.Column<long>(type: "bigint", nullable: false),
                    IsArrived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutesDetails_Routes_RoutesId",
                        column: x => x.RoutesId,
                        principalSchema: "BdArmy",
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypeInformation",
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
                    NameInEnglish = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameInBangla = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EligibleFor = table.Column<int>(type: "int", nullable: false),
                    CalculationMethodId = table.Column<long>(type: "bigint", nullable: false),
                    MaxDaysPerYear = table.Column<int>(type: "int", nullable: false),
                    LeaveRestriction = table.Column<int>(type: "int", nullable: false),
                    LeaveLimit = table.Column<int>(type: "int", nullable: false),
                    ApplicationWithIn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypeInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveTypeInformation_CalculationMethod_CalculationMethodId",
                        column: x => x.CalculationMethodId,
                        principalSchema: "GS",
                        principalTable: "CalculationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
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
                    DistrictName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DistrictNameBangla = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posting",
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
                    PostingName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PostingNameBangla = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    ThanaId = table.Column<long>(type: "bigint", nullable: true),
                    PostingTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posting_PostingType_PostingTypeId",
                        column: x => x.PostingTypeId,
                        principalSchema: "GS",
                        principalTable: "PostingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
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
                    DesignationName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DesignationNameBangla = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RankId = table.Column<long>(type: "bigint", nullable: false),
                    DesignationClassId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designation_DesignationClass_DesignationClassId",
                        column: x => x.DesignationClassId,
                        principalSchema: "GS",
                        principalTable: "DesignationClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Designation_Rank_RankId",
                        column: x => x.RankId,
                        principalSchema: "GS",
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayScalePerGrade",
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
                    ScaleYear = table.Column<int>(type: "int", nullable: false),
                    ScaleOfPay = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    basic_pay = table.Column<decimal>(type: "decimal", nullable: false),
                    RankId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayScalePerGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayScalePerGrade_Rank_RankId",
                        column: x => x.RankId,
                        principalSchema: "GS",
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyHolydaySetup",
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
                    Day = table.Column<int>(type: "int", nullable: false),
                    YearsId = table.Column<long>(type: "bigint", nullable: false),
                    HolidayDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyHolydaySetup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyHolydaySetup_Years_YearsId",
                        column: x => x.YearsId,
                        principalSchema: "GS",
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "System",
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
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    UserPhone = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserGroup = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserStatus = table.Column<bool>(type: "bit", nullable: false),
                    PmsGroupID = table.Column<long>(nullable: false),
                    GroupID = table.Column<long>(type: "bigint", nullable: true),
                    UserRolesId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserGroup_GroupID",
                        column: x => x.GroupID,
                        principalSchema: "System",
                        principalTable: "UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_PmsGroup_PmsGroupID",
                        column: x => x.PmsGroupID,
                        principalSchema: "System",
                        principalTable: "PmsGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserRoles_UserRolesId",
                        column: x => x.UserRolesId,
                        principalSchema: "System",
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoutesLineStringJsons",
                schema: "BdArmy",
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoutesId = table.Column<long>(type: "bigint", nullable: false),
                    RoutesDetailsId = table.Column<long>(type: "bigint", nullable: false),
                    StartLatitude = table.Column<double>(type: "float", nullable: false),
                    EndLatitude = table.Column<double>(type: "float", nullable: false),
                    StartLongitude = table.Column<double>(type: "float", nullable: false),
                    EndLongitude = table.Column<double>(type: "float", nullable: false),
                    JsonFileName = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutesLineStringJsons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutesLineStringJsons_RoutesDetails_RoutesDetailsId",
                        column: x => x.RoutesDetailsId,
                        principalSchema: "BdArmy",
                        principalTable: "RoutesDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoutesLineStringJsons_Routes_RoutesId",
                        column: x => x.RoutesId,
                        principalSchema: "BdArmy",
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoliceStation",
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
                    PoliceStationName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PoliceStationNameBangla = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceStation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliceStation_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInformation",
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
                    GovtID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NationalID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    NameBangla = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FathersNameBangla = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    FathersNameEnglish = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    MothersNameBangla = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    MothersNameEnglish = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    oclsd = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmployeeStatusId = table.Column<long>(type: "bigint", nullable: false),
                    OtherReligion = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FreedomFighter = table.Column<bool>(type: "bit", nullable: false),
                    ChildGrandChildOfFreedomFighter = table.Column<bool>(type: "bit", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    RecruitmentType = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<long>(type: "bigint", nullable: false),
                    MaritalStatusId = table.Column<long>(type: "bigint", nullable: false),
                    ReligionId = table.Column<int>(type: "int", nullable: true),
                    TIN = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PassportIssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassportIssuePlace = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    PassportDateOfExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DrivingLicenceNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CircularDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BCSNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeritOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceStationId = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeCode = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInformation_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInformation_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInformation_EmployeeStatus_EmployeeStatusId",
                        column: x => x.EmployeeStatusId,
                        principalSchema: "GS",
                        principalTable: "EmployeeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInformation_PoliceStation_PoliceStationId",
                        column: x => x.PoliceStationId,
                        principalSchema: "GS",
                        principalTable: "PoliceStation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addl_prof_q_info",
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
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addl_prof_q_info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addl_prof_q_info_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AwardInformation",
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
                    AwardName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AwardGround = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AwardDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardInformation_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildrenInformation",
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
                    SlNo = table.Column<int>(type: "int", nullable: false),
                    NameInEnglish = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameInBangla = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false),
                    GenderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildrenInformation_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaryActionsAndCriminalProsecution",
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
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresentStatusId = table.Column<long>(type: "bigint", nullable: true),
                    Judgement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalJudgement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaryActionsAndCriminalProsecution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplinaryActionsAndCriminalProsecution_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "GS",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisciplinaryActionsAndCriminalProsecution_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisciplinaryActionsAndCriminalProsecution_PresentStatus_PresentStatusId",
                        column: x => x.PresentStatusId,
                        principalSchema: "GS",
                        principalTable: "PresentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationalQualification",
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
                    NameOfTheInstitute = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    PrincipalSubject = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    DegreeId = table.Column<long>(type: "bigint", nullable: true),
                    PassingYear = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ResultOrDivision = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    GPAOrCGPA = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Distinction = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalQualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalQualification_Degree_DegreeId",
                        column: x => x.DegreeId,
                        principalSchema: "GS",
                        principalTable: "Degree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EducationalQualification_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTransfer",
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
                    PostingId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTransfer_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTransfer_Posting_PostingId",
                        column: x => x.PostingId,
                        principalSchema: "GS",
                        principalTable: "Posting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTransfer_PostingType_PostingTypeId",
                        column: x => x.PostingTypeId,
                        principalSchema: "GS",
                        principalTable: "PostingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForeignTravelInfo",
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
                    Country = table.Column<int>(nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignTravelInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignTravelInfo_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanguageInformation",
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
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    Listening = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Reading = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Writing = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageInformation_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageInformation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "GS",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApplication",
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
                    LeaveTypeInformationId = table.Column<long>(type: "bigint", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeaveDays = table.Column<int>(type: "int", nullable: true),
                    LeaveStatus = table.Column<int>(type: "int", nullable: false),
                    LeaveAuthority = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LeaveSubject = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MemoNO = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LeaveReason = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    EmergencyAddress = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHeadOfOffice = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveApplication_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveApplication_LeaveTypeInformation_LeaveTypeInformationId",
                        column: x => x.LeaveTypeInformationId,
                        principalSchema: "GS",
                        principalTable: "LeaveTypeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MagisterialPowerInfo",
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
                    Power = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DateOfNotification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagisterialPowerInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagisterialPowerInfo_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfficialInformation",
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
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false),
                    FirstJoiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JoinPostingTypeId = table.Column<long>(type: "bigint", nullable: true),
                    JoinPostingId = table.Column<long>(type: "bigint", nullable: true),
                    JoiningDesignationClassId = table.Column<long>(type: "bigint", nullable: true),
                    JoiningDesgId = table.Column<long>(type: "bigint", nullable: true),
                    CadreId = table.Column<int>(type: "int", nullable: false),
                    CadreDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Batch = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PresentJoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GradationNumber = table.Column<string>(nullable: true),
                    GradationTypeId = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeTypeId = table.Column<long>(type: "bigint", nullable: false),
                    JobCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SectionAt = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PRLDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobPermanentDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradationYear = table.Column<string>(nullable: true),
                    JoiningRankId = table.Column<long>(type: "bigint", nullable: true),
                    PresentRankId = table.Column<long>(type: "bigint", nullable: true),
                    PresentDesignationClassId = table.Column<long>(type: "bigint", nullable: true),
                    PresentDesignationId = table.Column<long>(type: "bigint", nullable: true),
                    CrntDesgId = table.Column<long>(type: "bigint", nullable: true),
                    CurrDesignationClassId = table.Column<long>(type: "bigint", nullable: true),
                    PostResponsibilityId = table.Column<long>(type: "bigint", nullable: true),
                    RecruitPromoId = table.Column<long>(type: "bigint", nullable: true),
                    PromtionNatureId = table.Column<long>(type: "bigint", nullable: false),
                    PostingTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DeppostingTypeId = table.Column<long>(type: "bigint", nullable: true),
                    PostingId = table.Column<long>(type: "bigint", nullable: false),
                    DepPostingId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_Designation_CrntDesgId",
                        column: x => x.CrntDesgId,
                        principalSchema: "GS",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_DesignationClass_CurrDesignationClassId",
                        column: x => x.CurrDesignationClassId,
                        principalSchema: "GS",
                        principalTable: "DesignationClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_Posting_DepPostingId",
                        column: x => x.DepPostingId,
                        principalSchema: "GS",
                        principalTable: "Posting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_PostingType_DeppostingTypeId",
                        column: x => x.DeppostingTypeId,
                        principalSchema: "GS",
                        principalTable: "PostingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_EmployeeType_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_GradationType_GradationTypeId",
                        column: x => x.GradationTypeId,
                        principalTable: "GradationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_JobCategory_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_Posting_JoinPostingId",
                        column: x => x.JoinPostingId,
                        principalSchema: "GS",
                        principalTable: "Posting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_PostingType_JoinPostingTypeId",
                        column: x => x.JoinPostingTypeId,
                        principalSchema: "GS",
                        principalTable: "PostingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_Designation_JoiningDesgId",
                        column: x => x.JoiningDesgId,
                        principalSchema: "GS",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_DesignationClass_JoiningDesignationClassId",
                        column: x => x.JoiningDesignationClassId,
                        principalSchema: "GS",
                        principalTable: "DesignationClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_Rank_JoiningRankId",
                        column: x => x.JoiningRankId,
                        principalSchema: "GS",
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_PostResponsibility_PostResponsibilityId",
                        column: x => x.PostResponsibilityId,
                        principalSchema: "GS",
                        principalTable: "PostResponsibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_Posting_PostingId",
                        column: x => x.PostingId,
                        principalSchema: "GS",
                        principalTable: "Posting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_PostingType_PostingTypeId",
                        column: x => x.PostingTypeId,
                        principalSchema: "GS",
                        principalTable: "PostingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_DesignationClass_PresentDesignationClassId",
                        column: x => x.PresentDesignationClassId,
                        principalSchema: "GS",
                        principalTable: "DesignationClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_Designation_PresentDesignationId",
                        column: x => x.PresentDesignationId,
                        principalSchema: "GS",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_Rank_PresentRankId",
                        column: x => x.PresentRankId,
                        principalSchema: "GS",
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_PromtionNature_PromtionNatureId",
                        column: x => x.PromtionNatureId,
                        principalSchema: "GS",
                        principalTable: "PromtionNature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialInformation_RecruitPromo_RecruitPromoId",
                        column: x => x.RecruitPromoId,
                        principalSchema: "GS",
                        principalTable: "RecruitPromo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherServiceInfo",
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
                    EmployerName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EmpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherServiceType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherServiceInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherServiceInfo_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermanentAddress",
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
                    VillageHouseNoAndRoadInEnglish = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    VillageHouseNoAndRoadInBangla = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    PoliceStationId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false),
                    OtherThana = table.Column<string>(type: "nvarchar(400)", nullable: true),
                    PostOfficeInEnglish = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PostOfficeInBangla = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    TelephoneNo = table.Column<string>(type: "nvarchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermanentAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermanentAddress_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermanentAddress_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermanentAddress_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermanentAddress_PoliceStation_PoliceStationId",
                        column: x => x.PoliceStationId,
                        principalSchema: "GS",
                        principalTable: "PoliceStation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostingAbroad",
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
                    Post = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false),
                    Country = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostingAbroad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostingAbroad_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostingRecords",
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
                    RankId = table.Column<long>(type: "bigint", nullable: true),
                    DesignationClassId = table.Column<long>(type: "bigint", nullable: true),
                    DesignationId = table.Column<long>(type: "bigint", nullable: true),
                    PostResponsibilityId = table.Column<long>(type: "bigint", nullable: true),
                    MainPostingTypeId = table.Column<long>(type: "bigint", nullable: true),
                    PostingId = table.Column<long>(type: "bigint", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IfEmployeeContinuing = table.Column<bool>(type: "bit", nullable: false),
                    CurrDesignationClassId = table.Column<long>(type: "bigint", nullable: true),
                    CrntDesgId = table.Column<long>(type: "bigint", nullable: true),
                    DeppostingTypeId = table.Column<long>(type: "bigint", nullable: true),
                    DepPostingId = table.Column<long>(type: "bigint", nullable: true),
                    AttachSection = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TransferFromDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    TransferToDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    TransferFromDistrictId = table.Column<long>(type: "bigint", nullable: true),
                    TransferToDistrictId = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false),
                    WorkingAsId = table.Column<long>(type: "bigint", nullable: false),
                    MemoNo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    UploadFiles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostingRecords_Designation_CrntDesgId",
                        column: x => x.CrntDesgId,
                        principalSchema: "GS",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_DesignationClass_CurrDesignationClassId",
                        column: x => x.CurrDesignationClassId,
                        principalSchema: "GS",
                        principalTable: "DesignationClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_Posting_DepPostingId",
                        column: x => x.DepPostingId,
                        principalSchema: "GS",
                        principalTable: "Posting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_PostingType_DeppostingTypeId",
                        column: x => x.DeppostingTypeId,
                        principalSchema: "GS",
                        principalTable: "PostingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_DesignationClass_DesignationClassId",
                        column: x => x.DesignationClassId,
                        principalSchema: "GS",
                        principalTable: "DesignationClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "GS",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_PostingType_MainPostingTypeId",
                        column: x => x.MainPostingTypeId,
                        principalSchema: "GS",
                        principalTable: "PostingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_PostResponsibility_PostResponsibilityId",
                        column: x => x.PostResponsibilityId,
                        principalSchema: "GS",
                        principalTable: "PostResponsibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_Posting_PostingId",
                        column: x => x.PostingId,
                        principalSchema: "GS",
                        principalTable: "Posting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_Rank_RankId",
                        column: x => x.RankId,
                        principalSchema: "GS",
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_District_TransferFromDistrictId",
                        column: x => x.TransferFromDistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_Division_TransferFromDivisionId",
                        column: x => x.TransferFromDivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_District_TransferToDistrictId",
                        column: x => x.TransferToDistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingRecords_Division_TransferToDivisionId",
                        column: x => x.TransferToDivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresentAddress",
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
                    VillageHouseNoAndRoadInEnglish = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    VillageHouseNoAndRoadInBangla = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    PoliceStationId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false),
                    OtherThana = table.Column<string>(type: "nvarchar(400)", nullable: true),
                    PostOfficeInEnglish = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PostOfficeInBangla = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    TelephoneNo = table.Column<string>(type: "nvarchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresentAddress_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresentAddress_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresentAddress_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresentAddress_PoliceStation_PoliceStationId",
                        column: x => x.PoliceStationId,
                        principalSchema: "GS",
                        principalTable: "PoliceStation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

             
            migrationBuilder.CreateTable(
                name: "PublicationInfo",
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
                    PublicationType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PublicationName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationInfo_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHistory",
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
                    DateOfGovtService = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfGazetted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EncadrementNumber = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EncadrementDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NationalSeniority = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false),
                    CadreId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHistory_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpouseInformation",
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
                    NameInBangla = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameInEnglish = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpouseInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpouseInformation_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "GS",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpouseInformation_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "GS",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpouseInformation_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingInformation",
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
                    CourseTitle = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Institute = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    EmployeeInformationId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    TrainingTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingInformation_EmployeeInformation_EmployeeInformationId",
                        column: x => x.EmployeeInformationId,
                        principalSchema: "Employee",
                        principalTable: "EmployeeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetails_RoutesId",
                schema: "BdArmy",
                table: "RoutesDetails",
                column: "RoutesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesLineStringJsons_RoutesDetailsId",
                schema: "BdArmy",
                table: "RoutesLineStringJsons",
                column: "RoutesDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesLineStringJsons_RoutesId",
                schema: "BdArmy",
                table: "RoutesLineStringJsons",
                column: "RoutesId");

            migrationBuilder.CreateIndex(
                name: "IX_Addl_prof_q_info_EmployeeInformationId",
                schema: "Employee",
                table: "Addl_prof_q_info",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardInformation_EmployeeInformationId",
                schema: "Employee",
                table: "AwardInformation",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenInformation_EmployeeInformationId",
                schema: "Employee",
                table: "ChildrenInformation",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryActionsAndCriminalProsecution_CategoryId",
                schema: "Employee",
                table: "DisciplinaryActionsAndCriminalProsecution",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryActionsAndCriminalProsecution_EmployeeInformationId",
                schema: "Employee",
                table: "DisciplinaryActionsAndCriminalProsecution",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryActionsAndCriminalProsecution_PresentStatusId",
                schema: "Employee",
                table: "DisciplinaryActionsAndCriminalProsecution",
                column: "PresentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualification_DegreeId",
                schema: "Employee",
                table: "EducationalQualification",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualification_EmployeeInformationId",
                schema: "Employee",
                table: "EducationalQualification",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformation_DistrictId",
                schema: "Employee",
                table: "EmployeeInformation",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformation_DivisionId",
                schema: "Employee",
                table: "EmployeeInformation",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformation_EmployeeStatusId",
                schema: "Employee",
                table: "EmployeeInformation",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformation_PoliceStationId",
                schema: "Employee",
                table: "EmployeeInformation",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_EmployeeInformationId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_PostingId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "PostingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTransfer_PostingTypeId",
                schema: "Employee",
                table: "EmployeeTransfer",
                column: "PostingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignTravelInfo_EmployeeInformationId",
                schema: "Employee",
                table: "ForeignTravelInfo",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageInformation_EmployeeInformationId",
                schema: "Employee",
                table: "LanguageInformation",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageInformation_LanguageId",
                schema: "Employee",
                table: "LanguageInformation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplication_EmployeeInformationId",
                schema: "Employee",
                table: "LeaveApplication",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplication_LeaveTypeInformationId",
                schema: "Employee",
                table: "LeaveApplication",
                column: "LeaveTypeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MagisterialPowerInfo_EmployeeInformationId",
                schema: "Employee",
                table: "MagisterialPowerInfo",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_CrntDesgId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "CrntDesgId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_CurrDesignationClassId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "CurrDesignationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_DepPostingId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "DepPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_DeppostingTypeId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "DeppostingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_EmployeeInformationId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_EmployeeTypeId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_GradationTypeId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "GradationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_JobCategoryId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_JoinPostingId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "JoinPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_JoinPostingTypeId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "JoinPostingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_JoiningDesgId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "JoiningDesgId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_JoiningDesignationClassId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "JoiningDesignationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_JoiningRankId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "JoiningRankId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_PostResponsibilityId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "PostResponsibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_PostingId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "PostingId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_PostingTypeId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "PostingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_PresentDesignationClassId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "PresentDesignationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_PresentDesignationId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "PresentDesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_PresentRankId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "PresentRankId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_PromtionNatureId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "PromtionNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialInformation_RecruitPromoId",
                schema: "Employee",
                table: "OfficialInformation",
                column: "RecruitPromoId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherServiceInfo_EmployeeInformationId",
                schema: "Employee",
                table: "OtherServiceInfo",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PermanentAddress_DistrictId",
                schema: "Employee",
                table: "PermanentAddress",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PermanentAddress_DivisionId",
                schema: "Employee",
                table: "PermanentAddress",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermanentAddress_EmployeeInformationId",
                schema: "Employee",
                table: "PermanentAddress",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PermanentAddress_PoliceStationId",
                schema: "Employee",
                table: "PermanentAddress",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingAbroad_EmployeeInformationId",
                schema: "Employee",
                table: "PostingAbroad",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_CrntDesgId",
                schema: "Employee",
                table: "PostingRecords",
                column: "CrntDesgId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_CurrDesignationClassId",
                schema: "Employee",
                table: "PostingRecords",
                column: "CurrDesignationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_DepPostingId",
                schema: "Employee",
                table: "PostingRecords",
                column: "DepPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_DeppostingTypeId",
                schema: "Employee",
                table: "PostingRecords",
                column: "DeppostingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_DesignationClassId",
                schema: "Employee",
                table: "PostingRecords",
                column: "DesignationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_DesignationId",
                schema: "Employee",
                table: "PostingRecords",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_EmployeeInformationId",
                schema: "Employee",
                table: "PostingRecords",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_MainPostingTypeId",
                schema: "Employee",
                table: "PostingRecords",
                column: "MainPostingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_PostResponsibilityId",
                schema: "Employee",
                table: "PostingRecords",
                column: "PostResponsibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_PostingId",
                schema: "Employee",
                table: "PostingRecords",
                column: "PostingId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_RankId",
                schema: "Employee",
                table: "PostingRecords",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_TransferFromDistrictId",
                schema: "Employee",
                table: "PostingRecords",
                column: "TransferFromDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_TransferFromDivisionId",
                schema: "Employee",
                table: "PostingRecords",
                column: "TransferFromDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_TransferToDistrictId",
                schema: "Employee",
                table: "PostingRecords",
                column: "TransferToDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingRecords_TransferToDivisionId",
                schema: "Employee",
                table: "PostingRecords",
                column: "TransferToDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentAddress_DistrictId",
                schema: "Employee",
                table: "PresentAddress",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentAddress_DivisionId",
                schema: "Employee",
                table: "PresentAddress",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentAddress_EmployeeInformationId",
                schema: "Employee",
                table: "PresentAddress",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentAddress_PoliceStationId",
                schema: "Employee",
                table: "PresentAddress",
                column: "PoliceStationId");

            
            migrationBuilder.CreateIndex(
                name: "IX_PublicationInfo_EmployeeInformationId",
                schema: "Employee",
                table: "PublicationInfo",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_EmployeeInformationId",
                schema: "Employee",
                table: "ServiceHistory",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpouseInformation_DistrictId",
                schema: "Employee",
                table: "SpouseInformation",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_SpouseInformation_DivisionId",
                schema: "Employee",
                table: "SpouseInformation",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpouseInformation_EmployeeInformationId",
                schema: "Employee",
                table: "SpouseInformation",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingInformation_EmployeeInformationId",
                schema: "Employee",
                table: "TrainingInformation",
                column: "EmployeeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_DesignationClassId",
                schema: "GS",
                table: "Designation",
                column: "DesignationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_RankId",
                schema: "GS",
                table: "Designation",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_District_DivisionId",
                schema: "GS",
                table: "District",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeInformation_CalculationMethodId",
                schema: "GS",
                table: "LeaveTypeInformation",
                column: "CalculationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PayScalePerGrade_RankId",
                schema: "GS",
                table: "PayScalePerGrade",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceStation_DistrictId",
                schema: "GS",
                table: "PoliceStation",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Posting_PostingTypeId",
                schema: "GS",
                table: "Posting",
                column: "PostingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyHolydaySetup_YearsId",
                schema: "GS",
                table: "WeeklyHolydaySetup",
                column: "YearsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupID",
                schema: "System",
                table: "User",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_User_PmsGroupID",
                schema: "System",
                table: "User",
                column: "PmsGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRolesId",
                schema: "System",
                table: "User",
                column: "UserRolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutesLineStringJsons",
                schema: "BdArmy");

            migrationBuilder.DropTable(
                name: "Addl_prof_q_info",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "AwardInformation",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "ChildrenInformation",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "DisciplinaryActionsAndCriminalProsecution",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "EducationalQualification",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeTransfer",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "ForeignTravelInfo",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "LanguageInformation",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "LeaveApplication",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "MagisterialPowerInfo",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "OfficialInformation",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "OtherServiceInfo",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "PermanentAddress",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "PostingAbroad",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "PostingRecords",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "PresentAddress",
                schema: "Employee");
             

            migrationBuilder.DropTable(
                name: "PublicationInfo",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "ServiceHistory",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "SpouseInformation",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "TrainingInformation",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "Cadre",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Color",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Institute",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "PayScalePerGrade",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "PayScaleYearInfo",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "SpecialHolydaySetup",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "WeeklyHolydaySetup",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Accesslist",
                schema: "System");

            migrationBuilder.DropTable(
                name: "AccessMapper",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "System");

            migrationBuilder.DropTable(
                name: "User",
                schema: "System");

            migrationBuilder.DropTable(
                name: "RoutesDetails",
                schema: "BdArmy");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "PresentStatus",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Degree",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "LeaveTypeInformation",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropTable(
                name: "GradationType");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "PromtionNature",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "RecruitPromo",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Posting",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "PostResponsibility",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Designation",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "EmployeeInformation",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "Years",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "UserGroup",
                schema: "System");

            migrationBuilder.DropTable(
                name: "PmsGroup",
                schema: "System");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Routes",
                schema: "BdArmy");

            migrationBuilder.DropTable(
                name: "CalculationMethod",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "PostingType",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "DesignationClass",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Rank",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "EmployeeStatus",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "PoliceStation",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "District",
                schema: "GS");

            migrationBuilder.DropTable(
                name: "Division",
                schema: "GS");
        }
    }
}

using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.ModelBuilderExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTSL.DgFood.Common.Entity
{
    public class DgFoodReadOnlyCtx : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public DgFoodReadOnlyCtx(DbContextOptions<DgFoodReadOnlyCtx> options)
            : base(options) => ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        public DgFoodReadOnlyCtx()
            : base() => ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=SUBHAMDEV\\SQLEXPRESS;Database=Identica My - Core - Auth;User id=subham;Password=abc123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            EntityModelBuilderExtensions.ConfigureUser(modelBuilder);
            EntityModelBuilderExtensions.ConfigureUserGroup(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCategory(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDegree(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDesignation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDesignationClass(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDivision(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDistrict(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEmployeeStatus(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePoliceStation(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePosting(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePostingType(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePostResponsibility(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePresentStatus(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePromtionNature(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRank(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEmployeeInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureChildrenInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDisciplinaryActionsAndCriminalProsecution(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEducationalQualification(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEmployeeTransfer(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePermanentAddress(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePostingRecords(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePresentAddress(modelBuilder);
            EntityModelBuilderExtensions.ConfigureOfficialInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePromotionPartculars(modelBuilder);
            EntityModelBuilderExtensions.ConfigureServiceHistory(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSpouseInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureTrainingInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureColor(modelBuilder);
            EntityModelBuilderExtensions.ConfigureUserRoles(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAccesslist(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAccessMapper(modelBuilder);
            EntityModelBuilderExtensions.ConfigureModule(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePmsGroup(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRoutes(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRoutesDetails(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRoutesLineStringJsons(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLanguage(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLanguageInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureYears(modelBuilder);
            EntityModelBuilderExtensions.ConfigureWeeklyHolydaySetup(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSpecialHolydaySetup(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCalculationMethod(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLeaveTypeInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLeaveApplication(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAwardInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAddl_prof_q_info(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCadre(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEvent(modelBuilder);
            EntityModelBuilderExtensions.ConfigureForeignTravelInfo(modelBuilder);
            EntityModelBuilderExtensions.ConfigureInstitute(modelBuilder);
            EntityModelBuilderExtensions.ConfigureMagisterialPowerInfo(modelBuilder);
            EntityModelBuilderExtensions.ConfigureOtherServiceInfo(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePayScalePerGrade(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePayScaleYearInfo(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePostingAbroad(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePublicationInfo(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRecruitPromo(modelBuilder);
            EntityModelBuilderExtensions.ConfigureTrainingManagementType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureTrainingInformationManagement(modelBuilder);
            EntityModelBuilderExtensions.ConfigureTrainingInformationManagementMaster(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePromotionManagement(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEmployeeInformationCount(modelBuilder);
            EntityModelBuilderExtensions.ConfigureOrganogram(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDisciplinaryHistory(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDocument(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePRL(modelBuilder);
            EntityModelBuilderExtensions.ConfigureUniversityInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureUnion(modelBuilder);
            EntityModelBuilderExtensions.ConfigureTrainingPlan(modelBuilder);
            EntityModelBuilderExtensions.ConfigureOtherTrainingMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEmployeePostingDetails(modelBuilder);

        }
    }
}
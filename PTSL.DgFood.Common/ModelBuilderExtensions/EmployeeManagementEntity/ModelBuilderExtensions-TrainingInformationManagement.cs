using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureTrainingInformationManagement(this ModelBuilder builder)
        {
            builder.Entity<TrainingInformationManagement>(ac =>
            {
            ac.ToTable("TrainingInformationManagement", "Employee");

            ac.Property(a => a.TrainingInformationManagementMasterId)
            .HasColumnName("TrainingInformationManagementMasterId")
            .HasColumnType("bigint")
            .IsRequired();
            ac.Property(a => a.RankId)
            .HasColumnName("RankId")
            .HasColumnType("bigint")
            .IsRequired(false);
            ac.Property(a => a.DesignationId)
            .HasColumnName("DesignationId")
            .HasColumnType("bigint")
            .IsRequired(false);
            ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationId")
            .HasColumnType("bigint")
            .IsRequired(); 

            ac.Property(a => a.ApprovalStatus)
                .HasColumnType("tinyint")
                .HasDefaultValue(TrainingInformationManagementApprovalStatus.Approved); 

             });

            builder.Entity<TrainingInformationManagement>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<TrainingInformationManagement>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.TrainingInformationManagements)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<TrainingInformationManagement>()
            .HasOne<TrainingInformationManagementMaster>(s => s.TrainingInformationManagementMaster)
            .WithMany(g => g.TrainingInformationManagements)
            .HasForeignKey(s => s.TrainingInformationManagementMasterId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

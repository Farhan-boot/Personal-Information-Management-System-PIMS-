using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureTrainingInformationManagementMaster(this ModelBuilder builder)
        {
            builder.Entity<TrainingInformationManagementMaster>(ac =>
            {
            ac.ToTable("TrainingInformationManagementMaster", "Employee");

            ac.Property(a => a.TrainingManagementTypeId)
            .HasColumnName("TrainingManagementTypeId")
            .HasColumnType("bigint")
            .IsRequired();
            ac.Property(a => a.Status)
            .HasColumnName("Status")
            .HasColumnType("bit")
            .IsRequired();
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

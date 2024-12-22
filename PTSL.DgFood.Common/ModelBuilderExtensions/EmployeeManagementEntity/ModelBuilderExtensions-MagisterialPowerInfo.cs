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
        public static void ConfigureMagisterialPowerInfo(this ModelBuilder builder)
        {
            builder.Entity<MagisterialPowerInfo>(ac =>
            {
            ac.ToTable("MagisterialPowerInfo", "Employee");

            ac.Property(a => a.Power)
            .HasColumnName("Power")
            .HasColumnType("nvarchar(250)")
            .IsRequired(false); 
             ac.Property(a => a.DateOfNotification)
            .HasColumnName("DateOfNotification")
            .HasColumnType("datetime2")
            .IsRequired(false);
            ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationId")
            .HasColumnType("bigint")
            .IsRequired(); 
             });

            builder.Entity<MagisterialPowerInfo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<MagisterialPowerInfo>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.MagisterialPowerInfos)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

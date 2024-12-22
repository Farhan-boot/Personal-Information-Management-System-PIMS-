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
        public static void ConfigureForeignTravelInfo(this ModelBuilder builder)
        {
            builder.Entity<ForeignTravelInfo>(ac =>
            {
            ac.ToTable("ForeignTravelInfo", "Employee");
                 
             ac.Property(a => a.Purpose)
            .HasColumnName("Purpose")
            .HasColumnType("nvarchar(250)")
            .IsRequired(false);
             ac.Property(a => a.StartDate)
            .HasColumnName("StartDate")
            .HasColumnType("datetime2")
            .IsRequired();
             ac.Property(a => a.EndDate)
            .HasColumnName("EndDate")
            .HasColumnType("datetime2")
            .IsRequired();
             ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationId")
            .HasColumnType("bigint")
            .IsRequired(); 
             });

            builder.Entity<ForeignTravelInfo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<ForeignTravelInfo>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.ForeignTravelInfos)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

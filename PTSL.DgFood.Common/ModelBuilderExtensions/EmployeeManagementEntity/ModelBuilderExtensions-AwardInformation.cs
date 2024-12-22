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
        public static void ConfigureAwardInformation(this ModelBuilder builder)
        {
            builder.Entity<AwardInformation>(ac =>
            {
            ac.ToTable("AwardInformation", "Employee");

            ac.Property(a => a.AwardName)
            .HasColumnName("AwardName")
            .HasColumnType("nvarchar(250)")
            .IsRequired(false);
             ac.Property(a => a.AwardGround)
            .HasColumnName("AwardGround")
            .HasColumnType("nvarchar(250)")
            .IsRequired(false);
             ac.Property(a => a.AwardDate)
            .HasColumnName("AwardDate")
            .HasColumnType("datetime2")
            .IsRequired(false);
            ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationId")
            .HasColumnType("bigint")
            .IsRequired(); 
             });

            builder.Entity<AwardInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<AwardInformation>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.AwardInformations)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

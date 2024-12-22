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
        public static void ConfigureEmployeeInformationCount(this ModelBuilder builder)
        {
            builder.Entity<EmployeeInformationCount>(ac =>
            {
                ac.ToTable("EmployeeInformationCount", "Employee");

                ac.Property(a => a.DesignationID)
               .HasColumnName("DesignationID")
               .HasColumnType("bigint")
               .IsRequired();

                ac.Property(a => a.RankId)
              .HasColumnName("RankId")
              .HasColumnType("bigint")
              .IsRequired();

                ac.Property(a => a.DesignationClassId)
              .HasColumnName("DesignationClassId")
              .HasColumnType("bigint")
              .IsRequired();

                ac.Property(a => a.ApprovedTotalPost)
                .HasColumnName("ApprovedTotalPost")
                .HasColumnType("int")
                .IsRequired();

                ac.Property(a => a.CurrentTotalActivePost)
                .HasColumnName("CurrentTotalActivePost")
                .HasColumnType("int")
                .IsRequired();

                ac.Property(a => a.CurrentTotalInactivePost)
                .HasColumnName("CurrentTotalInactivePost")
                .HasColumnType("int")
                .IsRequired();

                ac.Property(a => a.InactiveDate)
               .HasColumnName("InactiveDate")
               .HasColumnType("datetime2")
               .IsRequired(false);

                ac.Property(a => a.InactiveReason)
                .HasColumnName("InactiveReason")
                .HasColumnType("nvarchar(250)")
                .IsRequired(false);

                ac.Property(a => a.Remarks)
                .HasColumnName("Remarks")
                .HasColumnType("nvarchar(250)")
                .IsRequired(false);
            });

            builder.Entity<EmployeeInformationCount>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<EmployeeInformationCount>()
            .HasOne<Designation>(s => s.Designation)
            .WithMany(g => g.EmployeeInformationCount)
            .HasForeignKey(s => s.DesignationID).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<EmployeeInformationCount>()
            .HasOne<Rank>(s => s.Rank)
            .WithMany(g => g.EmployeeInformationCount)
            .HasForeignKey(s => s.RankId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<EmployeeInformationCount>()
            .HasOne<DesignationClass>(s => s.DesignationClass)
            .WithMany(g => g.EmployeeInformationCount)
            .HasForeignKey(s => s.DesignationClassId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

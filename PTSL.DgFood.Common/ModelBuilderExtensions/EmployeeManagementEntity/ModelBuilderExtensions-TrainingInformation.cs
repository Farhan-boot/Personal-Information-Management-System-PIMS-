using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureTrainingInformation(this ModelBuilder builder)
        {
            builder.Entity<TrainingInformation>(ac =>
            {
                ac.ToTable("TrainingInformation", "Employee");
                ac.Property(a => a.CourseTitle)
               .HasColumnName("CourseTitle")
               .HasColumnType("nvarchar(1000)")
               .IsRequired();
                ac.Property(a => a.Institute)
                .HasColumnName("Institute")
                .HasColumnType("nvarchar(1000)")
                .IsRequired();
                ac.Property(a => a.Location)
                .HasColumnName("Location")
                .HasColumnType("nvarchar(1000)")
                .IsRequired();
                ac.Property(a => a.FromDate)
                .HasColumnName("FromDate")
                .HasColumnType("datetime2")
                .IsRequired(false);
                ac.Property(a => a.ToDate)
                .HasColumnName("ToDate")
                .HasColumnType("datetime2")
                .IsRequired(false);
                ac.Property(a => a.Grade)
                .HasColumnName("Grade")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.Position)
                .HasColumnName("Position")
                .HasColumnType("nvarchar(300)")
                .IsRequired(false);
                ac.Property(a => a.EmployeeInformationId)
                .HasColumnName("EmployeeInformationId")
                .HasColumnType("bigint")
                .IsRequired();
            });
            builder.Entity<TrainingInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<TrainingInformation>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.TrainingInformation)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);

        }

    }
}

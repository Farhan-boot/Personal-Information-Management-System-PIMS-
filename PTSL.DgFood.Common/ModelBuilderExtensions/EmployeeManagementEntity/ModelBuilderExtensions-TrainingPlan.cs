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
        public static void ConfigureTrainingPlan(this ModelBuilder builder)
        {
            builder.Entity<TrainingPlan>(ac =>
            {
              ac.ToTable("TrainingPlan", "Employee");

              ac.Property(a => a.PossibleTrainingWorkshopTopics)
               .HasColumnName("PossibleTrainingWorkshopTopics")
               .HasColumnType("nvarchar(1000)")
               .IsRequired(false);

              ac.Property(a => a.TrainingHours)
               .HasColumnName("TrainingHours")
               .IsRequired(false);

             ac.Property(a => a.GradeId)
              .HasColumnName("GradeId")
              .HasColumnType("bigint")
              .IsRequired(false);

            ac.Property(a => a.NumberOfParticipants)
             .HasColumnName("NumberOfParticipants")
             .HasColumnType("bigint")
             .IsRequired(false);

            ac.Property(a => a.TotalTrainingHours)
             .HasColumnName("TotalTrainingHours")
             .IsRequired(false);

           ac.Property(a => a.InstructorOrConsultant)
             .HasColumnName("InstructorOrConsultant")
             .HasColumnType("nvarchar(1000)")
             .IsRequired(false);

           ac.Property(a => a.ProbableStartDate)
             .HasColumnName("ProbableStartDate")
             .HasColumnType("datetime2")
             .IsRequired(false);

           ac.Property(a => a.ProbableEndDate)
            .HasColumnName("ProbableEndDate")
            .HasColumnType("datetime2")
            .IsRequired(false);

            });
            builder.Entity<TrainingPlan>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

        }

    }
}

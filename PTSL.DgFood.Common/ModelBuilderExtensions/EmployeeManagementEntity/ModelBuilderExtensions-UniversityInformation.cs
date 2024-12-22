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
        public static void ConfigureUniversityInformation(this ModelBuilder builder)
        {
            builder.Entity<UniversityInformation>(ac =>
            {
                ac.ToTable("UniversityInformation", "Employee");

              ac.Property(a => a.UniversityName)
               .HasColumnName("UniversityName")
               .HasColumnType("nvarchar(1000)")
               .IsRequired(false);

              ac.Property(a => a.Acronym)
              .HasColumnName("Acronym")
              .HasColumnType("nvarchar(1000)")
              .IsRequired(false);

              ac.Property(a => a.EstablishedYear)
               .HasColumnName("EstablishedYear")
               .HasColumnType("bigint")
               .IsRequired(false);

             ac.Property(a => a.Location)
             .HasColumnName("Location")
             .HasColumnType("nvarchar(1000)")
             .IsRequired(false);

            });
            builder.Entity<UniversityInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

        }

    }
}

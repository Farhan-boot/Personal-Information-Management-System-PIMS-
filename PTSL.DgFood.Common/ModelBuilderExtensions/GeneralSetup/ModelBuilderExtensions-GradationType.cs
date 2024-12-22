using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureGradationType(this ModelBuilder builder)
        {
            builder.Entity<GradationType>(ac =>
            {
                ac.ToTable("GradationType", "GS");

                ac.Property(a => a.GradationTypeName)
                    .HasColumnName("GradationTypeName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<GradationType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

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
        public static void ConfigureDegree(this ModelBuilder builder)
        {
            builder.Entity<Degree>(ac =>
            {
                ac.ToTable("Degree", "GS");

                ac.Property(a => a.DegreeName)
                    .HasColumnName("DegreeName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<Degree>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }

    }
}

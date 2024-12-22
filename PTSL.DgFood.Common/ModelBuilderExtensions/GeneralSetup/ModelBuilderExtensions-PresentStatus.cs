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
        public static void ConfigurePresentStatus(this ModelBuilder builder)
        {
            builder.Entity<PresentStatus>(ac =>
            {
                ac.ToTable("PresentStatus", "GS");

                ac.Property(a => a.PresentStatusName)
                    .HasColumnName("PresentStatusName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<PresentStatus>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }

    }
}

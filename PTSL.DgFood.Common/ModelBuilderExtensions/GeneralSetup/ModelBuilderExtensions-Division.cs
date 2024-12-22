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
        public static void ConfigureDivision(this ModelBuilder builder)
        {
            builder.Entity<Division>(ac =>
            {
                ac.ToTable("Division", "GS");

                ac.Property(a => a.DivisionName)
                    .HasColumnName("DivisionName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.DivisionNameBangla)
                    .HasColumnName("DivisionNameBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);
            });
            builder.Entity<Division>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }

    }
}

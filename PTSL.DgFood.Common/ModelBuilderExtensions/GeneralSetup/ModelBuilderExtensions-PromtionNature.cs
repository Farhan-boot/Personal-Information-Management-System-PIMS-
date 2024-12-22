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
        public static void ConfigurePromtionNature(this ModelBuilder builder)
        {
            builder.Entity<PromtionNature>(ac =>
            {
                ac.ToTable("PromtionNature", "GS");

                ac.Property(a => a.PromtionNatureName)
                    .HasColumnName("PromtionNatureName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.PromtionNatureNameBangla)
                    .HasColumnName("PromtionNatureNameBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);
            });
            builder.Entity<PromtionNature>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }

    }
}

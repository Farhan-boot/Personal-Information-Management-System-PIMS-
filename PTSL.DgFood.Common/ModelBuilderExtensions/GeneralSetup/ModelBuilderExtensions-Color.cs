using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureColor(this ModelBuilder builder)
        {
            builder.Entity<Color>(ac =>
            {
                ac.ToTable("Color", "GS");

                ac.Property(a => a.ColorName)
                    .HasColumnName("ColorName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<Color>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

        }

    }
}

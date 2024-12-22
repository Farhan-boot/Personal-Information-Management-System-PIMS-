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
        public static void ConfigureYears(this ModelBuilder builder)
        {
            builder.Entity<Years>(ac =>
            {
                ac.ToTable("Years", "GS");

                ac.Property(a => a.YearsName)
                    .HasColumnName("YearsName")
                    .HasColumnType("int")
                    .IsRequired();
            });
            builder.Entity<Years>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

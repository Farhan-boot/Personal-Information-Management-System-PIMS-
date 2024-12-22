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
        public static void ConfigureWeeklyHolydaySetup(this ModelBuilder builder)
        {
            builder.Entity<WeeklyHolydaySetup>(ac =>
            {
                ac.ToTable("WeeklyHolydaySetup", "GS");

                ac.Property(a => a.YearsId)
                    .HasColumnName("YearsId")
                    .HasColumnType("bigint")
                    .IsRequired();
                ac.Property(a => a.HolidayDate)
                    .HasColumnName("HolidayDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                ac.Property(a => a.Day)
                    .HasColumnName("Day")
                    .HasColumnType("int")
                    .IsRequired();
            });
            builder.Entity<WeeklyHolydaySetup>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

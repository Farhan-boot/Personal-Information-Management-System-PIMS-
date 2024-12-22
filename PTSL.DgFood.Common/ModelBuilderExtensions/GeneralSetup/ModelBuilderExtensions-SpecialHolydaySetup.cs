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
        public static void ConfigureSpecialHolydaySetup(this ModelBuilder builder)
        {
            builder.Entity<SpecialHolydaySetup>(ac =>
            {
                ac.ToTable("SpecialHolydaySetup", "GS");

                ac.Property(a => a.SpecialHolydaySetupName)
                    .HasColumnName("SpecialHolydaySetupName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();
                ac.Property(a => a.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                ac.Property(a => a.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
            });
            builder.Entity<SpecialHolydaySetup>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

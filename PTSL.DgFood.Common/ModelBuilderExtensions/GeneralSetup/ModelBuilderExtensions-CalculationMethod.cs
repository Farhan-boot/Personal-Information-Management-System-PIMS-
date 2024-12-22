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
        public static void ConfigureCalculationMethod(this ModelBuilder builder)
        {
            builder.Entity<CalculationMethod>(ac =>
            {
                ac.ToTable("CalculationMethod", "GS");

                ac.Property(a => a.CalculationMethodName)
                    .HasColumnName("CalculationMethodName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<CalculationMethod>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

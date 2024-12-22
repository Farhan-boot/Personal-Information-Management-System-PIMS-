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
        public static void ConfigurePayScaleYearInfo(this ModelBuilder builder)
        {
            builder.Entity<PayScaleYearInfo>(ac =>
            {
                ac.ToTable("PayScaleYearInfo", "GS");

                ac.Property(a => a.PayScaleYearInfoName)
                    .HasColumnName("PayScaleYearInfoName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.ImplementationDate)
                    .HasColumnName("ImplementationDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
            });
            builder.Entity<PayScaleYearInfo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

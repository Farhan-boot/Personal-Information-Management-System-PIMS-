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
        public static void ConfigureInstitute(this ModelBuilder builder)
        {
            builder.Entity<Institute>(ac =>
            {
                ac.ToTable("Institute", "GS");

                ac.Property(a => a.InstituteName)
                    .HasColumnName("InstituteName")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired();
            });
            builder.Entity<Institute>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

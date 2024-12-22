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
        public static void ConfigureJobCategory(this ModelBuilder builder)
        {
            builder.Entity<JobCategory>(ac =>
            {
                ac.ToTable("JobCategory", "GS");

                ac.Property(a => a.JobCategoryName)
                    .HasColumnName("JobCategoryName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<JobCategory>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

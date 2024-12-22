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
        public static void ConfigureCategory(this ModelBuilder builder)
        {
            builder.Entity<Category>(ac =>
            {
                ac.ToTable("Category", "GS");

                ac.Property(a => a.CategoryName)
                    .HasColumnName("CategoryName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<Category>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

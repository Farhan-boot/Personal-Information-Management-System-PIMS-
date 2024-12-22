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
        public static void ConfigurePostResponsibility(this ModelBuilder builder)
        {
            builder.Entity<PostResponsibility>(ac =>
            {
                ac.ToTable("PostResponsibility", "GS");

                ac.Property(a => a.PostResponsibilityName)
                    .HasColumnName("PostResponsibilityName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<PostResponsibility>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }

    }
}

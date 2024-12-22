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
        public static void ConfigurePostingType(this ModelBuilder builder)
        {
            builder.Entity<PostingType>(ac =>
            {
                ac.ToTable("PostingType", "GS");

                ac.Property(a => a.PostingTypeName)
                    .HasColumnName("PostingTypeName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.PostingTypeNameBangla)
                    .HasColumnName("PostingTypeNameBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);
            });
            builder.Entity<PostingType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }

    }
}

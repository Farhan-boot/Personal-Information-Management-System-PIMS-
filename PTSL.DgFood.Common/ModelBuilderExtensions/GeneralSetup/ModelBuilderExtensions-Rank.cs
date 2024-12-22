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
        public static void ConfigureRank(this ModelBuilder builder)
        {
            builder.Entity<Rank>(ac =>
            {
                ac.ToTable("Rank", "GS");

                ac.Property(a => a.RankName)
                    .HasColumnName("RankName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.RankNameBangla)
                    .HasColumnName("RankNameBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);
            });
            builder.Entity<Rank>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

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
        public static void ConfigureDistrict(this ModelBuilder builder)
        {
            builder.Entity<District>(ac =>
            {
                ac.ToTable("District", "GS");

                ac.Property(a => a.DistrictName)
                    .HasColumnName("DistrictName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.DistrictNameBangla)
                    .HasColumnName("DistrictNameBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);

                ac.Property(a => a.DivisionId)
                    .HasColumnName("DivisionId")
                    .HasColumnType("bigint")
                    .IsRequired();
            });
            builder.Entity<District>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<District>()
             .HasOne<Division>(s => s.Division)
             .WithMany(g => g.Districts)
             .HasForeignKey(s => s.DivisionId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

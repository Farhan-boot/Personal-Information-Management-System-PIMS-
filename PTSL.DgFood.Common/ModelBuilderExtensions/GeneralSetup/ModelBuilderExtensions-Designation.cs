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
        public static void ConfigureDesignation(this ModelBuilder builder)
        {
            builder.Entity<Designation>(ac =>
            {
                ac.ToTable("Designation", "GS");

                ac.Property(a => a.DesignationName)
                    .HasColumnName("DesignationName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.DesignationNameBangla)
                    .HasColumnName("DesignationNameBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);

                ac.Property(a => a.RankId)
                .HasColumnName("RankId")
                .HasColumnType("bigint")
                .IsRequired();

            ac.Property(a => a.DesignationClassId)
                .HasColumnName("DesignationClassId")
                .HasColumnType("bigint")
                .IsRequired(); 
            });
            builder.Entity<Designation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
            builder.Entity<Designation>()
            .HasOne<Rank>(s => s.Rank)
            .WithMany(g => g.Designations)
            .HasForeignKey(s => s.RankId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Designation>()
            .HasOne<DesignationClass>(s => s.DesignationClasses)
            .WithMany(g => g.Designations)
            .HasForeignKey(s => s.DesignationClassId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

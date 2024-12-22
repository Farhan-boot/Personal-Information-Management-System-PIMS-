using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigurePmsGroup(this ModelBuilder builder)
        {
            builder.Entity<PmsGroup>(ac =>
            {
                ac.ToTable("PmsGroup", "System");

                ac.Property(a => a.GroupName)
                    .HasColumnName("GroupName")
                    .HasColumnType("nvarchar(40)")
                    .IsRequired();

                ac.Property(a => a.GroupDescription)
                    .HasColumnName("GroupDescription")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired();

                ac.Property(a => a.GroupStatus)
                    .HasColumnName("GroupStatus")
                    .HasColumnType("tinyint");

                ac.Property(a => a.IsVisible)
                    .HasColumnName("IsVisible")
                    .HasColumnType("tinyint");
            });
            builder.Entity<PmsGroup>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }
    }
}

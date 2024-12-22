using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureUserGroup(this ModelBuilder builder)
        {
            builder.Entity<UserGroup>(ac =>
            {
                ac.ToTable("UserGroup", "System");

                ac.Property(a => a.GroupName)
                    .HasColumnName("GroupName")
                    .HasColumnType("nvarchar(40)")
                    .IsRequired();

                ac.Property(a => a.ModuleActionNames)
                    .HasColumnName("ModuleActionNames")
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                ac.Property(a => a.IsUsed)
                    .HasColumnName("IsUsed")
                    .HasColumnType("tinyint");
                ac.Property(a => a.IsDefault)
                    .HasColumnName("IsDefault")
                    .HasColumnType("tinyint");

                ac.Property(a => a.IsVisible)
                    .HasColumnName("IsVisible")
                    .HasColumnType("tinyint");
            });
            builder.Entity<UserGroup>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }
    }
}

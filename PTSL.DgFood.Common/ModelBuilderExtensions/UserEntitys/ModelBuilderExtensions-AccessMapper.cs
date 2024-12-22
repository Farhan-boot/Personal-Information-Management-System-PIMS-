using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureAccessMapper(this ModelBuilder builder)
        {
            builder.Entity<AccessMapper>(ac =>
            {
                ac.ToTable("AccessMapper", "System");

                ac.Property(a => a.AccessList)
                    .HasColumnName("AccessList")
                    .HasColumnType("nvarchar(500)")
                    .IsRequired();
                ac.Property(a => a.RoleStatus)
                    .HasColumnName("RoleStatus")
                    .HasColumnType("tinyint")
                    .IsRequired();
                ac.Property(a => a.IsVisible)
                    .HasColumnName("IsVisible")
                    .HasColumnType("tinyint")
                    .IsRequired();
            });
            builder.Entity<AccessMapper>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

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
        public static void ConfigureUserRoles(this ModelBuilder builder)
        {
            builder.Entity<UserRoles>(ac =>
            {
                ac.ToTable("UserRoles", "System");

                ac.Property(a => a.RoleName)
                    .HasColumnName("RoleName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<UserRoles>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

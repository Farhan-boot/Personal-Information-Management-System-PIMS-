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
        public static void ConfigureEmployeeStatus(this ModelBuilder builder)
        {
            builder.Entity<EmployeeStatus>(ac =>
            {
                ac.ToTable("EmployeeStatus", "GS");

                ac.Property(a => a.EmployeeStatusName)
                    .HasColumnName("EmployeeStatusName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();

                ac.Property(a => a.EmployeeStatusNameBangla)
                    .HasColumnName("EmployeeStatusNameBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);
            });
            builder.Entity<EmployeeStatus>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }

    }
}

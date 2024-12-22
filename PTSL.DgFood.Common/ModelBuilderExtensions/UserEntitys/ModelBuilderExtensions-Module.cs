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
        public static void ConfigureModule(this ModelBuilder builder)
        {
            builder.Entity<Module>(ac =>
            {
                ac.ToTable("Module", "System");

                ac.Property(a => a.ModuleName)
                    .HasColumnName("ModuleName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(); 
                ac.Property(a => a.ModuleIcon)
                    .HasColumnName("ModuleIcon")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.MenueOrder)
                    .HasColumnName("MenueOrder")
                    .HasColumnType("int")
                    .IsRequired();
            });
            builder.Entity<Module>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

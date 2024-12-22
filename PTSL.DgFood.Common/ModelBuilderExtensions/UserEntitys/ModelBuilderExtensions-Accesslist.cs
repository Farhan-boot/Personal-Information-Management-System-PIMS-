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
        public static void ConfigureAccesslist(this ModelBuilder builder)
        {
            builder.Entity<Accesslist>(ac =>
            {
                ac.ToTable("Accesslist", "System");

                ac.Property(a => a.ControllerName)
                    .HasColumnName("ControllerName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.ActionName)
                    .HasColumnName("ActionName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.Mask)
                    .HasColumnName("Mask")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.AccessStatus)
                    .HasColumnName("AccessStatus")
                    .HasColumnType("tinyint")
                    .IsRequired();
                ac.Property(a => a.IsVisible)
                    .HasColumnName("IsVisible")
                    .HasColumnType("tinyint")
                    .IsRequired();
                ac.Property(a => a.IconClass)
                    .HasColumnName("IconClass")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.BaseModule)
                    .HasColumnName("BaseModule")
                    .HasColumnType("int")
                    .IsRequired();
                ac.Property(a => a.BaseModuleIndex)
                    .HasColumnName("BaseModuleIndex")
                    .HasColumnType("int")
                    .IsRequired(false);
            });
            builder.Entity<Accesslist>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

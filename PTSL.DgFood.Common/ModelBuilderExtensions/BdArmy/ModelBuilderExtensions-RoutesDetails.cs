using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity.BdArmy;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureRoutesDetails(this ModelBuilder builder)
        {
            builder.Entity<RoutesDetails>(ac =>
            {
                ac.ToTable("RoutesDetails", "BdArmy");

                ac.Property(a => a.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                ac.Property(a => a.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                ac.Property(a => a.StartTime)
                    .HasColumnName("StartTime")
                    .HasColumnType("float")
                    .IsRequired();
                ac.Property(a => a.EndTime)
                    .HasColumnName("EndTime")
                    .HasColumnType("float")
                    .IsRequired();
                ac.Property(a => a.Latitude)
                    .HasColumnName("Latitude")
                    .HasColumnType("float")
                    .IsRequired();
                ac.Property(a => a.Longitude)
                    .HasColumnName("Longitude")
                    .HasColumnType("float")
                    .IsRequired();
                ac.Property(a => a.Radius)
                    .HasColumnName("Radius")
                    .HasColumnType("float")
                    .IsRequired(false);
                ac.Property(a => a.PlaceName)
                    .HasColumnName("PlaceName")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired();
                ac.Property(a => a.RoutesId)
                    .HasColumnName("RoutesId")
                    .HasColumnType("bigint")
                    .IsRequired();
                ac.Property(a => a.IsArrived)
                    .HasColumnName("IsArrived")
                    .HasColumnType("bit")
                    .IsRequired();
            });
            builder.Entity<RoutesDetails>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<RoutesDetails>()
            .HasOne<Routes>(s => s.Routes)
            .WithMany(g => g.RoutesDetails)
            .HasForeignKey(s => s.RoutesId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

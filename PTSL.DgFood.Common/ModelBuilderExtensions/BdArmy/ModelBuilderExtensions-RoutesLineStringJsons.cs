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
        public static void ConfigureRoutesLineStringJsons(this ModelBuilder builder)
        {
            builder.Entity<RoutesLineStringJsons>(ac =>
            {
                ac.ToTable("RoutesLineStringJsons", "BdArmy");

                ac.Property(a => a.UserId)
                    .HasColumnName("UserId")
                    .HasColumnType("bigint")
                    .IsRequired();
                ac.Property(a => a.RoutesId)
                    .HasColumnName("RoutesId")
                    .HasColumnType("bigint")
                    .IsRequired();
                ac.Property(a => a.RoutesDetailsId)
                    .HasColumnName("RoutesDetailsId")
                    .HasColumnType("bigint")
                    .IsRequired();
                ac.Property(a => a.JsonFileName)
                    .HasColumnName("JsonFileName")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired();
                ac.Property(a => a.StartLatitude)
                    .HasColumnName("StartLatitude")
                    .HasColumnType("float")
                    .IsRequired();
                ac.Property(a => a.StartLongitude)
                    .HasColumnName("StartLongitude")
                    .HasColumnType("float")
                    .IsRequired();
                ac.Property(a => a.EndLatitude)
                    .HasColumnName("EndLatitude")
                    .HasColumnType("float")
                    .IsRequired();
                ac.Property(a => a.EndLongitude)
                    .HasColumnName("EndLongitude")
                    .HasColumnType("float")
                    .IsRequired();
            });
            builder.Entity<RoutesLineStringJsons>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<RoutesLineStringJsons>()
            .HasOne<Routes>(s => s.Routes)
            .WithMany(g => g.LineStringJsons)
            .HasForeignKey(s => s.RoutesId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<RoutesLineStringJsons>()
            .HasOne<RoutesDetails>(s => s.RoutesDetails)
            .WithMany(g => g.LineStringJsons)
            .HasForeignKey(s => s.RoutesDetailsId).OnDelete(DeleteBehavior.ClientCascade);

        }

    }
}

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
        public static void ConfigureRoutes(this ModelBuilder builder)
        {
            builder.Entity<Routes>(ac =>
            {
                ac.ToTable("Routes", "BdArmy");

                ac.Property(a => a.UserId)
                    .HasColumnName("UserId")
                    .HasColumnType("bigint")
                    .IsRequired();
                ac.Property(a => a.IsArrived)
                    .HasColumnName("IsArrived")
                    .HasColumnType("bit")
                    .IsRequired();
                ac.Property(a => a.JsonFileName)
                    .HasColumnName("JsonFileName")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired(false);
                ac.Property(a => a.SessionName)
                    .HasColumnName("SessionName")
                    .HasColumnType("nvarchar(150)")
                    .IsRequired();
                ac.Property(a => a.SessionId)
                    .HasColumnName("SessionId")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired();

            });
            builder.Entity<Routes>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

        }

    }
}

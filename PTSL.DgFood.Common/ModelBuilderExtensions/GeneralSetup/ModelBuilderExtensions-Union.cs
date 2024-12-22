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
        public static void ConfigureUnion(this ModelBuilder builder)
        {
            builder.Entity<Union>(ac =>
            {
                ac.ToTable("Union", "GS");

                ac.Property(a => a.Name)
                    .HasColumnType("varchar(100)")
                    .IsRequired();
                ac.Property(a => a.NameBn)
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);
            });
            builder.Entity<Union>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<Union>()
                .HasOne(x => x.Upazilla)
                .WithMany(x => x.Unions)
                .HasForeignKey(x => x.UpazillaId);
        }
    }
}

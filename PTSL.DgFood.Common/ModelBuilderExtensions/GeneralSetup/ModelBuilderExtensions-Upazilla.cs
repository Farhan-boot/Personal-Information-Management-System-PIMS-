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
        public static void ConfigureUpazilla(this ModelBuilder builder)
        {
            builder.Entity<Upazilla>(ac =>
            {
                ac.ToTable("Division", "GS");

                ac.Property(a => a.Name)
                    .HasColumnType("varchar(100)")
                    .IsRequired();
                ac.Property(a => a.NameBn)
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);
            });
            builder.Entity<Upazilla>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<Upazilla>()
                .HasOne(x => x.District)
                .WithMany(x => x.Upazillas)
                .HasForeignKey(x => x.DistrictId);
        }
    }
}

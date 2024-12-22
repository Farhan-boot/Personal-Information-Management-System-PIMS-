using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigurePoliceStation(this ModelBuilder builder)
        {
            builder.Entity<PoliceStation>(ac =>
            {
                ac.ToTable("PoliceStation", "GS");

                ac.Property(a => a.PoliceStationName)
                    .HasColumnName("PoliceStationName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.PoliceStationNameBangla)
                    .HasColumnName("PoliceStationNameBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);
                ac.Property(a => a.DistrictId)
                    .HasColumnName("DistrictId")
                    .HasColumnType("bigint")
                    .IsRequired();
            });
            builder.Entity<PoliceStation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<PoliceStation>()
            .HasOne<District>(s => s.District)
            .WithMany(g => g.PoliceStations)
            .HasForeignKey(s => s.DistrictId).OnDelete(DeleteBehavior.ClientCascade);
             
        }

    }
}

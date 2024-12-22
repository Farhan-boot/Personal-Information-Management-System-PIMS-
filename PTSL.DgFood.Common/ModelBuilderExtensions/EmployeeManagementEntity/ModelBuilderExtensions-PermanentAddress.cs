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
        public static void ConfigurePermanentAddress(this ModelBuilder builder)
        {
            builder.Entity<PermanentAddress>(ac =>
            {
                ac.ToTable("PermanentAddress", "Employee");

                ac.Property(a => a.VillageHouseNoAndRoadInEnglish)
                .HasColumnName("VillageHouseNoAndRoadInEnglish")
                .HasColumnType("nvarchar(1000)")
                .IsRequired();
                ac.Property(a => a.VillageHouseNoAndRoadInBangla)
                .HasColumnName("VillageHouseNoAndRoadInBangla")
                .HasColumnType("nvarchar(1000)")
                .IsRequired();
                ac.Property(a => a.DivisionId)
                .HasColumnName("DivisionId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.DistrictId)
                .HasColumnName("DistrictId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.PoliceStationId)
                .HasColumnName("PoliceStationId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.EmployeeInformationId)
                .HasColumnName("EmployeeInformationId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.OtherThana)
                .HasColumnName("OtherThana")
                .HasColumnType("nvarchar(400)")
                .IsRequired(false);
                ac.Property(a => a.PostOfficeInEnglish)
                .HasColumnName("PostOfficeInEnglish")
                .HasColumnType("nvarchar(200)")
                .IsRequired();
                ac.Property(a => a.PostOfficeInBangla)
                .HasColumnName("PostOfficeInBangla")
                .HasColumnType("nvarchar(200)")
                .IsRequired();
                ac.Property(a => a.TelephoneNo)
                .HasColumnName("TelephoneNo")
                .HasColumnType("nvarchar(60)")
                .IsRequired(false);
            });
            builder.Entity<PermanentAddress>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<PermanentAddress>()
            .HasOne<District>(ad => ad.District)
            .WithMany(s => s.PermanentAddresses)
            .HasForeignKey(ad => ad.DistrictId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PermanentAddress>()
            .HasOne<Division>(ad => ad.Division)
            .WithMany(s => s.PermanentAddresses)
            .HasForeignKey(ad => ad.DivisionId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PermanentAddress>()
            .HasOne<PoliceStation>(ad => ad.PoliceStation)
            .WithMany(s => s.PermanentAddresses)
            .HasForeignKey(ad => ad.PoliceStationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PermanentAddress>()
            .HasOne<EmployeeInformation>(ad => ad.EmployeeInformation)
            .WithMany(s => s.PermanentAddresses)
            .HasForeignKey(ad => ad.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);


        //Add New
          builder.Entity<PermanentAddress>()
          .HasOne<Upazilla>(ad => ad.Upazilla)
          .WithMany(s => s.PermanentAddresses)
          .HasForeignKey(ad => ad.UpazillaId).OnDelete(DeleteBehavior.ClientCascade);

         builder.Entity<PermanentAddress>()
         .HasOne<Union>(ad => ad.Union)
         .WithMany(s => s.PermanentAddresses)
         .HasForeignKey(ad => ad.UnionId).OnDelete(DeleteBehavior.ClientCascade);

        }

    }
}

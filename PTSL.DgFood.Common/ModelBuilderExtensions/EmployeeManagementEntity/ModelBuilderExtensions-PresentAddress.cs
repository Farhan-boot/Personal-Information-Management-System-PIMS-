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
        public static void ConfigurePresentAddress(this ModelBuilder builder)
        {
            builder.Entity<PresentAddress>(ac =>
            {
                ac.ToTable("PresentAddress", "Employee");

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
            builder.Entity<PresentAddress>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<PresentAddress>()
            .HasOne<District>(ad => ad.District)
            .WithMany(s => s.PresentAddresses)
            .HasForeignKey(ad => ad.DistrictId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PresentAddress>()
            .HasOne<Division>(ad => ad.Division)
            .WithMany(s => s.PresentAddresses)
            .HasForeignKey(ad => ad.DivisionId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PresentAddress>()
            .HasOne<PoliceStation>(ad => ad.PoliceStation)
            .WithMany(s => s.PresentAddresses)
            .HasForeignKey(ad => ad.PoliceStationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PresentAddress>()
            .HasOne<EmployeeInformation>(ad => ad.EmployeeInformation)
            .WithMany(s => s.PresentAddresses)
            .HasForeignKey(ad => ad.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);

         ///Add New
          builder.Entity<PresentAddress>()
            .HasOne<Upazilla>(ad => ad.Upazilla)
            .WithMany(s => s.PresentAddresses)
            .HasForeignKey(ad => ad.UpazillaId).OnDelete(DeleteBehavior.ClientCascade);

           builder.Entity<PresentAddress>()
           .HasOne<Union>(ad => ad.Union)
           .WithMany(s => s.PresentAddresses)
           .HasForeignKey(ad => ad.UnionId).OnDelete(DeleteBehavior.ClientCascade);


        }

    }
}

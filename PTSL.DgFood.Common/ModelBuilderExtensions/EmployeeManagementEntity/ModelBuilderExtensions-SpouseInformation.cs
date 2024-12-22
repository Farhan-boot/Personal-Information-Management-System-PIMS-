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
        public static void ConfigureSpouseInformation(this ModelBuilder builder)
        {
            builder.Entity<SpouseInformation>(ac =>
            {
                ac.ToTable("SpouseInformation", "Employee");
                ac.Property(a => a.NameInBangla)
                .HasColumnName("NameInBangla")
                .HasColumnType("nvarchar(100)")
                .IsRequired();
                ac.Property(a => a.NameInEnglish)
                .HasColumnName("NameInEnglish")
                .HasColumnType("nvarchar(100)")
                .IsRequired();
                ac.Property(a => a.DivisionId)
                .HasColumnName("DivisionId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.DistrictId)
                .HasColumnName("DistrictId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.EmployeeInformationId)
                .HasColumnName("EmployeeInformationId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.Occupation)
                .HasColumnName("Occupation")
                .HasColumnType("nvarchar(100)")
                .IsRequired();
                ac.Property(a => a.Designation)
                .HasColumnName("Designation")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.Location)
                .HasColumnName("Location")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
            });
            builder.Entity<SpouseInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<SpouseInformation>()
            .HasOne<District>(ad => ad.District)
            .WithMany(s => s.SpouseInformation)
            .HasForeignKey(ad => ad.DistrictId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<SpouseInformation>()
            .HasOne<Division>(ad => ad.Division)
            .WithMany(s => s.SpouseInformation)
            .HasForeignKey(ad => ad.DivisionId).OnDelete(DeleteBehavior.ClientCascade);


            builder.Entity<SpouseInformation>()
            .HasOne<EmployeeInformation>(ad => ad.EmployeeInformation)
            .WithMany(s => s.SpouseInformation)
            .HasForeignKey(ad => ad.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

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
        public static void ConfigurePromotionPartculars(this ModelBuilder builder)
        {
            builder.Entity<PromotionPartculars>(ac =>
            {
                ac.ToTable("PromotionPartculars", "Employee");

                ac.Property(a => a.RankId)
                .HasColumnName("RankId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.DesignationId)
                .HasColumnName("DesignationId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.PromotionDate)
                .HasColumnName("PromotionDate")
                .HasColumnType("datetime2")
                .IsRequired(false);
                ac.Property(a => a.GONumber)
                .HasColumnName("GONumber")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.GODate)
                .HasColumnName("GODate")
                .HasColumnType("datetime2")
                .IsRequired(false);
                //ac.Property(a => a.NatureOfPromotionId)
                //.HasColumnName("NatureOfPromotionId")
                //.HasColumnType("bigint")
                //.IsRequired();
                ac.Property(a => a.PayScaleYearInfoId)
                .HasColumnName("PayScaleYearInfoId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.PayScale)
                .HasColumnName("PayScale")
                .HasColumnType("nvarchar(200)")
                .IsRequired(false);
                ac.Property(a => a.PresentPosting)
                .HasColumnName("PresentPosting")
                .HasColumnType("bit")
                .IsRequired();
                ac.Property(a => a.PromtionNatureId)
                .HasColumnName("PromtionNatureId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.EmployeeInformationId)
                .HasColumnName("EmployeeInformationId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.PromotionStatus)
                .HasColumnName("PromotionStatus")
                .HasColumnType("bit")
                .IsRequired();
            });
            builder.Entity<PromotionPartculars>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<PromotionPartculars>()
            .HasOne<Designation>(ad => ad.Designation)
            .WithMany(s => s.PromotionPartculars)
            .HasForeignKey(ad => ad.DesignationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PromotionPartculars>()
            .HasOne<Rank>(ad => ad.Rank)
            .WithMany(s => s.PromotionPartculars)
            .HasForeignKey(ad => ad.RankId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PromotionPartculars>()
            .HasOne<PromtionNature>(ad => ad.PromtionNature)
            .WithMany(s => s.PromotionPartculars)
            .HasForeignKey(ad => ad.PromtionNatureId).OnDelete(DeleteBehavior.ClientCascade);


            builder.Entity<PromotionPartculars>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.PromotionPartculars)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PromotionPartculars>()
            .HasOne<PromotionManagement>(s => s.PromotionManagement)
            .WithOne(ad => ad.PromotionPartculars)
            .HasForeignKey<PromotionPartculars>(ad => ad.PromotionManagementId);

        }

    }
}

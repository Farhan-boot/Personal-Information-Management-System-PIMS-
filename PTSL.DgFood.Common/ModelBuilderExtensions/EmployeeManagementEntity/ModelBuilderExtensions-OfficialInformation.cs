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
        public static void ConfigureOfficialInformation(this ModelBuilder builder)
        {
            builder.Entity<OfficialInformation>(ac =>
            {
                ac.ToTable("OfficialInformation", "Employee");

                ac.Property(a => a.FirstJoiningDate)
                .HasColumnName("FirstJoiningDate")
                .HasColumnType("datetime2")
                .IsRequired(false);

                ac.Property(a => a.JoinOrganogramOfficeType)
                    .HasColumnType("tinyint")
                    .IsRequired(false);
                ac.Property(a => a.PresentOrganogramOfficeType)
                    .HasColumnType("tinyint")
                    .IsRequired(false);

                ac.Property(a => a.JoinPostingTypeId)
                .HasColumnName("JoinPostingTypeId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.JoinPostingId)
                .HasColumnName("JoinPostingId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.JoiningDesignationClassId)
                .HasColumnName("JoiningDesignationClassId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.JoiningDesgId)
                .HasColumnName("JoiningDesgId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.CadreId)
                .HasColumnName("CadreId")
                .HasColumnType("int")
                .IsRequired();

                ac.Property(a => a.PresentJoinDate)
                .HasColumnName("PresentJoinDate")
                .HasColumnType("datetime2")
                .IsRequired();
                ac.Property(a => a.RecruitPromoId)
                .HasColumnName("RecruitPromoId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.Section)
                .HasColumnName("Section")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.SectionAt)
                .HasColumnName("SectionAt")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.PRLDate)
                .HasColumnName("PRLDate")
                .HasColumnType("nvarchar(20)")
                .IsRequired(false);
                ac.Property(a => a.Remarks)
                .HasColumnName("Remarks")
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);
                ac.Property(a => a.JoiningRankId)
                .HasColumnName("JoiningRankId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.PresentRankId)
                .HasColumnName("PresentRankId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.PresentDesignationClassId)
                .HasColumnName("PresentDesignationClassId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.PresentDesignationId)
                .HasColumnName("PresentDesignationId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.CrntDesgId)
                .HasColumnName("CrntDesgId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.JoiningDesgId)
                .HasColumnName("JoiningDesgId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.JoiningDesignationClassId)
                .HasColumnName("JoiningDesignationClassId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.CurrDesignationClassId)
                .HasColumnName("CurrDesignationClassId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.PostResponsibilityId)
                .HasColumnName("PostResponsibilityId")
                .HasColumnType("bigint")
                .IsRequired(false); 
                ac.Property(a => a.PromtionNatureId)
                .HasColumnName("PromtionNatureId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.PostingTypeId)
                .HasColumnName("PostingTypeId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.DeppostingTypeId)
                .HasColumnName("DeppostingTypeId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.PostingId)
                .HasColumnName("PostingId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.DepPostingId)
                .HasColumnName("DepPostingId")
                .HasColumnType("bigint")
                .IsRequired(false);
                
                ac.Property(a => a.EmployeeInformationId)
                .HasColumnName("EmployeeInformationId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.CadreDate)
              .HasColumnName("CadreDate")
              .HasColumnType("datetime2")
              .IsRequired(false);
                ac.Property(a => a.OrderNumber)
                .HasColumnName("OrderNumber")
                .HasColumnType("nvarchar(100)")
                .IsRequired();
                ac.Property(a => a.OrderDate)
                .HasColumnName("OrderDate")
                .HasColumnType("datetime2")
                .IsRequired(false);
                ac.Property(a => a.Batch)
                .HasColumnName("Batch")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.JobCategoryId)
                .HasColumnName("JobCategoryId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.EmployeeTypeId)
                .HasColumnName("EmployeeTypeId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.GradationTypeId)
                .HasColumnName("GradationTypeId")
                .HasColumnType("bigint")
                .IsRequired(false);

                ac.Property(a => a.CrntOrganogramOfficeType)
                .HasColumnName("CrntOrganogramOfficeType")
                .IsRequired(false);
                ac.Property(a => a.IsCrntPostPermanent)
                .HasColumnName("IsCrntPostPermanent")
                .IsRequired();
            });
            builder.Entity<OfficialInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
            builder.Entity<OfficialInformation>()
            .HasOne<Designation>(ad => ad.PresentDesignation)
            .WithMany(s => s.PresentPostingDetails)
            .HasForeignKey(ad => ad.PresentDesignationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<Designation>(ad => ad.PresentDesignation)
            .WithMany(s => s.PresentPostingDetails)
            .HasForeignKey(ad => ad.PresentDesignationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<Designation>(ad => ad.CrntDesg)
            .WithMany(s => s.CrntPostingDetails)
            .HasForeignKey(ad => ad.CrntDesgId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<DesignationClass>(ad => ad.PresentDesignationClass)
            .WithMany(s => s.PresentPostingDetails)
            .HasForeignKey(ad => ad.PresentDesignationClassId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<DesignationClass>(ad => ad.CurrDesignationClass)
            .WithMany(s => s.CurrPostingDetails)
            .HasForeignKey(ad => ad.CurrDesignationClassId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<DesignationClass>(ad => ad.JoiningDesignationClass)
            .WithMany(s => s.JoiningPostingDetails)
            .HasForeignKey(ad => ad.JoiningDesignationClassId).OnDelete(DeleteBehavior.ClientCascade);

            
            builder.Entity<OfficialInformation>()
           .HasOne<Posting>(ad => ad.Posting)
           .WithMany(s => s.PresentPostingDetails)
           .HasForeignKey(ad => ad.PostingId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
           .HasOne<Posting>(ad => ad.Depposting)
           .WithMany(s => s.DepPostingDetails)
           .HasForeignKey(ad => ad.DepPostingId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
           .HasOne<PostingType>(ad => ad.PostingType)
           .WithMany(s => s.PresentPostingDetails)
           .HasForeignKey(ad => ad.PostingTypeId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
           .HasOne<PostingType>(ad => ad.DeppostingType)
           .WithMany(s => s.DepPostingDetails)
           .HasForeignKey(ad => ad.DeppostingTypeId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<PostResponsibility>(ad => ad.PostResponsibility)
            .WithMany(s => s.PresentPostingDetails)
            .HasForeignKey(ad => ad.PostResponsibilityId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<PromtionNature>(ad => ad.PromtionNature)
            .WithMany(s => s.PresentPostingDetails)
            .HasForeignKey(ad => ad.PromtionNatureId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<Rank>(ad => ad.PresentRank)
            .WithMany(s => s.PresentPostingDetails)
            .HasForeignKey(ad => ad.PresentRankId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<Rank>(ad => ad.JoiningRank)
            .WithMany(s => s.JoiningPostingDetails)
            .HasForeignKey(ad => ad.JoiningRankId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.OfficialInformation)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<JobCategory>(s => s.JobCategory)
            .WithMany(g => g.OfficialInformations)
            .HasForeignKey(s => s.JobCategoryId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<EmployeeType>(s => s.EmployeeType)
            .WithMany(g => g.OfficialInformations)
            .HasForeignKey(s => s.EmployeeTypeId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
            .HasOne<GradationType>(s => s.GradationType)
            .WithMany(g => g.OfficialInformations)
            .HasForeignKey(s => s.GradationTypeId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<OfficialInformation>()
             .HasOne<RecruitPromo>(s => s.RecruitPromo)
             .WithMany(g => g.OfficialInformations)
             .HasForeignKey(s => s.RecruitPromoId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

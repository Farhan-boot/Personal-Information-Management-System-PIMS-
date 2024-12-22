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
        public static void ConfigureEmployeePostingDetails(this ModelBuilder builder)
        {
            builder.Entity<EmployeePostingDetails>(ac =>
            {
                ac.ToTable("EmployeePostingDetails", "Employee");

                ac.Property(a => a.JoiningDate)
                .HasColumnName("JoiningDate")
                .HasColumnType("datetime2")
                .IsRequired(false);

                ac.Property(a => a.JoiningRankId)
                    .HasColumnType("bigint")
                    .IsRequired(false);

                ac.Property(a => a.OfficeEmail)
                    .IsRequired(false);

                ac.Property(a => a.OfficeType)
                .HasColumnName("OfficeType")
                .IsRequired(false);

                ac.Property(a => a.DesignationId)
                   .HasColumnType("bigint")
                   .IsRequired(false);

                ac.Property(a => a.GradationNumber)
                   .HasColumnName("GradationNumber")
                   .HasColumnType("nvarchar(100)")
                   .IsRequired(false);

               ac.Property(a => a.GradationTypeId)
                  .HasColumnType("bigint")
                  .IsRequired(false);

               ac.Property(a => a.EmployeeTypeId)
                 .HasColumnType("bigint")
                 .IsRequired(false);

               ac.Property(a => a.JobCategoryId)
                .HasColumnType("bigint")
                .IsRequired(false);

               ac.Property(a => a.JobCategoryId)
               .HasColumnType("bigint")
               .IsRequired(false);

               ac.Property(a => a.Section)
                  .HasColumnName("Section")
                  .HasColumnType("nvarchar(100)")
                  .IsRequired(false);

                ac.Property(a => a.GradationYear)
                 .HasColumnName("GradationYear")
                 .HasColumnType("nvarchar(100)")
                 .IsRequired(false);

               ac.Property(a => a.JobPermanentDate)
                .HasColumnName("JobPermanentDate")
                .HasColumnType("datetime2")
                .IsRequired(false);

               ac.Property(a => a.SectionAt)
                .HasColumnName("SectionAt")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);

             ac.Property(a => a.PRLDate)
               .HasColumnName("PRLDate")
               .HasColumnType("datetime2")
               .IsRequired(false);

             ac.Property(a => a.Batch)
              .HasColumnName("Batch")
              .HasColumnType("nvarchar(100)")
              .IsRequired(false);

             ac.Property(a => a.CadreId)
               .HasColumnName("CadreId")
               .HasColumnType("int")
               .IsRequired();

             ac.Property(a => a.OrderNumber)
             .HasColumnName("OrderNumber")
             .HasColumnType("nvarchar(100)")
             .IsRequired(false);

            ac.Property(a => a.OrderDate)
             .HasColumnName("OrderDate")
             .HasColumnType("datetime2")
             .IsRequired(false);


           ac.Property(a => a.Remarks)
            .HasColumnName("Remarks")
            .HasColumnType("nvarchar(100)")
            .IsRequired(false);

           ac.Property(a => a.PostingDetailsId)
             .HasColumnName("PostingDetailsId")
             .HasColumnType("int")
             .IsRequired();

            });
            builder.Entity<EmployeePostingDetails>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<EmployeePostingDetails>()
           .HasOne<DesignationClass>(ad => ad.DesignationClass)
           .WithMany(s => s.EmployeePostingDetails)
           .HasForeignKey(ad => ad.DesignationClassId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<EmployeePostingDetails>()
           .HasOne<Designation>(ad => ad.Designation)
           .WithMany(s => s.EmployeePostingDetails)
           .HasForeignKey(ad => ad.DesignationTypeId).OnDelete(DeleteBehavior.ClientCascade);

           builder.Entity<EmployeePostingDetails>()
          .HasOne<PostingType>(ad => ad.PostingType)
          .WithMany(s => s.EmployeePostingDetails)
          .HasForeignKey(ad => ad.PostingTypeId).OnDelete(DeleteBehavior.ClientCascade);

         builder.Entity<EmployeePostingDetails>()
         .HasOne<PostingType>(ad => ad.PostingType)
         .WithMany(s => s.EmployeePostingDetails)
         .HasForeignKey(ad => ad.PostingTypeId).OnDelete(DeleteBehavior.ClientCascade);

         builder.Entity<EmployeePostingDetails>()
           .HasOne<Posting>(ad => ad.Posting)
           .WithMany(s => s.EmployeePostingDetails)
           .HasForeignKey(ad => ad.PostingId).OnDelete(DeleteBehavior.ClientCascade);

          builder.Entity<EmployeePostingDetails>()
              .HasOne<PostResponsibility>(ad => ad.PostResponsibility)
              .WithMany(s => s.EmployeePostingDetails)
              .HasForeignKey(ad => ad.PostResponsibilityId).OnDelete(DeleteBehavior.ClientCascade);

          builder.Entity<EmployeePostingDetails>()
             .HasOne<RecruitPromo>(ad => ad.RecruitPromo)
             .WithMany(s => s.EmployeePostingDetails)
             .HasForeignKey(ad => ad.RecruitPromoId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<EmployeePostingDetails>()
               .HasOne<RecruitPromo>(ad => ad.RecruitPromo)
               .WithMany(s => s.EmployeePostingDetails)
               .HasForeignKey(ad => ad.RecruitPromoId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<EmployeePostingDetails>()
              .HasOne<PromtionNature>(ad => ad.PromtionNature)
              .WithMany(s => s.EmployeePostingDetails)
              .HasForeignKey(ad => ad.PromtionNatureId).OnDelete(DeleteBehavior.ClientCascade);


         builder.Entity<EmployeePostingDetails>()
            .HasOne<PromtionNature>(ad => ad.PromtionNature)
             .WithMany(s => s.EmployeePostingDetails)
             .HasForeignKey(ad => ad.PromtionNatureId).OnDelete(DeleteBehavior.ClientCascade);

         builder.Entity<EmployeePostingDetails>()
         .HasOne<PostingType>(ad => ad.PostingType)
         .WithMany(s => s.EmployeePostingDetails)
         .HasForeignKey(ad => ad.PostingTypeId).OnDelete(DeleteBehavior.ClientCascade);


         builder.Entity<EmployeePostingDetails>()
            .HasOne<EmployeeType>(ad => ad.EmployeeType)
            .WithMany(s => s.EmployeePostingDetails)
            .HasForeignKey(ad => ad.EmployeeTypeId).OnDelete(DeleteBehavior.ClientCascade);


        }
    }
}

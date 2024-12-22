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
        public static void ConfigurePostingRecords(this ModelBuilder builder)
        {
            builder.Entity<PostingRecords>(ac =>
            {
                ac.ToTable("PostingRecords", "Employee");

                ac.Property(a => a.RankId)
                .HasColumnName("RankId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.DesignationClassId)
                .HasColumnName("DesignationClassId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.DesignationId)
                .HasColumnName("DesignationId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.PostResponsibilityId)
                .HasColumnName("PostResponsibilityId")
                .HasColumnType("bigint")
                .IsRequired(false);
                //ac.Property(a => a.MainPostingPlace)
                //.HasColumnName("MainPostingPlace")
                //.HasColumnType("nvarchar(100)")
                //.IsRequired();
                ac.Property(a => a.MainPostingTypeId)
                .HasColumnName("MainPostingTypeId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.PostingId)
                .HasColumnName("PostingId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.Section)
                .HasColumnName("Section")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.PeriodFrom)
                .HasColumnName("PeriodFrom")
                .HasColumnType("datetime2")
                .IsRequired(false);
                ac.Property(a => a.PeriodTo)
                .HasColumnName("PeriodTo")
                .HasColumnType("datetime2")
                .IsRequired(false);
                ac.Property(a => a.IfEmployeeContinuing)
                .HasColumnName("IfEmployeeContinuing")
                .HasColumnType("bit")
                .IsRequired();
                ac.Property(a => a.WorkingAsId)
                .HasColumnName("WorkingAsId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.CurrDesignationClassId)
                .HasColumnName("CurrDesignationClassId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.CrntDesgId)
                .HasColumnName("CrntDesgId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.DeppostingTypeId)
                .HasColumnName("DeppostingTypeId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.DepPostingId)
                .HasColumnName("DepPostingId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.AttachSection)
                .HasColumnName("AttachSection")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.EmployeeInformationId)
                .HasColumnName("EmployeeInformationId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.TransferFromDivisionId)
                .HasColumnName("TransferFromDivisionId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.TransferToDivisionId)
                .HasColumnName("TransferToDivisionId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.TransferFromDistrictId)
                .HasColumnName("TransferFromDistrictId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.TransferToDistrictId)
                .HasColumnName("TransferToDistrictId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.MemoNo)
                .HasColumnName("MemoNo")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.UploadFiles)
                .HasColumnName("UploadFiles")
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);
                ac.Property(a => a.EmployeeTransferId)
                .HasColumnName("EmployeeTransferId")
                .HasColumnType("bigint")
                .IsRequired(false);

            });
            builder.Entity<PostingRecords>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<PostingRecords>()
            .HasOne<Designation>(ad => ad.Designation)
            .WithMany(s => s.PostingRecords)
            .HasForeignKey(ad => ad.DesignationId).OnDelete(DeleteBehavior.ClientCascade);//.OnDelete(DeleteBehavior.Restrict); 


            builder.Entity<PostingRecords>()
            .HasOne<DesignationClass>(ad => ad.DesignationClass)
            .WithMany(s => s.PostingRecords)
            .HasForeignKey(ad => ad.DesignationClassId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
           .HasOne<Designation>(ad => ad.CrntDesg)
           .WithMany(s => s.CrntPostingRecords)
           .HasForeignKey(ad => ad.CrntDesgId);//.OnDelete(DeleteBehavior.Restrict);


            builder.Entity<PostingRecords>()
            .HasOne<DesignationClass>(ad => ad.CurrDesignationClass)
            .WithMany(s => s.CurrPostingRecords)
            .HasForeignKey(ad => ad.CurrDesignationClassId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
            .HasOne<PostingType>(ad => ad.MainPostingType)
            .WithMany(s => s.MainPostingRecords)
            .HasForeignKey(ad => ad.MainPostingTypeId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
            .HasOne<PostingType>(ad => ad.DeppostingType)
            .WithMany(s => s.DepPostingRecords)
            .HasForeignKey(ad => ad.DeppostingTypeId).OnDelete(DeleteBehavior.ClientCascade);



            builder.Entity<PostingRecords>()
            .HasOne<Posting>(ad => ad.Posting)
            .WithMany(s => s.PostingRecords)
            .HasForeignKey(ad => ad.PostingId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
            .HasOne<Posting>(ad => ad.DepPosting)
            .WithMany(s => s.DepPostingRecords)
            .HasForeignKey(ad => ad.DepPostingId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
            .HasOne<PostResponsibility>(ad => ad.PostResponsibility)
            .WithMany(s => s.PostingRecords)
            .HasForeignKey(ad => ad.PostResponsibilityId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
            .HasOne<Rank>(ad => ad.Rank)
            .WithMany(s => s.PostingRecords)
            .HasForeignKey(ad => ad.RankId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.PostingRecords)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
            .HasOne<Division>(s => s.TransferFromDivision)
            .WithMany(g => g.TransferFromPostingRecords)
            .HasForeignKey(s => s.TransferFromDivisionId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
            .HasOne<Division>(s => s.TransferToDivision)
            .WithMany(g => g.TransferToPostingRecords)
            .HasForeignKey(s => s.TransferToDivisionId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
            .HasOne<District>(s => s.TransferFromDistrict)
            .WithMany(g => g.TransferFromPostingRecords)
            .HasForeignKey(s => s.TransferFromDistrictId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<PostingRecords>()
            .HasOne<District>(s => s.TransferToDistrict)
            .WithMany(g => g.TransferToPostingRecords)
            .HasForeignKey(s => s.TransferToDistrictId).OnDelete(DeleteBehavior.ClientCascade);

             
            builder.Entity<EmployeeTransfer>()   //one to one relationship
            .HasOne<PostingRecords>(s => s.PostingRecords)
            .WithOne(ad => ad.EmployeeTransfer)
            .HasForeignKey<PostingRecords>(ad => ad.EmployeeTransferId).OnDelete(DeleteBehavior.ClientCascade);

        }

    }
}

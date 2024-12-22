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
        public static void ConfigureEmployeeTransfer(this ModelBuilder builder)
        {
            builder.Entity<EmployeeTransfer>(ac =>
            {
                ac.ToTable("EmployeeTransfer", "Employee");

                ac.Property(a => a.MainPostingTypeId)
                .HasColumnName("PostingTypeId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.PostingId)
                .HasColumnName("PostingId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.EmployeeInformationId)
                .HasColumnName("EmployeeInformationId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.IsPostingCompleted)
                .HasColumnName("IsPostingCompleted")
                .HasColumnType("bit")
                .IsRequired();
                ac.Property(a => a.PostingDate)
                .HasColumnName("PostingDate")
                .HasColumnType("datetime2")
                .IsRequired(false);
            });
            builder.Entity<EmployeeTransfer>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<EmployeeTransfer>()
            .HasOne<Posting>(ad => ad.Posting)
            .WithMany(s => s.EmployeeTransfer)
            .HasForeignKey(ad => ad.PostingId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<EmployeeTransfer>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.EmployeeTransfers)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<EmployeeTransfer>()
           .HasOne<PostingType>(ad => ad.MainPostingType)
           .WithMany(s => s.EmployeeTransfer)
           .HasForeignKey(ad => ad.MainPostingTypeId).OnDelete(DeleteBehavior.ClientCascade);

        }

    }
}

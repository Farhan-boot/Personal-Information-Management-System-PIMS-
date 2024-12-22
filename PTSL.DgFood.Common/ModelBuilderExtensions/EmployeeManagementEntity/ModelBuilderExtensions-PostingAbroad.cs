using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigurePostingAbroad(this ModelBuilder builder)
        {
            builder.Entity<PostingAbroad>(ac =>
            {
            ac.ToTable("PostingAbroad", "Employee");

            ac.Property(a => a.Post)
            .HasColumnName("Post")
            .HasColumnType("nvarchar(250)")
            .IsRequired(false);
             ac.Property(a => a.Organization)
            .HasColumnName("Organization")
            .HasColumnType("nvarchar(250)")
            .IsRequired(false);
             ac.Property(a => a.StartDate)
            .HasColumnName("StartDate")
            .HasColumnType("datetime2")
            .IsRequired();
             ac.Property(a => a.EndDate)
            .HasColumnName("EndDate")
            .HasColumnType("datetime2")
            .IsRequired();
            ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationId")
            .HasColumnType("bigint")
            .IsRequired(); 
             });

            builder.Entity<PostingAbroad>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<PostingAbroad>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.PostingAbroads)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

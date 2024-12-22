using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureLanguageInformation(this ModelBuilder builder)
        {
            builder.Entity<LanguageInformation>(ac =>
            {
                ac.ToTable("LanguageInformation", "Employee");

            ac.Property(a => a.LanguageId)
            .HasColumnName("LanguageId")
            .HasColumnType("bigint")
            .IsRequired();
             ac.Property(a => a.Listening)
            .HasColumnName("Listening")
            .HasColumnType("nvarchar(100)")
            .IsRequired();
             ac.Property(a => a.Reading)
            .HasColumnName("Reading")
            .HasColumnType("nvarchar(100)")
            .IsRequired();
            ac.Property(a => a.Writing)
            .HasColumnName("Writing")
            .HasColumnType("nvarchar(100)")
            .IsRequired();
            ac.Property(a => a.Comments)
            .HasColumnName("Comments")
            .HasColumnType("nvarchar(max)")
            .IsRequired(false);
            ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationId")
            .HasColumnType("bigint")
            .IsRequired();

            });
            builder.Entity<LanguageInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<LanguageInformation>()
            .HasOne<Language>(s => s.Language)
            .WithMany(g => g.LanguageInformation)
            .HasForeignKey(s => s.LanguageId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<LanguageInformation>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.LanguageInformations)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

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
        public static void ConfigureDisciplinaryActionsAndCriminalProsecution(this ModelBuilder builder)
        {
            builder.Entity<DisciplinaryActionsAndCriminalProsecution>(ac =>
            {
                ac.ToTable("DisciplinaryActionsAndCriminalProsecution", "Employee");

                ac.Property(a => a.CategoryId)
                .HasColumnName("CategoryId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(max)")
                .IsRequired();
                ac.Property(a => a.PresentStatusId)
                .HasColumnName("PresentStatusId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.Judgement)
                .HasColumnName("Judgement")
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);
                ac.Property(a => a.FinalJudgement)
                .HasColumnName("FinalJudgement")
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);
                ac.Property(a => a.Remark)
                    .HasColumnName("Remark")
                    .HasColumnType("nvarchar(max)")
                    .IsRequired(false);
                ac.Property(a => a.Document)
                    .HasColumnType("nvarchar(1000)")
                    .IsRequired(false);
                ac.Property(a => a.EmployeeInformationId)
                .HasColumnName("EmployeeInformationId")
                .HasColumnType("bigint")
                .IsRequired();  
           });
            builder.Entity<DisciplinaryActionsAndCriminalProsecution>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<DisciplinaryActionsAndCriminalProsecution>()
            .HasOne<Category>(ad => ad.Category)
            .WithMany(s => s.DisciplinaryActionsAndCriminalProsecution)
            .HasForeignKey(ad => ad.CategoryId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<DisciplinaryActionsAndCriminalProsecution>()
            .HasOne<PresentStatus>(ad => ad.PresentStatus)
            .WithMany(s => s.DisciplinaryActionsAndCriminalProsecution)
            .HasForeignKey(ad => ad.PresentStatusId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<DisciplinaryActionsAndCriminalProsecution>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.DisciplinaryActionsAndCriminalProsecutions)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<DisciplinaryActionsAndCriminalProsecution>()
            .HasOne<Category>(ad => ad.Category)
            .WithMany(s => s.DisciplinaryActionsAndCriminalProsecution)
            .HasForeignKey(ad => ad.CategoryId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<DisciplinaryActionsAndCriminalProsecution>()
            .HasOne<PresentStatus>(ad => ad.PresentStatus)
            .WithMany(s => s.DisciplinaryActionsAndCriminalProsecution)
            .HasForeignKey(ad => ad.PresentStatusId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

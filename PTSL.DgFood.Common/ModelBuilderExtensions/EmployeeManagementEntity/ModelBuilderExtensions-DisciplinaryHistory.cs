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
        public static void ConfigureDisciplinaryHistory(this ModelBuilder builder)
        {
            builder.Entity<DisciplinaryHistory>(ac =>
            {
                ac.ToTable("DisciplinaryHistory", "Employee");
                
                ac.Property(a => a.DisciplinaryAndCriminalId)
                .HasColumnName("DisciplinaryAndCriminalId")
                .HasColumnType("bigint")
                .IsRequired();

                ac.Property(a => a.PresentStatusId)
                .HasColumnName("PresentStatusId")
                .HasColumnType("bigint")
                .IsRequired();

                ac.Property(a => a.SubmissonDate)
                 .HasColumnName("SubmissonDate")
                 .HasColumnType("nvarchar(1000)")
                 .IsRequired();
            });

            builder.Entity<DisciplinaryHistory>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<DisciplinaryHistory>()
             .HasOne<PresentStatus>(s => s.PresentStatus)
             .WithMany(g => g.DisciplinaryHistories)
             .HasForeignKey(s => s.PresentStatusId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<DisciplinaryHistory>()
            .HasOne<DisciplinaryActionsAndCriminalProsecution>(s => s.DisciplinaryAndCriminal)
            .WithMany(g => g.DisciplinaryHistories)
            .HasForeignKey(s => s.DisciplinaryAndCriminalId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureLeaveTypeInformation(this ModelBuilder builder)
        {
            builder.Entity<LeaveTypeInformation>(ac =>
            {
                ac.ToTable("LeaveTypeInformation", "GS");

                ac.Property(a => a.NameInBangla)
                    .HasColumnName("NameInBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.NameInEnglish)
                    .HasColumnName("NameInEnglish")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.CalculationMethodId)
                    .HasColumnName("CalculationMethodId")
                    .HasColumnType("bigint")
                    .IsRequired();
                ac.Property(a => a.EligibleFor)
                    .HasColumnName("EligibleFor")
                    .HasColumnType("int")
                    .IsRequired();
                ac.Property(a => a.MaxDaysPerYear)
                    .HasColumnName("MaxDaysPerYear")
                    .HasColumnType("int")
                    .IsRequired();
                ac.Property(a => a.LeaveRestriction)
                    .HasColumnName("LeaveRestriction")
                    .HasColumnType("int")
                    .IsRequired();
                ac.Property(a => a.LeaveLimit)
                    .HasColumnName("LeaveLimit")
                    .HasColumnType("int")
                    .IsRequired();
                ac.Property(a => a.ApplicationWithIn)
                    .HasColumnName("ApplicationWithIn")
                    .HasColumnType("int")
                    .IsRequired();

            });
            builder.Entity<LeaveTypeInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<LeaveTypeInformation>()
             .HasOne<CalculationMethod>(s => s.CalculationMethod)
             .WithMany(g => g.LeaveTypeInformations)
             .HasForeignKey(s => s.CalculationMethodId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

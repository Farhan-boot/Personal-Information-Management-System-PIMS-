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
        public static void ConfigureServiceHistory(this ModelBuilder builder)
        {
            builder.Entity<ServiceHistory>(ac =>
            {
                ac.ToTable("ServiceHistory", "Employee");

                ac.Property(a => a.DateOfGovtService)
                .HasColumnName("DateOfGovtService")
                .HasColumnType("datetime2")
                .IsRequired();
                ac.Property(a => a.DateOfGazetted)
                .HasColumnName("DateOfGazetted")
                .HasColumnType("datetime2")
                .IsRequired(false);
                ac.Property(a => a.EncadrementNumber)
                .HasColumnName("EncadrementNumber")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.EncadrementDate)
                .HasColumnName("EncadrementDate")
                .HasColumnType("datetime")
                .IsRequired(false);
                ac.Property(a => a.NationalSeniority)
                .HasColumnName("NationalSeniority")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.CadreId)
                .HasColumnName("CadreId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.EmployeeInformationId)
                .HasColumnName("EmployeeInformationId")
                .HasColumnType("bigint")
                .IsRequired();
            });
            builder.Entity<ServiceHistory>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<ServiceHistory>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.ServiceHistories)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

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
        public static void ConfigureOtherServiceInfo(this ModelBuilder builder)
        {
            builder.Entity<OtherServiceInfo>(ac =>
            {
            ac.ToTable("OtherServiceInfo", "Employee");

            ac.Property(a => a.EmployerName)
            .HasColumnName("EmployerName")
            .HasColumnType("nvarchar(250)")
            .IsRequired(false);
             ac.Property(a => a.EmpAddress)
            .HasColumnName("EmpAddress")
            .HasColumnType("nvarchar(max)")
            .IsRequired(false);
             ac.Property(a => a.OtherServiceType)
            .HasColumnName("OtherServiceType")
            .HasColumnType("nvarchar(250)")
            .IsRequired(false);
            ac.Property(a => a.Position)
           .HasColumnName("Position")
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

            builder.Entity<OtherServiceInfo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<OtherServiceInfo>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.OtherServiceInfos)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

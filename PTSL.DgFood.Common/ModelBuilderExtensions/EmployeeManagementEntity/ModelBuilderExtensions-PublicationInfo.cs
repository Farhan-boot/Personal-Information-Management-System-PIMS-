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
        public static void ConfigurePublicationInfo(this ModelBuilder builder)
        {
            builder.Entity<PublicationInfo>(ac =>
            {
            ac.ToTable("PublicationInfo", "Employee");

            ac.Property(a => a.PublicationType)
            .HasColumnName("PublicationType")
            .HasColumnType("nvarchar(250)")
            .IsRequired(false);
             ac.Property(a => a.PublicationName)
            .HasColumnName("PublicationName")
            .HasColumnType("nvarchar(250)")
            .IsRequired(false);
             ac.Property(a => a.PublicationDate)
            .HasColumnName("PublicationDate")
            .HasColumnType("datetime2")
            .IsRequired();
            ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationId")
            .HasColumnType("bigint")
            .IsRequired(); 
             });

            builder.Entity<PublicationInfo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<PublicationInfo>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.PublicationInfos)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

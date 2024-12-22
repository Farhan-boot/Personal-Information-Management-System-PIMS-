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
        public static void ConfigureChildrenInformation(this ModelBuilder builder)
        {
            builder.Entity<ChildrenInformation>(ac =>
            {
                ac.ToTable("ChildrenInformation", "Employee");

            ac.Property(a => a.SlNo)
            .HasColumnName("SlNo")
            .HasColumnType("int")
            .IsRequired();
             ac.Property(a => a.NameInEnglish)
            .HasColumnName("NameInEnglish")
            .HasColumnType("nvarchar(100)")
            .IsRequired();
             ac.Property(a => a.NameInBangla)
            .HasColumnName("NameInBangla")
            .HasColumnType("nvarchar(100)")
            .IsRequired();
            ac.Property(a => a.GenderId)
            .HasColumnName("GenderId")
            .HasColumnType("bigint")
            .IsRequired();
            ac.Property(a => a.DateOfBirth)
            .HasColumnName("DateOfBirth")
            .HasColumnType("datetime2")
            .IsRequired();
            ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationId")
            .HasColumnType("bigint")
            .IsRequired(); 
             });
            builder.Entity<ChildrenInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<ChildrenInformation>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.ChildrenInformation)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

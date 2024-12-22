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
        public static void ConfigurePRL(this ModelBuilder builder)
        {
            builder.Entity<PRL>(ac =>
            {
                ac.ToTable("PRL", "Employee");

            ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationdId")
            .HasColumnType("bigint")
            .IsRequired();

            ac.Property(a => a.MessageSubject)
            .HasColumnName("MessageSubject")
            .HasColumnType("nvarchar(200)")
            .IsRequired();

            ac.Property(a => a.MessageBody)
            .HasColumnName("MessageBody")
            .HasColumnType("nvarchar(MAX)")
            .IsRequired();

            ac.Property(a => a.NoticeDate)
            .HasColumnName("NoticeDate")
            .IsRequired();

            ac.Property(a => a.NoticeBy)
            .HasColumnName("NoticeBy")
            .HasColumnType("bigint")
            .IsRequired();

            ac.Property(a => a.IsEmail)
            .HasColumnName("IsEmail")
            .HasColumnType("bit")
            .IsRequired();

            ac.Property(a => a.IsSMS)
            .HasColumnName("IsSMS")
            .HasColumnType("bit")
            .IsRequired();
            });

            builder.Entity<PRL>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<PRL>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.PRLData)
            .HasForeignKey(e => e.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
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
        public static void ConfigureLeaveApplication(this ModelBuilder builder)
        {
            builder.Entity<LeaveApplication>(ac =>
            {
            ac.ToTable("LeaveApplication", "Employee");

            ac.Property(a => a.LeaveTypeInformationId)
            .HasColumnName("LeaveTypeInformationId")
            .HasColumnType("bigint")
            .IsRequired(false);
             ac.Property(a => a.ApplicationDate)
            .HasColumnName("ApplicationDate")
            .HasColumnType("datetime2")
            .IsRequired(false);
             ac.Property(a => a.FromDate)
            .HasColumnName("FromDate")
            .HasColumnType("datetime2")
            .IsRequired(false);
            ac.Property(a => a.ToDate)
            .HasColumnName("ToDate")
            .HasColumnType("datetime2")
            .IsRequired(false);      
             ac.Property(a => a.ApprovedDate)
            .HasColumnName("ApprovedDate")
            .HasColumnType("datetime2")
            .IsRequired(false);
             ac.Property(a => a.CancelledDate)
            .HasColumnName("CancelledDate")
            .HasColumnType("datetime2")
            .IsRequired(false);
            ac.Property(a => a.LeaveAuthority)
            .HasColumnName("LeaveAuthority")
            .HasColumnType("nvarchar(100)")
            .IsRequired(false);
             ac.Property(a => a.LeaveSubject)
            .HasColumnName("LeaveSubject")
            .HasColumnType("nvarchar(100)")
            .IsRequired(false);
            ac.Property(a => a.MemoNO)
            .HasColumnName("MemoNO")
            .HasColumnType("nvarchar(100)")
            .IsRequired(false);
            ac.Property(a => a.LeaveReason)
            .HasColumnName("LeaveReason")
            .HasColumnType("nvarchar(100)")
            .IsRequired(false);
            ac.Property(a => a.EmergencyContact)
            .HasColumnName("EmergencyContact")
            .HasColumnType("nvarchar(20)")
            .IsRequired(false);
            ac.Property(a => a.EmergencyAddress)
            .HasColumnName("EmergencyAddress")
            .HasColumnType("nvarchar(200)")
            .IsRequired(false);
            ac.Property(a => a.Comments)
            .HasColumnName("Comments")
            .HasColumnType("nvarchar(max)")
            .IsRequired(false);
            ac.Property(a => a.IsHeadOfOffice)
            .HasColumnName("IsHeadOfOffice")
            .HasColumnType("bit")
            .IsRequired();
            ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationId")
            .HasColumnType("bigint")
            .IsRequired();
             ac.Property(a => a.LeaveDays)
            .HasColumnName("LeaveDays")
            .HasColumnType("int")
            .IsRequired(false);
             ac.Property(a => a.LeaveStatus)
            .HasColumnName("LeaveStatus")
            .HasColumnType("int")
            .IsRequired();
            });
            builder.Entity<LeaveApplication>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<LeaveApplication>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.LeaveApplications)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<LeaveApplication>()
            .HasOne<LeaveTypeInformation>(s => s.LeaveTypeInformation)
            .WithMany(g => g.LeaveApplications)
            .HasForeignKey(s => s.LeaveTypeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

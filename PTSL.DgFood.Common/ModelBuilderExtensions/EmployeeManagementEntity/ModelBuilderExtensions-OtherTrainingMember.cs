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
        public static void ConfigureOtherTrainingMember(this ModelBuilder builder)
        {
            builder.Entity<OtherTrainingMember>(ac =>
            {
             ac.ToTable("OtherTrainingMember", "Employee");

             ac.Property(a => a.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(500)")
                .IsRequired(false);
             ac.Property(a => a.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar(500)")
                .IsRequired(false);
             ac.Property(a => a.Phone)
               .HasColumnName("Phone")
               .HasColumnType("nvarchar(500)")
               .IsRequired(false);
             ac.Property(a => a.AddressOrWorkplace)
               .HasColumnName("AddressOrWorkplace")
               .HasColumnType("nvarchar(500)")
               .IsRequired(false);
             ac.Property(a => a.GenderId)
               .HasColumnName("GenderId")
               .HasColumnType("bigint")
               .IsRequired(false);
             ac.Property(a => a.TrainingManagementTypeId)
               .HasColumnName("TrainingManagementTypeId")
               .HasColumnType("bigint")
               .IsRequired(false);
            });
            builder.Entity<OtherTrainingMember>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
            builder.Entity<OtherTrainingMember>()
                .HasOne<TrainingManagementType>(ad => ad.TrainingManagementType)
                .WithMany(s => s.OtherTrainingMembers)
                .HasForeignKey(ad => ad.TrainingManagementTypeId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

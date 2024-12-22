using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureUser(this ModelBuilder builder)
        {
            builder.Entity<User>(ac =>
            {
                ac.ToTable("User", "System");

                ac.Property(a => a.UserName)
                    .HasColumnName("UserName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();

                ac.Property(a => a.UserEmail)
                    .HasColumnName("UserEmail")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired();

                ac.Property(a => a.UserPassword)
                    .HasColumnName("UserPassword")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();

                ac.Property(a => a.UserPhone)
                   .HasColumnName("UserPhone")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired(false);

                ac.Property(a => a.UserGroup)
                   .HasColumnName("UserGroup")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired(false);

                ac.Property(a => a.UserStatus)
                   .HasColumnName("UserStatus")
                   .HasColumnType("bit")
                   .IsRequired();

                ac.Property(a => a.GroupID)
                  .HasColumnName("GroupID")
                  .HasColumnType("bigint")
                  .IsRequired(false);

                ac.Property(a => a.RoleName)
                  .HasColumnName("RoleName")
                  .HasColumnType("nvarchar(50)")
                  .IsRequired(false);

				ac.Property(a => a.EmployeeInformationId)
				  .HasColumnName("EmployeeInformationId")
				  .HasColumnType("bigint")
				  .IsRequired(false);

			});

            builder.Entity<User>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<User>()
            .HasOne<UserGroup>(s => s.Group)
            .WithMany(g => g.Users)
			.HasForeignKey(s => s.GroupID);

			builder.Entity<User>()
			.HasOne<EmployeeInformation>(s => s.EmployeeInformation)
			.WithOne(g => g.User)
			.HasForeignKey<User>(ad => ad.EmployeeInformationId).OnDelete(DeleteBehavior.NoAction);

			//builder.Entity<User>()
			//.HasOne<UserRoles>(s => s.UserRoles)
			//.WithMany(g => g.Users)
			//.HasForeignKey(s => s.rol);
		}

    }
}

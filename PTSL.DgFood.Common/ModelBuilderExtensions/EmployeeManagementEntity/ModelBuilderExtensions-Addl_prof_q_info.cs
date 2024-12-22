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
        public static void ConfigureAddl_prof_q_info(this ModelBuilder builder)
        {
            builder.Entity<Addl_prof_q_info>(ac =>
            {
            ac.ToTable("Addl_prof_q_info", "Employee");

            ac.Property(a => a.Description)
            .HasColumnName("Description")
            .HasColumnType("nvarchar(500)")
            .IsRequired(false);
            ac.Property(a => a.EmployeeInformationId)
            .HasColumnName("EmployeeInformationId")
            .HasColumnType("bigint")
            .IsRequired(); 
             });

            builder.Entity<Addl_prof_q_info>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<Addl_prof_q_info>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.Addl_prof_q_infos)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

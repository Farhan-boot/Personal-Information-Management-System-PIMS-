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
        public static void ConfigureRecruitPromo(this ModelBuilder builder)
        {
            builder.Entity<RecruitPromo>(ac =>
            {
                ac.ToTable("RecruitPromo", "GS");

                ac.Property(a => a.RecruitPromoEnglish)
                    .HasColumnName("RecruitPromoEnglish")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.RecruitPromoBangla)
                    .HasColumnName("RecruitPromoBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);
                 
            });
            builder.Entity<RecruitPromo>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

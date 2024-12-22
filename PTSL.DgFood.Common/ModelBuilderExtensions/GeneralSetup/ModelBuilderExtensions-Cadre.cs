using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCadre(this ModelBuilder builder)
        {
            builder.Entity<Cadre>(ac =>
            {
                ac.ToTable("Cadre", "GS");

                ac.Property(a => a.CadreNameEnglish)
                    .HasColumnName("CadreNameEnglish")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.CadreNameBangla)
                    .HasColumnName("CadreNameBangla")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.ClassType)
                    .HasColumnName("ClassType")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired(false);
            });
            builder.Entity<Cadre>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

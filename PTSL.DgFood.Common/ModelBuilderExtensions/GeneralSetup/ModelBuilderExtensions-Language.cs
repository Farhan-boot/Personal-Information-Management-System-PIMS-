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
        public static void ConfigureLanguage(this ModelBuilder builder)
        {
            builder.Entity<Language>(ac =>
            {
                ac.ToTable("Language", "GS");

                ac.Property(a => a.LanguageName)
                    .HasColumnName("LanguageName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<Language>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

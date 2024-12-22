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
        public static void ConfigureDesignationClass(this ModelBuilder builder)
        {
            builder.Entity<DesignationClass>(ac =>
            {
                ac.ToTable("DesignationClass", "GS");

                ac.Property(a => a.DesignationClassName)
                    .HasColumnName("DesignationClassName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<DesignationClass>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            //builder.Entity<DesignationClass>()
            //.HasOne<Designation>(s => s.Designations)
            //.WithMany(g => g.DesignationClasses)
            //.HasForeignKey(s => s.id);
        }

    }
}

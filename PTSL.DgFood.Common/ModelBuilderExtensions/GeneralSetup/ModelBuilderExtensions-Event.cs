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
        public static void ConfigureEvent(this ModelBuilder builder)
        {
            builder.Entity<Event>(ac =>
            {
                ac.ToTable("Event", "GS");

                ac.Property(a => a.EventName)
                    .HasColumnName("EventName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
            });
            builder.Entity<Event>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
        }

    }
}

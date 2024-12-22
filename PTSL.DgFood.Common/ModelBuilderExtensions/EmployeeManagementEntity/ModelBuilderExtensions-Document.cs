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
        public static void ConfigureDocument(this ModelBuilder builder)
        {
            builder.Entity<Document>(ac =>
            {
                ac.ToTable("Document", "Employee");
                
                ac.Property(a => a.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(200)")
                .IsRequired();

                ac.Property(a => a.DisciplinaryHistoryId)
                .HasColumnName("DisciplinaryHistoryId")
                .HasColumnType("bigint")
                .IsRequired();
            });

            builder.Entity<Document>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<Document>()
             .HasOne<DisciplinaryHistory>(s => s.DisciplinaryHistory)
             .WithMany(g => g.Documents)
             .HasForeignKey(s => s.DisciplinaryHistoryId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
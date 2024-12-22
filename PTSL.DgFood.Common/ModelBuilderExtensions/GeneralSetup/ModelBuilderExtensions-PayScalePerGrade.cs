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
        public static void ConfigurePayScalePerGrade(this ModelBuilder builder)
        {
            builder.Entity<PayScalePerGrade>(ac =>
            {
                ac.ToTable("PayScalePerGrade", "GS");

                ac.Property(a => a.ScaleYear)
                    .HasColumnName("ScaleYear")
                    .HasColumnType("int")
                    .IsRequired();
                ac.Property(a => a.ScaleOfPay)
                    .HasColumnName("ScaleOfPay")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired(false);
                ac.Property(a => a.basic_pay)
                    .HasColumnName("basic_pay")
                    .HasColumnType("decimal")
                    .IsRequired();
                ac.Property(a => a.RankId)
                    .HasColumnName("RankId")
                    .HasColumnType("bigint")
                    .IsRequired();
            });
            builder.Entity<PayScalePerGrade>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<PayScalePerGrade>()
            .HasOne<Rank>(s => s.Rank)
            .WithMany(g => g.PayScalePerGrades)
            .HasForeignKey(s => s.RankId).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

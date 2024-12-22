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
        public static void ConfigurePosting(this ModelBuilder builder)
        {
            builder.Entity<Posting>(ac =>
            {
                ac.ToTable("Posting", "GS");

                ac.Property(a => a.PostingName)
                    .HasColumnName("PostingName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();
                ac.Property(a => a.PostingNameBangla)
                   .HasColumnName("PostingNameBangla")
                   .HasColumnType("nvarchar(100)")
                   .IsRequired(false);
                ac.Property(a => a.DivisionId)
                   .HasColumnName("DivisionId")
                   .HasColumnType("bigint")
                   .IsRequired(false);
                ac.Property(a => a.DistrictId)
                   .HasColumnName("DistrictId")
                   .HasColumnType("bigint")
                   .IsRequired(false);
                ac.Property(a => a.ThanaId)
                   .HasColumnName("ThanaId")
                   .HasColumnType("bigint")
                   .IsRequired(false);

                ac.Property(a => a.PostingTypeId)
                    .HasColumnName("PostingTypeId")
                    .HasColumnType("bigint")
                    .IsRequired();
            });
            builder.Entity<Posting>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);

            builder.Entity<Posting>()
            .HasOne<PostingType>(s => s.PostingType)
            .WithMany(g => g.Postings)
            .HasForeignKey(s => s.PostingTypeId).OnDelete(DeleteBehavior.ClientCascade);


        }

    }
}

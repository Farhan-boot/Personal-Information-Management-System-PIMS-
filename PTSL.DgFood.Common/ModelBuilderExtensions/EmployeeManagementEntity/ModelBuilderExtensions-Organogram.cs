using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureOrganogram(this ModelBuilder builder)
        {
            builder.Entity<Organogram>(ac =>
            {
                ac.ToTable("Organogram", "Employee");

                ac.Property(a => a.PostingTypeId)
                   .HasColumnName("PostingTypeId")
                   .HasColumnType("bigint")
                   .IsRequired(false);

                ac.Property(a => a.OrganogramOfficeType)
                   .HasColumnType("tinyint")
                   .IsRequired();
               // ac.Property(a => a.ParentPostingId)
               //.HasColumnName("ParentPostingId")
               //.HasColumnType("bigint")
               //.IsRequired();
                ac.Property(a => a.PostingId)
               .HasColumnName("PostingId")
               .HasColumnType("bigint")
               .IsRequired(false);
                ac.Property(a => a.DesignationID)
              .HasColumnName("DesignationID")
              .HasColumnType("bigint")
              .IsRequired(false);

                ac.Property(a => a.IsPermanent)
              .HasColumnName("IsPermanent")
              .IsRequired(false)
              .HasDefaultValue(null);

                ac.Property(a => a.TotalPost)
              .HasColumnName("TotalPost")
              .HasColumnType("int")
              .IsRequired();
                ac.Property(a => a.IsParent)
              .HasColumnName("IsParent")
              .HasColumnType("bit")
              .IsRequired();
                ac.Property(a => a.ParentId)
              .HasColumnName("ParentId")
              .HasColumnType("bigint")
              .IsRequired();
                ac.Property(a => a.Name)
              .HasColumnName("Name")
              .HasColumnType("nvarchar(500)")
              .IsRequired();
            });

            builder.Entity<Organogram>().HasQueryFilter(q => !q.IsDeleted && q.IsActive && (!q.NonPermanentDeadLine.HasValue || q.NonPermanentDeadLine.Value > DateTime.Now));

            builder.Entity<Organogram>()
            .HasOne<PostingType>(s => s.PostingType)
            .WithMany(g => g.Organograms)
            .HasForeignKey(s => s.PostingTypeId).OnDelete(DeleteBehavior.ClientCascade);

            //builder.Entity<Organogram>()
            //.HasOne<Posting>(s => s.ParentPosting)
            //.WithMany(g => g.ParentOrganograms)
            //.HasForeignKey(s => s.ParentPostingId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Organogram>()
            .HasOne<Posting>(s => s.Posting)
            .WithMany(g => g.Organograms)
            .HasForeignKey(s => s.PostingId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Organogram>()
            .HasOne<Designation>(s => s.Designation)
            .WithMany(g => g.Organograms)
            .HasForeignKey(s => s.DesignationID).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

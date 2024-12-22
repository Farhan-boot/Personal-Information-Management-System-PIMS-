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
        public static void ConfigureEducationalQualification(this ModelBuilder builder)
        {
            builder.Entity<EducationalQualification>(ac =>
            {
                ac.ToTable("EducationalQualification", "Employee");

                ac.Property(a => a.NameOfTheInstitute)
                .HasColumnName("NameOfTheInstitute")
                .HasColumnType("nvarchar(1000)")
                .IsRequired();
                ac.Property(a => a.PrincipalSubject)
                .HasColumnName("PrincipalSubject")
                .HasColumnType("nvarchar(1000)")
                .IsRequired(false);
                ac.Property(a => a.DegreeId)
                .HasColumnName("DegreeId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.PassingYear)
                .HasColumnName("PassingYear")
                .HasColumnType("nvarchar(10)")
                .IsRequired();
                ac.Property(a => a.ResultOrDivision)
                .HasColumnName("ResultOrDivision")
                .HasColumnType("nvarchar(50)")
                .IsRequired(false);
                ac.Property(a => a.GPAOrCGPA)
                .HasColumnName("GPAOrCGPA")
                .HasColumnType("nvarchar(50)")
                .IsRequired(false);
                ac.Property(a => a.Distinction)
                .HasColumnName("Distinction")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.EmployeeInformationId)
                .HasColumnName("EmployeeInformationId")
                .HasColumnType("bigint")
                .IsRequired();


            });
            builder.Entity<EducationalQualification>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            builder.Entity<EducationalQualification>()
            .HasOne<Degree>(ad => ad.Degree)
            .WithMany(s => s.EducationalQualifications)
            .HasForeignKey(ad => ad.DegreeId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<EducationalQualification>()
            .HasOne<EmployeeInformation>(s => s.EmployeeInformation)
            .WithMany(g => g.EducationalQualification)
            .HasForeignKey(s => s.EmployeeInformationId).OnDelete(DeleteBehavior.ClientCascade);

        }

    }
}

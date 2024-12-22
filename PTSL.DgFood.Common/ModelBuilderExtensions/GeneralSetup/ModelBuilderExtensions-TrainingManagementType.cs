using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureTrainingManagementType(this ModelBuilder builder)
        {
            builder.Entity<TrainingManagementType>(ac =>
            {
                ac.ToTable("TrainingManagementType", "GS");

                ac.Property(x => x.TrainingLocationType)
                    .HasColumnType("tinyint")
                    .IsRequired(false);
                ac.Property(x => x.TrainingManagementTypeLocalType)
                    .HasColumnType("tinyint")
                    .IsRequired(false);
                ac.Property(x => x.TrainingManagementTypeForeignType)
                    .HasColumnType("tinyint")
                    .IsRequired(false);

                ac.Property(x => x.DivisionId)
                    .IsRequired(false);
                ac.Property(x => x.DistrictId)
                    .IsRequired(false);
                ac.Property(x => x.UpazillaId)
                    .IsRequired(false);

                ac.Property(a => a.TrainingTitle)
                    .HasColumnType("nvarchar(500)")
                    .IsRequired(false);

                ac.Property(x => x.TrainingBatch)
                    .HasColumnType("nvarchar(200)")
                    .IsRequired(false);
                ac.Property(x => x.TrainingSubject)
                    .HasColumnType("nvarchar(200)")
                    .IsRequired(false);
                ac.Property(x => x.TrainingObjective)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired(false);
                ac.Property(a => a.FromDate)
                    .HasColumnName("FromDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                ac.Property(a => a.ToDate)
                    .HasColumnName("ToDate")
                    .HasColumnType("datetime2")
                    .IsRequired();
                ac.Property(a => a.DurationHour)
                    .HasColumnName("DurationHour")
                    .HasColumnType("int")
                    .IsRequired();
                ac.Property(a => a.Vanue)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired(false);

                ac.Property(a => a.SuggestedBy)
                    .HasColumnType("nvarchar(200)")
                    .IsRequired(false);
                ac.Property(a => a.Remarks)
                    .HasColumnType("nvarchar(500)")
                    .IsRequired(false);
                ac.Property(a => a.Institute)
                    .HasColumnName("Institute")
                    .HasColumnType("nvarchar(max)")
                    .IsRequired(false);
                //Add New

                ac.Property(a => a.TrainingPlanId)
                .HasColumnName("TrainingPlanId")
                .HasColumnType("bigint")
                .IsRequired(false);
            });
            builder.Entity<TrainingManagementType>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
        }
    }
}

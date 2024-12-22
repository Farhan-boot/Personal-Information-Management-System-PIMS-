using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity.GeneralSetup;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureCountryTrainingManagementTypeMap(this ModelBuilder builder)
        {
            builder.Entity<CountryTrainingManagementTypeMap>(ac =>
            {
                ac.Property(a => a.Country)
                    .HasColumnType("tinyint")
                    .IsRequired();
            });

            builder.Entity<CountryTrainingManagementTypeMap>()
                .HasOne(x => x.TrainingManagementType)
                .WithMany(x => x.CountryTrainingManagementTypeMaps)
                .HasForeignKey(x => x.TrainingManagementTypeId);
        }
    }
}

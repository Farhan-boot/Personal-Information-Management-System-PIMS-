using PTSL.DgFood.Common.Enum;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class CountryTrainingManagementTypeMap
    {
        public long Id { get; set; }

        public Country Country { get; set; }

        public long TrainingManagementTypeId { get; set; }
        public TrainingManagementType TrainingManagementType { get; set; }
    }
}

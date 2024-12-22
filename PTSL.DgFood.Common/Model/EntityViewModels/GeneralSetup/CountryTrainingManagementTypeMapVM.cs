using PTSL.DgFood.Common.Enum;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class CountryTrainingManagementTypeMapVM
    {
        public long Id { get; set; }

        public Country Country { get; set; }

        public long TrainingManagementTypeId { get; set; }
        public TrainingManagementTypeVM TrainingManagementTypeVM { get; set; }
    }
}

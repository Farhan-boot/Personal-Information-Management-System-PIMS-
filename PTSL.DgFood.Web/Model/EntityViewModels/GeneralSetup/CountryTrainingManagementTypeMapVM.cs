using PTSL.DgFood.Web.Helper.Enum;

namespace PTSL.DgFood.Web.Model
{
    public class CountryTrainingManagementTypeMapVM
    {
        public long Id { get; set; }

        public Country Country { get; set; }

        public long TrainingManagementTypeId { get; set; }
        public TrainingManagementTypeVM TrainingManagementTypeVM { get; set; }
    }
}

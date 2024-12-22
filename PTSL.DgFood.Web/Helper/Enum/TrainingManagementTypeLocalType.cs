using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Helper.Enum
{
    public enum TrainingManagementTypeLocalType
    {
        [Display(Name = "In House")]
        InHouse = 1,

        [Display(Name = "Departmental")]
        Departmental = 2,

        [Display(Name = "Institute")]
        Institute = 3,

        [Display(Name = "Training For Field Employees")]
        TrainingForFieldEmployees = 4
    }
}

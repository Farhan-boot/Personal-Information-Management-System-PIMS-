using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Helper.Enum
{
    public enum TrainingLocationType
    {
        [Display(Name = "Local")]
        Local = 1,

        [Display(Name = "Foreign")]
        Foreign = 2
    }
}

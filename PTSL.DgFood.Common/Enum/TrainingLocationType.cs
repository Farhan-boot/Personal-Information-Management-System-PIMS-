using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PTSL.DgFood.Common.Enum
{
    public enum TrainingLocationType
    {
        [Display(Name = "Local")]
        Local = 1,

        [Display(Name = "Foreign")]
        Foreign = 2
    }
}

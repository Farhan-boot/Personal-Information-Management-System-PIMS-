using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Helper.Enum
{
    public enum TrainingType
    {
        [Display(Name = "Local Training")] LocalTraining = 1,
        [Display(Name = "Foreign Training")] ForeignTraining = 2
    }
}

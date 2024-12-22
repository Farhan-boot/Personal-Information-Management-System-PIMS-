using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Helper.Enum
{
    public enum TrainingPlanType
    {
        [Display(Name = "Workshop")]
        Workshop = 1,
        [Display(Name = "Training")]
        Training = 2
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Helper.Enum
{
    public enum NatureOfPromotion
    {
        [Display(Name = "Regular")]
        Regular = 1,
        [Display(Name = "Current Charge")]
        Current_Charge = 2,
        [Display(Name = "Interim with self pay")]
        Interim_with_self_pay = 3
    }
}

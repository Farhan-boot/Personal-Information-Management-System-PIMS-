using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Helper.Enum
{
    public enum FreedomFighterInformation
    {
        [Display(Name = "Freedom Fighter")]
        FreedomFighter = 1,
        [Display(Name = " Freedom Fighter Child")]
        FreedomFighterChild = 2,
        [Display(Name = "Freedom Fighter Grand Child")]
        FreedomFighterGrandChild = 3,
    }
}

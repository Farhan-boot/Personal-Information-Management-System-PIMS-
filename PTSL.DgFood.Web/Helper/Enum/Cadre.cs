using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Helper.Enum
{
    public enum Cadre
    {
        //[Display(Name = "Non-Cadre")] NonCadre = 1,
        //[Display(Name = "Food")] Food = 2,
        [Display(Name = "Cadre")]
        Cadre = 1,
        [Display(Name = "Non-Cadre")]
        NonCadre = 2
    }
}

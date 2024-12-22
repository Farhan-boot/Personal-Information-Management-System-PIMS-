using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PromtionNatureVM : BaseModel
    {
        [MaxLength(100)]
        public string PromtionNatureName { get; set; }
        [MaxLength(100)]
        public string PromtionNatureNameBangla { get; set; }
    }
}

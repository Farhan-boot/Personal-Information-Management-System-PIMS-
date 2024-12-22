using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PresentStatusVM : BaseModel
    {
        [MaxLength(100)]
        public string PresentStatusName { get; set; }
        public string PresentStatusNameBn { get; set; }
    }
}

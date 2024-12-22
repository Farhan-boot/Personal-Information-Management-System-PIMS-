using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class EmployeeStatusVM : BaseModel
    {
        [MaxLength(100)]
        public string EmployeeStatusName { get; set; }
        [MaxLength(100)]
        public string EmployeeStatusNameBangla { get; set; }
        //public PresentPostingDetails PresentPostingDetails { get; set; }
    }
}

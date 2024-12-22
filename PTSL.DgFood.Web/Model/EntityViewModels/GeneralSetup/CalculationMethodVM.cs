
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class CalculationMethodVM : BaseModel
    {
        [MaxLength(100)]
        public string CalculationMethodName { get; set; }
        public string CalculationMethodNameBn { get; set; }
        public IList<LeaveTypeInformationVM> LeaveTypeInformationList { get; set; }
    }
}

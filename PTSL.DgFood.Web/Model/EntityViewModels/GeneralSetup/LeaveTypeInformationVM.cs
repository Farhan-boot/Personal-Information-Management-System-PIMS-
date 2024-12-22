using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class LeaveTypeInformationVM : BaseModel
    {
        [MaxLength(100)]
        public string NameInEnglish { get; set; }
        [MaxLength(100)]
        public string NameInBangla { get; set; }
        public EligibleFor EligibleFor { get; set; }
        public long CalculationMethodId { get; set; }
        public int MaxDaysPerYear { get; set; }
        public int LeaveRestriction { get; set; }
        public int LeaveLimit { get; set; }
        public int ApplicationWithIn { get; set; }
        public virtual CalculationMethodVM CalculationMethodDTO { get; set; }
        public IList<LeaveApplicationVM> LeaveApplicationList { get; set; }

    }
}

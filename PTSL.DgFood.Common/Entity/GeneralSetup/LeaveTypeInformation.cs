using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class LeaveTypeInformation : BaseEntity
    {
        public string NameInEnglish { get; set; }
        public string NameInBangla { get; set; }
        public EligibleFor EligibleFor { get; set; }
        public long CalculationMethodId {get;set;}
        public int MaxDaysPerYear { get; set; }
        public int LeaveRestriction { get; set; }
        public int LeaveLimit { get; set; }
        public int ApplicationWithIn { get; set; }
        public virtual CalculationMethod CalculationMethod { get; set; }
        public IList<LeaveApplication> LeaveApplications { get; set; }

    }
}

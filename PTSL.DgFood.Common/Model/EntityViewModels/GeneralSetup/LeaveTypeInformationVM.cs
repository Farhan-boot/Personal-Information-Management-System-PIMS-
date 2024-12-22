using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class LeaveTypeInformationVM : BaseModel
    {
        public string NameInEnglish { get; set; }
        public string NameInBangla { get; set; }
        public EligibleFor EligibleFor { get; set; }
        public long CalculationMethodId {get;set;}
        public int MaxDaysPerYear { get; set; }
        public int LeaveRestriction { get; set; }
        public int LeaveLimit { get; set; }
        public int ApplicationWithIn { get; set; }
        public virtual CalculationMethodVM CalculationMethodDTO { get; set; }
        public IList<LeaveApplicationVM> LeaveApplicationList { get; set; }

    }
}

using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class CalculationMethodVM : BaseModel
    {
        public string CalculationMethodName { get; set; }
        public string CalculationMethodNameBn { get; set; }
        public IList<LeaveTypeInformationVM> LeaveTypeInformationList { get; set; }
    }
}

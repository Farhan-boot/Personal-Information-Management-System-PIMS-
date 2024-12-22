using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class CalculationMethod : BaseEntity
    {
        public string CalculationMethodName { get; set; }
        public string CalculationMethodNameBn { get; set; }
        public IList<LeaveTypeInformation> LeaveTypeInformations { get; set; }
    }
}

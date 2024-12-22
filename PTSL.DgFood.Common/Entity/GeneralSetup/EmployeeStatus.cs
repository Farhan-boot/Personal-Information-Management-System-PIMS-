using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class EmployeeStatus : BaseEntity
    {
        public string EmployeeStatusName { get; set; }
        public string EmployeeStatusNameBangla { get; set; }
        public IList<EmployeeInformation> EmployeeInformations { get; set; }
    }
}

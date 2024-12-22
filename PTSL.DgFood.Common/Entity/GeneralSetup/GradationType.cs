using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class GradationType : BaseEntity
    {
        public string GradationTypeName { get; set; }
        public string GradationTypeNameBn { get; set; }
        public IList<OfficialInformation> OfficialInformations { get; set; }
    }
}

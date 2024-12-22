using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class Addl_prof_q_info : BaseEntity
    {
        public string Description { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
    }
}

using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class AwardInformationVM : BaseModel
    {
        public string AwardName { get; set; }
        public string AwardGround { get; set; }
        public DateTime AwardDate { get; set; }
        public long EmployeeInformationId { get; set; } 
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
    

    }
}

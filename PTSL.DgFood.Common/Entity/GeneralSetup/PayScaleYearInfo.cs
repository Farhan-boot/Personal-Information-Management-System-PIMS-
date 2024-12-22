using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class PayScaleYearInfo : BaseEntity
    {
        public int PayScaleYearInfoName { get; set; } 
        public DateTime ImplementationDate { get; set; }
    }
}

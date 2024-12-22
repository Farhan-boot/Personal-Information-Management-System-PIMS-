using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class PayScaleYearInfoVM : BaseModel
    {
        public int PayScaleYearInfoName { get; set; }
        public DateTime ImplementationDate { get; set; }
    }
}

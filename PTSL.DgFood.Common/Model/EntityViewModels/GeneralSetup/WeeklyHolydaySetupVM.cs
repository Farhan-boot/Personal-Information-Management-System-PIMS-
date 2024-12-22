using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class WeeklyHolydaySetupVM : BaseModel
    {
        public Days Day { get; set; }
        public long YearsId { get; set; }
        public DateTime HolidayDate { get; set; }
        public virtual YearsVM YearDTO { get; set; }
    }
}

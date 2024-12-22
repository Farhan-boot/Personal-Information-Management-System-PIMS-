using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class WeeklyHolydaySetup : BaseEntity
    {
        public Days Day { get; set; }
        public long YearsId { get; set; }
        public DateTime HolidayDate { get; set; }
        public virtual Years Years { get; set; }
    }
}

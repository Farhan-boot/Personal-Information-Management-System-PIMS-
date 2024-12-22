using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class WeeklyHolydaySetupVM : BaseModel
    {
        public Days Day { get; set; }
        public long YearsId { get; set; }
        public DateTime HolidayDate { get; set; }
        public virtual YearsVM YearDTO { get; set; }
    }
}

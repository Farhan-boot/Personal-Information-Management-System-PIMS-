using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model
{
    public class EmployeeInformationCountVM : BaseModel
    {
        public long DesignationID { get; set; }
        public long RankId { get; set; }
        public long DesignationClassId { get; set; }
        public int ApprovedTotalPost { get; set; }
        public int CurrentTotalActivePost { get; set; }
        public int CurrentTotalInactivePost { get; set; }
        public DateTime? InactiveDate { get; set; }
        public string InactiveReason { get; set; }
        public string Remarks { get; set; }
        public virtual DesignationVM Designation { get; set; }
        public virtual RankVM Rank { get; set; }
        public virtual DesignationClassVM DesignationClass { get; set; }
    }
}
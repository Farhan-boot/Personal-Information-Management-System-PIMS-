using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class EmployeeInformationCount : BaseEntity
    {
        public long RankId { get; set; }
        public long DesignationClassId { get; set; }
        public long DesignationID { get; set; }       
        public int ApprovedTotalPost { get; set; }
        public int CurrentTotalActivePost { get; set; }
        public int CurrentTotalInactivePost { get; set; }
        public DateTime? InactiveDate { get; set; }
        public string InactiveReason { get; set; }
        public string Remarks { get; set; }

        //public virtual PayScalePerGrade Payscale { get; set; }
        //public virtual Rank Grade { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual DesignationClass DesignationClass { get; set; }
    }
}

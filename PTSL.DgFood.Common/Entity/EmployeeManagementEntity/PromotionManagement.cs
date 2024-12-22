using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class PromotionManagement : BaseEntity
    {
        public long? RankId { get; set; }
        public long? DesignationId { get; set; }
        public DateTime? PromotionDate { get; set; }
        public string GONumber { get; set; }
        public DateTime? GODate { get; set; }
        public string PayScale { get; set; }
        public bool PresentPosting { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual Designation Designation { get; set; }
        public long? PromtionNatureId { get; set; }
        public long PayScaleYearInfoId { get; set; }
        public virtual PromtionNature PromtionNature { get; set; }
        public virtual PayScaleYearInfo PayScaleYearInfo { get; set; }
        public bool RunningStatus { get; set; }
        public virtual PromotionPartculars PromotionPartculars { get; set; }
    }
}

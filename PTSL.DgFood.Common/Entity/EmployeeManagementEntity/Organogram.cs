using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using System;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class Organogram : BaseEntity
    {
        public long? PostingTypeId { get; set; }
        public OrganogramOfficeType OrganogramOfficeType { get; set; }
        public long? PostingId { get; set; } 
        public long? DesignationID { get; set; }       
        public bool? IsPermanent { get; set; }
        public DateTime? NonPermanentDeadLine { get; set; }

        public bool IsParent { get; set; }
        public long ParentId { get; set; }
        public int TotalPost { get; set; }
        public string Name { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string OfficeEmail { get; set; }

        public virtual PostingType PostingType { get; set; }
        public virtual Posting ParentPosting { get; set; }
        public virtual Posting Posting { get; set; }
        public virtual Designation Designation { get; set; }
    }
}

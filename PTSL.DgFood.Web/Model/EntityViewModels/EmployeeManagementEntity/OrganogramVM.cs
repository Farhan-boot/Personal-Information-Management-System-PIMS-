using PTSL.DgFood.Web.Helper.Enum;
using System;

namespace PTSL.DgFood.Web.Model
{
    public class OrganogramVM : BaseModel
    {
        public OrganogramOfficeType OrganogramOfficeType { get; set; }
        public long? PostingId { get; set; }
        public long? DesignationID { get; set; }
        public bool? IsPermanent { get; set; }
        public DateTime? NonPermanentDeadLine { get; set; }
        public string NonPermanentDeadLineString { get; set; } = string.Empty;

        public bool IsParent { get; set; }
        public long ParentId { get; set; }
        public int TotalPost { get; set; }
        public string Name { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string OfficeEmail { get; set; }

        public virtual PostingTypeVM PostingTypeDto { get; set; }
        public virtual PostingVM ParentPostingDto { get; set; }
        public virtual PostingVM PostingDto { get; set; }
        public virtual DesignationVM DesignationDto { get; set; }
    }
}
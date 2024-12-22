using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class EmployeeTransfer : BaseEntity
    {
        public long? RankId { get; set; }
        public long? DesignationClassId { get; set; }
        public long? DesignationId { get; set; }
        public long? PostResponsibilityId { get; set; }
        //public string MainPostingPlace { get; set; }
        public long? MainPostingTypeId { get; set; }
        public long? PostingId { get; set; }
        public string Section { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public bool IfEmployeeContinuing { get; set; }
        public long? CurrDesignationClassId { get; set; }
        public long? CrntDesgId { get; set; }
        public long? DeppostingTypeId { get; set; }
        public long? DepPostingId { get; set; }
        public string AttachSection { get; set; }
        public long? TransferFromDivisionId { get; set; }
        public long? TransferToDivisionId { get; set; }
        public long? TransferFromDistrictId { get; set; }
        public long? TransferToDistrictId { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual DesignationClass DesignationClass { get; set; }
        public virtual Designation CrntDesg { get; set; }
        public virtual DesignationClass CurrDesignationClass { get; set; }
        public virtual PostingType MainPostingType { get; set; }
        public virtual Posting Posting { get; set; }
        public virtual PostingType DeppostingType { get; set; }
        public virtual Posting DepPosting { get; set; }
        public virtual PostResponsibility PostResponsibility { get; set; }
        public WorkingAs WorkingAsId { get; set; }
        public virtual Division TransferFromDivision { get; set; }
        public virtual Division TransferToDivision { get; set; }
        public virtual District TransferFromDistrict { get; set; }
        public virtual District TransferToDistrict { get; set; }
        public virtual PostingRecords PostingRecords { get; set; }
        public string MemoNo { get; set; }
        public string UploadFiles { get; set; }
        public DateTime? PostingDate { get; set; }
        public bool IsPostingCompleted { get; set; }
    }
}

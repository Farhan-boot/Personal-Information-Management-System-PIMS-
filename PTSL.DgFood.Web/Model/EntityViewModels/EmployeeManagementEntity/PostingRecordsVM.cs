using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PostingRecordsVM : BaseModel
    {
        public long? RankId { get; set; }
        public long? DesignationClassId { get; set; }
        public long? DesignationId { get; set; }
        public long? PostResponsibilityId { get; set; }
        //public string MainPostingPlace { get; set; }
        public long? MainPostingTypeId { get; set; }
        public long? PostingId { get; set; }
        [MaxLength(100)]
        public string Section { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public bool IfEmployeeContinuing { get; set; }
        public long? CurrDesignationClassId { get; set; }
        public long? CrntDesgId { get; set; }
        public long? DeppostingTypeId { get; set; }
        public long? DepPostingId { get; set; }
        [MaxLength(100)]
        public string AttachSection { get; set; }
        public long? TransferFromDivisionId { get; set; }
        public long? TransferToDivisionId { get; set; }
        public long? TransferFromDistrictId { get; set; }
        public long? TransferToDistrictId { get; set; }
        public long EmployeeInformationId { get; set; }
        public WorkingAs WorkingAsId { get; set; }
        [MaxLength(100)]
        public string MemoNo { get; set; }
        public string UploadFiles { get; set; }
        public DateTime? PostingDate { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public virtual RankVM RankDTO { get; set; }
        public virtual DesignationVM DesignationDTO { get; set; }
        public virtual DesignationClassVM DesignationClassDTO { get; set; }
        public virtual DesignationVM CrntDesgDTO { get; set; }
        public virtual DesignationClassVM CurrDesignationClassDTO { get; set; }
        public virtual PostingTypeVM MainPostingTypeDTO { get; set; }
        public virtual PostingVM PostingDTO { get; set; }
        public virtual PostingTypeVM DeppostingTypeDTO { get; set; }
        public virtual PostingVM DepPostingDTO { get; set; }
        public virtual PostResponsibilityVM PostResponsibilityDTO { get; set; }
        public virtual DivisionVM TransferFromDivisionDTO { get; set; }
        public virtual DivisionVM TransferToDivisionDTO { get; set; }
        public virtual DistrictVM TransferFromDistrictDTO { get; set; }
        public virtual DistrictVM TransferToDistrictDTO { get; set; }
        public long? EmployeeTransferId { get; set; }
        public virtual EmployeeTransferVM EmployeeTransferDTO { get; set; }
    }
}

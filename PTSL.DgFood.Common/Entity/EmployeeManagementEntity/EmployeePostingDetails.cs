
using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class EmployeePostingDetails : BaseEntity
    {
        public long? EmployeeInformationId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public long? JoiningRankId { get; set; }
        public string OfficeEmail { get; set; }
        public OrganogramOfficeType? OfficeType { get; set; }
        public long? DesignationTypeId { get; set; }
        public virtual Designation DesignationType { get; set; }
        public long? PostingTypeId { get; set; }
        public virtual PostingType PostingType { get; set; }
        public long? PostingId { get; set; }
        public virtual Posting Posting { get; set; }
        public long? DesignationClassId { get; set; }
        public virtual DesignationClass DesignationClass { get; set; }
        public long? DesignationId { get; set; }
        public Designation Designation { get; set; }
        public string GradationNumber { get; set; }
        public long? GradationTypeId { get; set; }
        public long? EmployeeTypeId { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public long? JobCategoryId { get; set; }
        public long? PostResponsibilityId { get; set; }
        public virtual PostResponsibility PostResponsibility { get; set; }
        public long? RecruitPromoId { get; set; } // Position
        public virtual RecruitPromo RecruitPromo { get; set; } // Position
        public long PromtionNatureId { get; set; } // Working As
        public virtual PromtionNature PromtionNature { get; set; } // Working As
        public string Section { get; set; }
        public string GradationYear { get; set; }
        public DateTime? JobPermanentDate { get; set; }
        public long? DeppostingTypeId { get; set; } //Posting Type CC/Attachment etc
        public virtual PostingType? DeppostingType { get; set; } //Posting Type CC/Attachment etc
        public string SectionAt { get; set; }
        public DateTime? PRLDate { get; set; }
        public string Batch { get; set; }
        public Enum.Cadre? CadreId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Remarks { get; set; }
        public Enum.PostingDetails? PostingDetailsId { get; set; }

    }
}
using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity
{
    public class EmployeePostingDetailsVM : BaseModel
    {
        public long? EmployeeInformationId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public long? JoiningRankId { get; set; }
        public string OfficeEmail { get; set; }
        public OrganogramOfficeType? OfficeType { get; set; }
        public long? DesignationTypeId { get; set; }

        public virtual DesignationVM DesignationType { get; set; }
        public long? PostingTypeId { get; set; }

        public virtual PostingTypeVM PostingType { get; set; }
        public long? PostingId { get; set; }

        public virtual PostingVM Posting { get; set; }
        public long? DesignationClassId { get; set; }

        public virtual DesignationClassVM DesignationClass { get; set; }
        public long? DesignationId { get; set; }
        //public Designation Designation { get; set; }
        public string GradationNumber { get; set; }
        public long? GradationTypeId { get; set; }
        public long? EmployeeTypeId { get; set; }
        public virtual EmployeeTypeVM EmployeeType { get; set; }
        public long? JobCategoryId { get; set; }
        public long? PostResponsibilityId { get; set; }

        public virtual PostResponsibilityVM PostResponsibility { get; set; }
        public long? RecruitPromoId { get; set; } // Position

        public virtual RecruitPromoVM RecruitPromo { get; set; } // Position
        public long PromtionNatureId { get; set; } // Working As

        public virtual PromtionNatureVM PromtionNature { get; set; } // Working As
        public string Section { get; set; }
        public string GradationYear { get; set; }
        public DateTime? JobPermanentDate { get; set; }
        public long? DeppostingTypeId { get; set; } //Posting Type CC/Attachment etc
 
        public virtual PostingTypeVM DeppostingType { get; set; } //Posting Type CC/Attachment etc
        public string SectionAt { get; set; }
        public DateTime? PRLDate { get; set; }
        public string Batch { get; set; }
        public Cadre CadreId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Remarks { get; set; }
        public PostingDetails? PostingDetailsId { get; set; }
    }
}
using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class OfficialInformationVM : BaseModel
    {
        public long EmployeeInformationId { get; set; }
        public DateTime? FirstJoiningDate { get; set; }
        public OrganogramOfficeType? JoinOrganogramOfficeType { get; set; }
        public long? JoinPostingTypeId { get; set; }
        public long? JoinPostingId { get; set; }
        public long? JoiningDesignationClassId { get; set; }
        public long? JoiningDesgId { get; set; }
        public Cadre CadreId { get; set; }
        public DateTime? CadreDate { get; set; }
        [MaxLength(100)]
        public string Batch { get; set; }
        [MaxLength(100)]
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime PresentJoinDate { get; set; }
        public string GradationNumber { get; set; }
        public long? GradationTypeId { get; set; }
        public long EmployeeTypeId { get; set; }
        public long? JobCategoryId { get; set; }
        [MaxLength(100)]
        public string Section { get; set; }
        [MaxLength(100)]
        public string SectionAt { get; set; }
        public DateTime? PRLDate { get; set; }
        public DateTime JobPermanentDate { get; set; }
        public string Remarks { get; set; }
        public string GradationYear { get; set; }
        public long? JoiningRankId { get; set; }
        public long? PresentRankId { get; set; }
        public long? PresentDesignationClassId { get; set; }
        public long? PresentDesignationId { get; set; }
        public long? CrntDesgId { get; set; }

        public long? CurrDesignationClassId { get; set; }

        public long? PostResponsibilityId { get; set; }

        public long? RecruitPromoId { get; set; }

        public long PromtionNatureId { get; set; }
        public OrganogramOfficeType? PresentOrganogramOfficeType { get; set; }
        public long PostingTypeId { get; set; }
        public long? DeppostingTypeId { get; set; }

        public long PostingId { get; set; }
        public long? DepPostingId { get; set; }
        public virtual RankVM JoiningRankDTO { get; set; }
        public virtual RankVM PresentRankDTO { get; set; }
        public virtual DesignationClassVM PresentDesignationClassDTO { get; set; }
        public virtual DesignationVM PresentDesignationDTO { get; set; }
        public virtual DesignationVM CrntDesgDTO { get; set; }

        public virtual DesignationClassVM CurrDesignationClassDTO { get; set; }

        public virtual PostResponsibilityVM PostResponsibilityDTO { get; set; }

        public virtual RecruitPromoVM RecruitPromoDTO { get; set; }

        public virtual PromtionNatureVM PromtionNatureDTO { get; set; }
        public virtual PostingTypeVM PostingTypeDTO { get; set; }
        public virtual PostingTypeVM DeppostingTypeDTO { get; set; }

        public virtual PostingVM PostingDTO { get; set; }
        public virtual PostingVM DeppostingDTO { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }

        public virtual PostingTypeVM JoinPostingTypeDTO { get; set; }
        public virtual PostingVM JoinPostingDTO { get; set; }
        public virtual DesignationClassVM JoiningDesignationClassDTO { get; set; }
        public virtual DesignationVM JoiningDesgDTO { get; set; }
        public virtual GradationTypeVM GradationTypeDTO { get; set; }
        public virtual EmployeeTypeVM EmployeeTypeDTO { get; set; }
        public virtual JobCategoryVM JobCategoryDTO { get; set; }

		public bool IsFirstJoiningPostPermanent { get; set; }
		public bool IsPresentPostingPermanent { get; set; }

        public OrganogramOfficeType? CrntOrganogramOfficeType { get; set; }
		public bool IsCrntPostPermanent { get; set; }

        //Add New
        public string OfficeEmail { get; set; }
    }
}

using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Helper;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
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
        public Enum.Cadre CadreId { get; set; }
        public DateTime? CadreDate { get; set; }
        public string Batch { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime PresentJoinDate { get; set; }
        public string GradationNumber { get; set; }
        public long? GradationTypeId { get; set; }
        public long EmployeeTypeId { get; set; }
        public long? JobCategoryId { get; set; }
        public string Section { get; set; }

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

        [SwaggerExclude]
        public virtual RankVM JoiningRankDTO { get; set; }
        [SwaggerExclude]
        public virtual RankVM PresentRankDTO { get; set; }
        [SwaggerExclude]
        public virtual DesignationClassVM PresentDesignationClassDTO { get; set; }
        [SwaggerExclude]
        public virtual DesignationVM PresentDesignationDTO { get; set; }
        [SwaggerExclude]
        public virtual DesignationVM CrntDesgDTO { get; set; }
        [SwaggerExclude]
        public virtual DesignationClassVM CurrDesignationClassDTO { get; set; }
        [SwaggerExclude]
        public virtual PostResponsibilityVM PostResponsibilityDTO { get; set; }
        [SwaggerExclude]
        public virtual RecruitPromoVM RecruitPromoDTO { get; set; }
        [SwaggerExclude]
        public virtual PromtionNatureVM PromtionNatureDTO { get; set; }
        [SwaggerExclude]
        public virtual PostingTypeVM PostingTypeDTO { get; set; }
        [SwaggerExclude]
        public virtual PostingTypeVM DeppostingTypeDTO { get; set; }
        [SwaggerExclude]
        public virtual PostingVM PostingDTO { get; set; }
        [SwaggerExclude]
        public virtual PostingVM DeppostingDTO { get; set; }
        [SwaggerExclude]
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        [SwaggerExclude]
        public virtual PostingTypeVM JoinPostingTypeDTO { get; set; }
        [SwaggerExclude]
        public virtual PostingVM JoinPostingDTO { get; set; }
        [SwaggerExclude]
        public virtual DesignationClassVM JoiningDesignationClassDTO { get; set; }
        [SwaggerExclude]
        public virtual DesignationVM JoiningDesgDTO { get; set; }
        [SwaggerExclude]
        public virtual GradationTypeVM GradationTypeDTO { get; set; }
        [SwaggerExclude]
        public virtual EmployeeTypeVM EmployeeTypeDTO { get; set; }
        [SwaggerExclude]
        public virtual JobCategoryVM JobCategoryDTO { get; set; }

		public bool IsFirstJoiningPostPermanent { get; set; }
		public bool IsPresentPostingPermanent { get; set; }

        public OrganogramOfficeType? CrntOrganogramOfficeType { get; set; }
		public bool IsCrntPostPermanent { get; set; }

        //Add New
        public string? OfficeEmail { get; set; }
    }
}

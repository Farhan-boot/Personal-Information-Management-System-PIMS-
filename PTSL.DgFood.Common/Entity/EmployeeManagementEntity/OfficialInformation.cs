
using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class OfficialInformation : BaseEntity
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
        public virtual Rank JoiningRank { get; set; }
        public long? PresentRankId { get; set; }
        public virtual Rank PresentRank { get; set; }
        public long? PresentDesignationClassId { get; set; }
        public virtual DesignationClass PresentDesignationClass { get; set; }
        public long? PresentDesignationId { get; set; }
        public virtual Designation PresentDesignation { get; set; }
        public long? CrntDesgId { get; set; }
        public virtual Designation CrntDesg { get; set; }

        public long? CurrDesignationClassId { get; set; }
        public virtual DesignationClass CurrDesignationClass { get; set; }

        public long? PostResponsibilityId { get; set; }
        public virtual PostResponsibility PostResponsibility { get; set; }

        public long? RecruitPromoId { get; set; }
        public virtual RecruitPromo RecruitPromo { get; set; }

        public long PromtionNatureId { get; set; }
        public virtual PromtionNature PromtionNature { get; set; }
        public OrganogramOfficeType? PresentOrganogramOfficeType { get; set; }
        public long PostingTypeId { get; set; }
        public virtual PostingType PostingType { get; set; }
        public long? DeppostingTypeId { get; set; }
        public virtual PostingType DeppostingType { get; set; }

        public long PostingId { get; set; }
        public virtual Posting Posting { get; set; }
        public long? DepPostingId { get; set; }
        public virtual Posting Depposting { get; set; }

		public virtual EmployeeInformation EmployeeInformation { get; set; }

        public virtual PostingType JoinPostingType { get; set; }
        public virtual Posting JoinPosting { get; set; }
        public virtual DesignationClass JoiningDesignationClass { get; set; }
        public virtual Designation JoiningDesg { get; set; }
        public virtual GradationType GradationType { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public virtual JobCategory JobCategory { get; set; }


		public bool IsFirstJoiningPostPermanent { get; set; }
		public bool IsPresentPostingPermanent { get; set; }

        public OrganogramOfficeType? CrntOrganogramOfficeType { get; set; }
		public bool IsCrntPostPermanent { get; set; }

        //Add New
        public string? OfficeEmail { get; set; }
    }
}
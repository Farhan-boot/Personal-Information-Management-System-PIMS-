using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class EmployeeInformationVM : BaseModel
    {
        [MaxLength(50)]
        public string GovtID { get; set; }
        [MaxLength(50)]
        public string NationalID { get; set; }
        [MaxLength(50)]
        public string MobileNumber { get; set; }
        [MaxLength(300)]
        public string Email { get; set; }
        [MaxLength(500)]
        public string NameBangla { get; set; }
        [MaxLength(500)]
        public string NameEnglish { get; set; }
        [MaxLength(500)]
        public string Photo { get; set; }
        public long DivisionId { get; set; }
        public long DistrictId { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(300)]
        public string FathersNameBangla { get; set; }
        [MaxLength(300)]
        public string FathersNameEnglish { get; set; }
        [MaxLength(300)]
        public string MothersNameBangla { get; set; }
        [MaxLength(300)]
        public string MothersNameEnglish { get; set; }
        [MaxLength(100)]
        public string oclsd { get; set; }

        public long? EmployeeStatusId { get; set; }
        public virtual EmployeeStatusVM EmployeeStatus { get; set; }
        [MaxLength(100)]
        public string OtherReligion { get; set; }
        public bool FreedomFighter { get; set; }
        public bool ChildGrandChildOfFreedomFighter { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public RecruitmentType? RecruitmentType { get; set; }

        public virtual DivisionVM Division { get; set; }
        public virtual DistrictVM District { get; set; }
        public Gender GenderId { get; set; }
        public MaritalStatus MaritalStatusId { get; set; }
        public Religion? ReligionId { get; set; }
        [MaxLength(50)]
        public string TIN { get; set; }

        public string OfficeEmail { get; set; }

        public int? NumberOfChildren { get; set; }
        [MaxLength(50)]
        public string PassportNumber { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        [MaxLength(500)]
        public string PassportIssuePlace { get; set; }
        public DateTime? PassportDateOfExpire { get; set; }
        [MaxLength(50)]
        public string DrivingLicenceNo { get; set; }
        public DateTime? CircularDate { get; set; }
        public string BCSNo { get; set; }
        public string MeritOrder { get; set; }
        public long? PoliceStationId { get; set; }
        [MaxLength(50)]
        public string EmployeeCode { get; set; }
        public virtual EmployeeStatusVM EmployeeStatusDTO { get; set; }

        public virtual DivisionVM DivisionDTO { get; set; }
        public virtual DistrictVM DistrictDTO { get; set; }

        //New Add
        public long? FreedomFighterInformationId { get; set; }
        public string FingerPrintId { get; set; }

        //Add New
        public string BcsBatchNo { get; set; }
        public string BcsOrderNo { get; set; }
        public DateTime? BcsDate { get; set; }


        public IList<PermanentAddressVM> PermanentAddressesList { get; set; }
        public IList<PresentAddressVM> PresentAddressesList { get; set; }
        public IList<SpouseInformationVM> SpouseInformationList { get; set; }
        public IList<EducationalQualificationVM> EducationalQualificationList { get; set; }
        public IList<TrainingInformationVM> TrainingInformationList { get; set; }
        public IList<ChildrenInformationVM> ChildrenInformationList { get; set; }
        public IList<ServiceHistoryVM> ServiceHistoriesList { get; set; }
        public IList<OfficialInformationVM> OfficialInformation { get; set; }
        public IList<DisciplinaryActionsAndCriminalProsecutionVM> DisciplinaryActionsAndCriminalProsecutionsList { get; set; }
        public IList<PostingRecordsVM> PostingRecordsList { get; set; }
        public IList<EmployeeTransferVM> EmployeeTransfersList { get; set; }

        public IList<PromotionPartcularsVM> PromotionPartcularsList { get; set; }
        public IList<LanguageInformationVM> LanguageInformationsList { get; set; }
        public IList<LeaveApplicationVM> LeaveApplicationsList { get; set; }
        public IList<AwardInformationVM> AwardInformationList { get; set; }
        public IList<Addl_prof_q_infoVM> Addl_prof_q_infoList { get; set; }
        public IList<ForeignTravelInfoVM> ForeignTravelInfoList { get; set; }
        public IList<MagisterialPowerInfoVM> MagisterialPowerInfoList { get; set; }
        public IList<OtherServiceInfoVM> OtherServiceInfoList { get; set; }
        public IList<PostingAbroadVM> PostingAbroadList { get; set; }
        public IList<PublicationInfoVM> PublicationInfoList { get; set; }
        public PoliceStationVM PoliceStationDTO { get; set; }
        public IList<PromotionManagementVM> PromotionManagementList { get; set; }
        //public IList<TrainingInformationManagementVM> TrainingInformationManagementList { get; set; }

        // From Official Info
        public string JoiningDesignation { get; set; } = string.Empty;
        public long? JoiningDesignationId { get; set; }
        public string PresentDesignation { get; set; } = string.Empty;
        public long? PresentDesignationId { get; set; }
        public string AttachDesignation { get; set; } = string.Empty;
        public long? AttachDesignationId { get; set; }

        //Add New
        public string EmpCodeGen { get; set; } = string.Empty;

    }
}

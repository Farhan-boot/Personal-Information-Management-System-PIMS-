using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class EmployeeInformationVM : BaseModel
    {
        public string GovtID { get; set; }
        public string NationalID { get; set; }

        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string NameBangla { get; set; }
        public string NameEnglish { get; set; }
        public string Photo { get; set; }
        public long DivisionId { get; set; }
        public long DistrictId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FathersNameBangla { get; set; }
        public string FathersNameEnglish { get; set; }
        public string MothersNameBangla { get; set; }
        public string MothersNameEnglish { get; set; }
        public string oclsd { get; set; }

        public long? EmployeeStatusId { get; set; }
        public virtual EmployeeStatusVM EmployeeStatus { get; set; }
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

        public string TIN { get; set; }
        public string OfficeEmail { get; set; }

        public int? NumberOfChildren { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public string PassportIssuePlace { get; set; }
        public DateTime? PassportDateOfExpire { get; set; }
        public string DrivingLicenceNo { get; set; }
        public DateTime? CircularDate { get; set; }
        public string BCSNo { get; set; }
        public string MeritOrder { get; set; }
        public long? PoliceStationId { get; set; }
        public string EmployeeCode { get; set; }
        public virtual EmployeeStatusVM EmployeeStatusDTO { get; set; }
         
        public virtual DivisionVM DivisionDTO { get; set; }
        public virtual DistrictVM DistrictDTO { get; set; }

        //New Add
        public long? FreedomFighterInformationId { get; set; }
        public string FingerPrintId { get; set; }

        //Add New
        public string? BcsBatchNo { get; set; }
        public string? BcsOrderNo { get; set; }
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
        public IList<TrainingInformationManagementVM> TrainingInformationManagementList { get; set; }

        // From Official Info
        public string JoiningDesignation { get; set; } = string.Empty;
        public long? JoiningDesignationId { get; set; }
        public string PresentDesignation { get; set; } = string.Empty;
        public long? PresentDesignationId { get; set; }
        public string AttachDesignation { get; set; } = string.Empty;
        public long? AttachDesignationId { get; set; }
    }
}

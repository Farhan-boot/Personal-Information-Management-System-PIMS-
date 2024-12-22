using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class EmployeeInformation : BaseEntity
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
        public virtual EmployeeStatus EmployeeStatus { get; set; } 
        public string OtherReligion { get; set; }
        public bool FreedomFighter { get; set; }
        public bool ChildGrandChildOfFreedomFighter {get;set;}
        public BloodGroup BloodGroup { get; set; }
        public RecruitmentType? RecruitmentType { get; set; }

        public virtual Division Division { get; set; }
        public virtual District District { get; set; }
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
        public string FingerPrintId { get; set; }

        //public long? UserId { get; set; }
        public virtual User User { get; set; }

        //New Add
        public long? FreedomFighterInformationId { get; set; }

        //Add New
        public string? BcsBatchNo { get; set; }
        public string? BcsOrderNo { get; set; }
        public DateTime? BcsDate { get; set; }

        public IList<PermanentAddress> PermanentAddresses { get; set; }
        public IList<PresentAddress> PresentAddresses { get; set; }
        public IList<SpouseInformation> SpouseInformation { get; set; }
        public IList<EducationalQualification> EducationalQualification { get; set; }
        public IList<TrainingInformation> TrainingInformation { get; set; }
        public IList<ChildrenInformation> ChildrenInformation { get; set; }
        public IList<ServiceHistory> ServiceHistories { get; set; }
        public List<OfficialInformation> OfficialInformation { get; set; }
        public IList<DisciplinaryActionsAndCriminalProsecution> DisciplinaryActionsAndCriminalProsecutions { get; set; }
        public IList<PostingRecords> PostingRecords { get; set; }
        public IList<EmployeeTransfer> EmployeeTransfers { get; set; }

        public IList<PromotionPartculars> PromotionPartculars { get; set; }
        public IList<LanguageInformation> LanguageInformations { get; set; }
        public IList<LeaveApplication> LeaveApplications { get; set; }
        public IList<AwardInformation> AwardInformations { get; set; }
        public IList<Addl_prof_q_info> Addl_prof_q_infos { get; set; }
        public IList<ForeignTravelInfo> ForeignTravelInfos { get; set; }
        public IList<MagisterialPowerInfo> MagisterialPowerInfos { get; set; }
        public IList<OtherServiceInfo> OtherServiceInfos { get; set; }
        public IList<PostingAbroad> PostingAbroads { get; set; }
        public IList<PublicationInfo> PublicationInfos { get; set; }
        public IList<TrainingInformationManagement> TrainingInformationManagements { get; set; }
        public PoliceStation PoliceStation { get; set; }
        public IList<PromotionManagement> PromotionManagement { get; set; }
        public IList<PRL> PRLData { get; set; }

        public static implicit operator EmployeeInformation(Task<(ExecutionState executionState, EmployeeInformation entity, string message)> v)
        {
            throw new NotImplementedException();
        }
    }
}

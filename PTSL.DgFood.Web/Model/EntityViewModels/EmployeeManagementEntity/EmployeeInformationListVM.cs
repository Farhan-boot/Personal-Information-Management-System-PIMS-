using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class EmployeeInformationListVM
    {
        public long Id { get; set; }
        public string GovtID { get; set; }
        public string NationalID { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string NameBangla { get; set; }
        public string NameEnglish { get; set; }
        //public string Photo { get; set; }
        public long DivisionId { get; set; }

        public long DistrictId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FathersNameBangla { get; set; }
        public string FathersNameEnglish { get; set; }
        public string MothersNameBangla { get; set; }
        public string MothersNameEnglish { get; set; }
        public string oclsd { get; set; }
        public long EmployeeStatusId { get; set; }
        public string OtherReligion { get; set; }
        public bool FreedomFighter { get; set; }
        public bool ChildGrandChildOfFreedomFighter { get; set; }
        public string BloodGroup { get; set; }

        public int? RecruitmentType { get; set; }
        public long GenderId { get; set; }
        public long MaritalStatusId { get; set; }
        public int? ReligionId { get; set; }
        public string TIN { get; set; }
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
        public long? RankId { get; set; }
        public long? DesignationId { get; set; }
        public string RankName { get; set; }
        public string DesignationName { get; set; }
        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public string PoliceStationName { get; set; }
        public string RecruitPromo { get; set; }
        public long? PostingTypeId { get; set; }
        public string PostingType { get; set; }
        public long? PostingPlaceId { get; set; }
        public string PostingPlace { get; set; }
        public DateTime? FirstJoiningDate { get; set; }
        public DateTime? PRLDate { get; set; }
        public string EmployeeStatusName { get; set; }
        public string RecruitmentTypeName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatusName { get; set; }
        public string ReligionName { get; set; }
        public DateTime? PostingFromDate { get; set; }
        public DateTime? PostingToDate { get; set; }
        public DateTime? PromotionDate { get; set; }
        public string AttachmentPosting { get; set; }
        public int TotalRowCount { get; set; }
        public string GradationTypeName { get; set; }
        public bool HasUser { get; set; }


    }
}

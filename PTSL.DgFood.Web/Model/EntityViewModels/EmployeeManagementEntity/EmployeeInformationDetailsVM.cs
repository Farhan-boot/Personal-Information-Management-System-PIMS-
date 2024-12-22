using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class EmployeeInformationDetailsVM
    {
        public long Id { get; set; }
        public string GovtID { get; set; }
        public string NationalID { get; set; }
        public string NameBangla { get; set; }
        public string FathersNameBangla { get; set; }
        public string NameEnglish { get; set; }
        public string FathersNameEnglish { get; set; }
        public string DistrictName { get; set; }

        public string MothersNameBangla { get; set; } 
        public DateTime DateOfBirth { get; set; } 
        public string GONumber { get; set; } 
        public DateTime GoDate { get; set; } 
        public DateTime CadreDate { get; set; } 
        public String Religion { get; set; } 
        public string Gender { get; set; } 
        public bool FreedomFighter { get; set; } 
        public string MaritalStatus { get; set; } 
        public bool ChildGrandChildOfFreedomFighter { get; set; } 
        public string EmployeeStatusName { get; set; } 
        public string BloodGroup { get; set; } 
        public string OfficialRemarks { get; set; } 
        public string PresentRank { get; set; } 
        public string PresentClass { get; set; } 
        public string PresentDesignatin { get; set; } 
        public string PresentJoiningDate { get; set; } 
        public string PresentOfficeType { get; set; } 
        public string PresentPostingPlace { get; set; } 
        public string PresentPrlDate { get; set; } 
        public string PresentSection { get; set; } 
        public string PresentDeputation { get; set; } 
        public string PresentDeputationPosting { get; set; } 
        public string JoiningRank { get; set; } 
        public string JoiningClass { get; set; } 
        public string JoiningDesignatin { get; set; } 
        public string JoiningDate { get; set; } 
        public string JoiningOfficeType { get; set; } 
        public string JoiningPostingPlace { get; set; } 
        public string JoiningSection { get; set; } 
        public string presentAddressInBangla { get; set; } 
        public string permanentAddressInBangla { get; set; } 
        public string presentAddressInEnglish { get; set; } 
        public string permanentAddressInEnglish { get; set; } 
        public string presentAddressDivision { get; set; } 
        public string permanentAddressDivision { get; set; } 
        public string presentAddressDistrict { get; set; } 
        public string permanentAddressDistrict { get; set; } 
        public string presentAddressPoliceStation { get; set; } 
        public string permanentAddressPoliceStation { get; set; } 
        public string presentAddressOtherThana { get; set; } 
        public string permanentAddressOtherThana { get; set; } 
        public string presentAddressPoInBangla { get; set; } 
        public string permanentAddressPoInBangla { get; set; } 
        public string presentAddressPoInEnglish { get; set; } 
        public string permanentAddressPoInEnglish { get; set; } 
        public string presentAddressTelephone { get; set; } 
        public string permanentAddressTelephone { get; set; } 
        public string spouseInfoNameInBangla { get; set; } 
        public string spouseInfoNameInEnglish { get; set; } 
        public string spouseInfoDivision { get; set; } 
        public string spouseInfoDistrict { get; set; } 
        public string spouseInfoOccupation { get; set; } 
        public string spouseInfoDesignation { get; set; } 
        public string spouseInfoLocation { get; set; } 
        public List<ChildrenInformationListVM> ChildrenInformations { get; set; } 
        public List<EducationalQualificationListVM> EducationalQualifications { get; set; } 
        public List<TrainingInfoListVM> TrainingInformations { get; set; } 
        public List<PromotionParticularsListVM> PromotionPartculars { get; set; } 
        public List<PostingRecordsListVM> PostingRecords { get; set; } 
        public List<LanguageInfoListVM> LanguageInformations { get; set; } 
    }
}

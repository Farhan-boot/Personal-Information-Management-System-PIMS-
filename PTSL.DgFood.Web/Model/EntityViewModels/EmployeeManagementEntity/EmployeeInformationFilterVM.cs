using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class EmployeeInformationFilterVM
    {
        public long? Id { get; set; }
        public string Email { get; set; }
        public long? DivisionId { get; set; }
        public long? DistrictId { get; set; }
        public long? EmployeeStatusId { get; set; }
        public long? PoliceStationId { get; set; }
        public long? PostingTypeId { get; set; }
        public long? PostingId { get; set; }
        public long? RankId { get; set; }
        public long? DesignationId { get; set; }
        public string EmployeeCode { get; set; }

        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int RecordCount { get; set; } = 0;
        public DateTime? DateOfBirth { get; set; } = null;
        public string NameEnglish { get; set; } = null;
        public string Designation { get; set; } = null;
        public string Grade { get; set; } = null;
        public string PromoRecruit { get; set; } = null;
        public string PostingPlace { get; set; } = null;
        public string MobileNumber { get; set; } = null;
        public DateTime? FirstJoiningDate { get; set; } = null;
        public DateTime? PRLFromDate { get; set; } = null;
        public DateTime? PRLToDate { get; set; } = null;
        public long GradationTypeId { get; set; }
        public string BloodGroup { get; set; }
        public bool ReturnAllRow { get; set; } = false;
    }
}

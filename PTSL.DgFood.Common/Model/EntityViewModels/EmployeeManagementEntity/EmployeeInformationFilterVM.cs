
using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
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

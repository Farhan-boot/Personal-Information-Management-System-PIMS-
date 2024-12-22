using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model
{
    public class HomeViewModel
    {
        public long EmployeeStatusId { get; set; }
        public long DesignationId { get; set; }
        public long DivisionId { get; set; }
        public long DistrictId { get; set; }
        public long PoliceStationId { get; set; }
        public long GradationTypeId { get; set; }
        public DateTime? FirstJoiningDate { get; set; } = null;
        public DateTime? PRLFromDate { get; set; } = null;
        public DateTime? PRLToDate { get; set; } = null;
        public string BloodGroup { get; set; }

        public DateTime TransferFromDate { get; set; }
        public DateTime TransferToDate { get; set; }
        public DateTime PromotionFromDate { get; set; }
        public DateTime PromotionToDate { get; set; }

        public DateTime TrainingFromDate { get; set; }
        public DateTime TrainingToDate { get; set; }

        public long? CategoryId { get; set; }
        public long? PresentStatusId { get; set; }

        public long TrainingManagementMasterId { get; set; }
    }
}
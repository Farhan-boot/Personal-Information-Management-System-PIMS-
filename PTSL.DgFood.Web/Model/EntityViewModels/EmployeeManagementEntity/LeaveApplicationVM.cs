using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class LeaveApplicationVM : BaseModel
    {
        public long LeaveTypeInformationId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? CancelledDate { get; set; }
        public int LeaveDays { get; set; }
        public LeaveStatus LeaveStatus { get; set; }
        [MaxLength(100)]
        public string LeaveAuthority { get; set; }
        [MaxLength(100)]
        public string LeaveSubject { get; set; }
        [MaxLength(100)]
        public string MemoNO { get; set; }
        [MaxLength(100)]
        public string LeaveReason { get; set; }
        [MaxLength(20)]
        public string EmergencyContact { get; set; }
        [MaxLength(200)]
        public string EmergencyAddress { get; set; }
        public string Comments { get; set; }
        public bool IsHeadOfOffice { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public virtual LeaveTypeInformationVM LeaveTypeInformationDTO { get; set; }

    }
}

using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
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
        public string LeaveAuthority { get; set; }
        public string LeaveSubject { get; set; }
        public string MemoNO { get; set; }
        public string LeaveReason { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyAddress { get; set; }
        public string Comments { get; set; }
        public bool IsHeadOfOffice { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public virtual LeaveTypeInformationVM LeaveTypeInformationDTO { get; set; }

    }
}

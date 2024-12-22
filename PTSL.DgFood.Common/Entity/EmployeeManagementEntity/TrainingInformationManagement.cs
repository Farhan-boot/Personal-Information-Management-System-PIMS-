using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class TrainingInformationManagement : BaseEntity
    {
        public long TrainingInformationManagementMasterId { get; set; }
        public long? RankId { get; set; }
        public long? DesignationId { get; set; }
        public long EmployeeInformationId { get; set; }
        public bool Status { get; set; }
        public string Grade { get; set; }
        public string Position { get; set; }
        public string CertificateDocumentURI { get; set; }
        public TrainingInformationManagementApprovalStatus ApprovalStatus { get; set; }
        public TrainingInformationManagementMaster TrainingInformationManagementMaster { get; set; } 
        public EmployeeInformation EmployeeInformation { get; set; }
    }
}

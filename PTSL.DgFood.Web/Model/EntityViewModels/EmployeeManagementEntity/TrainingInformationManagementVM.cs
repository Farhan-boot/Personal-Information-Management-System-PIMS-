using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity
{
    public class TrainingInformationManagementVM : BaseModel
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
        public TrainingInformationManagementMasterVM TrainingInformationManagementMasterDto { get; set; }
        public EmployeeInformationVM EmployeeInformationDto { get; set; }
        public HttpPostedFileBase Certificate { get; set; }
	}
}
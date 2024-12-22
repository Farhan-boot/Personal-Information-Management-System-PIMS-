using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class TrainingInformationManagementMaster : BaseEntity
    { 
        public long TrainingManagementTypeId { get; set; }
        public bool Status { get; set; }
        public TrainingManagementType TrainingManagementType { get; set; }
        public List<TrainingInformationManagement> TrainingInformationManagements { get; set; }
	}
}

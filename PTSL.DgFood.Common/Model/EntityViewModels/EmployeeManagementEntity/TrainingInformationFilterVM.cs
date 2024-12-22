using System;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class TrainingInformationFilterVM
    { 
        public long EmployeeInformationId { get; set; }
        public DateTime? TrainingFromDate { get; set; }
        public DateTime? TrainingToDate { get; set; }
    }
}

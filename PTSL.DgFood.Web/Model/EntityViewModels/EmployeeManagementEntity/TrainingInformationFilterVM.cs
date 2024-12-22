using System;

namespace PTSL.DgFood.Web.Model
{
    public class TrainingInformationFilterVM
    { 
        public long EmployeeInformationId { get; set; } 
        public DateTime? TrainingFromDate { get; set; }
        public DateTime? TrainingToDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class TrainingInfoListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        public string InstituteName { get; set; }
        public string CourseTitle { get; set; }
        public DateTime? PeriodFrom {get;set;}
        public DateTime? PeriodTo {get;set;}
    }
}

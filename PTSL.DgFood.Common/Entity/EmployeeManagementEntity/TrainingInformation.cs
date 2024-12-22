using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
   public class TrainingInformation : BaseEntity
    {
        public string CourseTitle { get; set; }
        public string Institute { get; set; }
        public string Location { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Grade { get; set; }
        public string Position { get; set; }
        public long EmployeeInformationId { get; set; }
        //public long TrainingTypeId { get; set; }
        //public long? CountryId { get; set; }
        public Country? CountryId { get; set; }
        public TrainingType TrainingTypeId { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
    }
}

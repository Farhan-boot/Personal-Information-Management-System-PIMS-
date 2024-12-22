using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class TrainingInformationVM : BaseModel
    {
        [MaxLength(100)]
        public string CourseTitle { get; set; }
        [MaxLength(100)]
        public string Institute { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        [MaxLength(10)]
        public string Grade { get; set; }
        [MaxLength(100)]
        public string Position { get; set; }
        public long EmployeeInformationId { get; set; }
        //public long TrainingTypeId { get; set; }
        //public long? CountryId { get; set; }
        public Country? CountryId { get; set; }
        public TrainingType TrainingTypeId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
    }
}

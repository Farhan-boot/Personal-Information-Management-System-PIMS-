using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class OtherServiceInfoVM : BaseModel
    {
        [MaxLength(250)]
        public string EmployerName { get; set; }
        public string EmpAddress { get; set; }
        [MaxLength(250)]
        public string OtherServiceType { get; set; }
        [MaxLength(250)]
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
    }
}

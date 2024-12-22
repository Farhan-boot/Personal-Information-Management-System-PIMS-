using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class ForeignTravelInfoVM : BaseModel
    {
        public Country Country { get; set; }
        [MaxLength(250)]
        public string Purpose { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
    }
}

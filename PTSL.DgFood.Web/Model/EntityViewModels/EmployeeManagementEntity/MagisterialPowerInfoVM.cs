using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class MagisterialPowerInfoVM : BaseModel
    {
        [MaxLength(250)]
        public string Power { get; set; }
        public DateTime? DateOfNotification { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }

    }
}

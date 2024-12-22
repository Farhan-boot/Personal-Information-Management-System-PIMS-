using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class AwardInformationVM : BaseModel
    {
        [MaxLength(250)]
        public string AwardName { get; set; }
        [MaxLength(250)]
        public string AwardGround { get; set; }
        public DateTime AwardDate { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }

    }
}

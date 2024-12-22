
using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class Addl_prof_q_infoVM : BaseModel
    {
        [MaxLength(500)]
        public string Description { get; set; } 
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }

    }
}

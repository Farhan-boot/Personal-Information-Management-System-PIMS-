using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class PublicationInfoVM : BaseModel
    {
        [MaxLength(250)]
        public string PublicationType { get; set; }
        [MaxLength(250)]
        public string PublicationName { get; set; }
        public DateTime PublicationDate { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
    }
}

using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class ChildrenInformationVM : BaseModel
    {
        public int SlNo { get; set; }
        [MaxLength(100)]
        public string NameInEnglish { get; set; }
        [MaxLength(100)]
        public string NameInBangla { get; set; }
        //public long GenderId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public Gender GenderId { get; set; }

    }
}

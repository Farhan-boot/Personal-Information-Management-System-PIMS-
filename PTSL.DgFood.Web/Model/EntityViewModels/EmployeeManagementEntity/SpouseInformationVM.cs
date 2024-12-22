using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class SpouseInformationVM : BaseModel
    {
        [MaxLength(100)]
        public string NameInBangla { get; set; }
        [MaxLength(100)]
        public string NameInEnglish { get; set; }
        public long DivisionId { get; set; }
        public long DistrictId { get; set; }
        public long EmployeeInformationId { get; set; }
        [MaxLength(100)]
        public string Occupation { get; set; }
        [MaxLength(100)]
        public string Designation { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        public virtual DivisionVM DivisionDTO { get; set; }
        public virtual DistrictVM DistrictDTO { get; set; }
        //public virtual EmployeeInformation EmployeeInformation { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class EmployeeTypeVM : BaseModel
    {
        [MaxLength(100)]
        public string EmployeeTypeName { get; set; }
        public string EmployeeTypeNameBn { get; set; }
        public IList<OfficialInformationVM> OfficialInformationList { get; set; }
    }
}

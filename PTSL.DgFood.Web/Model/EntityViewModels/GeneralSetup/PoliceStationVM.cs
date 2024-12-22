using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PoliceStationVM : BaseModel
    {
        [MaxLength(100)]
        public string PoliceStationName { get; set; }
        [MaxLength(100)]
        public string PoliceStationNameBangla { get; set; }
        public long DistrictId { get; set; }
        public virtual DistrictVM DistrictDTO { get; set; }
        public IList<EmployeeInformationVM> EmployeeInformationList { get; set; }
    }
}

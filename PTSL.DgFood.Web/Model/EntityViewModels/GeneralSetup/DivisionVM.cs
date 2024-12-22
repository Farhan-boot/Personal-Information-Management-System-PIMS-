using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class DivisionVM : BaseModel
    {
        [MaxLength(100)]
        public string DivisionName { get; set; }
        [MaxLength(100)]
        public string DivisionNameBangla { get; set; }
        public List<DistrictVM> DistrictList { get; set; }
        //public IList<PermanentAddress> PermanentAddresses { get; set; }
        //public IList<PresentAddress> PresentAddresses { get; set; }
        //public IList<SpouseInformation> SpouseInformation { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }

        //Add New
        public string GeoCode { get; set; }
    }
}

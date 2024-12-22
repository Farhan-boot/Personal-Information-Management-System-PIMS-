using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class SpouseInformationListVM
    {
        public long Id { get; set; }
        public string NameInBangla {get;set;}
        public string NameInEnglish { get; set; }
        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public long EmployeeInformationId { get; set; }
        public string Occupation { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
    }
}

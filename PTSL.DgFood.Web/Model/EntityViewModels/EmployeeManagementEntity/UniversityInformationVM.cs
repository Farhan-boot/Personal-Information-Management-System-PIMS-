using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity
{
    public class UniversityInformationVM : BaseModel
    {
        public string UniversityName { get; set; }
        public string UniversityNameBn { get; set; }
        public string Acronym { get; set; }
        public long? EstablishedYear { get; set; }
        public string Location { get; set; }
    }
}
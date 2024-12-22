using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class UniversityInformation : BaseEntity
    {
        public string? UniversityName { get; set; }
        public string? UniversityNameBn { get; set; }
        public string? Acronym { get;set;}
        public long? EstablishedYear { get; set; }
        public string? Location { get; set; }
    }
}

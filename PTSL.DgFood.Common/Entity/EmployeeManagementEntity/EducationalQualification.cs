using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class EducationalQualification : BaseEntity
    {
        public string? NameOfTheInstitute { get; set; }
        public string PrincipalSubject {get;set;}
        public long? DegreeId { get; set; }
        public string PassingYear { get; set; }
        public string ResultOrDivision { get; set; }
        public string GPAOrCGPA { get; set; }
        public string Distinction { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
        public virtual Degree Degree { get; set; }
        //New
        public long? UniversityInformationId { get; set; }

    }
}
